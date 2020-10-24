# Programa en F# Regular Expresion (re)

## Datos personales
* ___Nombre:___ Diana 
* ___Apellido:___ Rodríguez Espiricueta
* ___Especialidad:___ Ingenieria en Tecnologias de la Información (ITI)
* ___Nombre del profesor de la especialidad:___ Ibarra González Juan Carlos
* ___Nombre de la institución:___ Universidad Politecnica de San Luis Potosí
* ___Matrícula:___ 170010

## Descripción

En el siguiente codigo se nos nuestra a realizar un lexer básico pero, ¿qué hace el analizador léxico? El propósito de un lexer (analizador léxico) es escanear el código 
fuente y dividir cada palabra que lo compone en un elemento de una lista. 
Una vez hecho esto, toma estas palabras y crea un par en donde especifica el tipo y el valor al que pertenece el elemento, por ejemplo ` ['INTEGER', '178'] `.
Estos tokens se crean para identificar la sintaxis de su idioma, por lo que todo el objetivo del lexer es crear la sintaxis de su idioma, ya que todo depende de cómo 
desee identificar e interpretar los diferentes elementos de la lista.


## Codigo

**_Encabezado del codigo_**

     //Creacion de un ejemplo de F# Regular Expresion (re)

     (* *****************************************************************************
     *  Nombre:  Diana
     *  Apellidos:  Rodríguez Espiricueta
     *  Especialidad:  ITI
     *  Profesor de la materia:  Juan Carlos González Ibarra
     *  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
     *  Matricula:  170010
     **************************************************************************** *)

**_Iniciamos el sistema y definicion de variables_**

     open System                                                                //  Abrimos el sistema
     open System.Text.RegularExpressions                                        //  Permite la ejecucion de regex expressions

     let mutable tokens = []                                                    //  Para cadenas  tokens
     let source_code = "int ponderacion = 8;".Split();                          //  Convierte el "código fuente" en una lista de palabras                           

**_Comaparamos los elementos que conforman la lista_**

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

**_Imprimimos el codigo fuente con la identificacion de sus elementos_**

     printfn "%A" tokens                                                        // Se imprime el codigo fuente 

## Problemas y soluciones
Como la función variablePROLOG no tenia ninguna funcion el el codigo se opto por documentarla para que no afectara el funcionamiento del codigo

## Bibliografía 
Para realizar esta actividad se hizo uso de la siguiente bibliografia:

* Microsoft. 2020. F# | Functional Programming For .NET. [online] Available at: <https://dotnet.microsoft.com/languages/fsharp> [Accessed 23 October 2020].