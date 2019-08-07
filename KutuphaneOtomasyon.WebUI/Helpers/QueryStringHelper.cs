using System;
using System.Globalization;
using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.WebUI.Helpers
{
    public static class QueryStringHelper
    {
        public static T QueryByName<T>(string query)
            where T : class, IPostModel, new()
        {
            T model = new T();
            if (string.IsNullOrEmpty(query)) return model;

            var list = query.Split('&');
            foreach (var item in list)
            {
                var prop = item.Split('=');
                if (prop.Length > 1 && prop[1].Length > 0)
                {
                    var type = typeof(T).GetProperty(prop[0]);
                    if (type != null)
                    {
                        if (type.PropertyType.IsEnum)
                            type.SetValue(model, Convert.ToInt32(prop[1]));
                        else if (type.PropertyType == typeof(DateTime?))
                        {
                            
                            type.SetValue(model, DateTime.ParseExact(prop[1], "yyyy-MM-dd", CultureInfo.InvariantCulture));
                        }
                        else
                            type.SetValue(model, Convert.ChangeType(prop[1], type.PropertyType));
                    }


                }
            }
            return model;
        }
    }
}