package com.ccf.bip.framework.demo;

public class StaticBlockDemo {
	public static int a = 0;
	public static int b = 0;
	
	public static final int i = a+b;
	
	static{
		a = 1;
		b = 1;
	}
	
	public static final int j = a+b;
	
	public static void main(String[] args) {
		System.out.println(i);
		System.out.println(j);
	}
}
