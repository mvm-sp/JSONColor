using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCon.TLib.Componente.Windows.Etc.Temas;

namespace JSONColor
{
	public partial class cFormTemplate : Form
	{
		private JToken root;
		private UPanelColor gControl;
		private Dictionary<string, UPanelColor> mControls;

		public cFormTemplate()
		{
			InitializeComponent();
			mControls = new Dictionary<string, UPanelColor>();
		}

		#region Metodos
		private void MudaCorPanel(UPanelColor mPanel, Label mLabel) {
			Color mCor ;
			if (mPanel != null)
			{
				if (mLabel.Name == "cLabelTexto")
				{
					mCor = mPanel.Cores.Texto;
				}
				else if (mLabel.Name == "cLabelBorda")
				{
					mCor = mPanel.Cores.Borda;
				}
				else
				{
					mCor = mPanel.Cores.Fundo;
				}
				if (mCor.A != 0)
				{
					cColorDialog.Color = mLabel.BackColor;
					if (cColorDialog.ShowDialog() == DialogResult.OK)
					{
						mLabel.BackColor = cColorDialog.Color;
						if (mLabel.Name == "cLabelTexto")
						{
							mPanel.Cores.Texto = cColorDialog.Color;
						}
						else if (mLabel.Name == "cLabelBorda")
						{
						  mPanel.Cores.Borda = cColorDialog.Color;
						}
						else
						{
							mPanel.Cores.Fundo = cColorDialog.Color;
						}
						this.MostraJSON();
						mPanel.Refresh();
					}
				}
			}
		}


		private void CriaEstilos()
		{
			cPanelEstilos.Controls.Clear();
			JToken jEstilos = root.SelectToken("EstruturaCores.Estrutura.Estilos");
			foreach (var item in jEstilos )
			{
				JToken mEst = ((Newtonsoft.Json.Linq.JProperty)item).First();
	
				UPanelColor mPanel = new UPanelColor
				{
					CorTextoARGB = mEst.SelectToken("Texto").ToString(),
					CorBordaARGB = mEst.SelectToken("Borda").ToString(),
					CorFundoARGB = mEst.SelectToken("Fundo").ToString(),
					Texto = "Estilo " + ((Newtonsoft.Json.Linq.JProperty)item).Name,
					Width = 300,
					Height = 30,
					Name = "cPanelCoresEstilo" + ((Newtonsoft.Json.Linq.JProperty)item).Name,
					Tag = mEst.Path,
					
				};
				mPanel.Top = ((mPanel.Height + 2) * cPanelEstilos.Controls.Count);

				cPanelEstilos.Controls.Add(mPanel);
				mControls.Add(mPanel.Name, mPanel);
				mPanel.Refresh();
			

			}

		}


		private void DesenhaBorda(PaintEventArgs e, Label control) {
			Rectangle mBounds = new Rectangle(0, 0, control.Width - 1, control.Height -1);
			using (Pen focusPen = new Pen(Color.Black))
			{
				focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
				e.Graphics.DrawRectangle(focusPen, mBounds);
			}
		}

	
		private void MudaCorControle(Control control) {
			foreach (Control mControl in control.Controls)
			{
				this.MudaCorControle(mControl);
			}
			if (control.Tag != null)
			{
				JToken jCores = root.SelectToken(control.Tag.ToString());
				
				UPanelColor mPanel = (UPanelColor)control;
				if (jCores.SelectToken("Texto") != null) mPanel.CorTextoARGB = jCores.SelectToken("Texto").ToString();
				if (jCores.SelectToken("Borda") != null) mPanel.CorBordaARGB = jCores.SelectToken("Borda").ToString();
				if (jCores.SelectToken("Fundo") != null) mPanel.CorFundoARGB = jCores.SelectToken("Fundo").ToString();
				mControls.Add(control.Name, mPanel);
			}
		}

		private void MostraJSON()
		{
			cTextJSON.Text = gControl.MontaJSON();
		}

		private void MontaJSONCompleto()
		{
			if (root != null)
			{
				foreach (UPanelColor mPanel in mControls.Values)
				{
					this.AtualizaJSONPanel(mPanel);
				}
				cTextJSON.Text = "\n" + root.ToString();
			}

		}

		private void AtualizaJSONPanel(UPanelColor mPanel)
		{
			
			JToken jCores = root.SelectToken(mPanel.Tag.ToString());
			JContainer jCol = ((Newtonsoft.Json.Linq.JContainer)jCores);
			if (jCores.SelectToken("Texto") == null)
			{
				((JObject)jCores).Add(new JProperty("Texto", mPanel.CorTextoARGB));
			}
			else
			{
				jCores["Texto"] = mPanel.CorTextoARGB;
			}

			if (jCores.SelectToken("Borda") == null)
			{
				((JObject)jCores).Add(new JProperty("Borda", mPanel.CorBordaARGB)); 
			}
			else
			{
				jCores["Borda"] = mPanel.CorBordaARGB;
			}

			if (jCores.SelectToken("Fundo") == null)
			{
				((JObject)jCores).Add(new JProperty("Fundo", mPanel.CorFundoARGB)); 
			}
			else
			{
				jCores["Fundo"] = mPanel.CorFundoARGB;
			}
		}

