using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE.Model
{
    public class Books
    {
        private string cost;
        public int ID_BOOK { get; set; }
        public string IMAGE_BOOK { get; set; }
        public string NAME { get; set; }
        public string AUTHOR { get; set; }
        public int POPULARITY { get; set; }
        public string GENRE { get; set; }
        public string DESCRIPTION { get; set; }
        public string TYPE_PRICE { get; set; }
        public float COST
        {
            get
            {
                return cost == "Бесплатно" ? 0 : float.Parse(cost.Substring(0, cost.Length - 4));
            }
            set
            {
                cost = value == 0 ? "Бесплатно" : Convert.ToString(value) + " BYN";
            }
        }
        public string COST_CUT
        {
            get
            {
                return cost;
            }
        }
        public DateTime DATE_PUBLICATION { get; set; }
        public string PATH_DOWNLOAD { get; set; }
        
    }
}
