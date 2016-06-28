Ext.define('FRAME.ux.tree.PageTreeStore', {
	extend : 'Ext.data.TreeStore',
	autoLoad : true,
	/**
	 * 加载数据源的数据对象，是树结构的loader
	 * 
	 * @type Ext.tree.TreePagingLoader
	 */
	loader : null,
	/**
	 * 树的根节点，最顶的节点
	 * 
	 * @type Ext.tree.AsyncTreeNode
	 */
	rootNode : null,
	constructor : function(cfg) {
		var me = this;
		cfg = cfg || {};
		me.callParent( [ Ext.apply( {
			root : {
				expanded : true,
				text : "数据字典",
				expanded : false,
				draggable : false
			},
			defaultRootId : '',
			proxy : {
				type : 'ajax',
				url : __ctxPath + '/pub/getDictTreePubTreeAction.do',
				method : 'post',
				reader : {
					root : 'result',
					totalProperty : 'totalCounts'
				}
			}
		}, cfg) ]);
		me.loader = config.loader;
		me.rootNode = config.rootNode;
	},
	load : function(options) {
		var _self = this;
		if (!this.loader || !this.rootNode) {
			Ext.MessageBox.alert("错误", "必须指定loader或者rootNode");
			return false;
		}
		Ext.apply(this.loader.baseParams, {
			start : options.params.start,
			limit : options.params.limit
		}), this.loader.load(this.rootNode, function(node) {
			_self.currentCount = _self.loader.currentCount;
			_self.totalLength = _self.loader.totalCount;
			node.expand();
			_self.fireEvent("load", _self, null, options);
			delete _self;
		});
		return true;
	},
	getCount : function() {
		return this.currentCount || 0;
	},
	getTotalCount : function() {
		return this.totalLength || 0;
	}
});