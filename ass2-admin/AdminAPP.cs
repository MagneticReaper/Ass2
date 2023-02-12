using Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using System.Net.Http.Json;
using System;

namespace ass2_admin
{
    internal class AdminAPP
    {
        // variables
        public static ObservableCollection<Product>? products;
        private static readonly HttpClient client = new();

        // constructor
        public AdminAPP()
        {
            GetProducts();
        }

        // --- http methods ---------------------------------------------------------------
        public static async void GetProducts()
        {
            try
            {
                products = new();
                var resp = client.GetFromJsonAsync<Response>("https://localhost:7022/Product/GetAllProducts");
                await resp;
                resp.Result?.Products?.ForEach(p => products.Add(p));
                foreach (var p in products)
                {
                    p.PropertyChanged += P_PropertyChanged;
                }
                products.CollectionChanged += Products_CollectionChanged;
            }
            catch (Exception) { MessageBox.Show("Failed to connect to API"); GetProducts(); }

        }
        private static async Task ReplaceAsync()
        {
            _ = await client.PostAsync("https://localhost:7022/Product/ReplaceProducts", new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
        }
        // --------------------------------------------------------------------------------

        // events
        private static async void P_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            await Task.Run(ReplaceAsync);
        }
        private static async void Products_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (products != null)
            {
                foreach (var p in products)
                {
                    p.PropertyChanged += P_PropertyChanged;
                }
            }
            await Task.Run(ReplaceAsync);
        }
    }
}
