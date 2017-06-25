using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.CustomControls
{
    [System.ComponentModel.DesignerCategory("Code")]
    public class MyPanel : Panel
    {
        #region Global Viarables
        string _strHexColor = string.Empty;
        #endregion

        #region Constructors
        public MyPanel()
        {
        }

        public MyPanel(string strHexColor)
        {
            _strHexColor = strHexColor;
        }
        #endregion

        #region Events
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen;
            if (string.IsNullOrEmpty(_strHexColor))
            {
                pen = new Pen(ColorTranslator.FromHtml("#CCCCCC"), 1);
            }

            else
            {
                pen = new Pen(ColorTranslator.FromHtml(_strHexColor), 1);
            }

            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
        #endregion
    }
}
