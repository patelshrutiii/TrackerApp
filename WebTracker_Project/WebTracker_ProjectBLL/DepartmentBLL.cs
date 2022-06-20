using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class DepartmentBLL
    {
        public Department Create(Department _Department,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    _Department.CompanyId = companyId;
                    _Department.IsActive = true;
                    _Department.EntryUser = companyId;
                    _Department.EntryDate = DateTime.Now;
                    _Department.IsDeleted = false;

                    var Dupdept = (from dept in db.Departments where dept.CompanyId == companyId && dept.IsDeleted == false && dept.DepartmentName.Equals(_Department.DepartmentName) select dept.DepartmentId).ToList();
                    if (Dupdept.Count > 0)
                    {
                        throw new Exception("This Department is already exist");
                    }
                    else
                    {
                        db.Departments.Add(_Department);
                        db.SaveChanges();
                        return _Department;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }                       
        }

        public Department Update(Department _Department,int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                _Department.CompanyId = companyId;
                _Department.ModifiedUser = companyId;
                _Department.ModifiedDate = DateTime.Now;
                _Department.IsDeleted = false;
                db.Departments.Attach(_Department);
                db.Entry(_Department).State = EntityState.Modified;
                db.SaveChanges();
                return _Department;
            }
        }

        public void Delete(int did)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                Department dept = db.Departments.Where(x => x.DepartmentId == did).FirstOrDefault();
                if (dept != null)
                {
                    dept.IsDeleted = true;
                    db.Departments.Attach(dept);
                    db.Entry(dept).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void Trash(int did)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                Department dept = db.Departments.Where(x => x.DepartmentId == did).FirstOrDefault();
                if (dept != null)
                {
                    db.Departments.Remove(dept);
                    db.SaveChanges();
                }
            }
        }

        public void Restore(int did)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                Department dept = db.Departments.Where(x => x.DepartmentId == did).FirstOrDefault();
                if (dept != null)
                {
                    dept.IsDeleted = false;
                    db.Departments.Attach(dept);
                    db.Entry(dept).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public List<Department> GetDeptList(int companyId)
        {
            List<Department> depts = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    depts = db.Departments.Where(x => x.CompanyId == companyId && x.IsDeleted == false).ToList();
                }
                catch
                {
                    depts = null;
                }
            }
            return depts;
        }

        public List<Department> ArchieveDeptList(int companyId)
        {
            List<Department> depts = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    depts = db.Departments.Where(x => x.CompanyId == companyId && x.IsDeleted == true).ToList();
                }
                catch
                {
                    depts = null;
                }
            }
            return depts;
        }

    }
}
