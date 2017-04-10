using AstAppSharedEntities.DTOs;
using AstAppSharedEntities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstAppWebApi.Models
{
    public class PoolsViewModel
    {
        public List<PoolDTO> UserPools { get; set; }
        public List<PoolDTO> AvailablePools { get; set; }
    }
}