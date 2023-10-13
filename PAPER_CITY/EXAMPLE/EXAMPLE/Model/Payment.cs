using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE.Model
{
    public class Payment
    {
        public int ID_PAY { get; set; }
        public int ID_USER { get; set; }
        public string NUMBER_CARD { get; set; }
        public string NAME_OWNER { get; set; }
        public string DATE { get; set; }
        public int ID_BOOK { get; set; }
        public string STATE { get; set; }
    }
}
