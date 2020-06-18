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
    public class FuncionariosController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        // GET: api/<FuncionariosController>
        public FuncionariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Listar
        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> Get()
        {
            return await context.Funcionarios.ToListAsync();
        }


        //Criar
        [HttpPost]
        public async Task<ActionResult> Criar(Funcionario funcionario)
        {
            context.Add(funcionario);
            await context.SaveChangesAsync();
            return Ok(funcionario.FuncionarioId);
        }


        //Editar
        [HttpGet("{id}", Name = "PeguePorId")]
        public async Task<ActionResult<Funcionario>> PeguePorId(int id)
        {
            return await context.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioId == id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Funcionario funcionario)
        {
            context.Entry(funcionario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        //Deletar
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var curso = await context.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioId == id);
            context.Remove(curso);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
