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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.controlLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.forwardButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.playListPanel = new System.Windows.Forms.Panel();
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
            this.addButton = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.playListPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.controlLabel);
            this.controlPanel.Controls.Add(this.trackBar1);
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(167, 12);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(176, 45);
            this.trackBar1.TabIndex = 3;
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(120, 34);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(44, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = ">>";
            this.forwardButton.UseVisualStyleBackColor = true;
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
            // 
            // playListPanel
            // 
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
            // playlistBox
            // 
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.ItemHeight = 15;
            this.playlistBox.Location = new System.Drawing.Point(3, 90);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(159, 169);
            this.playlistBox.TabIndex = 4;
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
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(58, 63);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(49, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.playListPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.songGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel controlPanel;
        private Label controlLabel;
        private TrackBar trackBar1;
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
    }
}