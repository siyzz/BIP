package com.ccf.bip.framework.util;

import junit.framework.TestCase;

/*
 * @filename:HTMLStringUtilsTest.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-19     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class StringEscapeUtilTest extends TestCase {
    @Override  
    protected void setUp() throws Exception  
    {  
        // TODO Auto-generated method stub  
        super.setUp();        
    }  
  
    @Override  
    protected void tearDown() throws Exception  
    {
        // TODO Auto-generated method stub  
        super.tearDown();  
    }
    
    public void testHtmlEntityToString(){
        assertEquals(StringEscapeUtil.unescapeHtml4("afdafaf&gt;adsf&lt;"),"afdafaf>adsf<");
    }
    
    public void testStringToHtmlEntity(){
        assertEquals(StringEscapeUtil.escapeHtml4("afdafaf>adsf<"),"afdafaf&gt;adsf&lt;");
    }
}
