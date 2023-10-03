namespace TaskManager;

public partial class DataEntryPage : ContentPage
{
    public CardModel Card {  get; private set; }
    private string _iconPath;
    public delegate void DeleteThisDataEntryPage(DataEntryPage dataEntryPage);
    public event DeleteThisDataEntryPage Delete;

    public DataEntryPage()
    {
        InitializeComponent();
        IconsInitialize();
    }

    public void Button_Clicked(object sender, EventArgs e)
    {
        Delete.Invoke(this);
        Card = new CardModel(TaskName.Text, TaskInfo.Text, _iconPath);
    }

    public void IconsInitialize()
    {
        var IconsPaths = new List<string>() { "home.png", "star.png", "plus.png" };
        var color = new Color(49, 51, 56, 255);
        foreach (var IconPath in IconsPaths) 
        {
            var icon = new ImageButton() { Source = IconPath, CornerRadius = 45, BackgroundColor = color };
            icon.Clicked += (s, e) => { _iconPath = IconPath; };
            Icons.Add(icon);
        }
    }

    public string IconClicked()
    {

        return "star.png";
    }
}
