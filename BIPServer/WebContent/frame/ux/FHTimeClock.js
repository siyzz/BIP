/**
 * LiuSQ 日期时钟控件(同时可以用作距固定时间点的计时器)
 */
Ext.define('FRAME.ux.FHTimeClock', {
	extend : 'Ext.toolbar.TextItem',

	alias : 'widget.fhtimeclock',
	timeStep : 1000,// 默认更新时间频率（毫秒）
	html : '&#160;',
	textDec : null,// 默认前面描述问题为null;
	dateTimePoint : null,// 不为空时，为距次时间点的时长
	timeFormat : "Y年m月d日 A <br> G:i:s 星期l",// 默认时间格式样式
	clockFormat : 'H:i:s',// 默认计时器的时间格式
	tpl : '{time}',
	/* 初始化控件 */
	initComponent : function() {
		var me = this;

		me.callParent();
		if (typeof (me.tpl) == 'string') {
			me.tpl = new Ext.XTemplate(me.tpl);
		}
	},
	/**/
	afterRender : function() {
		var me = this;
		Ext.Function.defer(me.updateTime, 1, me);
		me.callParent();
	},
	/* 销毁时间控件 */
	onDestroy : function() {
		var me = this;

		if (me.timer) {
			window.clearTimeout(me.timer);
			me.timer = null;
		}

		me.callParent();
	},
	/* 更新时间控件的值 */
	updateTime : function() {
		var me = this, time;
		if (me.dateTimePoint != null) {// && me.dateTimePoint.isDate()
			var miSecond = (new Date() - me.dateTimePoint);
			miSecond = miSecond > 0 ? miSecond : -miSecond;
			time = me.updateTimeFormBeginTime(miSecond)
		} else {
			time = Ext.Date.format(new Date(), me.timeFormat);
		}
		text = me.tpl.apply({
			time : time
		});
		if (me.textDec != null) {
			text = me.textDec + text;
		}
		if (me.lastText != text) {
			me.setText(text);
			me.lastText = text;
		}
		me.timer = Ext.Function.defer(me.updateTime, 1000, me);
	},
	/* 到某个指定时间点的时长 */
	updateTimeFormBeginTime : function(miSecond) {
		var me = this;
		var date = parseInt(miSecond / 1000 / 60 / 60 / 24);
		var hour = parseInt(miSecond / 1000 / 60 / 60 % 24);
		var min = parseInt(miSecond / 1000 / 60 % 60);
		var sec = parseInt(miSecond / 1000 % 60);
		var ms = parseInt(miSecond % 1000);
		var date = new Date();
		date.setHours(hour, min, sec, ms);
		time = Ext.Date.format(date, me.clockFormat);
		return time;
	}
});
