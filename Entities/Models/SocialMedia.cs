using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public string Facebook { get; set; }
        public string İnstagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }
}
