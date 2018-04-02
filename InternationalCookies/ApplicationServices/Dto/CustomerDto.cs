using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Dto
{
    public class CustomerDto
    {
         public int CustomerId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

    }
}
