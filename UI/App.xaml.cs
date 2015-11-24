using System.Windows;

namespace UI {
    public partial class App {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Start(new MainWindow());
        }
    }
}