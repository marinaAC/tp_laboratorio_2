#ifndef FUNCIONES_H_INCLUDED
#define FUNCIONES_H_INCLUDED

typedef struct {

    char nombre[50];
    int edad;
    int estado;
    int dni;

}EPersona;


/**
 * Inicializa el array con un valor determinado.
 * @param Recibe como parametro el array de tipo de persona, más la cantidad del array y el valor
 * @param con el que se desea guardar.
 * @return no retorna nada.
 */
void inicializarListaInt(EPersona lista[],int cantidadPersonas,int valor);

/**
 * Obtiene el primer indice libre del array.
 * @param lista el array se pasa como parametro.
 * @return el primer indice disponible
 */
int obtenerEspacioLibre(EPersona lista[], int cantidadPersonas, int valor);

/**
 * Obtiene el indice que coincide con el dni pasado por parametro.
 * @param lista el array se pasa como parametro.
 * @param dni el dni a ser buscado en el array.
 * @return el indice en donde se encuentra el elemento que coincide con el parametro dni
 */
int buscarPorDni(EPersona lista[], int dni, int cantidadPersonas);

#endif // FUNCIONES_H_INCLUDED

/**
 * Obtiene el promedio de un array.
 * @param se envia el array como parametro y la cantidad maxima del array.
 * @return devuelve el resultado.
 */
float promedio (int numero[], int cantidad);

/**
 * Calcula el maximo de un array
 * @param se envia el array como parametro y la cantidad maxima del array.
 * @return devuelve el valor maximo de ese array.
 */
int max(int numero[], int cantidad);

/**
 * Calcula el minimo de un array
 * @param se envia el array como parametro y la cantidad maxima del array.
 * @return devuelve el valor minimo de ese array.
 */
int min(int numero[], int cantidad);

/**
 * Calcula el mnimo de un array y retorna el indice en el cual se encuentra ubicado ese minimo
 * @param se envia el array como parametro y la cantidad maxima del array.
 * @return devuelve el indice donde esta el valor minimo.
 */
int minIndice(int numero[], int cantidad);

/**
 * Dado el valor, el indice del cual se desea eliminar se corre el array hacia la siguiente posicion.
 * @param se envia el array como parametro, la cantidad maxima del array y el indice en el cual se quiere compactar.
 * @return retorna la cantidad-1.
 */
int compactar(int numero[], int cantidad, int eliminar);

/**
 * Se ordena de una forma que no es con el burbujeo, realizando una busqueda del indice menor, se guarda en otro array
 * y luego se compacta para poder obtener el array nuevo, ordenado sin el indice eliminado.
 * @param se envia el array como parametro, la cantidad maxima del array y el segundo array donde se van a guardar.
 * @return no retorna nada.
 */
void ordernar(int numero[], int cantidadArray,int array2[]);

/**
 * Este grupo de funciones, se encargan de trabajar con tipos flotantes, reciben dos valores
 * y ejecutan la operacion matematica pedida.
 * @param se envian por parametros dos numeros, salvo en el factorial que recibe solo uno
 * @return retornan el resultado.
 */
 float promedioUno(float numerosSumados,float cantidadDeVeces);
 float suma(float numero1, float numero2);
 float resta(float numero1, float numero2);
 float division(float numero1, float numero2);
 float multilicacion(float numero1, float numero2);
 float factorial(float numero);



 void validacionIngreso(int opcion);

 /**
  * Valida que los caracteres ingresados sean solo de tipo numerico
  * @param recibe el array de caracteres
  * @return retorna un 0 cuando es verdadero y un 1 cuando es falso.
 */
 int esNumerico(char num[]);

  /**
  * Valida que los caracteres ingresados sean solo letras
  * @param recibe el array de caracteres
  * @return retorna un 0 cuando es verdadero y un 1 cuando es falso.
 */
 int soloLetras(char palabra[]);

  /**
  * Valida que los caracteres ingresados sean solo letras y numeros
  * @param recibe el array de caracteres
  * @return retorna un 0 cuando es verdadero y un 1 cuando es falso.
 */
 int alfaNum(char palabra[]);

  /**
  * Valida que los caracteres ingresados sean alfanumericos y permite solo un guion
  * @param recibe el array de caracteres
  * @return retorna un 0 cuando es verdadero y un 1 cuando es falso.
 */
 int esTel(char tel[]);

 /**
  * Obtiene un caracter ingresado por teclado y lo retorna en una variable
  * @param recibe el mensaje que sale por pantalla.
  * @return devuelve el caracter ingresado para guardarlo en alguna variable.
 */
 char getChar(char mensaje[]);

  /**
  * Obtiene un numero flotante ingresado por teclado y lo retorna en una variable
  * @param recibe el mensaje que sale por pantalla.
  * @return devuelve el valor ingresado para guardarlo en alguna variable.
 */
 float getFloat(char mensaje[]);

  /**
  * Obtiene un entero ingresado por teclado y lo retorna en una variable
  * @param recibe el mensaje que sale por pantalla.
  * @return devuelve el entero ingresado para guardarlo en alguna variable.
 */
 int getInt(char mensaje[]);


/**
  * Funcion que se encarga de mostrar por pantalla un mensaje y guardarlo en un array de string
  * @param necesita un mensaje y el array donde se va a guardar lo escrito
  * @return no retorna nada
 */
 void getString(char mensaje[], char input[]);

/**
  * Funcion que se encarga de guardar lo escrito solo si son letras
  * @param el array con el mensaje, y el lugar donde se va a guardar el dato
  * @return no devuelve nada
 */
 int getStringSoloLetras(char mensaje[], char input[]);

 /**
  * Funcion que se encarga de guardar lo escrito solo si son numeros
  * @param el array con el mensaje, y el lugar donde se va a guardar el dato
  * @return no devuelve nada
 */
 int getStringSoloNum(char mensaje[], char input[]);

/**
  * Funcion necesaria para incilizar un array en un valor determinado
  * @param recibe el array a inicializar, la cantidad de lugares que tiene, y el valor a guardar
  * @return no devuelve nada.
 */
void inicializarArrayInt(int arrayDos[][3],int primerElemento,int segundoElemento,int valor);

/**
  * Realiza el grafico dependiendo de los valores guardados en la matriz de grafico
  * @param recibe el array una matriz y la cantidad de elementos, dependiendo de la cantidad de elementos
  * graficara lo que se encuentra guardado en la primera posicion de la matriz.
  * @return no devuelve nada.
 */
void graficar(int graf[][3],int cantidadElementos,int indiceMayor);

/**
  * Calcula el valor minimo de tres valores y retorna el menor
  * @param recibe tres elementos
  * @return retorna el valor mas chico.
 */
int indiceMinimo(int contadorPrimero,int contadorSegundo, int contadorTercero);

/**
  * Calcula el valor maximo de tres valores y retorna el menor
  * @param recibe tres elementos
  * @return retorna el valor mas grande.
 */
int indiceMaximo(int contadorPrimero,int contadorSegundo, int contadorTercero);
