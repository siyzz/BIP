using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace com.ccf.bip.framework.form
{
    public class BipStyleBuilder
    {
        public static void SetFormStyle(BipForm form)
        {
            form.BackColor = Color.FromArgb(171, 206, 228);
            SetStyle(form);
        }

        private static void SetStyle(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                Type type = control.GetType();
                if (type.Assembly.FullName.StartsWith("Infragistics2.Win"))
                {
                    switch(type.Name)
                    {
                        case "UltraGrid":
                            (control as UltraGrid).DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.LightSkyBlue;
                            break;
                    }
                }
                SetStyle(control);
            }
        }
    }
}
