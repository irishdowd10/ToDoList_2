using System.Collections.Generic;

namespace ToDo.Objects
{
  public class Task
  {
    public string Description {get;set;}
    private static List<string> _instances = new List<string> {};

    public Task(string newDescription)
    {
      Description = newDescription;
    }

    public List<string> GetInstances()
    {
      return _instances;
    }
    public void SaveInstance()
    {
      _instances.Add(Description);
    }
  }
}
