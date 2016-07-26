using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Forms;
using com.ccf.bip.framework.core;
using System.Data;
using System.Collections;
using com.ccf.bip.biz.system.user.mapper;

namespace com.ccf.bip.framework.form
{
    public class BipMetroForm : MetroForm
    {
        private BipAction action;

        public BipAction Action
        {
            get { return action; }
            set { action = value; }
        }

        private SysUser user;

        public SysUser User
        {
            get { return user; }
            set { user = value; }
        }

        public IEnumerable<T> Find<T>(string serviceName, string methodName, object[] args)
        {
            return (this.action.Excute(serviceName, methodName, args) as ArrayList).Cast<T>();
        }

        public IEnumerable<T> Find<T>(BipAction action, string serviceName, string methodName, object[] args)
        {
            return (action.Excute(serviceName, methodName, args) as ArrayList).Cast<T>();
        }

        public List<T> FindList<T>(string serviceName, string methodName, object[] args)
        {
            List<T> list = new List<T>();
            list.AddRange(this.Find<T>(serviceName, methodName, args));
            return list;
        }

        public List<T> FindList<T>(BipAction action, string serviceName, string methodName, object[] args)
        {
            List<T> list = new List<T>();
            list.AddRange(this.Find<T>(action, serviceName, methodName, args));
            return list;
        }

        public DataTable FindDataTable(string serviceName, string methodName, object[] args)
        {
            DataTable table = new DataTable();
            IEnumerable<Hashtable> enumrable = this.Find<Hashtable>(serviceName, methodName, args);
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
                        if (de.Value.GetType().Equals(typeof(Hashtable)))
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

        public T FindOne<T>(string serviceName, string methodName, object[] args)
        {
            return (T)this.action.Excute(serviceName, methodName, args);
        }

        public T FindOne<T>(string serviceName, string methodName, object[] args, bool updateSession)
        {
            return (T)this.action.Excute(serviceName, methodName, args, updateSession);
        }

        public T FindOne<T>(BipAction action, string serviceName, string methodName, object[] args)
        {
            return (T)action.Excute(serviceName, methodName, args);
        }

        public bool Update(string serviceName, string methodName, object[] args)
        {
            this.action.Excute(serviceName, methodName, args);
            return true;
        }
    }
}
