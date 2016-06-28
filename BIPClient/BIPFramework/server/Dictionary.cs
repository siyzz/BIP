using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.ccf.bip.framework.core;
using System.Diagnostics;
using com.ccf.bip.biz.metadata.dictionary.mapper;
using System.Collections;

namespace com.ccf.bip.framework.server
{
    /// <summary>
    /// 系统数据字典数据访问类
    /// </summary>
    public class Dictionary
    {
        public const string SERVICE_NAME = "com.ccf.bip.biz.metadata.dictionary.service.DictionaryService";
        public const string METHOD_NAME = "findByParentCode";
        private BipAction action = null;

        public BipAction Action
        {
            get { return action; }
            set { action = value; }
        }

        public Dictionary(BipAction action)
        {
            this.action = action;
        }

        /// <summary>
        /// 获取组织机构类型
        /// </summary>
        /// <returns></returns>
        public List<SysDictionary> GetOrganizationType()
        {
            return GetDictionaryList(DictionaryType.Organization);
        }

        private List<SysDictionary> GetDictionaryList(DictionaryType type)
        {
            List<SysDictionary> list = new List<SysDictionary>();
            list.AddRange((action.Excute(SERVICE_NAME, METHOD_NAME, new object[] { ((int)type).ToString()}) as ArrayList).Cast<SysDictionary>());
            return list;
        }
    }
}
