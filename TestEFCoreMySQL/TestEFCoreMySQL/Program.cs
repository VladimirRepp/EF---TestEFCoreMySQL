using Microsoft.EntityFrameworkCore;
using TestEFCoreMySQL.Contexts;
using TestEFCoreMySQL.Models;
using Utils;

/// Instal Packages in NuGet (with dependencies):
/// - Pomelo.EntityFrameworkCore.MySql (9.0.0)
namespace TestEFCoreMySQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Add_Test();
            ConsoleVeiw_Test();
            ConsoleHelper.ConsolePuase();

            Edit_Test();
            ConsoleVeiw_Test();
            ConsoleHelper.ConsolePuase();

            Delete_Test();
            ConsoleVeiw_Test();
            ConsoleHelper.ConsolePuase();

            Clear_Test();
            ConsoleVeiw_Test();
            ConsoleHelper.ConsolePuase();
        }

        #region === CRUD Test ===

        private static void Add_Test()
        {
            using (DbAppContext db = new())
            {
                DbUser user1 = new (){ Email = "myemail@email.ru", PasswordHash = "hashpass" };
                DbUser user2 = new () { Email = "myemail_1@email.ru", PasswordHash = "hashpass1" };

                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }

            Console.WriteLine("Добавление выполнено!");
        }

        private static void Edit_Test()
        {
            using (DbAppContext db = new())
            {
                DbUser? user = db.Users.FirstOrDefault();

                if(user == null)
                {
                    Console.WriteLine("Данные не найдены!");
                    return;
                }

                user.Email = "NEW_myemail@email.ru";
                user.PasswordHash = "NEW_hashpass";

                db.SaveChanges();
            }

            Console.WriteLine("Обновление выполнено!");
        }

        private static void Delete_Test()
        {
            using (DbAppContext db = new())
            {
                DbUser? user = db.Users.FirstOrDefault();

                if (user == null)
                {
                    Console.WriteLine("Данные не найдены!");
                    return;
                }

                db.Users.Remove(user);
                db.SaveChanges();
            }

            Console.WriteLine("Удаление выполнено!");
        }

        private static void Clear_Test()
        {
            using (DbAppContext db = new())
            {
                db.Database.ExecuteSqlRaw("TRUNCATE TABLE users");
            }

            Console.WriteLine("Очистка выполнена!");
        }

        private static void ConsoleVeiw_Test()
        {
            using (DbAppContext db = new())
            {
                if (db.Users.Count() == 0)
                {
                    Console.WriteLine("Локальное хранилище пусто!");
                    return;
                }

                foreach (var u in db.Users)
                {
                    Console.WriteLine($"{u.Id}.{u.Email} - {u.PasswordHash}");
                }
            }
        }
        #endregion
    }
}
