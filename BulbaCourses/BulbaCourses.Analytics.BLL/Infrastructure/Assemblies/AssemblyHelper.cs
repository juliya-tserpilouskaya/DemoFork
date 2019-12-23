using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BulbaCourses.Analytics.BLL.Infrastructure.Assemblies
{
    /// <summary>
    /// Provides the ability to work with assemblies.
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Getts loaded assemblies by the first words in the name.
        /// </summary>
        /// <param name="firstWordAssembly"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> LoadedAssemblies(string firstWordAssembly)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var asm = assemblies.Where(a => a.GetName().FullName.StartsWith(firstWordAssembly));

            if (asm.FirstOrDefault() == null)
            {
                return null;
            }

            return asm;
        }        

        /// <summary>
        /// Creates instance from T object type with  params constructor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(Type type, params object[] args)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            var instance = (T)Activator.CreateInstance(type, args);

            return instance;
        }        

        /// <summary>
        /// Creates instance from T object with  params constructor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(params object[] args) 
        {            
            var instance = (T)Activator.CreateInstance(typeof(T), args);
            return instance;
        }

        /// <summary>
        /// Creates instance from T object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstance<T>()
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            return instance;
        }

        /// <summary>
        /// Getts instanced objects from assemblies.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstancedObjectsFromAssemblies<T>(IEnumerable<Assembly> assemblies)
        {
            IEnumerable<T> instancedObjects = new List<T>();

            foreach (var assembly in assemblies)
            {
                instancedObjects = instancedObjects.Concat(assembly
                    .GetTypes()
                    .Where(t => typeof(T).IsAssignableFrom(t))
                    .Select(t => CreateInstance<T>(t)));
            }

            if (instancedObjects.FirstOrDefault() == null)
            {
                return null;
            }

            return instancedObjects;
        }

        /// <summary>
        /// Getts instanced objects from assemblies by the first words in the assembly name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstancedObjects<T>(string str)
        {
            var asm = LoadedAssemblies(str);

            if (asm == null)
            {
                return null;
            }

            var instancedObjects = GetInstancedObjectsFromAssemblies<T>(asm);
            return instancedObjects;
        }
    }
}
