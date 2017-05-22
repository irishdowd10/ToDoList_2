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
      Get["/todo_confirmation"] = _ => View["todo_confirmation.cshtml"];
      Get["/todo_all_tasks"] = _ => View["todo_all_tasks.cshtml"];
    }
  }
}
