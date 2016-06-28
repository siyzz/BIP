/*
 * 系统前台层叠菜单导航栏面板
 * 
 */
Ext.define('FRAME.view.LayerMenuPanel', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.layermenupanel',
    itemId: 'LayerMenu_itemId',
    id: 'LayerMenu_itemId',
    layout: {
        type: 'accordion'
    },
//    title: '层叠菜单',
    initComponent: function() {
        var me = this;
        Ext.applyIf(me, {
            items: []
        });

        me.callParent(arguments);
    },
    /*动态添加菜单组面板组*/
    addMenusPanel:function(records){
    	var me = this;
    	me.removeAll();
    	var lenght=records?records.length:0;
    	for ( var i = 0; i < records.length; i++) {
    		me.createChildMenuPanel(records[i])
    	}
    },
    /*动态添加单个菜单组面板组*/
    createChildMenuPanel:function(record){
    	 var me = this;
    	 var childstore = Ext.create('Ext.data.TreeStore', {
				root : {
					expanded : true,
					children : record.children?record.children:[]
				}
			});
    	 var childpanel = Ext.create('Ext.tree.Panel', {
				store : childstore,
				iconCls:record.sysFuncicon,
				title:record.sysFuncname,
				layout : {
					type : 'fit'
				},
				flex : 1,
				border : false,
				loadMask : true,
				autoScroll : true,
				useArrows : true,
				rootVisible : false
			});
    	 me.add(childpanel);
    }

});