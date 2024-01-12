using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wfaTemplateData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyTask> listTasks;
        MyTask newTask = new();
        public MainWindow()
        {
            InitializeComponent();
            List<string> listPhones = new() { "iPhone 6S", "Samsumg", "Honor", "Huawei" };
            listBoxPhones.ItemsSource = listPhones;

            listTasks = new()
            {
                new MyTask() {TaskName="play", Description="dfghjk", Priority=0},
                new MyTask() {TaskName="buy", Description="ghjkl.j", Priority = 1},

            };
            listBoxTasks.ItemsSource = listTasks;

            stackPanelAdd.DataContext = newTask;

            buAdd.Click += BuAdd_Click;
        }

        private void BuAdd_Click(object sender, RoutedEventArgs e)
        {
            //listTasks.Add(new MyTask() { TaskName = "1111" });
            listTasks.Add(newTask);
        }
    }
    class MyTask : IDataErrorInfo
    {
        

        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public int? Priority { get; set; }

        public string this[string columnName]
        {
            get
            {
                string err = string.Empty;
                switch(columnName)
                {
                    case "TaskName":
                        break;
                    case "Prioriry":
                        if (this.Priority != 0)
                            err = "Приоритет должен быть не ноль";
                        break;

                            
                }
                return err;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
