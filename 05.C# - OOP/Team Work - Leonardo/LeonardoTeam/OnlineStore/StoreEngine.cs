using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore
{
    //Using the Singleton design pattern
    class StoreEngine
    {
        private static StoreEngine _instance;
        private List<Product> allProducts;
        private List<Storage> allStorages;
        private List<int> outOfStorage;

        //Ensures that we have only one instance of the StoreEngine class
        public static StoreEngine GetEngine()
        {
            if (_instance == null)
            {
                _instance = new StoreEngine();
            }

            return _instance;
        }

        //Keeps a list of all the products that are out of storage
        void OutOfStorageManagement(object sender, OutOfStorageEventArgs args)
        {
            int allStorageStock = 0;
            for (int i = 0; i < allStorages.Count; i++)
            {
                if (allStorages[i] != sender)
                {
                    allStorageStock += allStorages[i].GetStock(args.ProductId);
                }
            }

            if (allStorageStock == 0)
            {
                outOfStorage.Add(args.ProductId);
                throw new InsufficientStockException<int>(args.ProductId, args.RemainingQuantity);
            }                
        }

        //Returns all objects from type T in the allProducts list
        T [] GetAllProductsFromType<T>() where T : Product
        {
            return this.allProducts.Where(x => x is T).Cast<T>().ToArray();
        }

        public T [] GetAllAvailableProductsFromType <T>() where T : Product
        {
            return GetAllProductsFromType<T>().Where(x => outOfStorage.IndexOf(x.Id) < 0).ToArray();
        }

        public int ExtractStock(int productId, int productQuantity)
        {
            int storeIndex = 0;
            int remainingQuantity = productQuantity;

            while (storeIndex < allStorages.Count && remainingQuantity > 0)
            {
                remainingQuantity = allStorages[storeIndex].ExtractStock(productId, remainingQuantity);
                storeIndex++;
            }

            return remainingQuantity;
        }

        //Initializes the engine
        void Initialize()
        {
            outOfStorage = new List<int>();
            allStorages = new List<Storage>() { 
                new Storage ("Mladost", "Sofia, Mladost 1, bl.142"),
                new Storage ("Lulin", "Sofia, Lulin 1, bl.1")
            };

            //Link to OutOfStorageEvents
            foreach (Storage storage in allStorages)
            {
                storage.OutOfStorageEvent += OutOfStorageManagement;
            }
            
            allProducts = new List<Product>();
                        
            allProducts.Add(new Laptop("ProBook 4540", Brand.HP, 780, "CPU: Intel Celeron 1.90GHz; RAM: 3GB DDR3; HDD: 320GB SATA"));
            allProducts.Add(new Laptop("Pavilion G6", Brand.HP, 800, "CPU: Intel Core i3 1.80GHz; RAM: 4GB DDR3; HDD: 750GB SATA"));
            allProducts.Add(new Laptop("Inspiron 3251", Brand.Dell, 800, "CPU: Intel Pentium 1.60GHz; RAM: 4GB DDR3; HDD: 500GB SATA"));
            allProducts.Add(new Laptop("Vostro 2520", Brand.Dell, 899, "CPU: Intel Celeron 1.70GHz; RAM: 4GB DDR3; HDD: 320GB SATA"));
            allProducts.Add(new Laptop("Satellite C850", Brand.Toshiba, 600, "CPU: AMD E1-1200 1.40GHz ; RAM: 4GB DDR3; HDD: 320GB SATA"));
            allProducts.Add(new Laptop("Tecra R950", Brand.Toshiba, 1200, "CPU: Intel Core i3 2.20GHz ; RAM: 4GB DDR3; HDD: 500GB SATA"));


            allProducts.Add(new SmartPhone("S3", Brand.Samsung, 100));
            allProducts.Add(new SmartPhone("N9", Brand.Nokia, 200));
            allProducts.Add(new SmartPhone("iPhone 5", Brand.Apple, 300));

            RAM testRam = new RAM("8GB", "DDR3", "HyperX", Brand.Kingston, 100);
            testRam.InitID();
            allProducts.Add(testRam);

            allProducts.Add(new RAM("8GB", "DDR3", "HyperX", Brand.Kingston, 30));
            allProducts.Add(new RAM("16GB", "DDR2", "XMS", Brand.Corsair, 50));


            allProducts.Add(new HDD("Momentus", Brand.Seagate, 50, "5400 rpm", "1TB", "SATA"));
            allProducts.Add(new HDD("Silicon Drive", Brand.WesternDigital, 60, "150 MB/s", "120GB", "SSD"));

            allProducts.Add(new CPU("2.40GHz", "A6", Brand.AMD, 60));
            allProducts.Add(new CPU("3.00GHz", "A4", Brand.AMD, 50));
            allProducts.Add(new CPU("2.80GHz", "i5", Brand.Intel, 70));
            allProducts.Add(new CPU("3.50GHz", "i7", Brand.Intel, 80));

            Laptop testLaptop = new Laptop("Aspire D270", Brand.Acer, 500, "CPU: Intel Atom N2600 1.60GHz ; RAM: 2GB DDR3; HDD: 320GB SATA");
            testLaptop.Ram = testRam;
            allProducts.Add(testLaptop);

            testLaptop = new Laptop("Aspire E1", Brand.Acer, 650, "CPU: Intel Celeron 1.80GHz ; RAM: 4GB DDR3; HDD: 750GB SATA", new CPU("2.40GHz", "i7", Brand.Intel, 50));

            //We add the diferent products in random storage with random amount
            Random rnd = new Random();
            foreach (Product product in allProducts)
            {
                allStorages[rnd.Next(0, 2)].AddStock(product.Id, rnd.Next(1, 20));
            }
        }
        
        //Runs the engine
        void Run()
        {
            Console.WriteLine("Welcome to the Leonardo Online Store!\n\nTo navigate through our ordering system, please \nenter the number of the item you wish to go to.\n");
            Console.WriteLine(new String('*', 58));

            Menu.MenuStart();
        }

        static void Main(string[] args)
        {
            //Valyo-menu 
            //Simo-storage, interface
            //Ina-dokumentaciq, konstructori za vseki klas-Laptop, smart phone, configuration, product
            //Angela-exception classes Exception class-Out of storage, Invalid Input, konstruktori-parts, HDD, RAM, CPU

            StoreEngine engine = GetEngine();
            engine.Initialize();
            engine.Run();
        }
    }
}
