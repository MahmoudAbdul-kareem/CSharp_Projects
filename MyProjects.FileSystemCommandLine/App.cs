using System.Runtime.InteropServices;
using System;

namespace MyProjects.FileSystemCommandLine;
public class App
{
    /* [File system command line]
        - list files & directories:     ls    [path]
        - print file & directory info:  info  [path]
        - create directory:             mkdir [path]
        - create file:                  touch [path]
        - remove directory or file:     rm    [path]
        - read file content:            cat   [path]
        - clear terminal:               clear
        - exit program:                 exit
    */
    public static void Run(string[] args)
    {
        Console.Clear();
        while (true)
        {
            Console.Write("command@shell$ ");
            string ? input = Console.ReadLine().Trim(); // remove extra whitespaces
            string ? command = "";
            string ? path = "";

            // command validation.
            if (0 == input.Length) // you pressed enter key
                continue;
            if (-1 == input.IndexOf(' ')) // no space in input
                command = input;
            else
            {
                command = input.Substring(0, input.IndexOf(' '));
                path = input.Substring(input.IndexOf(' ') + 1);
            }

            if (command == "ls")
            {
                if(Directory.Exists(path))
                {
                    foreach (var entry in Directory.GetDirectories(path))
                        Console.WriteLine($"\t[dir] {entry}");

                    foreach (var entry in Directory.GetFiles(path))
                        Console.WriteLine($"\t[file] {entry}");
                }
                else
                    Console.WriteLine("Please enter valid path");
            }

            else if (command == "info")
            {
                if (Directory.Exists(path))
                {
                    var dirInfo = new DirectoryInfo(path);
                    Console.WriteLine($"Type: dir");
                    Console.WriteLine($"Created at: {dirInfo.CreationTime}");
                    Console.WriteLine($"Last modified at: {dirInfo.LastWriteTime}");
                }
                else if (File.Exists(path))
                {
                    var fileInfo = new FileInfo(path);
                    Console.WriteLine($"Type: file");
                    Console.WriteLine($"Created at: {fileInfo.CreationTime}");
                    Console.WriteLine($"Last modified at: {fileInfo.LastWriteTime}");
                    Console.WriteLine($"Size in bytes: {fileInfo.Length}");
                }
                else
                    Console.WriteLine("Please enter valid path");
            }

            else if (command == "mkdir")
            {
                Directory.CreateDirectory(path);
            }

            else if (command == "touch")
            {
                File.CreateText(path);
            }

            else if (command == "rm")
            {
                if (Directory.Exists(path))
                {
                    try
                    {
                        Directory.Delete(path); // Delete empty directories
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("error: trying to delete non-empty directory!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (File.Exists(path))
                    File.Delete(path);

                else
                    Console.WriteLine("Please enter valid path");
            }

            else if (command == "cat")
            {
                if (File.Exists(path))
                {
                    var content = File.ReadAllText(path);
                    Console.WriteLine(content);
                }
                else
                    Console.WriteLine("file doesn't exits");
            }

            else if (command == "clear")
            {
                Console.Clear();
            }

            else if (command == "exit")
            {
                break; // exit from program
            }

            else 
            {
                Console.WriteLine($"Command '{command}' not found!");
            }
        }
    }
}
