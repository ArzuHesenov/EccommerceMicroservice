using CorePackage.DataAccess.MongoDB.MongoSettings;
using CorePackage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Entities.Concrete
{
    [BsonCollection("featurevalues")]
    public class FeatureValue : IEntity
    {
        public string Value { get; set; } 
    }
}
