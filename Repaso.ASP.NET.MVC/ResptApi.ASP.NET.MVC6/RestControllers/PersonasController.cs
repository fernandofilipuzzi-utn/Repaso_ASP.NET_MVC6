using asp.net_mvc6.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp.net_mvc6.RestControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        static List<PersonaModel> personas = new List<PersonaModel>
        {
                new (){ DNI=23432324, Nombre="Luis"},
                new (){ DNI=33432224, Nombre="Esteban"},
        };

        [HttpGet("CrearPersona")]
        public IActionResult Get(int dni, string nombre)
        {
            var nueva=new PersonaModel { DNI = dni, Nombre = nombre };
            personas.Add(nueva);
            return Ok();
        }


        [HttpGet]
        public IActionResult Get()
        {
            if (personas.Count <= 0)
                return NotFound();

            return Ok(personas);
        }
       

        // GET api/<PersonasController>/5
        [HttpGet("{dni}")]
        public IActionResult Get(int dni)
        {
            PersonaModel objeto= personas.Where(p=>p.DNI == dni).FirstOrDefault();

            if (objeto == null) return NotFound();
            
            return Ok(objeto);
        }

       
        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonaModel nuevo)
        {
            if (nuevo == null) return BadRequest();

            personas.Add(nuevo);

            return Ok();
        }

        /*

       // PUT api/<PersonasController>/5
       [HttpPut("{id}")]
       public void Put(int id, [FromBody] string value)
       {
       }

       // DELETE api/<PersonasController>/5
       [HttpDelete("{id}")]
       public void Delete(int id)
       {
       }
       */
    }
}
