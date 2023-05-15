#include <stdlib.h>
#include <stdio.h>
#include "isqrt.h"

int main(){

	for (unsigned long i = 0; i < 201; i+=8)
	{
		printf("isqrt(%lu) = %lu\n", i, isqrt(i));
		;
	}
	return 0;
}