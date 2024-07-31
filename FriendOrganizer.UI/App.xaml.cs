using Autofac;
using FriendOrganizer.UI.Startup;
using System.Windows;

namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var container = new BootStrapper().Bootstrap();
            #region código anterior à implementação do Autofac
            /*
            var mainWindow = new MainWindow(
                    new ViewModel.MainViewModel(
                            new FriendDataService()
                        )
                );
            */
            #endregion

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }

}
