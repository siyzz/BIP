using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.ccf.bip.framework.core;
using com.ccf.bip.biz.system.user.mapper;
using Infragistics.Win.UltraWinToolbars;
using com.ccf.bip.biz.system.authorization.mapper;
using System.Data;

namespace com.ccf.bip.framework.form
{
    public class BipForm : Form
    {
        private string id = "";        
        private BipAction action;
        private SysUser user;
        private string customInformation = "";        
        private bool allowClose = true;
        private List<SysFunction> toolbarButtonList;        
        private UltraToolbarsManager toolbar;        

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool AllowClose
        {
            get { return allowClose; }
            set { allowClose = value; }
        }

        public BipAction Action
        {
            get { return action; }
            set { action = value; }
        }

        public SysUser User
        {
            get { return user; }
            set { user = value; }
        }

        public string CustomInformation
        {
            get { return customInformation; }
            set { customInformation = value; }
        }

        public List<SysFunction> ToolbarButtonList
        {
            get { return toolbarButtonList; }
            set { toolbarButtonList = value; }
        }

        public UltraToolbarsManager Toolbar
        {
            get { return toolbar; }
            set { toolbar = value; }
        }

        public IEnumerable<T> Find<T>(string serviceName, String methodName, object[] args)
        {
            return (action.Excute(serviceName, methodName, args) as ArrayList).Cast<T>();
        }

        public List<T> FindList<T>(string serviceName, String methodName, object[] args)
        {
            List<T> list = new List<T>();
            list.AddRange(this.Find<T>(serviceName, methodName, args));
            return list;
        }

        public DataTable FindDataTable(string serviceName, String methodName, object[] args)
        {
            DataTable table = new DataTable();
            IEnumerable<Hashtable> enumrable = this.Find<Hashtable>(serviceName,methodName,args);
            IEnumerator<Hashtable> enumrator = enumrable.GetEnumerator();
            if (enumrator.MoveNext())
            {
                Hashtable ht = enumrator.Current;
                string colName;
                Type colType;
                foreach (DictionaryEntry de in ht)
                {
                    colName = de.Key.ToString();
                    if (de.Value == null)
                        colType = typeof(String);
                    else
                        if(de.Value.GetType().Equals(typeof(Hashtable)))
                            colType = (de.Value as Hashtable)["value"].GetType();
                        else
                            colType = de.Value.GetType();
                    table.Columns.Add(colName, colType);
                }

                do
                {
                    ht = enumrator.Current;
                    object[] values = new object[ht.Keys.Count];
                    int i = 0;
                    foreach (DictionaryEntry de in ht)
                    {
                        if (de.Value != null && de.Value.GetType().Equals(typeof(Hashtable)))
                        {
                            values[i++] = (de.Value as Hashtable)["value"];
                            continue;
                        }
                        values[i++] = de.Value;
                    }
                    table.Rows.Add(values);
                }
                while (enumrator.MoveNext());
            }
            return table;
        }

        public T FindOne<T>(string serviceName, String methodName, object[] args)
        {
            return (T)action.Excute(serviceName, methodName, args);
        }

        public bool Update(string serviceName, String methodName, object[] args)
        {
            action.Excute(serviceName, methodName, args);
            return true;
        }

        /// <summary>
        /// 重写此方法获取界面功能按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="key"></param>
        public virtual void ToolClick(object sender,ToolClickEventArgs e){}
    }
}
