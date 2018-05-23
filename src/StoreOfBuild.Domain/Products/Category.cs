using System.Diagnostics.CodeAnalysis;

namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {
        public string Name {get; private set;}

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        /***
         * Class constructor
         * This constructor is used to DI
         *  
         */
        public Category() {}

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Category's name</param>
        public Category(string name){
            CheckAndSet(name);
        }

        /// <summary>
        /// Check and Set Category's name
        /// </summary>
        /// <param name="name">Category's name</param>
        private void CheckAndSet(string name){
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(name.Length < 3, "Invalid Name");
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