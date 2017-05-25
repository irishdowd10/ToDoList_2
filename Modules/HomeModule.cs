using Nancy;
using System.Collections.Generic;
using ToDo.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
         Get["/"] = _ => {
             return View["index.cshtml"];
         };
         Get["/category"] = _ => {
           List<Category> allCategories = Category.GetAll();
           return View["categories.cshtml", allCategories];
         };
         Get["/category/new"] = _ => {
           return View["category_form.cshtml"];
         };
         Post["/categories"] = _ => {
          Category newCategory = new Category(Request.Form["category-name"]);
           List<Category> allCategories = Category.GetAll();
           return View["categories.cshtml", allCategories];
         };
         Get["/categories/{id}"] = parameters => {
           Dictionary<string, object> model = new Dictionary<string, object>();
           Category selectedCategory = Category.Find(parameters.id);
           List<Task> categoryTasks = selectedCategory.GetTasks();
           model.Add("category", selectedCategory);
           model.Add("tasks", categoryTasks);
           return View["category.cshtml", model];
         };
         Get["/categories/{id}/task/new"] = parameters => {
           Dictionary<string, object> model = new Dictionary<string, object>();
           Category selectedCategory = Category.Find(parameters.id);
           List<Task> allTask = selectedCategory.GetTasks();
           model.Add("category", selectedCategory);
           model.Add("task", allTask);
           return View["category_task_form.cshtml", model];
         };
         Post["/tasks"] = _ => {
           Dictionary<string, object> model = new Dictionary<string, object>();
           Category selectedCategory = Category.Find(Request.Form["category-id"]);
           List<Task> categoryTasks = selectedCategory.GetTasks();
           string taskDescription = Request.Form["task-description"];
           Task newTask = new Task(taskDescription);
           categoryTasks.Add(newTask);
           model.Add("tasks", categoryTasks);
           model.Add("category", selectedCategory);
           return View["category.cshtml", model];
         };
       }
     }
   }
