using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "minimum 3 caractere")]
        [MaxLength(25, ErrorMessage = "maximum 25 caractere")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
