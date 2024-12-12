using EJERCICIO_CRUD_MVVM.Views;

namespace EJERCICIO_CRUD_MVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage( new ProveedorMainView()));
        }
    }
}