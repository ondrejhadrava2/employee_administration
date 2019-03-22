using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_and_maybe_time
{
    class Employee
    {
        // Name of employee used for searching in the database
        public string Name { get; private set; }
        // Job of employee used for searching in the database
        public string Job { get; set; }

        public Employee(string name, string job)
        {
            Name = name;
            Job = job;
        }
        /// <summary>
        /// Returns text represenatation of Employee's instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + " works as a " + Job + ".";
        }
    }
}
