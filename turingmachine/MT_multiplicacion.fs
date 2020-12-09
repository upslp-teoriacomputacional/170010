//  Programa en F# para realizar una MT de una multiplicacion 

(* *****************************************************************************
*  Nombre:  Diana
*  Apellidos:  Rodríguez Espiricueta
*  Especialidad:  ITI
*  Profesor de la materia:  Juan Carlos González Ibarra
*  Institución:  Universidad Politecnica de San Luis Potosí (UPSLP) 
*  Matricula:  170010
**************************************************************************** *)

(*
"
--Tape
--Cabezal (apuntador,simboloa sobreescribir,izquierda-derecha-izquierda)
--Registro de estados
--Tabla de transiciones

La maquina de turing tiene las caracteristicas de un Automata finito
    Q = Es un conjunto de estados
    Σ = Alfabeto conjunto de caracteres (codigo utf-8 ="\u03A3")	
    Γ = Simbolos de la cinta
    s = Estado inicial sϵQ
    δ= Reglas nde transicion (Codigo utf-8 = "\u03B4")
    QxΣ->Q Reglas de transicion
    bϵΓ = es un simbolo denominado blanco, que se puede repetir 
          infinitamente en toda la cinta 
    F⊆Q Estado finales o de aceptacion
    
    Q = {s,q1}
    Σ = {a}	
    Γ = {a,b}
    s = Estado inicial q0ϵQ
    δ= Reglas de transicion 
    Reglas de transicion
    Q x Σ -> Q
    ((q0,a)->q1*)
    (estado, valor) -> nuevo estado, nuevo valor, dirección)
    (s,a)->q1,b,right
    (q1,b)->--Valido--
    "si estamos en el estado s leyendo la posición q1, donde hay 
    escrito el símbolo 'a', entonces este símbolo debe ser reemplazado 
    por el símbolo 'b', y pasar a leer la celda siguiente, a la derecha".
    F⊆Q = {q1}
    
    Estructura gafica es un grafo dirigido que se conecta en los vertices 
    con:
        (lee el cabezal/
        símbolo que escribirá el cabezal, 
        movimiento del cabezal.)
        (s,a)->q1,b,right
        ('a',b,right)
"*)


open System                                                                 // Inicio del sistema 

exception OuterError of string                                              // Declaracion de la excepción

//Lenguaje de ma maquina se compone de: 
//estados, simbolo blanco del alfabeto-cinta, reglas de transicion, cinta final, estado final, posicion siguiente de la MT
let turing_M ( state ) ( blank ) ( rules:list<list<string>> ) ( tape:list<string> ) ( final ) ( pos ) =
    
    let mutable st = state                                                  // Declaracion de variables globales/mutables                                       
    let mutable tape = tape
    let mutable pos = pos
    let mutable Break = false
    let mutable NoCinta = true
    let mutable True = true

    if ( tape.IsEmpty ) then
        tape <- [blank]

    if ( pos < 0 ) then
        pos <- pos + tape.Length

    if ( pos >= tape.Length || pos < 0 ) then
        raise ( OuterError ( "Se inicializa mal la posicion" ) )


    while not (Break) do                     
        printf (" %s ") st
        for i in 0..tape.Length-1 do
            if ( i = pos ) then
                printf (" [%s] ") tape.[i]
            else
                printf (" %s ") tape.[i]
        printfn ("")

        if ( st = final ) then
            Break <- true

        for character in rules do
            if ( st = character.[0] && tape.[pos] = character.[1] ) then
                NoCinta <- false
        if ( NoCinta ) then
            Break <- true
        if ( not Break ) then
            let mutable v1, dr, s1 = "", "", ""                                // Auxiliares para las variables

            for character in rules do
                if ( st = character.[0] && tape.[pos] = character.[1] ) then
                    v1 <- character.[2]
                    dr <- character.[3]
                    s1 <- character.[4]

            let mutable nuevaCinta = []

            for x in 0..tape.Length-1 do                                       //   Realiza la sustitucion en la cinta
                if ( x = pos ) then
                    nuevaCinta <- nuevaCinta @ [v1]
                else
                    nuevaCinta <- nuevaCinta @ [tape.[x]]
            tape <- nuevaCinta

            if ( dr.Equals("left") ) then                                       // movimiento del cabezal
                if (pos > 0) then
                    pos <- pos - 1
                else
                    tape <- [blank] @ tape
            if ( dr.Equals("right") ) then
                pos <- pos + 1
                if ( pos >= tape.Length ) then
                    tape <- tape @ [blank]
            st <- s1

printf("MAQUINA DE TURING TEST MULTIPLICACIÓN \n")

let main =
    // Se puede cambiar las reglasde transicion para otra maquina de turing
    let reglas =  [["s0"; "1"; "1"; "right"; "s0"];                              // Transiciones del estado 0
              ["s0"; "x"; "x"; "right"; "s0"];
              ["s0"; "b"; "x"; "left";  "s1"];

              ["s1"; "1"; "1"; "left";  "s1"];                              // Transiciones del estado 1
              ["s1"; "x"; "x"; "left";  "s1"];
              ["s1"; "b"; "b"; "right"; "s2"];

              ["s2"; "1"; "b"; "right"; "s3"];                              // Transiciones del estado 2
              ["s2"; "x"; "b"; "right"; "s8"];

              ["s3"; "1"; "1"; "right"; "s3"];                              // Transiciones del estado 3
              ["s3"; "x"; "x"; "right"; "s4"];

              ["s4"; "1"; "b"; "right"; "s5"];                              // Transiciones del estado 4
              ["s4"; "x"; "x"; "left";  "s7"];

              ["s5"; "1"; "1"; "right"; "s5"];                              // Transiciones del estado 5
              ["s5"; "x"; "x"; "right"; "s5"];
              ["s5"; "b"; "1"; "left";  "s6"];

              ["s6"; "1"; "1"; "left";  "s6"];                              // Transiciones del estado 6
              ["s6"; "x"; "x"; "left";  "s6"];
              ["s6"; "b"; "b"; "right"; "s4"];

              ["s7"; "b"; "1"; "left"; "s7"];                               // Transiciones del estado 7
              ["s7"; "x"; "x"; "left"; "s1"];

              ["s8"; "1"; "b"; "right"; "s8"];                              // Transiciones del estado 9
              ["s8"; "x"; "b"; "right"; "s9"];]

    turing_M ("s0") ("b") (reglas) (["1";"1";"1";"x";"1";"1";]) ("s9") (0)       // Gramatica/reglas de la maquina de turing
    0