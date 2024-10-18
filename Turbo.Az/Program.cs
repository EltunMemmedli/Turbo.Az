
using System.Collections;
using System.Text.RegularExpressions;
using Turbo.Az;

ProfilController Users = new ProfilController();

Profil User = new Profil("Eltun", "Memmedli", "eltun.memmedli.06@gmail.com", "2006");

Users.AddList(User);

Car Car_1 = new Car("BMW", "X6", 50000, 2000, VehicleCategory.Car);
Car Car_2 = new Car("Mercedes", "GLS", 60000, 50000, VehicleCategory.Car);

Truck Truck_1 = new Truck("FAW", "Tiger VN", 44500, 50000, VehicleCategory.Truck);
Truck Truck_2 = new Truck("Hyundai", "HD-78", 65500, 100000, VehicleCategory.Truck);

Moto Motor_1 = new Moto("Suzuki", "GSX-S1000GT", 38500, 120, VehicleCategory.Moto);
Moto Motor_2 = new Moto("Kawasaki", "Ninja H2 SX", 32500, 220, VehicleCategory.Moto);


CarsController Car_Controll = new CarsController();
Car_Controll.AddVehicle(Car_1);
Car_Controll.AddVehicle(Car_2);


TruckController Truck_Control = new TruckController();
Truck_Control.AddVehicle(Truck_1);
Truck_Control.AddVehicle(Truck_2);


MotoController Moto_Controll = new MotoController();
Moto_Controll.AddVehicle(Motor_1);
Moto_Controll.AddVehicle(Motor_2);

Secim:
Console.WriteLine($"Bir secim edin:\n" +
                    $"1.Sign In,\n" +
                    $"2.Sign Up\n" +
                    $"-----------------");
string secim = Console.ReadLine();
int Secim;

