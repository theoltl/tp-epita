# include <stdio.h>

unsigned long sum_of_divisors(unsigned long n, size_t *count)
{
        unsigned long div = 0;
	*count = 0;


	for(unsigned long temp = 2 ; temp * temp <= n; temp++)
        {
                if(n % temp == 0)
                {
                        div += temp;
                        if (temp != (n / temp))
			{
				div += n / temp;
                        	*count = *count + 2;
			}
			else
				*count = *count + 1;
                }
        }

        if (n < 2)
                return 0;

	*count = *count + 1;
        return div + 1;
}

int main()
{
    unsigned long x;
    unsigned long sum;
    size_t count;

    x = 28;
    sum = sum_of_divisors(x, &count);
    printf("x = %lu\n", x);
    printf("sum   = %lu\n", sum);
    printf("count = %zu\n\n", count);

    x = 100;
    sum = sum_of_divisors(x, &count);
    printf("x = %lu\n", x);
    printf("sum   = %lu\n", sum);
    printf("count = %zu\n", count);
}