		private void AdicionaEvento()
		{
			foreach(UPanelColor mPanel in mControls.Values)
			{
				 mPanel.Click += CPanelColor_Click;

			}

		}
		#endregion
		#region eventos
		private void CFormTemplate_Load(object sender, EventArgs e)
		{


			cToolTip.SetToolTip(cButtonCopy, "Copiar Texto");
			cToolTip.SetToolTip(cButtonPaste, "Colar do Texto");

		}
		private void OnLabelPaint(object sender, PaintEventArgs e)
		{
			this.DesenhaBorda(e, (Label)sender);
		}

		private void CLableTexto_Click(object sender, EventArgs e)
		{

			this.MudaCorPanel(gControl, cLabelTexto);

		}

		private void CLabelBorda_Click(object sender, EventArgs e)
		{
			this.MudaCorPanel(gControl, cLabelBorda);

		}

		private void CLabelFundo_Click(object sender, EventArgs e)
		{
			this.MudaCorPanel(gControl, cLabelFundo);
		}

		private void CPanelColorTitulo_Paint(object sender, PaintEventArgs e)
		{

		}

		private void CPanelColor_Click(object sender, EventArgs e)
		{
			UPanelColor control = (UPanelColor)sender;
			if (control.Cores != null)
			{
				cLabelTexto.BackColor = control.Cores.Texto == null ? Color.FromArgb(0, 0, 0, 0) : control.Cores.Texto;
				cLabelBorda.BackColor = control.Cores.Borda == null ? Color.FromArgb(0, 0, 0, 0) : control.Cores.Borda;
				cLabelFundo.BackColor = control.Cores.Fundo == null ? Color.FromArgb(0, 0, 0, 0) : control.Cores.Fundo;
				gControl = (UPanelColor)sender;
				this.MostraJSON();
			}

		}

		private void CButtonSalva_Click(object sender, EventArgs e)
		{
			this.MontaJSONCompleto();
		}

		private void CButtonEstilo_Click(object sender, EventArgs e)
		{
			if (root != null)
			{
				JToken jEstilos = root.SelectToken("EstruturaCores.Estrutura.Estilos");
				JProperty mEst = (JProperty)((JContainer)jEstilos).Last;

				UPanelColor mPanel = new UPanelColor
				{
					CorTextoARGB = "255,255,255",
					CorBordaARGB = "255,0,0",
					CorFundoARGB = "255,255,255",
					Texto = "Estilo " + (int.Parse(mEst.Name) + 1).ToString().PadLeft(2, '0'),
					Width = 300,
					Height = 30,
					Name = "cPanelCoresEstilo" + (int.Parse(mEst.Name) + 1).ToString().PadLeft(2, '0'),
					Tag = "EstruturaCores.Estrutura.Estilos." + (int.Parse(mEst.Name) + 1).ToString().PadLeft(2, '0')

				};
				mPanel.Top = ((mPanel.Height + 2) * cPanelEstilos.Controls.Count);

				cPanelEstilos.Controls.Add(mPanel);
				mControls.Add(mPanel.Name, mPanel);
				mPanel.Click += CPanelColor_Click;
				mPanel.Refresh();

				((JObject)jEstilos).Add(new JProperty((int.Parse(mEst.Name) + 1).ToString().PadLeft(2, '0'), JToken.Parse(@"{}")));
				

				this.AtualizaJSONPanel(mPanel);

			}
			
		}

		private void CButtonPaste_Click(object sender, EventArgs e)
		{
			try
			{
				cTextJSON.Text = Clipboard.GetText();
				//string path = "colors.json";
				//using (var reader = new System.IO.StreamReader(path))
				//using (var jsonReader = new JsonTextReader(reader))
				//{
					//root = JToken.Load(cTextJSON.Text);
					//root = JToken.Parse(cTextJSON.Text);
				//}
				root = JToken.Parse(cTextJSON.Text);
				cPanelEstilos.Controls.Clear();
				mControls.Clear();
				this.MudaCorControle(this.cPanelTemplate);
				this.CriaEstilos();
				this.AdicionaEvento();
				this.Refresh();
			}
			catch (Exception ex)
			{

				MessageBox.Show("Erro ao ler o JSON, por favro, verifique\n" + ex.ToString());

			}

		}

		private void CButtonCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(cTextJSON.Text);
		}
		#endregion


	}
}
