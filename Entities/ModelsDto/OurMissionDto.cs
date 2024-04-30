using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class OurMissionDto
    {
        public int Id { get; set; }
      public  IFormFile formFile { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string SkillTitle { get; set; }
        public string SkillDescription { get; set; }
        public string SkillImage { get; set; }
      public  IFormFile skillFile { get; set; }
    }
}
