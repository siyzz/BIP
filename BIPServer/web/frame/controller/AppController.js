/**
 * 系统首页总控制中心
 */
Ext
		.define(
				'FRAME.controller.AppController',
				{
					extend : 'Ext.app.Controller',
					views : [ 'FRAME.view.CenterPanel',/* 功能区面板 */
					'FRAME.view.PMenuPanel',/* 系统级菜单展示区 */
					'FRAME.view.HeaderPanel',/* 顶部页头区，包含背景图片、系统提示以及退出、当前用户展示等信息 */
					'FRAME.view.LayerMenuPanel',/* 层叠菜单面板 */
					'FRAME.view.NavigationMenuPanel'/* 导航菜单区面板 */
					],
					refs : [ {
						ref : 'headerpanel',
						selector : 'headerpanel'
					}, {
						ref : 'pmenupanel',
						selector : 'pmenupanel'
					}, {
						ref : 'centerpanel',
						selector : 'centerpanel'
					}, {
						ref : 'navigationmenupanel',
						selector : 'navigationmenupanel'
					}, {
						ref : 'sysoperationwidget',
						selector : 'sysoperationwidget'
					}, {
						/* 中心面板，用于加载流程页面 */
						ref : 'centerpanel_panel_con',
						selector : 'panel[itemId=centerpanel_panel_con]'
					}, {
						/* 用于展示标题 */
						ref : 'centerpanel_label_name',
						selector : 'label[itemId=centerpanel_label_name]'
					}, {
						/* 切换列表展示 */
						ref : 'centerpanel_btn_grid',
						selector : 'button[itemId=centerpanel_btn_grid]'
					}, {
						/* 切换树形展示 */
						ref : 'centerpanel_btn_tree',
						selector : 'button[itemId=centerpanel_btn_tree]'
					} ],

					init : function() {
						this.control({
							'headerpanel' : {
								beforerender : this.pmenuload
							},
							'pmenupanel label' : {
								click : this.addMenuPanel
							},
							'pmenupanel label' : {
								click : this.addMenuPanel
							},
							'layermenupanel treepanel' : {
								itemclick : this.addTabPanel
							},
							'button[itemId=centerpanel_btn_grid]' : {
								click : this.gridShow
							},
							'button[itemId=centerpanel_btn_tree]' : {
								click : this.treeShow
							}
						});
					},
					pmenuload : function() {
						var me = this;
						Ext.Ajax.request({
							url : __ctxPath + "/menu/queryFuncByParams.do",
							async : false,
							params : {
								type : '1'
							},
							success : function(response, options) {
								var results = response.responseText;
								var records = Ext.decode(results);// 后台数据库查出的功能点
								// 获取层叠式面板
								// debugger;
								var pmenu = me.getPmenupanel();
								pmenu.addMenusLabel(records.result);
							}
						});

					},
					/**
					 * 添加对应的View到操作区域的TabPanel中(对应的是树形节点的选中处理事件，其中的id对应的是树节点的Id，text对应的是树节点的名称、同时也默认作为新添加的veiw的tab名，leaf为选中的节点是否是叶子节点)
					 * 
					 * @param {}
					 *            tree 选中的树对象
					 * @param {}
					 *            record 选中的树节点数据
					 */
					addTabPanel : function(tree, record) {
						var me = this;
						// 1. 获取中心面板
						// var centerpanel = me.getCenterpanel();
						var centerpanel = me.getCenterpanel_panel_con();
						var label = me.getCenterpanel_label_name();
						// 获取当前选中项的ID（由于展示采用树的默认展示，所以这里根据ID查找对应的页面路径、功能项权限）
						var menuid = record.get('id');
						var ctrlurl = record.raw.ctrlurl;// 获取菜单的节点对应的要加载的功能点的控制器
						var showname = record.raw.text;
						label.setText("  访问路径>>" + showname);
						var isLeaf = record.get('leaf') ? true : false;
						if (isLeaf) {
							// 2. 移除原有的面板
							centerpanel.removeAll(true);
							// 3. 加载新加入的面板
							var ctrl = App_all.getController(ctrlurl, {});
							var view = Ext.create(ctrl.views[0]);
							var gridpanels = view
									.queryBy(function(a) {
										return (a.xtype == 'gridpanel' || a.xtype == 'treepanel')
									}), grid;
							for ( var i = 0; i < gridpanels.length; i++) {
								grid = gridpanels[i];
								var gview = grid.getView();
								gview.addListener('cellcontextmenu', function(
										client, td, cellIndex, record, tr,
										rowIndex, e, eOpts) {
									var mm = Ext.create(
											'common.extutil.ContextMenuList', {
												// 传递参数
												record : record
											});
									// mm.clearManagedListeners();
									mm.addListener('mouseleave', function(menu,
											e, eOpts) {
										mm.close();
									});
									mm.showAt(e.getXY());
								});

							}
							centerpanel.add(view);
						}
					},
					/**
					 * 主要实现页面的准备，创建页面，配置相应的按钮
					 * 
					 * @param {}
					 *            viewname
					 * @param {}
					 *            viewConfg
					 * @param {}
					 *            respose
					 * @return {}
					 */
					readyView : function(viewname, viewConfg, respose) {
						view = Ext.create(viewname, viewConfg);
						return view;
					},
					gridShow : function() {
						var me = this;
						var centerpanel = me.getCenterpanel_panel_con();
						var panels = centerpanel
								.queryBy(function(a) {
									return (a.xtype == 'panel'
											&& a.layout != undefined && a.layout.$className == "Ext.layout.container.Card")
								});
						if (panels.length > 0) {
							var panel = panels[0];
							panel.getLayout().setActiveItem(1);
						} else {
							Ext.ux.Toast.msg("提示", "未查找到切换控件！")
						}
					},
					treeShow : function() {
						var me = this;
						var centerpanel = me.getCenterpanel_panel_con();
						var panels = centerpanel
								.queryBy(function(a) {
									return (a.xtype == 'panel'
											&& a.layout != undefined && a.layout.$className == "Ext.layout.container.Card")
								});
						if (panels.length > 0) {
							var panel = panels[0];
							panel.getLayout().setActiveItem(0);
						} else {
							Ext.ux.Toast.msg("提示", "未查找到切换控件！")
						}
					}
				});
