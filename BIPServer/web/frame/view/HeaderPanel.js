/*
 *  系统前台主页头面板
 * 
 */
Ext
		.define(
				'FRAME.view.HeaderPanel',
				{
					extend : 'Ext.panel.Panel',
					alias : 'widget.headerpanel',
					frame : false,
					height : 50,
					itemId : 'HeaderPanel_itemId',
					maxHeight : 50,
					header : false,
					title : 'FahonMES 5.0',
					layout : {
						type : 'absolute'
					},
					initComponent : function() {
						var me = this;
								me.items = [
										{// 主页头（图片）
											xtype : 'image',
											itemId : 'NorthImg',
											style : {
												maggin : '0px 0px 0px 0px',
												padding : '0px 0px 0px 0px'
											},
											border : false,
											height : 34,
											width : '100%',
											height : '100%',
											x : 0,
											y : 0,
											flex : 1,
											margin : '0 0 0 0',
											src : __ctxPath
													+ '/frame/resource/images/frame/home/header_background.gif'
										// src : __ctxPath
										// +
										// '/frame/resource/images/frame/home/blueTip.jpg'
										},
										{
											xtype : 'container',
											width : '100%',
											height : '100%',
											itemId : 'headpanel_pmenu_con',
											id : 'headpanel_pmenu_con',
											x : 0,
											y : 0,
											layout : {
												type : 'hbox'
											},
											items : [
													{
														xtype : 'label',
														text : 'F6工厂管理平台',/* 应用名称（在config.js中配置） */
														// 主页的项目名称
														style : {
															'margin-top' : '15px',
															'margin-left' : '20px',
															'margin-right' : '70px',
															'font-size' : '22px',
															'font-family' : 'STXingkai',// 华文行楷
															'color' : '#ffffff'
														}
													},
													{
														xtype : 'pmenupanel'
													},
													{
														xtype : 'tbfill'
													},
													{
														xtype : 'button',
														width : 130,
														height : 30,
														text : '欢迎你，ADMIN',
														margin : '10 50 0 0',
														iconCls : 'currentUser',
														menu : [
																{
																	iconCls : 'userSet',
																	text : '设置'
																},
																{
																	iconCls : 'help',
																	text : '帮助'
																},
																{
																	iconCls : 'exit',
																	text : '退出',
																	handler : function() {
																		Ext.Msg
																				.confirm(
																						"退出确认",
																						"确认退出系统？",
																						function(
																								c) {
																							if (c == "yes") {
																								Ext.Ajax
																										.request({
																											url : __ctxPath
																													+ "/login/logout.do",
																											success : function() {
																												window.location.href = __ctxPath;
																											}
																										});
																							}
																						});
																	}
																} ]
													} ]
										} ], me.callParent(arguments);
					}

				});