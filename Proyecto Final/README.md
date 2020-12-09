## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez, Diana Rodriguez Espiricueta
* Matricula: 170011, 170010
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra

## Objetivo
De la materia de tecnologias de la información se realizo un proyecto
en donde se involucren los temas necesarios para el desarrollo.
Se realizo un analizador lexico para el lenguaje C, en donde se utilizaron temas como 
expresiones regulares, AFD y AFND, que a continuación se vera en el código.

Para poder ejecutarlo es necesario contar con un archivo txt y colocar la ubicacion de este en la 
linea que se muestra a continuación:
```
// Read in a file with StreamReader.
        use stream = new StreamReader @"C:\Users\admon\Desktop\Proyecto Teoria\LeerArchivo\ejemplo.txt"
```
es aqui en conde se colocara el código a analizar. Debe estar escrito con un espacio de separacion 
cada una de las palabras, caracters o conjunto de caracteres.

## Código
Utilizamos pilas para poder guardar los tokens y sus lexemas, asi como algunos contadores auxiliares
```
let mutable tokenC = ResizeArray<string>()//cuando es correcta la entrada
let mutable tokenI = ResizeArray<string>()//cuando es incorrecta la entrada
let mutable lexemaC = ResizeArray<string>()//cuando es correcta la entrada
let mutable lexemaI = ResizeArray<string>()//cuando es incorrecta la entrada
let mutable clinea = ResizeArray<int>()
let mutable cont=0;//contador para los ingresos correctos
let mutable contI=0;//contador para los ingresos incorrectos
```
Funciones 
* guardar los tokens correctos
* guardar los tokens incorrectos
* imprimir los tokens incorrectos
* imprimir los tokens correctos
* imprimir el encabezado de las tablas 

```
let tokenCorrecto(cadena, lexem)=   //funcion que guarda en una pila los tokens correctos
    tokenC.Add(cadena)  //guarda la palabra
    lexemaC.Add(lexem)  //guarda el lexema
    cont<-cont+1        //aumenta el contador

let tokenIncorrecto(cadena,lexem,linea)=  //funcion que guarda en una pila los tokens incorrectos
    tokenI.Add(cadena)  //guarda la palabra
    lexemaI.Add(lexem)  //guarda el lexema
    clinea.Add(linea)
    contI<-contI+1      //aumenta el contador
    
let imprimirCorrecto()=     //funcion para imprimir los tokens correctos
    
    for i=0 to cont-1 do        //utiliza el contador de correctos para poder verificar cuantos hay
        Console.ForegroundColor<-ConsoleColor.White     //cambia de color de letra a blanca
        printfn "\t\t %A \t|\t %A\t" tokenC.[i] lexemaC.[i]     //imprime la palabra y el lexema separados por tabulaciones y una linea
        Console.ForegroundColor<-ConsoleColor.Cyan      //cambia el color de impresion a cyan
        printfn"\t+------------------------------------------------------+"//funciona como separador
    //tokenC |> Seq.iter (fun x -> printf "%A;" x)//impresion del vector

let imprimirIncorrecto()=       //funcion para imprimir los tokens incorrectos
    
    for i=0 to contI-1 do            //utiliza el contador de incorrectos para poder verificar cuantos hay
        Console.ForegroundColor<-ConsoleColor.White//cambia de color de letra a blanca
        printfn "\t\t %A \t|\t %A\t|\t %A\t" tokenI.[i] lexemaI.[i] clinea.[i]//imprime la palabra y el lexema separados por tabulaciones y una linea
        Console.ForegroundColor<-ConsoleColor.Red            //cambia el color de impresion a rojo
        printfn"\t+--------------------------------------------------------------------+"//funciona como separador
    //tokenI |> Seq.iter (fun x -> printf "%A;" x)//impresion del vector

let imprimeCabeza()=        //funcion que imprime los encabezados de ambas 
    Console.ForegroundColor<-ConsoleColor.White //cambia el color de impresion a blanco
    printfn"\t\nTokens de las entradas\n"
    Console.ForegroundColor<-ConsoleColor.Blue  //cambia el color de impresion a azul
    printfn"\t+--------------------------------------------------------------------+"//funciona como separador
    Console.ForegroundColor<-ConsoleColor.White //cambia el color de impresion a blanco
    printfn"\t\t TOKEN \t\t|\t LEXEMA \t|\t LINEA \t"                       //impresion de los encabezados
    Console.ForegroundColor<-ConsoleColor.Blue  //cambia el color de impresion a azul
    printfn"\t+--------------------------------------------------------------------+"//funciona como separador
    Console.ForegroundColor<-ConsoleColor.White //cambia el color de impresion a blanco
```
leer de un archivo de texto se baso en un codigo igual al siguiente, en donde
se le tiene que agregar la ubicación del archivo

