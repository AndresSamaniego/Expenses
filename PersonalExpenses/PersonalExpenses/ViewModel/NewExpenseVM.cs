using PersonalExpenses.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel
{
    public class NewExpenseVM : INotifyPropertyChanged
    {
        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        private Expense expense;
        public Expense Expense
        {
            get { return expense; }
            set
            {
                expense = value;
                Name = expense.Name;
                Quantity = expense.Quantity;
                Date = expense.Date;
                Category = expense.Category;
                OnPropertyChanged("Expense");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private double quantity;
        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private DateTime date = DateTime.Today;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }

        public ICommand SaveExpenseCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewExpenseVM()
        {
            IsEditing = false;
            SaveExpenseCommand = new Command(SaveExpense);

            Categories = new ObservableCollection<string>();
            foreach (string category in Model.Category.GetCategories())
            {
                Categories.Add(category);
            }
        }

        void SaveExpense()
        {
            Expense expense = new Expense()
            {
                Name = this.Name,
                Quantity = Quantity,
                Date = Date,
                Category = Category
            };

            var saved = expense.InsertExpense();

            if (saved)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Error", "Error al insertar el gasto", "Ok");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
