using Microsoft.AspNetCore.SignalR;
using SignalRDenemeler.BL.Abstract;
using SignalRDenemeler.DAL.Abstract;
using SignalRDenemeler.DAL.Dtos;
using SignalRDenemeler.DAL.Models;

namespace SignalRDenemeler.Hubs
{
    public class MyHub : Hub
    {
        private readonly IGenericService<User> service;
        private readonly IUserService userService;

        public MyHub(IGenericService<User> service, IUserService userService)
        {
            this.service = service;
            this.userService = userService;
        }


        public async Task SendMessageAsync(string userName, string message)
        {
            await Clients.All.SendAsync("receiveMessage", userName,message);
        }

        public override async Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["username"].ToString();
            userService.setConnectionId(username,Context.ConnectionId);
            await Clients.All.SendAsync("JoinMessage", $"{username} Sohbete Katıldı\n<br />");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            DisconnectResponseDto sonuc = userService.SetDisconnectByConnectionId(Context.ConnectionId);
            if (sonuc.result==false)
            {
                await Clients.All.SendAsync("LeaveMessage", "Bir kullanıcı ayrıldı ancak Veritabanında kayıtlı değil");
            }else
            {
                await Clients.All.SendAsync("LeaveMessage", $"{sonuc.LeavedUser.userName} sohbetten ayrıldı");
            }
        }
    }
}
