using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacebookAuth.Utils
{
    public class ObjectValidator
    {
        public static bool Validate<T>(T obj)
        {
            var context = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, validationResults, true);
        }
    }
}
