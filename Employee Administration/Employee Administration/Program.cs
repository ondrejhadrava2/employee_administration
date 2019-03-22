using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_and_maybe_time
{
    class Program
    {
        static void Main(string[] args)
        {
            Database d = new Database();
            UserInterface ui = new UserInterface(d);

            ui.Menu();
        }
    }
}
