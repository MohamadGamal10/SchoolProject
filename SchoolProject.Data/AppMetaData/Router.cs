using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string perfix = rule + "Student";
            public const string getAll = perfix + "/GetAll";
            public const string getById = perfix + "/GetById/{id}";
            public const string create = perfix + "/Create";
        }
    }
}
