using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using apiSuperMkd.Models;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;

namespace apiSuperMkd.Clases
{
    public class opeSuperMkd
    {
        //Esto maneja el objeto JSON
        public modSuperMkD objModMdo { get; set; }

        private bool validar()
        {
            if (objModMdo.tipoClasif != 1 &&
                objModMdo.tipoClasif != 5 &&
                objModMdo.tipoClasif != 10)
            {
                objModMdo.Error = "El tipo de clasificación es no permitida";

                return false;
            }
            if (objModMdo.subTotal <= 0)
            {
                objModMdo.Error = "El subtotal no es valido ";

                return false;
            }
            return true;

        }

        private void hallarDscto()
        {
            float d = 0;
            int tc = objModMdo.tipoClasif;
            float st = objModMdo.subTotal;

            try
            {
                switch (tc)
                {
                    case 1:
                        if (st <= 1000000)
                        {
                            d = 8f;
                        }
                        else if (st <= 500000)
                        {
                            d = 11.5f;
                        }
                        else
                        {
                            d = 15f;
                        }
                        break;
                    case 5:
                        if (st <= 1000000)
                        {
                            d = 5f;
                        }
                        else if (st <= 500000)
                        {
                            d = 8.1f;
                        }
                        else
                        {
                            d = 11.2f;
                        }
                        break;

                    default:

                        if (st <= 1000000)
                        {
                            d = 0f;
                        }
                        else if (st <= 500000)
                        {
                            d = 2.5f;
                        }
                        else
                        {
                            d = 5f;
                        }
                        break;

                }
                objModMdo.porcDscto = d;
            }
            catch (Exception)
            {
                objModMdo.Error = "Error en el proceso 1";

            }


        }

        public void hallarDatos()
        {
            if (!validar())
            {
                return;
            }
            hallarDscto();
            objModMdo.vrDscto = (objModMdo.subTotal * objModMdo.porcDscto) / 100;
            objModMdo.vrAPagar = objModMdo.subTotal - objModMdo.vrDscto;


        }


    }
}