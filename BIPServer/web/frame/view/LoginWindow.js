Ext
		.define(
				'frame.view.LoginWindow',
				{
					extend : 'Ext.window.Window',
					itemId : 'loginWindow_itemId',
					border : false,
					closable : false,
					resizable : false,
					header : false,
					//headerPosition : 'bottom',
					buttonAlign : "center",
					height : 238,
					width : 357,
					layout : {
						type : "hbox",
						align : "stretch"
					},
					initComponent : function() {
						var me = this;
						Ext
								.applyIf(
										me,
										{
											items : [ {
												xtype : 'form',
												bodyStyle : "padding-top:auto;background-image: url(resources/images/loginbackground.jpg);background-repeat:no-repeat;background-position:top left;",
												defaultType : "textfield",
												labelPad : 0,
												border : false,
												flex : 1,
												itemId : 'loginForm_itemId',
												layout : 'absolute',
												fieldDefaults : {
													width : 300,
													labelAlign : "right",
													allowBlank : true,
													selectOnFocus : true
												},
												items : [
														{
															x : 100,
															y : 62,
															width : 210,
															name : "userName",
															id : "userNo",
															fieldLabel : "",
															labelAlign : 'right',
															value : 'ADMIN',
															allowBlank : false,
															blankText : "账号不能为空",
															enableKeyEvents : true,
															listeners : {
																'render' : function(
																		input) {
																	new Ext.KeyMap(
																			input
																					.getEl(),
																			[ {
																				key : 13,
																				fn : me.logInIngWin,
																				scope : input
																			} ]);
																},
																'keyup' : function(
																		tx) {
																	tx
																			.setValue(tx
																					.getValue()
																					.toUpperCase());
																}
															}
														},
														{
															x : 100,
															y : 107,
															width : 210,
															name : "userPassword",
															id : "userPwd",
															fieldLabel : "",
															labelAlign : 'right',
															value : '111',
															minLengthText : '输入长度要大等于10位',
															allowBlank : false,
															blankText : "密码不能为空",
															inputType : "password",
															enableKeyEvents : true,
															listeners : {
																'render' : function(
																		input) {
																	new Ext.KeyMap(
																			input
																					.getEl(),
																			[ {
																				key : 13,
																				fn : me.logInIngWin,
																				scope : input
																			} ]);
																	;
																},
																'keyup' : function(
																		tx) {
																	tx
																			.setValue(tx
																					.getValue()
																					.toUpperCase());
																}
															}
														},
														{
															x : 100,
															y : 142,
															xtype:'checkboxgroup',name:'checkboxautologin',   
											                id: 'checkboxautologin', fieldLabel: '',
											                items:[{ name: 'cb', inputValue: '1'}],
											                listeners : {
																'render' : function(
																		ctrl,eOpts) {
																	//if(Ext.isIE){
																		//Ext.Msg.alert(ctrl);
																		//ctrl.showAt(100,142);
																	//}
																}
															}
											            },
														{
															x : 104,
															y : 186,
															width : 65,
											            	height : 35,
															xtype:'button',
															name:'buttonLogin',   
											                id: 'buttonLogin',
											                text: '',
											                style: 'opacity:0.2;filter:alpha(opacity=20);'
											            },
														{
															x : 179,
															y : 186,
															width : 65,
											            	height : 35,
															xtype:'button',
															name:'buttonReset',   
											                id: 'buttonReset',
											                text: '',
											                style: 'opacity:0.2;filter:alpha(opacity=20);'
											            }    
													]
											} ]/*,
											buttons : [ {
												text : "登录",
												iconCls : "submit",
												hidden : true,
												handler : me.logInIngWin
											}, {
												text : "重置",
												iconCls : "clear",
												hidden : true,
												handler : me.resetForm
											} ]*/
										});

						me.callParent(arguments);
					},
					logInIngWin : function() {
						var me = this;
						var window = me.up('[itemId=loginWindow_itemId]');
						var form = window.down('form[itemId=loginForm_itemId]');
						if (form.form.isValid()) {
							form.form.submit({
								waitTitle : "请稍候",
								waitMsg : "正在登录......",
								mothed : 'post',
								timeout : 1000 * 60 * 5,
								url : __ctxPath + "/login/login.do",
								success : function(e, f) {
									window.handleLoginResult(window, f);// 根据登录返回结果
								},
								failure : function(g, h) {
									// debugger;
									/*---------duanhy 2014-01-24 修改密码以及用户名错误处理方法----------*/
									window.handleLoginResult(window, h);
									/*---------duanhy 2014-01-24 修改密码以及用户名错误处理方法----------*/
									/* 登录失败的处理 */
									// g.findField("userNo").setRawValue("");
									g.findField("userPwd").setRawValue("");

								}
							});
						}
					},
					resetForm : function() {
						var me = this;
						var window = me.up('[itemId=loginWindow_itemId]');
						var form = window.down('form[itemId=loginForm_itemId]');
						form.form.reset();
					},
					/**
					 * 根据登录验证返回信息，控制登录
					 * 
					 * @editor duanhy
					 * @editDate 2014-01-24 15:18 方法处理
					 * @editContent
					 * @param {}
					 *            a
					 */
					handleLoginResult : function(win, records) {
						var result = Ext.decode(records.response.responseText);
						if (result.success) {
							win.hide();
							var progressbar = new Ext.ProgressBar({
								text : "正在登录..."
							});
							progressbar.show();
							window.location.href = __ctxPath
									+ "/frame/index.jsp";// 登录进入页面

						} else {
							Ext.MessageBox.show({
								title : "操作信息",
								msg : result.msg,
								buttons : Ext.MessageBox.OK,
								icon : Ext.MessageBox.ERROR
							});
						}
					}
				});