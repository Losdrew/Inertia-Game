using CommonCodebase.Entities;

namespace GUI.Forms.JsonStorage
{
    partial class LevelEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditorForm));
            this.MapSizeContainer = new System.Windows.Forms.SplitContainer();
            this.MapSizeLabel = new System.Windows.Forms.Label();
            this.MapHeight = new System.Windows.Forms.NumericUpDown();
            this.XLabel = new System.Windows.Forms.Label();
            this.MapWidth = new System.Windows.Forms.NumericUpDown();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.ActionPanel = new System.Windows.Forms.Panel();
            this.PlayButton = new System.Windows.Forms.Button();
            this.EraseCursorButton = new System.Windows.Forms.Button();
            this.SelectCursorButton = new System.Windows.Forms.Button();
            this.ClearMapTemplateButton = new System.Windows.Forms.Button();
            this.ElementSelectionStatusLabel = new System.Windows.Forms.Label();
            this.CreateMapTemplateButton = new System.Windows.Forms.Button();
            this.GameElementsPanel = new System.Windows.Forms.Panel();
            this.GameElementsPictureBoxPanel = new System.Windows.Forms.Panel();
            this.WallButton = new System.Windows.Forms.Button();
            this.TrapButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PrizeButton = new System.Windows.Forms.Button();
            this.PlayerButton = new System.Windows.Forms.Button();
            this.GameElementsLabelPanel = new System.Windows.Forms.Panel();
            this.GameElementsLabel = new System.Windows.Forms.Label();
            this.MapListPanel = new System.Windows.Forms.Panel();
            this.MapListView = new System.Windows.Forms.ListView();
            this.ListButtonsPanel = new System.Windows.Forms.Panel();
            this.DeleteMapButton = new System.Windows.Forms.Button();
            this.AddMapButton = new System.Windows.Forms.Button();
            this.MapNameTextBox = new System.Windows.Forms.TextBox();
            this.MenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MapSizeContainer)).BeginInit();
            this.MapSizeContainer.Panel1.SuspendLayout();
            this.MapSizeContainer.Panel2.SuspendLayout();
            this.MapSizeContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapWidth)).BeginInit();
            this.SidePanel.SuspendLayout();
            this.ActionPanel.SuspendLayout();
            this.GameElementsPanel.SuspendLayout();
            this.GameElementsPictureBoxPanel.SuspendLayout();
            this.GameElementsLabelPanel.SuspendLayout();
            this.MapListPanel.SuspendLayout();
            this.ListButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapSizeContainer
            // 
            resources.ApplyResources(this.MapSizeContainer, "MapSizeContainer");
            this.MapSizeContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MapSizeContainer.Name = "MapSizeContainer";
            // 
            // MapSizeContainer.Panel1
            // 
            resources.ApplyResources(this.MapSizeContainer.Panel1, "MapSizeContainer.Panel1");
            this.MapSizeContainer.Panel1.Controls.Add(this.MapSizeLabel);
            // 
            // MapSizeContainer.Panel2
            // 
            resources.ApplyResources(this.MapSizeContainer.Panel2, "MapSizeContainer.Panel2");
            this.MapSizeContainer.Panel2.Controls.Add(this.MapHeight);
            this.MapSizeContainer.Panel2.Controls.Add(this.XLabel);
            this.MapSizeContainer.Panel2.Controls.Add(this.MapWidth);
            // 
            // MapSizeLabel
            // 
            resources.ApplyResources(this.MapSizeLabel, "MapSizeLabel");
            this.MapSizeLabel.Name = "MapSizeLabel";
            // 
            // MapHeight
            // 
            resources.ApplyResources(this.MapHeight, "MapHeight");
            this.MapHeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MapHeight.Name = "MapHeight";
            this.MapHeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // XLabel
            // 
            resources.ApplyResources(this.XLabel, "XLabel");
            this.XLabel.Name = "XLabel";
            // 
            // MapWidth
            // 
            resources.ApplyResources(this.MapWidth, "MapWidth");
            this.MapWidth.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MapWidth.Name = "MapWidth";
            this.MapWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // MapPanel
            // 
            resources.ApplyResources(this.MapPanel, "MapPanel");
            this.MapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // SidePanel
            // 
            resources.ApplyResources(this.SidePanel, "SidePanel");
            this.SidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SidePanel.Controls.Add(this.ActionPanel);
            this.SidePanel.Controls.Add(this.GameElementsPanel);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // ActionPanel
            // 
            resources.ApplyResources(this.ActionPanel, "ActionPanel");
            this.ActionPanel.Controls.Add(this.PlayButton);
            this.ActionPanel.Controls.Add(this.EraseCursorButton);
            this.ActionPanel.Controls.Add(this.SelectCursorButton);
            this.ActionPanel.Controls.Add(this.ClearMapTemplateButton);
            this.ActionPanel.Controls.Add(this.ElementSelectionStatusLabel);
            this.ActionPanel.Controls.Add(this.CreateMapTemplateButton);
            this.ActionPanel.Controls.Add(this.MapSizeContainer);
            this.ActionPanel.Name = "ActionPanel";
            this.ActionPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // PlayButton
            // 
            resources.ApplyResources(this.PlayButton, "PlayButton");
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // EraseCursorButton
            // 
            resources.ApplyResources(this.EraseCursorButton, "EraseCursorButton");
            this.EraseCursorButton.BackgroundImage = global::GUI.Properties.Resources.EraseCursor;
            this.EraseCursorButton.Name = "EraseCursorButton";
            this.EraseCursorButton.UseVisualStyleBackColor = true;
            this.EraseCursorButton.Click += new System.EventHandler(this.EraseCursorButton_Click);
            // 
            // SelectCursorButton
            // 
            resources.ApplyResources(this.SelectCursorButton, "SelectCursorButton");
            this.SelectCursorButton.BackgroundImage = global::GUI.Properties.Resources.SelectCursor;
            this.SelectCursorButton.Name = "SelectCursorButton";
            this.SelectCursorButton.UseVisualStyleBackColor = true;
            this.SelectCursorButton.Click += new System.EventHandler(this.SelectCursorButton_Click);
            // 
            // ClearMapTemplateButton
            // 
            resources.ApplyResources(this.ClearMapTemplateButton, "ClearMapTemplateButton");
            this.ClearMapTemplateButton.Name = "ClearMapTemplateButton";
            this.ClearMapTemplateButton.UseVisualStyleBackColor = true;
            this.ClearMapTemplateButton.Click += new System.EventHandler(this.ClearMapTemplateButton_Click);
            // 
            // ElementSelectionStatusLabel
            // 
            resources.ApplyResources(this.ElementSelectionStatusLabel, "ElementSelectionStatusLabel");
            this.ElementSelectionStatusLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.ElementSelectionStatusLabel.Name = "ElementSelectionStatusLabel";
            // 
            // CreateMapTemplateButton
            // 
            resources.ApplyResources(this.CreateMapTemplateButton, "CreateMapTemplateButton");
            this.CreateMapTemplateButton.Name = "CreateMapTemplateButton";
            this.CreateMapTemplateButton.UseVisualStyleBackColor = true;
            this.CreateMapTemplateButton.Click += new System.EventHandler(this.CreateMapTemplateButton_Click);
            // 
            // GameElementsPanel
            // 
            resources.ApplyResources(this.GameElementsPanel, "GameElementsPanel");
            this.GameElementsPanel.Controls.Add(this.GameElementsPictureBoxPanel);
            this.GameElementsPanel.Controls.Add(this.GameElementsLabelPanel);
            this.GameElementsPanel.Name = "GameElementsPanel";
            this.GameElementsPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // GameElementsPictureBoxPanel
            // 
            resources.ApplyResources(this.GameElementsPictureBoxPanel, "GameElementsPictureBoxPanel");
            this.GameElementsPictureBoxPanel.Controls.Add(this.WallButton);
            this.GameElementsPictureBoxPanel.Controls.Add(this.TrapButton);
            this.GameElementsPictureBoxPanel.Controls.Add(this.StopButton);
            this.GameElementsPictureBoxPanel.Controls.Add(this.PrizeButton);
            this.GameElementsPictureBoxPanel.Controls.Add(this.PlayerButton);
            this.GameElementsPictureBoxPanel.Name = "GameElementsPictureBoxPanel";
            this.GameElementsPictureBoxPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // WallButton
            // 
            resources.ApplyResources(this.WallButton, "WallButton");
            this.WallButton.BackgroundImage = global::GUI.Properties.Resources.Wall;
            this.WallButton.Name = "WallButton";
            this.WallButton.Tag = "Wall";
            this.WallButton.UseVisualStyleBackColor = true;
            this.WallButton.Leave += new System.EventHandler(this.GameElement_Deselect);
            this.WallButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Select);
            // 
            // TrapButton
            // 
            resources.ApplyResources(this.TrapButton, "TrapButton");
            this.TrapButton.BackgroundImage = global::GUI.Properties.Resources.Trap;
            this.TrapButton.Name = "TrapButton";
            this.TrapButton.Tag = "Trap";
            this.TrapButton.UseVisualStyleBackColor = true;
            this.TrapButton.Leave += new System.EventHandler(this.GameElement_Deselect);
            this.TrapButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Select);
            // 
            // StopButton
            // 
            resources.ApplyResources(this.StopButton, "StopButton");
            this.StopButton.BackgroundImage = global::GUI.Properties.Resources.Stop;
            this.StopButton.Name = "StopButton";
            this.StopButton.Tag = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Leave += new System.EventHandler(this.GameElement_Deselect);
            this.StopButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Select);
            // 
            // PrizeButton
            // 
            resources.ApplyResources(this.PrizeButton, "PrizeButton");
            this.PrizeButton.BackgroundImage = global::GUI.Properties.Resources.Prize;
            this.PrizeButton.Name = "PrizeButton";
            this.PrizeButton.Tag = "Prize";
            this.PrizeButton.UseVisualStyleBackColor = true;
            this.PrizeButton.Leave += new System.EventHandler(this.GameElement_Deselect);
            this.PrizeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Select);
            // 
            // PlayerButton
            // 
            resources.ApplyResources(this.PlayerButton, "PlayerButton");
            this.PlayerButton.BackgroundImage = global::GUI.Properties.Resources.Player_Right;
            this.PlayerButton.Name = "PlayerButton";
            this.PlayerButton.Tag = "Player";
            this.PlayerButton.UseVisualStyleBackColor = true;
            this.PlayerButton.Leave += new System.EventHandler(this.GameElement_Deselect);
            this.PlayerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Select);
            // 
            // GameElementsLabelPanel
            // 
            resources.ApplyResources(this.GameElementsLabelPanel, "GameElementsLabelPanel");
            this.GameElementsLabelPanel.Controls.Add(this.GameElementsLabel);
            this.GameElementsLabelPanel.Name = "GameElementsLabelPanel";
            this.GameElementsLabelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // GameElementsLabel
            // 
            resources.ApplyResources(this.GameElementsLabel, "GameElementsLabel");
            this.GameElementsLabel.Name = "GameElementsLabel";
            // 
            // MapListPanel
            // 
            resources.ApplyResources(this.MapListPanel, "MapListPanel");
            this.MapListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapListPanel.Controls.Add(this.MapListView);
            this.MapListPanel.Controls.Add(this.ListButtonsPanel);
            this.MapListPanel.Name = "MapListPanel";
            this.MapListPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // MapListView
            // 
            resources.ApplyResources(this.MapListView, "MapListView");
            this.MapListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MapListView.Name = "MapListView";
            this.MapListView.UseCompatibleStateImageBehavior = false;
            this.MapListView.View = System.Windows.Forms.View.List;
            this.MapListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MapListView_DoubleClick);
            // 
            // ListButtonsPanel
            // 
            resources.ApplyResources(this.ListButtonsPanel, "ListButtonsPanel");
            this.ListButtonsPanel.Controls.Add(this.DeleteMapButton);
            this.ListButtonsPanel.Controls.Add(this.AddMapButton);
            this.ListButtonsPanel.Controls.Add(this.MapNameTextBox);
            this.ListButtonsPanel.Name = "ListButtonsPanel";
            this.ListButtonsPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameElement_Deselect);
            // 
            // DeleteMapButton
            // 
            resources.ApplyResources(this.DeleteMapButton, "DeleteMapButton");
            this.DeleteMapButton.Name = "DeleteMapButton";
            this.DeleteMapButton.UseVisualStyleBackColor = true;
            this.DeleteMapButton.Click += new System.EventHandler(this.DeleteMapButton_Click);
            // 
            // AddMapButton
            // 
            resources.ApplyResources(this.AddMapButton, "AddMapButton");
            this.AddMapButton.Name = "AddMapButton";
            this.AddMapButton.UseVisualStyleBackColor = true;
            this.AddMapButton.Click += new System.EventHandler(this.AddMapButton_Click);
            // 
            // MapNameTextBox
            // 
            resources.ApplyResources(this.MapNameTextBox, "MapNameTextBox");
            this.MapNameTextBox.Name = "MapNameTextBox";
            this.MapNameTextBox.Enter += new System.EventHandler(this.TextBox_FocusEnter);
            this.MapNameTextBox.Leave += new System.EventHandler(this.TextBox_FocusLeave);
            // 
            // MenuButton
            // 
            resources.ApplyResources(this.MenuButton, "MenuButton");
            this.MenuButton.BackgroundImage = global::GUI.Properties.Resources.GoBackArrow;
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_SaveMaps_Click);
            // 
            // LevelEditorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.MapPanel);
            this.Controls.Add(this.MapListPanel);
            this.Controls.Add(this.SidePanel);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "LevelEditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditorForm_FormClosing);
            this.MapSizeContainer.Panel1.ResumeLayout(false);
            this.MapSizeContainer.Panel1.PerformLayout();
            this.MapSizeContainer.Panel2.ResumeLayout(false);
            this.MapSizeContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapSizeContainer)).EndInit();
            this.MapSizeContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapWidth)).EndInit();
            this.SidePanel.ResumeLayout(false);
            this.ActionPanel.ResumeLayout(false);
            this.ActionPanel.PerformLayout();
            this.GameElementsPanel.ResumeLayout(false);
            this.GameElementsPictureBoxPanel.ResumeLayout(false);
            this.GameElementsLabelPanel.ResumeLayout(false);
            this.GameElementsLabelPanel.PerformLayout();
            this.MapListPanel.ResumeLayout(false);
            this.ListButtonsPanel.ResumeLayout(false);
            this.ListButtonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel MapPanel;
        private Panel ActionPanel;
        private Panel GameElementsPanel;
        private Panel GameElementsPictureBoxPanel;
        private Label GameElementsLabel;
        private Button CreateMapTemplateButton;
        private SplitContainer MapSizeContainer;
        private Label MapSizeLabel;
        internal NumericUpDown MapHeight;
        private Label XLabel;
        internal NumericUpDown MapWidth;
        private Panel GameElementsLabelPanel;
        private Panel SidePanel;
        private Panel MapListPanel;
        private ListView MapListView;
        private Panel ListButtonsPanel;
        private Button DeleteMapButton;
        private Button AddMapButton;
        private TextBox MapNameTextBox;
        private Label ElementSelectionStatusLabel;
        private Button WallButton;
        private Button TrapButton;
        private Button StopButton;
        private Button PrizeButton;
        private Button PlayerButton;
        private Button ClearMapTemplateButton;
        private Button SelectCursorButton;
        private Button EraseCursorButton;
        private Button MenuButton;
        private Button PlayButton;
    }
}