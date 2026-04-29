using Microsoft.AspNetCore.Mvc;
using ApiContatos10.Data; // Ajusta para onde está o seu DbContext
using ApiContatos10.Models; // Ajusta para o nome da sua pasta de Models
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiContatos10.Controllers
{
    [ApiController] //Diz que essa classe é um controlador de API
    [Route("api/[controller]")] // Define a rota para acessar esse controlador, nesse caso, "api/contato"
    public class ContatoController : ControllerBase
    {
        private readonly AppDbContext _context; // Declaração do DbContext para acessar o banco de dados
        public ContatoController(AppDbContext context)
        {
            _context = context; // Injeta o DbContext no construtor do controlador
        }

        [HttpGet] 
        public async Task<IActionResult> GetTodos()
        {
            var contatos = await _context.Contatos.ToListAsync(); // Busca todos os contatos do banco de dados
            return Ok(contatos); // Retorna os contatos encontrados com status 200 OK
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var contato = await _context.Contatos.FindAsync(id); // Busca um contato específico pelo ID
            if (contato == null)
                return NotFound(new {mensagem = "Contato não encontrado"}); // Retorna 404 Not Found se o contato não for encontrado

            return Ok(contato); // Retorna o contato encontrado com status 200 OK
        }
    }
}

