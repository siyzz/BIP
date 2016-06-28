Ext.define('FRAME.ux.Clock', {
	extend : 'Ext.toolbar.TextItem',
	alias : 'widget.clock',
	timeStep : 1000,// 默认更新时间频率（毫秒）
	timeFormat : "Y年m月d日 A G:i:s 星期l",// 默认时间格式样式
	initComponent : function() {
		var me = this;
		me.initClock();
		me.callParent();
	},

	initClock : function() {
		if (this.clockTask) {
			Ext.TaskManager.stop(this.clockTask);
		}
		this.clockTask = Ext.TaskManager.start({
			run : function() {
				text = Ext.Date.format(new Date(), me.timeFormat);
				me.setText(text);
			},
			scope : this,
			interval : this.timeStep
		});

	}

})