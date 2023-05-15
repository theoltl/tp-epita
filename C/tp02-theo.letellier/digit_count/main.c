#include <stdlib.h>
#include <stdio.h>
#include "digit_count.h"

int main(){

	for ( unsigned long i = 0; i < 64; ++i)
	{
		unsigned long x = 1;
		unsigned long tmp = x<<i;
		printf("digit_count (%lu) = %d\n", tmp, digit_count(tmp));
	}
	return 0;
}