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
    public class AlunosController : ControllerBase
    {
        
        private readonly ApplicationDbContext context;
        // GET: api/<AlunosController>
        public AlunosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Listar
        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> Get()
        {
            return await context.Alunos.Include(x => x.Curso).ToListAsync();
        }


        //Criar
        [HttpPost]
        public async Task<ActionResult> Criar(Aluno aluno)
        {
            context.Add(aluno);
            await context.SaveChangesAsync();
            return Ok(aluno.AlunoId);

            //try
            //{
            //    context.Add(aluno);
            //    await context.SaveChangesAsync();
            //    return Ok(aluno.AlunoId);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("{0} Exception caught.", e);
            //    return null;
            //}

        }


        //Editar
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Aluno>> GetById(int id)
        {
            return await context.Alunos.FirstOrDefaultAsync(x => x.AlunoId == id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        //Deletar
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.AlunoId == id);
            context.Remove(aluno);
            await context.SaveChangesAsync();
            return NoContent();
        }
       


    }
}
