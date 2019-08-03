using System;
namespace KutuphaneOtomasyon.Entities.BaseType
{
    public class Log 
    {
        public int Id { get; set; }

        public string Detail { get; set; }

        public string Audit { get; set; }

        public DateTime Date { get; set; }
    }
}