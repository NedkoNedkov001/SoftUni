﻿using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {

            string command;

            HashSet<string> parkingLot = new HashSet<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string number = tokens[1];

                if (direction == "IN")
                {
                    parkingLot.Add(number);
                }
                else 
                {
                    parkingLot.Remove(number);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var number in parkingLot)
            {
                Console.WriteLine(number);
            }
        }
    }
}
