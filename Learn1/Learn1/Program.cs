namespace Learn1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var admin = new Person
            {
                Name = "Admin",
            };
            var ivan = new Person
            {
                Name = "Ivan",
            };
            var misha = new Person
            {
                Name = "Misha",
            };
            var persons = new[]
            {
                admin, ivan, misha
            };
            var rootFolder = new Folder
            {
                Name = "Root",
                Access =
                [
                    new FolderAccess
                    {
                        Person = admin,
                        CanRead = true,
                        CanCreate = true,
                        CanUpdate = true,
                        CanDelete = false,
                    },
                    new FolderAccess
                    {
                        Person = ivan,
                        CanRead = true,
                        CanCreate = true,
                        CanUpdate = false,
                        
                        CanDelete = false,
                    }
                ]
            };
            var childFolder = new Folder
            {
                Name = "Child",
                Parent = rootFolder,
                Access = 
                [
                    new FolderAccess
                    {
                        Person = admin,
                        CanRead = true,
                        CanCreate = true,
                        CanUpdate = true,
                        CanDelete = true,
                    },
                    new FolderAccess
                    {
                        Person = ivan,
                        CanRead = true,
                        CanCreate = true,
                        CanUpdate = true,
                        CanDelete = true,
                    }
                ]
            };

            Console.WriteLine("Привет это программа проверки доступа на папки");
            Console.Write("Пожалуйста введите свое имя:");
            var inputPersonName = Console.ReadLine();
            var isExist = false;
            foreach (var person in persons)
            {
                if (person.Name == inputPersonName)
                {
                    isExist = true;
                }
            }

            if (isExist == false)
            {
                Console.WriteLine("К сожалению у вас нет доступа");
                return;
            }
            
            Console.WriteLine("Ура вы вошли");
            Console.Write("Пожалуйста введите папку которую хотите проверить:");
            var inputFolderName = Console.ReadLine();
            var isExistFolder = childFolder.TryGetFolder(inputFolderName!, out var folder);
            if (isExistFolder == false)
            {
                Console.WriteLine("Папки нет такой");
                return;
            }
            
            Console.WriteLine("Папка есть, проверяем доступ");
            var inputPerson = new Person
            {
                Name = inputPersonName!
            };
            var hasReadAccess = folder!.HasReadAccess(inputPerson);
            if (hasReadAccess)
            {
                Console.WriteLine("У вас есть доступ");
            }
            else
            {
                Console.WriteLine("У вас нет доступа");
            }
        }
    }
}
