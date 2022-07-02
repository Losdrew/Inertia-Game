namespace GUI.Forms.Screens;

partial class WinScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinScreenForm));
            this.ContinueButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.SkiRunnerImage = new System.Windows.Forms.PictureBox();
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.RestartLevelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ContinueButton
            // 
            resources.ApplyResources(this.ContinueButton, "ContinueButton");
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // MenuButton
            // 
            resources.ApplyResources(this.MenuButton, "MenuButton");
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // SkiRunnerImage
            // 
            resources.ApplyResources(this.SkiRunnerImage, "SkiRunnerImage");
            this.SkiRunnerImage.Name = "SkiRunnerImage";
            this.SkiRunnerImage.TabStop = false;
            // 
            // GameOverLabel
            // 
            resources.ApplyResources(this.GameOverLabel, "GameOverLabel");
            this.GameOverLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.GameOverLabel.Name = "GameOverLabel";
            // 
            // RestartLevelButton
            // 
            resources.ApplyResources(this.RestartLevelButton, "RestartLevelButton");
            this.RestartLevelButton.Name = "RestartLevelButton";
            this.RestartLevelButton.UseVisualStyleBackColor = true;
            this.RestartLevelButton.Click += new System.EventHandler(this.RestartLevelButton_Click);
            // 
            // WinScreenForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RestartLevelButton);
            this.Controls.Add(this.GameOverLabel);
            this.Controls.Add(this.SkiRunnerImage);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.ContinueButton);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "WinScreenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Button ContinueButton;
    private Button MenuButton;
    private PictureBox SkiRunnerImage;
    private Label GameOverLabel;
    private Button RestartLevelButton;
}