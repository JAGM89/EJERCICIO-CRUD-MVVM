using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EJERCICIO_CRUD_MVVM.Models;
using EJERCICIO_CRUD_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_CRUD_MVVM.ViewModels
{
    public partial class ProveedorFormViewModel:ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string codigo;

        [ObservableProperty]
        private string nombreproveedor;

        [ObservableProperty]
        private string empresa;

        [ObservableProperty]
        private string direccion;

        private readonly ProveedorService service;


        public ProveedorFormViewModel()
        {
            service = new ProveedorService();
        }

        public ProveedorFormViewModel(Proveedores proveedores)
        {
            service=new ProveedorService();
            Id =proveedores.Id;
            Codigo=proveedores.Codigo;
            Nombreproveedor = proveedores.NombreProveedor;
            Empresa=proveedores.Empresa;
            Direccion=proveedores.Direccion;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Proveedores proveedores = new Proveedores();
                proveedores.Id = Id;
                proveedores.Codigo = Codigo;
                proveedores.NombreProveedor = Nombreproveedor;
                proveedores.Empresa = Empresa;
                proveedores.Direccion = Direccion;

                if (Validar(proveedores))
                {
                    if (Id == 0)
                    {
                        service.Insert(proveedores);
                    }
                    else
                    {
                        service.Update(proveedores);
                    }
                    // Regresa a la pantalla principal
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Proveedores proveedores)
        {
            if (proveedores.Codigo == null || proveedores.Codigo == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el código del proveedor");
                return false;
            }
            else if (proveedores.NombreProveedor== null || proveedores.NombreProveedor == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre del proveedor");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
