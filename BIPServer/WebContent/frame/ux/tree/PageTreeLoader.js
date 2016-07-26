Ext.define('FRAME.ux.tree.PageTreeLoader', {
	extend : 'Ext.tree.TreeLoader',

	processResponse : function(response, node, callback, scope) {
		var json = response.responseText;
		try {
			var o = response.responseData || Ext.decode(json);
			// TODO:暂时从后台获取当前页的记录数，通过currentCount属性获取
	// 最佳做法是效仿pagingToolbar的做法，在客户端获取
	// 目前的障碍是，loader还没读取完，翻页的工具栏已经初始化了，导致当前页记录数无法获取
	// 有空再继续修改，思路是把loader当store来用
	this.totalCount = o.totalCount;
	this.currentCount = o.data.length;
	var o = o.data;
	node.beginUpdate();
	for ( var i = 0, len = o.length; i < len; i++) {
		var n = this.createNode(o[i]);
		if (n) {
			node.appendChild(n);
		}
	}
	node.endUpdate();
	this.runCallback(callback, scope || node, [ node ]);
} catch (e) {
	this.handleFailure(response);
}
}

});