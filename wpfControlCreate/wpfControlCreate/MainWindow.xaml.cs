using System;
using System.Collections.Generic;
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

namespace wpfControlCreate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new();
        public MainWindow()
        {
            InitializeComponent();

            this.MouseDown += MainWindow_MouseDown;
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed) { }

            if(e.ChangedButton == MouseButton.Left)
            {
                Label la = new();
                la.SetValue(Canvas.LeftProperty, e.GetPosition(this).X);
                la.SetValue(Canvas.TopProperty, e.GetPosition(this).Y);
                la.Content = $"{la.GetValue(Canvas.LeftProperty)}:{la.GetValue(Canvas.TopProperty)}";
                la.Background = Brushes.LightCoral;
                Main.Children.Add( la );
            }
            else if(e.ChangedButton == MouseButton.Right)
            {
                for (int i = 0; i<10; i++)
                {
                    Label la = new();
                    la.SetValue(Canvas.LeftProperty, (double)rnd.Next(Convert.ToInt32(this.Main.Width)));
                    la.SetValue(Canvas.TopProperty, (double)rnd.Next(Convert.ToInt32(this.Main.Height)));
                    la.Content = $"{la.GetValue(Canvas.LeftProperty):0}:{la.GetValue(Canvas.TopProperty):0}";
                    la.Background = Brushes.Blue;
                    //Color.FromRgb((byte))
                    Main.Children.Add(la);
                }
            }else if(e.ChangedButton == MouseButton.Middle){
                Main.Children.Clear();
            }
        }
    }
}
