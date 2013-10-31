using System;
using System.Linq;
using System.Reflection;

namespace OnlineStore
{
    class Menu
    {
        static StoreEngine engine = StoreEngine.GetEngine();

        public static string[] order = new string[7];
        private static Product currentProduct;
        // This list will store the choises the consumer has made through the menu.
        // order[0] = type
        // order[1] = brand
        // order[2] = model
        // order[3] = HDD
        // order[4] = RAM
        // order[5] = CPU
        // order[6] = quantity

        // Menu Level 01 - START
        public static void MenuStart()
        {
            Console.WriteLine("\nPlease choose the type of product you would like to order:\n");
            Console.WriteLine(new String('-', 58));
            Console.WriteLine();
            Console.WriteLine("1.  Smartphone");
            Console.WriteLine("2.  Laptop");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1": Console.Clear();
                    Menu.order[0] = "smartphone";
                    MenuBrand(1);
                    break;
                case "2": Console.Clear();
                    Menu.order[0] = "laptop";
                    MenuBrand(2);
                    break;
                default: Console.WriteLine("Please enter 1 or 2 and than press [ENTER]!");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }

        // Menu Level 02
        public static void MenuBrand(int type)
        {
            Console.WriteLine("\nPlease choose a brand now:\n");
            Console.WriteLine(new String('-', 58));
            Console.WriteLine();

            if (type == 1)
            {
                SmartPhone[] smartphones = engine.GetAllAvailableProductsFromType<SmartPhone>();
                Brand[] smartphoneBrands = smartphones.Select(x => x.Brand).Distinct().Cast<Brand>().ToArray();

                for (int i = 0; i < smartphoneBrands.Length; i++)
                {
                    Console.WriteLine("{0}.  {1}", i + 1, smartphoneBrands[i]);
                }

                Console.WriteLine("\n{0}.  Go back\n", smartphoneBrands.Length + 1);
                
                int input = int.Parse(Console.ReadLine());

                if (input > 0 && input <= smartphoneBrands.Length + 1)
                {
                    if (input == smartphoneBrands.Length + 1)
                    {
                        Console.Clear();
                        MenuStart();
                    }
                    else
                    {
                        Menu.order[1] = Convert.ToString(smartphoneBrands[input - 1]);
                        Console.Clear();
                        MenuModel(smartphoneBrands[input - 1]);
                    }
                }
                else 
                {
                    Console.WriteLine("\nPlease enter a number between 1 and {0} and than press [ENTER]!", smartphoneBrands.Length + 1);
                    input = int.Parse(Console.ReadLine());
                    Console.Clear();
                    MenuBrand(1);
                }


            }
            else if (type == 2)
            {
                Laptop[] laptops = engine.GetAllAvailableProductsFromType<Laptop>();
                Brand[] laptopBrands = laptops.Select(x => x.Brand).Distinct().Cast<Brand>().ToArray();

                for (int i = 0; i < laptopBrands.Length; i++)
                {
                    Console.WriteLine("{0}.  {1}", i + 1, laptopBrands[i]);
                }

                Console.WriteLine("\n{0}.  Go back\n", laptopBrands.Length + 1);

                int input = int.Parse(Console.ReadLine());

                if (input > 0 && input <= laptopBrands.Length + 1)
                {
                    if (input == laptopBrands.Length + 1)
                    {
                        Console.Clear();
                        MenuStart();
                    }
                    else
                    {
                        Menu.order[1] = Convert.ToString(laptopBrands[input - 1]);
                        Console.Clear();
                        MenuModel(laptopBrands[input - 1]);
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter a number between 1 and {0} and than press [ENTER]!", laptopBrands.Length + 1);
                    input = int.Parse(Console.ReadLine());
                }
            }
        }

        // Menu Level 03
        public static void MenuModel(Brand brand)
        {
            Console.WriteLine("\nPlease choose a model:\n");
            Console.WriteLine(new String('-', 58));
            Console.WriteLine();

            if (order[0] == "smartphone")
            {
                SmartPhone[] smartphones = engine.GetAllAvailableProductsFromType<SmartPhone>();
                SmartPhone[] smartphoneModels = smartphones.Where(x => x.Brand == brand).Cast<SmartPhone>().ToArray();

                for (int i = 0; i < smartphoneModels.Length; i++)
                {
                    Console.WriteLine("{0}.  {1}", i + 1, smartphoneModels[i]);
                }

                Console.WriteLine("\n{0}.  Go back\n", smartphoneModels.Length + 1);

                int input = int.Parse(Console.ReadLine());

                if (input > 0 && input <= smartphoneModels.Length + 1)
                {
                    if (input == smartphoneModels.Length + 1)
                    {
                        Console.Clear();
                        MenuBrand(1);
                    }
                    else
                    {
                        Menu.order[2] = Convert.ToString(smartphoneModels[input - 1].Model);
                        Console.Clear();
                        currentProduct = smartphoneModels[input - 1];
                        MenuQuantity();
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter a number between 1 and {0} and than press [ENTER]!", smartphoneModels.Length + 1);
                    input = int.Parse(Console.ReadLine());
                }
            }
            else if (order[0] == "laptop")
            {
                Laptop[] laptops = engine.GetAllAvailableProductsFromType<Laptop>();
                Laptop[] laptopModels = laptops.Where(x => x.Brand == brand).Cast<Laptop>().ToArray();

                for (int i = 0; i < laptopModels.Length; i++)
                {
                    Console.WriteLine("{0}.  {1}", i + 1, laptopModels[i]);
                }

                Console.WriteLine("\n{0}.  Go back\n", laptopModels.Length + 1);

                int input = int.Parse(Console.ReadLine());

                if (input > 0 && input <= laptopModels.Length + 1)
                {
                    if (input == laptopModels.Length + 1)
                    {
                        Console.Clear();
                        MenuBrand(2);
                    }
                    else
                    {
                        Menu.order[2] = Convert.ToString(laptopModels[input - 1].Model);
                        Console.Clear();
                        MenuConfiguration(laptopModels[input - 1]);
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter a number between 1 and {0} and than press [ENTER]!", laptopModels.Length + 1);
                    input = int.Parse(Console.ReadLine());
                }
                
            }
        }

        // Menu Level 04
        public static void MenuConfiguration(Laptop laptop)
        {
            int choice = 0;
            while (choice != 1 && choice != 5)
            {
                Console.Clear();
                Console.WriteLine("\nDo you want to upgrade this laptop?\n");
                Console.WriteLine(new String('-', 58));
                Console.WriteLine();

                //Console.WriteLine("Current configuration: {0}", laptop);

                Console.WriteLine("Current configuration: {0} {1}\n+{2}\n+{3}\n+{4}", laptop.Brand, laptop.Model, laptop.Hdd, laptop.Cpu, laptop.Ram);
                Console.WriteLine("\nCurrent price: {0:c}\n", laptop.GetPrice());

                Console.WriteLine("1.  No. I want to purchase this configuration.");
                Console.WriteLine("2.  I want to add a HDD.");
                Console.WriteLine("3.  I want to change the CPU.");
                Console.WriteLine("4.  I want to add more RAM.");
                Console.WriteLine("\n5.  Go back\n");

                string choiceString = Console.ReadLine();

                if (int.TryParse(choiceString, out choice))
                {
                    switch (choice)
                    {
                        case 1: Console.Clear();
                            currentProduct = laptop;
                            MenuQuantity();
                            break;
                        case 2:
                            laptop.Hdd = GetPart<HDD>();
                            break;
                        case 3:
                            laptop.Cpu = GetPart<CPU>();
                            break;
                        case 4:
                            laptop.Ram = GetPart<RAM>();
                            break;
                        case 5: Console.Clear();
                            MenuModel((Brand)Enum.Parse(typeof(Brand), order[1]));
                            break;
                        default: 
                            break;
                    }
                }
            }
            
            
        }

        static public T GetPart<T>() where T : Product
        {
            bool correctChoice = false;
            while (!correctChoice)
            {
                Console.Clear();
                Console.WriteLine("\nMake your choice:\n");
                Console.WriteLine(new String('-', 58));
                Console.WriteLine();
                T[] parts = engine.GetAllAvailableProductsFromType<T>();
                for (int i = 0; i < parts.Length; i++)
                {
                    Console.WriteLine("{0}.  {1}", i + 1, parts[i]);
                }
                Console.WriteLine("\n{0}.  Go back\n", parts.Length + 1);

                string choiceString = Console.ReadLine();
                int choice = 0;
                if (int.TryParse(choiceString, out choice))
                {
                    if ((choice > 0) && (choice <= parts.Length))
                        return parts[choice - 1];
                    else if (choice == parts.Length + 1)
                        return null;
                }
            }
            return null;

        }

        // Menu Level 05
        public static void MenuQuantity()
        {
            bool correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine("\nPlease enter the desired quantity or B to go back:\n");
                Console.WriteLine(new String('-', 58));
                Console.WriteLine();

                string input = Console.ReadLine();
                try
                {
                    if (input == "B" || input == "b")
                    {
                        Console.Clear();
                        MenuModel((Brand)Enum.Parse(typeof(Brand), order[1]));
                    }
                    else if (int.Parse(input) <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Invalid choice!");                    
                    }
                    else
                    {
                        Menu.order[6] = input;
                        MenuPurchase(int.Parse(input));
                    }
                    correctInput = true;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
        }

        // Menu Level 06 - END
        public static void MenuPurchase(int quantity)
        {
            Console.Clear();
            Console.WriteLine("\nYour order is:\n");
            Console.WriteLine(currentProduct);
            Console.WriteLine("Quantity: {0}", quantity); 
            Console.WriteLine(new String('-', 58));

            try
            {
                engine.ExtractStock(currentProduct.Id, quantity);


                //If the product is configurable we extract from the stock all of its configured parts
                if (currentProduct is IConfigurable)
                {
                    PropertyInfo[] changebleProperties = (currentProduct as IConfigurable).GetChangableProperties();
                    foreach (PropertyInfo changebleProperty in changebleProperties)
                    {
                        Product currentPropertyValue = changebleProperty.GetValue(currentProduct, null) as Product;

                        if (currentPropertyValue != null)
                            engine.ExtractStock(currentPropertyValue.Id, quantity);
                    }
                }

                Console.WriteLine("Your purchase was processed successfully!");
            }
            catch (InsufficientStockException<int> e)
            {
                Console.WriteLine("{0} for product with ID: {1}", e.Message, e.ProductId);
                Console.WriteLine("Remaining quantity: {0}", e.Quantity);
            }
            Console.ReadLine();
        }
    }
}
