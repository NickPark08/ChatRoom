using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using ChatRoom;
using Microsoft.AspNetCore.Components.Forms;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            bool userOne = true;
            string messageContent;
            string user;
            string roomID;
            List<Message> oldMessage = [];
            StringBuilder sb = new StringBuilder();
            ConsoleColor color = ConsoleColor.White;

            Console.WriteLine("Please enter your user id");
            user = Console.ReadLine();

            Console.WriteLine("Now please enter the id of the chatroom you would like to join, or type 'create' to create one");
            roomID = Console.ReadLine();




            var getResponse = await httpClient.GetAsync(@"https://localhost:7211/Chat/GetMessages");
            List<Message> content = await getResponse.Content.ReadFromJsonAsync<List<Message>>();

            sb.AppendLine(user + ": ");

            while (true)
            {
                getResponse = await httpClient.GetAsync(@"https://localhost:7211/Chat/GetMessages");
                content = await getResponse.Content.ReadFromJsonAsync<List<Message>>();

                if (content.Count != oldMessage.Count)
                {
                    Console.Clear();
                    foreach (var mes in content)
                    {
                        Console.ForegroundColor = mes.User;
                        Console.WriteLine(mes.MessageContent);
                        Console.WriteLine();
                    }
                }
                oldMessage = content;


                Console.ForegroundColor = ConsoleColor.White;

                Message message = null;
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        //send message
                        messageContent = sb.ToString();
                        message = new Message(messageContent, color, roomID);

                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace || keyInfo.Key == ConsoleKey.Delete)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    else
                    {
                        sb.Append(keyInfo.KeyChar);
                    }

                    if (message != null)
                    {
                        var postResponse = await httpClient.PostAsync(@"https://localhost:7211/Chat/PostMessage", JsonContent.Create(message));
                        try
                        {
                            postResponse.EnsureSuccessStatusCode();
                        }
                        catch
                        {
                            Console.WriteLine("thingy no worky :(");
                        }
                        userOne = !userOne;
                        sb.Clear();
                        sb.AppendLine(user + ": ");
                    }
                ;
                }
            }
        }
    }
}
