using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EndToEnd.Data;
public class ReservationService
{
    string _dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection conn;
    public ReservationService(string dbPath)
    {
        _dbPath = dbPath;
    }
    private async Task InitAsync()
    {
        // Don't Create database if it exists
        if (conn != null)
            return;
        // Create database and Reservation Table
        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Reservation>();
    }
    public async Task<List<Reservation>> GetReservationsAsync()
    {
        await InitAsync();
        return await conn.Table<Reservation>().ToListAsync();
    }
    public async Task<Reservation> CreateReservationAsync(
        Reservation reservation)
    {
        // Insert
        await conn.InsertAsync(reservation);
        return reservation;
    }
    public async Task<Reservation> UpdateReservationAsync(
        Reservation reservation)
    {
        // Update
        await conn.UpdateAsync(reservation);
        // Return the updated object
        return reservation;
    }
    public async Task<Reservation> DeleteReservationAsync(
        Reservation reservation)
    {
        // Delete
        await conn.DeleteAsync(reservation);
        return reservation;
    }
}