#include <stdlib.h>
#include <stdio.h>
#include "insert_sort.h"


// Insertion using the plain algorithm.
void array_insert(int *begin, int *end, int x)
{
	int *fin = end;

	while (begin < fin && x < *(fin-1))
	{
		*fin = *(fin-1);
		fin--;
	}

	*fin = x;
}


//Looking for the position of x
int* binary_search(int *begin, int *end, int x)
{
	int left = 0;
	int right = end - begin;
	int middle;

	while(right > left && right != (left + 1))
	{
		middle = ((right+left)/2);

		if (x > *(begin + middle))
                        left = middle;

		else if (x < *(begin + middle))
                        right = middle;

		else
			return (begin + middle);
	}
	return (begin + right);
}

	
// Insertion using the binary-search algorithm.
void array_insert_bin(int *begin, int *end, int x)
{
	int *pos = binary_search(begin, end, x);
	int *fin = end;

	while (pos != fin)
	{
		*fin = *(fin - 1);
		fin--;
	}

	*fin = x;
}



// Insertion sort using plain method.
void array_insert_sort(int *begin, int *end)
{
	int *fin = end;
	int *debut = begin;

	while (debut != fin)
	{
		array_insert(begin, debut, *debut);
		debut++;
	}
}



// Insertion sort using binary search.
void array_insert_sort_bin(int *begin, int *end)
{
        int *debut = begin;
	int *fin = end;

        while (debut != fin)
        {
                array_insert_bin(begin, debut, *debut);
                debut++;
        }

	debut = begin;
	fin = end;

	while(debut < (fin-1) && *debut > *(debut+1))
	{
		swap(debut, (debut+1));
		debut++;
	}
}
