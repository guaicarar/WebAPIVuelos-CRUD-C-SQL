using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIVuelos.Data;
using WebAPIVuelos.Models;

namespace WebAPIVuelos.Controllers
{
    public class VueloController : ApiController
    {
        // GET api/<controller>
        public List<Vuelo> Get()
        {
            return VueloData.Listar();
        }

        // GET api/<controller>/5
        public Vuelo Get(int id)
        {
            return VueloData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Vuelo oVuelo)
        {
            return VueloData.Registrar(oVuelo);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Vuelo oVuelo)
        {
            return VueloData.Modificar(oVuelo);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return VueloData.Eliminar(id);
        }
    }
}