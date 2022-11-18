
namespace Lotto
{
    partial class Lotto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lotto));
            this.label1 = new System.Windows.Forms.Label();
            this.remainingNumbersID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Осталось номеров:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // remainingNumbersID
            // 
            this.remainingNumbersID.AutoSize = true;
            this.remainingNumbersID.Location = new System.Drawing.Point(865, 34);
            this.remainingNumbersID.Name = "remainingNumbersID";
            this.remainingNumbersID.Size = new System.Drawing.Size(13, 17);
            this.remainingNumbersID.TabIndex = 2;
            this.remainingNumbersID.Text = "-";
            this.remainingNumbersID.Click += new System.EventHandler(this.label2_Click);
            // 
            // Lotto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.remainingNumbersID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lotto";
            this.RightToLeftLayout = true;
            this.Text = "Lotto";
            this.Load += new System.EventHandler(this.Loto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label remainingNumbersID;
    }
}

