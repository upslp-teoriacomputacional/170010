//  Programa para realizar diferentes operaciones de conjuntos como en matemáticas

(* *****************************************************************************
*  Nombre:  Diana
*  Apellidos:  Rodríguez Espiricueta
*  Especialidad:  ITI
*  Profesor de la materia:  Juan Carlos González Ibarra
*  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
*  Matricula:  170010
**************************************************************************** *)


//  Define tres conjuntos
let A = Set.ofSeq [ 1 .. 1.. 5 ]        //  Conjunto con "expresión de secuencia",
let B = Set.ofSeq [ 3 .. 1.. 7 ]        //  indica en que valor empieza y termina.
let C = Set.empty                   //  Creando un conjunto vacío usando Set.empty.

(* ------------------------------------------------ ---------
*  NOTA: Si desea crear una función que no tome ningún  
*  parámetro, la forma correcta de hacerlo es:
*       let hello () =
*           printfn "Hello world"
* ------------------------------------------------- --------*)

//  Pertenencia
let pertenencia () =                                                            
    let A = Set.ofSeq [ 1 .. 1.. 5 ]                                
    printfn "1 in A : %A" ( Set.contains 1 A )                      //  Set.contains -> Duvuelve verdadero si el
    printfn "10 in A : %A" ( Set.contains 10 A )                    //  elemento dado está en el conjunto dado.


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


//  Quitar un elemento al conjunto
let quitar () =                 
    let A = Set.ofSeq [ 0 .. 1.. 5 ]                               //  Set.remove -> Devuelve un nuevo conjunto
    printfn "The set after to delete : %A" ( Set.remove 2 A )      //  con el elemento dado eliminado. 


//  Quitar todos los elementos de un conjunto
let  clearSet () =                                                 
    let A = Set.ofSeq [ 0 .. 1.. 5 ]                               //  Set.empty.Remove -> Elimina todos los                
    printfn "The set clear: %A" ( Set.empty.Remove A )             //  elementos de un conjunto.


//  Copiar un conjunto
let copiar () =
    let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Debido a que no existe una operación para
    let B = Set.ofSeq A                                            //  copiar, se crea una variable y esta se 
    printfn "Set A = %A" A                                         //  iguala a la variable del conjunto que se
    printfn "compare set B = %A" B                                 //  quiere copiar.


//  Agregar un elemento
let agregar () =
    let B =  B.Add(987)                                            //  Add -> Devuelve un nuevo conjunto con un 
    printfn "The new set B = %A" B                                 //  elemento agregado al conjunto.


//  OPERACIONES DE CONJUNTO

//  Unión
let union () =
    let A = Set.ofSeq [ 1 .. 1.. 5 ]
    let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  Set.union -> Calcula la unión de los dos 
    printfn "The union = %A" ( Set.union A B )                     //  conjuntos. Tambien se pueden unir empleando
    printfn "The union = %A" ( A + B )                             //  el signo de adición (+).


//  Interseccion
let intereseccion () =
    let A = Set.ofSeq [ 1 .. 1.. 5 ]
    let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  Set.intersect -> Calcula la intersección   
    printfn "The intereseccion = %A" ( Set.intersect A B )         //  de los dos conjuntos.


//  Diferencia 
let diferencia () =
    let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Set.difference -> Devuelve un nuevo 
    let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  conjunto con los elementos del segundo
    printfn "The diference = %A" ( Set.difference A B )            //  conjunto eliminados del primero. Tambien se 
    printfn "The diference = %A" ( A - B )                         //  puede emplear el signo de sustracción (-).
                          

//  Diferencia simetrica 
let simetrica () =
    let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Dado que no existe una operacion para la 
    let B = Set.ofSeq [ 3 .. 1.. 7 ]                               //  diferencia simetrica, se aplica la union y
    let C = Set.empty                                              //  sustracción.
    printfn "The symmetric_differenc A^B= %A" ( ( A - B ) + ( B - A ) )
    printfn "The symmetric_differenc B^A= %A" ( ( B - A ) + ( A - B ) )
    printfn "The symmetric_differenc A^C= %A" ( ( A - C ) + ( C - A ) )
    printfn "The symmetric_differenc B^C= %A" ( ( B - C ) + ( C - A ) )


//  Subconjunto
let subconjunto () =                                                
    let B = Set.ofSeq [ 0 .. 1.. 9 ]                               
    let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Set.isSubset -> Se evalúa como verdadero si 
    printfn "The subset = %A" ( Set.isSubset A B )                 //  todos los elementos del primer conjunto 
    printfn "The subset = %A" ( Set.isSubset B A )                 //  están en el segundo.


//  Superconjunto
let superconjunto () =
    let B = Set.ofSeq [ 0 .. 1.. 9 ]
    let A = Set.ofSeq [ 1 .. 1.. 5 ]                               //  Set.isSuperset -> Se evalúa como verdadero 
    printfn "The superset = %A" ( Set.isSuperset B A )             //  si todos los elementos del segundo conjunto 
    printfn "The superset = %A" ( Set.isSuperset A B )             //  están en el primero.


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
