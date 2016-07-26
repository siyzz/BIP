Ext.define('FRAME.view.ThemeComBox', {
    extend: 'Ext.form.field.ComboBox',
    alias: 'widget.themecombox',

    fieldLabel: '样式',
    name: 'ThemeComBox',

    initComponent: function() {
        var me = this;
        Ext.applyIf(me, {rtl: false,
            width: 170,
            labelWidth: 45, 
            fieldLabel: '样式',
            displayField: 'name',
            valueField: 'value',
            labelStyle: 'cursor:move;',
            margin: '0 5 0 0',
            store: Ext.create('Ext.data.Store', {
                fields: ['value', 'name'],
                data : [
                    { value: 'access', name: '黑色' },
                    { value: 'classic', name: '经典' },
                    { value: 'gray', name: '灰色' },
                    { value: 'neptune', name: '深蓝' }
                ]
            }),
            value: theme,
            listeners: {
                select: function(combo) {
                    var theme = combo.getValue();
                    if (theme !== defaultTheme) {
                        setParam({ theme: theme });
                    } else {
                        removeParam('theme');
                    }
                }
            }});
        me.callParent(arguments);
    }

});