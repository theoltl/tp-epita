#include <stdio.h>
#include <stdlib.h>
#include <err.h>
#include "mix.h"

int main(int argc, char *argv[]){
    if (argc == 2)
    {
        printf("%s\n",argv[1]);
        mix(argv[1]);
        printf("%s\n",argv[1]);
    }
    else
    {
        char str[] = "Le J c'est le S ok! une liasse epaisse";
        printf("%s\n",str);
        mix(str);
        printf("%s\n",str);
    }
    

}