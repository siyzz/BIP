using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace com.ccf.bip.frame.style
{
    public delegate void SkinFormBorderRenderEventHandler(
        object sender,
        SkinFormBorderRenderEventArgs e);

    public class SkinFormBorderRenderEventArgs : PaintEventArgs
    {
        private SkinForm _skinForm;
        private bool _active;

        public SkinFormBorderRenderEventArgs(
            SkinForm skinForm,
            Graphics g,
            Rectangle clipRect,
            bool active)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
            _active = active;
        }

        public SkinForm SkinForm
        {
            get { return _skinForm; }
        }

        public bool Active
        {
            get { return _active; }
        }
    }
}
