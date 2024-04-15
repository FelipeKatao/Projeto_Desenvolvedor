// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var bt_inicio = document.getElementById("index_bt")
var bt_filtrar = document.getElementById("filtro_bt")
var bt_add = document.getElementById("add_bt")

var Caminho = window.location.href
var List_caminho = Caminho.split("/")

console.log(List_caminho[List_caminho.length-1]);

if(List_caminho[List_caminho.length-1] == "Adicionar"){
    bt_add.classList.add("selectd")
}

if(List_caminho[List_caminho.length-1] == "Filtrar"){
    bt_filtrar.classList.add("selectd")
}

if(List_caminho[List_caminho.length-1] == ""){
    bt_inicio.classList.add("selectd")
}
