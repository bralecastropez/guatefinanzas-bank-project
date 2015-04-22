using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Project_GuateFinanzas.Helpers
{
    public class EnumHelper<T>
    {
        public IEnumerable<SelectListItem> GetEnumValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(s => new SelectListItem {
                Text = s.ToString(),
                Value = Convert.ToInt32(s).ToString()
            });
        }

        public int GetIDByName(string name)
        {
            var count = 0;
            var thisEnum = Enum.GetValues(typeof(T));

            foreach(var item in thisEnum)
            {
                if(item == name)
                {
                    return count;
                }
                    count++;
            }
            return 0;
        }
    }
}