var dir = "http://localhost:61273/api/"; //Director del servidor

jQuery(function () {
    $("#btnLimpiar").on("click", function () {
        alert("Limpiar");
        limpiar();


    });

    $("#btnProcesar").on("click", function () {
        alert("procesar");
        procesar();
    });
});



function limpiar() {
    $("#txtNroDoc").val("");
    $("#txtNombre").val("");
    $("#cmbClasif").val(10);
    $("#txtSubTotal").val("");
    $("#txtPorcDsc").val("");
    $("#VrDsc").val("");
    $("#VrAPag").val("");
    $("#txtNroDoc").val("").focus();;
}

async function procesar() {
    let nroD = $("#txtNroDoc").val();
    let nom = $("#txtNombre").val().trim();
    let tipClasif = $("#cmbClasif").val();
    let vrSubTot = $("#txtSubTotal").val();


    alert("nroD" + nroD + ", nom:" + nom + ", tipClasif: " + tipClasif + ", vrSubTot: " + vrSubTot);

    if (nroD <= 0 || nom.tr == vrSubTot <= 0) {
        alert("Error: existe al menos un valor no válido");
        $("#txtNroDoc").focus();
        return;
    }

    let datosOut = {
        tipoClasif: tipClasif,
        subTotal: vrSubTot,
    }

    try {
        const retornoSrv = await fetch(dir + "servSuperMkd",
            {
                method: "POST",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(datosOut),
            }
        );
        const Rpta = await retornoSrv.json();
        $("#txtPorcDsc").val(Rpta.porcDscto);
        $("#txtVrDsc").val(Rpta.vrDscto);
        $("#txtVrAPag").val(Rpta.vrAPagar);
    } catch (e) {
           alert("Error en la comunicación con el servidor")
    }

}