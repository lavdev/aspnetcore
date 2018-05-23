namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {
        public string Name {get; private set;}

        public Category() {}

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="Name">Category's name</param>
        public Category(string name){
            CheckAndSet(name);
        }

        /// <summary>
        /// Check and Set Category's name
        /// </summary>
        /// <param name="name">Category's name</param>
        private void CheckAndSet(string name){
            DomainException.When(string.IsNullOrEmpty(Name), "Name is required");
            Name = name;
        }

        /// <summary>
        /// Category's data update
        /// </summary>
        /// <param name="name">Name</param>
        public void Update(string name){
            CheckAndSet(name);
        }

    }
}