using Restt.Context;
using Restt.Models;
using Restt.Repositories;
using Restt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restt
{
    class Program
    {
        static void Main(string[] args)
        {
            RestMenu restMenu = new RestMenu();
            restMenu.Menu();
        }
    }
}
