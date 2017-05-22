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
      Get["/todo_all_tasks"] = _ => {
        List<string> allTasks = Task.GetInstances();
        return View["todo_all_tasks.cshtml", allTasks];
      };
      Post["/todo_confirmation"] = _ => {
        Task newTask = new Task(Request.Form["new-task"]);
        newTask.Save();
        return View["todo_confirmation.cshtml", newTask];
      };
      Post["/tasks_cleared"] = _ => {
        Task.ClearAll();
        return View["todo_form.cshtml"];
      };
    }
  }
}
