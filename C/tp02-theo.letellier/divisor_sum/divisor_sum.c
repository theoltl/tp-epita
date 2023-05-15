#include <stdio.h>
#include <stdlib.h>

unsigned long divisor_sum(unsigned long n){

    unsigned long i;
    unsigned long d;
    unsigned long sum=1;

    if (n < 3)
    {
        return n-1;
    }

    for(i = 2; i*i <= n; i++)
    {
        if(n % i == 0)
        {
           sum += i;
           d = n/i;
           if(d!=i)
              sum+=d;
        }
    }

    return sum;
}