using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiSuperMkd.Models;
using apiSuperMkd.Clases;
using System.Web.Http.Cors;


namespace apiSuperMkd.Controllers
{
    //62065
    //Habilitacion del Cors y el servicio a consumir del cliente 

    [EnableCors(origins: "http://localhost:62065", headers: "*", methods: "*")]

    public class servSuperMkdController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get() //Select
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public modSuperMkD Post([FromBody] modSuperMkD objIn) //Insert
        {
            opeSuperMkd objOpe = new opeSuperMkd();
            objOpe.objModMdo = objIn;
            objOpe.hallarDatos();
            return objOpe.objModMdo;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value) //Update
        {
        }

        // DELETE api/<controller>/5 //Delete
        public void Delete(int id)
        {
        }
    }
}