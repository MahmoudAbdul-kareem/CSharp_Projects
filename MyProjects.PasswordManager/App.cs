using System.Drawing;
using System.Text;

namespace MyProject.PasswordManager;
public class App
{
    /* [Password Manager]
        0. Authentication
        1. List all passwords
        2. Add or change passwords
        3. Get password
        4. Delete password
    */

    private static readonly Dictionary<string, string> _passwordEntries = new();
    public static void Run(string[] args)
    {
        ReadPasswords(); // read passwords from file
        Authentication(); // verify admin password
        while(true)
        {
            Console.WriteLine("Please type command:");
            Console.WriteLine("ls -> List all passwords");
            Console.WriteLine("ad -> Add/Change password");
            Console.WriteLine("gt -> Get pssword");
            Console.WriteLine("dl -> Delete password");
            Console.WriteLine("q  -> Quit program");
            Console.WriteLine("===========================================");
            Console.Write("command$ ");
        
            var choice = Console.ReadLine();
            Console.Clear();

            switch(choice)
            {
                case "ls":
                    ListAllPasswords();
                    break;

                case "ad":
                    AddOrChangePasswords();
                    break;

                case "gt":
                    GetPasswords();
                    break;

                case "dl":
                    DeletePasswords();
                    break;
                
                case "q":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                
                default:
                    Console.WriteLine("================= Output ==================");
                    Console.WriteLine("Enter valid choice...");
                    break;
            }
            Console.WriteLine("===========================================");
        }
    }

    private static void Authentication()
    {
        Console.WriteLine("====> Welcome to Password Manager App <====");

        if (_passwordEntries.ContainsKey("admin"))
        {
            // check password for 'three' times
            uint  numberOfTries = 2;
            while (true)
            {
                Console.WriteLine("Please enter your 'admin' password:");
                var adminPassword = Console.ReadLine();

                if (adminPassword == _passwordEntries["admin"])
                {
                    Console.Clear();
                    Console.WriteLine("======== You loged in successfully ========");
                    break;
                }
                else if (0 != numberOfTries)
                {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Password NOT correct! - [{numberOfTries}] available tries");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-------------------------------------------");
                    numberOfTries--;
                }
                else
                {
                    Console.WriteLine("========= Authentication failed! ==========");
                    Environment.Exit(0);
                }
            }
        }
        else
        {
            // create admin password
            Console.WriteLine("Please create the 'admin' password");
            var adminPassword = Console.ReadLine();
            _passwordEntries.Add("admin", adminPassword);
            SavePasswords();
        }
    }

    private static void DeletePasswords()
    {
        Console.WriteLine("============= Delete Password =============");
        Console.WriteLine("Please Enter website/app name");
        var appName = Console.ReadLine();
        if(_passwordEntries.ContainsKey(appName)) // found
        {
            _passwordEntries.Remove(appName);
            SavePasswords();
        }
        else
            Console.WriteLine("Password not found!");
    }

    private static void GetPasswords()
    {
        Console.WriteLine("============== Get Password ===============");
        Console.WriteLine("Please Enter website/app name");
        var appName = Console.ReadLine();
        if(_passwordEntries.ContainsKey(appName)) // found
            Console.WriteLine($"Password is: {_passwordEntries[appName]}");
        else
            Console.WriteLine("Password not found!");

    }

    private static void AddOrChangePasswords()
    {
        Console.WriteLine("=========== Add/Change Password ===========");
        Console.WriteLine("Please Enter website/app name");
        var appName = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        var password = Console.ReadLine();

        if(_passwordEntries.ContainsKey(appName)) // found
            _passwordEntries[appName] = password; // change 
        else
            _passwordEntries.Add(appName, password); // add

        SavePasswords();
    }

    private static void ListAllPasswords()
    {
        Console.WriteLine("============== All Passwords ==============");
        foreach (var entry in _passwordEntries)
        {
            if (entry.Key != "admin")
                Console.WriteLine($"{entry.Key} = {entry.Value}");
        }
    }

    private static void ReadPasswords()
    {
        Console.Clear(); // clear screen

        if (File.Exists("passwords.txt"))
        {
            var passwordLines = File.ReadAllText("passwords.txt");
            foreach (var line in passwordLines.Split(Environment.NewLine))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    // google.com=kljds
                    var equalIndex = line.IndexOf('=');
                    var appName = line.Substring(0, equalIndex);
                    var password = line.Substring(equalIndex + 1);

                    _passwordEntries.Add(appName, EncryptionUtiliy.Decrypt(password));
                }
            }

        }
    }

    private static void SavePasswords()
    {
        var sb = new StringBuilder();
        foreach (var entry in _passwordEntries)
            sb.AppendLine($"{entry.Key}={EncryptionUtiliy.Encrypt(entry.Value)}");
        File.WriteAllText("passwords.txt", sb.ToString());
    }
}
