using AppMedia.clases;
using AppMedia.model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMedia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoList : ContentPage
    {
        Crud crud = new Crud();
        public VideoList()
        {
            InitializeComponent();
            mostrarDatos();

        }
        async void volverPage(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }

     

        public async void mostrarDatos()
        {
            try
            {


                var imgLista = await crud.getReadMedia();


                if (imgLista != null)
                {
                    listaItems.ItemsSource = imgLista;
                }
                else
                {
                    await DisplayAlert("Lista", "no hay registros", "ok");
                }

            }
            catch (SQLiteException e)
            {
                await DisplayAlert("Lista", "no hay registros", "ok");

            }


        }
       

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mostrarDatos();
        }
        private async void listaItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var obj = (MediaVideo)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {
                var listaSeleccionada = await crud.GetMediaId((obj.id));
                if (listaSeleccionada != null)
                {
                    var getLista = new Lista
                    {
                        idimage = (listaSeleccionada.id),
                        Nombre = (listaSeleccionada.Nombre),
                        descripcion=(listaSeleccionada.descripcion),
                        image = (listaSeleccionada.MiImagen)

                    };


                    var datos = new VideoView();
                    datos.BindingContext = getLista;
                    await Navigation.PushAsync(datos);


                }

            }

        }

    }

}