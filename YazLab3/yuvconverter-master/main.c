//
// Writing faster code Spring 2009
// Software Optimizations Optimizations
//
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <chrono>
//#include "HPClock.h"


#define CLIP(x) ((x<0?0:(x>255?255:x)))

typedef struct {
  unsigned short bfType; 
  unsigned long  bfSize; 
  unsigned short bfReserved1; 
  unsigned short bfReserved2; 
  unsigned long bfOffBits; 
} BITMAPFILEHEADER_T; 

typedef struct { 
  unsigned long biSize; 
  long biWidth; 
  long biHeight; 
  unsigned short biPlanes; 
  unsigned short biBitCount; 
  unsigned long biCompression; 
  unsigned long biSizeImage; 
  long biXPelsPerMeter; 
  long biYPelsPerMeter; 
  unsigned long biClrUsed; 
  unsigned long biClrImportant; 
} BITMAPINFOHEADER_T; 

// convert  YUV to BMP
void yuv2bmp(unsigned char *pFrame[3], int nWidth, int nHeight, unsigned char *pBBuf, int *nBSize){ 


	BITMAPINFOHEADER_T stInfoHdr;
	BITMAPFILEHEADER_T stFileHdr;
	unsigned char* pRGBData;
	int i, j, k, Y, Cb, Cr;

	/* BMP file header*/
	stFileHdr.bfType = 0x4D42;
	stFileHdr.bfReserved1 = 0;
	stFileHdr.bfReserved2 = 0;	 
	stFileHdr.bfOffBits = 14 + 40;
	stFileHdr.bfSize = stFileHdr.bfOffBits + nWidth*nHeight*3;

	/* info header */
	stInfoHdr.biSize = sizeof(BITMAPINFOHEADER_T);
	stInfoHdr.biWidth = nWidth;
	stInfoHdr.biHeight = nHeight*-1;
	stInfoHdr.biPlanes = 1;
	stInfoHdr.biBitCount = 24;
	stInfoHdr.biCompression = 0;
	stInfoHdr.biSizeImage = nWidth*nHeight*3;
	stInfoHdr.biXPelsPerMeter = 0;
	stInfoHdr.biYPelsPerMeter = 0;
	stInfoHdr.biClrUsed = 0;
	stInfoHdr.biClrImportant = 0;

	memcpy(pBBuf, (char*)&(stFileHdr.bfType), 2);
	memcpy(pBBuf+2, (char*)&(stFileHdr.bfSize), 4);
	memcpy(pBBuf+6, (char*)&(stFileHdr.bfReserved1), 2);
	memcpy(pBBuf+8, (char*)&(stFileHdr.bfReserved2), 2);
	memcpy(pBBuf+10, (char*)&(stFileHdr.bfOffBits), 4);

	memcpy(pBBuf+14, (char*)&stInfoHdr, 40);

	pRGBData = pBBuf + stFileHdr.bfOffBits;
	for(i = 0, k = 0; i < nWidth*3; i+=3, k++){	
		for(j = 0; j < nHeight; j++){
			Y = (unsigned char) pFrame[0][j*nWidth+k];
			Cr = (unsigned char)pFrame[2][j*nWidth+k]; 
			Cb = (unsigned char)pFrame[1][j*nWidth+k];

			pRGBData[nWidth*3*j+i+0] = CLIP(Y + 1.772*(Cb-128)); // B
			pRGBData[nWidth*3*j+i+1] = CLIP(Y - 0.34414*(Cb-128) - 0.71414*(Cr-128)); // G
			pRGBData[nWidth*3*j+i+2] = CLIP(Y + 1.402*(Cr-128)); // R
		}
	}

	*nBSize = stFileHdr.bfSize;
}

void Usage (){
	printf("\nUsage:\n\thw2 -i <input YUV file> -w <width> -h <height> -o <output bmp file> -n <number of frames to convert>\n");
}

