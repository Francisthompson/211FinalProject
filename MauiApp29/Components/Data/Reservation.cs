using SQLite;
namespace EndToEnd.Data;
public class Reservation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Customer { get; set; }

    public string Time { get; set; }

    public int Table { get; set; }
}