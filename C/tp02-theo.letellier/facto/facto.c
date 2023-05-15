#include <stdlib.h>
#include <stdio.h>

unsigned long facto(unsigned long n){
	
	if (n==0)
	{
		return 1;
	}

	unsigned long res = 1;
	for (unsigned long i = 1; i < n+1; ++i)
	{
		res*=i;
	}
	return res;
}
