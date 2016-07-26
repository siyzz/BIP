package com.ccf.bip.framework.core;

import com.ccf.bip.framework.util.StringUtil;

import java.io.UnsupportedEncodingException;
import java.util.Random;
import java.util.UUID;
import java.util.zip.CRC32;

/**
 * Created by siy on 2016/6/21.
 */
public class BipGuid {
    private static final int len = 18;
    private static final CRC32 crc = new CRC32();
    private static final Random r = new Random();

    public static String getCRC32(String str) {
        crc.reset();
        byte[] buffer = null;
        try {
            buffer = str.getBytes("utf-8");
        }
        catch (UnsupportedEncodingException uee){
            buffer = str.getBytes();
        }

        crc.update(buffer);
        return Long.toString(crc.getValue(),16);
    }

    public static String getGuid(){
        String str = getCRC32(UUID.randomUUID().toString()) + getCRC32(String.valueOf(System.nanoTime() - r.nextLong()));
        if (str.length() < len)  //包含长度小于18位的结果，调整到18位。
            str = StringUtil.rightPad(str,18,'0');

        return str;
    }
}
