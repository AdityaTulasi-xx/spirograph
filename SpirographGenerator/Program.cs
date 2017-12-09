using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirographGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
                SpirographGenerator randomSpiral = new SpirographGenerator(450, 152, 150, 0.001);
                ImageGenerator.CreateAndSaveImage("4500x" + ".jpeg", randomSpiral.GenerateSpirograph(), 1000, 1000);
        }
    }
}
