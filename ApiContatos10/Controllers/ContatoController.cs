using Microsoft.AspNetCore.Mvc;
using ApiContatos10.Data; // Ajusta para onde está o seu DbContext
using ApiContatos10.Models; // Ajusta para o nome da sua pasta de Models
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

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
                return NotFound(new { mensagem = "Contato não encontrado" }); // Retorna 404 Not Found se o contato não for encontrado

            return Ok(contato); // Retorna o contato encontrado com status 200 OK
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Contato contato)
        {
            if (!EmailValido(contato.Email)) // Valida o formato do email usando o método EmailValido
                return BadRequest(new { mensagem = "Email inválido" }); // Retorna 400 Bad Request se o email for inválido
            _context.Contatos.Add(contato); // Adiciona o novo contato ao DbContext
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return CreatedAtAction(nameof(GetPorId), new { id = contato.Id }, contato); // Retorna 201 Created com o contato criado
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var contato = await _context.Contatos.FindAsync(id); // Busca um contato específico pelo ID
            if (contato == null)
                return NotFound(new { mensagem = "Contato não encontrado" }); // Retorna 404 Not Found se o contato não for encontrado
            _context.Contatos.Remove(contato); // Remove o contato do DbContext
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return NoContent(); // Retorna 204 No Content para indicar que a exclusão foi bem-sucedida
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar (int id, Contato contato)
        {
            var contatoExistente = await _context.Contatos.FindAsync(id);

            if (contatoExistente == null)
                return NotFound(new { mensagem = "Contato não encontrado" });

            if (!EmailValido(contato.Email))
                return BadRequest(new {mensagem = "Email inválido" });

            contatoExistente.Nome = contato.Nome;
            contatoExistente.Telefone = contato.Telefone;
            contatoExistente.Email = contato.Email;
            contatoExistente.Endereco = contato.Endereco;
            contatoExistente.Categoria = contato.Categoria;

            _context.Contatos.Update(contatoExistente); // Atualiza o contato existente no DbContext
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados
            return Ok(contatoExistente); // Retorna 200 OK com o ID do contato atualizado
        }







        private bool EmailValido(string email)
        {
            try
            {
                var mail = new MailAddress(email); // Tenta criar um objeto MailAddress para validar o formato do email
                return true; // Retorna true se o email for válido
            }
            catch
            {
                return false; // Retorna false se o email for inválido
            }
        }
    }
}

