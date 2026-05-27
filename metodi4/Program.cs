using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodi4
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите пароль для проверки: ");
            string password = Console.ReadLine();

            // Вызываем метод для вывода отчёта
            PrintPasswordReport(password);
        }

        // 1 метод: проверяет длину пароля
        static bool IsLengthValid(string password)
        {
            return password.Length >= 8;
        }

        // 2 метод: проверяет наличие хотя бы одной цифры
        static bool HasDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        // 3 метод: проверяет наличие хотя бы одной заглавной буквы
        static bool HasUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        // 4 метод: вызывает все три метода и возвращает общий результат
        static bool IsPasswordStrong(string password)
        {
            bool lengthOk = IsLengthValid(password);
            bool digitOk = HasDigit(password);
            bool upperOk = HasUpperCase(password);

            return lengthOk && digitOk && upperOk;
        }

        // 5 метод: выводит подробный отчёт
        static void PrintPasswordReport(string password)
        {
            Console.WriteLine("ОТЧЁТ О ПРОВЕРКЕ ПАРОЛЯ");

            // Проверяем каждое условие
            bool lengthOk = IsLengthValid(password);
            bool digitOk = HasDigit(password);
            bool upperOk = HasUpperCase(password);

            // Выводим детали
            Console.WriteLine($"1. Длина пароля (мин. 8 символов): {(lengthOk ? " Выполнено" : " Не выполнено")}");
            Console.WriteLine($"2. Наличие хотя бы одной цифры: {(digitOk ? " Выполнено" : " Не выполнено")}");
            Console.WriteLine($"3. Наличие заглавной буквы: {(upperOk ? " Выполнено" : " Не выполнено")}");

            Console.WriteLine("ОБЩИЙ РЕЗУЛЬТАТ");

            // Вызываем 4 метод для общего вердикта
            bool isStrong = IsPasswordStrong(password);

            if (isStrong)
            {
                Console.WriteLine("✓ Пароль надёжный! Можно использовать.");
            }
            else
            {
                Console.WriteLine("✗ Пароль НЕНАДЁЖНЫЙ! Рекомендации по улучшению:");

                if (!lengthOk)
                    Console.WriteLine("  - Увеличьте длину пароля до 8 символов");
                if (!digitOk)
                    Console.WriteLine("  - Добавьте хотя бы одну цифру");
                if (!upperOk)
                    Console.WriteLine("  - Добавьте хотя бы одну заглавную букву");
            }
        }
    }
    class CoffeeMachine
    {
        // Запасы ресурсов
        static int coffee = 10;   // порции кофе
        static int milk = 5;      // порции молока
        static int sugar = 15;    // порции сахара

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MakeEspresso();
                        break;
                    case "2":
                        MakeLatte();
                        break;
                    case "3":
                        MakeCappuccino();
                        break;
                    case "4":
                        AddSugarOption();
                        break;
                    case "5":
                        ShowRemaining();
                        break;
                    case "6":
                        RefillMachine();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("До свидания!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine(" КОФЕМАШИНА ");
            Console.WriteLine("1. Эспрессо (1 кофе)");
            Console.WriteLine("2. Латте (1 кофе + 2 молока)");
            Console.WriteLine("3. Капучино (1 кофе + 1 молоко)");
            Console.WriteLine("4. Добавить сахар (опционально)");
            Console.WriteLine("5. Показать остатки");
            Console.WriteLine("6. Заправить кофемашину");
            Console.WriteLine("7. Выход\n");
            Console.Write("Ваш выбор: ");
        }

        // Метод проверки ресурсов
        static bool CheckResources(int neededCoffee, int neededMilk, int neededSugar = 0)
        {
            if (coffee < neededCoffee)
            {
                Console.WriteLine(" Недостаточно кофе!");
                return false;
            }

            if (milk < neededMilk)
            {
                Console.WriteLine(" Недостаточно молока!");
                return false;
            }

            if (sugar < neededSugar)
            {
                Console.WriteLine(" Недостаточно сахара!");
                return false;
            }

            return true;
        }

        // Метод приготовления (уменьшает ресурсы)
        static void MakeDrink(string drinkName, int neededCoffee, int neededMilk, int neededSugar = 0)
        {
            if (CheckResources(neededCoffee, neededMilk, neededSugar))
            {
                coffee -= neededCoffee;
                milk -= neededMilk;
                sugar -= neededSugar;
                Console.WriteLine($" {drinkName} готов! Приятного аппетита!");
            }
        }

        // Метод для эспрессо
        static void MakeEspresso()
        {
            Console.Write("Добавить сахар? (да/нет): ");
            string answer = Console.ReadLine()?.ToLower();
            int extraSugar = (answer == "да" || answer == "yes" || answer == "y") ? 1 : 0;

            if (extraSugar == 1 && sugar < 1)
            {
                Console.WriteLine(" Недостаточно сахара для добавления!");
                return;
            }

            MakeDrink("Эспрессо", 1, 0, extraSugar);
        }

        // Метод для латте
        static void MakeLatte()
        {
            MakeDrink("Латте", 1, 2);
        }

        // Метод для капучино
        static void MakeCappuccino()
        {
            MakeDrink("Капучино", 1, 1);
        }

        // Опциональное добавление сахара к любому напитку
        static void AddSugarOption()
        {
            if (sugar > 0)
            {
                sugar--;
                Console.WriteLine(" Добавлена 1 порция сахара!");
            }
            else
            {
                Console.WriteLine(" Сахар закончился!");
            }
        }

        // Метод показа остатков
        static void ShowRemaining()
        {
            Console.WriteLine(" ОСТАТКИ РЕСУРСОВ ");
            Console.WriteLine($"Кофе:   {coffee} порций");
            Console.WriteLine($"Молоко: {milk} порций");
            Console.WriteLine($"Сахар:  {sugar} порций");
            
        }

        // Метод заправки
        static void RefillMachine()
        {
            Console.WriteLine(" ЗАПРАВКА КОФЕМАШИНЫ ");
            Console.Write("Сколько порций кофе добавить? ");
            coffee += int.Parse(Console.ReadLine());

            Console.Write("Сколько порций молока добавить? ");
            milk += int.Parse(Console.ReadLine());

            Console.Write("Сколько порций сахара добавить? ");
            sugar += int.Parse(Console.ReadLine());

            Console.WriteLine("✓ Кофемашина успешно заправлена!");
            ShowRemaining();
        }
    }
}
