#include "dll.h"
#include <math.h>
#include <iostream>

using namespace std;

const int pixelSize = 4;
const int threshold = 127;

const char value = 0;
const char A = 3;
const char R = 2;
const char G = 1;
const char B = 0;

int px1R,px2R,px3R,px4R,px5R,px6R,px7R,px8R,px9R;
int px1G,px2G,px3G,px4G,px5G,px6G,px7G,px8G,px9G;
int px1B,px2B,px3B,px4B,px5B,px6B,px7B,px8B,px9B;
int pxR,pxG,pxB;

int sumA,sumB,sumC,sumD,sumE,sumF,sumG,sumH,sumI,sumJ;

byte y11,y12,y13,y14,y15,y16,y17;
byte y21,y22,y23,y24,y25,y26,y27;
byte y31,y32,y33,y34,y35,y36,y37;
byte y41,y42,y43,y44,y45,y46,y47;
byte y51,y52,y53,y54,y55,y56,y57;
byte y61,y62,y63,y64,y65,y66,y67;

MYAPI double _stdcall YUV(byte r, byte g, byte b)
{
	return (.299*r) + (.587*g) + (.114*b);
}

/**
 * Gaussian function
 */
MYAPI double Gaussian(double x, double y, double sigma2)
{
	double t = (x*x+y*y)/(2*sigma2);
	double u = 1.0/(2*M_1_PI*sigma2);
	double e = u*exp( -t );
	return e;
}
/*
* This method always changes the values on the original Image. 
* marking the corner candidates with a green cross.
* it uses a byte array copy of the same size of the one of the image
* to work on it as a temp.
* It first turns the image to YUV values, then it Binarizes it 
* then it takes a 5x5 window and counts the rows and the columns of the mask
* to evaluate them as conditions.
*
* @param length of the byte array of the image
* @param width the width of the image as a matrix
* @param height the height of the image as a matrix
* @param image byte array with the RGBA info in the next order
* 		B = 0  G = 1 R = 2  A = 3
* @param cpy byte array with the same length of the image info
*/
MYAPI void YSobel(int length ,int width,int height, byte image[],byte cpy[])
{
	
	for(int i = 0; i < length; i+= pixelSize)
	{
		image[i+A] = YUV(image[i+R] , image[i+G], image[i+B]);
	}
	
	for(int i = (3*pixelSize * width); i < length - (3*pixelSize * width); i += pixelSize)
	{
		if( (i +4) % (width*pixelSize) != 0  && (i) % (width*pixelSize) != 1 && (i) % (width*pixelSize) != 0)
		{
			y11 = image[i -(width*pixelSize) - pixelSize + A ];
			y12 = image[i -(width*pixelSize) + A ];
			y13 = image[i -(width*pixelSize) + pixelSize + A ];
			
			y21 = image[i - pixelSize + A ];
			y22 = image[i + A ];
			y23 = image[i  + pixelSize + A ];
			
			y31 = image[i +(width*pixelSize) - pixelSize + A ];
			y32 = image[i +(width*pixelSize) + A ];
			y33 = image[i +(width*pixelSize) + pixelSize + A ];
			///////////////////////////////////////////////////////////////////////////
		
			pxR = abs( y11-y13 );
			pxR += abs((2*y21)-(2*y23));
			pxR += abs( y31-y33 );
						
			pxR += abs( y11-y31 );
			pxR += abs((2*y12)-(2*y32));
			pxR += abs( y13-y33 );
						
			pxR += abs( y21-y32 );
			pxR += abs((2*y11)-(2*y33));
			pxR += abs( y12-y23 );
						
			pxR += abs( y21-y12 );
			pxR += abs((2*y13)-(2*y31));
			pxR += abs( y32-y23 );	
			
			cpy[i+R] = ( (pxR/4 ) > threshold ) ? 1:0;					
		}
	}

	for(int i = (3*pixelSize * width); i < length - (3*pixelSize * width); i += pixelSize)
	{			
		if( (i +4) % (width*3*pixelSize) != 0  && (i) % (width*3*pixelSize) != 1 && (i) % (width*3*pixelSize) != 0)
		{
			y11 = cpy[i -(2*width*pixelSize) - 2*pixelSize + R];
			y12 = cpy[i -(2*width*pixelSize) - pixelSize + R];
			y13 = cpy[i -(2*width*pixelSize) + R];
			y14 = cpy[i -(2*width*pixelSize) + pixelSize + R];
			y15 = cpy[i -(2*width*pixelSize) + 2*pixelSize + R];
			
			y21 = cpy[i -(width*pixelSize) - 2*pixelSize + R];
			y22 = cpy[i -(width*pixelSize) - pixelSize + R];
			y23 = cpy[i -(width*pixelSize) + R];
			y24 = cpy[i -(width*pixelSize) + pixelSize + R];
			y25 = cpy[i -(width*pixelSize) + 2*pixelSize + R];
			
			y31 = cpy[i - 2*pixelSize + R];
			y32 = cpy[i - pixelSize + R];
			y33 = cpy[i + R];
			y34 = cpy[i  + pixelSize + R];
			y35 = cpy[i  + 2*pixelSize + R];
			
			y41 = cpy[i +(width*pixelSize) - 2*pixelSize + R];
			y42 = cpy[i +(width*pixelSize) - pixelSize + R];
			y43 = cpy[i +(width*pixelSize) + R];
			y44 = cpy[i +(width*pixelSize) + pixelSize + R];
			y45 = cpy[i +(width*pixelSize) + 2*pixelSize + R];
			
			y51 = cpy[i +(2*width*pixelSize) - 2*pixelSize + R];
			y52 = cpy[i +(2*width*pixelSize) - pixelSize + R];
			y53 = cpy[i +(2*width*pixelSize) + R];
			y54 = cpy[i +(2*width*pixelSize) + pixelSize + R];
			y55 = cpy[i +(2*width*pixelSize) + 2*pixelSize + R];
			
			///////////////////////////////////////////////////////////////////////////
						
			sumA = y11+y12+y13+y14+y15;
			sumB = y21+y22+y23+y24+y25;
			sumC = y31+y32+y33+y34+y35;			
			sumD = y41+y42+y43+y44+y45;
			sumE = y51+y52+y53+y54+y55;
			
			sumF = y11+y21+y31+y41+y51;
			sumG = y12+y22+y32+y42+y52;
			sumH = y13+y23+y33+y43+y53;
			sumI = y14+y24+y34+y44+y54;
			sumJ = y15+y25+y35+y45+y55;
			
			if(y33>0)
			if((sumC + sumH) <  (sumA+sumE+sumF+sumJ) && 
			(sumC + sumH) <  (sumA+sumB+sumD+sumE+sumF+sumG+sumI+sumJ)  &&
			( (sumC + sumH) > 5 ) &&
			( (sumC + sumH) < 11 )  && 
			(sumA+sumB+sumD+sumE+sumF+sumG+sumI+sumJ) < 20 )
			{
				image[i -(width*pixelSize) - pixelSize + G] = 255;
				image[i -(width*pixelSize) + pixelSize + G] = 255;
				image[i + G] = (unsigned char)(255);
				image[i +(width*pixelSize) - pixelSize + G] = 255;	
				image[i +(width*pixelSize) + pixelSize + G] = 255;
			}			
		}	
		image[i+A] = 255;	
	}
}

