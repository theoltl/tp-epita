#include <stdlib.h>
#include <stdio.h>
#include "divisor_sum.h"

int main(int argc, char** argv){

	unsigned long param = strtoul(argv[1], NULL, 10);

	if (argc != 2 || param == 0)
	{
//		errx(1, "Error");
		printf("Errueur de logique\n");
		return 1;
	}

	printf("divisor_sum(%lu) = %lu\n", param,divisor_sum(param));
	return 0;
}