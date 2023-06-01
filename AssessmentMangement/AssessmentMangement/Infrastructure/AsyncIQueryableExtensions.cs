using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using AssessmentMangement.Repository;

namespace AssessmentMangement.Infrastructure
{
    public static class AsyncIQueryableExtensions
    {

        /// <summary>
        /// ToPaged List Async
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records. Set to "true" if you don't want to load data from database</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public static IPagedList<T> ToPagedList<T>(this List<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            if (source == null)
                return new PagedList<T>(new List<T>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = source.Count();

            var data = new List<T>();

            if (!getOnlyTotalCount)
            {
                //data = await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
                data.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
            }
            return new PagedList<T>(data, pageIndex, pageSize, count);
        }

        /// <summary>
        /// ToPaged List Async
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records. Set to "true" if you don't want to load data from database</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            if (source == null)
                return new PagedList<T>(new List<T>(), pageIndex, pageSize);

            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            var count = await source.CountAsync();

            var data = new List<T>();

            if (!getOnlyTotalCount)
            {
                //data = await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
                data.AddRange(await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());
            }
            return new PagedList<T>(data, pageIndex, pageSize, count);
        }
        /// <summary>
        /// Add Sort Functionality
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string orderby)
        {
            if (!source.Any())
                return source;
            if (string.IsNullOrWhiteSpace(orderby))
            {
                return source;
                //orderby = "CreateDate desc";
            }
            var orderParams = orderby.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                if (propertyInfos.Length > 0 && (propertyInfos[0].Name == "MasterEntity"))
                {

                    Type masterEntityType = Type.GetType(propertyInfos[0].PropertyType.FullName);
                    Object masterEntity = Activator.CreateInstance(masterEntityType);
                    var masterEntityInfos = masterEntity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var masterEntityProperty = masterEntityInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                    if (masterEntityProperty != null)
                    {
                        var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                        orderQueryBuilder.Append($"MasterEntity.{masterEntityProperty.Name} {sortingOrder}, ");
                        continue;
                    }

                    Type entityType = Type.GetType(propertyInfos[1].PropertyType.FullName);
                    Object entity = Activator.CreateInstance(entityType);
                    var entityInfos = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var entityProperty = entityInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                    if (entityProperty != null)
                    {
                        var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                        orderQueryBuilder.Append($"Entity.{entityProperty.Name} {sortingOrder}, ");
                        continue;
                    }

                }
                else
                {
                    var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                    if (objectProperty == null)
                        continue;
                    var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                    orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
                }


            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (String.IsNullOrEmpty(orderQuery))
                return source;
            return source.OrderBy(orderQuery);
        }
    }
}

