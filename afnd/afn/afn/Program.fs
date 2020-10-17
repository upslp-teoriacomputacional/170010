// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions

let mutable simbolo:string = null
let mutable fin:string = null

let caracter (character) : int = 
    simbolo <- ""
    fin <- ""
    let mutable digito = "[0-9]"
    let mutable operador = "(\+|\-|\*|\/)"
    let mutable x:char = 'e'

    if Regex.IsMatch(character, digito) then
        simbolo <- "Digito"
        0
    elif Regex.IsMatch(character, operador) then
        simbolo <- "Operador"
        1
    elif character.Equals(fin) then 
        2
    else 
        printfn "Caracter no valido"
        4
    
let cuerpo() = 
    printfn "+-----------------------+-----------------------+-----------------------+-----------------------+"

let contenido (estadoSiguiente, character, simbolo,estado) = 
    printfn "|\t    %i    \t|\t    %c    \t|\t%s  \t|\t %i\t|" estadoSiguiente character simbolo estado
    cuerpo()

let encabezado() = 
    printfn "|\tEdo. Actual\t|\tCaracter\t|\tSimbolo   \t|\tEdo. Siguiente\t|"
    cuerpo()
    
// estados 1,2,3
// error 5
// aceptacion 4
let tabla = [[1;5;5]; [1;2;5];[3;5;5];[3;2;4]]

let mutable estado = 0
printfn """+-------------------------------------+
|    Ingrese una cadena a evaluar:    |
+-------------------------------------+"""
let cadena = Console.ReadLine()
cuerpo()
encabezado()
let mutable charcaracter = 4
for character in cadena do
    let mutable estadoSiguiente = estado
    charcaracter <- caracter(string character)
    if charcaracter < 4 then
        estado <- tabla.[estado].[charcaracter]
        if estado = 5 then
            printfn "|     %i      |  %c    |%s |     %i       |" estadoSiguiente character simbolo estado
            cuerpo()
            printfn """|                                    Cadena No Valida
    +-----------------------+-----------------------+-----------------------+-----------------------+"""
        contenido(estadoSiguiente, character, simbolo, estado)
if estado <> 3 then
    printfn """|                                    Cadena No Valida
+-----------------------+-----------------------+-----------------------+-----------------------+"""
if estado = 3 && charcaracter < 4 then
    printfn "|\t    %i    \t|\t          \t|\tFin Cadena\t|\t   \t|" estado
    cuerpo()
    printfn """|                                    Cadena Valida
+-----------------------+-----------------------+-----------------------+-----------------------+"""
         // return an integer exit code



