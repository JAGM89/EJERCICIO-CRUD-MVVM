using EJERCICIO_CRUD_MVVM.Models;
using EJERCICIO_CRUD_MVVM.ViewModels;

namespace EJERCICIO_CRUD_MVVM.Views;

public partial class ProveedorFormView : ContentPage
{
	ProveedorFormViewModel viewModel= new ProveedorFormViewModel();
	public ProveedorFormView()
	{
		InitializeComponent();
		viewModel= new ProveedorFormViewModel();
		BindingContext= viewModel;
	}

	public ProveedorFormView(Proveedores proveedores)
	{
		InitializeComponent();
		viewModel= new ProveedorFormViewModel(proveedores);
		BindingContext= viewModel;

	}
}