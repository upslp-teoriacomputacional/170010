# Programa en F# para ilustrar diferentes operaciones de conjuntos

## Datos personales
* ___Nombre:___ Diana 
* ___Apellido:___ Rodríguez Espiricueta
* ___Especialidad:___ Ingenieria en Tecnologias de la Información (ITI)
* ___Nombre del profesor de la especialidad:___ Ibarra González Juan Carlos
* ___Nombre de la institución:___ Universidad Politecnica de San Luis Potosí
* ___Matrícula:___ 170010

## Objetivos
_El siguiente programa se encuentra en el lenguaje de programacion F#, y tiene como objetivos los siguientes:_
* Comprender la sintaxis de este nuevo lenguaje de programacion para cumplir con los siguientes puntos:
* Realizar las diferentes operaciones de conjunto como en matemáticas, las cuales son: Union, intersección, diferencia, diferencia simétrica, subconjunto y superconjunto.
* Comprender las diferentes funciones que definen a un conjunto dentro del lenguaje F#, las cuales pueden ser el transformar colecciones/listas a conjuntos, remover un elemento en especifico, copiar un conjunto, vaciar un conjunto en su totalidad, etc.  

## ¿Cómo se cumplieron los objetivos?
Se cumplieron mediante el análisis e investigación del lenguaje F# en diferentes medios de comunicación, entre los que destacan los sitios web de Microsoft (https://dotnet.microsoft.com/languages/fsharp) y el sitio oficial del lenguaje (https://fsharp.org/learn/).

Además de la implementación de las diferentes operaciones básicas de conjuntos que ofrece la programación en F# mediante sus métodos del objeto Set, como lo son:
* Set.add
* Set.contains
* Set.difference
* Set.empty
* Etc. 

## Código
Como datos importantes, programar en F# significa utilizar la programación funcional, la cual se destaca por los siguientes puntos
* Funciona como construcciones principales que se usan
* Expresiones en lugar de instrucciones
* Valores inmutables en variables
* Programación declarativa a través de la programación imperativa
* Uso de tabulaciónes en lugar de llaves
* Se deja de implementar el uso de punto y coma ( ; ) al final de la linea de código


### _Datos personales en el codigo_
En esta parte del codigo se documento con los datos personales de su servidora, asi como los datos del profesor y la institución.

    // Programa para realizar diferentes operaciones de conjuntos como en matemáticas

    (* ********************************************** *****************************
    * Nombre: Diana
    * Apellidos: Rodríguez Espiricueta
    * Especialidad: ITI
    * Profesor de la materia: Juan Carlos González Ibarra
    * Institución: Universidad Politécnica de San Luis Potosí (UPSLP) 
    * Matrícula: 170010
    *********************************************** ************************** *)
### _Creacion de tres conjuntos_
Se crean conjuntos con su respectiva sintaxis a los cuales se les agrega la palabra clave `let`, la cual sirve para vincular un nombre a un valor o función.

    //  Define tres conjuntos
    let A = Set.ofSeq [ 1 .. 1.. 5 ]        //  Conjunto con "expresión de secuencia",
    let B = Set.ofSeq [ 3 .. 1.. 7 ]        //  indica en que valor empieza y termina.
    let C = Set.empty                   //  Creando un conjunto vacío usando Set.empty.
    
### _Creación de las funciones con las diferentes operaciones de los conjuntos_
Se aclara la forma correcta de definir una función.

    (* ------------------------------------------------ ---------
    *  NOTA: Si desea crear una función que no tome ningún  
    *  parámetro, la forma correcta de hacerlo es:
    *       let hello () =
    *           printfn "Hello world"
    * ------------------------------------------------- --------*)

### _Función "pertenencia()"_
Uso del método `Set.ofSeq` para comprobar si un elemento dado pertenece a un conjunto en especifico.

    //  Pertenencia
    let pertenencia () =                                                            
        let A = Set.ofSeq [ 1 .. 1.. 5 ]                                
        printfn "1 in A : %A" ( Set.contains 1 A )                      //  Set.contains -> Duvuelve verdadero si el
        printfn "10 in A : %A" ( Set.contains 10 A )                    //  elemento dado está en el conjunto dado.