if(int.TryParse(secim, out Secim) && Secim > 0 && Secim < 3)
{
    if (Secim == 1)
    {
        Console.Clear();
    email:
        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
        Regex regex = new Regex(pattern);


        Console.WriteLine("Please, enter your email");
        string email = Console.ReadLine();
        Console.Clear();

        bool Ismatch = regex.IsMatch(email);
        if (!(string.IsNullOrEmpty(email)) && Ismatch)
        {
            Console.Clear();
            Password:
            Console.WriteLine("Please, enter your Password: ");
            string password = Console.ReadLine();
            if (!(string.IsNullOrEmpty(password)))
            {

                bool valid = Users.SignIn(email, password);
                if(valid is false)
                {
                    Console.Clear();
                    Console.WriteLine("Try again!");
                    goto email;
                }
                else
                {
                    Console.Clear();
                Menu:
                    Console.WriteLine("Welcome!\n" +
                                        "1.Show all vehicles\n" +
                                        "2.Search by price\n" +
                                        "3.Search by brand\n" +
                                        "4.Search by model\n" +
                                        "5.Show by price Low\n" +
                                        "6.Show by price High\n" +
                                        "7.Search by Km\n" +
                                        "8.Add vehicle\n" +
                                        "9.Update vehicle\n" +
                                        "10.Remove vehicle\n" +
                                        "11.Exit\n" +
                                        "--------------");
                    string option = Console.ReadLine();
                    int Option;
                    if (int.TryParse(option, out Option)
                                            && Option > 0 &&
                                            Option < 12)
                    {
                        if (Option == 1)
                        {
                            Console.Clear();
                            Car_Controll.ShowAllVehicle();
                            Truck_Control.ShowAllVehicle();
                            Moto_Controll.ShowAllVehicle();
                        Kec:
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                            string Kec = Console.ReadLine();

                            if (Kec.ToLower() == "f")
                            {
                                Console.Clear();
                                goto Menu;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                goto Kec;
                            }
                        }

                        else if (Option == 2)
                        {
                            Console.Clear();
                        MinPrice:
                            Console.Write("Min price: ");
                            string qiymet = Console.ReadLine();
                            decimal Qiymet;
                            if (decimal.TryParse(qiymet, out Qiymet) && Qiymet > 0)
                            {
                                Console.Clear();
                            MaxPrice:
                                Console.Write("Max Price: ");
                                string Price = Console.ReadLine();
                                decimal price;
                                if (decimal.TryParse(Price, out price) && price > 0)
                                {
                                    Car_Controll.SearchByPrice(Qiymet, price);
                                    Truck_Control.SearchByPrice(Qiymet, price);
                                    Moto_Controll.SearchByPrice(Qiymet, price);

                                Kec:
                                    Thread.Sleep(2000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                    string Kec = Console.ReadLine();

                                    if (Kec.ToLower() == "f")
                                    {
                                        Console.Clear();
                                        goto Menu;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                        goto Kec;
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto MaxPrice;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto MinPrice;
                            }
                        }

                        else if(Option == 3)
                        {
                            Console.Clear();
                            Brand:
                            Console.WriteLine("Please, enter the brand");
                            string Brand = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(Brand)))
                            {
                                if(Car_Controll.SearchByBrand(Brand) ||
                                    Moto_Controll.SearchByBrand(Brand) ||
                                    Truck_Control.SearchByBrand(Brand))
                                {
                                    
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("sehv");
                                    goto Brand;
                                }
                                
                                

                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Menu;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto Brand;
                            }
                        }

                        else if(Option == 4)
                        {
                            Console.Clear();
                            Model:
                            Console.WriteLine("Please, enter model");
                            string Model = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(Model)))
                            {
                                if(Car_Controll.SearchByModel(Model) ||
                                    Moto_Controll.SearchByModel(Model) ||
                                    Truck_Control.SearchByModel(Model))
                                {
                                Kec:
                                    Thread.Sleep(2000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                    string Kec = Console.ReadLine();

                                    if (Kec.ToLower() == "f")
                                    {
                                        Console.Clear();
                                        goto Menu;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                        goto Kec;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Model Tapilmadi!");
                                    goto Model;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto Model;
                            }
                        }

                        else if(Option == 5)
                        {
                            Console.Clear();
                            Moto_Controll.ShowByPriceLow();
                            Car_Controll.ShowByPriceLow();
                            Truck_Control.ShowByPriceLow();
                        Kec:
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                            string Kec = Console.ReadLine();

                            if (Kec.ToLower() == "f")
                            {
                                Console.Clear();
                                goto Menu;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                goto Kec;
                            }
                        }

                        else if (Option == 6)
                        {
                            Car_Controll.ShowByPriceHight();
                            Moto_Controll.ShowByPriceHight();
                            Truck_Control.ShowByPriceHight();

                        Kec:
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                            string Kec = Console.ReadLine();

                            if (Kec.ToLower() == "f")
                            {
                                Console.Clear();
                                goto Menu;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                goto Kec;
                            }
                        }

                        else if(Option == 7)
                        {
                            Console.Clear();
                            MinKm:
                            Console.Write("Min Km: ");
                            string minkm = Console.ReadLine();
                            decimal MinKm;
                            if(decimal.TryParse(minkm, out MinKm) && MinKm > 0)
                            {
                                Console.Clear();
                                MaxKm:
                                Console.Write("Max Km: ");
                                string maxkm = Console.ReadLine();
                                decimal MaxKm;
                                if(decimal.TryParse(maxkm, out MaxKm) && MaxKm > 0)
                                {
                                    Truck_Control.SearcByKm(MinKm, MaxKm);
                                    Car_Controll.SearcByKm(MinKm, MaxKm);
                                   
                                    Moto_Controll.SearcByKm(MinKm, MaxKm);
                                Kec:
                                    Thread.Sleep(2000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                    string Kec = Console.ReadLine();

                                    if (Kec.ToLower() == "f")
                                    {
                                        Console.Clear();
                                        goto Menu;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                        goto Kec;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Yanslidir");
                                    goto MaxKm;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Yanlisdir");
                                goto MinKm;
                            }
                        }

                        else if(Option == 8)
                        {
                            Console.Clear();
                            Category:
                            Console.WriteLine("Please, enter the category");
                            string Category = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(Category)))
                            {
                                Console.Clear();
                                Brand:
                                Console.WriteLine("Please, enter the Brand");
                                string Brand = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Brand)))
                                {
                                    Console.Clear();
                                    Model:
                                    Console.WriteLine("Please, enter the Model");
                                    string Model = Console.ReadLine();
                                    if (!(string.IsNullOrEmpty(Model)))
                                    {
                                        Console.Clear();
                                        Price:
                                        Console.WriteLine("Please, enter the Price");
                                        string Price = Console.ReadLine();
                                        decimal price;
                                        if(decimal.TryParse(Price, out price) && price > 0)
                                        {
                                            Console.Clear();
                                        KiloMetr:
                                            Console.WriteLine("Please, enter the Km");
                                            string Km = Console.ReadLine();
                                            decimal km;
                                            if(decimal.TryParse(Km, out km) && km >= 0)
                                            {
                                                if(Category.ToLower() == VehicleCategory.Moto.ToString().ToLower())
                                                {
                                                    Moto_Controll.AddNewVehicle(Brand, Model, price, km, VehicleCategory.Moto);
                                                    Moto_Controll.ShowAllVehicle();
                                                Kec:
                                                    Thread.Sleep(2000);
                                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                    string Kec = Console.ReadLine();

                                                    if (Kec.ToLower() == "f")
                                                    {
                                                        Console.Clear();
                                                        goto Menu;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                        goto Kec;
                                                    }
                                                }
                                                else if(Category.ToLower() == VehicleCategory.Car.ToString().ToLower())
                                                {
                                                    Car_Controll.AddNewVehicle(Brand, Model, price, km, VehicleCategory.Car);
                                                    Car_Controll.ShowAllVehicle();
                                                Kec:
                                                    Thread.Sleep(2000);
                                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                    string Kec = Console.ReadLine();

                                                    if (Kec.ToLower() == "f")
                                                    {
                                                        Console.Clear();
                                                        goto Menu;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                        goto Kec;
                                                    }
                                                }
                                                else if(Category.ToLower() == VehicleCategory.Truck.ToString().ToLower())
                                                {
                                                    Truck_Control.AddNewVehicle(Brand, Model, price, km, VehicleCategory.Truck);
                                                    Truck_Control.ShowAllVehicle();
                                                Kec:
                                                    Thread.Sleep(2000);
                                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                    string Kec = Console.ReadLine();

                                                    if (Kec.ToLower() == "f")
                                                    {
                                                        Console.Clear();
                                                        goto Menu;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                        goto Kec;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto KiloMetr;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto Price;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun daxil edin");
                                        goto Model;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin");
                                    goto Brand;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin");
                                goto Category;
                            }
                        }

                        else if(Option == 9)
                        {
                            Console.Clear();
                            Category_2:
                            Console.WriteLine("Please, enter the category");
                            string Category = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(Category)))
                            {
                                Console.Clear();
                                if(Category.ToLower() == VehicleCategory.Car.ToString().ToLower())
                                {
                                    Car_Controll.ShowAllVehicle();
                                    ArrayList Car = Car_Controll.GetVehicles();
                                    int say = Car.Count;
                                    Console.WriteLine("\nPlease, enter Vehicle's ID");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if(int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                    {
                                        Console.Clear();
                                        Brand:
                                        Console.WriteLine("Please, enter the new Brand");
                                        string Brand = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(Brand)))
                                        {
                                            Console.Clear();
                                        Model:
                                            Console.WriteLine("Please, enter the new Model");
                                            string Model = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Model)))
                                            {
                                                Console.Clear();
                                                Price:
                                                Console.WriteLine("Please, enter the new Price");
                                                string price = Console.ReadLine();
                                                decimal Price;
                                                if(decimal.TryParse(price, out Price) && Price > 0)
                                                {
                                                    Console.Clear();
                                                    Km:
                                                    Console.WriteLine("Please, enter the new Kilometr");
                                                    string km = Console.ReadLine();
                                                    decimal Km;
                                                    if(decimal.TryParse(km, out Km) && Km >= 0)
                                                    {
                                                        Car UpdatecdCar = new Car(Brand, Model, Price, Km, VehicleCategory.Car);

                                                        Car_Controll.UpdateVehicle(ID, UpdatecdCar);
                                                        Car_Controll.ShowAllVehicle();
                                                    Kec:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec = Console.ReadLine();

                                                        if (Kec.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Menu;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun daxil edin");
                                                        goto Km;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Duzgun daxil edin");
                                                    goto Price;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Suzu=gun daxil edin");
                                                goto Model;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto Brand;
                                        }
                                    }
                                }

                                else if(Category.ToLower() == VehicleCategory.Truck.ToString().ToLower())
                                {
                                    Truck_Control.ShowAllVehicle();
                                    ArrayList Truck = Truck_Control.GetVehicles();
                                    int say = Truck.Count;
                                    Console.WriteLine("\nPlease, enter Vehicle's ID");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                    {
                                        Console.Clear();
                                    Brand:
                                        Console.WriteLine("Please, enter the new Brand");
                                        string Brand = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(Brand)))
                                        {
                                            Console.Clear();
                                        Model:
                                            Console.WriteLine("Please, enter the new Model");
                                            string Model = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Model)))
                                            {
                                                Console.Clear();
                                            Price:
                                                Console.WriteLine("Please, enter the new Price");
                                                string price = Console.ReadLine();
                                                decimal Price;
                                                if (decimal.TryParse(price, out Price) && Price > 0)
                                                {
                                                    Console.Clear();
                                                Km:
                                                    Console.WriteLine("Please, enter the new Kilometr");
                                                    string km = Console.ReadLine();
                                                    decimal Km;
                                                    if (decimal.TryParse(km, out Km) && Km >= 0)
                                                    {
                                                        Truck UpdatecdTruck = new Truck(Brand, Model, Price, Km, VehicleCategory.Truck);

                                                        Truck_Control.UpdateVehicle(ID, UpdatecdTruck);
                                                        Truck_Control.ShowAllVehicle();
                                                    Kec:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec = Console.ReadLine();

                                                        if (Kec.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Menu;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun daxil edin");
                                                        goto Km;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Duzgun daxil edin");
                                                    goto Price;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Suzu=gun daxil edin");
                                                goto Model;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto Brand;
                                        }
                                    }
                                }

                                else if(Category.ToLower() == VehicleCategory.Moto.ToString().ToLower())
                                {

                                    Moto_Controll.ShowAllVehicle();
                                    ArrayList Moto = Moto_Controll.GetVehicles();
                                    int say = Moto.Count;
                                    Console.WriteLine("\nPlease, enter Vehicle's ID");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                    {
                                        Console.Clear();
                                    Brand:
                                        Console.WriteLine("Please, enter the new Brand");
                                        string Brand = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(Brand)))
                                        {
                                            Console.Clear();
                                        Model:
                                            Console.WriteLine("Please, enter the new Model");
                                            string Model = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Model)))
                                            {
                                                Console.Clear();
                                            Price:
                                                Console.WriteLine("Please, enter the new Price");
                                                string price = Console.ReadLine();
                                                decimal Price;
                                                if (decimal.TryParse(price, out Price) && Price > 0)
                                                {
                                                    Console.Clear();
                                                Km:
                                                    Console.WriteLine("Please, enter the new Kilometr");
                                                    string km = Console.ReadLine();
                                                    decimal Km;
                                                    if (decimal.TryParse(km, out Km) && Km >= 0)
                                                    {
                                                        Moto UpdatecdMoto = new Moto(Brand, Model, Price, Km, VehicleCategory.Moto);

                                                        Moto_Controll.UpdateVehicle(ID, UpdatecdMoto);

                                                        Moto_Controll.ShowAllVehicle();
                                                    Kec:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec = Console.ReadLine();

                                                        if (Kec.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Menu;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun daxil edin");
                                                        goto Km;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Duzgun daxil edin");
                                                    goto Price;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Suzu=gun daxil edin");
                                                goto Model;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto Brand;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin");
                                goto Category_2;
                            }
                        }

                        else if(Option == 10)
                        {
                            Console.Clear();
                            Category:
                            Console.WriteLine("Please, enter the Category");
                            string Category = Console.ReadLine();
                            if (!(string.IsNullOrEmpty(Category)))
                            {
                                if (Category.ToLower() == VehicleCategory.Car.ToString().ToLower())
                                {
                                    Console.Clear();
                                    Car_Controll.ShowAllVehicle();
                                    ArrayList RemovCar = Car_Controll.GetVehicles();
                                    int say = RemovCar.Count;
                                ID:
                                    Console.WriteLine("\nPlease, enter the Vehicle ID");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                    {
                                        Car_Controll.RemoveVehicle(ID);

                                        Console.Clear();
                                        Car_Controll.ShowAllVehicle();
                                    Kec:
                                        Thread.Sleep(2000);
                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                        string Kec = Console.ReadLine();

                                        if (Kec.ToLower() == "f")
                                        {
                                            Console.Clear();
                                            goto Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                            goto Kec;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun daxil edin");
                                        goto ID;
                                    }
                                }

                                else if (Category.ToLower() == VehicleCategory.Truck.ToString().ToLower())
                                {

                                    Console.Clear();
                                    Truck_Control.ShowAllVehicle();
                                    ArrayList RemovTruck = Truck_Control.GetVehicles();
                                    int say = RemovTruck.Count;
                                ID:
                                    Console.WriteLine("\nPlease, enter the Vehicle ID");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                    {
                                        Truck_Control.RemoveVehicle(ID);
                                        Console.Clear();
                                        Truck_Control.ShowAllVehicle();
                                    Kec:
                                        Thread.Sleep(2000);
                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                        string Kec = Console.ReadLine();

                                        if (Kec.ToLower() == "f")
                                        {
                                            Console.Clear();
                                            goto Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                            goto Kec;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun daxil edin");
                                        goto ID;
                                    }
                                }

                                else if(Category.ToLower() == VehicleCategory.Moto.ToString().ToLower())
                                {
                                    Console.Clear();
                                    Moto_Controll.ShowAllVehicle();
                                    ArrayList RemovMoto = Moto_Controll.GetVehicles();
                                    int say = RemovMoto.Count;
                                ID:
                                    Console.WriteLine("\nPlease, enter the Vehicle ID");
                                    string id = Console.ReadLine();
                                    int ID;
                                    if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                    {
                                        Moto_Controll.RemoveVehicle(ID);
                                        Console.Clear();
                                        Moto_Controll.ShowAllVehicle();
                                    Kec:
                                        Thread.Sleep(2000);
                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                        string Kec = Console.ReadLine();

                                        if (Kec.ToLower() == "f")
                                        {
                                            Console.Clear();
                                            goto Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                            goto Kec;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun daxil edin");
                                        goto ID;
                                    }
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Can not find category");
                                    goto Category; 
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin");
                                goto Category;
                            }
                        }

                        else if(Option == 11)
                        {
                            Console.Clear();
                            Choose: 
                            Console.WriteLine("Are you sure to exit?(1 - Yes / 2 - No)");
                            string Choose = Console.ReadLine();
                            int choose;
                            if(int.TryParse(Choose, out choose) && choose > 0 && choose < 3)
                            {
                                if(choose == 1)
                                {
                                    goto Secim;
                                }
                                else if(choose == 2)
                                {
                                    goto Menu;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun daxil edin");
                                goto Choose;
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil edin!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto Menu;
                    }
                }

                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Duzgun daxil edin!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Secim;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Duzgun daxil edin!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Secim;
        }
    }

    else if(Secim == 2)
    {
        Console.Clear();
        name:
        Console.WriteLine("Please, enter your name");
        string name = Console.ReadLine();
        if (!(string.IsNullOrEmpty(name)))
        {
            Console.Clear();
            surname:
            Console.WriteLine("Please, enter your surname");
            string surname = Console.ReadLine();
            if (!(string.IsNullOrEmpty(surname)))
            {
                Console.Clear();
            Email2:
                Console.WriteLine("Enter your email");
                string email = Console.ReadLine();

                string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                Regex regex = new Regex(pattern);

                bool IsMatch = regex.IsMatch(email);
                if (!(string.IsNullOrEmpty(email)) && IsMatch)
                {
                    Console.Clear();
                password:
                    Console.WriteLine("Please, enter your password");
                    string password = Console.ReadLine();
                    if (!(string.IsNullOrEmpty(password)))
                    {
                        Users.SignUp(name, surname, email, password);

                    Menu:
                        Console.WriteLine("Welcome!\n" +
                                            "1.Show all vehicles\n" +
                                            "2.Search by price\n" +
                                            "3.Search by brand\n" +
                                            "4.Search by model\n" +
                                            "5.Show by price Low\n" +
                                            "6.Show by price High\n" +
                                            "7.Search by Km\n" +
                                            "8.Add vehicle\n" +
                                            "9.Update vehicle\n" +
                                            "10.Remove vehicle\n" +
                                            "11.Exit\n" +
                                            "--------------");
                        string Option = Console.ReadLine();
                        int option;
                        if(int.TryParse(Option, out option) && option > 0 && option < 12)
                        {
                            if (option == 1)
                            {
                                Console.Clear();
                                Car_Controll.ShowAllVehicle();
                                Truck_Control.ShowAllVehicle();
                                Moto_Controll.ShowAllVehicle();
                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Menu;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }
                            }

                            else if (option == 2)
                            {
                                Console.Clear();
                            MinPrice:
                                Console.Write("Min price: ");
                                string qiymet = Console.ReadLine();
                                decimal Qiymet;
                                if (decimal.TryParse(qiymet, out Qiymet) && Qiymet > 0)
                                {
                                    Console.Clear();
                                MaxPrice:
                                    Console.Write("Max Price: ");
                                    string Price = Console.ReadLine();
                                    decimal price;
                                    if (decimal.TryParse(Price, out price) && price > 0)
                                    {
                                        Car_Controll.SearchByPrice(Qiymet, price);
                                        Truck_Control.SearchByPrice(Qiymet, price);
                                        Moto_Controll.SearchByPrice(Qiymet, price);

                                    Kec:
                                        Thread.Sleep(2000);
                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                        string Kec = Console.ReadLine();

                                        if (Kec.ToLower() == "f")
                                        {
                                            Console.Clear();
                                            goto Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                            goto Kec;
                                        }

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun daxil edin!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto MaxPrice;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto MinPrice;
                                }
                            }

                            else if (option == 3)
                            {
                                Console.Clear();
                            Brand:
                                Console.WriteLine("Please, enter the brand");
                                string Brand = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Brand)))
                                {
                                    if (Car_Controll.SearchByBrand(Brand) ||
                                        Moto_Controll.SearchByBrand(Brand) ||
                                        Truck_Control.SearchByBrand(Brand))
                                    {

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("sehv");
                                        goto Brand;
                                    }



                                Kec:
                                    Thread.Sleep(2000);
                                    Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                    string Kec = Console.ReadLine();

                                    if (Kec.ToLower() == "f")
                                    {
                                        Console.Clear();
                                        goto Menu;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                        goto Kec;
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Brand;
                                }
                            }

                            else if (option == 4)
                            {
                                Console.Clear();
                            Model:
                                Console.WriteLine("Please, enter model");
                                string Model = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Model)))
                                {
                                    if (Car_Controll.SearchByModel(Model) ||
                                        Moto_Controll.SearchByModel(Model) ||
                                        Truck_Control.SearchByModel(Model))
                                    {
                                    Kec:
                                        Thread.Sleep(2000);
                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                        string Kec = Console.ReadLine();

                                        if (Kec.ToLower() == "f")
                                        {
                                            Console.Clear();
                                            goto Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                            goto Kec;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Model Tapilmadi!");
                                        goto Model;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto Model;
                                }
                            }

                            else if (option == 5)
                            {
                                Console.Clear();
                                Moto_Controll.ShowByPriceLow();
                                Car_Controll.ShowByPriceLow();
                                Truck_Control.ShowByPriceLow();
                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Menu;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }
                            }

                            else if (option == 6)
                            {
                                Car_Controll.ShowByPriceHight();
                                Moto_Controll.ShowByPriceHight();
                                Truck_Control.ShowByPriceHight();

                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Menu;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }
                            }

                            else if (option == 7)
                            {
                                Console.Clear();
                            MinKm:
                                Console.Write("Min Km: ");
                                string minkm = Console.ReadLine();
                                decimal MinKm;
                                if (decimal.TryParse(minkm, out MinKm) && MinKm > 0)
                                {
                                    Console.Clear();
                                MaxKm:
                                    Console.Write("Max Km: ");
                                    string maxkm = Console.ReadLine();
                                    decimal MaxKm;
                                    if (decimal.TryParse(maxkm, out MaxKm) && MaxKm > 0)
                                    {
                                        Truck_Control.SearcByKm(MinKm, MaxKm);
                                        Car_Controll.SearcByKm(MinKm, MaxKm);

                                        Moto_Controll.SearcByKm(MinKm, MaxKm);
                                    Kec:
                                        Thread.Sleep(2000);
                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                        string Kec = Console.ReadLine();

                                        if (Kec.ToLower() == "f")
                                        {
                                            Console.Clear();
                                            goto Menu;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                            goto Kec;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Yanslidir");
                                        goto MaxKm;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Yanlisdir");
                                    goto MinKm;
                                }
                            }

                            else if (option == 8)
                            {
                                Console.Clear();
                            Category:
                                Console.WriteLine("Please, enter the category");
                                string Category = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Category)))
                                {
                                    Console.Clear();
                                Brand:
                                    Console.WriteLine("Please, enter the Brand");
                                    string Brand = Console.ReadLine();
                                    if (!(string.IsNullOrEmpty(Brand)))
                                    {
                                        Console.Clear();
                                    Model:
                                        Console.WriteLine("Please, enter the Model");
                                        string Model = Console.ReadLine();
                                        if (!(string.IsNullOrEmpty(Model)))
                                        {
                                            Console.Clear();
                                        Price:
                                            Console.WriteLine("Please, enter the Price");
                                            string Price = Console.ReadLine();
                                            decimal price;
                                            if (decimal.TryParse(Price, out price) && price > 0)
                                            {
                                                Console.Clear();
                                            KiloMetr:
                                                Console.WriteLine("Please, enter the Km");
                                                string Km = Console.ReadLine();
                                                decimal km;
                                                if (decimal.TryParse(Km, out km) && km >= 0)
                                                {
                                                    if (Category.ToLower() == VehicleCategory.Moto.ToString().ToLower())
                                                    {
                                                        Moto_Controll.AddNewVehicle(Brand, Model, price, km, VehicleCategory.Moto);
                                                        Moto_Controll.ShowAllVehicle();
                                                    Kec:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec = Console.ReadLine();

                                                        if (Kec.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Menu;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }
                                                    }
                                                    else if (Category.ToLower() == VehicleCategory.Car.ToString().ToLower())
                                                    {
                                                        Car_Controll.AddNewVehicle(Brand, Model, price, km, VehicleCategory.Car);
                                                        Car_Controll.ShowAllVehicle();
                                                    Kec:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec = Console.ReadLine();

                                                        if (Kec.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Menu;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }
                                                    }
                                                    else if (Category.ToLower() == VehicleCategory.Truck.ToString().ToLower())
                                                    {
                                                        Truck_Control.AddNewVehicle(Brand, Model, price, km, VehicleCategory.Truck);
                                                        Truck_Control.ShowAllVehicle();
                                                    Kec:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec = Console.ReadLine();

                                                        if (Kec.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Menu;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Duzgun daxil edin");
                                                    goto KiloMetr;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto Price;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto Model;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Duzgun daxil edin");
                                        goto Brand;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin");
                                    goto Category;
                                }
                            }

                            else if (option == 9)
                            {
                                Console.Clear();
                            Category_2:
                                Console.WriteLine("Please, enter the category");
                                string Category = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Category)))
                                {
                                    Console.Clear();
                                    if (Category.ToLower() == VehicleCategory.Car.ToString().ToLower())
                                    {
                                        Car_Controll.ShowAllVehicle();
                                        ArrayList Car = Car_Controll.GetVehicles();
                                        int say = Car.Count;
                                        Console.WriteLine("\nPlease, enter Vehicle's ID");
                                        string id = Console.ReadLine();
                                        int ID;
                                        if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                        {
                                            Console.Clear();
                                        Brand:
                                            Console.WriteLine("Please, enter the new Brand");
                                            string Brand = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Brand)))
                                            {
                                                Console.Clear();
                                            Model:
                                                Console.WriteLine("Please, enter the new Model");
                                                string Model = Console.ReadLine();
                                                if (!(string.IsNullOrEmpty(Model)))
                                                {
                                                    Console.Clear();
                                                Price:
                                                    Console.WriteLine("Please, enter the new Price");
                                                    string price = Console.ReadLine();
                                                    decimal Price;
                                                    if (decimal.TryParse(price, out Price) && Price > 0)
                                                    {
                                                        Console.Clear();
                                                    Km:
                                                        Console.WriteLine("Please, enter the new Kilometr");
                                                        string km = Console.ReadLine();
                                                        decimal Km;
                                                        if (decimal.TryParse(km, out Km) && Km >= 0)
                                                        {
                                                            Car UpdatecdCar = new Car(Brand, Model, Price, Km, VehicleCategory.Car);

                                                            Car_Controll.UpdateVehicle(ID, UpdatecdCar);
                                                            Car_Controll.ShowAllVehicle();
                                                        Kec:
                                                            Thread.Sleep(2000);
                                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                            string Kec = Console.ReadLine();

                                                            if (Kec.ToLower() == "f")
                                                            {
                                                                Console.Clear();
                                                                goto Menu;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                                goto Kec;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun daxil edin");
                                                            goto Km;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun daxil edin");
                                                        goto Price;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Suzu=gun daxil edin");
                                                    goto Model;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto Brand;
                                            }
                                        }
                                    }

                                    else if (Category.ToLower() == VehicleCategory.Truck.ToString().ToLower())
                                    {
                                        Truck_Control.ShowAllVehicle();
                                        ArrayList Truck = Truck_Control.GetVehicles();
                                        int say = Truck.Count;
                                        Console.WriteLine("\nPlease, enter Vehicle's ID");
                                        string id = Console.ReadLine();
                                        int ID;
                                        if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                        {
                                            Console.Clear();
                                        Brand:
                                            Console.WriteLine("Please, enter the new Brand");
                                            string Brand = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Brand)))
                                            {
                                                Console.Clear();
                                            Model:
                                                Console.WriteLine("Please, enter the new Model");
                                                string Model = Console.ReadLine();
                                                if (!(string.IsNullOrEmpty(Model)))
                                                {
                                                    Console.Clear();
                                                Price:
                                                    Console.WriteLine("Please, enter the new Price");
                                                    string price = Console.ReadLine();
                                                    decimal Price;
                                                    if (decimal.TryParse(price, out Price) && Price > 0)
                                                    {
                                                        Console.Clear();
                                                    Km:
                                                        Console.WriteLine("Please, enter the new Kilometr");
                                                        string km = Console.ReadLine();
                                                        decimal Km;
                                                        if (decimal.TryParse(km, out Km) && Km >= 0)
                                                        {
                                                            Truck UpdatecdTruck = new Truck(Brand, Model, Price, Km, VehicleCategory.Truck);

                                                            Truck_Control.UpdateVehicle(ID, UpdatecdTruck);
                                                            Truck_Control.ShowAllVehicle();
                                                        Kec:
                                                            Thread.Sleep(2000);
                                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                            string Kec = Console.ReadLine();

                                                            if (Kec.ToLower() == "f")
                                                            {
                                                                Console.Clear();
                                                                goto Menu;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                                goto Kec;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun daxil edin");
                                                            goto Km;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun daxil edin");
                                                        goto Price;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Suzu=gun daxil edin");
                                                    goto Model;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto Brand;
                                            }
                                        }
                                    }

                                    else if (Category.ToLower() == VehicleCategory.Moto.ToString().ToLower())
                                    {

                                        Moto_Controll.ShowAllVehicle();
                                        ArrayList Moto = Moto_Controll.GetVehicles();
                                        int say = Moto.Count;
                                        Console.WriteLine("\nPlease, enter Vehicle's ID");
                                        string id = Console.ReadLine();
                                        int ID;
                                        if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                        {
                                            Console.Clear();
                                        Brand:
                                            Console.WriteLine("Please, enter the new Brand");
                                            string Brand = Console.ReadLine();
                                            if (!(string.IsNullOrEmpty(Brand)))
                                            {
                                                Console.Clear();
                                            Model:
                                                Console.WriteLine("Please, enter the new Model");
                                                string Model = Console.ReadLine();
                                                if (!(string.IsNullOrEmpty(Model)))
                                                {
                                                    Console.Clear();
                                                Price:
                                                    Console.WriteLine("Please, enter the new Price");
                                                    string price = Console.ReadLine();
                                                    decimal Price;
                                                    if (decimal.TryParse(price, out Price) && Price > 0)
                                                    {
                                                        Console.Clear();
                                                    Km:
                                                        Console.WriteLine("Please, enter the new Kilometr");
                                                        string km = Console.ReadLine();
                                                        decimal Km;
                                                        if (decimal.TryParse(km, out Km) && Km >= 0)
                                                        {
                                                            Moto UpdatecdMoto = new Moto(Brand, Model, Price, Km, VehicleCategory.Moto);

                                                            Moto_Controll.UpdateVehicle(ID, UpdatecdMoto);

                                                            Moto_Controll.ShowAllVehicle();
                                                        Kec:
                                                            Thread.Sleep(2000);
                                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                            string Kec = Console.ReadLine();

                                                            if (Kec.ToLower() == "f")
                                                            {
                                                                Console.Clear();
                                                                goto Menu;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                                goto Kec;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun daxil edin");
                                                            goto Km;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Duzgun daxil edin");
                                                        goto Price;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Suzu=gun daxil edin");
                                                    goto Model;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun daxil edin");
                                                goto Brand;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin");
                                    goto Category_2;
                                }
                            }

                            else if (option == 10)
                            {
                                Console.Clear();
                            Category:
                                Console.WriteLine("Please, enter the Category");
                                string Category = Console.ReadLine();
                                if (!(string.IsNullOrEmpty(Category)))
                                {
                                    if (Category.ToLower() == VehicleCategory.Car.ToString().ToLower())
                                    {
                                        Console.Clear();
                                        Car_Controll.ShowAllVehicle();
                                        ArrayList RemovCar = Car_Controll.GetVehicles();
                                        int say = RemovCar.Count;
                                    ID:
                                        Console.WriteLine("\nPlease, enter the Vehicle ID");
                                        string id = Console.ReadLine();
                                        int ID;
                                        if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                        {
                                            Car_Controll.RemoveVehicle(ID);

                                            Console.Clear();
                                            Car_Controll.ShowAllVehicle();
                                        Kec:
                                            Thread.Sleep(2000);
                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                            string Kec = Console.ReadLine();

                                            if (Kec.ToLower() == "f")
                                            {
                                                Console.Clear();
                                                goto Menu;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                goto Kec;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto ID;
                                        }
                                    }

                                    else if (Category.ToLower() == VehicleCategory.Truck.ToString().ToLower())
                                    {

                                        Console.Clear();
                                        Truck_Control.ShowAllVehicle();
                                        ArrayList RemovTruck = Truck_Control.GetVehicles();
                                        int say = RemovTruck.Count;
                                    ID:
                                        Console.WriteLine("\nPlease, enter the Vehicle ID");
                                        string id = Console.ReadLine();
                                        int ID;
                                        if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                        {
                                            Truck_Control.RemoveVehicle(ID);
                                            Console.Clear();
                                            Truck_Control.ShowAllVehicle();
                                        Kec:
                                            Thread.Sleep(2000);
                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                            string Kec = Console.ReadLine();

                                            if (Kec.ToLower() == "f")
                                            {
                                                Console.Clear();
                                                goto Menu;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                goto Kec;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto ID;
                                        }
                                    }

                                    else if (Category.ToLower() == VehicleCategory.Moto.ToString().ToLower())
                                    {
                                        Console.Clear();
                                        Moto_Controll.ShowAllVehicle();
                                        ArrayList RemovMoto = Moto_Controll.GetVehicles();
                                        int say = RemovMoto.Count;
                                    ID:
                                        Console.WriteLine("\nPlease, enter the Vehicle ID");
                                        string id = Console.ReadLine();
                                        int ID;
                                        if (int.TryParse(id, out ID) && ID > 0 && ID < say + 1)
                                        {
                                            Moto_Controll.RemoveVehicle(ID);
                                            Console.Clear();
                                            Moto_Controll.ShowAllVehicle();
                                        Kec:
                                            Thread.Sleep(2000);
                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                            string Kec = Console.ReadLine();

                                            if (Kec.ToLower() == "f")
                                            {
                                                Console.Clear();
                                                goto Menu;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                goto Kec;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Duzgun daxil edin");
                                            goto ID;
                                        }
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Can not find category");
                                        goto Category;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin");
                                    goto Category;
                                }
                            }

                            else if (option == 11)
                            {
                                Console.Clear();
                            Choose:
                                Console.WriteLine("Are you sure to exit?(1 - Yes / 2 - No)");
                                string Choose = Console.ReadLine();
                                int choose;
                                if (int.TryParse(Choose, out choose) && choose > 0 && choose < 3)
                                {
                                    if (choose == 1)
                                    {
                                        goto Secim;
                                    }
                                    else if (choose == 2)
                                    {
                                        goto Menu;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun daxil edin");
                                    goto Choose;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Duzgun secim edin!");
                            goto Menu;
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Adi duzgun edin!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        goto password;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Adi duzgun edin!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Email2;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Adi duzgun edin!");
                Thread.Sleep(1000);
                Console.Clear();
                goto surname;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Adi duzgun edin!");
            Thread.Sleep(1000);
            Console.Clear();
            goto name;
        }
    }
}
else 
{
    Console.Clear();
    Console.WriteLine("Duzgun Secim edin!");
    Thread.Sleep(1000);
    Console.Clear() ;
    goto Secim ;
}












// IVehicle- Brand ,Model ,Price , Km , GetInfo(),Update
// Car,Truck ,Moto 
// VehicleController -> Cars , Trucks,Motos 

//Menu


// Sign In 
// Sign Up
// Show All Vehicles 
// Search By Price
// Search By Brand
// Search By Model
// Search By Price Low 
// Search By Price Hight
// Search By Km 
// Add Vehicle 
// Update Vehicle
// Remove Vehicle 
// Exit 



/*
 
    
 
 
 */