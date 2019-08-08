using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KutuphaneOtomasyon.Core.Entity.Abstract;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.WebUI.Helpers
{
    public static class FormCreator
    {
        public static void FillForm<T>(HtmlForm form, T nesne)
            where T :  EditModel, new()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                var control = form.FindControl(prop.Name);
                if (control is TextBox)
                    ((TextBox) control).Text = prop.GetValue(nesne) !=null ? prop.GetValue(nesne).ToString():"";
                if (control is DropDownList)
                    ((DropDownList)control).SelectedValue = prop.GetValue(nesne).ToString();
                if (control is Label)
                    ((Label)control).Text = prop.GetValue(nesne).ToString();
            }
        }
      
    }
}