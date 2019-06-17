using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPi.BAL.Model
{
  public  class EmployeeTest
    {
        public int count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string CName { get; set; }
        public string SName { get; set; }
        public int StateID { get; set; }
        public int ContryID { get; set; }
        public int Editmode { get; set; }
        public List<Contryclass> Contrylist { get; set; }
        public List<Stateclass>  statelist{ get; set; }
}
    public class Contryclass
    {
        public int ContryId { get; set; }
        public String ContryName { get; set; }
    }
    public class Stateclass
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
