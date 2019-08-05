using System;
using System.Web.UI;
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
                    if (form.FindControl(prop.Name) is TextBox controlTb)
                        prop.SetValue(model, Convert.ChangeType(controlTb.Text.Trim(), prop.PropertyType));
                    else if (form.FindControl(prop.Name) is DropDownList controlDBox)
                        prop.SetValue(model, Convert.ChangeType(controlDBox.SelectedValue.Trim(), prop.PropertyType));
                    else if (form.FindControl(prop.Name) is UserControl controlUser)
                        UserControlProperty(model,controlUser);
                }
            }
            return model;
        }
        private static void UserControlProperty<T>(T model, UserControl control)
            where T : class, IPostModel, new()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (control.FindControl(prop.Name) is TextBox controlTb)
                {
                    prop.SetValue(model, Convert.ChangeType(controlTb.Text.Trim(), prop.PropertyType));
                    break;
                }
                if (control.FindControl(prop.Name) is DropDownList controlDBox)
                {
                    prop.SetValue(model, Convert.ChangeType(controlDBox.SelectedValue.Trim(), prop.PropertyType));
                    break;
                }

                if (control.FindControl(prop.Name) is UserControl controlUser)
                {
                    UserControlProperty(model, controlUser);
                    break;
                }
            }
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