using WMPLib;
using System.IO;
namespace Media_Player
{

    //what does this need
    //create a playlist
    //filedialog to get playlist save loc
    //name playlist which will become a text file at the save loc
    //what is in a playlist? just song paths probably
    // i need a way to display a list of playlists so maybe a list of playlist address a master playlist
    //i need to figure out how im going to display or swap between playlists though 
    //the song display is actually pretty good I just need to figure out how to programmatically create new rows for each song in a playlist
    //first i should just get the filedialog and creation of a single playlist
    //then get the master playlist to load up all my indivdual playlists
    //that should be basic functionality
    //then its forward/backward creating/edit playlists and adding removing songs
    //then its right click menu polymorphism
    public partial class Form1 : Form
    {
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        //var tfile = TagLib.File.Create

        //strings to be used for creating new playlists and adding them to the playlistbox
        string projFolder, playlistFolder;
        List<string> masterList = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //creating the primary playlist folder
            projFolder = Path.GetDirectoryName(Application.ExecutablePath);
            playlistFolder = Path.Combine(projFolder, "playlists");
            Directory.CreateDirectory(playlistFolder);

            //loads playlists already in the primary playlist folder
            var playLists = Directory.GetFiles(playlistFolder, "*.txt");
            foreach (var file in playLists)
            {
                string fileName = Path.GetFileName(file);
                //playlistBox.Items.Add(fileName);
                masterList.Add(file);
            }
            playlistBox.DataSource.Equals(masterList);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            player.URL = "04. I Am Above.mp3";
            player.controls.play();
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
                
                //
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string path = dlg.FileName;
                    File.Create(path);
                    fName = Path.GetFileName(dlg.FileName);
                    playlistBox.Items.Add(fName);
                }
            }
        }
    }
}