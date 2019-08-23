using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace JSONColor
{
	class ColorTree : TreeView
	{
		public Color BorderColor { get; set; }

		public bool DrewDone { get; set; }

		public TreeView Base { get; set; }
		protected override void OnDrawNode(DrawTreeNodeEventArgs e)
		{
			//if ((e.State & TreeNodeStates.Selected) != 0){
				base.OnDrawNode(e);
				ControlPaint.DrawBorder(e.Graphics, ((TreeNode)Base.SelectedNode).Bounds, BorderColor, ButtonBorderStyle.Solid);
			//}

		}
	}
}

