using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1;

namespace YourProjectName.Controllers
{
    public class TodoController : Controller
    {
        private static List<ToDo> todoItems = new List<ToDo>();

        public ActionResult Index()
        {
            return View(todoItems);
        }

        [HttpPost]
        public ActionResult Add(string title)
        {
            var newItem = new ToDo
            {
                Id = todoItems.Count + 1,
                Title = title,
                IsCompleted = false
            };

            todoItems.Add(newItem);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(int id, bool isCompleted)
        {
            var todoItem = todoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem != null)
            {
                todoItem.IsCompleted = isCompleted;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var todoItem = todoItems.FirstOrDefault(t => t.Id == id);
            if (todoItem != null)
            {
                todoItems.Remove(todoItem);
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}