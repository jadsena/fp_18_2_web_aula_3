using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fp_stack.core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fp_stack.api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        private readonly Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }

        //public List<Pergunta> Index()
        //{
        //    return _context.Perguntas.ToList();
        //}
        //[HttpGet]
        //[ProducesResponseType(200,Type =typeof(List<Pergunta>))]
        //[ProducesResponseType(400)]
        //public IActionResult Index2()
        //{
        //    var perguntas = _context.Perguntas.ToList();
        //    if (perguntas.Count() == 3)
        //        return BadRequest();
        //    return Ok(perguntas);
        //}
        [HttpGet]
        //[Route("")]
        public ActionResult<List<Pergunta>> Get()
        {
            var perguntas = _context.Perguntas.ToList();
            return perguntas;
        }
        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<Pergunta> Get(int id)
        //{
        //    var pergunta = _context.Perguntas.FirstOrDefault;
        //    return pergunta;
        //}
        [HttpPost]
        //[Route("")]
        public IActionResult Post(Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Perguntas.Add(pergunta);
                _context.SaveChanges();
                return Created($"/api/perguntas/{pergunta.Id}", pergunta);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                //_context.Attach(pergunta);
                _context.Perguntas.Attach(pergunta);
                _context.Entry(pergunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();
                return Created($"/api/perguntas/{pergunta.Id}", pergunta);
            }
            return BadRequest(ModelState);
        }
    }
}