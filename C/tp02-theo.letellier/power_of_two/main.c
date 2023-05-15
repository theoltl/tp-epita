#include <stdio.h>
#include "power_of_two.h"

int main(){
	char i;

	for (i = 0; i < 64; ++i)
	{
		printf("power_of_two(%d) = %lu\n", (i), power_of_two(i));
	}
	return 0;
}