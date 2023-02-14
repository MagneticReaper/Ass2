using Models;

namespace ass2_client
{
    internal class SaleProduct : Product
    {
        private int saleQTY;
        private double subtotal;
        private string _subTot = "";

        public SaleProduct(int saleQTY, double subtotal, Product product)
        {
            SaleQTY = saleQTY;
            Subtotal = subtotal;
            Name = product.Name;
            Amount = product.Amount;
            Price = product.Price;
            Id = product.Id;
        }
        public SaleProduct() { }
        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; OnPropertyChanged(); }
        }
        public int SaleQTY
        {
            get { return saleQTY; }
            set
            {
                saleQTY = value;
                Subtotal = value * Price;
                SubTot = string.Format("{0:C2}", Subtotal);
                OnPropertyChanged();
            }
        }

        public string SubTot { get {return _subTot; } set { _subTot = value; OnPropertyChanged(); } }
    }
}
