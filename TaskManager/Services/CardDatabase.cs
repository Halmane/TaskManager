using Dapper;
using Microsoft.Data.Sqlite;

namespace TaskManager;

public class CardDatabase : IDisposable
{
    private SqliteConnection _connection;

    public CardDatabase(string path)
    {
        _connection = new SqliteConnection($"Data Source = {System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\{path}");
        _connection.Open();
        _connection.Execute("CREATE TABLE IF NOT EXISTS TASK (Id INTEGER PRIMARY KEY AUTOINCREMENT, TaskName TEXT, TaskInfo TEXT, IconPath TEXT)");
    }

    public async void InsertCard(CardModel card)
    {
        card.Id = await _connection.QuerySingleAsync<int>(
            "INSERT INTO Task(TaskName, TaskInfo, IconPath) VALUES(@TaskName,@TaskInfo,@IconPath) Returning Id;",
            new
            {
                TaskName = card.TaskName,
                TaskInfo = card.TaskInfo,
                IconPath = card.IconPath
            }
        );
    }

    public List<CardModel> SelectCards()
    {
        return  _connection.Query<CardModel>("SELECT TaskName,TaskInfo,IconPath,Id FROM Task").ToList();
    }

    public void DeleteCard(CardModel card)
    {
        _connection.Execute(
            "DELETE FROM Task WHERE Id = @Id;",
            new
            {
                Id = card.Id,
            }
        );
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}
