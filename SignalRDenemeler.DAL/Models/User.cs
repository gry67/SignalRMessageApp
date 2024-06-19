using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.DAL.Models
{
    public class User : BaseEntity
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string? ClientId { get; set; }
    }
}
