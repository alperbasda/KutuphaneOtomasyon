﻿using System;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.WebUI.Helpers
{
    public static class QueryStringHelper
    {
        public static T QueryByName<T>(string query)
            where T : class, IPostModel, new()
        {
            if (string.IsNullOrEmpty(query)) return null;
            T model = new T();
            var list = query.Split('&');
            foreach (var item in list)
            {
                var prop = item.Split('=');
                if (prop.Length > 1 && prop[1].Length > 0)
                {
                    var type = typeof(T).GetProperty(prop[0]);
                    if (type != null)
                        type.SetValue(model, Convert.ChangeType(prop[1], type.PropertyType));
                }
            }
            return model;
        }
    }
}