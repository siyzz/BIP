using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Security.Permissions;

namespace com.ccf.bip.frame.style
{
    public abstract class SkinFormRenderer
    {
        #region Fields

        private EventHandlerList _events;

        private static readonly object EventRenderSkinFormCaption = new object();
        private static readonly object EventRenderSkinFormBorder = new object();
        private static readonly object EventRenderSkinFormBackground = new object();
        private static readonly object EventRenderSkinFormControlBox = new object();

        #endregion

        #region Constructors

        protected SkinFormRenderer()
        {
        }

        #endregion

        #region Properties

        protected EventHandlerList Events
        {
            get
            {
                if (_events == null)
                {
                    _events = new EventHandlerList();
                }
                return _events;
            }
        }

        #endregion

        #region Events

        public event SkinFormCaptionRenderEventHandler RenderSkinFormCaption
        {
            add { AddHandler(EventRenderSkinFormCaption, value); }
            remove { RemoveHandler(EventRenderSkinFormCaption, value); }
        }

        public event SkinFormBorderRenderEventHandler RenderSkinFormBorder
        {
            add { AddHandler(EventRenderSkinFormBorder, value); }
            remove { RemoveHandler(EventRenderSkinFormBorder, value); }
        }

        public event SkinFormBackgroundRenderEventHandler RenderSkinFormBackground
        {
            add { AddHandler(EventRenderSkinFormBackground, value); }
            remove { RemoveHandler(EventRenderSkinFormBackground, value); }
        }

        public event SkinFormControlBoxRenderEventHandler RenderSkinFormControlBox
        {
            add { AddHandler(EventRenderSkinFormControlBox, value); }
            remove { RemoveHandler(EventRenderSkinFormControlBox, value); }
        }

        #endregion

        #region Public Methods
       // 创建一个Region，提供给SkinForm使用
        public abstract Region CreateRegion(SkinForm form);

        public abstract void InitSkinForm(SkinForm  form);

       // 绘制窗体标题栏(标题图片及文字)
        public void DrawSkinFormCaption(
            SkinFormCaptionRenderEventArgs e)
        {
            OnRenderSkinFormCaption(e);
            SkinFormCaptionRenderEventHandler handle =
                Events[EventRenderSkinFormCaption]
                as SkinFormCaptionRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }

        //绘制窗体边框
        public void DrawSkinFormBorder(
            SkinFormBorderRenderEventArgs e)
        {
            OnRenderSkinFormBorder(e);
            SkinFormBorderRenderEventHandler handle =
                Events[EventRenderSkinFormBorder]
                as SkinFormBorderRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }

        //绘制窗体背景
        public void DrawSkinFormBackground(
            SkinFormBackgroundRenderEventArgs e)
        {
            OnRenderSkinFormBackground(e);
            SkinFormBackgroundRenderEventHandler handle =
                Events[EventRenderSkinFormBackground]
                as SkinFormBackgroundRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }
        //绘制窗体控制按钮
        public void DrawSkinFormControlBox(
            SkinFormControlBoxRenderEventArgs e)
        {
            OnRenderSkinFormControlBox(e);
            SkinFormControlBoxRenderEventHandler handle =
                Events[EventRenderSkinFormControlBox]
                as SkinFormControlBoxRenderEventHandler;
            if (handle != null)
            {
                handle(this, e);
            }
        }

        #endregion

        #region Protected Render Methods
        // 绘制窗体标题栏
        protected abstract void OnRenderSkinFormCaption(
            SkinFormCaptionRenderEventArgs e);
        //绘制窗体边框
        protected abstract void OnRenderSkinFormBorder(
            SkinFormBorderRenderEventArgs e);
        //绘制窗体背景
        protected abstract void OnRenderSkinFormBackground(
            SkinFormBackgroundRenderEventArgs e);
        //绘制窗体控制按钮
        protected abstract void OnRenderSkinFormControlBox(
            SkinFormControlBoxRenderEventArgs e);

        #endregion

        #region Protected Methods

        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        protected void AddHandler(object key, Delegate value)
        {
            Events.AddHandler(key, value);
        }

        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        protected void RemoveHandler(object key, Delegate value)
        {
            Events.RemoveHandler(key, value);
        }

        #endregion
    }
}
