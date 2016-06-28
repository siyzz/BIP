Ext.define('Ext.ux.LiverSearcher', {
    alias: 'plugin.liversearcher',

    requires: [
               'Ext.toolbar.TextItem',
               'Ext.form.field.Checkbox',
               'Ext.form.field.Text',
               'Ext.ux.statusbar.StatusBar'
           ],
           grid:null,
           searchValue: null,
           
           /**
            * @private
            * The row indexes where matching strings are found. (used by previous and next buttons)
            */
           indexes: [],
           
           /**
            * @private
            * The row index of the first search, it could change if next or previous buttons are used.
            */
           currentIndex: null,
           
           /**
            * @private
            * The generated regular expression used for searching.
            */
           searchRegExp: null,
           
           /**
            * @private
            * Case sensitive mode.
            */
           caseSensitive: false,
           
           /**
            * @private
            * Regular expression mode.
            */
           regExpMode: false,
           
           /**
            * @cfg {String} matchCls
            * The matched string css classe.
            */
           matchCls: 'x-livesearch-match',
           
           defaultStatusText: '没有查询的信息',
    //public

    init : function(grid){
        this.grid = grid;
        grid.tbar = ['Search',{
            xtype: 'textfield',
            name: 'searchField',
            hideLabel: true,
            width: 200,
            listeners: {
                change: {
                    fn: me.onTextFieldChange,
                    scope: this,
                    buffer: 100
                }
            }
       }, {
           xtype: 'button',
           text: '&lt;',
           tooltip: '前一行',
           handler: me.onPreviousClick,
           scope: me
       },{
           xtype: 'button',
           text: '&gt;',
           tooltip: '下一行',
           handler: me.onNextClick,
           scope: me
       }, '-', {
           xtype: 'checkbox',
           hideLabel: true,
           margin: '0 0 0 4px',
           handler: me.regExpToggle,
           scope: me                
       }, 'Regular expression', {
           xtype: 'checkbox',
           hideLabel: true,
           margin: '0 0 0 4px',
           handler: me.caseSensitiveToggle,
           scope: me
       }, 'Case sensitive'];

   grid.bbar = Ext.create('Ext.ux.StatusBar', {
       defaultText: me.defaultStatusText,
       name: 'searchStatusBar'
   });
        this.mon(this.grid, {
            scope: this,
            afterlayout: this.onAfterLayout,
            single: true
        });
    },

    onAfterLayout: function() {
        this.mon(this.tabBar.el, {
            scope: this,
            contextmenu: this.onContextMenu,
            delegate: 'div.x-tab'
        });
    },

    onBeforeDestroy : function(){
        Ext.destroy(this.menu);
        this.callParent(arguments);
    }
});