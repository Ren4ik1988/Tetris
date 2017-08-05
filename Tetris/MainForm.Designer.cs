namespace Tetris
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Level_btn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.NewGame_btn = new System.Windows.Forms.Button();
            this.StartPause_Btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(19, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 13);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Уровень сложности";
            // 
            // Level_btn
            // 
            this.Level_btn.Location = new System.Drawing.Point(36, 145);
            this.Level_btn.Name = "Level_btn";
            this.Level_btn.Size = new System.Drawing.Size(75, 23);
            this.Level_btn.TabIndex = 0;
            this.Level_btn.Text = "Легко";
            this.Level_btn.UseVisualStyleBackColor = true;
            // 
            // Exit_btn
            // 
            this.Exit_btn.Location = new System.Drawing.Point(36, 90);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(75, 23);
            this.Exit_btn.TabIndex = 0;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // NewGame_btn
            // 
            this.NewGame_btn.Location = new System.Drawing.Point(36, 55);
            this.NewGame_btn.Name = "NewGame_btn";
            this.NewGame_btn.Size = new System.Drawing.Size(75, 23);
            this.NewGame_btn.TabIndex = 0;
            this.NewGame_btn.Text = "New game";
            this.NewGame_btn.UseVisualStyleBackColor = true;
            // 
            // StartPause_Btn
            // 
            this.StartPause_Btn.Location = new System.Drawing.Point(36, 26);
            this.StartPause_Btn.Name = "StartPause_Btn";
            this.StartPause_Btn.Size = new System.Drawing.Size(75, 23);
            this.StartPause_Btn.TabIndex = 0;
            this.StartPause_Btn.Text = "Start/Pause";
            this.StartPause_Btn.UseCompatibleTextRendering = true;
            this.StartPause_Btn.UseVisualStyleBackColor = true;
            this.StartPause_Btn.Click += new System.EventHandler(this.StartPause_Btn_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Exit_btn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.StartPause_Btn);
            this.panel1.Controls.Add(this.Level_btn);
            this.panel1.Controls.Add(this.NewGame_btn);
            this.panel1.Location = new System.Drawing.Point(284, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 192);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 510);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "MainForm";
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Level_btn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Button NewGame_btn;
        private System.Windows.Forms.Button StartPause_Btn;
        private System.Windows.Forms.Panel panel1;
    }
}

