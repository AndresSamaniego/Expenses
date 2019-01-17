using PersonalExpenses.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PersonalExpenses.ViewModel
{
    public class ExpenseDetailVM : INotifyPropertyChanged
    {
        private Expense expense;
        public Expense Expense
        {
            get { return expense; }
            set
            {
                expense = value;
                //Name = expense.Name;
                //Quantity = expense.Quantity;
                //Date = expense.Date;
                //Category = expense.Category;
                OnPropertyChanged("Expense");
            }
        }

        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}

        //private double quantity;
        //public double Quantity
        //{
        //    get { return quantity; }
        //    set
        //    {
        //        quantity = value;
        //        OnPropertyChanged("Quantity");
        //    }
        //}

        //private DateTime date = DateTime.Today;
        //public DateTime Date
        //{
        //    get { return date; }
        //    set
        //    {
        //        date = value;
        //        OnPropertyChanged("Date");
        //    }
        //}

        //private string category;
        //public string Category
        //{
        //    get { return category; }
        //    set
        //    {
        //        category = value;
        //        OnPropertyChanged("Category");
        //    }
        //}
        public event PropertyChangedEventHandler PropertyChanged;

        public ExpenseDetailVM()
        {

        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
