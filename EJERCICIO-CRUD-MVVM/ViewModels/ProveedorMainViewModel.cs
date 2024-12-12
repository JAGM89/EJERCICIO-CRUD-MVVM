using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EJERCICIO_CRUD_MVVM.Models;
using EJERCICIO_CRUD_MVVM.Services;
using System.Collections.ObjectModel;
using EJERCICIO_CRUD_MVVM.Views;


namespace EJERCICIO_CRUD_MVVM.ViewModels
{
    public partial class ProveedorMainViewModel:ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedores> proveedoresCollection = new ObservableCollection<Proveedores>();

        private readonly ProveedorService service;

        public ProveedorMainViewModel()
        {
            service = new ProveedorService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = service.GetAll();

            if (getAll.Count > 0)
            {
                ProveedoresCollection.Clear();
               
                foreach (var proveedor in getAll)
                {
                    ProveedoresCollection.Add(proveedor);
                }
            }
        }

        [RelayCommand]
        private async Task GoToProveedorFormView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProveedorFormView());
        }

        [RelayCommand]
        private async Task GoToEditProveedorFormView(Proveedores proveedores)
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProveedorFormView(proveedores));
        }

        private async Task EliminarProveedor(Proveedores proveedores)
        {
            try
            {
                bool respuesta = await App.Current!.MainPage.DisplayAlert("ELIMINAR PROVEEDOR", "¿Desea eliminar el proveedor?", "Si", "No");

                if (respuesta)
                {
                    int del = service.Delete(proveedores);

                    if (del > 0)
                    {
                        Alerta("ELIMINAR PROVEEDOR", "Proveedor eliminado correctamente");
                        ProveedoresCollection.Remove(proveedores);
                    }
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        [RelayCommand]
        private async Task SelectProveedor(Proveedores proveedores)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await GoToEditProveedorFormView(proveedores);
                }
                else if (res == ELIMINAR)
                {
                    await EliminarProveedor(proveedores);
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
