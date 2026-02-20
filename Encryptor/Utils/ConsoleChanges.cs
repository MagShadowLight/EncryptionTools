using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryptor.Utils
{
    public class ConsoleChanges
    {
        public static void Colors(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Clear();
        }
    }
}
