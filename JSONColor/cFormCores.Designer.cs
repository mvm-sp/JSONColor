namespace JSONColor
{
    partial class cFormCores
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
			System.Windows.Forms.ColorDialog cColorDialog;
			this.cButtonForeground = new System.Windows.Forms.Button();
			this.cButtonBackground = new System.Windows.Forms.Button();
			this.cButtonBorder = new System.Windows.Forms.Button();
			this.cLabelTexto = new System.Windows.Forms.Label();
			this.cLabelFundo = new System.Windows.Forms.Label();
			this.cLabelBorda = new System.Windows.Forms.Label();
			this.cButtonSample = new System.Windows.Forms.Button();
			this.cPanelCores = new System.Windows.Forms.Panel();
			this.cButtonGera = new System.Windows.Forms.Button();
			this.cTreeViewCores = new System.Windows.Forms.TreeView();
			this.cButtonAssocia = new System.Windows.Forms.Button();
			cColorDialog = new System.Windows.Forms.ColorDialog();
			this.SuspendLayout();
			// 
			// cColorDialog
			// 
			cColorDialog.FullOpen = true;
			// 
			// cButtonForeground
			// 
			this.cButtonForeground.Location = new System.Drawing.Point(350, 12);
			this.cButtonForeground.Name = "cButtonForeground";
			this.cButtonForeground.Size = new System.Drawing.Size(55, 31);
			this.cButtonForeground.TabIndex = 0;
			this.cButtonForeground.Text = "Texto";
			this.cButtonForeground.UseVisualStyleBackColor = true;
			this.cButtonForeground.Click += new System.EventHandler(this.ForegroundButton_Click);
			// 
			// cButtonBackground
			// 
			this.cButtonBackground.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cButtonBackground.Location = new System.Drawing.Point(350, 86);
			this.cButtonBackground.Name = "cButtonBackground";
			this.cButtonBackground.Size = new System.Drawing.Size(55, 31);
			this.cButtonBackground.TabIndex = 1;
			this.cButtonBackground.Text = "Fundo";
			this.cButtonBackground.UseVisualStyleBackColor = true;
			this.cButtonBackground.Click += new System.EventHandler(this.BackgroundButton_Click);
			// 
			// cButtonBorder
			// 
			this.cButtonBorder.Location = new System.Drawing.Point(350, 49);
			this.cButtonBorder.Name = "cButtonBorder";
			this.cButtonBorder.Size = new System.Drawing.Size(55, 31);
			this.cButtonBorder.TabIndex = 7;
			this.cButtonBorder.Text = "Borda";
			this.cButtonBorder.UseVisualStyleBackColor = true;
			this.cButtonBorder.Click += new System.EventHandler(this.CButtonBorder_Click);
			// 
			// cLabelTexto
			// 
			this.cLabelTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cLabelTexto.Cursor = System.Windows.Forms.Cursors.No;
			this.cLabelTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cLabelTexto.Location = new System.Drawing.Point(4, 17);
			this.cLabelTexto.Name = "cLabelTexto";
			this.cLabelTexto.Size = new System.Drawing.Size(340, 20);
			this.cLabelTexto.TabIndex = 8;
			this.cLabelTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cLabelFundo
			// 
			this.cLabelFundo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cLabelFundo.Cursor = System.Windows.Forms.Cursors.No;
			this.cLabelFundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cLabelFundo.Location = new System.Drawing.Point(4, 91);
			this.cLabelFundo.Name = "cLabelFundo";
			this.cLabelFundo.Size = new System.Drawing.Size(340, 20);
			this.cLabelFundo.TabIndex = 9;
			this.cLabelFundo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cLabelBorda
			// 
			this.cLabelBorda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cLabelBorda.Cursor = System.Windows.Forms.Cursors.No;
			this.cLabelBorda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cLabelBorda.Location = new System.Drawing.Point(4, 54);
			this.cLabelBorda.Name = "cLabelBorda";
			this.cLabelBorda.Size = new System.Drawing.Size(340, 20);
			this.cLabelBorda.TabIndex = 10;
			this.cLabelBorda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cButtonSample
			// 
			this.cButtonSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cButtonSample.Location = new System.Drawing.Point(94, 122);
			this.cButtonSample.Name = "cButtonSample";
			this.cButtonSample.Size = new System.Drawing.Size(302, 23);
			this.cButtonSample.TabIndex = 11;
			this.cButtonSample.Text = "Exemplo do Padrao";
			this.cButtonSample.UseVisualStyleBackColor = true;
			this.cButtonSample.Click += new System.EventHandler(this.CButtonSample_Click);
			// 
			// cPanelCores
			// 
			this.cPanelCores.AutoScroll = true;
			this.cPanelCores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cPanelCores.Location = new System.Drawing.Point(87, 169);
			this.cPanelCores.Name = "cPanelCores";
			this.cPanelCores.Size = new System.Drawing.Size(309, 117);
			this.cPanelCores.TabIndex = 12;
			this.cPanelCores.Visible = false;
			// 
			// cButtonGera
			// 
			this.cButtonGera.Location = new System.Drawing.Point(330, 548);
			this.cButtonGera.Name = "cButtonGera";
			this.cButtonGera.Size = new System.Drawing.Size(75, 23);
			this.cButtonGera.TabIndex = 13;
			this.cButtonGera.Text = "Gerar JSON";
			this.cButtonGera.UseVisualStyleBackColor = true;
			this.cButtonGera.Click += new System.EventHandler(this.CButtonGera_Click);
			// 
			// cTreeViewCores
			// 
			this.cTreeViewCores.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
			this.cTreeViewCores.HideSelection = false;
			this.cTreeViewCores.Location = new System.Drawing.Point(4, 151);
			this.cTreeViewCores.Name = "cTreeViewCores";
			this.cTreeViewCores.Size = new System.Drawing.Size(401, 391);
			this.cTreeViewCores.TabIndex = 15;
			this.cTreeViewCores.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.CTreeViewCores_DrawNode);
			this.cTreeViewCores.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CTreeViewCores_AfterSelect);
			// 
			// cButtonAssocia
			// 
			this.cButtonAssocia.Enabled = false;
			this.cButtonAssocia.Location = new System.Drawing.Point(5, 122);
			this.cButtonAssocia.Name = "cButtonAssocia";
			this.cButtonAssocia.Size = new System.Drawing.Size(83, 23);
			this.cButtonAssocia.TabIndex = 16;
			this.cButtonAssocia.Text = "Associar";
			this.cButtonAssocia.UseVisualStyleBackColor = true;
			this.cButtonAssocia.Click += new System.EventHandler(this.CButtonAssocia_Click);
			// 
			// cFormCores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 573);
			this.Controls.Add(this.cButtonAssocia);
			this.Controls.Add(this.cButtonGera);
			this.Controls.Add(this.cPanelCores);
			this.Controls.Add(this.cButtonSample);
			this.Controls.Add(this.cLabelBorda);
			this.Controls.Add(this.cLabelFundo);
			this.Controls.Add(this.cLabelTexto);
			this.Controls.Add(this.cButtonBorder);
			this.Controls.Add(this.cButtonBackground);
			this.Controls.Add(this.cButtonForeground);
			this.Controls.Add(this.cTreeViewCores);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "cFormCores";
			this.Text = "Gerar JSON de Cores";
			this.Load += new System.EventHandler(this.CFormCores_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cButtonForeground;
        private System.Windows.Forms.Button cButtonBackground;
		private System.Windows.Forms.Button cButtonBorder;
		private System.Windows.Forms.Label cLabelTexto;
		private System.Windows.Forms.Label cLabelFundo;
		private System.Windows.Forms.Label cLabelBorda;
		private System.Windows.Forms.Button cButtonSample;
		private System.Windows.Forms.Panel cPanelCores;
		private System.Windows.Forms.Button cButtonGera;
		private System.Windows.Forms.TreeView cTreeViewCores;
		private System.Windows.Forms.Button cButtonAssocia;
	}
}

