using System.Security.Principal;

namespace APIGerenciador.Entities
{
	public class Tarefa // Classe tarefa que será nossa Tabela no banco de dados
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public DateTime Data { get; set; }

		public EnumStatus Status { get; set; }

	}
}
