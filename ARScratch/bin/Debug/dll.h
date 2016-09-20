#ifndef _NATIVELIB_H_
#define _NATIVELIB_H_

#ifndef MYAPI
  #define MYAPI 
#endif

#include <string>
#include <iomanip>

extern "C" {

typedef unsigned char byte;

MYAPI void __stdcall YSobel(int length ,int width ,int height ,byte image[],byte cpy[]);

MYAPI double __stdcall Gaussian(double x, double y, double sigma2);

MYAPI double _stdcall YUV(byte r, byte g, byte b);

}
#endif

