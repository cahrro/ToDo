//Conexão com banco de dados

using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Context
{
    public class TodoContexts : DbContext
    {
        public DbSet<Todo> Todos => Set<Todo>(); //Avisa quais são as classes de modelo no projeto. Se o projeto tivesse mais uma tabela seria mais um DbSet

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Informa qual banco de dados o projeto vai se conectar
        {
            optionsBuilder.UseSqlite("Data Source = todos.sqlite3") //conexão com o bd
            .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
