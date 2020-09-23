# Programa en F# para ilustrar diferentes operaciones de la tabla de verdad

## Datos personales
* ___Nombre:___ Diana 
* ___Apellido:___ Rodríguez Espiricueta
* ___Especialidad:___ Ingenieria en Tecnologias de la Información (ITI)
* ___Nombre del profesor de la especialidad:___ Ibarra González Juan Carlos
* ___Nombre de la institución:___ Universidad Politecnica de San Luis Potosí
* ___Matrícula:___ 170010

## Descripción
Los operadores lógicos básicos son O, Y y NO y son representados en el lenguaje de programación F# por or ( || ), and ( && ) y not, respectivamente.
Entre los operadores lógicos basicos tambien podemos incluir el O EXCLUSIVO, que es verdadero cuando uno y solo uno de los operandos lo es; no cuenta con
un operador como tal en el lenguaje F# por lo que pero se deriva a partir de los tres básicos anteriores.

## Codigo

### _Creacion de una lista con valores booleanos_
Como primer punto se declara una lista con los dos posibles valores booleanos: False y True, notamos que estos se encuentran en minusculas y separados mediante punto y coma (;).

    let booleanos = [ false; true ]
    
### _Sintaxis para comparar las posibles combinaciones de False y True_
Para comparar las posibles combinaciones de los boleanos False y True se hace uso de una doble iteración usando el bucle for.

    Ejemplo:
    for x in booleanos do                                   
      for y in booleanos do                               
        printfn "%A\t%A\t%A" x y ( x || y )             


### _Sintaxis que se emplea para los operadores básicos_

_Tabla de verdad de OR_

Observamos que para realizar la comparación de tipo Or se emplea el operador `||`

    printfn "%A\t%A\t%A" x y ( x || y )  

_Tabla de verdad de AND_         

Observamos que para realizar la comparación de tipo AND se emplea el operador `&&`

    printfn "%A\t%A\t%A" x y ( x && y )
    
_Tabla de verdad de NOT_           

Observamos que para realizar la comparación de tipo NOT se emplea el operador `not`

    printfn "%A\t%A" x ( not ( x ) )
    
_Tabla de verdad de XOR_ 

Observamos que para realizar la comparación de tipo XOR, este no tiene un operador como tal en el leguage F#, por lo que se opta por realizar su equivalente haciendo uso de 
los 3 operadores basicos anteriores con los que trabaja el lenguaje.

    printfn "%A\t%A\t%A" x y ( ( x || y ) && not ( x && y ) )

## Problemas y soluciones
Como se mencionó anteriormente, en el lenguaje F# no se cuanta con el operador de XOR, por lo que para poder llevar acabo esta comparación, se tiene que hacer uso de los 3 
operadores basicos con los que cuenta el lenguaje: OR, AND y NOT, para poder crear una equivalencia de este operador como se muestra a continuación:

    printfn "%A" ("x\ty\tx xor y")
    printfn ("-----------------------")                     
    for x in booleanos do                                  
      for y in booleanos do                               
        printfn "%A\t%A\t%A" x y ( ( x || y ) && not ( x && y ) ) 

## Bibliografía 
Para realizar esta actividad se hizo uso de la siguiente bibliografia:

* Microsoft. 2020. F# | Functional Programming For .NET. [online] Available at: <https://dotnet.microsoft.com/languages/fsharp> [Accessed 20 September 2020].
* Microsoft. 2020. F# | Boolean Operators [online] Available at: <https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/boolean-operators> [Accessed 20 September 2020].



