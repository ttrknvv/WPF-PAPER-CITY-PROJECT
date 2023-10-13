using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE.Model
{
    public class ReviewProblem
    {
        [Key]
        public int ID_REVIEW { get; set; }
        public string LOGIN { get; set; }
        public DateTime DATE { get; set; }
        public string REVIEW_TEXT { get; set; }
        public string STATE { get; set; }
    }
}
