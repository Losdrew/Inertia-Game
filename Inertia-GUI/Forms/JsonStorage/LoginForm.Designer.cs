namespace GUI.Forms.JsonStorage
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.EnterAnonymouslyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            resources.ApplyResources(this.WelcomeLabel, "WelcomeLabel");
            this.WelcomeLabel.Name = "WelcomeLabel";
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.Name = "NameLabel";
            // 
            // LoginButton
            // 
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // NameTextBox
            // 
            resources.ApplyResources(this.NameTextBox, "NameTextBox");
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Enter += new System.EventHandler(this.TextBox_FocusEnter);
            this.NameTextBox.Leave += new System.EventHandler(this.TextBox_FocusLeave);
            // 
            // EnterAnonymouslyButton
            // 
            resources.ApplyResources(this.EnterAnonymouslyButton, "EnterAnonymouslyButton");
            this.EnterAnonymouslyButton.Name = "EnterAnonymouslyButton";
            this.EnterAnonymouslyButton.UseVisualStyleBackColor = true;
            this.EnterAnonymouslyButton.Click += new System.EventHandler(this.EnterAnonymouslyButton_Click);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EnterAnonymouslyButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Icon = global::GUI.Properties.Resources.Icon;
            this.Name = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBase_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WelcomeLabel;
        private Label NameLabel;
        private Button LoginButton;
        private TextBox NameTextBox;
        private Button EnterAnonymouslyButton;
    }
}