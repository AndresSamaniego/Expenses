using PersonalExpenses.Model;
using PersonalExpenses.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalExpenses.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpenseDetailPage : ContentPage
    {
        ExpenseDetailVM viewModel;

        public ExpenseDetailPage()
		{
			InitializeComponent();
		}

        public ExpenseDetailPage(Expense expense)
        {
            InitializeComponent();

            viewModel = Resources["vm"] as ExpenseDetailVM;

            viewModel.Expense = expense;
        }
    }
}