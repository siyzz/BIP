package com.ccf.bip.framework.util;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.commons.lang3.StringEscapeUtils;


/*
 * HTML字段串特殊字符转义工具类
 * @filename:HTMLStringUtils.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-19     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class StringEscapeUtil extends StringEscapeUtils{
    /**
     * 字符串转义为unicode格式
     * @author siy
     * @param s
     * @return
     * @throws
     * @version V1.0
     */
    public static String toUnicodeString(String str) {
        String unicode = "";
        char[] charAry = new char[str.length()];
        for (int i = 0; i < charAry.length; ++i) {
            charAry[i] = str.charAt(i);
            unicode = unicode + "\\u" + Integer.toString(charAry[i], 16);
        }
        return unicode;
    }

    /**
     * unicode格式转义为正常字符串
     * @author siy
     * @param unicodeStr
     * @return
     * @throws
     * @version V1.0
     */
    public static String unicode2String(String unicodeStr) {
        StringBuffer sb = new StringBuffer();
        String[] str = unicodeStr.toUpperCase().split("\\\\U");
        for (int i = 0; i < str.length; ++i)
            if (!str[i].equals("")) {
                char c = (char) Integer.parseInt(str[i].trim(), 16);
                sb.append(c);
            }
        return sb.toString();
    }

    /**
     * html转义为字符串
     * @author siy
     * @param inputString
     * @return
     * @throws
     * @version V1.0
     */
    public static String html2Text(String str) {
        String htmlStr = str;
        String textStr = "";
        try {
            String regEx_script = "<[\\s]*?script[^>]*?>[\\s\\S]*?<[\\s]*?\\/[\\s]*?script[\\s]*?>";

            String regEx_style = "<[\\s]*?style[^>]*?>[\\s\\S]*?<[\\s]*?\\/[\\s]*?style[\\s]*?>";

            String regEx_html = "<[^>]+>";

            Pattern p_script = Pattern.compile(regEx_script, 2);
            Matcher m_script = p_script.matcher(htmlStr);
            htmlStr = m_script.replaceAll("");

            Pattern p_style = Pattern.compile(regEx_style, 2);
            Matcher m_style = p_style.matcher(htmlStr);
            htmlStr = m_style.replaceAll("");

            Pattern p_html = Pattern.compile(regEx_html, 2);
            Matcher m_html = p_html.matcher(htmlStr);
            htmlStr = m_html.replaceAll("");

            textStr = htmlStr;
        }
        catch (Exception e) {
            System.err.println("Html2Text: " + e.getMessage());
        }
        return textStr;
    }
}
