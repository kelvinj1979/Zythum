
class Principal {
    userLink(URLactual) {
        let url = "";
        let cadena = URLactual.split("/");
        for (var i = 0; i < cadena.length; i++) {
            if (cadena[i] != "Index") {
                url += cadena[i];
            }
        }
        switch (url) {
            case "UsersRegister":
                document.getElementById('files').addEventListener('change', imageUser, false);
                break;
            case "BreweryRegister":
                document.getElementById('files').addEventListener('change', imageBrewery, false);
                break;
            case "BeersRegister":
                document.getElementById('files').addEventListener('change', imageBeer, false);
                break;
        }
    }
}
