using APIRestEquipos.Data;
using APIRestEquipos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        // GET api/<controller>
        public List<Equipo> Get()
        {
            return EquipoData.Listar();
        }

        // GET api/<controller>/5
        public Equipo Get(int id)
        {
            return EquipoData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Equipo oEquipo)
        {
            return EquipoData.Registrar(oEquipo);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Equipo oEquipo)
        {
            return EquipoData.Modificar(oEquipo);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return EquipoData.Eliminar(id);
        }
    }
}
