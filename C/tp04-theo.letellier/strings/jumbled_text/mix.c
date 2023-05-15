#include <stdio.h>
#include "mix.h"

char separator[] = " ,;:!?./%*$=+)@_-('&1234567890\"\r\n";

void mix(char s[]){

    int enoughlong = 0; //if len(s) < 4

    for (int i = 0; i < 4; ++i)
    {
        if (s[i] == '\0')
        {
            enoughlong = -1;
            break;
        } 
    }

    if (enoughlong != -1)
        for (int i = 0; s[i] != '\0'; i+=1)
        {
            if(isfirstletter(s, i) == 1 && isfirstletter(s, i+1) == 1 && islastletter(s, i) == 1 && islastletter(s, i+1) == 1)
            {
                swapletter(s, i, i+1);
                i+=1;
            }
        }

}
/**
 * swap letters i and j in a string s
 * */
void swapletter(char s[], int i, int j){
    char temp = s[i];
    s[i] = s[j];
    s[j] = temp;
}

/**
 * return 0 is s[i] is first letter of a word and 1 otherwise 
 * */
int isfirstletter(char s[], int i){
    if (i == 0 || is_separator(s[i-1]) == 0)
        return 0;
    return 1;
}
/**
 * return 0 is s[i] is last letter of a word and 1 otherwise 
 * */
int islastletter(char s[], int i){
    if (s[i+1] == '\0' || is_separator(s[i+1]) == 0)
        return 0;
    return 1;
}
/**
 * return 0 is s is a separator and 1 otherwise 
 * */
int is_separator(char s){
    for (int i = 0; separator[i] != '\0'; ++i)
    {
    	if (s == separator[i])
    		return 0;
    }
    return 1;
}
