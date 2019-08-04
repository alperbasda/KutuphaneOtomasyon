using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.WebUI.Helpers
{
    public static class ObjectCreator
    {
        private static object _locker;

        public static T Create<T>(HtmlForm form)
        where T : class, IPostModel, new()
        {
            CreateLocker();
            T model = new T();
            lock (_locker)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (form.FindControl(prop.Name) is TextBox control)
                        prop.SetValue(model, Convert.ChangeType(control.Text, prop.PropertyType));
                }
            }
            return model;
        }

        private static void CreateLocker()
        {
            if (_locker == null)
            {
                _locker = new object();
            }
        }

    }
}