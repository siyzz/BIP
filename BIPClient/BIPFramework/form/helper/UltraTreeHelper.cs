using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;
using com.ccf.bip.biz.system.authorization.mapper;
using com.ccf.bip.biz.metadata.org.mapper;
using System.Drawing;
using com.ccf.bip.framework.core;

namespace com.ccf.bip.framework.form.helper
{
    public class UltraTreeHelper
    {
        /// <summary>
        /// 功能菜单树节点赋值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        /// <param name="expandFunctionType"></param>
        public static void FillData(List<SysFunction> list, UltraTree tree, string expandFunctionType)
        {
            UltraTreeNode node = null;
            TreeNodesCollection nodes = tree.Nodes;
            nodes.Clear();
            //获取根节点（代表系统）
            List<SysFunction> sysFunctions = list.FindAll(f => string.IsNullOrEmpty(f.ParentId));
            foreach (SysFunction sysFun in sysFunctions)
            {
                node = new UltraTreeNode();
                node.Key = sysFun.FunctionId;
                node.Text = sysFun.FunctionName;
                node.Tag = sysFun;
                if (String.Compare(expandFunctionType, sysFun.FunctionType) > 0)
                    node.Expanded = true;
                if (!String.IsNullOrEmpty(sysFun.Image))
                {
                    node.LeftImages.Add(Image.FromFile("./resource/image/mainMenu/" + sysFun.Image + ".png"));
                }
                nodes.Add(node);

                FillData(list, node, expandFunctionType);
            }
        }
        /// <summary>
        /// 组织结构树节点赋值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        /// <param name="expandFunctionType"></param>
        public static void FillData(List<SysOrganization> list, UltraTree tree, string expandOrgType,bool showIcon)
        {
            FillData(list, tree.Nodes, expandOrgType, showIcon);
        }
        /// <summary>
        /// 组织结构树节点赋值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        /// <param name="expandFunctionType"></param>
        public static void FillData(List<SysOrganization> list, TreeNodesCollection nodes, string expandOrgType, bool showIcon)
        {
            UltraTreeNode node = null;
            nodes.Clear();

            //获取最高组织节点
            List<SysOrganization> orgList = list.FindAll(o => string.IsNullOrEmpty(o.ParentId));
            foreach (SysOrganization org in orgList)
            {
                node = new UltraTreeNode();
                node.Key = org.OrganizationId;
                node.Text = GetOrgTreeNodeText(org);
                node.Tag = org;
                if (String.Compare(expandOrgType, org.OrganizationType) > 0)
                    node.Expanded = true;
                if (showIcon)
                    node.LeftImages.Add(GetImage(org.OrganizationType));
                nodes.Add(node);

                FillData(list, node, expandOrgType, showIcon);
            }
        }
        /// <summary>
        /// 角色树节点赋值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        /// <param name="expandFunctionType"></param>
        public static void FillData(List<SysRole> list, UltraTree tree)
        {
            UltraTreeNode node = null;
            TreeNodesCollection nodes = tree.Nodes;
            nodes.Clear();

            List<SysRole> roleList = list.FindAll(o => string.IsNullOrEmpty(o.ParentId));
            foreach (SysRole role in roleList)
            {
                node = new UltraTreeNode();
                node.Key = role.RoleId;
                node.Text = role.RoleName;
                node.Tag = role;
                nodes.Add(node);

                FillData(list, node);
            }
        }
        /// <summary>
        /// 单树节点克隆
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        /// <param name="expandFunctionType"></param>
        public static UltraTreeNode SingleClone(UltraTreeNode node)
        {
            UltraTreeNode newNode = new UltraTreeNode(node.Key);
            newNode.Tag = node.Tag;
            newNode.Text = node.Text;
            if(node.LeftImages.Count > 0)
                newNode.LeftImages.Add(node.LeftImages[0]);
            return newNode;
        }
        /// <summary>
        /// 查找根节点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        /// <param name="expandFunctionType"></param>
        public static UltraTreeNode FindTop(UltraTreeNode node)
        {
            UltraTreeNode n = node;
            while (n.Parent != null)
            {
                n = n.Parent;
            }
            return n;
        }
        
        private static void FillData(List<SysFunction> list, UltraTreeNode node, String expandFunctionType)
        {
            UltraTreeNode subNode = null;
            List<SysFunction> funs = list.FindAll(f => f.ParentId != null && f.ParentId.Equals(node.Key));
            foreach (SysFunction fun in funs)
            {
                subNode = new UltraTreeNode();
                subNode.Key = fun.FunctionId;
                subNode.Text = fun.FunctionName;
                subNode.Tag = fun;
                if (String.Compare(expandFunctionType, fun.FunctionType) > 0)
                    subNode.Expanded = true;
                if (!String.IsNullOrEmpty(fun.Image))
                {
                    subNode.LeftImages.Add(Image.FromFile("./resource/image/" + (fun.FunctionType.Equals("1015") ? "button" : "mainMenu") + "/" + fun.Image + ".png"));
                    //subNode.LeftImages.Add(Image.FromFile("./resource/image/mainMenu/" + fun.Image + ".png"));
                }
                node.Nodes.Add(subNode);

                FillData(list, subNode, expandFunctionType);
            }
        }

        private static void FillData(List<SysOrganization> list, UltraTreeNode node, string expandOrgType,bool showIcon)
        {
            UltraTreeNode subNode = null;
            List<SysOrganization> orgList = list.FindAll(o => !string.IsNullOrEmpty(o.ParentId) && o.ParentId.Equals(node.Key));
            foreach (SysOrganization org in orgList)
            {
                subNode = new UltraTreeNode();
                subNode.Key = org.OrganizationId;
                subNode.Text = GetOrgTreeNodeText(org);
                subNode.Tag = org;
                if (String.Compare(expandOrgType, org.OrganizationType) > 0)
                    subNode.Expanded = true;
                if(showIcon)
                subNode.LeftImages.Add(GetImage(org.OrganizationType));
                node.Nodes.Add(subNode);

                FillData(list, subNode, expandOrgType, showIcon);
            }
        }

        private static void FillData(List<SysRole> list, UltraTreeNode node)
        {
            UltraTreeNode subNode = null;
            List<SysRole> roleList = list.FindAll(r => !string.IsNullOrEmpty(r.ParentId) && r.ParentId.Equals(node.Key));
            foreach (SysRole role in roleList)
            {
                subNode = new UltraTreeNode();
                subNode.Key = role.RoleId;
                subNode.Text = role.RoleName;
                subNode.Tag = role;
                node.Nodes.Add(subNode);

                FillData(list, subNode);
            }
        }
                
        private static string GetOrgTreeNodeText(SysOrganization org)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(org.OrganizationCode))
            {
                sb.Append("[");
                sb.Append(org.OrganizationCode);
                sb.Append("]");
            }
            sb.Append(org.OrganizationName);

            return sb.ToString();
        }

        private static Image GetImage(string orgType)
        {
            string path = "\\resource\\image\\mainMenu\\";
            switch (orgType)
            {
                case "1001":
                    path += "group.png";
                    break;
                case "1002":
                    path += "company.png";
                    break;
                case "1003":
                    path += "department.png";
                    break;
                case "1004":
                    path += "section.png";
                    break;
                default:
                    path += "directory.png";
                    break;
            }
            return Image.FromFile(Globals.AppPath + path);
        }
    }
}
