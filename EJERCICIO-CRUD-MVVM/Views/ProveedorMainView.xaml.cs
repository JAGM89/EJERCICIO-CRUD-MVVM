using EJERCICIO_CRUD_MVVM.ViewModels;

namespace EJERCICIO_CRUD_MVVM.Views;

public partial class ProveedorMainView : ContentPage
{
	private ProveedorMainViewModel viewModel;
	public ProveedorMainView()
	{
		InitializeComponent();
		viewModel = new ProveedorMainViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }

}