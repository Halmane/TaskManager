using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager;

public class CardModel
{
    public long Id { get; set; }
    public string TaskName;
    public string TaskInfo;
    public string IconPath;

    public CardModel(string taskName, string taskInfo, string iconPath, long id = 0)
    {
        Id = id;
        TaskInfo = taskInfo;
        TaskName = taskName;
        IconPath = iconPath;
    }
}
