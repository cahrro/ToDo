using System.ComponentModel.DataAnnotations;
using ToDo.Validators;

namespace ToDo.Models
{
    public class Todo //modelo tabela
    {
        public int Id { get; set; } //seta como primary key automaticamente

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100,MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        public string Titulo { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; }

        [Display(Name = "Data de Entrega")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [FutureOrPresent]
        public DateOnly Prazo { get; set; }

        public DateOnly? FinalizadoEm { get; set;}

        //todos sem ? vão ser setados como not null

        public void Finish()
        {
            FinalizadoEm = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
