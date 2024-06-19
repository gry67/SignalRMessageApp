using SignalRDenemeler.DAL.Dtos;
using SignalRDenemeler.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.BL.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        bool VarMi(User user);
        void setConnectionId(string userName, string connectionId);
        DisconnectResponseDto SetDisconnectByConnectionId(string connectionId);
        User getByConnectionId(string connectionId);
    }
}
