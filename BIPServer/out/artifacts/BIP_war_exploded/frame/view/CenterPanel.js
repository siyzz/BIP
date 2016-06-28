/**
 * 系统前台主页功能区面板，用于展示功能主页，初始加载，点击左侧菜单栏后刷新（将上一个页面销毁，加载新的页面）
 * 
 */
Ext.define('FRAME.view.CenterPanel', {
	extend : 'Ext.panel.Panel',
	alias : 'widget.centerpanel',
	itemId : 'CenterPanel_itemId',
	frameHeader : false,
	border : false,
	bodyPadding : 0,
	layout : {
		type : 'vbox',
		align : 'stretch'
	},
	initComponent : function() {
		var me = this;
		Ext.applyIf(me, {
			items : [ {
				xtype : 'toolbar',
				height : 35,
				layout : {
					type : 'hbox',
					align : 'middle'
				},
				items : [ {
					xtype : 'label',
					itemId : 'centerpanel_label_name'
				}, {
					xtype : 'tbfill'
				}, {
					xtype : 'button',
					text : '列表展示',
					itemId : 'centerpanel_btn_grid'
				}, {
					xtype : 'button',
					text : '树形展示',
					margins : {
						right : 50
					},
					itemId : 'centerpanel_btn_tree'
				} ]
			}, {
				xtype : 'panel',
				flex : 1,
				border : false,
				layout : 'fit',
				itemId : 'centerpanel_panel_con'
			} ]
		});
		me.callParent(arguments);
	}
});