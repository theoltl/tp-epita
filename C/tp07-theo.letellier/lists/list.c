#include <stdlib.h>
#include "list.h"

void list_init(struct list *list)
{
    list -> data = 0;
    list -> next = NULL;
}

int list_is_empty(struct list *list)
{
    if (list -> next == NULL)
        return 1;

    return 0;
}

size_t list_len(struct list *list)
{
    size_t len = 0;
    for (; list->next != NULL; list = list->next) len++;    

    return len;
}


//=============
void list_push_front(struct list *list, struct list *elm)
{
    elm -> next = list -> next;
    list -> next = elm;
}



struct list *list_pop_front(struct list *list)
{
    if (list_is_empty(list) == 1 ) return list;

    struct list *front = malloc(sizeof(struct list));
    front = list -> next;
    list->next = front -> next;
    front -> next =  NULL;

    return front;
}

struct list *list_find(struct list *list, int value)
{
    for (; list->next != NULL; list = list->next)
        if (list ->next->data == value) return list->next;
    return NULL;
}

struct list *list_lower_bound(struct list *list, int value)
{
    for (; list -> next != NULL && list->next->data > value; list = list -> next)
        continue;
    return list;
}

int list_is_sorted(struct list *list)
{
    for (; list->next == NULL; list = list->next)
        if(list->data > (list->next)->data)
            return 0;
    return 1;
}

void list_insert(struct list *list, struct list *elm)
{
    for (; list -> next != NULL && list->next->data < elm->data; list = list->next)
        continue;

    elm -> next = list -> next;
    list -> next = elm;

}

void list_rev(struct list *list)
{
/*    struct list *tmp = malloc(sizeof (struct list));
    tmp = list -> next;

    for (; list-> next != NULL ; list = list->next)
    {
        list->next = list;
    }

    (void) tmp;
*/

    struct list *prev = NULL;
    struct list *current = list->next;
    struct list *next=NULL;
    while(current!=NULL)
    {
        next = current->next;
        current->next = prev;
        prev = current;
        current = next;
    }
    list->next = prev;
}

void list_half_split(struct list *list, struct list *second)
{
    int half = list_len(list) / 2;

    for (int i = 0; i <= half /2; i++, list = list -> next);

    second->next = list->next;
    list->next = NULL;
}

