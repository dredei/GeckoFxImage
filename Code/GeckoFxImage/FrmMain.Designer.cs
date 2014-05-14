namespace GeckoFxImage
{
    partial class FrmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnter = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnGetNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnter.Location = new System.Drawing.Point(0, 92);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(175, 23);
            this.btnEnter.TabIndex = 1;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(175, 60);
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(0, 66);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(175, 20);
            this.tbInput.TabIndex = 3;
            // 
            // btnGetNew
            // 
            this.btnGetNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetNew.Location = new System.Drawing.Point(0, 121);
            this.btnGetNew.Name = "btnGetNew";
            this.btnGetNew.Size = new System.Drawing.Size(175, 23);
            this.btnGetNew.TabIndex = 4;
            this.btnGetNew.Text = "Get new";
            this.btnGetNew.UseVisualStyleBackColor = true;
            this.btnGetNew.Click += new System.EventHandler(this.btnGetNew_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(179, 146);
            this.Controls.Add(this.btnGetNew);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnEnter);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captcha";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnGetNew;
    }
}

