﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.Domain.Seedwork
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();

        void BeginTransaction();
        Task BeginTransactionAsync();
    }
}
