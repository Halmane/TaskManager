namespace TaskManager;

public partial class Card : ContentView
{
    public delegate void DeleteThisTask(Card ñard);
    public event DeleteThisTask Delete;

    public Card(CardModel cardInfo)
	{
        InitializeComponent();
        VM.Initialize(cardInfo);
    }

    public void Button_Clicked(object sender, EventArgs e)
    {
        Delete.Invoke(this);
    }
}