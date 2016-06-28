/*
 * 
 */
Ext.define('FRAME.view.Viewport', {
			extend : 'Ext.container.Viewport',
			requires : ['FRAME.view.HeaderPanel',
					'FRAME.view.NavigationMenuPanel',
					'FRAME.view.CenterPanel'],
			layout : 'border',
			itemId : 'fhviewportItemId',
			items : [{
						xtype : 'headerpanel',
						region : 'north',
						height : 300
					}, {
						xtype : 'container',
						region : 'center',
						itemId : 'fhmiddleItemId',
						layout : {
							type : 'border'
						},
						flex : 1,
						padding : '0 5 0 5',
						items : [{
									xtype : 'centerpanel',
									flex : 1,
									region : 'center'
								}, {
									xtype : 'navigationmenupanel',
									collapsed : false,
									width : 200,
									border : false,
									maxWidth : 200,
									region : 'west',
									split : true
								}]
					}]
		});
