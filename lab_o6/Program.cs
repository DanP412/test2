using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace lab_o6
{
    public class Program
    {
        private static List<string> _roles = new List<string> { "ADMIN", "MODERATOR", "TEACHER", "STUDENT" };

        public static void Main(string[] args)
        {
            List<User> users = GetRandomUsers(20);

            // 1.
            Console.WriteLine("1. Długośc listy: " + users.Count);
            Console.WriteLine();

            // 2.
            var userNames = users.Select(u => u.Name); // Select "wyciąga" wskazaną właściwość z kolekcji obiektów, np. Name obiektów User
            string names = string.Join(", ", userNames); // Sklejenie kolekcji stringów w 1 długiego stringa
            Console.WriteLine("2. Imiona: " + names);
            Console.WriteLine();

            // 3.
            var sortedUserNames = users.Select(u => u.Name);
            var usersSortedByName = sortedUserNames.OrderBy(x => x);
            string sortedUserNamesString = string.Join(", ", usersSortedByName);
            Console.WriteLine("3. Posrotowane imiona: " + sortedUserNamesString);
            Console.WriteLine();

            // 4.
            string rolesString = string.Join(", ", _roles);
            Console.WriteLine("4. Dostępne role:  " + rolesString);
            Console.WriteLine();

            // 5. 
            // GroupBy tworzy listę pogrupowanych list po wskazanej właściwości
            // W tym przypadku ta lista zawiera listę adminów, listę moderatorów, listę studentów i listę nauczycieli
            Console.WriteLine("Pogrupowane role użytkowników: ");
            var userGroups = users.GroupBy(u => u.Role);

            // Pętla po grupach
            foreach (var userGroup in userGroups)
            {
                // Pętla po userach w danej grupie
                foreach (User user in userGroup)
                {
                    Console.WriteLine($"{user.Name} | {user.Role}");
                }

                Console.WriteLine();
            }

            // 6.
            // Count zlicza pasujące elementy kolekcji na podstawie przekazanego warunku
            // Any zwraca wartość bool, czy kolekcja zawiera jakikolwiek element
            int userWithMarksCount = users.Count(u => u.Marks != null && u.Marks.Any());
            Console.WriteLine();

            // 7.
            // Where odsiewa listę po podanym warunku
            // SelectMany łączy podrzędne kolekcje w jedną
            var students = users.Where(u => u.Role == "STUDENT");
            var allUserMarks = students.SelectMany(u => u.Marks); 
            double allUserMarkSum = allUserMarks.Sum();
            double allUserMarkCount = allUserMarks.Count();
            double allUserMarkAverage = allUserMarkSum / allUserMarkCount;
            Console.WriteLine("Suma: " + allUserMarkSum);
            Console.WriteLine("Ilość: " + allUserMarkCount);
            Console.WriteLine("Średnia: " + allUserMarkAverage);
            Console.WriteLine();

            // 8.
            int highestMark = allUserMarks.Max();
            Console.WriteLine("Najwyższa ocena: " + highestMark);

            // 9.
            int lowestMark = allUserMarks.Min();
            Console.WriteLine("Najniższa ocena: " + lowestMark);

            // 10.

            var userMarks = students.Select(u => u.Marks);
            Console.WriteLine(userMarks);

        }

        

        static List<User> GetRandomUsers(int count)
        {
            List<int> marks = new List<int> { 1, 2, 3, 4, 5, 6 };

            List<string> names = new List<string> { "Damian", "Basia", "Kasia", "Seba", "Jan", "Tomek" };

            List<User> users = new List<User>();

            for (int i = 0; i < count; i++)
            {
                User user = new User
                {
                    Name = names[RandomNumberGenerator.GetInt32(0, names.Count)],
                    Age = RandomNumberGenerator.GetInt32(20, 41),
                    Role = _roles[RandomNumberGenerator.GetInt32(0, _roles.Count)]
                };

                if (user.Role == "STUDENT")
                {
                    user.Marks = new int[RandomNumberGenerator.GetInt32(0, 21)];
                    for (int j = 0; j < user.Marks.Length; j++)
                    {
                        user.Marks[j] = RandomNumberGenerator.GetInt32(1, 7);
                    }
                }

                users.Add(user);
            }

            return users;
        }
    }
}
