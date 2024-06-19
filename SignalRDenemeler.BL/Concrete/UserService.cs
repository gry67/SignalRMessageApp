using SignalRDenemeler.BL.Abstract;
using SignalRDenemeler.DAL.Abstract;
using SignalRDenemeler.DAL.Dtos;
using SignalRDenemeler.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDenemeler.BL.Concrete
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IGenericRepository<User> genericrepository, IUserRepository repository) :base(genericrepository)
        {
            this.repository = repository;
        }

        public DisconnectResponseDto SetDisconnectByConnectionId(string connectionId)
        {
            return repository.SetDisconnectByConnectionId(connectionId);
        }

        public void setConnectionId(string userName, string connectionId)
        {
            repository.setConnectionId(userName, connectionId);
        }

        public bool VarMi(User user)
        {
            return repository.VarMi(user);
        }

        public User getByConnectionId(string connectionId)
        {
            return repository.getByConnectionId(connectionId);
        }
    }
}
