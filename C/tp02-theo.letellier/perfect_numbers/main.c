#include <stdlib.h>
#include <stdio.h>
#include "is_perfect_number.h"

int main(){
	int res = 0;
	for (int i = 0; i < 100000; ++i)
	{
		res = is_perfect_number(i);
		if (res != 0)
		{
			printf("%d\n", res );
		}
	}

	return 0;

}