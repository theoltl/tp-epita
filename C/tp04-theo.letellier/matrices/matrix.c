#include <stdio.h>

void print_matrix(char s[], double m[], size_t rows, size_t cols)
{
    printf("%s = \n", s);

    size_t len = rows * cols;
    for (size_t i = 0; i < len; i++)
    {
        printf("%4g  ", m[i]);

        if ((i+1)%(cols) == 0)
        {
            printf("\n");
        }
    }
}


void transpose(double m[], size_t rows, size_t cols, double r[])
{
    int a = 0;
    size_t len = rows * cols;

    for (size_t i = 0; i < cols; i++)
    {
        for (size_t j = i; j < len; j+= cols)
        {
            r[a] = m[j];
            a++;
        }
        
    }
    
}

void add(double m1[], double m2[], size_t rows, size_t cols, double r[])
{
    size_t len = rows * cols;
    
    for (size_t i = 0; i < len; i++)
    {
        r[i] = m1[i] + m2[i];
    }
}


void mul(double m1[], double m2[], size_t r1, size_t c1, size_t c2, double r[])
{
    for (size_t i = 0; i < r1; i++)
    {
        for (size_t j = 0; j < c2; j++)
        {
            for (size_t k = 0; k < c1; k++)
            {
                r[i *c2 +j] +=m1[k + i * c1] * m2[j + k * c2];
            }
            
        }
        
    }
}