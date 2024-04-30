using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }
        public string ClientMail { get; set; }
    }
}
