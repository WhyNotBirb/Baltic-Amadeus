using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_C3
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type_Id { get; set; }
        public string Type_Label { get; set; }
        public int Lan_Id { get; set; }
        public string Lan_Label { get; set; }
        public int Children { get; set; }
        public int Free_space { get; set; }
      
    }

}
