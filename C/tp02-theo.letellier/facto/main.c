#include <stdlib.h>
#include <stdio.h>
#include "facto.h"

int main(){
	
	for (unsigned long i = 0; i < 21; ++i)
	{
		printf("%lu\n", facto(i));
	}

	return 0;
}
