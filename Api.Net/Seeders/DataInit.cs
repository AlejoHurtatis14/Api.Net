using Api.Net.Database;
using Api.Net.Models;

namespace Api.Net.Seeders
{
    public class DataInit
    {

        private readonly DataBase database;

        public DataInit(DataBase data)
        {
            database = data;
        }

        public void set()
        {
            seedUser();
            seedCategories();
        }

        public void seedUser()
        {
            if (!database.users.Any())
            {
                IEnumerable<User> patients = new List<User>() {
                    new User()
                    {
                        Name = "Pepito Perez",
                        Email = "pepito@perez.com"
                    },
                    new User()
                    {
                        Name = "Juanito Perez",
                        Email = "juanito@perez.com"
                    },
                };

                database.users.AddRange(patients);
                database.SaveChanges();
            }
        }

        public void seedCategories()
        {
            if (!database.categories.Any())
            {
                IEnumerable<Category> arzte = new List<Category>() {
                    new Category()
                    {
                        title = "Vidrios"
                    },
                    new Category()
                    {
                        title = "Juguetes"
                    }
                };

                database.categories.AddRange(arzte);
                database.SaveChanges();
                this.seedProdcutsCategories();
            }
        }

        public async void seedProdcutsCategories()
        {
            if (!database.products.Any())
            {

                var categoryOne = await database.categories.FindAsync(1);
                var categoryTwo = await database.categories.FindAsync(2);

                if (categoryOne != null && categoryTwo != null)
                {
                    IEnumerable<Product> prodcuts = new List<Product>() {
                        new Product()
                        {
                            category = categoryOne,
                            description = "Carro de control remoto",
                            precio = 5000,
                            title = "Carro control"
                        },
                        new Product()
                        {
                            category = categoryTwo,
                            description = "Vidrio para espejo",
                            precio = 10000,
                            title = "Espejo"
                        }
                    };

                    database.products.AddRange(prodcuts);
                    database.SaveChanges();
                }
            }
        }

    }
}
