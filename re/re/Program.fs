//Creacion de un ejemplo de F# Regular Expresion (re)

(* *****************************************************************************
*  Nombre:  Diana
*  Apellidos:  Rodríguez Espiricueta
*  Especialidad:  ITI
*  Profesor de la materia:  Juan Carlos González Ibarra
*  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
*  Matricula:  170010
**************************************************************************** *)


open System                                                                //  Abrimos el sistema
open System.Text.RegularExpressions                                        //  Permite la ejecucion de regex expressions

let mutable tokens = []                                                    //  Para cadenas  tokens
let source_code = "int ponderacion = 8;".Split();                          //  Convierte el "código fuente" en una lista de palabras                           

for word in source_code do                                                 //  El loop recorre cada palabra de la lista

    if List.exists ((=)word) ["str"; "int"; "bool"] then                   //  Se comprobara si en la lista tokens hay este tipo de datos:
        tokens <- List.append tokens (["DATATYPE"; word])                  //  str, int y bool

    elif (Regex.IsMatch(word, "[A-Za-z]")) then                            //  Se busca dentro de la lista solo una palabra 
        tokens <- List.append tokens (["IDENTIFIER"; word])

    elif (Regex.IsMatch(word, "(\+|\-|\*|\/|\%|\=)")) then                 //  Se busca dentro de la lista si existe alguno de los operadores de
        tokens <- List.append tokens (["OPERATOR"; word])                  //  suma,resta,multiplicación ,división, modulo e igual

    elif (Regex.IsMatch (word, "[0-9]")) then                              //  Buscará elementos enteros y los convertirá como un número
        if word.[word.Length - 1] = ';' then
            tokens <- List.append tokens (["INTEGER"; word.[0..(word.Length-1)]])  //  Busca el simbolo ";" al final del estado una vez que
            tokens <- List.append tokens (["END_STATEMENT"; ";"])                  //  convierte los numeros, ya que estos llevan ese simbolo 
        else                                                               
            tokens <- List.append tokens (["INTEGER"; word])               // Sino, se trabaja con una palabra y no un numero

printfn "%A" tokens                                                        // Se imprime el codigo fuente 
    

(*let variablePROLOG( w : string) =
     if (Char.IsLetter(w.[0]) && Char.IsUpper(w.[0]) || w.[0] = '_') then 
         //  El primer caracter es una mayuscula o un subrayado
         w <- w.[1..(w.Length-1)]  //  Se quita el primer caracter
         while ( w && (Char.IsNumber w.[0] || w.[0] = '_')) do
             //  Mientras queden caracteres en "w" y el primer caracter actual sea un alfanumerico o un subrayado, todo esta bien
             w <- w.[1..(w.Length-1)]  // Se quita el primer caracter
         if (w == "") then
           //Si ya no quedan elementos a revisar, es una variable PROLOG
           return true
      return false *)
 

