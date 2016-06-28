/*
 * 
 */
Ext.define('FRAME.view.NavigationMenuPanel', {
	extend : 'Ext.panel.Panel',
	alias : 'widget.navigationmenupanel',

	itemId : 'NavigationMenu_itemId',
	layout : {
		type : 'fit'
	},
	collapsible : true,
	title : '导航菜单',
	initComponent : function() {
		var me = this;
		Ext.applyIf(me, {
			items : [ {
				xtype : 'layermenupanel'
			} ]
		});
		me.callParent(arguments);
	}
});