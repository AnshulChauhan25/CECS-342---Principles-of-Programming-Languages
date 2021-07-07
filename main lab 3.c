/*Anshul Chauhan
CECS 342
Assignment 3 in C language out of 5 languages
Due Date 4/8/2021
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//A distinct value represented for the data types
enum dataTypes {
    INT, FLOAT, STRING, PEOPLE, AGE
} type;

//Structure that creates the people data type which contains values A character name and integer age
typedef struct People {
    char *name;
    int age;
} People;


//This conatains 5 types of function that will help to pass and compare functions for sort function,  INT, FLOAT, STRING, PEOPLE, and AGE

  int compareFunction (const void *a, const void *b) {
    switch(type) {
      case INT:
        return (*(int*)a - *(int*)b);

      case FLOAT:
        return (*(float*)a - *(float*)b);

      case STRING:
        return strcmp(*(char**)a, *(char**)b);

//name & age compare are in the same structure type.
      case PEOPLE:
        return strcmp(((People*)a)->name,
                      ((People*)b)->name);

      case AGE:
        if (((People*)a)->age == ((People*)b)->age) {
          return strcmp(((People*)a)->name, ((People*)b)->name);
          
        }else{
          return ((People*)b)->age - ((People*)a)->age;
      }
    }
  }

//print function for all the data types float, integer, structure, string, character, we have to specify the types for old language like in C but in C's predecessors like C++ and C# we do not need to because it is already built in.

void print(void *list, int size){
  printf("\n");
  for(int x = 0; x < size; x++){
    switch(type) {
      case INT:
        printf(" %d\n", ((int*)list)[x]);
        break;
      case FLOAT:
        printf(" %.2f\n", ((float*)list)[x]);
        break;
      case STRING:
        printf(" %s\n", ((char**)list)[x]);
        break;
      case PEOPLE:
      case AGE:
        printf(" %s,%d\n", ((People*)list)[x].name, ((People*)list)[x].age);
        break;
      }
  }
  printf("\n");
}


int main(void) {

  // Sorting array of floating point values, Enumerated type set to FLOAT
  type = FLOAT;
  float numbers[] = { 645.41, 37.59, 76.41, 5.31, -34.23, 1.10, 1.11, 23.46, 635.47, -876.32, 467.83, 62.25 };
  int sizeFloat = (sizeof(numbers)/sizeof(numbers[0]));
  printf("\n");
  printf("-> List of unsorted Float Numbers: \n");
  print(numbers, sizeFloat);
  qsort(numbers, sizeFloat, sizeof(float), compareFunction);
  printf("-> List of sorted Float Numbers in ascending order:\n");
  print(numbers, sizeFloat);

  //array of People, structure
  type = PEOPLE;
  People person[] = { 
    {"Hal", 20}, 
    {"Susann", 31},
    {"Dwight", 19},
    {"Kassandra", 21}, 
		{"Lawrence", 25},
    {"Cindy", 22}, 
    {"Cory", 27}, 
    {"Mac", 19},
    {"Romana", 27}, 
    {"Doretha", 32},
    {"Danna", 20}, 
    {"Zara", 23}, 
    {"Rosalyn", 26}, 
    {"Risa", 24}, 
    {"Benny", 28},
    {"Juan", 33}, 
    {"Natalie", 25}
  }; 

  //Sorting array of People with name

  int sizePerson = (sizeof(person)/sizeof(person[0]));
  printf("-> Unsorted List of People: \n");
  print(person, sizePerson);
  qsort(person, sizePerson, sizeof(People), compareFunction);
  printf("\n");
  printf("-> List of Sorted People Alphabetically(Name): \n");
  print(person, sizePerson);

  //Sorting array of People with age, integer
  type = AGE;
  qsort(person, sizePerson, sizeof(People), compareFunction);
  printf("\n");
  printf("-> List of Sorted People in descending order(Age): \n");
  print(person, sizePerson);

  return 0;
}