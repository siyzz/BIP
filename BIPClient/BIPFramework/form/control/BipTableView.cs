using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace com.ccf.bip.framework.form.control
{
    public partial class BipTableView : UserControl
    {
        public List<BipRow> Rows = new List<BipRow>();        
        private BipRow activeRow = null;
        public BipRow ActiveRow
        {
            get { return activeRow; }
            set 
            { 
                activeRow = value;
                if(value != null)
                    value.BackColor = Color.LightBlue;
            }
        }


        public new int Height
        {
            get
            {
                int h = 0;
                foreach (BipRow row in Rows)
                {
                    h += row.Height;
                }
                return h;
            }
        }

        public BipTableView()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;          
        }        

        public void AddRow(BipRow row)
        {
            row.Left = 0;
            row.Top = this.Height;
            row.Click += new EventHandler(row_Click);
            this.Controls.Add(row);
            Rows.Add(row);
        }

        void row_Click(object sender, EventArgs e)
        {
            if (ActiveRow != null)
                ActiveRow.BackColor = Color.Transparent;
            ActiveRow = sender as BipRow;
        }

        public void Clear()
        {            
            Rows.Clear();
            this.Controls.Clear();
        }
    }

    public class BipRow : Panel
    {
        public new EventHandler Click = null;
        public List<BipCell> Cells = new List<BipCell>();

        public new int Width 
        {
            get
            {
                int w = 0;
                if (Cells != null)
                {
                    foreach (BipCell c in Cells)
                    {
                        w += c.Width;
                    }
                }
                return w;
            }
        }
        public new int Height 
        {
            get 
            {
                return base.Height;
            }

            set
            {
                base.Height = value;
                if (Cells != null)
                {
                    for (int i = 0; i < Cells.Count(); i++)
                    {
                        Cells[i].Height = value;
                    }
                }
            }
        }

        private bool isHeader;

        public bool IsHeader
        {
            get { return isHeader; }
            set { isHeader = value; }
        }

        public BipRow()
        {
            this.BackColor = Color.Transparent;
            this.Height = 30;
        }

        public void Add(BipCell cell)
        {
            cell.Top = 0;
            cell.Left = this.Width;
            cell.Height = this.Height;
            if (this.isHeader)
            {
                //cell.TextAlign = ContentAlignment.MiddleCenter;
                cell.Font = new Font(cell.Font,FontStyle.Bold);
            }
            else
            {
                cell.Click += new EventHandler(cell_Click);
            }
            this.Controls.Add(cell);
            base.Width = this.Width + cell.Width;
            Cells.Add(cell);            
        }

        void cell_Click(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, EventArgs.Empty);
            }
        }
    }

    public class BipCell : Label
    {
        public BipCell()
        {
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.None;
            this.AutoSize = false;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Width = 80;
        }
    }
}
