using System.Linq;
using System.Reflection;
using Dapper;
using Template.Repositories.Mappers;
using Template.Entities.DbModels.Base;

namespace Template.Repositories.Helpers
{
    public static class MapperHelper
    {
        public static void MapAllEntities()
        {
            var entityTypes = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(BaseEntity))).ToList();
            foreach (var type in entityTypes)
                SqlMapper.SetTypeMap(type, new ColumnAttributeTypeMapper(type));
        }
    }
}