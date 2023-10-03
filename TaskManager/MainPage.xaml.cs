namespace TaskManager;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public async void ClickedEventArgs(object sender, EventArgs e)
    {
        var dataEntryPage = new DataEntryPage();
        dataEntryPage.Delete += DeleteDataEntryWindow;
        await Navigation.PushAsync(dataEntryPage);
    }

    public async void DeleteTask(Card card)
    {
        bool result = await DisplayAlert(
            "Подтвердить действие",
            "",
            "Да",
            "Нет"
        );
        if (result)
        {
            Tasks.Remove(card);
            card.Delete -= DeleteTask;
        }
    }

    public async void DeleteDataEntryWindow(DataEntryPage dataEntryWindow)
    {
        bool result = await DisplayAlert(
            "Подтвердить действие",
            "",
            "Да",
            "Нет"
        );
        if (result)
        {
            var card = new Card(new CardModel(dataEntryWindow.Card.TaskName, dataEntryWindow.Card.TaskInfo, dataEntryWindow.Card.IconPath));
            Tasks.Add(card);
            card.Delete += DeleteTask;
            await Navigation.PopAsync();
        }
    }
}
