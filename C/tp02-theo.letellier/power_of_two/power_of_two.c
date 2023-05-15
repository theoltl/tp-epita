#include <stdlib.h>
#include <stdio.h>

unsigned long power_of_two(unsigned char n){
	//utiliser la fonction power de C
	unsigned long x = 1; 
	return(x<<n);
}