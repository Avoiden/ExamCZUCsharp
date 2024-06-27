using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zkouska
{
    class Program
    {
        //Pro zkousku jsem zadal konkretni nazev souboru
        static string filePath = "data.csv";

        static void Main(string[] args)
        {
            while (true)
            {
                //Menu pro navigaci v programu
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Nacist data ze souboru");
                Console.WriteLine("2. Ulozit data do souboru");
                Console.WriteLine("3. Pridat novy zaznam");
                Console.WriteLine("4. Ukoncit program");
                Console.Write("Vyberte moznost (1-4): ");

                //Hlavni cast kodu-prace z souborem
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoadData(); //Funkce pro nacitani dat
                        Console.WriteLine("Stisknete Enter pro pokracovani:");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) {}
                        Console.Clear();
                        break;
                    case "2":
                        SaveData(); //Funkce pro ukladani libovolnych dat
                        Console.WriteLine("Stisknete Enter pro pokracovani:");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) {}
                        Console.Clear();
                        break;
                    case "3":
                        AddRecord(); //Funkce pro pridavani konkretniho zaznamu
                        Console.WriteLine("Stisknete Enter pro pokracovani:");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) {}
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Program se ukoncuje."); //Jednoduche ukoncovani programu
                        return;
                    default:
                        Console.WriteLine("Neplatna volba, zkuste to znovu."); //Osetreni spravnosti zadane volby
                        break;
                }
            }
        }

        //Funkce pro nacitani dat
        static void LoadData()
        {
            //Ujisteni existence souboru
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Soubor neexistuje.");
                return;
            }

            //Osetreni moznych chyb pri Nacitani souboru
            try
            {
                var lines = File.ReadAllLines(filePath);
                Console.WriteLine("\nNactena data:");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri nacitani souboru: {ex.Message}");
            }
        }

        //Funkce pro ukladani libovolnych dat
        static void SaveData()
        {
            //Jednoduche pridavani dat do souboru
            Console.Write("Zadejte data k ulozeni (oddelte carkou): ");
            string data = Console.ReadLine();

            //Osetreni moznych chyb pri pridavani dat
            try
            {
                File.AppendAllText(filePath, data + Environment.NewLine);
                Console.WriteLine("Data byla uspesne ulozena.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri ukladani souboru: {ex.Message}");
            }
        }

        //Funkce pro pridavani konkretniho zaznamu
        static void AddRecord()
        {
            Console.Write("Zadejte jmeno: ");
            string name = Console.ReadLine();

            Console.Write("Zadejte vek: ");
            string age = Console.ReadLine();

            Console.Write("Zadejte mesto: ");
            string city = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(age) || string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("Vsechna pole musi byt vyplnena."); //Osetreni spravnosti zadanych dat
                return;
            }

            if (!int.TryParse(age, out int parsedAge))
            {
                Console.WriteLine("Vek musi byt cislo.");
                return;
            }

            string record = $"{name},{age},{city}";
            //Osetreni moznych chyb pri pridavani dat
            try
            {
                File.AppendAllText(filePath, record + Environment.NewLine);
                Console.WriteLine("Novy zaznam byl uspesne pridan.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri pridavani zaznamu: {ex.Message}");
            }
        }
    }
}