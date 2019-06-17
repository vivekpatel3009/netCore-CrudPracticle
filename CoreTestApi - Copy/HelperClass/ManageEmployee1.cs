using CoreAPi.BAL.Model;
using CoreAPi.BAL.Repository;
using CoreTestApi.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTestApi.HelperClass
{
    public class ManageEmployee1 : IManageEmployee, ImanageContryState
    {
        private IConfiguration configuration;
        private TestContext DB;
        public ManageEmployee1(TestContext _DB, IConfiguration _congf)
        {
            DB = _DB;
            configuration = _congf;
        }
        public async Task<string> AddEmployee(EmployeeBAL model)
        {
            try
            {
                if (model.Editmode == 0)
                {
                    Employee em = new Employee();
                    em.Name = model.name;
                    em.ContryId = model.ContryID;
                    em.StateId = model.StateID;
                    em.IsActive = true;
                    DB.Employee.Add(em);
                    await DB.SaveChangesAsync();
                    return "Added";
                }
                else if (model.Editmode == 1)
                {
                    var empdata = DB.Employee.Where(x => x.Id == model.id).FirstOrDefault();
                    if (empdata != null)
                    {
                        empdata.Id = model.id;
                        empdata.Name = model.name;
                        empdata.ContryId = model.ContryID;
                        empdata.StateId = model.StateID;
                        await DB.SaveChangesAsync();
                        return "Updated";
                    }

                }
                else { return "Error"; }
                return "Error";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }
        public async Task<List<EmployeeBAL>> GetEmployee()
        {
            List<EmployeeBAL> Model = new List<EmployeeBAL>();
            var data = await DB.Employee.Where(x => x.IsActive == true).ToListAsync();
            if (data.Count > 0)
            {
                var count = 0;
                foreach (var item in data)
                {
                    EmployeeBAL model = new EmployeeBAL();
                    count++;
                    model.count = count;
                    model.id = item.Id;
                    model.name = item.Name;
                    var Contrydata = Getcontryname((int)item.ContryId);
                    var Statedata = GetState((int)item.StateId);
                    if (Contrydata != null)
                    {
                        model.CName = Contrydata.ContryName;
                    }
                    if (Statedata != null)
                    {
                        model.SName = Statedata.StateName;
                    }
                    Model.Add(model);
                }
            }
            return Model;
        }
        public async Task<EmployeeTest> GetById(int? id)
        {
            EmployeeTest model = new EmployeeTest();
            var data = await DB.Employee.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                model.id = data.Id;
                //model.ContryID = (int)data.ContryId;
                var Contrydata = Getcontryname((int)data.ContryId);//item.ContryID;
                var Statedata = GetState((int)data.StateId);
                if (Contrydata != null)
                {
                    model.CName = Contrydata.ContryName;
                }
                if (Statedata != null)
                {
                    model.SName = Statedata.StateName;
                }
                model.StateID = (int)data.StateId;
                model.ContryID = (int)data.ContryId;
                model.name = data.Name;
                model.statelist = GetStatelstById(model.ContryID);
                model.Contrylist = GetContry();
            }
            return model;
        }
        public async Task<bool> Remove(int? id)
        {
            var empdata = await DB.Employee.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (empdata != null)
            {
                empdata.IsActive = false;
                await DB.SaveChangesAsync();
                return true;
            }
            return false; // delete
        }
        public StateTbl GetState(int sid)
        {
            return DB.StateTbl.Where(x => x.StateId == sid).FirstOrDefault();
        }
        public ContryTbl Getcontryname(int Cid)
        {

            return DB.ContryTbl.Where(x => x.ContryId == Cid).FirstOrDefault();
        }
        public List<Stateclass> GetState()
        {
            List<Stateclass> stlst = new List<Stateclass>();
            List<StateTbl> statelist = DB.StateTbl.ToList();
            foreach (var item in statelist)
            {
                Stateclass st = new Stateclass();
                st.StateId = item.Id;
                st.StateName = item.StateName;
                stlst.Add(st);
            }
            return stlst;
        }
        public List<Stateclass> GetStatelstById(int id)
        {
            List<Stateclass> stlst = new List<Stateclass>();
            List<StateTbl> statelist = DB.StateTbl.ToList();
            foreach (var item in statelist)
            {
                Stateclass st = new Stateclass();
                st.StateId = item.Id;
                st.StateName = item.StateName;
                stlst.Add(st);
            }
            return stlst;
        }
        public List<Contryclass> GetContry()
        {
            List<Contryclass> contlst = new List<Contryclass>();
            List<ContryTbl> ContryLsit = DB.ContryTbl.ToList();
            foreach (var item in ContryLsit)
            {
                Contryclass st = new Contryclass();
                st.ContryId = item.Id;
                st.ContryName = item.ContryName;
                contlst.Add(st);
            }
            return contlst;
        }
        public async Task<List<Stateclass>> GetStateById(int id)
        {
            List<Stateclass> contlst = new List<Stateclass>();
            List<StateTbl> ContryLsit = await DB.StateTbl.Where(x => x.ContryId == id).ToListAsync();
            foreach (var item in ContryLsit)
            {
                Stateclass st = new Stateclass();
                st.StateId = (int)item.StateId;
                st.StateName = item.StateName;
                contlst.Add(st);
            }
            return contlst;
        }
    }
}
