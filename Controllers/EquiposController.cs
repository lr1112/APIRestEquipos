using APIRestEquipos.Data;
using APIRestEquipos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        // GET api/<controller>
        [HttpGet("List")]
        public List<Equipo> Get()
        {
            return EquipoData.Listar();
        }

        // GET api/<controller>/5
        [HttpGet("id")]
        public Equipo Get(int id)
        {
            return EquipoData.Obtener(id);
        }

        // POST api/<controller>
        [HttpPost]
        public bool Post([FromBody] Equipo oEquipo)
        {
            return EquipoData.Registrar(oEquipo);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public bool Put([FromBody] Equipo oEquipo)
        {
            return EquipoData.Modificar(oEquipo);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public bool Delete(int id)
        {
            return EquipoData.Eliminar(id);
        }
    }
}
