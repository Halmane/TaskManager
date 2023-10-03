using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager;

public class CardModel
{
    public string TaskName;
    public string TaskInfo;
    public string IconPath;

    public CardModel(string taskName, string taskInfo, string iconPath)
    {
        TaskInfo = taskInfo;
        TaskName = taskName;
        IconPath = iconPath;
    }
}
