using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Windows;

namespace Editable_GridView1.Models
{
    public class Employeeupdate
    {
        Database1Entities emp = new Database1Entities();
        public List<Employee> Employee()
        {
            return emp.Employees.ToList();
        }
        public bool SaveEmployee(int Id, string Name, int Age, int Departement, float Salary)
        {
            var employee = (from tb in emp.Employees
                            where tb.Id == Id
                            select tb).FirstOrDefault();
            employee.Name = Name;
            employee.Age = Age;
            employee.Departement = Departement;
            employee.Salary = Salary;
            //Employee e = new Employee();
            //e.Name = Name;
            //e.Age = Age;
            //e.Departement = Departement;
            //e.Salary = Salary;
            ////emp.Employees.Add(e);
            emp.SaveChanges();
            return true;
        }
        public bool AddEmployee(string Name, int Age, int Departement, float Salary)
        {
            
                Employee e = new Employee();
                e.Name = Name;
                e.Age = Age;
                e.Departement = Departement;
                e.Salary = Salary;
                emp.Employees.Add(e);
                emp.SaveChanges();
                return true;
           
        }
        public bool DeleteEmployee(int id)
        {
            var empl = (from Emp in emp.Employees
                        where Emp.Id == id
                        select Emp).FirstOrDefault();
            emp.Employees.Remove(empl);
            emp.SaveChanges();
            return true;

        }
        public IEnumerable<Employee> Search(int Id, string Name, int Age, int Departement, float Salary)
        {
                
          //IEnumerable<Employee> key = null;
          //    key = from content in emp.Employees
          //          where  content.Id == Id && content.Name == Name && content.Age == Age &&content.Departement == Departement && content.Salary == Salary||
          //          content.Name == Name && content.Age == Age && content.Departement == Departement ||
          //          content.Name == Name && content.Age == Age && content.Salary == Salary ||
          //          content.Name == Name && content.Departement == Departement && content.Salary == Salary||
          //          content.Age == Age && content.Departement == Departement && content.Salary == Salary ||
          //          content.Id == Id && content.Name == Name && content.Age == Age||
          //          content.Id == Id && content.Departement == Departement && content.Salary == Salary||
          //          content.Id == Id && content.Name == Name&&content.Departement == Departement||
          //          content.Id == Id && content.Name == Name && content.Salary == Salary||
          //          content.Id == Id && content.Age == Age && content.Departement == Departement||
          //          content.Id == Id && content.Age == Age && content.Salary == Salary ||
          //          content.Id == Id&&content.Name == Name||
          //          content.Id == Id && content.Age == Age||
          //          content.Id == Id && content.Departement == Departement||
          //          content.Id == Id && content.Salary == Salary||
          //          content.Name == Name && content.Age == Age||
          //          content.Name == Name && content.Departement == Departement||
          //          content.Name == Name && content.Salary == Salary||
          //          content.Age == Age && content.Departement == Departement||
          //          content.Age == Age && content.Salary == Salary||
          //          content.Departement == Departement && content.Salary == Salary||
          //          content.Id == Id || content.Name == Name || content.Age == Age || content.Departement == Departement || content.Salary == Salary
          //          select content;
          //    return key;
              var query = emp.Employees.AsQueryable();
            if(!String.IsNullOrEmpty(Name))
            {
              query =   query.Where(e => e.Name == Name);
            }
            if (Age > 0)
            {
                query = query.Where(e => e.Age == Age);
            }
            if (Departement > 0)
            {
                query = query.Where(e => e.Departement == Departement);
            }

          return  query.ToList();
          }






    }
}