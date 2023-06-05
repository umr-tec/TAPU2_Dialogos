
namespace TAPU2_Dialogos
{
    partial class Captura
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
            this.pbCaptura = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptura)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaptura
            // 
            this.pbCaptura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCaptura.Location = new System.Drawing.Point(0, 0);
            this.pbCaptura.Name = "pbCaptura";
            this.pbCaptura.Size = new System.Drawing.Size(510, 474);
            this.pbCaptura.TabIndex = 0;
            this.pbCaptura.TabStop = false;
            // 
            // Captura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 474);
            this.ControlBox = false;
            this.Controls.Add(this.pbCaptura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Captura";
            this.Text = "Captura";
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbCaptura;
    }
}