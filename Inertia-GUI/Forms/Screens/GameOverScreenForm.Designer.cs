namespace GUI.Forms.Screens;

partial class GameOverScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverScreenForm));
            this.RestartLevelButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SkiRunnerImage = new System.Windows.Forms.PictureBox();
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.CreateNewLevelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // RestartLevelButton
            // 
            this.RestartLevelButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RestartLevelButton.Location = new System.Drawing.Point(350, 184);
            this.RestartLevelButton.Name = "RestartLevelButton";
            this.RestartLevelButton.Size = new System.Drawing.Size(201, 39);
            this.RestartLevelButton.TabIndex = 1;
            this.RestartLevelButton.Text = "Restart current level";
            this.RestartLevelButton.UseVisualStyleBackColor = true;
            this.RestartLevelButton.Click += new System.EventHandler(this.RestartLevelButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuitButton.Location = new System.Drawing.Point(350, 302);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(201, 39);
            this.QuitButton.TabIndex = 3;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // SkiRunnerImage
            // 
            this.SkiRunnerImage.Image = ((System.Drawing.Image)(resources.GetObject("SkiRunnerImage.Image")));
            this.SkiRunnerImage.Location = new System.Drawing.Point(270, 366);
            this.SkiRunnerImage.Name = "SkiRunnerImage";
            this.SkiRunnerImage.Size = new System.Drawing.Size(360, 360);
            this.SkiRunnerImage.TabIndex = 3;
            this.SkiRunnerImage.TabStop = false;
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.AutoSize = true;
            this.GameOverLabel.Font = new System.Drawing.Font("Arial", 90F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.GameOverLabel.ForeColor = System.Drawing.Color.Red;
            this.GameOverLabel.Location = new System.Drawing.Point(14, 9);
            this.GameOverLabel.Margin = new System.Windows.Forms.Padding(0);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(846, 172);
            this.GameOverLabel.TabIndex = 4;
            this.GameOverLabel.Text = "Game over";
            // 
            // CreateNewLevelButton
            // 
            this.CreateNewLevelButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateNewLevelButton.Location = new System.Drawing.Point(350, 243);
            this.CreateNewLevelButton.Name = "CreateNewLevelButton";
            this.CreateNewLevelButton.Size = new System.Drawing.Size(201, 39);
            this.CreateNewLevelButton.TabIndex = 2;
            this.CreateNewLevelButton.Text = "Create new level";
            this.CreateNewLevelButton.UseVisualStyleBackColor = true;
            this.CreateNewLevelButton.Click += new System.EventHandler(this.CreateNewLevelButton_Click);
            // 
            // GameOverScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.CreateNewLevelButton);
            this.Controls.Add(this.GameOverLabel);
            this.Controls.Add(this.SkiRunnerImage);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.RestartLevelButton);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "GameOverScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game over";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Button RestartLevelButton;
    private Button QuitButton;
    private PictureBox SkiRunnerImage;
    private Label GameOverLabel;
    private Button CreateNewLevelButton;
}