int main(int argc, char *argv[]){

	int i,j,k, nIdx;
	//HPClock oClock;
	unsigned char *pYUVData[3], *pBMPData;
	int nWidth, nHeight, nNumFrames=1;
	FILE *fpIn, *fpOut;
	fpIn = fpOut = NULL;

	if(argc < 11){
		Usage();
		exit(0);
	}
	
	nIdx  = 1;
	while(nIdx < argc){
		switch(argv[nIdx][1]){
		case 'i':
		case 'I':
				nIdx++;
				fpIn = fopen(argv[nIdx], "rb");
				if(fpIn == NULL){
					printf("\nCannot open input file: %s", argv[nIdx]);
					return 0;
				}
			break;

		case 'o':
		case 'O':
				nIdx++;
				fpOut = fopen(argv[nIdx], "wb");
				if(fpOut == NULL){
					printf("\nCannot open output file: %s", argv[nIdx]);
					return 0;
				}
			break;

		case 'w':
		case 'W':
				nIdx++;
				nWidth = atoi(argv[nIdx]);
			break;

		case 'h':
		case 'H':
				nIdx++;
				nHeight = atoi(argv[nIdx]);
			break;

		case 'n':
		case 'N':
				nIdx++;
				nNumFrames = atoi(argv[nIdx]);
			break;

		default:
			printf("\nUnknown option: -%c", argv[nIdx][1]);
			Usage();
			exit(0);
			break;
		}
		nIdx++;
	}

	// YUV data buffer
	pYUVData[0] = new unsigned char [nWidth*nHeight]; 
	pYUVData[1] = new unsigned char [nWidth*nHeight];
	pYUVData[2] = new unsigned char [nWidth*nHeight];

	// buffer for RGB bitmap; BMP header is 54 buyes
	pBMPData = new unsigned char [nWidth*nHeight*3+54];
	int nBMPSize = 0;

	double nBTime = 0.0;
	/* Each YUV frame has Y, U, and V components.
	   The data for each component is stored in consecutive memory locations.
	   The Y component size is nWidth*nHeight bytes.
	   This corresponds to nHeight lines with nWidth pixels per line.

	   The U and V components are each (nWidth/2)*(nHeight/2) bytes.
	   The size of YUV frame is: nWidth*nHeight + 2*(nWidth/2)*(nHeight/2) = 1.5*nWidth*nHeight
	   The YUV files used in this HW do now have any header.
	*/
	for(;nNumFrames>0;nNumFrames--){
		// read the YUV frame
		// read Y component
		int nBytesRead = fread(pYUVData[0],1, nWidth*nHeight, fpIn);
		if(nBytesRead < nWidth*nHeight){
			printf("\nNot enough data to read YUV frame");
			break;
		}
		// read U component
		nBytesRead = fread(pYUVData[1],1, nWidth*nHeight/4, fpIn);
		if(nBytesRead < nWidth*nHeight/4){
			printf("\nNot enough data to read YUV frame");
			break;
		}
		// read V component
		nBytesRead = fread(pYUVData[2],1, nWidth*nHeight/4, fpIn);
		if(nBytesRead < nWidth*nHeight/4){
			printf("\nNot enough data to read YUV frame");
			break;
		}

		//oClock.Start();
		// upsample YUV to 444 format before converting to RGB
		// U and V components are upsampled to nWidth*nHeight 
		// resolution for RGB conversion
        std::chrono::steady_clock::time_point start = std::chrono::steady_clock::now(); //start time

		k = 0;
		int nUVPitch = nWidth/2;
		unsigned char *pUData, *pVData, *pUDest0, *pVDest0, *pUDest1, *pVDest1;
		for(i = nHeight - 1; i >=0 ; i-=2){

			pUData = pYUVData[1]+(i/2)*nUVPitch;
			pVData = pYUVData[2]+(i/2)*nUVPitch;

			pUDest0 = pYUVData[1]+i*nWidth;
			pVDest0 = pYUVData[2]+i*nWidth;

			pUDest1 = pYUVData[1]+(i-1)*nWidth;
			pVDest1 = pYUVData[2]+(i-1)*nWidth;
			for(j = 0, k = 0; j < nWidth/2; j++, k+=2){
				pUDest0[k] = pUDest0[k+1] = pUDest1[k] = pUDest1[k+1] = pUData[j]; 
				pVDest0[k] = pVDest0[k+1] = pVDest1[k] = pVDest1[k+1] = pVData[j];
			}
		}

		yuv2bmp(pYUVData, nWidth, nHeight, pBMPData, &nBMPSize); 
		//nBTime += oClock.Stop();
        
        std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now(); //end time
        
        std::chrono::steady_clock::duration runtime = end - start; //runtime computation
        nBTime = std::chrono::duration_cast<std::chrono::nanoseconds>(runtime).count();
        
	}

   printf("\nBase BMP Encoding Time in nanoseconds: %f\n", nBTime);

	fwrite(pBMPData, 1, nBMPSize, fpOut);

	fclose(fpIn);
	fclose(fpOut);

	delete [] pYUVData[0];
	delete [] pYUVData[1];
	delete [] pYUVData[2];
	delete [] pBMPData;

	return 0;
}

