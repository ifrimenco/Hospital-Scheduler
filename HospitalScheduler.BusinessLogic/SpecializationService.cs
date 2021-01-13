using HospitalScheduler.DataAccess;
using HospitalScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalScheduler.BusinessLogic
{
    public class SpecializationService : BaseService
    {
        public SpecializationService(UnitOfWork unitOfWork)
           : base(unitOfWork)
        {
        }
        public IEnumerable<Specialization> GetAll()
        {
            return UnitOfWork.Specializations.Get().ToList();
        }

        public Specialization GetByName(string name)
        {
            return UnitOfWork.Specializations.Get().Where(s => s.Name == name).FirstOrDefault(); 
        }

        public bool Add(Specialization specialization)
        {   
            if (UnitOfWork.Specializations.Get().Where(s => s.Name == specialization.Name).Any())
            {
                return false;
            }
            UnitOfWork.Specializations.Insert(specialization);
            UnitOfWork.SaveChanges();
            return true;
        }

        public void Remove(int id)
        {
            var specialization = UnitOfWork.Specializations.Get().FirstOrDefault(e => e.Id == id);
            UnitOfWork.Specializations.Delete(specialization);
            UnitOfWork.SaveChanges();
        }
    }
}
