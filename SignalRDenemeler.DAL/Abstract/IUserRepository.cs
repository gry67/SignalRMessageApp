using SignalRDenemeler.DAL.Dtos;
using SignalRDenemeler.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.DAL.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool VarMi(User user);
        void setConnectionId(string userName, string connectionId);
        DisconnectResponseDto SetDisconnectByConnectionId(string connectionId);
        User getByConnectionId(string connectionId);
    }
}
