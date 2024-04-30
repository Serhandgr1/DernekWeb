using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public static class ClientTokenDto
    {
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
    }
}
