using WMPLib;
using System.IO;
using System.ComponentModel;
using TagLib.Mpeg;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Media_Player
{
    //whats left to do
    //alternate play modes ie shuffle implemented in a polymorphic design pattern
    public partial class Form1 : Form
    {
        //creating a windows media player object which is used to play music later on the play button action listener
        WMPLib.WindowsMediaPlayer player;

        //strings to be used for creating new playlists and adding them to the playlistbox
        //lists for working with the playlists and songs in the playlists
        string projFolder, playlistFolder;
        BindingList<string> masterList = new BindingList<string>();
        BindingList<string> addressList = new BindingList<string>();

        //boolean to track the windows media player playlist so that double click play functionality works
        bool playListLoaded = false;



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

                //masterlist is the data source for the list box and has the cleaned names of each playlist 
                masterList.Add(fileName);
                
                //address list holds the paths of each playlist so the rest of the program can find them easily
                addressList.Add(file);
            }

            //sets the listbox datasource
            playlistBox.DataSource = masterList;
            
            //making sure the datagrid is clear of old stuff from other playlists
            songGrid.Rows.Clear();

            //instantiating the media player
            player = new WMPLib.WindowsMediaPlayer();
            
            //setting up the volume slider
            volBar.Minimum = 0;
            volBar.Maximum = 100;
            volBar.TickFrequency = 5;
            volBar.Value = player.settings.volume;
            
            //setting up the functionality for the context menu and subscribing to the right click function
            songGrid.ContextMenuStrip = contextMenuStrip1;
            rightMenu.Click += playToolStripMenuItem_Click;
            
            //setting the songGrid so that users cant change the data in each cell
            songGrid.ReadOnly = true;
        }


        //function to load mediaplayer playlist for the purpose of controlls
        private void loadPlaylist(string playListPath, int startIndex)
        {

            //checking the loaded playlist tag 
            if (playListLoaded) return;

            //reading songs from the current play list into a list collection
            var curSongs = System.IO.File
             .ReadAllLines(playListPath)
             .Where(l => !string.IsNullOrWhiteSpace(l))
             .ToList();

            //creating the mediaplayer playlist object for the purpose of actually playing the songs then adding the songs to the playlist
            IWMPPlaylist tempPlayList = player.playlistCollection.newPlaylist("temp");//consider changing temp so the playlists have unique names maybe get it so that 
            for (int i = startIndex; i < curSongs.Count; i++)
            {
                tempPlayList.appendItem(player.newMedia(curSongs[i]));
            }

            //setting the mediaplayer playlist to the temp list and the currently selected song to the one selected in songGrid
            player.currentPlaylist = tempPlayList;
            //MessageBox.Show($"idnex: {startIndex}");
            player.controls.currentItem = tempPlayList.Item[0];
            playListLoaded = true;
        }

        
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
            //setting the playListLoaded bool to false so the playlist will reload on the next call
            playListLoaded = false;
        }

        //actionlistener for playbutton clicked
        private void playButton_Click(object sender, EventArgs e)
        {
            //getting the currently selected playlist and songGird item
            int selection = songGrid.CurrentCell.RowIndex;
            string curPlayList = addressList[playlistBox.SelectedIndex];

            //calling the loadPlayList function 
            loadPlaylist(curPlayList,selection);

            //control logic acting as a pause/play button in the case a song is actively playing it will pause on press
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }


        //actionlistener for when an item in the listbox is double clicked this will load the current selected playlist into the data grid
        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            //make sure something is selected
            if (playlistBox.SelectedIndex < 0) return;

            //getting the currently selected playlist
            string curPlayList = addressList[playlistBox.SelectedIndex];
            
            //calling gridupdate 
            gridUpdate(curPlayList);
        }

        //actionlistener for when the add button is clicked it adds an mp3 to the currently selected playlist
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

                //checking the result from the filedialog was ok then adding the mp3 path to the playlist file, finally calls gridupdate to add the new song to the songGrid
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

        private void volBar_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = volBar.Value;
        }

        //function that fires when something in songGrid is double clicked it will play the selected song stopping whatever was previously playing if anything
        private void songGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //getting current songGrid selection and current playlist address
            int selection = songGrid.CurrentCell.RowIndex;
            string curPlayList = addressList[playlistBox.SelectedIndex];;

            //sets playlist loaded flag to false so it can be updated on the next call then loads the windows playlist, stops the current playing song, and finally plays the new song
            playListLoaded = false;
            loadPlaylist(curPlayList, selection);
            player.controls.stop();
            player.controls.play();
        }

        //function for firing the context menu on songgrid right click
        private void songGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checking it is the correct right mouse button down and the selected cell exists
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                songGrid.ClearSelection();
                songGrid.Rows[e.RowIndex].Selected = true;
                songGrid.CurrentCell = songGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        //code for play button in the right click menu 
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //checking there are rows in the data grid
            if(songGrid.SelectedRows.Count == 0) return;
            int selection = songGrid.CurrentCell.RowIndex;
            string curPlayList = addressList[playlistBox.SelectedIndex];
            
            //reloads the windows playlist and then runs control logic for play/pause functionality
            loadPlaylist(curPlayList, selection);
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }

        //on left click of a row in songGrid function will load the album art into picBox
        private void songGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //making sure theres a row slected in the songGrid
            if (songGrid.CurrentRow == null) return;
            
            //getting current selections 
            int selection = songGrid.CurrentCell.RowIndex;
            string curPlayList = addressList[playlistBox.SelectedIndex];
            
            //adding songs from current playlist to a list 
            var curSongs = System.IO.File
             .ReadAllLines(curPlayList)
             .Where(l => !string.IsNullOrWhiteSpace(l))
             .ToList();
            
            //getting the songpath from the playlist file
            string songPath = curSongs[selection];
            
            //creating a taglib object to get the album pictures from
            var tfile = TagLib.File.Create(songPath.Trim('"'));
            var pics = tfile.Tag.Pictures;
            
            //making sure there was picture meta data in the mp3
            if(pics != null && pics.Length > 0) 
            {
                //getting the first picture if there is more than one
                var firstPic = pics[0];

                //converting picture data to an actual image then setting it as a picture box image
                byte[] bin = firstPic.Data.Data;
                using (var ms = new MemoryStream(bin))
                {
                    Image albumCover = Image.FromStream(ms);
                    picBox.Image?.Dispose();
                    picBox.Image = albumCover;
                }
            }
        }

        //actionlistener for deleting songs from playlists
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //making sure there is a row selected
            if (songGrid.CurrentRow == null) return;

            //getting the current selected song and playlist
            int selection = songGrid.CurrentCell.RowIndex;
            string curPlayList = addressList[playlistBox.SelectedIndex];
            
            //opening the current playlist as a list 
            var curSongs = System.IO.File
             .ReadAllLines(curPlayList)
             .Where(l => !string.IsNullOrWhiteSpace(l))
             .ToList();
            
            //removing the selected song 
            curSongs.RemoveAt(selection);
            
            //writing the updated list to the playlist file and updating the grid to match 
            System.IO.File.WriteAllLines(curPlayList, curSongs);
            gridUpdate(curPlayList);
        }


        //actionlistener for when newbutton is clicked creating a savedialog and a new playlist
        private void newButton_Click(object sender, EventArgs e)
        {
            string fName;
            //filedialog to create a new text file 
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
                    masterList.Add(fName);
                    addressList.Add(path);
                }
            }
        }
    }
}