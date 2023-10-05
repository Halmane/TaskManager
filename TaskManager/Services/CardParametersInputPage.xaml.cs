namespace TaskManager;

public partial class CardParametersInputPage : ContentPage
{
    public CardModel Card {  get; private set; }
    private string _iconPath;
    public event Action<CardParametersInputPage> CloseAndSave;

    public CardParametersInputPage()
    {
        InitializeComponent();
        IconsInitialize();
    }

    public void Button_Clicked(object sender, EventArgs e)
    {
        Card = new CardModel(TaskName.Text, TaskInfo.Text, _iconPath);
        CloseAndSave?.Invoke(this);
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
