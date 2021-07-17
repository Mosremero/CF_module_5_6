using System;

namespace CF_module_5_6
{
    class Program
    {
        static void Main(string[] args)
        {
           var UserInfo = GetUserInfo();
           WriteUserInfo(UserInfo);
        }

        private static void WriteUserInfo((string firstname, string lastname, int age, bool is_have_pet, int pet_cnt, string[] pet_names, int colors_cnt, string[] favcolors) userInfo)
        {
            Console.WriteLine("\nФинальные данные: ");
            Console.WriteLine("Имя: {0}\nФамилия: {1}\nВозраст: {2}\nНаличие питомца: {3}", userInfo.firstname, userInfo.lastname, userInfo.age, userInfo.is_have_pet ? "да" : "нет"); ;
            if (userInfo.is_have_pet)
            {
                Console.WriteLine("Количество питомцев: {0}", userInfo.pet_cnt);
                Console.Write("Клички питомцев: ");
                for (int i = 0; i < userInfo.pet_names.Length; i++)
                {
                    if (i > 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(userInfo.pet_names[i]);
                }
            }
            Console.WriteLine("{0}Количество любимых цветов: {1}", userInfo.is_have_pet ? "\n" : "", userInfo.colors_cnt);;
            Console.Write("Любимые цвета: ");
            for (int i = 0; i < userInfo.favcolors.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(", ");
                }
                Console.Write(userInfo.favcolors[i]);
            }
            Console.ReadKey();

        }

        static (string firstname, string lastname, int age, bool is_have_pet, int pet_cnt, string[] pet_names, int colors_cnt, string[] favcolors) GetUserInfo()
        {
            const string pet_yes = "да";
            (string firstname, string lastname, int age, bool is_have_pet, int pet_cnt, string[] pet_names, int colors_cnt, string[] favcolors) UserInfo = ("", "", 0, false, 0, Array.Empty<string>(), 0, Array.Empty<string>());
            Console.Write("Введите имя: ");
            UserInfo.firstname = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            UserInfo.lastname = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.Write("Введите возраст: ");
                age = Console.ReadLine();

            } while (CheckNum(age, out intage) == false);

            UserInfo.age = intage;

            Console.Write("Есть ли питомец?(да): ");
            UserInfo.is_have_pet = pet_yes == Console.ReadLine() ? true : false;

            if (UserInfo.is_have_pet)
            {
                string pet_cnt;
                int int_pet_Cnt;
                do
                {
                    Console.Write("Сколько питомцев есть?: ");
                    pet_cnt = Console.ReadLine();

                } while (CheckNum(pet_cnt, out int_pet_Cnt) == false);

                UserInfo.pet_cnt = int_pet_Cnt;

                UserInfo.pet_names = getPetNames(UserInfo.pet_cnt);
            }

            string colors_cnt;
            int int_colors_cnt;
            do
            {
                Console.Write("Сколько любимых цветов есть?: ");
                colors_cnt = Console.ReadLine();

            } while (CheckNum(colors_cnt, out int_colors_cnt) ==false);

            UserInfo.colors_cnt = int_colors_cnt;

            UserInfo.favcolors = getFavoritesColors(UserInfo.colors_cnt);

            return UserInfo;
        }


        static bool CheckNum(string number, out int cor_number)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    cor_number = intnum;
                    return true;
                }
            }
            {
                cor_number = 0;
                return false;
            }
        }

        /* клички питомцев */
        static string[] getPetNames(int cnt)
        {
            string[] result = new string[cnt];
            Console.WriteLine("Введите имена питомцев: ");
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine("Питомец {0}: ", i+1);
                result[i] = Console.ReadLine();
            }
            return result;
        }

        /* названия любимых цветов по количеству */
        static string[] getFavoritesColors(int cnt)
        {
            string[] result = new string[cnt];
            Console.WriteLine("Введите названия любимых цветов: ");
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine("Любимый цвет {0}: ", i+1);
                result[i] = Console.ReadLine();
            }
            return result;
        }



    }
}
