using CorePackage.DataAccess.MongoDB.MongoSettings;
using CorePackage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Entities.Concrete
{
    [BsonCollection("features")]
    public class Feature : IEntity
    {
        public string FeatureKey { get; set; }
        public List<FeatureValue> FeatureValues { get; set; }
    }
}
