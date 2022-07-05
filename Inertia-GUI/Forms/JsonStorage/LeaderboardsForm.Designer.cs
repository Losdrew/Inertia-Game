namespace GUI.Forms.JsonStorage
{
    partial class LeaderboardsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaderboardsForm));
            this.BestResultsListView = new System.Windows.Forms.ListView();
            this.NameHeader = new System.Windows.Forms.ColumnHeader();
            this.PrizesCollectedHeader = new System.Windows.Forms.ColumnHeader();
            this.LevelsCompletedHeader = new System.Windows.Forms.ColumnHeader();
            this.GameOversHeader = new System.Windows.Forms.ColumnHeader();
            this.DateHeader = new System.Windows.Forms.ColumnHeader();
            this.AllResultLabel = new System.Windows.Forms.Label();
            this.BestResultsLabel = new System.Windows.Forms.Label();
            this.MenuButton = new System.Windows.Forms.Button();
            this.LatestResultsListView = new System.Windows.Forms.ListView();
            this.NameHeader1 = new System.Windows.Forms.ColumnHeader();
            this.PrizesCollectedHeader1 = new System.Windows.Forms.ColumnHeader();
            this.LevelsCompletedHeader1 = new System.Windows.Forms.ColumnHeader();
            this.GameOverHeader1 = new System.Windows.Forms.ColumnHeader();
            this.DateHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // BestResultsListView
            // 
            resources.ApplyResources(this.BestResultsListView, "BestResultsListView");
            this.BestResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader,
            this.PrizesCollectedHeader,
            this.LevelsCompletedHeader,
            this.GameOversHeader,
            this.DateHeader});
            this.BestResultsListView.Name = "BestResultsListView";
            this.BestResultsListView.UseCompatibleStateImageBehavior = false;
            this.BestResultsListView.View = System.Windows.Forms.View.Details;
            // 
            // NameHeader
            // 
            resources.ApplyResources(this.NameHeader, "NameHeader");
            // 
            // PrizesCollectedHeader
            // 
            resources.ApplyResources(this.PrizesCollectedHeader, "PrizesCollectedHeader");
            // 
            // LevelsCompletedHeader
            // 
            resources.ApplyResources(this.LevelsCompletedHeader, "LevelsCompletedHeader");
            // 
            // GameOversHeader
            // 
            resources.ApplyResources(this.GameOversHeader, "GameOversHeader");
            // 
            // DateHeader
            // 
            resources.ApplyResources(this.DateHeader, "DateHeader");
            // 
            // AllResultLabel
            // 
            resources.ApplyResources(this.AllResultLabel, "AllResultLabel");
            this.AllResultLabel.Name = "AllResultLabel";
            // 
            // BestResultsLabel
            // 
            resources.ApplyResources(this.BestResultsLabel, "BestResultsLabel");
            this.BestResultsLabel.Name = "BestResultsLabel";
            // 
            // MenuButton
            // 
            resources.ApplyResources(this.MenuButton, "MenuButton");
            this.MenuButton.BackgroundImage = global::GUI.Properties.Resources.GoBackArrow;
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // LatestResultsListView
            // 
            resources.ApplyResources(this.LatestResultsListView, "LatestResultsListView");
            this.LatestResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHeader1,
            this.PrizesCollectedHeader1,
            this.LevelsCompletedHeader1,
            this.GameOverHeader1,
            this.DateHeader1});
            this.LatestResultsListView.Name = "LatestResultsListView";
            this.LatestResultsListView.UseCompatibleStateImageBehavior = false;
            this.LatestResultsListView.View = System.Windows.Forms.View.Details;
            // 
            // NameHeader1
            // 
            resources.ApplyResources(this.NameHeader1, "NameHeader1");
            // 
            // PrizesCollectedHeader1
            // 
            resources.ApplyResources(this.PrizesCollectedHeader1, "PrizesCollectedHeader1");
            // 
            // LevelsCompletedHeader1
            // 
            resources.ApplyResources(this.LevelsCompletedHeader1, "LevelsCompletedHeader1");
            // 
            // GameOverHeader1
            // 
            resources.ApplyResources(this.GameOverHeader1, "GameOverHeader1");
            // 
            // DateHeader1
            // 
            resources.ApplyResources(this.DateHeader1, "DateHeader1");
            // 
            // LeaderboardsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LatestResultsListView);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.BestResultsLabel);
            this.Controls.Add(this.AllResultLabel);
            this.Controls.Add(this.BestResultsListView);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "LeaderboardsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView BestResultsListView;
        private Label AllResultLabel;
        private Label BestResultsLabel;
        private Button MenuButton;
        private ColumnHeader NameHeader;
        private ColumnHeader PrizesCollectedHeader;
        private ColumnHeader LevelsCompletedHeader;
        private ColumnHeader GameOversHeader;
        private ColumnHeader DateHeader;
        private ListView LatestResultsListView;
        private ColumnHeader NameHeader1;
        private ColumnHeader PrizesCollectedHeader1;
        private ColumnHeader LevelsCompletedHeader1;
        private ColumnHeader GameOverHeader1;
        private ColumnHeader DateHeader1;
    }
}