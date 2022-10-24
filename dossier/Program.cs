using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dossier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandWriteAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandExit = "5";
            List<string> fullName = new List<string>();
            List<string> job = new List<string>();
            bool isExit = false;

            while (isExit == false)
            {
                Console.CursorVisible = true;
                Console.Write($"{CommandAddDossier} Добавить досье\n{CommandWriteAllDossiers} Вывести все досье\n{CommandDeleteDossier} Удалить досье\n{CommandExit} Выйти\n\nВведите команду: ");

                switch (Console.ReadLine())
                {
                    case CommandAddDossier:
                        AddDossier(fullName, job);
                        break;
                    case CommandWriteAllDossiers:
                        WriteAllDossiers(fullName, job);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(fullName, job);
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Некоректная команда");
                        Console.CursorVisible = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine("Программа завершена");
            Console.CursorVisible = false;
            Console.ReadLine();
        }

        static void AddDossier(List<string> fullName, List<string> job)
        {
            Console.Write("Введите ФИО: ");
            fullName.Add(Console.ReadLine());
            Console.Write("Введите должность: ");
            job.Add(Console.ReadLine());
            Console.CursorVisible = false;
        }

        static void WriteAllDossiers(List<string> fullName, List<string> job)
        {
            Console.Write("Досье: ");

            for (int i = 0; i < fullName.Count; i++)
            {
                Console.Write($"{i + 1}.{fullName[i]} - {job[i]} ");
            }

            Console.CursorVisible = false;
        }

        static void DeleteDossier(List<string> fullName, List<string> job)
        {
            const string CommandExitDelete = "exit";
            string command;

            Console.Write($"Какой номер досье вы хотите удалить (отмена - {CommandExitDelete}): ");
            command = Console.ReadLine();

            if (command != CommandExitDelete)
            {
                if(int.TryParse(command, out int deleteIndex))
                {
                    deleteIndex = Convert.ToInt32(command);

                    if (deleteIndex <= fullName.Count && deleteIndex > 0)
                    {
                        fullName.RemoveAt(deleteIndex - 1);
                        job.RemoveAt(deleteIndex - 1);
                    }
                    else
                    {
                        Console.Write("Недопустимое значение");
                    }
                }
                else
                {
                    Console.Write("Недопустимое значение");
                }
            }

            Console.CursorVisible = false;
        }
    }
}
