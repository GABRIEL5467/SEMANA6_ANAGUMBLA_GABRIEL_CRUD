using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SEMANA6_ANAGUMBLA_GABRIEL
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.0.185/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<SEMANA6_ANAGUMBLA_GABRIEL.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<SEMANA6_ANAGUMBLA_GABRIEL.Datos> posts = JsonConvert.DeserializeObject<List<SEMANA6_ANAGUMBLA_GABRIEL.Datos>>(content);
                _post = new ObservableCollection<SEMANA6_ANAGUMBLA_GABRIEL.Datos>(posts);

              
            }
            catch (Exception ex)
            {
                DisplayAlert("error", "error" + ex.Message, "ok");

            }

        }

        private async void btnGet_Clicked(object sender, EventArgs e)

        {
            await Navigation.PushModalAsync(new InsertPost());

            //var content = await client.GetStringAsync(Url);
            // List<SEMANA6_ANAGUMBLA_GABRIEL.Datos> posts = JsonConvert.DeserializeObject<List<SEMANA6_ANAGUMBLA_GABRIEL.Datos>>(content);
            //  _post = new ObservableCollection<SEMANA6_ANAGUMBLA_GABRIEL.Datos>(posts);

            //  MyListView.ItemsSource = _post;
        }
    

        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Put());

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Eliminar());


        }
      

       
    }
}
