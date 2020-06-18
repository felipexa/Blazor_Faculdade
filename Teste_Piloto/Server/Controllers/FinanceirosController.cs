using Faculdade_FUP_Project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Teste_Piloto.Server.Data;

namespace Teste_Piloto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceirosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public FinanceirosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Financeiro>>> Get()
        {
            return await context.Finaiceiros.ToListAsync();
        }


        //Criar
        [HttpPost]
        public async Task<ActionResult> Criar(Financeiro financeiro)
        {
            context.Add(financeiro);
            await context.SaveChangesAsync();
            return Ok(financeiro.FinanceiroId);
        }


        //Editar
        [HttpGet("{id}", Name = "GetFinanceiroID")]
        public async Task<ActionResult<Financeiro>> GetFinanceiroID(int id)
        {
            return await context.Finaiceiros.FirstOrDefaultAsync(x => x.FinanceiroId== id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Financeiro financeiro)
        {
            context.Entry(financeiro).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        //Deletar
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var financeiro = await context.Finaiceiros.FirstOrDefaultAsync(x => x.FinanceiroId== id);
            context.Remove(financeiro);
            await context.SaveChangesAsync();
            return NoContent();
        }


        //    //Listar aluno
        //    [HttpGet]
        //    public async Task<ActionResult<List<Aluno>>> Get()
        //    {
        //        return await context.Alunos.ToListAsync();
        //    }



        //    [HttpGet]
        //    public async Task<FileResult> DownloadPdf()
        //    {
        //        using (var doc = new PdfSharpCore.Pdf.PdfDocument())
        //        {
        //            var page = doc.AddPage();
        //            page.Size = PdfSharpCore.PageSize.A4;
        //            page.Orientation = PdfSharpCore.PageOrientation.Portrait;
        //            var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
        //            var corFonte = PdfSharpCore.Drawing.XBrushes.Black;
        //            var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
        //            var fonteOrganizacao = new PdfSharpCore.Drawing.XFont("Ariel", 10);
        //            var fonteDescricao = new PdfSharpCore.Drawing.XFont("Ariel", 8, PdfSharpCore.Drawing.XFontStyle.BoldItalic);
        //            var tituloDetalhes = new PdfSharpCore.Drawing.XFont("Ariel", 8, PdfSharpCore.Drawing.XFontStyle.Bold);
        //            var fonteDetalhesDescricao = new PdfSharpCore.Drawing.XFont("Ariel", 7);
        //            var logo = @"C:\Users\Aparicio\Desktop\FUP_TRABALHO_29-05\PROJETO_FUP_Brasil\wwwroot\img\logo.jpg";
        //            var qtdPaginas = doc.PageCount;

        //            //imagem logotipo
        //            textFormatter.DrawString(qtdPaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(575, 825, page.Width, page.Height));
        //            XImage imagem = XImage.FromFile(logo);
        //            graphics.DrawImage(imagem, 20, 5, 100, 50);


        //            //Titulo Maior
        //            var descricaoFinanceira = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
        //            descricaoFinanceira.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
        //            descricaoFinanceira.DrawString("Detalhamento Financeiro", tituloDetalhes, corFonte, new PdfSharpCore.Drawing.XRect(0, 120, page.Width, page.Height));

        //            //titulo das Colunas
        //            var alturaTituloFinanceiroY = 140;
        //            var detalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

        //            detalhes.DrawString("Saida", fonteDescricao, PdfSharpCore.Drawing.XBrushes.Red, new PdfSharpCore.Drawing.XRect(20, alturaTituloFinanceiroY, page.Width, page.Height));
        //            detalhes.DrawString("Entrada", fonteDescricao, PdfSharpCore.Drawing.XBrushes.Green, new PdfSharpCore.Drawing.XRect(220, alturaTituloFinanceiroY, page.Width, page.Height));
        //            detalhes.DrawString("Total Liquido", fonteDescricao, PdfSharpCore.Drawing.XBrushes.CadetBlue, new PdfSharpCore.Drawing.XRect(340, alturaTituloFinanceiroY, page.Width, page.Height));

        //            //gerar dados do relátorio

        //            Financeiro model = new Financeiro();
        //            var alturaItens = 160;
        //            var alturaItens2 = 160;
        //            var conteudoAluno = await context.Alunos.Include(d => d.Curso).ToListAsync();
        //            var conteudoFuncionario = await context.Funcionarios.ToListAsync();
        //            model.Funcionarios = conteudoFuncionario;
        //            model.Alunos = conteudoAluno;
        //            decimal somaDespesas = 0;
        //            decimal somaLucros = 0;
        //            decimal totalLiquido = 0;


        //            foreach (var item in model.Funcionarios)
        //            {
        //                textFormatter.DrawString("Saida: " + item.SalarioFuncionario, fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, alturaItens, page.Width, page.Height));
        //                somaDespesas += item.SalarioFuncionario;
        //                alturaItens += 20;
        //            }


        //            foreach (var item in model.Alunos)
        //            {
        //                textFormatter.DrawString("Entrada: " + item.Curso.ValorCurso, fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(220, alturaItens2, page.Width, page.Height));
        //                somaLucros += item.Curso.ValorCurso;
        //                alturaItens2 += 20;
        //            }
        //            totalLiquido = somaLucros - somaDespesas;
        //            textFormatter.DrawString("Total Saida: " + somaDespesas, fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, alturaItens, page.Width, page.Height));
        //            textFormatter.DrawString("Total Entrada: " + somaLucros, fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(220, alturaItens2, page.Width, page.Height));
        //            if (totalLiquido > 0)
        //            {
        //                textFormatter.DrawString("Total Liquido: " + totalLiquido, fonteDescricao, PdfSharpCore.Drawing.XBrushes.Green, new PdfSharpCore.Drawing.XRect(340, alturaItens2, page.Width, page.Height));
        //            }
        //            else
        //            {
        //                textFormatter.DrawString("Total Liquido: " + totalLiquido, fonteDescricao, PdfSharpCore.Drawing.XBrushes.Red, new PdfSharpCore.Drawing.XRect(340, alturaItens2, page.Width, page.Height));
        //            }


        //            //cabeçalho inicio statico
        //            textFormatter.DrawString("Instituição: ", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, 95, page.Width, page.Height));
        //            textFormatter.DrawString("Faculdade Universitaria de Programação", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(80, 95, page.Width, page.Height));




        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                var contantType = "application/pdf";
        //                doc.Save(stream, false);
        //                var nomeArquivo = "relatorioFinancerio.pdf";
        //                return File(stream.ToArray(), contantType, nomeArquivo);
        //            }

        //        }
        //    }

    }
}
