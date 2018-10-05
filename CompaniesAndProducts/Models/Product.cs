
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompaniesAndProducts.Models {
    public class Product {

        [Key]
        public int ProductKey { get; set; }

        [Required]
        [DisplayName("Компания")]
        public int? CompanyKey { get; set; }

        [ForeignKey("CompanyKey")]
        [DisplayName("Компания")]
        public virtual Company Company { get; set; }

        [Required]
        [DisplayName("Имя продукта")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Комиссия")]
        [MaxLength(50)]
        public string Comission { get; set; }
        
    }
}