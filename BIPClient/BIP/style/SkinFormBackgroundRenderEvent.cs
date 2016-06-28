using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace com.ccf.bip.frame.style
{
     public delegate void SkinFormBackgroundRenderEventHandler(
        object sender,
        SkinFormBackgroundRenderEventArgs e);

    public class SkinFormBackgroundRenderEventArgs : PaintEventArgs
    {
        private SkinForm _skinForm;

        public SkinFormBackgroundRenderEventArgs(
            SkinForm skinForm,
            Graphics g,
            Rectangle clipRect)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
        }

        public SkinForm SkinForm
        {
            get { return _skinForm; }
        }
    }
}
