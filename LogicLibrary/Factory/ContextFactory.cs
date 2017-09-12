using LogicLibrary.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Factory
{
    public static class ContextFactory
    {
        public enum ContextType
        {
            Student,
            Professor,
            Registar
        }

        public static UserContext GetContext(ContextType _type, string _username, string _pass)
        {
            UserContext result = null;

            var ef = Database.Instance;

            switch(_type)
            {
                case ContextType.Student:
                    var stu = ef.GetStudent(_username, _pass);
                    if (stu != null)
                        result = new StudentContext(stu, _username, _pass);
                    break;
                case ContextType.Professor:
                    var pro = ef.GetProfessor(_username, _pass);
                    if (pro != null)
                        result = new ProfessorContext(pro, _username, _pass);
                    break;
                case ContextType.Registar:
                    var reg = ef.GetRegistar(_username, _pass);
                    if (reg != null)
                        result = new RegistarContext(reg, _username, _pass);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
