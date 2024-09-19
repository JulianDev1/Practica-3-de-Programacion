using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiSuperMkd.Models
{
    public class modSuperMkD
    {
        #region "Constructor"
        public modSuperMkD()
        {

            tipoClasif = 0;
            subTotal = 0;
            porcDscto = 0;
            vrDscto = 0;
            vrAPagar = 0;
            Error = string.Empty;

        }
        #endregion

        #region "Atributos/Propiedades"
        //Si quiero deshabilitar uno de los tods hay que anteponer el private       
        public int tipoClasif { get; set; }
        public float subTotal { get; set; }
        public float porcDscto { get; set; }
        public float vrDscto { get; set; }
        public float vrAPagar { get; set; }
        public string Error { get; set; }

        #endregion

        #region "Metodos Publicos"

        #endregion


    }
}