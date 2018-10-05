using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompaniesAndProducts.Models {
    public class Company {

        [Key]
        public int CompanyKey { get; set; }

        [Required]
        [DisplayName("Имя компании")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Сайт")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Site { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}