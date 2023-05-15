#include <stdio.h>
#include <stdlib.h>

unsigned char digit_count(unsigned long n){

	int res = 0;
	while(n>9){
		n /= 10;
		res += 1; 
	}

	return res+1;
}