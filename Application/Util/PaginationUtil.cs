using Application.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Util
{
    public static  class PaginationUtil<T>
    {
        public static Pagination<T> ToPagination(List<T> list, int pageIndex, int pageSize)
        {
            var itemCount =  list.Count();
            var items =  list.Skip(pageIndex*pageSize)
                             .Take(pageSize);
            var result = new Pagination<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalItemsCount = itemCount,
                Items = items.ToList(),
            };
            return result;
        }
    }
}
