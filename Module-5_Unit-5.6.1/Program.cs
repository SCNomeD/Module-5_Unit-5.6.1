using System;

namespace Module_5_Unit_5._6._1
{
    class Program
    {
        static (string, string, int, string[], string[]) UserInfo()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] FavColors) User;

            Console.Write("Введите Ваше имя: ");
            User.Name = Console.ReadLine();

            Console.Write("Введите Вашу фамилию: ");
            User.LastName = Console.ReadLine();

            string ConsoleAge;
            int Age;
            do
            {
                Console.Write("Введите Ваш возраст: ");
                ConsoleAge = Console.ReadLine();
            }
            while (!CheckNumber(ConsoleAge, out Age));

            User.Age = Age;

            bool HaveAPet;
            bool CheckAPet;

            do
            {
                Console.Write("Есть ли у Вас животные? (да/нет) ");
                switch (Console.ReadLine())
                {
                    case "да":

                        HaveAPet = true;
                        CheckAPet = true;
                        break;

                    case "нет":

                        HaveAPet = false;
                        CheckAPet = true;
                        break;

                    default:

                        HaveAPet = false;
                        CheckAPet = false;
                        Console.WriteLine("Проверьте правильность введенного ответа");
                        break;
                }
            }
            while (!CheckAPet);

            if (HaveAPet)
            {
                string ConsoleNumPets;
                int NumPets;
                do
                {
                    Console.Write("Введите кол-во Ваших питомцев: ");
                    ConsoleNumPets = Console.ReadLine();
                }
                while (!CheckNumber(ConsoleNumPets, out NumPets));

                User.Pets = GetUserPets(NumPets);
            }
            else
            {
                User.Pets = new string[1];

                for (int i = 0; i < User.Pets.Length; i++)
                {
                    User.Pets[i] = "у Вас нет питомцев";
                }
            }

            string ConsoleNumColors;
            int NumColors;
            do
            {
                Console.Write("Введите число ваших любимых цветов: ");
                ConsoleNumColors = Console.ReadLine();
            }
            while (!CheckNumber(ConsoleNumColors, out NumColors));

            User.FavColors = GetFavColors(NumColors);

            return User;
        }
        static bool CheckNumber(string innum, out int correctnum)
        {
            if (int.TryParse(innum, out int intnumber))
            {
                if (intnumber > 0)
                {
                    correctnum = intnumber;
                    return true;
                }
            }
            correctnum = 0;
            return false;
        }
        static string[] GetUserPets(int num)
        {
            var petsarray = new string[num];

            for (int i = 0; i < petsarray.Length; i++)
            {
                Console.Write("Введите кличку Вашего питомца №{0}: ", i + 1);
                petsarray[i] = Console.ReadLine();
            }

            return petsarray;
        }
        static string[] GetFavColors(int num)
        {
            var favcolor = new string[num];

            for (int i = 0; i < favcolor.Length; i++)
            {
               Console.Write("(red/green/cyan/yellow/gray/blue/magenta)\nВведите ваш любимый цвет №{0}: ", i + 1);
                favcolor[i] = Console.ReadLine();
            }

            return favcolor;
        }
        static void ShowUser((string Name, string LastName, int Age, string[] Pets, string[] FavColor) ShowUser)
        {
            Console.WriteLine();
            Console.WriteLine("Ваше имя: {0}", ShowUser.Name);
            Console.WriteLine("Ваша фамилия: {0}", ShowUser.LastName);
            Console.WriteLine("Ваш возраст: {0}", ShowUser.Age);

            Console.Write("Клички ваших питомцев: ");
            for (int i = 0; i < ShowUser.Pets.Length; i++)
            {
                if (i == ShowUser.Pets.Length - 1)
                {
                    Console.Write(ShowUser.Pets[i] + " ");
                }
                else
                {
                    Console.Write(ShowUser.Pets[i] + ", ");
                }
            }

            Console.WriteLine();

            Console.Write("Ваши любимые цвета: ");
            for (int i = 0; i < ShowUser.FavColor.Length; i++)
            {
                var color = ShowUser.FavColor[i];
                switch (color)
                {
                    case "red":
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case "green":
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case "cyan":
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case "yellow":
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case "gray":
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case "blue":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    case "magenta":
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                }
                if (i == ShowUser.FavColor.Length - 1)
                {
                    Console.Write(ShowUser.FavColor[i] + " ");
                }
                else
                {
                    Console.Write(ShowUser.FavColor[i] + ", ");
                }
            }
        }
        static void Main(string[] args)
        {
            var User = UserInfo();

            ShowUser(User);

            Console.ReadLine();
        }
    }
}
