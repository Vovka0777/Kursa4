using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppКУРСОВАЯ
{
    class Program
    {
        static List<Animal> animals = new List<Animal>();
        static List<Owner> owners = new List<Owner>();
        static List<Veterinarian> veterinarians = new List<Veterinarian>();
        static List<Appointment> appointments = new List<Appointment>();

        static void Main(string[] args)
        {
            Console.Title = "Ветеринарная Клиника \"Здоровье Питомец\"";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false; // Скроем курсор

            Actions clinicActions = new Actions(animals, owners, veterinarians, appointments);

            int menuWidth = 60;
            int consoleWidth = Console.WindowWidth;

            bool flag = true;
            while (flag)
            {
                Console.Clear(); // Очистка экрана в начале каждой итерации
                PrintHeaderFancy(menuWidth, consoleWidth);
                PrintCenteredMenuFancy(menuWidth, consoleWidth);
                Console.SetCursorPosition((consoleWidth - "Ваш выбор: ".Length) / 2, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Ваш выбор: ");
                Console.ResetColor();
                string s = Console.ReadLine();
                Console.WriteLine();

                switch (s)
                {
                    case "1":
                        RunActionFancy("Добавление животного", clinicActions.AddAnimal, menuWidth, consoleWidth);
                        break;
                    case "2":
                        RunActionFancy("Добавление владельца", clinicActions.AddOwner, menuWidth, consoleWidth);
                        break;
                    case "3":
                        RunActionFancy("Добавление ветеринара", clinicActions.AddVeterinarian, menuWidth, consoleWidth);
                        break;
                    case "4":
                        RunActionFancy("Назначение приема", clinicActions.AddAppointment, menuWidth, consoleWidth);
                        break;
                    case "5":
                        RunActionFancy("Список всех животных", clinicActions.PrintAnimalDetails, menuWidth, consoleWidth);
                        break;
                    case "6":
                        RunActionFancy("Список всех владельцев", clinicActions.PrintOwnerDetails, menuWidth, consoleWidth);
                        break;
                    case "7":
                        RunActionFancy("Список всех ветеринаров", clinicActions.PrintVeterinarianDetails, menuWidth, consoleWidth);
                        break;
                    case "8":
                        RunActionFancy("Список всех приёмов", clinicActions.PrintAppointmentDetails, menuWidth, consoleWidth);
                        break;
                    case "9":
                        RunActionFancy("Животные, посетившие клинику за последний месяц", clinicActions.GetAnimalsVisitedLastMonth, menuWidth, consoleWidth);
                        break;
                    case "10":
                        RunActionFancy("Ветеринары, лечившие указанного пациента", clinicActions.GetVeterinariansByPatient, menuWidth, consoleWidth);
                        break;
                    case "11":
                        RunActionFancy("Владельцы с более чем одним питомцем", clinicActions.GetOwnersWithMultiplePets, menuWidth, consoleWidth);
                        break;
                    case "12":
                        RunActionFancy("Сумма лечения питомца владельцем", clinicActions.GetTotalCostByOwnerAndPet, menuWidth, consoleWidth);
                        break;
                    case "13":
                        RunActionFancy("Самые частые диагнозы", clinicActions.GetMostFrequentDiagnoses, menuWidth, consoleWidth);
                        break;
                    case "14":
                        RunActionFancy("Общая выручка клиники", clinicActions.GetTotalRevenue, menuWidth, consoleWidth);
                        break;
                    case "15":
                        RunActionFancy("Прием ветеринара на работу", clinicActions.HireVeterinarian, menuWidth, consoleWidth);
                        break;
                    case "16":
                        RunActionFancy("Увольнение ветеринара", clinicActions.FireVeterinarian, menuWidth, consoleWidth);
                        break;
                    case "17":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n--- Запись данных в файл ---");
                        Console.ResetColor();
                        Console.Write("Введите путь к файлу для сохранения (например, data.txt): ");
                        string filePath = Console.ReadLine();
                        clinicActions.SaveDataToFile(filePath);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                    case "18":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n--- Загрузка данных из файла ---");
                        Console.ResetColor();
                        Console.Write("Введите путь к файлу (например, data.txt): ");
                        string path = Console.ReadLine();
                        clinicActions.LoadDataFromFile(path);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        break;
                    case "0":
                        Console.Clear();
                        PrintGoodbyeFancy(menuWidth, consoleWidth);
                        flag = false;
                        break;
                    default:
                        Console.Clear();
                        PrintErrorFancy("Некорректный ввод. Пожалуйста, повторите.", menuWidth, consoleWidth);
                        Console.ReadKey(true);
                        break;
                }
            }
            Console.CursorVisible = true; // Вернем курсор перед выходом
        }

        static void PrintHeaderFancy(int menuWidth, int consoleWidth)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string headerText = "Ветеринарная Клиника \"Здоровье Питомец\"";
            string topBorder = "╔" + new string('═', menuWidth - 2) + "╗";
            string middleLine = "╠" + new string('═', menuWidth - 2) + "╣";
            string bottomBorder = "╚" + new string('═', menuWidth - 2) + "╝";
            string paddedHeader = "║" + headerText.PadCenter(menuWidth - 2) + "║";

            int horizontalPadding = (consoleWidth - menuWidth) / 2;
            int topOffset = 1; // Смещение от верхнего края

            Console.SetCursorPosition(horizontalPadding, topOffset);
            Console.WriteLine(topBorder);
            Console.SetCursorPosition(horizontalPadding, topOffset + 1);
            Console.WriteLine(paddedHeader);
            Console.SetCursorPosition(horizontalPadding, topOffset + 2);
            Console.WriteLine(middleLine);
            Console.ResetColor();
        }

        static void PrintCenteredMenuFancy(int menuWidth, int consoleWidth)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string title = "Выберите действие:";
            string[] menuItems = new string[]
            {
        "1. Добавить животное",
        "2. Добавить владельца",
        "3. Добавить ветеринара",
        "4. Назначить прием",
        "",
        "5. Список всех животных",
        "6. Список всех владельцев",
        "7. Список всех ветеринаров",
        "8. Список всех приёмов",
        "",
        "9. Животные, посетившие за последний месяц",
        "10. Ветеринары, лечившие пациента",
        "11. Владельцы с более чем одним питомцем",
        "12. Сумма лечения питомца владельцем",
        "13. Самые частые диагнозы",
        "14. Общая выручка клиники",
        "",
        "15. Принять ветеринара на работу",
        "16. Уволить ветеринара",
        "",
        "17. Сохранить данные в файл",
        "18. Загрузить данные из файла", // Новый пункт меню
        "0. Выход"
            };

            int horizontalPadding = (consoleWidth - menuWidth) / 2;
            string verticalLine = "║";
            int startLine = 4; // Начальная строка для меню
            int consoleHeight = Console.WindowHeight;

            Console.SetCursorPosition(horizontalPadding, startLine);
            Console.WriteLine(verticalLine + title.PadCenter(menuWidth - 2) + verticalLine);
            Console.SetCursorPosition(horizontalPadding, startLine + 1);
            Console.WriteLine("╠" + new string('─', menuWidth - 2) + "╣");

            int currentLine = startLine + 2;
            foreach (string item in menuItems)
            {
                if (currentLine < consoleHeight - 2) // Проверка, не выходим ли за нижнюю границу
                {
                    Console.SetCursorPosition(horizontalPadding, currentLine++);
                    Console.WriteLine(verticalLine + item.PadLeft((menuWidth - 2) / 2 + item.Length / 2).PadRight(menuWidth - 2) + verticalLine);
                }
            }

            if (currentLine < consoleHeight - 1) // Проверка перед выводом нижней границы
            {
                Console.SetCursorPosition(horizontalPadding, currentLine);
                Console.WriteLine("╚" + new string('═', menuWidth - 2) + "╝");
                Console.ResetColor();
                // Больше не выводим "Ваш выбор:" здесь
            }
            else
            {
                Console.WriteLine("\nМеню слишком длинное для отображения полностью.");
                Console.ResetColor();
            }
        }

        static void RunActionFancy(string title, Action action, int menuWidth, int consoleWidth)
        {
            Console.Clear(); // Очистка перед выполнением действия
            Console.ForegroundColor = ConsoleColor.Yellow;
            string topBorder = "╔" + new string('═', menuWidth - 2) + "╗";
            string bottomBorder = "╚" + new string('═', menuWidth - 2) + "╝";
            string paddedTitle = "║" + $"--- {title} ---".PadCenter(menuWidth - 2) + "║";
            int horizontalPadding = (consoleWidth - menuWidth) / 2;
            int leftOffset = horizontalPadding + 2; // Отступ слева для содержимого действия
            int topOffset = 1;

            Console.SetCursorPosition(horizontalPadding, topOffset);
            Console.WriteLine(topBorder);
            Console.SetCursorPosition(horizontalPadding, topOffset + 1);
            Console.WriteLine(paddedTitle);
            Console.SetCursorPosition(horizontalPadding, topOffset + 2);
            Console.WriteLine(bottomBorder);
            Console.ResetColor();

            Console.SetCursorPosition(leftOffset, topOffset + 4);
            action?.Invoke();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(leftOffset, Console.CursorTop + 2);
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        static void PrintErrorFancy(string message, int menuWidth, int consoleWidth)
        {
            Console.Clear(); // Очистка перед выводом ошибки
            Console.ForegroundColor = ConsoleColor.Red;
            string topBorder = "╔" + new string('═', menuWidth - 2) + "╗";
            string bottomBorder = "╚" + new string('═', menuWidth - 2) + "╝";
            string paddedMessage = "║" + $"Ошибка: {message}".PadCenter(menuWidth - 2) + "║";
            int horizontalPadding = (consoleWidth - menuWidth) / 2;
            int topOffset = 1;

            Console.SetCursorPosition(horizontalPadding, topOffset);
            Console.WriteLine(topBorder);
            Console.SetCursorPosition(horizontalPadding, topOffset + 1);
            Console.WriteLine(paddedMessage);
            Console.SetCursorPosition(horizontalPadding, topOffset + 2);
            Console.WriteLine(bottomBorder);
            Console.ResetColor();
            Console.SetCursorPosition(horizontalPadding + 2, topOffset + 4);
        }

        static void PrintGoodbyeFancy(int menuWidth, int consoleWidth)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string goodbyeText = "Спасибо за работу!";
            string subText = "До свидания!";
            string topBorder = "╔" + new string('═', menuWidth - 2) + "╗";
            string bottomBorder = "╚" + new string('═', menuWidth - 2) + "╝";
            string paddedGoodbye = "║" + goodbyeText.PadCenter(menuWidth - 2) + "║";
            string paddedSub = "║" + subText.PadCenter(menuWidth - 2) + "║";
            int horizontalPadding = (consoleWidth - menuWidth) / 2;
            int topOffset = 1;

            Console.SetCursorPosition(horizontalPadding, topOffset);
            Console.WriteLine(topBorder);
            Console.SetCursorPosition(horizontalPadding, topOffset + 1);
            Console.WriteLine(paddedGoodbye);
            Console.SetCursorPosition(horizontalPadding, topOffset + 2);
            Console.WriteLine(paddedSub);
            Console.SetCursorPosition(horizontalPadding, topOffset + 3);
            Console.WriteLine(bottomBorder);
            Console.ResetColor();
        }
    }
}
