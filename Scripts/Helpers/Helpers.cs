using EFZ.Scripts.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFZ.Scripts;

public class Helpers
{
    public static List<Type> GetType<T>() where T : class
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        var relevantAssemblies = assemblies.Where(asm => asm.FullName.StartsWith("EFZ"));

        var subclasses = new List<Type>();
        foreach (var assembly in relevantAssemblies)
        {

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                // 检查类型是否继承自T，且不是抽象类，且不是T本身
                if (type.IsSubclassOf(typeof(T)) && !type.IsAbstract)
                {
                    subclasses.Add(type);
                }
            }
        }

        return subclasses;
    }
}
