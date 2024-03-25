using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
    }
}

