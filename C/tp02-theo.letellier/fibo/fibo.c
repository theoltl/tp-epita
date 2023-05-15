#include <stdlib.h>
#include <stdio.h>

unsigned long fibo(unsigned long n){
	unsigned long F0 = 0;
	unsigned long F1 = 1;
	if (n == 0)
	{
		return F0;
	}
	
	unsigned long tmp = 0;
	for (unsigned long i = 2; i < n+1; ++i)
	{
		tmp = F0 + F1;
		F0 = F1 ;
		F1 = tmp;
	}

	return F1;
}