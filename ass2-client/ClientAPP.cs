using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ass2_client
{
    internal class ClientAPP
    {
        // variables
        public static ObservableCollection<SaleProduct>? saleProducts;
        private static readonly HttpClient client = new();

        // constructor
        public ClientAPP()
        {
            GetProducts();
        }
        // --- http methods ---------------------------------------------------------------
        public static async void GetProducts()
        {
            try
            {
                saleProducts = new();
                var resp = client.GetFromJsonAsync<Response>("https://localhost:7022/Product/GetAllProducts");
                await resp;
                resp?.Result?.Products?.ForEach(p => saleProducts.Add(new SaleProduct(0, 0, p)));
                foreach (var p in saleProducts)
                {
                    p.PropertyChanged += SaleP_PropertyChanged;
                }
                saleProducts.CollectionChanged += SaleProducts_CollectionChanged;
                MainWindow.SaleInstance?.UpdateGrid();
            }
            catch (Exception) { MessageBox.Show("Failed to connect to API"); GetProducts(); }

        }
        public static async Task ReplaceAsync()
        {
            List<Product> products = new();
            if (saleProducts != null)
                foreach (Product p in saleProducts)
                {
                    products.Add(p);
                }
            _ = await client.PostAsJsonAsync("https://localhost:7022/Product/ReplaceProducts", products);
        }
        // --------------------------------------------------------------------------------

        // events
        private static void SaleProducts_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (saleProducts != null)
            {
                foreach (var p in saleProducts)
                {
                    p.PropertyChanged += SaleP_PropertyChanged;
                }
            }
        }

        private static void SaleP_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            double totalPrice = 0;
            if (saleProducts != null)
                foreach (SaleProduct sp in saleProducts)
                {
                    totalPrice += sp.Subtotal;
                }
            if (MainWindow.SaleInstance != null)
            {
                MainWindow.SaleInstance.labelTot.Content = string.Format("{0:C2}", totalPrice);
                MainWindow.SaleInstance.saleGrid.UpdateLayout();
            }
        }
    }
}
