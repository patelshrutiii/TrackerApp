using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTracker_ProjectDLL.Models;

namespace WebTracker_ProjectBLL
{
    public class DesignationBLL
    {
        public Designation Create(Designation _Designation, int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    _Designation.CompanyId = companyId;
                    _Designation.IsActive = true;
                    _Designation.EntryUser = companyId;
                    _Designation.EntryDate = DateTime.Now;
                    _Designation.IsDeleted = false;

                    var Dupdes = (from des in db.Designations where des.CompanyId == companyId && des.IsDeleted == false && des.DesignationName.Equals(_Designation.DesignationName) select des.DesignationId).ToList();
                    if (Dupdes.Count > 0)
                    {
                        throw new Exception("This Designation is already exist");
                    }
                    else
                    {
                        db.Designations.Add(_Designation);
                        db.SaveChanges();
                        return _Designation;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }     
 
        public Designation Update(Designation _Designation, int companyId)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                _Designation.CompanyId = companyId;
                _Designation.ModifiedUser = companyId;
                _Designation.ModifiedDate = DateTime.Now;
                _Designation.IsDeleted = false;
                db.Designations.Attach(_Designation);
                db.Entry(_Designation).State = EntityState.Modified;
                db.SaveChanges();
                return _Designation;
            }
        }

        public void Delete(int did)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                Designation des = db.Designations.Where(x => x.DesignationId == did).FirstOrDefault();
                if (des != null)
                {
                    des.IsDeleted = true;
                    db.Designations.Attach(des);
                    db.Entry(des).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public void Trash(int did)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                Designation des = db.Designations.Where(x => x.DesignationId == did).FirstOrDefault();
                if (des != null)
                {
                    db.Designations.Remove(des);
                    db.SaveChanges();
                }
            }
        }

        public void Restore(int did)
        {
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                Designation des = db.Designations.Where(x => x.DesignationId == did).FirstOrDefault();
                if (des != null)
                {
                    des.IsDeleted = false;
                    db.Designations.Attach(des);
                    db.Entry(des).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public List<Designation> GetDesList(int companyId)
        {
            List<Designation> des = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    des = db.Designations.Where(x => x.CompanyId == companyId && x.IsDeleted == false).ToList();
                }
                catch
                {
                    des = null;
                }
            }
            return des;
        }

        public List<Designation> ArchieveDesList(int companyId)
        {
            List<Designation> des = null;
            using (TrackerAppEntities db = new TrackerAppEntities())
            {
                try
                {
                    des = db.Designations.Where(x => x.CompanyId == companyId && x.IsDeleted == true).ToList();
                }
                catch
                {
                    des = null;
                }
            }
            return des;
        }
     
    }
}