### _Función "transformarConj()"_
Uso del método `Set.ofList` el cual permite crear un conjunto de una lista dada

    //  Convertir a un conjunto
    let transformarConj () =        
        let A = [ 1 .. 3 ]             //  Declaración de una lista
        let conjuntoA = Set.ofList A                                    //  Set.ofList -> Crea un conjunto que contiene 
        printfn "The set A is : %A" ( Set.ofList A )                    //  los mismos elementos que la lista dada.
        let B = [ 1 .. 5 ]
        let conjuntoB = Set.ofList B
        printfn "The set B is : %A" conjuntoB
        let conjuntoC = Set.ofSeq ( "Hola mundo" )
        printfn "The set C is : %A" conjuntoC

### _Función "quitar()"_
Uso del método `Set.remove` el cual permite eliminar un elemento especifico de un conjunto dado, la sintaxis muestra que después de escribir el método se procede a colocar el número que se desea eliminar seguido del conjunto del que se quiere eliminar; en caso de no encontrar el elemento no sucede nada.

    //  Quitar un elemento al conjunto
    let quitar () =                 
        let A = Set.ofSeq [ 0 .. 1.. 5 ]                               //  Set.remove -> Devuelve un nuevo conjunto
        printfn "The set after to delete : %A" ( Set.remove 2 A )      //  con el elemento dado eliminado. 

### _Función "clearSet()"_
Uso del método `Set.empy.Remove`. Aquí se hizo uso de dos métodos, ya que no existe un método para borrar todos los elementos de un conjunto. 
Se indica que del conjunto A se remueven todos los elementos y se deja vacío.

    //  Quitar todos los elementos de un conjunto
    let  clearSet () =                                                 
        let A = Set.ofSeq [ 0 .. 1.. 5 ]                               //  Set.empty.Remove -> Elimina todos los                
        printfn "The set clear: %A" ( Set.empty.Remove A )             //  elementos de un conjunto.

### _Función "copiar()"_
Uso del método `Set.ofSeq` para crear un conjunto que contenga los valores de un conjunto dado.

    //  Copiar un conjunto
    let copiar () =
        let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Debido a que no existe una operación para
        let B = Set.ofSeq A                                            //  copiar, se crea una variable y esta se 
        printfn "Set A = %A" A                                         //  iguala a la variable del conjunto que se
        printfn "compare set B = %A" B                                 //  quiere copiar.

### _Función "agregar()"_
Uso del metodo `.add`, el cual permite agregar un elemento nuevo a un conjunto dado.

    //  Agregar un elemento
    let agregar () =
        let B =  B.Add(987)                                            //  Add -> Devuelve un nuevo conjunto con un 
        printfn "The new set B = %A" B                                 //  elemento agregado al conjunto.


    //  OPERACIONES DE CONJUNTO

### _Función "union()"_
Uso del método `Set.union` que permite unir los conjuntos que se le indiquen a dicho metodo, además se puede hacer uso del signo de la adicción para realizar tal acción.

    //  Unión
    let union () =
        let A = Set.ofSeq [ 1 .. 1.. 5 ]
        let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  Set.union -> Calcula la unión de los dos 
        printfn "The union = %A" ( Set.union A B )                     //  conjuntos. Tambien se pueden unir empleando
        printfn "The union = %A" ( A + B )                             //  el signo de adición (+).

### _Función "interseccion()"_
Uso del método `Set.intersect` que permite calcular la intersección de dos conjuntos.

    //  Interseccion
    let intereseccion () =
        let A = Set.ofSeq [ 1 .. 1.. 5 ]
        let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  Set.intersect -> Calcula la intersección   
        printfn "The intereseccion = %A" ( Set.intersect A B )         //  de los dos conjuntos.

### _Función "diferencia()"_
Uso del método `Set.difference` para permitir calcular la diferencia entre dos conjuntos, a su vez se puede hacer uso del signo de la sustracción para realizar tal acción. 

    //  Diferencia 
    let diferencia () =
        let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Set.difference -> Devuelve un nuevo 
        let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  conjunto con los elementos del segundo
        printfn "The diference = %A" ( Set.difference A B )            //  conjunto eliminados del primero. Tambien se 
        printfn "The diference = %A" ( A - B )                         //  puede emplear el signo de sustracción (-).

### _Función "simetrica()"_
En este caso se hizo uso de las técnicas de unión y sustraccion, debido a que no existe un metodo para realizar tal acción.

    //  Diferencia simetrica 
    let simetrica () =
        let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Dado que no existe una operacion para la 
        let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  diferencia simetrica, se aplica la union y
        let C = Set.empty                                              //  sustracción.
        printfn "The symmetric_differenc A^B= %A" ( ( A - B ) + ( B - A ) )
        printfn "The symmetric_differenc B^A= %A" ( ( B - A ) + ( A - B ) )
        printfn "The symmetric_differenc A^C= %A" ( ( A - C ) + ( C - A ) )
        printfn "The symmetric_differenc B^C= %A" ( ( B - C ) + ( C - A ) )

