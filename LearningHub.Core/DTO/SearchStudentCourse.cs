using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class SearchStudentCourse
    {
        public string? Firstname { get; set; }
        public decimal? Markofstd { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public string? Coursename { get; set; }

    }
}
