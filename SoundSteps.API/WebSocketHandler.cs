using System.Net.WebSockets;
using System.Text;
namespace SoundSteps.API;
public static class WebSocketHandler
{
    private static readonly List<WebSocket> WebSockets = new List<WebSocket>();
    public static async Task HandleWebSocketAsync(WebSocket webSocket)
    {
        WebSockets.Add(webSocket);
        var buffer = new byte[1024 * 4];
        WebSocketReceiveResult result;
        do
        {
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }
        while (!result.CloseStatus.HasValue);
        WebSockets.Remove(webSocket);
        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }
    public static async Task NotifyClientsAsync(string message)
    {
        var toRemove = new List<WebSocket>();
        foreach (var socket in WebSockets)
        {
            if (socket.State == WebSocketState.Open)
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else
            {
                toRemove.Add(socket);
            }
        }
        foreach (var socket in toRemove)
        {
            WebSockets.Remove(socket);
        }
    }
}