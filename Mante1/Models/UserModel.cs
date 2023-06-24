using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mante1.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string CodUser { get; set; }
        public int Id { get; set; }
    }
}

//Para que se le aplique a todos los registros.
public abstract class BaseModels {
    public int Id { get; set; }
}