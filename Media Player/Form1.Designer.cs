namespace Media_Player
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.controlLabel = new System.Windows.Forms.Label();
            this.volBar = new System.Windows.Forms.TrackBar();
            this.forwardButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.playListPanel = new System.Windows.Forms.Panel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.playlistsLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.songGrid = new System.Windows.Forms.DataGridView();
            this.songColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.songLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volBar)).BeginInit();
            this.playListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.controlLabel);
            this.controlPanel.Controls.Add(this.volBar);
            this.controlPanel.Controls.Add(this.forwardButton);
            this.controlPanel.Controls.Add(this.playButton);
            this.controlPanel.Controls.Add(this.prevButton);
            this.controlPanel.Location = new System.Drawing.Point(185, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(346, 61);
            this.controlPanel.TabIndex = 0;
            // 
            // controlLabel
            // 
            this.controlLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlLabel.Location = new System.Drawing.Point(41, 5);
            this.controlLabel.Name = "controlLabel";
            this.controlLabel.Size = new System.Drawing.Size(100, 23);
            this.controlLabel.TabIndex = 4;
            this.controlLabel.Text = "Controls";
            this.controlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volBar
            // 
            this.volBar.Location = new System.Drawing.Point(167, 12);
            this.volBar.Name = "volBar";
            this.volBar.Size = new System.Drawing.Size(176, 45);
            this.volBar.TabIndex = 3;
            this.volBar.Scroll += new System.EventHandler(this.volBar_Scroll);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(120, 34);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(44, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = ">>";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(70, 34);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(44, 23);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(20, 34);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(44, 23);
            this.prevButton.TabIndex = 0;
            this.prevButton.Text = "<<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // playListPanel
            // 
            this.playListPanel.Controls.Add(this.picBox);
            this.playListPanel.Controls.Add(this.addButton);
            this.playListPanel.Controls.Add(this.playlistBox);
            this.playListPanel.Controls.Add(this.playlistsLabel);
            this.playListPanel.Controls.Add(this.deleteButton);
            this.playListPanel.Controls.Add(this.loadButton);
            this.playListPanel.Controls.Add(this.newButton);
            this.playListPanel.Location = new System.Drawing.Point(12, 3);
            this.playListPanel.Name = "playListPanel";
            this.playListPanel.Size = new System.Drawing.Size(167, 264);
            this.playListPanel.TabIndex = 1;
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(5, 160);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(157, 98);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 6;
            this.picBox.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(58, 63);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(49, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // playlistBox
            // 
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.ItemHeight = 15;
            this.playlistBox.Location = new System.Drawing.Point(3, 90);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(159, 64);
            this.playlistBox.TabIndex = 4;
            this.playlistBox.DoubleClick += new System.EventHandler(this.playlistBox_DoubleClick);
            // 
            // playlistsLabel
            // 
            this.playlistsLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playlistsLabel.Location = new System.Drawing.Point(32, 2);
            this.playlistsLabel.Name = "playlistsLabel";
            this.playlistsLabel.Size = new System.Drawing.Size(100, 30);
            this.playlistsLabel.TabIndex = 3;
            this.playlistsLabel.Text = "Playlists";
            this.playlistsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(113, 34);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(49, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(58, 34);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(49, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(3, 34);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(49, 23);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.songGrid);
            this.dataPanel.Controls.Add(this.songLabel);
            this.dataPanel.Location = new System.Drawing.Point(185, 70);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(346, 197);
            this.dataPanel.TabIndex = 2;
            // 
            // songGrid
            // 
            this.songGrid.AllowUserToOrderColumns = true;
            this.songGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.songGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.songColumn,
            this.duration,
            this.dataGridViewTextBoxColumn1});
            this.songGrid.Location = new System.Drawing.Point(4, 36);
            this.songGrid.Name = "songGrid";
            this.songGrid.RowTemplate.Height = 25;
            this.songGrid.Size = new System.Drawing.Size(342, 155);
            this.songGrid.TabIndex = 6;
            this.songGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.songGrid_CellContentDoubleClick);
            this.songGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.songGrid_CellMouseClick);
            this.songGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.songGrid_CellMouseDown);
            // 
            // songColumn
            // 
            this.songColumn.HeaderText = "name";
            this.songColumn.Name = "songColumn";
            // 
            // duration
            // 
            this.duration.HeaderText = "duration";
            this.duration.Name = "duration";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "artist";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // songLabel
            // 
            this.songLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.songLabel.Location = new System.Drawing.Point(41, 2);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(100, 33);
            this.songLabel.TabIndex = 5;
            this.songLabel.Text = "Songs";
            this.songLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // rightMenu
            // 
            this.rightMenu.Name = "rightMenu";
            this.rightMenu.Size = new System.Drawing.Size(96, 22);
            this.rightMenu.Text = "play";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 276);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.playListPanel);
            this.Controls.Add(this.controlPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volBar)).EndInit();
            this.playListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel controlPanel;
        private Label controlLabel;
        private TrackBar volBar;
        private Button forwardButton;
        private Button playButton;
        private Button prevButton;
        private Panel playListPanel;
        private Label playlistsLabel;
        private Button deleteButton;
        private Button loadButton;
        private Button newButton;
        private Panel dataPanel;
        private DataGridView songGrid;
        private Label songLabel;
        private ListBox playlistBox;
        private DataGridViewTextBoxColumn songColumn;
        private DataGridViewTextBoxColumn duration;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Button addButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem rightMenu;
        private PictureBox picBox;
    }
}