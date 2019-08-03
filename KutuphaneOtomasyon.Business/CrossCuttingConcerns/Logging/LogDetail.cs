using System.Collections.Generic;

namespace KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }

        public string MethodName { get; set; }

        public List<LogParameter> Parameters { get; set; }
    }
}