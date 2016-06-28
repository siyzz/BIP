package com.ccf.bip.framework.util;

import java.io.IOException;

import junit.framework.TestCase;

/*
 * @filename:FileUtilTest.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-20     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class FileUtilTest extends TestCase {
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
    
    public void testCopy(){
        try {
            FileUtil.copy("H:\\CoreMcmsSetup.msi", "d:\\aaaabcd.msi");
        }
        catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        assertTrue(FileUtil.isFileExist("d:\\aaaabcd.msi"));
    }
    
    public void testCopy2(){
        try {
            FileUtil.copy2("H:\\CoreMcmsSetup.msi", "d:\\bbbbcd.msi");
        }
        catch (Exception e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        assertTrue(FileUtil.isFileExist("d:\\bbbbcd.msi"));
    }
}
