namespace Reportes.GUI
{
    partial class VisorCompras
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
            this.label2 = new System.Windows.Forms.Label();
            this.Mostrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFinal = new System.Windows.Forms.DateTimePicker();
            this.dpInicio = new System.Windows.Forms.DateTimePicker();
            this.crvCompras = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hasta:";
            // 
            // Mostrar
            // 
            this.Mostrar.Location = new System.Drawing.Point(122, 236);
            this.Mostrar.Name = "Mostrar";
            this.Mostrar.Size = new System.Drawing.Size(72, 23);
            this.Mostrar.TabIndex = 10;
            this.Mostrar.Text = "Mostrar";
            this.Mostrar.UseVisualStyleBackColor = true;
            this.Mostrar.Click += new System.EventHandler(this.Mostrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "De:";
            // 
            // dpFinal
            // 
            this.dpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFinal.Location = new System.Drawing.Point(15, 168);
            this.dpFinal.Name = "dpFinal";
            this.dpFinal.Size = new System.Drawing.Size(135, 20);
            this.dpFinal.TabIndex = 8;
            // 
            // dpInicio
            // 
            this.dpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpInicio.Location = new System.Drawing.Point(15, 96);
            this.dpInicio.Name = "dpInicio";
            this.dpInicio.Size = new System.Drawing.Size(135, 20);
            this.dpInicio.TabIndex = 7;
            // 
            // crvCompras
            // 
            this.crvCompras.ActiveViewIndex = -1;
            this.crvCompras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCompras.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCompras.Location = new System.Drawing.Point(214, 1);
            this.crvCompras.Name = "crvCompras";
            this.crvCompras.Size = new System.Drawing.Size(589, 450);
            this.crvCompras.TabIndex = 6;
            this.crvCompras.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VisorCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvCompras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Mostrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpFinal);
            this.Controls.Add(this.dpInicio);
            this.Name = "VisorCompras";
            this.Text = "VisorCompras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Mostrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFinal;
        private System.Windows.Forms.DateTimePicker dpInicio;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCompras;
    }
}