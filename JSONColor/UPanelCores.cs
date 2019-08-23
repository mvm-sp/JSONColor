using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCon.TLib.Componente.Windows.Etc.Temas;

namespace JSONColor
{
	public partial class UPanelColor : Panel
	{
		private TCores mCores;

		private string corTextoARGB;
		private string corBordaARGB;
		private string corFundoARGB;

		#region Propriedades
		public TCores Cores
		{
			get
			{
				
				return mCores;
			}
			set
			{
				mCores = value;
				this.AtualizaCoresARGB();
			}
		}

		public string Texto { get; set; }
		public string CorTextoARGB
		{
			get
			{
				
				return corTextoARGB;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					corTextoARGB = value;
					this.InstanciaCores();
					this.mCores.Texto = this.CorARGB(corTextoARGB);
				}

			}
		}

		public string CorBordaARGB
		{
			get
			{
				
				return corBordaARGB;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					corBordaARGB = value;
					this.InstanciaCores();
					this.mCores.Borda = this.CorARGB(corBordaARGB);
				}

			}
		}

		public string CorFundoARGB
		{
			get
			{
				
				return corFundoARGB;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					corFundoARGB = value;
					this.InstanciaCores();
					this.mCores.Fundo = this.CorARGB(corFundoARGB);
				}

			}
		}
		#endregion


		public UPanelColor()
		{
			InitializeComponent();
			this.InstanciaCores();
		}

		protected override void OnPaint(PaintEventArgs e)
		{


			if (this.mCores != null)
			{
				if (this.mCores.Borda.A != 0)
				{
					ControlPaint.DrawBorder(e.Graphics, new Rectangle(0,0,this.Width - 1, this.Height-1) , this.mCores.Borda, ButtonBorderStyle.Solid);
				}
				if (this.mCores.Fundo.A != 0)
				{
					this.BackColor = this.mCores.Fundo;
				}
				if ((this.mCores.Texto != this.mCores.Fundo) && (this.mCores.Texto.A != 0))
				{
					e.Graphics.DrawString(this.Texto, this.Font, ConverteParaBrush(this.mCores.Texto.ToArgb().ToString()), 1, 1);

					this.ForeColor = this.mCores.Texto;
				}
			}

		}

		public System.Drawing.Brush ConverteParaBrush(string color)
		{
			System.Drawing.ColorConverter mConverter = new System.Drawing.ColorConverter();
			System.Drawing.Brush mBrush = new System.Drawing.SolidBrush((System.Drawing.Color)mConverter.ConvertFrom(color));
			return mBrush;

		}
		#region Metodos
		public string MontaJSON()
		{
			string mRet = "";
			if (this != null)
			{
				StringBuilder mBuider = new StringBuilder();
				var mArr = this.Tag.ToString().Split('.');
				string mTemp = "";
				string mTempB = "";
				string mTempT = "";
				string mTempF = "";
				int mMaxLen = 0;
				Color mCor;

				for (int x = 0; x <= mArr.Length - 1; x++)
				{
					mArr[x] = '"' + mArr[x] + '"' + ": {";
					mTemp = mArr[x].PadLeft(mArr[x].Length + (2 * x));
					mMaxLen = 2 * x;
					mBuider.AppendLine(mTemp);
				}
				mCor = this.mCores.Texto;
				mTempT = ConverteCor(mCor);

				mCor = this.mCores.Borda;
				mTempB = ConverteCor(mCor);

				mCor = this.mCores.Fundo;
				mTempF = ConverteCor(mCor);


				if (mTempT.Length > 0) mBuider.AppendLine(('"' + "Texto" + '"' + " : " + mTempT).PadLeft((mTempT).Length + mMaxLen + 12) + ((mTempB.Length > 0 || mTempF.Length > 0) ? "," : ""));


				if (mTempB.Length > 0) mBuider.AppendLine(('"' + "Borda" + '"' + " : " + mTempB).PadLeft((mTempB).Length + mMaxLen + 12) + ((mTempF.Length > 0) ? "," : ""));


				if (mTempF.Length > 0) mBuider.AppendLine(('"' + "Fundo" + '"' + " : " + mTempF).PadLeft((mTempF).Length + mMaxLen + 12));
				for (int x = mArr.Length - 1; x >= 0; x--)
				{
					mBuider.AppendLine(string.Concat(Enumerable.Repeat(" ", x * 2)) + "}");
				}
				mRet = mBuider.ToString();
			}
			this.AtualizaCoresARGB();
			return mRet;
		}

		private Color CorARGB(string color)
		{
			var mArr = color.Split(',');
			Color mCor;
			if (mArr.Length == 3)
			{
				mCor = Color.FromArgb(int.Parse(mArr[0].Trim()), int.Parse(mArr[1].Trim()), int.Parse(mArr[2].Trim()));
			}
			else
			{
				mCor = Color.FromArgb(int.Parse(mArr[0].Trim()), int.Parse(mArr[1].Trim()), int.Parse(mArr[2].Trim()), int.Parse(mArr[3].Trim()));
			}
			return mCor;
		}

		private string ConverteCor(Color mCor)
		{
			string mRet = "";

			if (mCor.A != 255)
			{
				mRet = mCor.A.ToString() + "," + mCor.R.ToString() + "," + mCor.G.ToString() + "," + mCor.B.ToString();
			}
			else
			{

				mRet = mCor.R.ToString() + "," + mCor.G.ToString() + "," + mCor.B.ToString();
			}
			mRet = '"' + mRet + '"';

			return mRet;
		}

		private void InstanciaCores()
		{
			if (this.mCores == null) this.mCores = new TCores();
		}

		private void AtualizaCoresARGB()
		{
			if (mCores != null)
			{
				corTextoARGB = ConverteCor(mCores.Texto).Replace('"', ' ').Trim();
				corBordaARGB = ConverteCor(mCores.Borda).Replace('"', ' ').Trim();
				corFundoARGB = ConverteCor(mCores.Fundo).Replace('"', ' ').Trim();
			}
		}
		#endregion
	}
}
