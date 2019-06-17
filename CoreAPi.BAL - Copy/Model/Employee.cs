using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPi.BAL.Model
{
    public class EmployeeBAL
    {
        public int count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string CName { get; set; }
        public string SName { get; set; }
        public int StateID { get; set; }
        public int ContryID { get; set; }
        public int Editmode { get; set; }
        public List<listemnp> ListEmp { get; set; }
        public List<ContryClass> ContryList { get; set; }
        public List<StateClass> StateList { get; set; }
        // public List<Contry> ContryList { get; set; }
        //public List<State> StateList { get; set; }
    }
    public class EmployeeBAL1
    {
        public int count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string CName { get; set; }
        public string SName { get; set; }
        public int StateID { get; set; }
        public int ContryID { get; set; }
        public int Editmode { get; set; }
    }
    public class Contry
    {
        public int ContryId { get; set; }
        public String ContryName { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
    public class listemnp
    {
        public int count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string State { get; set; }
        public string Contry { get; set; }
        public int StateID { get; set; }
        public int ContryID { get; set; }
        public int Editmode { get; set; }
    }
    public class ContryClass
    {
        public int ContryID { get; set; }
        public String ContryName { get; set; }
    }
    public class StateClass
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
