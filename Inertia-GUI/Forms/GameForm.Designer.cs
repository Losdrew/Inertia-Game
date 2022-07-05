namespace GUI.Forms;

partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.ScoreBox = new System.Windows.Forms.SplitContainer();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.ScoreNumberLabel = new System.Windows.Forms.Label();
            this.AudioVolumeContainer = new System.Windows.Forms.SplitContainer();
            this.AudioVolumeLabel = new System.Windows.Forms.Label();
            this.AudioVolumeSlider = new NAudio.Gui.VolumeSlider();
            this.ControlsTipLabel = new System.Windows.Forms.Label();
            this.LeftSection = new System.Windows.Forms.Panel();
            this.CenterSection = new System.Windows.Forms.Panel();
            this.MapBox = new System.Windows.Forms.PictureBox();
            this.RightSection = new System.Windows.Forms.Panel();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.BottomSection = new System.Windows.Forms.Panel();
            this.MenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBox)).BeginInit();
            this.ScoreBox.Panel1.SuspendLayout();
            this.ScoreBox.Panel2.SuspendLayout();
            this.ScoreBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AudioVolumeContainer)).BeginInit();
            this.AudioVolumeContainer.Panel1.SuspendLayout();
            this.AudioVolumeContainer.Panel2.SuspendLayout();
            this.AudioVolumeContainer.SuspendLayout();
            this.LeftSection.SuspendLayout();
            this.CenterSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapBox)).BeginInit();
            this.RightSection.SuspendLayout();
            this.BottomSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScoreBox
            // 
            resources.ApplyResources(this.ScoreBox, "ScoreBox");
            this.ScoreBox.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScoreBox.Name = "ScoreBox";
            // 
            // ScoreBox.Panel1
            // 
            this.ScoreBox.Panel1.Controls.Add(this.ScoreLabel);
            resources.ApplyResources(this.ScoreBox.Panel1, "ScoreBox.Panel1");
            // 
            // ScoreBox.Panel2
            // 
            this.ScoreBox.Panel2.Controls.Add(this.ScoreNumberLabel);
            this.ScoreBox.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // ScoreLabel
            // 
            resources.ApplyResources(this.ScoreLabel, "ScoreLabel");
            this.ScoreLabel.Name = "ScoreLabel";
            // 
            // ScoreNumberLabel
            // 
            resources.ApplyResources(this.ScoreNumberLabel, "ScoreNumberLabel");
            this.ScoreNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(174)))), ((int)(((byte)(102)))));
            this.ScoreNumberLabel.Name = "ScoreNumberLabel";
            // 
            // AudioVolumeContainer
            // 
            resources.ApplyResources(this.AudioVolumeContainer, "AudioVolumeContainer");
            this.AudioVolumeContainer.Name = "AudioVolumeContainer";
            // 
            // AudioVolumeContainer.Panel1
            // 
            this.AudioVolumeContainer.Panel1.Controls.Add(this.AudioVolumeLabel);
            // 
            // AudioVolumeContainer.Panel2
            // 
            this.AudioVolumeContainer.Panel2.Controls.Add(this.AudioVolumeSlider);
            // 
            // AudioVolumeLabel
            // 
            resources.ApplyResources(this.AudioVolumeLabel, "AudioVolumeLabel");
            this.AudioVolumeLabel.Name = "AudioVolumeLabel";
            // 
            // AudioVolumeSlider
            // 
            resources.ApplyResources(this.AudioVolumeSlider, "AudioVolumeSlider");
            this.AudioVolumeSlider.Name = "AudioVolumeSlider";
            this.AudioVolumeSlider.VolumeChanged += new System.EventHandler(this.AudioVolumeSlider_VolumeChanged);
            // 
            // ControlsTipLabel
            // 
            resources.ApplyResources(this.ControlsTipLabel, "ControlsTipLabel");
            this.ControlsTipLabel.Name = "ControlsTipLabel";
            // 
            // LeftSection
            // 
            resources.ApplyResources(this.LeftSection, "LeftSection");
            this.LeftSection.Controls.Add(this.ControlsTipLabel);
            this.LeftSection.Name = "LeftSection";
            // 
            // CenterSection
            // 
            resources.ApplyResources(this.CenterSection, "CenterSection");
            this.CenterSection.Controls.Add(this.MapBox);
            this.CenterSection.Name = "CenterSection";
            // 
            // MapBox
            // 
            this.MapBox.BackgroundImage = global::GUI.Properties.Resources.MapBackground;
            resources.ApplyResources(this.MapBox, "MapBox");
            this.MapBox.Name = "MapBox";
            this.MapBox.TabStop = false;
            // 
            // RightSection
            // 
            resources.ApplyResources(this.RightSection, "RightSection");
            this.RightSection.Controls.Add(this.ScoreBox);
            this.RightSection.Name = "RightSection";
            // 
            // BottomSection
            // 
            this.BottomSection.Controls.Add(this.AudioVolumeContainer);
            resources.ApplyResources(this.BottomSection, "BottomSection");
            this.BottomSection.Name = "BottomSection";
            // 
            // MenuButton
            // 
            this.MenuButton.BackgroundImage = global::GUI.Properties.Resources.GoBackArrow;
            resources.ApplyResources(this.MenuButton, "MenuButton");
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuButton.FlatAppearance.BorderSize = 0;
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click_ProgressSave);
            // 
            // GameForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.CenterSection);
            this.Controls.Add(this.RightSection);
            this.Controls.Add(this.LeftSection);
            this.Controls.Add(this.BottomSection);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.ScoreBox.Panel1.ResumeLayout(false);
            this.ScoreBox.Panel1.PerformLayout();
            this.ScoreBox.Panel2.ResumeLayout(false);
            this.ScoreBox.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBox)).EndInit();
            this.ScoreBox.ResumeLayout(false);
            this.AudioVolumeContainer.Panel1.ResumeLayout(false);
            this.AudioVolumeContainer.Panel1.PerformLayout();
            this.AudioVolumeContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AudioVolumeContainer)).EndInit();
            this.AudioVolumeContainer.ResumeLayout(false);
            this.LeftSection.ResumeLayout(false);
            this.LeftSection.PerformLayout();
            this.CenterSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapBox)).EndInit();
            this.RightSection.ResumeLayout(false);
            this.BottomSection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    public Label ScoreLabel;
    public Label ControlsTipLabel;
    public SplitContainer ScoreBox;
    public Panel CenterSection;
    public Label ScoreNumberLabel;
    public Panel LeftSection;
    public Panel RightSection;
    public PictureBox MapBox;
    internal System.Windows.Forms.Timer AnimationTimer;
    private Panel BottomSection;
    private NAudio.Gui.VolumeSlider AudioVolumeSlider;
    private Label AudioVolumeLabel;
    private SplitContainer AudioVolumeContainer;
    private Button MenuButton;
}