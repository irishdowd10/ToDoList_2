using Nancy;
using ToDo.Objects;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["todo_form.cshtml"];
      Get["/todo_confirmation"] = _ => {
        Task newTask = new Task(Request.Query["new-task"]);
        return View["todo_confirmation.cshtml", newTask];
      };
      // Get["/todo_all_tasks"] = _ => View["todo_all_tasks.cshtml"];
    }
  }
}
