namespace StoreOfBuild.Domain.Products
{
    public class Product
    {

        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public int StockQuantity {get; private set;}


        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name"> Product's name</param>
        /// <param name="category">Product's category</param>
        /// <param name="price">Product's price </param>
        /// <param name="stockQuantity">Product's quantity</param>
        public Product(string name, Category category, decimal price, int stockQuantity)
        {
            ValuesValidate(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }

        /// <summary>
        /// Set Product's value properties
        /// </summary>
        /// <param name="name"> Product's name</param>
        /// <param name="category">Product's category</param>
        /// <param name="price">Product's price </param>
        /// <param name="stockQuantity">Product's quantity</param>
        private void SetProperties(string name, Category category, decimal price, int stockQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Product's values validate
        /// </summary>
        /// <param name="name"> Product's name</param>
        /// <param name="category">Product's category</param>
        /// <param name="price">Product's price </param>
        /// <param name="stockQuantity">Product's quantity</param>
        private static void ValuesValidate(string name, Category category, decimal price, int stockQuantity)
        {
                ValuesValidate(name, category, price, stockQuantity);        
        }

        /// <summary>
        /// Product's values update
        /// </summary>
        /// <param name="name"> Product's name</param>
        /// <param name="category">Product's category</param>
        /// <param name="price">Product's price </param>
        /// <param name="stockQuantity">Product's quantity</param>
        public void Update(string name, Category category, decimal price, int stockQuantity)
        {
            ValuesValidate(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }
    }
}