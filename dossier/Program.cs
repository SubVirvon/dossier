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
            const string CommandSearchDossier = "4";
            const string CommandExit = "5";
            string[] fullName = new string[0];
            string[] job = new string[0];
            bool isExit = false;

            while (isExit == false)
            {
                Console.CursorVisible = true;
                Console.Write($"{CommandAddDossier} Добавить досье\n{CommandWriteAllDossiers} Вывести все досье\n{CommandDeleteDossier} Удалить досье\n{CommandSearchDossier} Поиск по фамилии\n{CommandExit} Выйти\n\nВведите команду: ");

                switch (Console.ReadLine())
                {
                    case CommandAddDossier:
                        AddDossier(ref fullName, ref job);
                        break;
                    case CommandWriteAllDossiers:
                        WriteAllDossiers(fullName, job);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(ref fullName, ref job);
                        break;
                    case CommandSearchDossier: 
                        SearchDossier(fullName, job);
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

        static void AddDossier(ref string[] fullName, ref string[] job)
        {
            Console.Write("Введите ФИО: ");
            fullName = AddElement(fullName, Console.ReadLine());
            Console.Write("Введите должность: ");
            job = AddElement(job, Console.ReadLine());
            Console.CursorVisible = false;
        }

        static void WriteAllDossiers(string[] fullName, string[] job)
        {
            Console.Write("Досье: ");

            for (int i = 0; i < fullName.Length; i++)
            {
                WriteDossierElement(i, fullName, job);
            }

            Console.CursorVisible = false;
        }

        static string[] AddElement(string[] array, string element)
        {
            string[] tempArray = new string[array.Length + 1];

            tempArray[tempArray.Length - 1] = element;

            for(int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
            return array;
        }

        static void DeleteDossier(ref string[] fullName, ref string[] job)
        {
            const string CommandExitDelete = "exit";
            string command;
            int deleteIndex;

            Console.Write($"Какой номер досье вы хотите удалить (отмена - {CommandExitDelete}): ");
            command = Console.ReadLine();

            if (command != CommandExitDelete)
            {
                deleteIndex = Convert.ToInt32(command);

                if (deleteIndex <= fullName.Length && deleteIndex > 0)
                {
                    fullName = DeleteElement(fullName, deleteIndex);
                    job = DeleteElement(job, deleteIndex);
                }
                else
                {
                    Console.Write("Недопустимое значение");
                }
            }

            Console.CursorVisible = false;
        }

        static string[] DeleteElement(string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];
            
            for(int i = index - 1; i < array.Length; i++)
            {
                if (i + 1 != array.Length)
                {
                    array[i] = array[i + 1];
                }
            }

            for(int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
            return array;
        }

        static void WriteDossierElement(int index, string[] fullName, string[] job)
        {
            Console.Write($"{index + 1}.{fullName[index]} - {job[index]}. ");
        }

        static void SearchDossier(string[] fullName, string[] job)
        {
            int searchIndex = 0;
            bool isFind = false;
            string surname;

            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {
                string[] tempArray = fullName[i].Split(' ');

                if (surname == tempArray[0])
                {
                    searchIndex = i;
                    isFind = true;
                    break;
                }
            }

            if (isFind)
            {
                WriteDossierElement(searchIndex, fullName, job);
            }
            else
            {
                Console.WriteLine("Досье не найдено");
            }

            Console.CursorVisible = false;
        }
    }
}
