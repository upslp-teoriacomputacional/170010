// Comprobacion para saber si una palabra es un Palindromo en F#

(* *****************************************************************************
*  Nombre:  Diana
*  Apellidos:  Rodríguez Espiricueta
*  Especialidad:  ITI
*  Profesor de la materia:  Juan Carlos González Ibarra
*  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
*  Matricula:  170010
**************************************************************************** *)

open System                                                     //  Abrimos el sistema

let array = ResizeArray<char>()                                 //  Definicion del arreglo
let palindromo = "anitalavalatina";                             //  Palindromo *se escribe todo junto

let cadena = palindromo.ToCharArray();                          //  Se convierte el palindromo en un arreglo
let tamaño = palindromo.Length;                                 //  Tamaño de la cadena/palindromo *es 15 en este ejemplo

printf "\n %A" cadena                                           //  Imprimimos el polindromo 

let mitad = tamaño/2                                            //  Mitad del arreglo *es 7 en este ejemplo

let mutable cont = 0;                                           //  Contador que sirve para contar las coincidencias de letras

if mitad*2 = tamaño then                                        //  Si la mitad del arreglo * 2 es igual al tamaño del arreglo *7x2 = 15
    printfn "\n NO ES UN PALINDROMO"                            //  No es un palindromo porque su tamaño es par
else                                                            //  Sino
    printfn "\n La palabra ingresada puede ser un palindromo"   //  Puede ser palindromo porque su tamaño es impar
    printfn "\nComprobamos:"                                    //  Si su tamaño es impar, comprobamos si es o no palindromo
    

   //NOTA: El arreglo se lee de 0 a tamaño-1

    for i=0 to mitad do                                         //  Se recorre hasta la mitad del arreglo                        
        if(cadena.[i].Equals(cadena.[(tamaño-1)-i])) then       //  Si la primer posicion es igual a la ultima posición
            cont <- cont + 1                                    //  Se aumenta el contador
            printfn "posicion[%A] = %A <=> posicion[%A] = %A" i cadena.[i] ((tamaño-1)-i) cadena.[(tamaño-1)-i]   //Se imprimer las coincidencias de caracteres

    if cont = mitad+1 then                                      //  Si el numero de coincidencias de letras del arreglo es igual a la mitad del tam del arreglo
        printfn "\n ES UN PALINDROMO"                           //  Es un palindromo
    else                                                        //  Sino
        printfn "NO ES UN PALINDROMO"                           //  No es palindromo
             





