using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace com.ccf.bip.framework.form.helper
{
    public class ControlHelper
    {
        public static Point GetAbsolutePosition(Control control)
        {
            return new Point(GetAbsoluteLeft(control), GetAbsoluteTop(control));
        }

        public static int GetAbsoluteLeft(Control control)
        {
            int left = 0;
            if (control.Parent != null && !(control.Parent is MdiClient))
            {
                left += GetAbsoluteLeft(control.Parent);
            }
            else
            {
                left -= control.Left;
            }
            left += control.Left;
            return left;
        }

        public static int GetAbsoluteTop(Control control)
        {
            int top = 0;
            if (control.Parent != null && !(control.Parent is MdiClient))
            {
                top += GetAbsoluteTop(control.Parent);
            }
            else
            {
                top -= control.Top;
            }
            top += control.Top;
            return top;
        }

        public static Control GetBaseControl(Control control)
        {
            Control baseControl = control;
            while (baseControl.Parent != null && !(baseControl.Parent is MdiClient))
            {
                baseControl = baseControl.Parent;
            }
            return baseControl;
        }
    }
}
