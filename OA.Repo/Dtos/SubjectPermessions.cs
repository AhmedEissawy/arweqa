using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Dtos
{

    public class Naming
    {
        public Naming(string name, string displayName)
        {
            Name = name; DisplayName = displayName;

        }
        public string Name { get; set; }
        public string DisplayName { get; set; }



    }
    public class Permessions
    {
        public Permessions(string permession,string displayName)
        {
            Permession = permession;
            DisplayName = displayName;
        }

        public string Permession { get; set; }
        public string DisplayName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class PermessionsModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<Permessions> Permessions { get; set; }
    }
    public class SubjectPermessions
    {
        public const string Permission = "Permession";

        public const string Add = "Add";
        public const string Update = "Update";
        public const string Delete = "Delete";

        public const string AddA = "إضافة";
        public const string UpdatA = "تعديل";
        public const string DeleteA = "حذف";

        public static List<PermessionsModel> GetPermessions() 
        {
            return new List<PermessionsModel>()
        {
           new PermessionsModel {Name="Units",DisplayName="الوحدات",Permessions= new List<Permessions>
           { new Permessions($"Units.{Permission}.{Add}",AddA),new Permessions($"Units.{Permission}.{Update}",UpdatA),new Permessions($"Units.{Permission}.{Delete}",DeleteA) } },

                      new PermessionsModel {Name="Lessons",DisplayName="الدروس",Permessions= new List<Permessions>
           { new Permessions($"Lessons.{Permission}.{Add}",AddA),new Permessions($"Lessons.{Permission}.{Update}",UpdatA),new Permessions($"Lessons.{Permission}.{Delete}",DeleteA) } },

                                 new PermessionsModel {Name="Questions",DisplayName="الأسئلة",Permessions= new List<Permessions>
           { new Permessions($"Questions.{Permission}.{Add}",AddA),new Permessions($"Questions.{Permission}.{Update}",UpdatA),new Permessions($"Questions.{Permission}.{Delete}",DeleteA) } },

        };
        }
        public static List<PermessionsModel> modulesPermessions = new List<PermessionsModel>()
        {
           new PermessionsModel {Name="Units",DisplayName="الوحدات",Permessions= new List<Permessions> 
           { new Permessions($"Units.{Permission}.{Add}",AddA),new Permessions($"Units.{Permission}.{Update}",UpdatA),new Permessions($"Units.{Permission}.{Delete}",DeleteA) } },

                      new PermessionsModel {Name="Lessons",DisplayName="الدروس",Permessions= new List<Permessions>
           { new Permessions($"Lessons.{Permission}.{Add}",AddA),new Permessions($"Lessons.{Permission}.{Update}",UpdatA),new Permessions($"Lessons.{Permission}.{Delete}",DeleteA) } },

                                 new PermessionsModel {Name="Questions",DisplayName="الأسئلة",Permessions= new List<Permessions>
           { new Permessions($"Questions.{Permission}.{Add}",AddA),new Permessions($"Questions.{Permission}.{Update}",UpdatA),new Permessions($"Questions.{Permission}.{Delete}",DeleteA) } },

        };
    }
}


