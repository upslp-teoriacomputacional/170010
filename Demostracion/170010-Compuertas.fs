//  Programa en F# para realizar diferentes operaciones con operadores lógicos

(* *****************************************************************************
*  Nombre:  Diana
*  Apellidos:  Rodríguez Espiricueta
*  Especialidad:  ITI
*  Profesor de la materia:  Juan Carlos González Ibarra
*  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
*  Matricula:  170010
**************************************************************************** *)

// Comenzamos creando una lista con los dos posibles valores booleanos: false y true
let booleanos = [ false; true ]

(* ------------------------------------------------ ---------
*  NOTA: Para realizar la impresion de valores.
*
*  Cuando se usa el %A especificador, las cadenas se formatean con comillas. 
* Los códigos de escape no se agregan y en su lugar se imprimen los caracteres
* sin formato.      
* Los \t en la primera línea no son más que tabuladores.         
* ------------------------------------------------- --------*)

(* ------------------------------------------------ ---------
* En F #, y el operador evalúa el segundo operando si el primer operando es verdadero; 
* de lo contrario, devuelve falso sin verificar el segundo operando. También se lo 
* conoce como operador de cortocircuito.
* ------------------------------------------------ ---------*)

// Tabla de verdad de or
printfn "%A" ("x\t y\tx or y")
printfn ("-----------------------")                       
for x in booleanos do                                   // OR - Se usa el operador ||
    for y in booleanos do                               // Compara, devuelve el valor booleano true si uno o ambos
        printfn "%A\t%A\t%A" x y ( x || y )             // operandos es true y si no devuelve false.         

printfn "" 

// Tabla de verdad de and
printfn "%A" ("x\t y\tx and y")
printfn ("-----------------------")                     
for x in booleanos do                                   // AND - Se usa el operador &&
    for y in booleanos do                               // Devuelve true si ambos operandos son true y devuelve
        printfn "%A\t%A\t%A" x y ( x && y )             // false si no .                

printfn "" 

// Tabla de verdad de not
printfn "%A" ("x\tnot x")
printfn ("--------------")                              // NOT - Se usa el operador not
for x in booleanos do                                   // El operador not devuelve el valor opuesto al 
    printfn "%A\t%A" x ( not ( x ) )                         // valor booleano.

printfn "" 

// Tabla de verdad de ^
printfn "%A" ("x\ty\tx xor y")
printfn ("-----------------------")                     // XOR - Como no tiene operador, se le creo uno.
for x in booleanos do                                   // Una salida verdadera resulta si una, y solo una de las 
    for y in booleanos do                               // entradas a la puerta es verdadera.
        printfn "%A\t%A\t%A" x y ( ( x || y ) && not ( x && y ) ) 


