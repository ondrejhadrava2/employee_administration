using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_and_maybe_time
{
    class UserInterface
    {
        public Database Database { get; private set; }

        public UserInterface(Database database){
            Database = database;
        }

        /// <summary>
        /// Searches and show employees by name, job, or combination of both.
        /// </summary>
        public void ShowEmployee()
        {
            // User's option variable with default value
            char option = '0';
            // User chooeses how he wants to search employees
            Console.WriteLine();
            Console.WriteLine("How do you want to search employee?");
            Console.WriteLine();
            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Job");
            Console.WriteLine("3 - Both");

            bool wrongOption = true;
            while (wrongOption)
            {
                Console.WriteLine();
                Console.Write("Pick one of the options above: ");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (option)
                {
                    case '1':
                        // Searching employees by name
                        Console.WriteLine();
                        Console.Write("Name: ");
                        string name1 = Console.ReadLine();
                        List<Employee> found = Database.FindEmployees(name1, "", true, false);
                        Console.WriteLine();
                        Console.WriteLine("Found employees:");
                        Visualize(found);
                        Console.WriteLine();
                        Console.WriteLine("Press random key for returning to the menu");
                        Console.ReadKey();
                        ReturnToMenu();
                        break;
                    case '2':
                        // Searching employees by job
                        Console.WriteLine();
                        Console.Write("Job: ");
                        string job1 = Console.ReadLine();
                        List<Employee> found2 = Database.FindEmployees("", job1, false, true);
                        Console.WriteLine();
                        Console.WriteLine("Found employees:");
                        Visualize(found2);
                        Console.WriteLine();
                        Console.WriteLine("Press random key for returning to the menu");
                        Console.ReadKey();
                        ReturnToMenu();
                        break;
                    case '3':
                        // Searching employees by name and job
                        Console.WriteLine();
                        Console.Write("Name: ");
                        string name2 = Console.ReadLine();
                        Console.Write("Job: ");
                        string job2 = Console.ReadLine();
                        List<Employee> found3 = Database.FindEmployees(name2, job2, true, true);
                        Visualize(found3);
                        Console.WriteLine();
                        Console.WriteLine("Press random key for returning to the menu");
                        Console.ReadKey();
                        ReturnToMenu();
                        break;
                    default:
                        Console.WriteLine("This option doesn't exist.");
                        break;
                }

                if (option == '1' || option == '2' || option == '3')
                    wrongOption = false;
            }
        }

        /// <summary>
        /// Asks user on information about employee and adds that employee into the database.
        /// </summary>
        public void AddEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("For adding new employee you will have to type his name and job.");
            Console.WriteLine();
            // Asks information about employee
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Job: ");
            string job = Console.ReadLine();
            // Adds employee into the database
            Database.AddEmployee(name, job);
            Console.WriteLine("{0} will be in registration system as a {1}.", name, job);

            Console.WriteLine();

            bool wrongOption = true;
            while (wrongOption)
            {
                Console.WriteLine("Do you want to continue in adding new employees? [y/n]");
                Console.Write("Your option: ");
                char option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (option)
                {
                    // User confirmed
                    case 'y':
                        // Removes employees from the database
                        AddEmployee();
                        break;
                    // User unconfirmed
                    case 'n':
                        // User has to click for returning to the menu
                        Console.WriteLine("Press random key for returning to the menu.");
                        ReturnToMenu();
                        break;
                    // User gave unexisting option 
                    default:
                        // User is informed about unexisting option and has to click for returning to the menu
                        Console.WriteLine("This option doesn't exist.");
                        Console.WriteLine();
                        break;
                }

                if (option == 'y' || option == 'n')
                    wrongOption = false;
            }
        }

        /// <summary>
        /// Asks user on information about employee and removes him from the database. User has to confirm his choice.
        /// </summary>
        public void RemoveEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("For removing employees you have to type his name and job.");
            Console.WriteLine();
            // Asks information about employee
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Job: ");
            string job = Console.ReadLine();
            Console.WriteLine();
            // List of employees which fitted with given informations
            List <Employee> found = Database.FindEmployees(name, job, true, true);
            Visualize(found);
            // User has to confirm his choice
            bool wrongOption = true;
            while (wrongOption)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to remove these employees? [y/n]");
                Console.Write("Your option: ");
                char option = Console.ReadKey().KeyChar;
                switch (option)
                {
                    // User confirmed
                    case 'y':
                        // Removes employees from the database
                        Database.RemoveEmployee(found, true, true);
                        Console.WriteLine("Employee has been removed.");
                        ReturnToMenu();
                        break;
                    // User unconfirmed
                    case 'n':
                        // User has to click for returning to the menu
                        Console.WriteLine("Press random key for returning to the menu.");
                        Console.ReadKey();
                        ReturnToMenu();
                        break;
                    // User gave unexisting option 
                    default:
                        // User is informed about unexisting option and has to click for returning to the menu
                        Console.WriteLine("This option doesn't exist.");
                        break;
                }

                if (option == 'y' || option == 'n')
                    wrongOption = false;
            }
        }

        /// <summary>
        /// Wrotes list of employees into the console.
        /// </summary>
        /// <param name="employees">List of the employees which will be written into the console.</param>
        private void Visualize(List <Employee> employees)
        {
            foreach(Employee e in employees)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Navigation providing using features and quitting programme.
        /// </summary>
        public void Menu()
        {
            // Outputs navigation including features and quit
            Console.WriteLine("Employee administration ver 0.1");
            Console.WriteLine();
            Console.WriteLine("1 - Show employees");
            Console.WriteLine("2 - Add employees");
            Console.WriteLine("3 - Remove employees");
            Console.WriteLine("4 - Quit  \n");

            // User's choice
                Console.Write("Pick one number between options above: ");
                char option = Console.ReadKey().KeyChar;


                switch (option)
                {
                    case '1':
                    // Shows employees
                        Console.WriteLine();
                        ShowEmployee();
                        break;
                    case '2':
                    // Adds employees
                        Console.WriteLine();
                        AddEmployee();
                        break;
                    case '3':
                    // Removes employees
                        Console.WriteLine();
                        RemoveEmployee();
                        break;
                    case '4':
                    // Quit the programme
                        Console.WriteLine();
                        Console.WriteLine("Programme will quit after pressing random key.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This option doesn't exist. Pressing random key will return you to the menu.");
                        Console.ReadKey();
                        ReturnToMenu();
                        break;
     
            }
        }

        public void ReturnToMenu()
        {
            Console.Clear();
            Menu();
        }
    }
}
