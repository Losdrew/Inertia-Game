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
            this.ControlsTipLabel = new System.Windows.Forms.Label();
            this.LeftSection = new System.Windows.Forms.Panel();
            this.CenterSection = new System.Windows.Forms.Panel();
            this.MapBox = new System.Windows.Forms.PictureBox();
            this.RightSection = new System.Windows.Forms.Panel();
            this.ScoreBox = new System.Windows.Forms.SplitContainer();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.ScoreNumberLabel = new System.Windows.Forms.Label();
            this.MovementTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftSection.SuspendLayout();
            this.CenterSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapBox)).BeginInit();
            this.RightSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBox)).BeginInit();
            this.ScoreBox.Panel1.SuspendLayout();
            this.ScoreBox.Panel2.SuspendLayout();
            this.ScoreBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlsTipLabel
            // 
            this.ControlsTipLabel.AutoSize = true;
            this.ControlsTipLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ControlsTipLabel.Location = new System.Drawing.Point(20, 154);
            this.ControlsTipLabel.Name = "ControlsTipLabel";
            this.ControlsTipLabel.Size = new System.Drawing.Size(86, 28);
            this.ControlsTipLabel.TabIndex = 1;
            this.ControlsTipLabel.Text = "Controls";
            this.ControlsTipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeftSection
            // 
            this.LeftSection.AutoSize = true;
            this.LeftSection.Controls.Add(this.ControlsTipLabel);
            this.LeftSection.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSection.Location = new System.Drawing.Point(30, 60);
            this.LeftSection.Name = "LeftSection";
            this.LeftSection.Padding = new System.Windows.Forms.Padding(20);
            this.LeftSection.Size = new System.Drawing.Size(129, 333);
            this.LeftSection.TabIndex = 4;
            // 
            // CenterSection
            // 
            this.CenterSection.AutoSize = true;
            this.CenterSection.Controls.Add(this.MapBox);
            this.CenterSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterSection.Location = new System.Drawing.Point(159, 60);
            this.CenterSection.Name = "CenterSection";
            this.CenterSection.Size = new System.Drawing.Size(591, 333);
            this.CenterSection.TabIndex = 6;
            // 
            // MapBox
            // 
            this.MapBox.BackgroundImage = global::GUI.Resources.MapBackground;
            this.MapBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MapBox.Location = new System.Drawing.Point(0, 0);
            this.MapBox.Name = "MapBox";
            this.MapBox.Size = new System.Drawing.Size(591, 333);
            this.MapBox.TabIndex = 0;
            this.MapBox.TabStop = false;
            // 
            // RightSection
            // 
            this.RightSection.AutoSize = true;
            this.RightSection.Controls.Add(this.ScoreBox);
            this.RightSection.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightSection.Location = new System.Drawing.Point(750, 60);
            this.RightSection.Name = "RightSection";
            this.RightSection.Padding = new System.Windows.Forms.Padding(20);
            this.RightSection.Size = new System.Drawing.Size(202, 333);
            this.RightSection.TabIndex = 5;
            // 
            // ScoreBox
            // 
            this.ScoreBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreBox.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScoreBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreBox.IsSplitterFixed = true;
            this.ScoreBox.Location = new System.Drawing.Point(42, 154);
            this.ScoreBox.Name = "ScoreBox";
            // 
            // ScoreBox.Panel1
            // 
            this.ScoreBox.Panel1.Controls.Add(this.ScoreLabel);
            this.ScoreBox.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ScoreBox.Panel2
            // 
            this.ScoreBox.Panel2.Controls.Add(this.ScoreNumberLabel);
            this.ScoreBox.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ScoreBox.Size = new System.Drawing.Size(117, 31);
            this.ScoreBox.SplitterDistance = 66;
            this.ScoreBox.SplitterWidth = 1;
            this.ScoreBox.TabIndex = 6;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(0, 0);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(75, 31);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Score:";
            // 
            // ScoreNumberLabel
            // 
            this.ScoreNumberLabel.AutoSize = true;
            this.ScoreNumberLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.ScoreNumberLabel.Location = new System.Drawing.Point(3, 0);
            this.ScoreNumberLabel.Name = "ScoreNumberLabel";
            this.ScoreNumberLabel.Size = new System.Drawing.Size(26, 31);
            this.ScoreNumberLabel.TabIndex = 3;
            this.ScoreNumberLabel.Text = "0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(982, 453);
            this.Controls.Add(this.CenterSection);
            this.Controls.Add(this.RightSection);
            this.Controls.Add(this.LeftSection);
            this.Icon = global::GUI.Resources.Icon;
            this.KeyPreview = true;
            this.Name = "GameForm";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 60);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inertia";
            this.LeftSection.ResumeLayout(false);
            this.LeftSection.PerformLayout();
            this.CenterSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapBox)).EndInit();
            this.RightSection.ResumeLayout(false);
            this.ScoreBox.Panel1.ResumeLayout(false);
            this.ScoreBox.Panel1.PerformLayout();
            this.ScoreBox.Panel2.ResumeLayout(false);
            this.ScoreBox.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScoreBox)).EndInit();
            this.ScoreBox.ResumeLayout(false);
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
    internal System.Windows.Forms.Timer MovementTimer;
}