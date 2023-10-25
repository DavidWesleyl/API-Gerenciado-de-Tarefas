using APIGerenciador.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIGerenciador.Context
{
	public class organizadorContext : DbContext // Nosso context que irá nos relacionar ao Banco de dados
	{
        public DbSet<Tarefa> Tarefas { get; set; }

        public organizadorContext(DbContextOptions<organizadorContext> options)
            :base(options)
        {
            
        }
    }
}
