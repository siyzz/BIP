/*
 * 系统前台框架的app入口
 */
Ext.application({
	name : 'FRAME',// 框架应用的名称
	paths : {
		'js' : '../js'// 指定命名空间
	},
	// user : Ext.decode("{}"),
	autoCreateViewport : true,// 自动创建ViewPort
	controllers : [ 'FRAME.controller.AppController'// 前台框架的主控制器
	],
	launch : function() {
		Ext.BLANK_IMAGE_URL = __ctxPath + "/images/default/s.gif";
		 App_all = this;
		 CopyContent="";
		 App_all.controllers.addListener('add',
		 this.newControllerAdded, this);
	},
	newControllerAdded : function(idx, ctrlr, token) {
		if (!ctrlr) {
			ctrlr.init();
		}
	}
});