```
open System.IO

type Data() =
    member x.Read() =
        // Read in a file with StreamReader.
        use stream = new StreamReader @"C:\Users\admon\Desktop\Proyecto Teoria\LeerArchivo\ejemplo.txt"

        // Continue reading while valid lines.
        let mutable valid = true
        let mutable token=""
        
        while (valid) do
            let line = stream.ReadLine()
            if (line = null) then
                valid <- false
            else
                // Display line.
                printfn "%A" line
                token<-token + " " + line
                let mutable cadena=line.Split();
                for word in cadena do
                    if word.Equals("int")then
                        printfn"%A Palabra Reservada"word
                    if word.Equals("=")then
                        printfn"%A asignación "word    
        printfn "%A"token
     
// Create instance of Data and Read in the file.
let data = Data()
data.Read()
```
para poder revisar cada entrada se utilizaron sentencias listas con las palabras y caracteres
```
let reservada=["auto";"const";"enum";"goto";"else";"sizeof";"register";"unsigned";
                       "break";"continue";"extern";"if";"return";"static";"switch";"void";
                       "case";"default";"float";"int";"short";"struct";"typedef";"volatile";
                       "char";"do";"for";"long";"signed";"double";"union";"while";"print"];
        let delim=["[";"]";"(";")";"{";"}";";";",";":";"*"];
        let operaComp=["==";"!=";">=";"<=";">";"<"];
        let operaArit=["++";"--"];
        let operaBool=["and";"or";"&&";"||"]
        let operaAsig=["*=";"/=";"%=";"+=";"-=";"<<=";">>=";"&=";"^=";"|="];
        let operador=["+";"-";"*";"/";"%";"="]
```
algunas variables booleanas auxiliares y para el lexema, y para poder ver en que linea se encuentra
el error
```
	let mutable aux:bool=false;//verificar que sea palabra reservada o no
        let mutable aux2:bool=false;    //que entre o no entre a verificar si es operador o delimitador
        let mutable aux4:bool=false;    //dar a conocer si es o no un comentario
        let mutable auxtoken:bool=false;    //saber si es un token correcto o incorrecto
        let mutable aux5:bool=true;         //verificar lineas vacias
        //uso de las funciones para especificar que tipo es la entrada
        let mutable lexem="";
        //PARA VER EN QUE LINEA SE EQUIVOCO
        let mutable clinea=0

        // Continue reading while valid lines.
        let mutable valid = true
```
y con estas listas se revisaba cada palabra de ingreso, asicomo las expresiones regulares
```
while (valid) do
            let line = stream.ReadLine()//lee la linea y lo guarda EN LINE
            if (line = null) then       //SI  ES NULL  estado final
                valid <- false //manda a while un false
            else                //caso contrario trabaja con la linea
                // Display line.
                //printfn "%A" line
                clinea<-clinea+1
                lexem<-""       //inicializa la variable
                aux5<-true//inicializa la variable
                let cadena2=line        //cadena2 toma el valor de linea
                let cadena = cadena2.Split();//tambien toma el valor de la linea pero ahora separa cada palabra
                
                //comentarios
                let comentarios=cadena2.ToCharArray();      //variable toma el valor de cadena2 y lo guarda en un arreglo de caracteres
                //printf"%A"comentarios
                if line.Equals("")then//verifica las lineas vacias y no se cree un error
                    aux5<-false

                let aux3=cadena2.Length//auxiliar ayuda a tomar el tamaño de la cadena2
                if aux5.Equals(true) then
                    //printfn"%A %A %A" comentarios.[0] comentarios.[aux3-1] aux3
                    if (comentarios.[0]).Equals('/')  then//utilizamos variable comentario para revisar su primer caracter
                        if (comentarios.[1]).Equals('/') then//y el segundo
                            //printfn"es un comentario"
                            aux4<-true  //coloca el auxiliar en true para dar a conocer que es un comentario
                        elif (comentarios.[1]).Equals('*') && ((comentarios.[aux3-1]).Equals('/') && (comentarios.[aux3-2]).Equals('*'))then//el segundo caracter y los dos ultimos
                            //printfn "Es un comentario"
                            aux4<-true //coloca el auxiliar en true para dar a conocer que es un comentario
                        lexem<-"Comentario" //el lexema es comentario
                        tokenCorrecto(cadena2,lexem)//manda el token y el lexema a la funcion de tokens correctos
                    else
                        aux4<-false//si no es un comentario lo coloca en falso
                
                if aux4.Equals(false) && aux5.Equals(true) then//puede ingresar mientras no sea un comentario
                    for word in cadena do//recorre de palabra por palabra de cada linea
                        //printfn"%A"word
                        aux<-false//inicializa
                        aux2<-false//inicializa
                        auxtoken<-false//inicializa
                        lexem<-""//inicializa

                        if (Regex.IsMatch(word,"^[a-zA-Z]+$" ) )then//si la palabra que esta usando es solo de letras ingresa
                            //para verificar que sea palabra reservada
                            for i=0 to reservada.Length-1 do    //verifica si se encientra en las palabras reservadas
                                if (word.Equals(reservada.[i]) )then//en caso de que si
                                    //printfn"%A es igual a %A PALABRA RESERVADA"word reservada.[i]
                                    lexem<-"Reservada"//el lexema es este
                                    aux<-true;//auxiliar ayuda a saber que ya no ingrese en los demás
                                    aux2<-true //auxiliar ayuda a saber que ya no ingrese en los demás

                            //para verificar que sea un operador boleano
                            for i=0 to operaBool.Length-3 do
                                if (Regex.IsMatch(word,operaBool.[i]) && aux.Equals(false) )then
                                    //printfn "%A es igual a %A OPERADOR BOOLEANO"word operaBool.[i]
                                    lexem<-"Operador Booleano"
                                    aux<-true;
                                    aux2<-true 

                        //verificar que sea un digito
                        //if (Regex.IsMatch(word,"^[0-9]+$.") )then//[+-]?([0-9]*[.])?[0-9]+
                        if (Regex.IsMatch(word,"^[-+]?[0-9]*\.?[0-9]+$") )then//
                                //printfn"%A es un digito"word
                                lexem<-"Digito"
                                aux<-true
                                aux2<-true 
                    

                            //para verificar que sea un identificador
                        if Regex.IsMatch(word,"^[a-zA-Z0-9a-zA-Z,_]+$") && aux.Equals(false) then//si tiene numeros, letras y _
                            let auxiliar=word.ToCharArray()//auxiliar para verificar su primer caracter
                            //printfn"%A"auxiliar.[0]
                            let auxiliar2=auxiliar.[0].ToString() 
                            //printfn"%A"auxiliar2
                            if Regex.IsMatch(auxiliar2,"[0-9]") then//si es un número el primer caracter
                                auxtoken<-true//es un token incorrecto
                                aux2<-true
                            else
                                //printfn"%A IDENTIFICADOR"word
                                lexem<-"Identificador"//si no es uno correcto
                                aux2<-true 
                            
                           

                        if aux2.Equals(false)  then     //entra si no le mandan un true
                            //verificar si es un delimitador
                            for i=0 to delim.Length-1 do
                                if (word.Equals(delim.[i]))then
                                    //printfn"%A es igual a %A DELIMITADOR" word delim.[i]
                                    lexem<-"Delimitador"
                                

                            //verificar si es un operador de comparación
                            for i=0 to operaComp.Length-1 do
                                if (word.Equals(operaComp.[i]))then
                                    //printfn"%A es igual a %A OPERADOR DE COMPARACION" word operaComp.[i]
                                    lexem<-"Operador de Comparacion"
                                

                            //verificar si es un operador aritmeticos
                            for i=0 to operaArit.Length-1 do
                                if (word.Equals(operaArit.[i]))then
                                    //printfn"%A es igual a %A OPERADOR ARITMETICO" word operaArit.[i]
                                    lexem<-"Operador aritmetico"
                                

                            //verificar si es un operador booleano
                            for i=0 to operaBool.Length-1 do
                                if (word.Equals(operaBool.[i]))then
                                    //printfn"%A es igual a %A OPERADOR BOOLEANO" word operaBool.[i]
                                    lexem<-"operador booleano"
                                

                            //verificar si es un operador compuesto de asignacion 
                            for i=0 to operaAsig.Length-1 do
                                if (word.Equals(operaAsig.[i]))then
                                    //printfn"%A es igual a %A OPERADOR COMPUESTO DE ASIGNACION" word operaAsig.[i]
                                    lexem<-"Operador compuesto asig"
                                

                            //verificar si es un operador 
                            for i=0 to operador.Length-1 do
                                if (word.Equals(operador.[i]))then
                                    //printfn"%A es igual a %A OPERADOR " word operador.[i]
                                    lexem<-"Operador"
                                
                        if lexem.Equals("") then//si el lexema no trae ningun valor quiere decir que es incorrecto
                            auxtoken<-true


                        if auxtoken.Equals(false) && not (lexem.Equals("")) then//si es bueno
                            tokenCorrecto(word,lexem) //llama a la función de tokens buenos para guardarlos en la pila
                        else
                            lexem<-"Error de ingreso"
                            tokenIncorrecto(word,lexem,clinea)//llama a la función de tokens incorrectos para guardarlos en la pila

                //imprimirCorrecto();
                   
        //printfn "%A"token
```
Y un menu en donde se llama a las diferentes funciones que se tiene
```
[<EntryPoint>]
let main argv =
    imprimeCabeza() //llama la funcion que imprime el encabezado
    let data = Data()//define valor que toma la funcion
    data.Read()//lee
    imprimirCorrecto()//imprime los tokens correctos
    if contI>0 then
        printfn "HAY UN ERROR DE INGRESO"
        imprimeCabeza()//llama la funcion que imprime el encabezado
        imprimirIncorrecto()//imprime los tokens incorrectos
    else
        printfn"NO HAY ERRORES DE INGRESO"
    
    Console.ForegroundColor<-ConsoleColor.White//cambia el color de escritura a blanco
    
    0 // return an integer exit code
```
