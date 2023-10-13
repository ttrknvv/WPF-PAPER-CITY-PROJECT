using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE.Model
{
    public class User
    {
        public int ID_USER { get; set; }
        public string IMAGE_PROFILE { get; set; }
        public string LOGIN { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        private string phone_number;
        public string PHONE_NUMBER
        {
            get
            {
                return phone_number;
            }
            set
            {
                phone_number = String.IsNullOrWhiteSpace(value) ? "Не указано!" : value;
            }
        }
        public DateTime DATE_REGISTRATION { get; set; }
        public string ROLE { get; set; }
    }
}
