using System;
using blockbuster.Model;
using blockbuster.Model.Enum;
using blockbuster.Repository;

namespace blockbuster
{
    class Program
    {
        static MediaRepository repository = new MediaRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAll();
                        break;
                    case "2":
                        Insert();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        FindById();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }
        }

        private static void FindById()
        {
            Console.WriteLine("Id: ");
            int indexMedia = int.Parse(Console.ReadLine());

            var media = repository.FindById(indexMedia);

            Console.WriteLine(media);
        }

        private static void Delete()
        {
            Console.WriteLine("Id: ");
            int indexMedia = int.Parse(Console.ReadLine());

            repository.Delete(indexMedia);
        }

        private static void Update()
        {
            Console.Write("Id: ");
            int indexMedia = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genre), i));   
            }

            Console.Write("Select the genre by its number: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Year of Release: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Description: ");
            string inputDescription = Console.ReadLine();


            foreach (int i in System.Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Category), i));
            }

            Console.Write("Select the category by its number: ");
            int inputCategory = int.Parse(Console.ReadLine());

            Media updatedMedia = new Media(id: indexMedia,
                                           genre: (Genre) inputGenre,
                                           title: inputTitle,
                                           year: inputYear,
                                           description: inputDescription,
                                           category: (Category) inputCategory);

            repository.Update(indexMedia, updatedMedia);
            
        }

        private static void Insert()
        {
            foreach (int i in System.Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genre), i));   
            }

            Console.Write("Select the genre by its number: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Year of Release: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Description: ");
            string inputDescription = Console.ReadLine();


            foreach (int i in System.Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Category), i));
            }

            Console.Write("Select the category by its number: ");
            int inputCategory = int.Parse(Console.ReadLine());

            Media savedMedia = new Media(id: repository.NextId(),
                                           genre: (Genre) inputGenre,
                                           title: inputTitle,
                                           year: inputYear,
                                           description: inputDescription,
                                           category: (Category) inputCategory);

            repository.Create(savedMedia);
        }

        private static void ListAll()
        {
            Console.WriteLine("List All");

            var list = repository.ListAll();

            if (list.Count == 0)
            {
                Console.WriteLine("There are not Media registered");
            }

            foreach (var item in list)
            {
                var deleted = item.returnDeleted();

                Console.WriteLine("{0} - {1}", item.returnId(), item.returnTitle(), deleted ? "*Deleted*" : "");
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("***BLOCKBUSTER***");
            Console.WriteLine("Select One Option:");
            Console.WriteLine("1 - List All Movies or Series");
            Console.WriteLine("2 - Insert a new Movie or Serie");
            Console.WriteLine("3 - Update a Movie or Serie");
            Console.WriteLine("4 - Delete a Movie or Serie");
            Console.WriteLine("5 - Find a Movie or Serie");
            Console.WriteLine("C - Clean");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }
    }
}
