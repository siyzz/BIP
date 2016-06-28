/*
 * 系统前台层叠菜单导航栏面板
 * 
 */
Ext
		.define(
				'FRAME.view.PMenuPanel',
				{
					extend : 'Ext.container.Container',
					alias : 'widget.pmenupanel',
					itemId : 'PMenu_itemId',
					layout : {
						type : 'hbox'
					},
					initComponent : function() {
						var me = this;
						Ext.applyIf(me, {
							items : []
						});

						me.callParent(arguments);
					},
					/* 动态添加菜单组面板组 */
					addMenusLabel : function(records) {
						var me = this;
						var lenght = records ? records.length : 0;
						for ( var i = 0; i < records.length; i++) {
							var label = Ext
									.create(
											'Ext.form.Label',
											{
												text : records[i].sysFunccode,// 显示在上排的属性名
												overCls : 'label-mouseon',
												// componentCls:'sys16x16',
												data : records[i],// 将数据缓存至data属性中
												style : {
													'margin-top' : '20px',
													'margin-left' : '15px',
													'margin-right' : '15px',
													'font-size' : '18px',
													'font-family' : 'STFangsong',// 华文仿宋
													'font-style' : 'italic',
													'color' : '#ffffff'
												},
												listeners : {
													render : function(e, f, g) {
														var me = this;
														Ext
																.fly(this.el)
																.on(
																		'click',
																		function(
																				a,
																				b,
																				c) {
																			Ext.Ajax
																					.request({
																						url : __ctxPath
																								+ "/menu/queryFuncForSysMenu.do",
																						async : false,
																						params : {
																							pid : me.data.sysFuncid
																						},
																						success : function(
																								response,
																								options) {
																							var results = response.responseText;
																							var records = Ext
																									.decode(results);// 后台数据库查出的功能点
																							// 获取层叠式面板
																							var Layermenupanel = Ext
																									.getCmp("LayerMenu_itemId");
																							Layermenupanel
																									.addMenusPanel(records.result);
																						}
																					});
																		});
													}
												}
											});
							me.add(label);
						}
					}
				});