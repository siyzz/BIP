using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.util;
using com.ccf.bip.framework.form;

namespace com.ccf.bip.frame
{
    public partial class FormTest : BipForm
    {
        public FormTest()
        {
            InitializeComponent();
            this.AllowClose = false;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            //
            Image img = Image.FromFile("./resource/image/mainMenuIcon.jpg");
            int width = 48, height = 48, startX = 40, startY = 50, distanceX = 14, distanceY = 14;
            int index = 1;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    PictureBox pic = this.GetType().GetField("pictureBox" + index.ToString(),
                     System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                     | System.Reflection.BindingFlags.IgnoreCase).GetValue(this) as PictureBox;

                    pic.Image = ImageUtil.GetPart(img, 0, 0, width, height, startX + (j*(distanceX+width)), startY + (i*(distanceY+height)));

                    index++;
                }
            }
            //pictureBox1.Image = ImageUtil.GetPart(img, 0, 0, 48, 48, 40, 50);
        }
    }
}
