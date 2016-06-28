package com.ccf.bip.framework.core;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.*;

/**
 * Created by siy on 2016/6/21.
 */
public class BipGuidTest {
    @Before
    public void setUp() throws Exception {
    }

    @After
    public void tearDown() throws Exception {

    }

    @Test
    public void getGuid() throws Exception {
        assertNotNull(BipGuid.getGuid());
    }

}