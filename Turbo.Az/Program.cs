
using System.Text.RegularExpressions;
using Turbo.Az;

ProfilController Users = new ProfilController();

Profil User = new Profil("Eltun", "Memmedli", "eltun.memmedli.06@gmail.com", "2006");

Users.AddList(User);

Car Cars = new Car("BMW", "X6", 50000, 2000, VehicleCategory.Car);
Truck Trucks = new Truck("FAW", "Tiger VN", 44500, 50000, VehicleCategory.Truck);
Moto Motors = new Moto("Suzuki", "GSX-S1000GT", 30500, 120, VehicleCategory.Moto);

CarsController Car_Controll = new CarsController();
Car_Controll.AddVehicle(Cars);

TruckController Truck_Control = new TruckController();
Truck_Control.AddVehicle(Trucks);

MotoController Moto_Controll = new MotoController();
Moto_Controll.AddVehicle(Motors);

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