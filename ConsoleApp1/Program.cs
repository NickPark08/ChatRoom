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
            Guid testRoom;

            Console.WriteLine("Please enter your user id");
            user = Console.ReadLine();

            Console.WriteLine("Now please enter the id of the chatroom you would like to join, or type 'create' to create one");
            roomID = Console.ReadLine();

            Guid.TryParse(roomID, out testRoom);

            var newRoomResponse = await httpClient.PostAsync(@"https://localhost:7211/Chat/NewRoom", JsonContent.Create(testRoom));
            try
            {
                newRoomResponse.EnsureSuccessStatusCode();
            }
            catch
            {
                Console.WriteLine("thingy no worky :(");
            }


            sb.AppendLine(user + ": ");

            var getResponse = await httpClient.PostAsync(@"https://localhost:7211/Chat/GetMessages", JsonContent.Create(testRoom));
            var content = await getResponse.Content.ReadFromJsonAsync<List<Message>>();


            while (true)
            {
                getResponse = await httpClient.PostAsync(@"https://localhost:7211/Chat/GetMessages", JsonContent.Create(testRoom));
                content = await getResponse.Content.ReadFromJsonAsync<List<Message>>();

                if (content.Count != oldMessage.Count)
                {
                    Console.Clear();
                    //foreach (var mes in content)
                    //{
                    //    if (mes.Key == testRoom)
                    //    {

                    //        Console.ForegroundColor = mes.Value;
                    //        Console.WriteLine(mes.MessageContent);
                    //        Console.WriteLine();
                    //    }
                    //}
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
                        message = new Message(messageContent, color, testRoom);

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
