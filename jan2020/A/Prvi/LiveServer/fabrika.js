import {Silos} from "./silos.js";

export class Fabrika
{
    constructor(kontejner, ime, id, silosi, brojSilosa)
    {
        this.kontejner = kontejner;
        this.ime = ime;
        this.id = id;
        this.silosi = silosi;
        this.brojSilosa = brojSilosa;
    }

    crtaj()
    {
        const glavni = document.createElement("div");
        const prikaz = document.createElement("div");
        const opcije = document.createElement("div");

        glavni.className = "glavni";
        this.kontejner.appendChild(glavni);
        prikaz.className = "prikaz";
        glavni.appendChild(prikaz);
        opcije.className = "opcije";
        glavni.appendChild(opcije);

        //#region prikaz

        const lblIme = document.createElement("label");
        lblIme.innerHTML = this.ime;
        lblIme.className = "fabrikaIme";
        prikaz.appendChild(lblIme);

        const prikazSilosa = document.createElement("div");
        prikazSilosa.className = "prikazSilosa";
        prikaz.appendChild(prikazSilosa);
        this.silosi.forEach(element => {
            let stub = document.createElement("div");
            stub.className = "stubKontejner";
            prikazSilosa.appendChild(stub);
            element.crtaj(stub);
        });

        //#endregion

        //#region opcije

        const divSilos = document.createElement("div");
        divSilos.className = "silosSelect";
        opcije.appendChild(divSilos);
        const divKolicina = document.createElement("div");
        divKolicina.className = "kolicinaDInput";
        opcije.appendChild(divKolicina);

        const labelSilos = document.createElement("label");
        labelSilos.className = "labelaLevo";
        labelSilos.innerHTML = "Silos: ";
        divSilos.appendChild(labelSilos);

        const selectSilos = document.createElement("select");
        selectSilos.className = "listaSilosa";
        divSilos.appendChild(selectSilos);
        this.silosi.forEach(element => {
            let opcijaSilos = document.createElement("option");
            opcijaSilos.value = element.ime;
            selectSilos.appendChild(opcijaSilos);
        });

        const labelKolicina = document.createElement("label");
        labelKolicina.innerHTML = "Kolicina: ";
        labelKolicina.innerHTML = "labelaLevo"
        divKolicina.appendChild(labelKolicina);
        const inputKolicina = document.createElement("input");
        inputKolicina.type = "number";
        inputKolicina.className = "kolicinaMaterijala";
        inputKolicina.value = 0;
        divKolicina.appendChild(inputKolicina);

        const dugme = document.createElement("button");
        dugme.value = "Sipaj u silos";
        dugme.onclick = (ev) => this.klik(ev);

        //#endregion
    }

    sipaj(kolicina, ime)
    {
        this.silosi.forEach(element => {
            if (element.ime === ime)
            {
                element.sipaj(kolicina);
                break;
            }
        });
    }

    klik(ev)
    {
        const kolicina = this.kontejner.querySelector(".kolicinaMaterijala");
        const selectList =  this.kontejner.querySelector(".listaSilosa");

        this.sipaj(kolicina.value, selectList.options[selectList.selectedIndex].value);
    }
}