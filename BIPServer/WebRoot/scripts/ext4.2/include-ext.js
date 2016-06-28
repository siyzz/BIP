/**
 * This file includes the required ext-all js and css files based upon "theme"
 * and "direction" url parameters. It first searches for these parameters on the
 * page url, and if they are not found there, it looks for them on the script
 * tag src query string. For example, to include the neptune flavor of ext from
 * an index page in a subdirectory of extjs/examples/: <script
 * type="text/javascript"
 * src="../../examples/shared/include-ext.js?theme=neptune"></script>
 */
/* 默認的樣式 */
var theme, defaultTheme = 'neptune';
/* 设置变量值 */
function setParam(param) {
	var queryString = Ext.Object.toQueryString(Ext.apply(Ext.Object
			.fromQueryString(location.search), param));
	location.search = queryString;
}
/* 移除变量值 */
function removeParam(paramName) {
	var params = Ext.Object.fromQueryString(location.search);
	delete params[paramName];
	location.search = Ext.Object.toQueryString(params);
}
/**
 * 查询页面中的对应元素
 * 
 * @param name
 *            要要查询的属性名
 * @param queryString
 *            要查询的属性对应的字符串
 * @author 刘守权
 * @version 1.0
 */
function getQueryParam(name, queryString) {
	var match = RegExp(name + '=([^&]*)').exec(queryString || location.search);
	return match && decodeURIComponent(match[1]);
}
/**
 * 获取可以使用的css样式
 * 
 * @param opt
 * @param queryString
 * @author 刘守权
 * @version 1.0
 */
function hasOption(opt, queryString) {
	var s = queryString || location.search;
	var re = new RegExp('(?:^|[&?])' + opt + '(?:[=]([^&]*))?(?:$|[&])', 'i');
	var m = re.exec(s);
	return m ? (m[1] === undefined || m[1] === '' ? true : m[1]) : false;
}
(function() {

	/**
	 * 获取Cookie的name
	 * 
	 * @param name
	 * @author 刘守权
	 * @version 1.0
	 */
	function getCookieValue(name) {
		var cookies = document.cookie.split('; ');
		var i = cookies.length;
		var cookie;
		var value;
		while (i--) {
			cookie = cookies[i].split('=');
			if (cookie[0] === name) {
				value = cookie[1];
			}
		}
		// debugger
		return value;
	}
	// ////////////////////////////////////////
	var scriptEls = document.getElementsByTagName('script'),
	/* 默认的样式名 */
	/* 默认RTL */
	defaultRtl = false,
	/* script标签的数量 */
	i = scriptEls.length,
	/* 默认查询的字符串 */
	defaultQueryString,
	/* script标签中的src属性 */
	src,
	/* 切换样式的后缀信息 */
	suffix = [],
	/* 样式路径 */
	themePath,
	/* 样式类型 */
	theme,
	/* 是否开发模式 */
	repoDevMode = getCookieValue('ExtRepoDevMode'),
	/**/
	rtl;
	/* 循环获取各个样式的 */
	while (i--) {
		src = scriptEls[i].src;
		if (src.indexOf('include-ext.js') !== -1) {
			defaultPathQueryString = src.split('?')[0];
			defaultQueryString = src.split('?')[1];
			themePath = defaultPathQueryString.substring(0,
					defaultPathQueryString.lastIndexOf('/'));
			if (defaultQueryString) {
				defaultTheme = getQueryParam('theme', defaultQueryString)
						|| defaultTheme;
				defaultRtl = getQueryParam('rtl', defaultQueryString)
						|| defaultRtl;
			}
			break;
		}
	}
	/* 样式名 */
	theme = getQueryParam('theme') || defaultTheme;

	rtl = getQueryParam('rtl') || defaultRtl;
	if (theme && theme !== 'classic') {
		suffix.push(theme);
	}
	if (rtl) {
		suffix.push('rtl');
	}

	suffix = (suffix.length) ? ('-' + suffix.join('-')) : '';
	/* 如果支持CSS样式则添加对应的CSS样式 */
	includeCSS = !hasOption('nocss', themePath);
	if (includeCSS) {
		document
				.write('<link rel="stylesheet" type="text/css" href="' + themePath + '/resources/css/ext-all-debug.css"/>');
	}
	/* 添加对应的JS样式JS文件 */
	document.write('<script type="text/javascript" src="' + themePath
			+ '/ext-all' + (rtl ? '-rtl' : '') + '.js"></script>');
	document
			.write('<script type="text/javascript" src="' + themePath + '/local/ext-lang-zh_CN.js"></script>');
	/* 对IE6兼容性提示 */
	if (theme) {
		/* 添加对应的样式文件 */
		themePath = (repoDevMode ? themePath + '/..' : themePath) + '/resources/ext-theme-gray/ext-theme-gray-all.css';
		// if (repoDevMode && window.ActiveXObject) {
		// Ext = {
		// _beforereadyhandler : function() {
		//
		// Ext.Loader.loadScript( {
		// url : themePath
		// });
		// }
		// };
		// } else {
		document
				.write('<link rel="stylesheet" type="text/css" href="' + themePath + '" defer></script>');
		// }
	}

})();