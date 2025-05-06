using WMPLib;
using System.IO;
using System.ComponentModel;
using TagLib.Mpeg;
using System.Windows.Forms;

namespace Media_Player
{
    //whats left to do
    //delete button to remove song from a playlist dump the contents of the playlist file into a list then delete the correct index from the list then resave it to the playlist
    //volume/tracker bar
    //double click songs this can just fire play 
    //right click playlist
    //right click songs
    //use album artork
    //alternate play modes ie shuffle implemented in a polymorphic design pattern
    public partial class Form1 : Form
    {
        //creating a windows media player object which is used to play music later on the play button action listener
        WMPLib.WindowsMediaPlayer player;

        //strings to be used for creating new playlists and adding them to the playlistbox
        string projFolder, playlistFolder;
        BindingList<string> masterList = new BindingList<string>();
        BindingList<string> addressList = new BindingList<string>();
        bool playListLoaded = false;
        //List<string> curSongs = new List<string>();
        int curIndex;


        //constructor for the form
        public Form1()
        {
            InitializeComponent();

            //creating the primary playlist folder if it doesnt already exist
            projFolder = Path.GetDirectoryName(Application.ExecutablePath);
            playlistFolder = Path.Combine(projFolder, "playlists");
            Directory.CreateDirectory(playlistFolder);

            //loads playlists already in the primary playlist folder into a bindinglist which is then set as the data source for the listbox
            //note the bindinglist so the listbox will update as changes are made to the underlying data source such as the case a new playlist is created or deleted
            var playLists = Directory.GetFiles(playlistFolder, "*.txt");
            foreach (var file in playLists)
            {
                string fileName = Path.GetFileName(file);
                masterList.Add(fileName);
                addressList.Add(file);
            }
            playlistBox.DataSource = masterList;
            songGrid.Rows.Clear();
            player = new WMPLib.WindowsMediaPlayer();
            //player.PlayStateChange += Player_PlayStateChange;
        }


        //function to load mediaplayer playlist for the purpose of controlls
        private void loadPlaylist(string playListPath, int startIndex)
        {
            if (playListLoaded) return;

            var curSongs = System.IO.File
             .ReadAllLines(playListPath)
             .Where(l => !string.IsNullOrWhiteSpace(l))
             .ToList();

            IWMPPlaylist tempPlayList = player.playlistCollection.newPlaylist("temp");
            for (int i = startIndex; i < curSongs.Count; i++)
            {
                tempPlayList.appendItem(player.newMedia(curSongs[i]));
            }

            player.currentPlaylist = tempPlayList;
            player.controls.currentItem = tempPlayList.Item[startIndex];
            playListLoaded = true;
        }
        //checking state of media player
        /*private void Player_PlayStateChange(int newState)
        {
            var state = (WMPPlayState)newState;
            MessageBox.Show($"State: {state}");
            if ((WMPPlayState)newState == WMPPlayState.wmppsMediaEnded || (WMPPlayState)newState == WMPPlayState.wmppsStopped || state == WMPPlayState.wmppsReady)
            {
                curIndex++;
                if (curIndex < curSongs.Count)
                {
                    player.URL = curSongs[curIndex];
                    player.controls.play();
                }
            }
        }*/


