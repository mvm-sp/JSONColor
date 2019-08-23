using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SWMBrush = System.Windows.Media.Brush;



namespace JSONColor
{
	public partial class cFormCores : Form
	{
		ColorDialog colorDlg;

		#region Operacoes
		public cFormCores()
		{
			InitializeComponent();
			colorDlg = new ColorDialog
			{
				AllowFullOpen = true,
				AnyColor = true,
				SolidColorOnly = false
			};
			LoadTree();

		}

		private void ForegroundButton_Click(object sender, EventArgs e)
		{

			colorDlg.Color = cLabelTexto.BackColor;

			if (colorDlg.ShowDialog() == DialogResult.OK)
			{
				cButtonSample.ForeColor = colorDlg.Color;
				cLabelTexto.BackColor = colorDlg.Color;
			}
		}

		private void BackgroundButton_Click(object sender, EventArgs e)
		{
			colorDlg.Color = cLabelFundo.BackColor;
			if (colorDlg.ShowDialog() == DialogResult.OK)
			{
				cButtonSample.BackColor = colorDlg.Color;
				cLabelFundo.BackColor = colorDlg.Color;
			}
		}


		private void CButtonBorder_Click(object sender, EventArgs e)
		{
			colorDlg.Color = cLabelBorda.BackColor;
			if (colorDlg.ShowDialog() == DialogResult.OK)
			{
				cButtonSample.FlatAppearance.BorderColor = colorDlg.Color;
				cLabelBorda.BackColor = colorDlg.Color;
			}
		}

		private void CFormCores_Load(object sender, EventArgs e)
		{

		}

		private void CButtonSample_Click(object sender, EventArgs e)
		{
			/*ColorLabel mLabel = new ColorLabel
			{
				BackColor = cLabelFundo.BackColor,
				ForeColor = cLabelTexto.BackColor,
				BorderColor = cLabelBorda.BackColor,
				TextAlign = ContentAlignment.MiddleCenter,
				Width = 150,
				Text = "Exemplo " + (cPanelCores.Controls.Count + 1).ToString().PadLeft(2, '0')
			};
			mLabel.Top = ((mLabel.Height + 2) * cPanelCores.Controls.Count);
			mLabel.MouseDown += Label_MouseDown;
			cPanelCores.Controls.Add(mLabel);*/
			
		}

		private void CButtonGera_Click(object sender, EventArgs e)
		{
			StringBuilder mSBuilder = new StringBuilder();

			foreach (Control mLabel in this.cPanelCores.Controls)
			{
				string mCor = "";
				mSBuilder.Append(mCor);
			}
		}
		private void Label_MouseDown(object sender, EventArgs e)
		{
			ColorLabel mLabel = (ColorLabel)sender;
			cLabelFundo.BackColor = mLabel.BackColor;
			cLabelTexto.BackColor = mLabel.ForeColor;
			cLabelBorda.BackColor = mLabel.BorderColor;

		}
		#endregion


		#region tree
		private void LoadTree()
		{
			string path = "colors.json";
			using (var reader = new StreamReader(path))
			using (var jsonReader = new JsonTextReader(reader))
			{
				var root = JToken.Load(jsonReader);
				DisplayTreeView(root, Path.GetFileNameWithoutExtension(path));
			}
		}

		private void DisplayTreeView(JToken root, string rootName)
		{
			TreeView mColorTree = cTreeViewCores;

			mColorTree.BeginUpdate();
			try
			{
				mColorTree.Nodes.Clear();
				var tNode = mColorTree.Nodes[mColorTree.Nodes.Add(new TreeNode(rootName))];
				tNode.Tag = root;

				AddNode(root, tNode);

				mColorTree.ExpandAll();
			}
			finally
			{
				mColorTree.EndUpdate();
			}

		}

