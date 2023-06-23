using Mante1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mante1.Services
{
    public class Functions : IFunctions
    {
        public string CambiarTexto(string text, int count)
        => $"{text} {count}";
    }
}
