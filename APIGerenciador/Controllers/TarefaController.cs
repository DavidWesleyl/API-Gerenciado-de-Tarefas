using APIGerenciador.Context;
using APIGerenciador.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace APIGerenciador.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TarefaController : ControllerBase
	{
		private readonly organizadorContext _context;

		public TarefaController(organizadorContext Contexto)
		{
			_context = Contexto;

		}

		// ENDPOINT: OBTER O ID NA API

		[HttpGet("/Obter Id - {id}")]
		public IActionResult ObterId(int id)
		{
			var tarefas = _context.Tarefas.Find(id);

			if (tarefas == null)
			{
				return NotFound();
			}

			return Ok(tarefas);

		}


		//ENDPOINT: INSERERIR DADOS NA API

		[HttpPost]
		public IActionResult Criar(Tarefa dadosUsuario)
		{
			_context.Add(dadosUsuario);
			_context.SaveChanges();

			return Ok(dadosUsuario);

		}

		// ENDPOINT: OBTER  DADOS POR TITULO

		[HttpGet("/Obter Titulo")]
		public IActionResult obterTitulo(string titulo)
		{
			var obterTitulo = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));

			return Ok(obterTitulo);

		}

		// ENDPOINT: OBTER DADOS POR DATA

		[HttpGet("/Obter Data")]
		public IActionResult obterData(DateTime data)
		{
			var obterData = _context.Tarefas.Where(x => x.Data.Date == data.Date);

			return Ok(obterData);
		}

		//ENDPOINT: OBTER DADOS POR STATUS

		[HttpGet("/Obter Status")]
		public IActionResult obterStatus(EnumStatus status)
		{
			var obterStatus = _context.Tarefas.Where(x => x.Status == status);
			
			_context.SaveChanges();


			return Ok(obterStatus);
		}

		//ENDPOINT: OBTER TODOS OS DADOS

		[HttpGet("/ Obter todos os Dados")]
		public ActionResult<IEnumerable<Tarefa>> obterTodos()
		{
			var todosOsDados = _context.Tarefas.ToList();
			_context.SaveChanges();

			return Ok(todosOsDados);
		}


		//ENDPOINT: UPDATE (ATUALIZAR DADOS)

		[HttpPut("/Atualizar")]

		public IActionResult Atualizar(int id, Tarefa tarefa)
		{
			var tarefaDB = _context.Tarefas.Find(id);

			if (tarefaDB == null) // Se a busca pelo Id (var TarefaDB) não existir, retorne:
			{
				return NotFound();
			}

			if (tarefa.Data == DateTime.MinValue) // Se a data não for preenchida
			{
				return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
			}

			else
			{
				tarefaDB.Id = tarefa.Id;
				tarefaDB.Titulo = tarefa.Titulo;
				tarefaDB.Descricao = tarefa.Descricao;
				tarefaDB.Data = tarefa.Data;
				tarefaDB.Status = tarefa.Status;

				_context.Tarefas.Add(tarefaDB);
				_context.SaveChanges();

				return Ok(tarefaDB);

			}


		}

		// ENDPOINT: DELETAR DADOS

		[HttpDelete("/Deletar")]
		public IActionResult Deletar(int Id)
		{
			var tarefa = _context.Tarefas.Find(Id);

			if (tarefa == null)
			{
				return NotFound();
			}

			else
			{
				_context.Tarefas.Remove(tarefa);
				_context.SaveChanges();

				return NoContent();
			}

		}



	}
}
