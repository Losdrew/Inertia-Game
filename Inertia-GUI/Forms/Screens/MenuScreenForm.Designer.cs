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
            ((System.ComponentModel.ISupportInitialize)(this.SkiRunnerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartButton.Location = new System.Drawing.Point(363, 200);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(173, 43);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.QuitButton.Location = new System.Drawing.Point(363, 262);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(173, 42);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // SkiRunnerImage
            // 
            this.SkiRunnerImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SkiRunnerImage.BackgroundImage")));
            this.SkiRunnerImage.Location = new System.Drawing.Point(270, 336);
            this.SkiRunnerImage.Name = "SkiRunnerImage";
            this.SkiRunnerImage.Size = new System.Drawing.Size(360, 360);
            this.SkiRunnerImage.TabIndex = 3;
            this.SkiRunnerImage.TabStop = false;
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Font = new System.Drawing.Font("Arial", 90F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.MenuLabel.Location = new System.Drawing.Point(189, 9);
            this.MenuLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(522, 172);
            this.MenuLabel.TabIndex = 4;
            this.MenuLabel.Text = "Inertia";
            // 
            // MenuScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.SkiRunnerImage);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.StartButton);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "MenuScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
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
}