using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faculdade_FUP_Project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Piloto.Server.Data;


namespace Teste_Piloto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefiasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        // GET: api/<ChefiaController>
        public ChefiasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Listar
        [HttpGet]
        public async Task<ActionResult<List<Chefia>>> Get()
        {
            return await context.Chefias.ToListAsync();
        }


        //Criar
        [HttpPost]
        public async Task<ActionResult> Criar(Chefia chefia)
        {
            context.Add(chefia);
            await context.SaveChangesAsync();
            return Ok(chefia.ChefiaId);
        }


        //Editar
        [HttpGet("{id}", Name = "PegaOid")]
        public async Task<ActionResult<Chefia>> PegaOid(int id)
        {
            return await context.Chefias.FirstOrDefaultAsync(x => x.ChefiaId == id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Chefia chefia)
        {
            context.Entry(chefia).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        //Deletar
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var chefia = await context.Chefias.FirstOrDefaultAsync(x => x.ChefiaId == id);
            context.Remove(chefia);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
