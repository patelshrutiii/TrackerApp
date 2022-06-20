using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace WebTracker_ProjectBLL
{
    public class Project
    {
        [Key]
        public int Proj_id { get; set; }

        public string Pname { get; set; }

        public string Remark { get; set; }
    }
}
