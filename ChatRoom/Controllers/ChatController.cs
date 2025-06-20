using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ChatRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : Controller
    {
        // GET: ChatController
        //[HttpGet("GetMessages")]
        //public IEnumerable<Message> GetMessages()
        //{

        //}

        [HttpPost("PostMessage")]
        public ActionResult PostMessage([FromBody] Message message)
        {
            ChatServer.AddMessage(message, message.RoomID);

            return Ok();
        }

        [HttpPost("GetMessages")]
        public List<Message> GetMessages([FromBody] Guid roomID)
        {
            return ChatServer.messages[roomID];
        }

        [HttpPost("NewRoom")]
        public ActionResult NewRoom([FromBody] Guid roomID)
        {
            if (!ChatServer.messages.ContainsKey(roomID))
            {
                ChatServer.messages.Add(roomID, new List<Message>());
            }

            return Ok();
        }



        /*
                // GET: ChatController/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: ChatController/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: ChatController/Create
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create(string message)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: ChatController/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: ChatController/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: ChatController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: ChatController/Delete/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Delete(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }*/
    }
}