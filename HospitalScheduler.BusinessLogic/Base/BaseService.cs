using HospitalScheduler.DataAccess;
using HospitalScheduler.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace HospitalScheduler.BusinessLogic
{
    public class BaseService
    {
        protected readonly UnitOfWork UnitOfWork;
        protected readonly CurrentUserDto CurrentUser;

        public BaseService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected T ExecuteInTransaction<T>(Func<UnitOfWork, T> func)
        {
            using (var transactionScope = new TransactionScope())
            {
                var result = func(UnitOfWork);

                transactionScope.Complete();

                return result;
            }
        }

        protected void ExecuteInTransaction<T>(Action<UnitOfWork> action)
        {
            using (var transactionScope = new TransactionScope())
            {
                action(UnitOfWork);

                transactionScope.Complete();
            }
        }
    }
}
