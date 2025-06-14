using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult PostMessage([FromBody]Message message)
        {
            ChatServer.AddMessage(message);

            return Ok();
        }

        [HttpGet("GetMessages")]
        public IEnumerable<Message> GetMessages()
        {
            return ChatServer.messages;
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