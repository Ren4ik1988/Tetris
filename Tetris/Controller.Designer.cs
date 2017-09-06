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
            this.MainPanel = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Level_btn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.NewGame_btn = new System.Windows.Forms.Button();
            this.StartPause_Btn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.LineLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.textBox1);
            this.MainPanel.Controls.Add(this.Level_btn);
            this.MainPanel.Controls.Add(this.Exit_btn);
            this.MainPanel.Controls.Add(this.NewGame_btn);
            this.MainPanel.Controls.Add(this.StartPause_Btn);
            this.MainPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainPanel.Location = new System.Drawing.Point(361, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(161, 181);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(22, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(110, 13);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Уровень сложности";
            // 
            // Level_btn
            // 
            this.Level_btn.Location = new System.Drawing.Point(39, 138);
            this.Level_btn.Name = "Level_btn";
            this.Level_btn.Size = new System.Drawing.Size(80, 23);
            this.Level_btn.TabIndex = 0;
            this.Level_btn.Text = "Легко";
            this.Level_btn.UseVisualStyleBackColor = true;
            this.Level_btn.Click += new System.EventHandler(this.Level_btn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.Location = new System.Drawing.Point(39, 77);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 23);
            this.Exit_btn.TabIndex = 0;
            this.Exit_btn.Text = "Выход";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // NewGame_btn
            // 
            this.NewGame_btn.Location = new System.Drawing.Point(39, 48);
            this.NewGame_btn.Name = "NewGame_btn";
            this.NewGame_btn.Size = new System.Drawing.Size(80, 23);
            this.NewGame_btn.TabIndex = 0;
            this.NewGame_btn.Text = "Новая игра";
            this.NewGame_btn.UseVisualStyleBackColor = true;
            this.NewGame_btn.Click += new System.EventHandler(this.NewGame_btn_Click);
            // 
            // StartPause_Btn
            // 
            this.StartPause_Btn.Location = new System.Drawing.Point(39, 19);
            this.StartPause_Btn.Name = "StartPause_Btn";
            this.StartPause_Btn.Size = new System.Drawing.Size(80, 23);
            this.StartPause_Btn.TabIndex = 0;
            this.StartPause_Btn.Text = "Начать игру";
            this.StartPause_Btn.UseCompatibleTextRendering = true;
            this.StartPause_Btn.UseVisualStyleBackColor = true;
            this.StartPause_Btn.Click += new System.EventHandler(this.StartPause_Btn_Click);
            this.StartPause_Btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Manipulate);
            this.StartPause_Btn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InputCatch);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.Navy;
            this.textBox2.Location = new System.Drawing.Point(393, 219);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Следующая фигура";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Текущий прогресс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Счет:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество линий:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Текущий уровень:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LevelLabel);
            this.groupBox1.Controls.Add(this.LineLabel);
            this.groupBox1.Controls.Add(this.ScoreLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(361, 397);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 154);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(47, 55);
            this.ScoreLabel.MinimumSize = new System.Drawing.Size(39, 13);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(39, 13);
            this.ScoreLabel.TabIndex = 3;
            this.ScoreLabel.Text = "0";
            // 
            // LineLabel
            // 
            this.LineLabel.AutoSize = true;
            this.LineLabel.Location = new System.Drawing.Point(114, 87);
            this.LineLabel.MinimumSize = new System.Drawing.Size(39, 13);
            this.LineLabel.Name = "LineLabel";
            this.LineLabel.Size = new System.Drawing.Size(39, 13);
            this.LineLabel.TabIndex = 3;
            this.LineLabel.Text = "0";
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(114, 123);
            this.LevelLabel.MinimumSize = new System.Drawing.Size(39, 13);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(39, 13);
            this.LevelLabel.TabIndex = 3;
            this.LevelLabel.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 731);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.MainPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 770);
            this.MinimumSize = new System.Drawing.Size(550, 770);
            this.Name = "MainForm";
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MainPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Level_btn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Button NewGame_btn;
        private System.Windows.Forms.Button StartPause_Btn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LevelLabel;
        public System.Windows.Forms.Label ScoreLabel;
        public System.Windows.Forms.Label LineLabel;
    }
}

