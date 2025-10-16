using DependencyLib;
using System.Reflection;
using WebAPI_internship.Services.Interfaces;

namespace WebAPI_internship.Services
{
    public class PluginRegisterService : IPluginRegisterService
    {
        public void RegisterService(string path)
        {
            path = path.Replace("\"", "");
            var assembly = Assembly.LoadFrom(path);

            var type = typeof(NodeOperation);
            var types = assembly.GetTypes().Where(t => type.IsAssignableFrom(t));

            foreach( var t in types) 
                Store.NodeTypeMap.Add(t.Name, t);
        }
    }
}
