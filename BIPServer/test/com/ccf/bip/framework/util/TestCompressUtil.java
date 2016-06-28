package com.ccf.bip.framework.util;

import junit.framework.TestCase;

/*
 * @filename:TestCompressUtil.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-20     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class TestCompressUtil extends TestCase {
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
    
    public void testZip() throws Exception{
       CompressUtil.zip("F:\\技术文档\\项目文档\\1[1].03 需求文档 SRS\\1.03 需求文档 SRS","D:\\test.zip", "test");
       assertTrue(FileUtil.isFileExist("D:\\test.zip"));
    }
    
    public void testUnZip() throws Exception{
        CompressUtil.unzip("D:\\test.zip", "d:\\test");
        assertTrue(FileUtil.isFileExist("d:\\test"));
    }
}
