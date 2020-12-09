# Programa en F# Automata de Pila a^nb^n

## Datos personales
* ___Nombre:___ Diana 
* ___Apellido:___ Rodríguez Espiricueta
* ___Especialidad:___ Ingenieria en Tecnologias de la Información (ITI)
* ___Nombre del profesor de la especialidad:___ Ibarra González Juan Carlos
* ___Nombre de la institución:___ Universidad Politecnica de San Luis Potosí
* ___Matrícula:___ 170010

**Este programa se hizo en colaboracion con Julieta Rodríguez Espiricueta (180024)**

## Descripción

Un autómata con pila, autómata a pila o autómata de pila es un modelo matemático de un sistema que recibe una cadena constituida por 
símbolos de un alfabeto y determina si esa cadena pertenece al lenguaje que el autómata reconoce.

En este caso se conto con un alfabeto de entrada de : {a,b}
y un alfabeto {1} para la pila

## Codigo

**_Encabezado del codigo_**

    //Creacion de un ejemplo de F# -> nfd
    (* *****************************************************************************
    *  Nombre:  Diana
    *  Apellidos:  Rodríguez Espiricueta
    *  Especialidad:  ITI
    *  Profesor de la materia:  Juan Carlos González Ibarra
    *  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
    *  Matricula:  170010

    ***Codigo eleborado con colaboracion de Julieta Rodríguez Espiricueta (180024)

    **************************************************************************** *)

**_Declaracion de variables_**

    //  Abrimos el sistema
    open System
    open System.Text.RegularExpressions 

    //  Declaracion de variables
    let mutable simbolo = " "
    let mutable Fin = " "
    let mutable contA = 0
    let mutable contB = 0
    let pila = ResizeArray<int>()//definicion del vector

**_validacion del alfabeto de entrada_**

    //  Definición de la funcion caracter
    let caracter ( character ) : int = 
        simbolo <- " "
        Fin <- " "
        let a = "a"         // El alfabeto del automata es a y b 
        let b = "b"

        //  Comparamos si es 'a' o 'b' 
        if Regex.IsMatch ( character, a ) then      // Si es una a, regresa un 0
            simbolo <- "    a   "
            contA <- contA+1
            0

        elif Regex.IsMatch ( character, b ) then    // Si es una a, regresa un 1
            simbolo <- "   b    "
            //pila.RemoveAt(1)                //remueve un valor
            contB <- contB+1
            1

        elif character = Fin then                   // Si es "" , regresa un 2
            2
        else 
            printf "Error no es valido el caracter %A" character  // Si es un caracter no valido, regresa un 3 y se sale
            exit(3)

**_Impresion de valores y tabla_**

    (*---------------
    // IMPRESIONES // 
    ---------------*)
    let body()=
        printfn "+---------------+------------+----------------+------------------+" //Impresion se linea de división

    //  Funcion contenido, donde se guarda cada valor despues de encontrarlo en el ciclo
    let contenido ( estadosig, character, simbolo, estado, pila ) =    
        printfn "|       %A       |    %A     |   %A   |        %A         |" estadosig character simbolo estado

        //  Solo muestra la linea que se repetira cada vez que la mandemos a llamar
        body()

    //  Definicion de la funcion del encabezado
    let encabezado() =
        printfn "|  Edo. Actual  |  Caracter  |    Simbolo     |  Edo. Siguiente  |"
        body()

**_Main y tabla de transiciones_**

    (*---------------
    //     MAIN    // 
    ---------------*)
    //  Tabla de transiciones del automata AFD creado 
    let tabla = [   //Estado    //Valores que acepta          
    [  0;  1; 2 ];  //0             a|b                         
    [  1;  2; 2 ];  //1             a|b                      
    [  2;  2; 2 ];  //2             a|b                      
    ] 

    let mutable estado = 0


    printfn "+------------------------------+ \n
    | Ingresa una cadena a evaluar | \n
    +------------------------------+"
    let caden = Console.ReadLine()
    let cadena = caden+" "
    body()
    encabezado()

**_Validaciones_**

    (*---------------
    // VALIDACIONES// 
    ---------------*)
    let mutable charcaracter = 0
    let mutable bandera = 0

    //  Se recorre la cadena
    for character in cadena do
        let mutable estadosig = estado
        pila.Add(1)           //añade a la pila un valor

        //  Llamamos al metodo para saber si es un caracter valido y el valor retornado se guarda en charcaracter 
        charcaracter <- caracter( string character )

        //  Guardamos en estado el valor obtenido en la tabla segun las coordenadas que recibio anteriormente
        estado <- tabla.[ estado ].[ charcaracter ]

        if( string character = "a" )then
            contenido( estadosig, character, simbolo, estado, pila )
            body()

        if( string character = "b" )then
            pila.RemoveAt(1)                //remueve un valor
            bandera <- 1
        contenido( estadosig, character, simbolo, estado, pila )

        if(string character = "a" && bandera = 1)then
            printfn "|       %A       |            |   Fin Cadena   |                  |" estado 
            body()
            printfn "|                  Cadena no Valida                                |"
            printfn "+----------------------------------------------------------------+"   
            exit(3)


    //  Al concluir si el estado no es 3 que es el de aceptacion imprimimos cadena no valida
    if( not ( contA.Equals( contB ) ) ) then 
        printfn "|       %A       |            |   Fin Cadena   |                  |" estado 
        body()
        printfn "|                  Cadena no Valida                                |"
        printfn "+----------------------------------------------------------------+"

    //  Si el estado 3 es una cadena de aceptación
    if( contA.Equals( contB ) ) then
        printfn "|       %A       |            |   Fin Cadena   |                  |" estado
        body()
        printfn "|                  Cadena  Valida                                |"
        printfn "+----------------------------------------------------------------+"


## Problemas y soluciones

En el automata establecido por el profesor de la materia, para la expresion regular ` a^nb^n ` 
Entonces para resolverlo se tuvo que proponer diversas validaciones que permitieran validar que la misma cantidad de a ingresadas, fueran igual al numero de b's ingresadas,
ademas de que se tenia que validar de que fueran cadenas de ` ab, aabb, aaabbb ... ` donde no se pudieran combinar o "intercalar ambos valores"
Ademas la impresion de la cadena no se puso, debido a que su grafico no era bueno, pero si esta implementada en el codigo como tal.

## Bibliografía 
Para realizar esta actividad se hizo uso de la siguiente bibliografia:

* Microsoft. 2020. F# | Functional Programming For .NET. [online] Available at: <https://dotnet.microsoft.com/languages/fsharp> [Accessed 12 de November 2020].
