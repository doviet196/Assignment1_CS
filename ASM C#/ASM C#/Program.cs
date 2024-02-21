﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("------------------- WATER BILLING OF DDV -------------------\n");
            string name = GetCustomerName();
            Console.WriteLine($"\nHello {name}, Welcome to DDV !!\n");
            Console.WriteLine("-------------------------------------------------");

            double totalBill = CalculateTotalBill();
            Console.WriteLine($"Total Water Bill: {totalBill} VND ");
            Console.ReadLine();
        }

        static string GetCustomerName()
        {
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            return customerName;
        }

        static double CalculateTotalBill()
        {
            double price = CalculatePrice();
            double fee = price * 0.1;
            double totalBill = price + fee;
            return totalBill;
        }

        static double CalculatePrice()
        {
            int type = GetCustomerType();
            double consumption = GetAmountOfConsumption();

            double price = 0;
            switch (type)
            {
                case 1: // Household Customer
                    price = CalculateHouseholdPrice(consumption);
                    break;
                case 2: // Sewing company
                    price = consumption * 9.955;
                    break;
                case 3: // Supermarket
                    price = consumption * 11.615;
                    break;
                case 4: // Aeon Mall
                    price = consumption * 22.068;
                    break;
            }
            return price;
        }

        static int GetCustomerType()
        {
            Console.WriteLine("Type a customer:\n\t" +
                                "1. Household Customer\n\t" +
                                "2. Sewing company \n\t" +
                                "3. Supermarket\n\t" +
                                "4. Aeon Mall");
            Console.Write("Enter your type (1 -> 4): ");
            int type;
            while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 4)
            {
                Console.Write("Choose numbers from 1 to 4: ");
            }
            return type;
        }

        static double GetAmountOfConsumption()
        {
            double lastWaterMeter;
            double thisWaterMeter;
            do
            {
                Console.Write("Enter last month’s water meter readings: ");
            } while (!double.TryParse(Console.ReadLine(), out lastWaterMeter) || lastWaterMeter < 0);

            do
            {
                Console.Write("Enter this month’s water meter readings: ");
            } while (!double.TryParse(Console.ReadLine(), out thisWaterMeter) || thisWaterMeter < lastWaterMeter);

            return thisWaterMeter - lastWaterMeter;
        }

        static double CalculateHouseholdPrice(double consumption)
        {
            if (consumption > 0 && consumption <= 10)
            {
                Console.WriteLine($"Water price for Household customer is: {consumption * 5.973} VND/m3");
                return consumption * 5.973;
            }
            else if (consumption > 10 && consumption <= 20)
            {
                Console.WriteLine($"Water price for Household customer is: {consumption * 7.052} VND/m3");
                return consumption * 7.052;
            }
            else if (consumption > 20 && consumption <= 30)
            {
                Console.WriteLine($"Water price for Household customer is: {consumption * 8.699} VND/m3");
                return consumption * 8.699;
            }
            else
            {
                Console.WriteLine($"Water price for Household customer is: {consumption * 15.929} VND/m3");
                return consumption * 15.929;
            }
        }
    }
}





