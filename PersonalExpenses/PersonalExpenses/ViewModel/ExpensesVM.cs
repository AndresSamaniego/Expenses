using PersonalExpenses.Model;
using PersonalExpenses.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel
{
    public class ExpensesVM : INotifyPropertyChanged
    {
        public ICommand NewExpenseCommand { get; set; }

        public ICommand DeleteExpenseCommand { get; set; }

        public ICommand RefreshExpensesCommand { get; set; }

        public ObservableCollection<Expense> Expenses { get; set; }

        private Expense selectedExpense;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public Expense SelectedExpense
        {
            get { return selectedExpense; }
            set
            {
                selectedExpense = value;
                OnPropertyChanged("SelectedExpense");
                App.Current.MainPage.Navigation.PushAsync(new ExpenseDetailPage(selectedExpense));
            }
        }

        public ExpensesVM()
        {
            NewExpenseCommand = new Command(NewExpense);
            DeleteExpenseCommand = new Command<Expense>(DeleteExpense);
            RefreshExpensesCommand = new Command(ReadExpenses);
            Expenses = new ObservableCollection<Expense>();
        }

        private void NewExpense()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewExpensePage(), true);
        }

        private void DeleteExpense(Expense expense)
        {
            expense.DeleteExpense();
            Expenses.Remove(expense);
        }
        
        public void ReadExpenses()
        {
            IsRefreshing = true;
            var expenses = Expense.ReadExpenses();
            Expenses.Clear();
            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
            IsRefreshing = false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
