using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Editable_GridView1.Models;
using PagedList;


namespace Editable_GridView1.Controllers
{
    public class GridViewDisController : Controller
    {  
        //
        // GET: /GridViewDis/
        Employeeupdate eu = new Employeeupdate();
        public ActionResult DisplayGrid(int page =1)
        {
            const int pageSize = 3;
            int totalRecords;
            IQueryable<Employee> employees;
            IEnumerable<Employee>elist;
            using (Database1Entities emp = new Database1Entities())
            {
                employees = emp.Employees;// open the DB and retrive the values 
                totalRecords = employees.Count();
                employees = employees.OrderBy(e=>e.Id).Skip((page-1) * pageSize).Take(pageSize);
                elist=employees.ToList();
            }

            InterfacePaging pagingclass = new InterfacePaging 
            { 
            employees = elist,
            pageNumber = page,
            pageSize = pageSize,
            totalRows = totalRecords,
        
            };
            return View(pagingclass);
        }
        [HttpGet]
        public JsonResult Search(int Id=0, string Name="", int Age=0, int Departement=0, float Salary=0 )
        {
            IEnumerable<Employee> key;
            key=eu.Search(Id, Name, Age,Departement,Salary);
            return Json(key,JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult SaveChanges(int Id, string Name, int Age, int Departement, float Salary)
        {
            bool result = false;
            result = eu.SaveEmployee(Id, Name, Age, Departement, Salary);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddEmployees(string Name, int Age, int Departement, float Salary)
        {
            bool result = false;
            result = eu.AddEmployee(Name, Age, Departement, Salary);
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult DeleteEmployee(int id)
        {
            bool result = false;
            result = eu.DeleteEmployee(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }




    }
}
