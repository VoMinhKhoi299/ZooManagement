﻿using System;
using System.Collections.Generic;

namespace CK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chức năng chính: ");
            Console.WriteLine("1. Quản lý động vật");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AnimalManager.ManageAnimals();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }
   
}
