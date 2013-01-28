 
using System.Windows;

namespace RoverApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            var  context = new MainWindowViewModel();
            mainWindow.DataContext = context;
            mainWindow.Show();
        }

    }
}
