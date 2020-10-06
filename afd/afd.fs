//Creacion de un ejemplo de F# Program Finite Automaton

(* *****************************************************************************
*  Nombre:  Diana
*  Apellidos:  Rodríguez Espiricueta
*  Especialidad:  ITI
*  Profesor de la materia:  Juan Carlos González Ibarra
*  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
*  Matricula:  170010
**************************************************************************** *)
//  Abrimos el sistema
open System
open System.Text.RegularExpressions 

//  Declaracion de variables
let mutable simbolo = " "
let mutable Fin = " "

//  Definición de la funcion caracter
let caracter ( character ) : int = 
    simbolo <- " "
    Fin <- " "
    let digito = "[0-9]"
    let operador = "(\+|\-|\*|\/)"

    //  Comparamos si es digito o operador
    if Regex.IsMatch ( character, digito ) then
        simbolo <- " Digito "
        0
    elif Regex.IsMatch ( character, operador ) then
        simbolo <- " Operador "
        1
    elif character = Fin then
        2
    else 
        printf "Error no es valido el caracter %A" character
        9

let body()=
    printfn "+---------------+------------+----------------+------------------+"

//  Definimos la funcion contenido, donde se guarda cada valor despues de encontrarlo en un ciclo
let contenido ( estadosig, character, simbolo, estado ) =
    printfn "|       %A       |    %A     |   %A   |        %A         |" estadosig character simbolo estado
//  Solo muestra la linea que se repetira cada vez que la mandemos a llamar
    body()


//  Definicion de la funcion del encabezado
let encabezado() =
    printfn "|  Edo. Actual  |  Caracter  |    Simbolo     |  Edo. Siguiente  |"
    body()


//MAIN
//tabla de transiciones del automata AFD creado 
let tabla = [ [ 1; 7; 7 ]; [ 1; 2; 7 ]; [ 3; 7; 7 ]; [ 3; 2; 200]]
let mutable estado = 0

printfn "         +------------------------------+ \n
         | Ingresa una cadena a evaluar | \n
         +------------------------------+"
let cadena = Console.ReadLine()
body()
encabezado()
let mutable charcaracter = 0

//  Se recorre la cadena
for character in cadena do
    let mutable estadosig = estado
    
    //  Llamamos al metodo para saber si es un caracter valido y el valor retornado se guarda en character 
    charcaracter <- caracter( string character )
    //  Guardamos en estado el valor obtenido en la tabla segun las coordenadas que recibio anteriormente
    estado <- tabla.[ estado ].[ charcaracter ]
    if( estado = 7 )then
        printfn "|       %A       |    %A     |  %A    |        %A         |" estadosig character simbolo estado
        body()
        printfn "|                       Cadena No Valida                         |"
        printfn "+----------------------------------------------------------------+"
    contenido( estadosig, character, simbolo, estado )

    //  Al concluir si el estado no es 3 que es el de aceptacion imprimimos cadena no valida
if( not ( estado.Equals( 3 ) ) ) then
    printfn "|                       Cadena No Valida                         |"
    printfn "+----------------------------------------------------------------+"

    //  Si el estado 3 es una cadena de aceptación
if( estado.Equals( 3 ) ) then
    printfn "|       %A       |            |   Fin Cadena   |                  |" estado
    body()
    printfn "|                  Cadena  Valida                                |"
    printfn "+----------------------------------------------------------------+"