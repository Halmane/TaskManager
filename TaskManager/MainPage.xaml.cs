namespace TaskManager;

public partial class MainPage : ContentPage
{
    private CardSQLiteController cardSQLiteController;
    public MainPage()
    {
        InitializeComponent();
        cardSQLiteController = new CardSQLiteController("D:\\C#Project\\TaskManager\\Tasks.db");
        var cards = cardSQLiteController.SelectCards();
        foreach (var cardModel in cards)
        {
            var card = new Card(cardModel);
            Tasks.Add(card);
            card.Delete += DeleteTask;
        }
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
            cardSQLiteController.DeleteCard(card.VM.Card);
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
            var cardModel = new CardModel(dataEntryWindow.Card.TaskName, dataEntryWindow.Card.TaskInfo, dataEntryWindow.Card.IconPath);
            cardSQLiteController.InsertCard(cardModel);
            var card = new Card(cardModel);
            Tasks.Add(card);
            card.Delete += DeleteTask;
            await Navigation.PopAsync();
        }
    }
}