        //function that updates the data grid compartmentalized for ease of reuse
        private void gridUpdate(string curPlayList)
        {
            //declaring line to hold each song path and a counter to be used in adding the correct meta data to each cell
            string line;
            int inc = 0;
            
            //pre clearing the datagrid so we dont overlap playlist contents
            songGrid.Rows.Clear();
            
            //opening the playlist file so it can be iterated over and the songs can be added with their meta data to the datagrid
            using (var fs = new FileStream(curPlayList, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using var reader = new StreamReader(fs);
                while ((line = reader.ReadLine()) != null)
                {

                    //adds a new row each time the loop runs
                    songGrid.Rows.Add();

                    //creating tfile object to get song meta deta and then adding them to the data grid cells
                    var tfile = TagLib.File.Create(line.Trim('"'));
                    songGrid[0, inc].Value = tfile.Tag.Title;

                    //length is unreiable so its easier to use the duration property instead which is a TimeSpan
                    TimeSpan duration = tfile.Properties.Duration;
                    string minsSecs = $"{duration.Minutes:D2}:{duration.Seconds:D2}";
                    songGrid[1, inc].Value = minsSecs;
                    songGrid[2, inc].Value = tfile.Tag.FirstArtist;
                    inc++;
                }
            }
            playListLoaded = false;
        }

        //actionlistener for playbutton clicked
        private void playButton_Click(object sender, EventArgs e)
        {
            //i need to check if player is playing 
            //if the currently selectd song is playing pause
            //if a different song is playing play the new song


            int selection = songGrid.CurrentCell.RowIndex;
            //string line;
            //List<string> curSongs = new List<string>();
            string curPlayList = addressList[playlistBox.SelectedIndex];

            /*using (var fs = new FileStream(curPlayList, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using var reader = new StreamReader(fs);
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    curSongs.Add(line);
                }
            }

            var curSongs = System.IO.File
             .ReadAllLines(curPlayList)
             .Where(l => !string.IsNullOrWhiteSpace(l))
             .ToList();

            IWMPPlaylist tempPlayList = player.playlistCollection.newPlaylist("temp");
            for (int i = selection; i < curSongs.Count; i++)
            {
                tempPlayList.appendItem(player.newMedia(curSongs[i]));
            }
            /*if (player.playState == WMPPlayState.wmppsPlaying && selection == curIndex)
            {
                player.controls.pause();
                return;
            }
            player.currentPlaylist = tempPlayList;*/
            loadPlaylist(curPlayList,selection);
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
            
            //curIndex = selection;
            //player.URL = curSongs[curIndex];
            //player.controls.play();
            /*(for (int i = curInd; i < curSongs.Count; i++)
            {
                player.URL = curSongs[i];
                player.controls.play();
            }*/
            //do this in a for loop to play the entire play list 
        }


        //actionlistener for when an item in the listbox is double clicked this will load the current selected playlist into the data grid
        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            //make sure something is selected
            if (playlistBox.SelectedIndex < 0) return;
            int inc = 0;
            string line;
            //int selected = playlistBox.SelectedIndex;
            string curPlayList = addressList[playlistBox.SelectedIndex];
            gridUpdate(curPlayList);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //adds song to a playlist ie file dialog to select an mp3 then get the mp3 full path and add it to a new line in the selected playlist 
            if (playlistBox.SelectedIndex < 0) return;
            string curPlayList = addressList[playlistBox.SelectedIndex];
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select an MP3 File";
                dlg.Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
                dlg.DefaultExt = "mp3";
                dlg.AddExtension = true;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                if (dlg.ShowDialog() == DialogResult.OK) 
                {
                    string mp3Path = dlg.FileName;
                    System.IO.File.AppendAllText(curPlayList, mp3Path + Environment.NewLine);
                    gridUpdate(curPlayList);
                }
            }
            
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if(player.controls.isAvailable["next"])
                player.controls.next();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (player.controls.isAvailable["previous"])
                player.controls.previous();
        }


        //actionlistener for when newbutton is clicked creating a savedialog and a new playlist
        private void newButton_Click(object sender, EventArgs e)
        {
            string fName;
            //filedialog to create a new text file in here 
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = "save your playlist";
                dlg.DefaultExt = "txt";
                dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                dlg.InitialDirectory = playlistFolder;
                dlg.AddExtension= true;
                
                //if filedialog return is valid create the playlist and add it to the masterlist which will also cause it to display on the listbox
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string path = dlg.FileName;
                    System.IO.File.Create(path).Dispose();
                    fName = Path.GetFileName(dlg.FileName);
                    //playlistBox.Items.Add(fName);
                    masterList.Add(fName);
                    addressList.Add(path);
                }
            }
        }
    }
}