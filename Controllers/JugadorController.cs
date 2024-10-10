using APIRestEquipos.Data;
using APIRestEquipos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestEquipos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        // GET api/<controller>
        [HttpGet("List")]
        public List<Jugador> Get()
        {
            return JugadorData.Listar();
        }

        // GET api/<controller>/5
        [HttpGet("id")]
        public Jugador Get(int id)
        {
            return JugadorData.Obtener(id);
        }

        // POST api/<controller>
        [HttpPost]
        public bool Post([FromBody] Jugador oJugador)
        {
            return JugadorData.Registrar(oJugador);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public bool Put([FromBody] Jugador oJugador)
        {
            return JugadorData.Modificar(oJugador);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public bool Delete(int id)
        {
            return JugadorData.Eliminar(id);
        }


    }
}
