﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EvrySmartbike2Service.Models;

namespace EvrySmartbike2Service.Controllers
{
    public class TestTableController : ApiController
    {
        private EvrySmartbike2ServiceContext db = new EvrySmartbike2ServiceContext();

        // GET: api/TestTable
        public IQueryable<TestTable> GetSensordata()
        {
            return db.Testdata;
        

        }
    }
}