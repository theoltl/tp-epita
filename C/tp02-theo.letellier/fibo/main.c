#include <stdlib.h>
#include <stdio.h>
#include "fibo.h"

int main(){

	for (unsigned long i = 0; i < 11; ++i)
	{
		printf("fibo(%lu) = %lu\n",i, fibo(i));
	}
	printf("... \n");
	for (unsigned long i = 81; i < 91; ++i)
	{
		printf("fibo(%lu) = %lu\n",i, fibo(i));
	}
	return 0;
}