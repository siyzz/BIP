<%@page pageEncoding="UTF-8"%>

<head>
<!-- <meta http-equiv="X-UA-Compatible" content="chrome=1">  -->
<title>BIP</title>
<script type="text/javascript">
            var __ctxPath="<%=request.getContextPath()%>";
</script>
<link rel="stylesheet" type="text/css"
    href="<%=request.getContextPath()%>/resources/styles/default/frame.css" />
<!-- 引入对应的Extjs文件开始 -->
<script type="text/javascript"
    src="<%=request.getContextPath()%>/scripts/ext4.2/include-ext.js?theme=classic"></script>

<script type="text/javascript"
    src="<%=request.getContextPath()%>/frame/view/LogingWindow.js"></script>
<script type="text/javascript">
    Ext.onReady(function() {
        Ext.BLANK_IMAGE_URL = __ctxPath + "/resources/images/default/s.gif";
        Ext.create('frame.view.LoginWindow', {
            istrue : true
        }).show();
        var y = Ext.getCmp('userNo');
        Ext.Function.defer(function() {
            y.focus(true);
        }, 100);
    });
</script>

</head>
<body
    style="background:url('./resources/images/background.jpg');
    				background-repeat:no-repeat;
    				background-position:center center;
    				background-color:#d9e8f8;
                    margin-left: 0px;
                    margin-top: 0px;
                    margin-right: 0px;
                    margin-bottom: 0px;">
</body>
</html>