namespace KG4
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.open = new System.Windows.Forms.Button();
            this.grey = new System.Windows.Forms.Button();
            this.saw = new System.Windows.Forms.Button();
            this.mask = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(169, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1073, 751);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(117, 37);
            this.open.TabIndex = 2;
            this.open.Text = "OPEN FILE";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // grey
            // 
            this.grey.Location = new System.Drawing.Point(12, 76);
            this.grey.Name = "grey";
            this.grey.Size = new System.Drawing.Size(117, 37);
            this.grey.TabIndex = 3;
            this.grey.Text = "TURN TO GREY";
            this.grey.UseVisualStyleBackColor = true;
            this.grey.Click += new System.EventHandler(this.grey_Click);
            // 
            // saw
            // 
            this.saw.Location = new System.Drawing.Point(12, 136);
            this.saw.Name = "saw";
            this.saw.Size = new System.Drawing.Size(117, 37);
            this.saw.TabIndex = 4;
            this.saw.Text = "SAW FILTER";
            this.saw.UseVisualStyleBackColor = true;
            this.saw.Click += new System.EventHandler(this.saw_Click);
            // 
            // mask
            // 
            this.mask.Location = new System.Drawing.Point(12, 240);
            this.mask.Name = "mask";
            this.mask.Size = new System.Drawing.Size(117, 37);
            this.mask.TabIndex = 5;
            this.mask.Text = "MATRIX MASK";
            this.mask.UseVisualStyleBackColor = true;
            this.mask.Click += new System.EventHandler(this.mask_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 765);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mask);
            this.Controls.Add(this.saw);
            this.Controls.Add(this.grey);
            this.Controls.Add(this.open);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button grey;
        private System.Windows.Forms.Button saw;
        private System.Windows.Forms.Button mask;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

