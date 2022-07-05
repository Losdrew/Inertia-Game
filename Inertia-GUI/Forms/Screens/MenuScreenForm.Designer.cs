namespace GUI.Forms.Screens;

partial class MenuScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreenForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SkiRunnerImage = new System.Windows.Forms.PictureBox();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.LeaderboardsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            resources.ApplyResources(this.StartButton, "StartButton");
            this.StartButton.Name = "StartButton";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // QuitButton
            // 
            resources.ApplyResources(this.QuitButton, "QuitButton");
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // SkiRunnerImage
            // 
            resources.ApplyResources(this.SkiRunnerImage, "SkiRunnerImage");
            this.SkiRunnerImage.Name = "SkiRunnerImage";
            this.SkiRunnerImage.TabStop = false;
            // 
            // MenuLabel
            // 
            resources.ApplyResources(this.MenuLabel, "MenuLabel");
            this.MenuLabel.Name = "MenuLabel";
            // 
            // OptionsButton
            // 
            resources.ApplyResources(this.OptionsButton, "OptionsButton");
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // LeaderboardsButton
            // 
            resources.ApplyResources(this.LeaderboardsButton, "LeaderboardsButton");
            this.LeaderboardsButton.Name = "LeaderboardsButton";
            this.LeaderboardsButton.UseVisualStyleBackColor = true;
            this.LeaderboardsButton.Click += new System.EventHandler(this.LeaderboardsButton_Click);
            // 
            // MenuScreenForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LeaderboardsButton);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.SkiRunnerImage);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.StartButton);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "MenuScreenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Button StartButton;
    private Button QuitButton;
    private PictureBox SkiRunnerImage;
    private Label MenuLabel;
    private Button OptionsButton;
    private Button LeaderboardsButton;
}