using System.Collections.Generic;

namespace ToDo.Objects
{
  public class Task
  {
    private string _description;
    private static List<string> _instances = new List<string> {};

    public Task(string newDescription)
    {
      _description = newDescription;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public List<string> GetInstances()
    {
      return _instances;
    }
    public void SaveInstance()
    {
      _instances.Add(_description);
    }
  }
}
