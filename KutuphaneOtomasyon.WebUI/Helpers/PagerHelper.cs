
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyon.WebUI.Helpers
{
    public static class PagerHelper
    {
        private static string SayfaOkSol = "<i class='la la-angle-left'></i>";
        private static string SayfaOkSag = "<i class='la la-angle-right'></i>";
        public static string Paging(int toplamSayfa, NameValueCollection queryCollection)
        {
            string turnQuery = ToQueryString(queryCollection);
            string hasLeft = "";
            string hasRight = "";
            string parseOperator = queryCollection.Count <= 0 || (queryCollection.Count == 1 && queryCollection.Keys[0] == "Sayfa") ? "" : "&";
            List<string> hrefList = new List<string>();
            int querySayfa = 1;
            if (queryCollection["Sayfa"] != null)
                querySayfa = Convert.ToInt32(queryCollection["Sayfa"]);
            if (querySayfa <= 1)
            {
                hasLeft = "disabled";
                hrefList.Add("#");
                hrefList.Add("#");
            }
            else
            {
                hrefList.Add($"{turnQuery}{parseOperator}Sayfa=1");
                hrefList.Add($"{turnQuery}{parseOperator}Sayfa={querySayfa - 1}");
            }


            if (querySayfa >= toplamSayfa)
            {
                hasRight = "disabled";
                hrefList.Add("#");
                hrefList.Add("#");
            }
            else
            {
                hrefList.Add($"{turnQuery}{parseOperator}Sayfa={querySayfa + 1}");
                hrefList.Add($"{turnQuery}{parseOperator}Sayfa={toplamSayfa}");
            }



            return string.Format("<li class='page-item previous {3}'><a href='{5}' class='page-link'>{0}{0}</a></li>" +
                                 "<li class='page-item previous {3}'><a href='{6}' class='page-link'>{0}</a></li>" +
                                 "<li class='page-item disabled'><a href='#' class='page-link'>{1}</a></li>" +
                                 "<li class='page-item next {4}'><a href='{7}' class='page-link'>{2}</a></li>" +
                                 "<li class='page-item next {4}'><a href='{8}' class='page-link'>{2}{2}</a></li>", SayfaOkSol, querySayfa, SayfaOkSag, hasLeft, hasRight, hrefList[0], hrefList[1], hrefList[2], hrefList[3]);
        }



        private static string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         where key != "Sayfa"
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }

    }
}