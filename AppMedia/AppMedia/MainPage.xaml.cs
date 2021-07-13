using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMedia.clases;
using AppMedia.model;
using Plugin.Media;
using Xamarin.Forms;
using SQLite;
namespace AppMedia
{
    public partial class MainPage : ContentPage
    {
        string ruta;
        public MainPage()
        {
            InitializeComponent();

          
               

        }
    

        private async void btnSeleccionarFoto_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombre.Text))
            {
                await DisplayAlert("Alert", "Campo vacio", "ok");
                return;
            }
            if (string.IsNullOrEmpty(descripcion.Text))
            {
                await DisplayAlert("Alert", "Campo vacio", "ok");
                return;
            }
            else
            {
                var data = new MediaVideo
                {
                    id = 0,
                    Nombre = nombre.Text,
                    descripcion = descripcion.Text,
                    MiImagen = ruta

                };


                try
                {
                    Conexion co = new Conexion();
                    co.Conn().CreateTable<MediaVideo>();
                    co.Conn().Insert(data);
                    co.Conn().Close();
                    await DisplayAlert("Save Fille", "Datos Guardados ", "ok");
                    nombre.IsEnabled = false;
                    descripcion.IsEnabled = false;
               
                    nombre.Text = "";
                    descripcion.Text = "";
                    nombre.IsVisible = false;
                    descripcion.IsVisible = false;


                }
                catch (SQLiteException ex)
                {

                    Console.WriteLine(ex.ToString());
                }

            }

        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsTakeVideoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Name = "video",
                Quality = Plugin.Media.Abstractions.VideoQuality.High,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front

            });


            if (file == null)
                return;

            await DisplayAlert("Ubicacion: ", file.Path, "OK");
            video.Source = file.Path;
            ruta = file.Path;
        
        nombre.IsVisible = true;
            descripcion.IsVisible = true;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoList());
        }
    }
}
