using SignalRDenemeler.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.DAL.Dtos
{
    public class DisconnectResponseDto
    {
        public User LeavedUser { get; set; }
        public bool result { get; set; }
    }
}
