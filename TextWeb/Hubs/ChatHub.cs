using Microsoft.AspNetCore.SignalR;

namespace TextWeb.Hubs; 
public class ChatHub : Hub{
    private static Dictionary<string, string> _clients = new Dictionary<string, string>(); 

    //public Task UpdateReceiver(string otherID) {
    //    _clients[Context.ConnectionId] = otherID;
    //    return base.OnConnectedAsync();
    //}

    public Task SendAll(string user, string message) {
        return Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public Task SendToOne(string otherID, string selfID, string message) {
        return Clients.Client(otherID).SendAsync("ReceiveMessage" ,selfID, message);   
    }
    public Task UpdateToSelf(string selfID, string message) {
        return Clients.Client(selfID).SendAsync("ReceiveMessage", selfID, message);
    }
}
