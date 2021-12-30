using System.ComponentModel.DataAnnotations;

namespace Product.API.CustomAttributes
{
    public class Email : ValidationAttribute
    {
        private readonly string _level;
        private readonly string _value;
        public Email(string value, string level) : base(errorMessage: "it is not email")
        {
            _level = level;
            _value = value;
        }//

        public override bool IsValid(object value)
        {
            string email = (string) value;
            return email.Contains('@') ? true : false;
        }
    }
}