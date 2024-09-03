namespace WindowsFormsApp1
{
    partial class Form1
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
            this.textBoxSystem = new System.Windows.Forms.TextBox();
            this.numericUpDownXCount = new System.Windows.Forms.NumericUpDown();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxWriteFile = new System.Windows.Forms.CheckBox();
            this.textBoxU = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonModel = new System.Windows.Forms.Button();
            this.numericUpDownGameCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGameCount)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSystem
            // 
            this.textBoxSystem.Location = new System.Drawing.Point(16, 39);
            this.textBoxSystem.Multiline = true;
            this.textBoxSystem.Name = "textBoxSystem";
            this.textBoxSystem.Size = new System.Drawing.Size(296, 222);
            this.textBoxSystem.TabIndex = 0;
            // 
            // numericUpDownXCount
            // 
            this.numericUpDownXCount.Location = new System.Drawing.Point(343, 39);
            this.numericUpDownXCount.Name = "numericUpDownXCount";
            this.numericUpDownXCount.Size = new System.Drawing.Size(166, 20);
            this.numericUpDownXCount.TabIndex = 2;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(343, 103);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(74, 20);
            this.textBoxX.TabIndex = 3;
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(343, 155);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(168, 20);
            this.textBoxMax.TabIndex = 4;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(394, 180);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(115, 30);
            this.buttonSolve.TabIndex = 5;
            this.buttonSolve.Text = "Розрахувати";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Обмеження";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Кількість змінних";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Стратегія 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ціна гри";
            // 
            // checkBoxWriteFile
            // 
            this.checkBoxWriteFile.AutoSize = true;
            this.checkBoxWriteFile.Location = new System.Drawing.Point(342, 188);
            this.checkBoxWriteFile.Name = "checkBoxWriteFile";
            this.checkBoxWriteFile.Size = new System.Drawing.Size(46, 17);
            this.checkBoxWriteFile.TabIndex = 11;
            this.checkBoxWriteFile.Text = "Звіт";
            this.checkBoxWriteFile.UseVisualStyleBackColor = true;
            // 
            // textBoxU
            // 
            this.textBoxU.Location = new System.Drawing.Point(432, 103);
            this.textBoxU.Name = "textBoxU";
            this.textBoxU.Size = new System.Drawing.Size(79, 20);
            this.textBoxU.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Стратегія 2";
            // 
            // buttonModel
            // 
            this.buttonModel.Location = new System.Drawing.Point(415, 217);
            this.buttonModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModel.Name = "buttonModel";
            this.buttonModel.Size = new System.Drawing.Size(94, 44);
            this.buttonModel.TabIndex = 14;
            this.buttonModel.Text = "Змоделювати";
            this.buttonModel.UseVisualStyleBackColor = true;
            this.buttonModel.Click += new System.EventHandler(this.buttonModel_Click);
            // 
            // numericUpDownGameCount
            // 
            this.numericUpDownGameCount.Location = new System.Drawing.Point(342, 239);
            this.numericUpDownGameCount.Name = "numericUpDownGameCount";
            this.numericUpDownGameCount.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownGameCount.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Кліькість ігор";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownGameCount);
            this.Controls.Add(this.buttonModel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxU);
            this.Controls.Add(this.checkBoxWriteFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.numericUpDownXCount);
            this.Controls.Add(this.textBoxSystem);
            this.Name = "Form1";
            this.Text = "LR6";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGameCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSystem;
        private System.Windows.Forms.NumericUpDown numericUpDownXCount;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxWriteFile;
        private System.Windows.Forms.TextBox textBoxU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonModel;
        private System.Windows.Forms.NumericUpDown numericUpDownGameCount;
        private System.Windows.Forms.Label label1;
    }
}

