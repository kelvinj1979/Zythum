// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var principal = new Principal();

/*CODIGO DE USUARIOS*/
var user = new User();
var imageUser = (evt) => {
    user.archivo(evt, "imageUser");
}

/*CODIGO DE BREWERY*/
var brewery = new Brewery();
var imageBrewery = (evt) => {
    brewery.archivo(evt, "imageBrewery");
}

/*CODIGO DE BEER*/
var beer = new Beer();
var imageBeer = (evt) => {
    beer.archivo(evt, "imageBeer");
}

$().ready(() => {
    let URLactual = window.location.pathname;
    principal.userLink(URLactual);
});