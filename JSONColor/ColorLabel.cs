using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JSONColor
{
	class ColorLabel : Label
	{
		public Color BorderColor { get; set; }

		public bool DrewDone { get; set; }
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (!DrewDone) {
				ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, BorderColor, ButtonBorderStyle.Solid);
			}
			
		}
	}
}
