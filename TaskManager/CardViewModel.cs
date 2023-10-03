using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager;

public class CardViewModel : INotifyPropertyChanged
{
    public CardModel Card { get; private set; } = new CardModel("", "", "");

    public string TaskName
    {
        get { return Card.TaskName; }
        set
        {
            Card.TaskName = value;
            OnPropertyChanged();
        }
    }
    public string TaskInfo
    {
        get { return Card.TaskInfo; }
        set
        {
            Card.TaskInfo = value;
            OnPropertyChanged();
        }
    } 
    public string IconPath
    {
        get { return Card.IconPath; }
        set
        {
            Card.IconPath = value;
            OnPropertyChanged();
        }
    }

    public long Id
    {
        get { return Card.Id; }
        set
        {
            Card.Id = value;
            OnPropertyChanged();
        }
    }

    public void Initialize(CardModel card)
    {
        Id = card.Id;
        TaskName = card.TaskName;
        TaskInfo = card.TaskInfo;
        IconPath = card.IconPath;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
