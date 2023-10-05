namespace TaskManager;

public partial class MainPage : ContentPage
{
    private CardDatabase _cardDatabase;
    public MainPage()
    {
        InitializeComponent();
        _cardDatabase = new CardDatabase("Tasks.db");
        var cards = _cardDatabase.SelectCards();
        foreach (var cardModel in cards)
        {
            var card = new Card(cardModel);
            Tasks.Add(card);
            card.Delete += DeleteTask;
        }
    }

    public async void ClickedEventArgs(object sender, EventArgs e)
    {
        var cardParametersInputPage = new CardParametersInputPage();
        cardParametersInputPage.CloseAndSave += CloseAndSave;
        await Navigation.PushAsync(cardParametersInputPage);
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
            _cardDatabase.DeleteCard(card.VM.Card);
            Tasks.Remove(card);
            card.Delete -= DeleteTask;
        }
    }

    public async void CloseAndSave(CardParametersInputPage сardParametersInputPage)
    {
        bool result = await DisplayAlert(
            "Подтвердить действие",
            "",
            "Да",
            "Нет"
        );
        if (result)
        {
            var cardModel = new CardModel(сardParametersInputPage.Card.TaskName, сardParametersInputPage.Card.TaskInfo, сardParametersInputPage.Card.IconPath);
            _cardDatabase.InsertCard(cardModel);
            var card = new Card(cardModel);
            Tasks.Add(card);
            card.Delete += DeleteTask;
            await Navigation.PopAsync();
        }
    }
}
