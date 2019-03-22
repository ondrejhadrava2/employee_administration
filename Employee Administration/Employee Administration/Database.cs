using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_and_maybe_time
{
    class Database
    {
        private List<Employee> employees = new List<Employee>();

        /// <summary>
        /// Adds employee to the database.
        /// </summary>
        /// <param name="name">Employee's name</param>
        /// <param name="job">Employee's job</param>
        public void AddEmployee (string name, string job)
        {
            Employee e = new Employee(name, job);
            employees.Add(e);
        }

        /// <summary>
        /// Finds employees in database by given parametres.
        /// </summary>
        /// <param name="name">Employee's name</param>
        /// <param name="job">Employee's job</param>
        /// <param name="byName">Searching employee by name.</param>
        /// <param name="byJob">Searching employee by job.</param>
        /// <returns></returns>
        public List<Employee> FindEmployees(string name, string job, bool byName, bool byJob)
        {
            List<Employee> found = new List<Employee>();
            foreach (Employee e in employees)
            {
                // Searching by name
                if (byName && !byJob)
                {
                    if (name == e.Name)
                        found.Add(e);
                }
                //Searching by job
                else if (!byName && byJob)
                {
                    if (job == e.Job)
                        found.Add(e);
                }
                //Searching by job and name 
                else if (byJob & byName)
                {
                    if (job == e.Job && name == e.Name)
                        found.Add(e);
                }

            }
            return found;
        }

        /// <summary>
        /// Removes employees in database by given paramatres.
        /// </summary>
        /// <param name="employee">List of Employee object which will be removed from the database</param>
        /// <param name="byName">Searching employee by name.</param>
        /// <param name="byJob">Searching employee by job.</param>
        public void RemoveEmployee(List <Employee> employee, bool byName, bool byJob)
        {
            foreach (Employee e in employee)
            {
                employees.Remove(e);
            }
        }

    }
}
