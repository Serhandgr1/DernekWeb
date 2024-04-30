using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class LogoDto
    {
        public int Id { get; set; }
        public IFormFile formFile { get; set; }
        public string Image { get; set; }
    }
}
