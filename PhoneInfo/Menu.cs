using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneInfo.Module
{
    public class Menu
    {
        public Menu() { }

        public void MyMenu()
        {
            ServicePhone sp = new ServicePhone();

            Console.WriteLine("========== Menu ==========");
            Console.WriteLine();
            Console.WriteLine("1. Добавить телефон");
            Console.WriteLine("2. Найти телефон");
            Console.WriteLine("3. Выйти");
            Console.WriteLine();
            Console.WriteLine("==========================");
            Console.WriteLine();

            Console.Write("Выберите действие: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("============ Добавление ============");
                    Console.WriteLine();
                    sp.addPhone();
                    return;
                case 2:
                    Console.WriteLine("============ Поиск ============");
                    Console.WriteLine();
                    Console.Write("Введите модель телефона: ");
                    sp.SearchPhoneByModel(Console.ReadLine());
                    break;
                case 4:
                    break;
            }

        }
    }
}
