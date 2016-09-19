namespace ARScratch
{
    partial class ARView
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_OPEN = new System.Windows.Forms.Button();
            this.PCT_BOX = new System.Windows.Forms.PictureBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.BTN_CAMERA = new System.Windows.Forms.Button();
            this.BTN_EXECUTE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_BOX)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_OPEN
            // 
            this.BTN_OPEN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BTN_OPEN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_OPEN.ForeColor = System.Drawing.Color.Gray;
            this.BTN_OPEN.Location = new System.Drawing.Point(12, 12);
            this.BTN_OPEN.Name = "BTN_OPEN";
            this.BTN_OPEN.Size = new System.Drawing.Size(66, 29);
            this.BTN_OPEN.TabIndex = 0;
            this.BTN_OPEN.Text = "OPEN";
            this.BTN_OPEN.UseVisualStyleBackColor = false;
            this.BTN_OPEN.Click += new System.EventHandler(this.BTN_OPEN_Click);
            // 
            // PCT_BOX
            // 
            this.PCT_BOX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PCT_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PCT_BOX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PCT_BOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_BOX.Location = new System.Drawing.Point(172, 87);
            this.PCT_BOX.Name = "PCT_BOX";
            this.PCT_BOX.Size = new System.Drawing.Size(640, 480);
            this.PCT_BOX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCT_BOX.TabIndex = 1;
            this.PCT_BOX.TabStop = false;
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // BTN_CAMERA
            // 
            this.BTN_CAMERA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_CAMERA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BTN_CAMERA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CAMERA.ForeColor = System.Drawing.Color.Gray;
            this.BTN_CAMERA.Location = new System.Drawing.Point(192, 573);
            this.BTN_CAMERA.Name = "BTN_CAMERA";
            this.BTN_CAMERA.Size = new System.Drawing.Size(73, 31);
            this.BTN_CAMERA.TabIndex = 2;
            this.BTN_CAMERA.Text = "WEBCAM";
            this.BTN_CAMERA.UseVisualStyleBackColor = false;
            this.BTN_CAMERA.Click += new System.EventHandler(this.BTN_EXECUTE_Click);
            // 
            // BTN_EXECUTE
            // 
            this.BTN_EXECUTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BTN_EXECUTE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EXECUTE.ForeColor = System.Drawing.Color.Gray;
            this.BTN_EXECUTE.Location = new System.Drawing.Point(28, 47);
            this.BTN_EXECUTE.Name = "BTN_EXECUTE";
            this.BTN_EXECUTE.Size = new System.Drawing.Size(73, 34);
            this.BTN_EXECUTE.TabIndex = 3;
            this.BTN_EXECUTE.Text = "EXECUTE";
            this.BTN_EXECUTE.UseVisualStyleBackColor = false;
            this.BTN_EXECUTE.Click += new System.EventHandler(this.BTN_EXECUTE_Click_1);
            // 
            // ARView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(991, 681);
            this.Controls.Add(this.BTN_EXECUTE);
            this.Controls.Add(this.BTN_CAMERA);
            this.Controls.Add(this.PCT_BOX);
            this.Controls.Add(this.BTN_OPEN);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Name = "ARView";
            this.Text = "AR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ARView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_BOX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_OPEN;
        private System.Windows.Forms.PictureBox PCT_BOX;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Button BTN_CAMERA;
        private System.Windows.Forms.Button BTN_EXECUTE;
    }
}

