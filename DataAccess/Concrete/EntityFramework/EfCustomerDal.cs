﻿using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapContext>,ICustomerDal
    {

    }
}