		private void AddNode(JToken token, TreeNode inTreeNode)
		{
			if (token == null)
				return;
			if (token is JValue)
			{

				TreeNode childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
				childNode.Tag = token;

			}
			else if (token is JObject)
			{
				var obj = (JObject)token;
				foreach (var property in obj.Properties())
				{
					var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
					childNode.Tag = property;
					AddNode(property.Value, childNode);
				}
			}
			else if (token is JArray)
			{
				var array = (JArray)token;
				for (int i = 0; i < array.Count; i++)
				{
					TreeNode childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(i.ToString()))];
					childNode.Tag = array[i];
					AddNode(array[i], childNode);
				}
			}
			else
			{
				Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
			}
		}

		private void CButtonAssocia_Click(object sender, EventArgs e)
		{
			string mCor = "Sem Cor";
			foreach (TreeNode mNode in cTreeViewCores.SelectedNode.Nodes) {
				switch (mNode.Text)
				{
					case "Texto":
						mCor = cLabelTexto.BackColor.R.ToString() + ", " + cLabelTexto.BackColor.G.ToString() + ", " + cLabelTexto.BackColor.B.ToString();
						break;
					case "Fundo":
						mCor = cLabelFundo.BackColor.R.ToString() + ", " + cLabelFundo.BackColor.G.ToString() + ", " + cLabelFundo.BackColor.B.ToString();
						break;
					case "Borda":
						mCor = cLabelBorda.BackColor.R.ToString() + ", " + cLabelBorda.BackColor.G.ToString() + ", " + cLabelBorda.BackColor.B.ToString();
						break;
					default:
						break;

				}
				mNode.Nodes[0].Text = mCor;
			}
			
		}

		private Color getFromRGB(string color) {
			var mArr = color.Split(',');
			return Color.FromArgb(int.Parse(mArr[0].Trim()), int.Parse(mArr[1].Trim()), int.Parse(mArr[2].Trim()));
		}

		#endregion

		private void CTreeViewCores_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode mNode = ((TreeView)sender).SelectedNode;
			if (mNode.Nodes.Count == 3)
			{
				foreach (TreeNode mChild in cTreeViewCores.SelectedNode.Nodes)
				{
					switch (mChild.Text)
					{
						case "Texto":
							cLabelTexto.BackColor = getFromRGB(mChild.Nodes[0].Text);
							cButtonSample.ForeColor = cLabelTexto.BackColor;
							break;
						case "Fundo":
							cLabelFundo.BackColor = getFromRGB(mChild.Nodes[0].Text);
							cButtonSample.BackColor = cLabelFundo.BackColor;
							break;
						case "Borda":
							cLabelBorda.BackColor = getFromRGB(mChild.Nodes[0].Text);
							cButtonSample.FlatAppearance.BorderColor = cLabelBorda.BackColor;
							break;
						default:
							break;

					}
				}
					cButtonAssocia.Enabled = (mNode.Nodes[0].Text == "Texto");
			}		
			else
			{
				cButtonAssocia.Enabled = false;
			}
			//cButtonAssocia.Enabled = (((TreeView)sender).SelectedNode.Parent.Text == "Borda" || ((TreeView)sender).SelectedNode.Parent.Text == "Texto" || ((TreeView)sender).SelectedNode.Parent.Text == "Fundo");

		}


		private void CTreeViewCores_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			// Draw the background and node text for a selected node.
			string mCorFundo = "255,255,255";
			string mCorTexto = "0,0,0";
			string mCorBorda= "255,255,255";
			string mCorEscreve = "0,0,0";
			Rectangle mBounds = new Rectangle(e.Node.Bounds.X - 3, e.Node.Bounds.Y - 3, e.Node.Bounds.Width + 2, e.Node.Bounds.Height + 2);
			if (e.Node.Parent != null) {
				switch (e.Node.Parent.Text)
				{
					case "Texto":
						mCorTexto = e.Node.Text;
						mCorEscreve = e.Node.Text;
						break;
					case "Fundo":
						mCorFundo = e.Node.Text;
						mCorEscreve = e.Node.Text;
						break;
					case "Borda":
						mCorBorda = e.Node.Text;
						mCorEscreve = e.Node.Text;
						break;
					default:
						break;

				}
			}
			if ((e.State & TreeNodeStates.Selected) != 0)
			{
				Font nodeFont = e.Node.NodeFont;
				if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
				Pen p = new Pen(getFromRGB(mCorBorda));
				//e.Graphics.DrawRectangle(p, mBounds);
				//e.Graphics.FillRectangle(ConvertToBrush(mCorFundo), mBounds);
				// Draw the node text.
				e.Graphics.DrawString(e.Node.Text, nodeFont, ConvertToBrush(mCorEscreve),
						Rectangle.Inflate(e.Bounds, 2, 0));
			}

			// Use the default background and node text.
			else
			{
				Font nodeFont = e.Node.NodeFont;
				if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
				Pen p = new Pen(getFromRGB(mCorBorda));
				//draw border
				//e.Graphics.DrawRectangle(p, mBounds);
				//e.Graphics.FillRectangle(ConvertToBrush(mCorFundo), mBounds);
				// Draw the node text.
				e.Graphics.DrawString(e.Node.Text, nodeFont, ConvertToBrush(mCorEscreve),
						Rectangle.Inflate(e.Bounds, 2, 0));
			}

			// If the node has focus, draw the focus rectangle large, making
			// it large enough to include the text of the node tag, if present.
			if ((e.State & TreeNodeStates.Focused) != 0)
			{
				using (Pen focusPen = new Pen(Color.Red))
				{
					focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
					Rectangle focusBounds = mBounds;
					focusBounds.Size = new Size(focusBounds.Width - 1,
					focusBounds.Height - 1);
					e.Graphics.DrawRectangle(focusPen, mBounds);
					e.Graphics.FillRectangle(ConvertToBrush("50,50,255"), mBounds);
					e.Graphics.DrawString(e.Node.Text, cTreeViewCores.Font, ConvertToBrush("255,255,255"),Rectangle.Inflate(e.Bounds, 2, 0));
				}
			}

		}

		public System.Drawing.Brush ConvertToBrush(string color) {
			System.Drawing.ColorConverter mConverter = new System.Drawing.ColorConverter();
			System.Drawing.Brush mBrush = new System.Drawing.SolidBrush((System.Drawing.Color)mConverter.ConvertFrom(color));
			return mBrush;

		} 
		/*System.Windows.Media.Color ConvertColorType(System.Drawing.Color color)
		{
			byte AVal = color.A;
			byte RVal = color.R;
			byte GVal = color.G;
			byte BVal = color.B;
			
			return SWMBrush.FromArgb(AVal, RVal, GVal, BVal);
		}*/
	}
}
