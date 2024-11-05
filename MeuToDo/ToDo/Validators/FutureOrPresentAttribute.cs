using System.ComponentModel.DataAnnotations;

namespace ToDo.Validators
{

    public class FutureOrPresentAttribute : ValidationAttribute
    {
        public FutureOrPresentAttribute()
        {
            ErrorMessage = "O campo {0} deve ser em uma data futura ou presente";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }
            var date = (DateOnly)value;
            return date >= DateOnly.FromDateTime(DateTime.Now);
        }
    }

}
