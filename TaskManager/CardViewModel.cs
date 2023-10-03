using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager;

public class CardViewModel : INotifyPropertyChanged
{
    private CardModel _card = new CardModel("","","");

    public string TaskName
    {
        get { return _card.TaskName; }
        set
        {
            _card.TaskName = value;
            OnPropertyChanged();
        }
    }
    public string TaskInfo
    {
        get { return _card.TaskInfo; }
        set
        {
            _card.TaskInfo = value;
            OnPropertyChanged();
        }
    } 
    public string IconPath
    {
        get { return _card.IconPath; }
        set
        {
            _card.IconPath = value;
            OnPropertyChanged();
        }
    }

    public void Initialize(CardModel card)
    {
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
