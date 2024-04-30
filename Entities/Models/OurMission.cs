using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OurMission
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string SkillTitle { get; set; }
        public string SkillDescription { get; set; }
        public string SkillImage { get; set; }
    }
}
