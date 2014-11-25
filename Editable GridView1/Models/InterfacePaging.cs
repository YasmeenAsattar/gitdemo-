using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Editable_GridView1.Models
{
    public class InterfacePaging
    {
        public IEnumerable<Employee> employees { get; set; }
        public int totalRows { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}