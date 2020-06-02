import { Fabrika } from "./fabrika.js";
import { Silos } from "./silos.js";

fetch("https:/localhost:5500/fabrikacontroller/dodaj", {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify({
        "Ime": "Zitopek",
        "Id": 1,
        "brojSilosa": 1,
        "Silosi":[
            {
                "Id": 1,
                "Ime": "Silos1",
                "Kolicina": 100,
                "Kapacitet": 2000
            },
            {
                "Id": 2,
                "Ime": "Silos2",
                "Kolicina": 1000,
                "Kapacitet": 2000
            },
            {
                "Id": 3,
                "Ime": "Silos3",
                "Kolicina": 500,
                "Kapacitet": 2000
            }
        ]
    })
}).then(p => {
    if (p.ok)
    {
        console.log("Uspesno");
    }
    else
    {
        alert("Greska");
    }
})

let fabrike = [];

fetch("https:/localhost:5500/fabrikacontroller/all")
.then(p => p.json().then(data =>{
    fabrike = [];
    data.forEach(element => {
        const kontejner = document.createElement("div");
        kontejner.className = "kontejnerFabrike";
        document.body.appendChild(kontejner);
        const fabrika = new Fabrika(kontejner, element["Ime"], element["Id"], element["Silosi"].forEach(s => {
            const silos = new Silos(s["Id"], s["Ime"], s["Kolicina"], s["Kapacitet"]);
            fabrika.silosi.push(silos);
        }), element["brojSilosa"]);
        fabrike.push(fabrika);
    });
}))

fabrike.forEach(f =>{
    f.crtaj();
})