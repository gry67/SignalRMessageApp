using Microsoft.EntityFrameworkCore;
using SignalRDenemeler.DAL.Abstract;
using SignalRDenemeler.DAL.Dtos;
using SignalRDenemeler.DAL.Models;
using System.Net.Mime;

namespace SignalRDenemeler.DAL.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public DisconnectResponseDto SetDisconnectByConnectionId(string connectionId)
        {
            var entity = context.users.SingleOrDefault(u=>u.ClientId == connectionId);
            if (entity==null)
            {
                return new DisconnectResponseDto() { result = false };
            }
            else
            {
                entity.ClientId = string.Empty;
                return new DisconnectResponseDto() { LeavedUser=entity,result = true };
            }
            
        }

        public void setConnectionId(string userName, string connectionId)
        {
            var entity = context.users.Single(u => u.userName == userName);
            entity.ClientId = connectionId;
            context.SaveChanges();
        }

        public bool VarMi(User user)
        {
            return context.users.Any(u => u.userName == user.userName);
        }

        public User getByConnectionId(string connectionId)
        {
            return context.users.SingleOrDefault(u => u.ClientId == connectionId);
        }
    }
}
