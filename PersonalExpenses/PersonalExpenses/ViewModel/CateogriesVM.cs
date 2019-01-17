using PCLStorage;
using PersonalExpenses.Model;
using PersonalExpenses.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel
{
    public class CateogriesVM : INotifyPropertyChanged
    {
        public ObservableCollection<Progress> Progresses { get; set; }

        public ICommand ShareCommand { get; set; }
        
        private bool hasProgresses;

        public bool HasProgresses
        {
            get { return hasProgresses; }
            set
            {
                hasProgresses = value;
                OnPropertyChanged("HasProgresses");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public CateogriesVM()
        {
            HasProgresses = false;
            Progresses = new ObservableCollection<Progress>();
            ShareCommand = new Command<bool>(Share, ShareCommmandCanExecute);
        }

        public void GetProgresses()
        {
            Progresses.Clear();
            var categories = Model.Category.GetCategories();
            var expenses = Expense.ReadExpenses();

            if (expenses != null)
            {
                double totalExpenses = expenses.Sum(e => e.Quantity);
                foreach (var category in categories)
                {
                    var totalAmount = expenses.Where(x => x.Category == category).Sum(e => e.Quantity);
                    Progresses.Add(new Progress() { Name = category, ProgressValue = totalAmount / totalExpenses });
                }

                HasProgresses = true;
            }
        }

        bool ShareCommmandCanExecute(bool arg)
        {
            return arg;
        }

        async void Share(bool canExecute)
        {
            IFileSystem fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);
            var reportFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using (StreamWriter stream = new StreamWriter(reportFile.Path))
            {
                foreach (var progress in Progresses)
                {
                    stream.WriteLine($"{progress.Name} - {progress.ProgressValue:p}");
                }
            }

            IShare shareDependency = DependencyService.Get<IShare>();

            await shareDependency.Show("Reporte de Gastos", "Reporte de gastos por categoria", reportFile.Path);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Progress
    {
        public string Name { get; set; }
        public double ProgressValue { get; set; }
    }
}


