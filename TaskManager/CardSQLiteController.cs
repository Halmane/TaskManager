using Dapper;
using Microsoft.Data.Sqlite;

namespace TaskManager;

public class CardSQLiteController : IDisposable
{
    private SqliteConnection _connection;

    public CardSQLiteController(string path)
    {
        _connection = new SqliteConnection($"Data Source={path}");
        _connection.Open();
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