### _Función "subconjunto()"_
Uso del método `Set.isSubset` para indicar si existe este tipo de relación entre los dos conjuntos. Regresa un True o False

    //  Subconjunto
    let subconjunto () =                                                
        let B = Set.ofSeq [ 0 .. 1.. 9 ]                               
        let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Set.isSubset -> Se evalúa como verdadero si 
        printfn "The subset = %A" ( Set.isSubset A B )                 //  todos los elementos del primer conjunto 
        printfn "The subset = %A" ( Set.isSubset B A )                 //  están en el segundo.

### _Función "superconjunto()"_
Uso del método `Set.isSuperset` para indicar si existe este tipo de relación entre los dos conjuntos. Regresa un True o False

    //  Superconjunto
    let superconjunto () =
        let B = Set.ofSeq [ 0 .. 1.. 9 ]
        let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Set.isSuperset -> Se evalúa como verdadero 
        printfn "The superset = %A" ( Set.isSuperset B A )             //  si todos los elementos del segundo conjunto 
        printfn "The superset = %A" ( Set.isSuperset A B )             //  están en el primero.

### _Llamado a las funciones_
Se realiza el lladado de las funciones mediante la sintaxis `System.Console.WriteLine( nombre_Funcion () )`

    (* ------------------------------------------------ ---------
    *  Llamado a las funciones
    * ------------------------------------------------- --------*)
    System.Console.WriteLine( pertenencia () )
    System.Console.WriteLine( transformarConj () )
    System.Console.WriteLine( quitar () )
    System.Console.WriteLine( clearSet () )
    System.Console.WriteLine( copiar () )
    System.Console.WriteLine( agregar () )
    System.Console.WriteLine( union () )
    System.Console.WriteLine( intereseccion () )
    System.Console.WriteLine( diferencia () )
    System.Console.WriteLine( simetrica () )
    System.Console.WriteLine( subconjunto () )
    System.Console.WriteLine( superconjunto () )

## Problemas y soluciones
Uno de los principales problemas que se presentaron a la hora de codificar el programa anterior fue que se desconocía por completo el tipo de sintaxis con la que se tenía que trabajar con F#, lo que provoco que se tuviera problemas en averiguar distintos puntos del mismo, por ejemplo, el mayor problema que presente fue al momento de crear las funciones ya que en la guías de consulta del lenguaje solo me mostraban ejemplos de la creación de funciones mediante el envió de parámetros, donde se utiliza una sintaxis igual a la siguiente:
    
    //Declaracion de una funcion en F#      
        let [inline] function-name parameter-list [ : return-type ] = function-body
    
Pero no mostraba como declarar una función que no recibía parámetros, fue por lo que en un momento llegue a cometer el error de declarar una función de la siguiente manera:

    let hello =  // This is a value, not a function
      printfn "Hello world"

Y esto está mal debido a que, si no coloco los paréntesis adelante del nombre de la función, no estaría declarando una función, estaría declarando una variable.
Por lo que la declaración correcta de una función que no recibe parámetros en F# es la siguiente:

    let hello () =
      printfn "Hello world"
      
      
Además de la problemática presentada anteriormente, se tuvo algunos problemas con la implementación de los métodos de la clase Set, ya que se desconocía su sintaxis, pero dichas dudas quedaron resueltas una vez que se consultó la bibliografía adjunta a continuación.


## Bibliografía
* Docs.microsoft.com. 2020. Functions - F#. [online] Available at: <https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/> [Accessed 15 September 2020].
* Microsoft. 2020. F# | Functional Programming For .NET. [online] Available at: <https://dotnet.microsoft.com/languages/fsharp> [Accessed 15 September 2020].
* Riptutorial.com. 2020. F# - Fundamentos De Funciones | F# Tutorial. [online] Available at: <https://riptutorial.com/es/fsharp/example/8352/fundamentos-de-funciones> [Accessed 15 September 2020].
* Tutorialspoint.com. 2020. F# - Sets - Tutorialspoint. [online] Available at: <https://www.tutorialspoint.com/fsharp/fsharp_sets.htm> [Accessed 15 September 2020].
