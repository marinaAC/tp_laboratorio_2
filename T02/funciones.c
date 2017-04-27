#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include "funciones.h"

float promedio (int numero[], int cantidad) {
    int suma=0;
    float resultadoProm;
    int i;
    for (i=0; i<cantidad;i++) {

        suma = suma + numero[i];

    }
    resultadoProm = (float)suma / cantidad;

    return resultadoProm;
}

int max(int numero[], int cantidad)
{
    int flag=0;
    int i;
    int max;
    for (i=0; i<cantidad; i++)
    {
        if (flag == 0)
        {
            flag = 1;
            max = numero[i];
        }

        if(numero[i]>max)
        {
            max = numero[i];
        }
    }
    return max;
}


int min(int numero[], int cantidad)
{
    int min;
    int i;
    int flag=0;

    for (i=0; i<cantidad; i++)
    {
        if (flag == 0){
            flag = 1;
            min = numero[i];
        }
        if (numero[i]<min){
            min = numero[i];
        }
    }
    return min;
}

int minIndice(int numero[], int cantidad)
{
    int minIndice, min;
    int i;
    int flag=0;

    for (i=0; i<cantidad; i++)
    {
        if (flag == 0){
            flag = 1;
            min = numero[i];
            minIndice=i;
        }
        if (numero[i]<min){
            min = numero[i];
            minIndice=i;
        }
    }
    return minIndice;
}

int compactar(int numero[], int cantidad, int eliminar){
    int i;
    for(i=eliminar;i<cantidad;i++){
        numero[i]=numero[i+1];
    }
    return cantidad-1;
}

void ordernar(int numero[], int cantidadArray,int array2[]){
    int indiceMenor;
    int iterar=cantidadArray;
    int i;
    for(i=0;i<iterar;i++){
        indiceMenor=minIndice(numero,cantidadArray);
        array2[i]=numero[indiceMenor];
        cantidadArray=compactar(numero,cantidadArray,indiceMenor);
    }
}


 float promedioUno(float numerosSumados,float cantidadDeVeces){
    float resultado;
    resultado = numerosSumados/cantidadDeVeces;
    return resultado;

}

float suma(float numero1, float numero2){
    float result;
    fflush(stdin);
    result = numero1 + numero2;
    return result;
}

float resta(float numero1, float numero2){
    float result;
    fflush(stdin);
    result = numero1 - numero2;
    return result;
}

float division(float numero1, float numero2){
    float result;
    fflush(stdin);
    while(numero2<=0){
        printf("No se puede realizar una division por 0 o menor a 0. Ingrese nuevos valor para el numero b: ");
        fflush(stdin);
        scanf("%f",&numero2);
    }
    result = numero1/numero2;
    return result;
}

float multilicacion(float numero1, float numero2){
    float result;
    fflush(stdin);
    result = numero1 * numero2;
    return result;
}

float factorial(float numero){
    float result=1.0;
    for(;numero>0;numero--){
        result = result*numero;
    }
    return result;
}

int esNumerico(char num[]){
    int i=0;
    while(num[i]!='\0'){
        if(num[i]<'0'||num[i]>'9'){
            return 0;
        }
        i++;
    }
    return 1;
}

int soloLetras(char palabra[]){
    int i = 0;
    while(palabra[i]!='\0'){
        if((palabra[i]!=' ')&&(palabra[i]<'a'||palabra[i]>'z')&&(palabra[i]<'A'||palabra[i]>'Z')){
            return 0;
        }
        i++;
    }
    return 1;
}

int alfaNum(char palabra[]){
    int i=0;
    while(palabra[i]!='\0'){
        if((palabra[i]!=' ')&&(palabra[i]<'a'||palabra[i]>'z')&&(palabra[i]<'A'||palabra[i]>'Z')&&(palabra[i]<'0'||palabra[i]>'9')){
            return 0;
        }
        i++;
    }
    return 1;
}

int esTel(char tel[]){
    int i=0;
    int contadorGuiones = 0;
    while(tel[i]!='\0'){
        if((tel[i]!=' ')&&(tel[i]!='-')&&(tel[i]<'0'||tel[i]>'9')){
            return 0;
        }
        if(tel[i]=='-'){
            contadorGuiones++;
        }
        i++;
    }
    if(contadorGuiones==1){
        return 1;
    }
    return 0;
}

int getInt(char mensaje[]){
    int buffer;
    printf(mensaje);
    fflush(stdin);
    scanf("%d",&buffer);
    return buffer;
}

float getFloat(char mensaje[]){
    float buffer;
    printf(mensaje);
    fflush(stdin);
    scanf("%f",&buffer);
    return buffer;
}

char getChar(char mensaje[]){
    char buffer;
    printf(mensaje);
    fflush(stdin);
    scanf("%c",&buffer);
    return buffer;
}

void getString(char mensaje[], char input[]){
    printf("%s",mensaje);
    fflush(stdin);
    scanf("%s",input);
}

int getStringSoloLetras(char mensaje[], char input[]){
    char aux[256];
    getString(mensaje,aux);
    if(soloLetras(aux)){
        strcpy(input,aux);
        return 1;
    }
    return 0;
}

int getStringSoloNum(char mensaje[], char input[]){
    char aux[256];
    getString(mensaje,aux);
    if(esNumerico(aux)){
        strcpy(input,aux);
        return 1;
    }
    return 0;
}

void inicializarListaInt(EPersona lista[],int cantidadPersonas,int valor){
    int i;
    for(i=0;i<cantidadPersonas;i++){
        lista[i].estado=valor;
    }
}

void inicializarArrayInt(int arrayDos[][3],int primerElemento,int segundoElemento,int valor){
    int i,j;
    for(i=0;i<primerElemento;i++){
        for(j=0;j<segundoElemento;j++){
            arrayDos[i][j]=valor;
        }
    }
}


int obtenerEspacioLibre(EPersona lista[], int cantidadPersonas, int valor){
    int i;
    for(i=0;i<cantidadPersonas;i++){
        if(lista[i].estado==valor){
            return i;
        }
    }
    return -1;
}

int buscarPorDni(EPersona lista[], int dni, int cantidadPersonas){
    int i;
    for(i=0;i<cantidadPersonas;i++){
        if(lista[i].dni==dni){
            return i;
        }
    }
    return -1;
}

void graficar(int graf[][3],int cantidadElementos, int indiceMayor){
    int i,j;
    for(i=0;i<cantidadElementos;i++){
        if(i==indiceMayor+1){
            break;
        }
        for(j=0;j<3;j++){
           if(graf[i][j]==1){
                printf("\t*");
            }
            if(graf[i][j]==0){
                printf("\t");
            }
        }
        printf("\n");
   }
}

int indiceMinimo(int contadorPrimero,int contadorSegundo, int contadorTercero){
    int auxMinimo;
    if(contadorPrimero<contadorSegundo){
        auxMinimo = contadorPrimero;
    }else{
        auxMinimo = contadorSegundo;
    }
    if(contadorTercero<auxMinimo){
        auxMinimo = contadorTercero;
    }
    return auxMinimo;
}

int indiceMaximo(int contadorPrimero,int contadorSegundo, int contadorTercero){
    int auxMaxima;
     if(contadorPrimero>contadorSegundo){
        auxMaxima = contadorPrimero;
    }else{
        auxMaxima = contadorSegundo;
    }
    if(auxMaxima<contadorTercero){
        auxMaxima = contadorTercero;
    }
    return auxMaxima;
}

