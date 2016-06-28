using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.ccf.bip.biz.metadata.dictionary.mapper
{
    [Serializable]
    public class SysDictionary
    {
        private string dictionaryId;

        public string DictionaryId
        {
            get { return dictionaryId; }
            set { dictionaryId = value; }
        }

        private string parentId;

        public string ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private string dictionaryCode;

        public string DictionaryCode
        {
            get { return dictionaryCode; }
            set { dictionaryCode = value; }
        }

        private string dictionaryName;

        public string DictionaryName
        {
            get { return dictionaryName; }
            set { dictionaryName = value; }
        }

        private string dictionaryValue;

        public string DictionaryValue
        {
            get { return dictionaryValue; }
            set { dictionaryValue = value; }
        }

        private string valid;

        public string Valid
        {
            get { return valid; }
            set { valid = value; }
        }

        private string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
