# Programa en F# Automata finito

## Datos personales
* ___Nombre:___ Diana 
* ___Apellido:___ Rodríguez Espiricueta
* ___Especialidad:___ Ingenieria en Tecnologias de la Información (ITI)
* ___Nombre del profesor de la especialidad:___ Ibarra González Juan Carlos
* ___Nombre de la institución:___ Universidad Politecnica de San Luis Potosí
* ___Matrícula:___ 170010

## Descripción

<li>Dentro de los usos que se le pueden dar a las máquinas de estados, y en particular a los AFD, está el reconocimiento de cadenas. Para realizar este reconocimiento en forma precisa y automatizada, el mismo puede implementarse en cualquier lenguaje de programación.
 </li>
  <li>Será posible que habiendo diseñado un autómata que sea capaz de reconocer un conjunto de cadenas de un lenguaje, construir un programa que implemente dicho autómata en algún lenguaje de programación, a tal fin el Algoritmo de funcionamiento del programa puede ser obtenido a partir del AFD en forma directa. 
  </li>

Dentro de los usos que se le pueden dar a las máquinas de estados, y en particular a los AFD, está el reconocimiento de cadenas. Para realizar este reconocimiento en forma precisa y automatizada, el mismo puede implementarse en cualquier lenguaje de programación.
Será posible que habiendo diseñado un autómata que sea capaz de reconocer un conjunto de cadenas de un lenguaje, construir un programa que implemente dicho autómata en algún lenguaje de programación, a tal fin el Algoritmo de funcionamiento del programa puede ser obtenido a partir del AFD en forma directa.   
Para hacer uso de una expresion que me permita trabajar con un conjunto, utilizaré el siguiente modulo.

     open System.Text.RegularExpressions
     
la cual contiene clases que proporcionan acceso al motor de expresiones regulares .NET. El espacio de nombres proporciona una funcionalidad de expresión regular que se puede utilizar desde cualquier plataforma o lenguaje que se ejecute dentro de .NET.
  

## Codigo

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
            simbolo <- "Operador"
            1
        elif character = Fin then
            2
        else 
            printf "Error no es valido el caracter %A" character
            exit(9)

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
    let tabla = [ [ 1; 7; 7 ]; [ 7; 2; 7 ]; [ 3; 7; 7 ]; [ 7; 7; 9]]
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
            let estado = "E"
            printfn "|       %A       |    %A     |   %A   |        %A       |" estadosig character simbolo estado
            body()
            printfn "|                       Cadena No Valida                         |"
            printfn "+----------------------------------------------------------------+"
            exit(9)
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

## Problemas y soluciones

En el codigo establecido por el profesor dela materia, la tabla de transiciones del automata AFD creado es dada por la siguiente linea de codigo

    tabla=[[1,"E","E"],["E",2,"E"],[3,"E","E"],["E","E","A"]]

Pero en el caso de F#, no se pueden emplear numeros y letras en una lista, por lo que se opto por cambiar las letras por numeros, para poder llevar acabo la comparacion en esta lisla de listas.
    
    let tabla = [ [ 1; 7; 7 ]; [ 7; 2; 7 ]; [ 3; 7; 7 ]; [ 7; 7; 9]]

## Bibliografía 
Para realizar esta actividad se hizo uso de la siguiente bibliografia:

* Microsoft. 2020. F# | Functional Programming For .NET. [online] Available at: <https://dotnet.microsoft.com/languages/fsharp> [Accessed 20 September 2020].
