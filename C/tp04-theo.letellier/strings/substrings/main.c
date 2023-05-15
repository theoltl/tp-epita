#include <stdio.h>
#include <stdlib.h>
#include <err.h>

/**
 * check if a string s2 is a substring of a string s1
 * 
 * return the index of the first occurence if research is positive or -1 if negative 
 */
int is_substring(char s1[], char s2[])
{
	for (int i = 0, a = 0, j =0; s1[i] != '\0'; i++)
	{
		a = i;
		while(s2[j] != '\0')
		{
			if (s1[a] == s2[j])
				a++;
			else
				break;
			j+=1;
		}

		if (s2[j] == '\0')
			return i;
	}

	return -1;
}


/**
 * check if a string has all her caracters on the interval [32-122] of ascii table
 * to suppress accentued caracters
 * 
 * return 0 if all caracters pass the test and 1 otherwise*/

int checkascii(char s[]){
	for (int i = 0; s[i] != '\0'; i++)
	{
		if ((int)s[i] < 32 || (int)s[i] > 122)
			return 1;
	}
	return 0;
}

int main(int argc, char *argv[])
{
	if (argc != 3)
		errx(1,"Usage: str1 str2");
	if (checkascii(argv[1]) == 0 && checkascii(argv[2]) == 0)
	{
		int res = is_substring(argv[1], argv[2]);
		printf("%d\n", res);
		if (res == -1)
			printf ("Not Found!\n");
		
		else
		{
			printf ("%s\n", argv[1]);
			for (int i = 0; i < res; ++i)
				printf(" ");
			printf ("^\n");
		}	
	}

	
	return 0;
}