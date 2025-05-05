using WMPLib;
using System.IO;
using System.ComponentModel;
using TagLib.Mpeg;

namespace Media_Player
{
    //whats left to do
    //play button
    //delete button to remove song from a playlist dump the contents of the playlist file into a list then delete the correct index from the list then resave it to the playlist
    //forward/backward button
    //volume/tracker bar
    //double click songs this can just fire play 
    //right click playlist
    //right click songs
    //use album artork
    //alternate play modes ie shuffle implemented in a polymorphic design pattern
    //move repeated code segements out to seperate functions ie updating datagrid 
    public partial class Form1 : Form
    {
        //creating a windows media player object which is used to play music later on the play button action listener
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        //strings to be used for creating new playlists and adding them to the playlistbox
        string projFolder, playlistFolder;
        BindingList<string> masterList = new BindingList<string>();
        BindingList<string> addressList = new BindingList<string>();


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
                //playlistBox.Items.Add(fileName);
                masterList.Add(fileName);
                addressList.Add(file);
            }
            playlistBox.DataSource = masterList;
            songGrid.Rows.Clear();
        }


        private void gridUpdate(string curPlayList)
        {
            string line;
            int inc = 0;
            songGrid.Rows.Clear();
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
        }

        //actionlistener for playbutton clicked
        private void playButton_Click(object sender, EventArgs e)
        {
            //right now just gives the address of an mp3 in the projects bin folder to the music player this needs to be done from the currently active playlist
            player.URL = "04. I Am Above.mp3";
            
            //plays the previously passed song no error checking yet
            player.controls.play();

            //setting the songs title to the datagrid eventually this will set all the meta data such as length and artist 
            var tfile = TagLib.File.Create("D:\\coding projects\\school projects\\c#\\Final\\Media Player\\Media Player\\bin\\Debug\\net7.0-windows\\04. I Am Above.mp3");
            string title = tfile.Tag.Title;
            songGrid[1,0].Value = title;
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