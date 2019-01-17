using Microsoft.AppCenter.Analytics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenses.Model
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public Expense()
        {
            Date = DateTime.Today;
        }
        
        public bool InsertExpense()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Expense>();
                    Analytics.TrackEvent("Insert expense");
                    return conn.Insert(this) > 0;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Expense> ReadExpenses()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable(typeof(Expense));
                Analytics.TrackEvent("Read expenses");
                return conn.Table<Expense>().ToList();
            }
        }

        public int DeleteExpense()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable(typeof(Expense));
                Analytics.TrackEvent("Delete expense");
                return conn.Delete(this);
            }
        }
    }
}
