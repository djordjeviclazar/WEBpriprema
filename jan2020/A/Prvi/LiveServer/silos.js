export class Silos
{
    constructor(id, ime, kolicina, kapacitet)
    {
        this.id = id;
        this.ime = ime;
        this.kolicina = kolicina;
        this.kapacitet = kapacitet;
        this.kontejner = null;
        this.stub = null;
    }

    crtaj(kontejner)
    {
        this.kontejner = kontejner;

        //#region labele

        const lblIme = document.createElement("label");
        lblIme.innerHTML = this.ime;
        lblIme.className = "imeSilosa";
        this.kontejner.appendChild(lblIme);

        const lblKolicina = document.createElement("label");
        lblKolicina.innerHTML = this.kolicina + "t / " + this.kapacitet + "t";
        lblKolicina.className = "kolicinaSilosa";
        this.kontejner.appendChild(lblKolicina);

        //#endregion

        //#region stub

        const okvir = document.createElement("div");
        okvir.className = "okvir";
        this.kontejner.appendChild(okvir);
        const stub = document.createElement("div");
        stub.className = "stub";
        stub.height = (okvir.height / 100) * (this.kolicina * 100 / this.kapacitet);
        okvir.appendChild(stub);
        this.stub = stub;

        //#endregion
    }

    sipaj(kolicina)
    {
        let novaKolicina = this.kolicina + kolicina;
        if (novaKolicina > this.kapacitet)
        {
            console.log("Alo bre");
            alert("Alo bre");
        }
        else
        {
            //#region pozivanje API-ja

            fetch("https://localhost:5500/fabrikacontroller/napunisilos/",{
                method:"PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    "Id": this.id,
                    "Kolicina": kolicina
                })
            }).then(p => {
                if (p.ok())
                {
                    this.stub.height = (stub.parentElement().height / 100) * (novaKolicina * 100 / this.kapacitet);
                    this.kolicina = novaKolicina;
                }}).catch(poruka =>{
                    alert(poruka);
                    /*
                    poruka.json().then(res =>{alert(res.poruka)})
                     */
                });

            //#endregion
        }
    }
}