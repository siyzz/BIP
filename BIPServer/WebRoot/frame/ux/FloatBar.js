Ext.define('FRAME.ux.FloatBar', {
    extend: 'Ext.toolbar.Toolbar',
    alias: 'widget.floatbar',

    border: true,
    floating: true,
    rtl: false,
    width: 400,
    fixed: true,
 draggable: {
                    constrain: true
                },
    initComponent: function() {
        var me = this;
    me.items= [{
                    xtype: 'combo',
                    rtl: false,
                    width: 170,
                    labelWidth: 45,
                    fieldLabel: 'Theme',
                    displayField: 'name',
                    valueField: 'value',
                    labelStyle: 'cursor:move;',
                    margin: '0 5 0 0',
                    store: Ext.create('Ext.data.Store', {
                        fields: ['value', 'name'],
                        data : [
                            { value: 'access', name: 'Accessibility' },
                            { value: 'classic', name: 'Classic' },
                            { value: 'gray', name: 'Gray' },
                            { value: 'neptune', name: 'Neptune' }
                        ]
                    }),
//                    value: theme,
                    listeners: {
//                        select: function(combo) {
//                            var theme = combo.getValue();
//                            if (theme !== defaultTheme) {
//                                setParam({ theme: theme });
//                            } else {
//                                removeParam('theme');
//                            }
//                        }
                    }
                }, {
                    xtype: 'button',
                    rtl: false,
//                    hidden: !(Ext.repoDevMode || location.href.indexOf('qa.sencha.com') !== -1),
//                    enableToggle: true,
//                    pressed: rtl,
                    text: 'RTL',
                    margin: '0 5 0 0',
                    listeners: {
//                        toggle: function(btn, pressed) {
//                            if (pressed) {
//                                setParam({ rtl: true });
//                            } else {
//                                removeParam('rtl');
//                            }
//                        }
                    }
                }, {
                    xtype: 'tool',
                    type: 'close',
                    rtl: false,
                    handler: function() {
                        this.destroy();
                    }
                }];
               me.show();
               alert('11')
            me.align(me);
//            Ext.EventManager.onWindowResize(me.align(me)); 
        me.callParent(arguments);
    },
     align:  function (me) {
            me.alignTo(
                document.body,
                'tr-tr',
                [
                    (Ext.getScrollbarSize().width + 4) * (Ext.rootHierarchyState.rtl ? 1 : -1),
                    -(document.body.scrollTop || document.documentElement.scrollTop)
                ]
            );
        } 
//        removeParam: function (paramName) {
//            var params = Ext.Object.fromQueryString(location.search);
//
//            delete params[paramName];
//
//            location.search = Ext.Object.toQueryString(params);
//        },
//          setParam: function (param) {
//            var queryString = Ext.Object.toQueryString(
//                Ext.apply(Ext.Object.fromQueryString(location.search), param)
//            );
//            location.search = queryString;
//        }

});