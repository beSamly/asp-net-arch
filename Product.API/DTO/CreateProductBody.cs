using System.ComponentModel.DataAnnotations;
using Product.API.CustomAttributes;

namespace Product.API.DTO
{
    public class CreateProductBody
    {
        [Required] 
        public string name { get; set; }

        [Required] 
        [Email(level:"mylevel",value : "myvalue")]
        public string email { get; set; }
    }
}