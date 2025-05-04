using WMPLib;
using System.IO;
using System.ComponentModel;

namespace Media_Player
{

    //what does this need
    //the song display is actually pretty good I just need to figure out how to programmatically create new rows for each song in a playlist
    //first i should just get the filedialog and creation of a single playlist
    //then get the master playlist to load up all my indivdual playlists
    //that should be basic functionality
    //then its forward/backward creating/edit playlists and adding removing songs
    //then its right click menu polymorphism
    //get album art with Taglib.Picture somehow then load that into a picture form component
    public partial class Form1 : Form
    {
        //creating a windows media player object which is used to play music later on the play button action listener
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        //strings to be used for creating new playlists and adding them to the playlistbox
        string projFolder, playlistFolder;
        BindingList<string> masterList = new BindingList<string>();

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
            }
            playlistBox.DataSource = masterList;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //right now just gives the address of an mp3 in the projects bin folder to the music player this needs to be done from the currently active playlist
            player.URL = "04. I Am Above.mp3";
            
            //plays the previously passed song no error checking yet
            player.controls.play();

            //setting the songs title to the datagrid eventually this will set all the meta data such as length and artist 
            var tfile = TagLib.File.Create(@player.URL);
            string title = tfile.Tag.Title;
            songGrid[0,0].Value = title;
        }

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
                    File.Create(path);
                    fName = Path.GetFileName(dlg.FileName);
                    //playlistBox.Items.Add(fName);
                    masterList.Add(fName);
                }
            }
        }
    }
}