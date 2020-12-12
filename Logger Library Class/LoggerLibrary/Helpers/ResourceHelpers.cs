using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace LoggerLibrary.Helpers
{
    internal static class ResourceHelpers
    {
        /// <summary>
        /// Load Help Method Text
        /// </summary>
        /// <returns></returns>
        internal static async Task<string> LoadHelpText()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resource = "HelpResource.txt";
            using (Stream stream = assembly.GetManifestResourceStream(resource))
            { 
                using (StreamReader sr = new StreamReader(stream))
                {
                    string output = await sr.ReadToEndAsync();
                    return output;
                }
            }
        }
    }
}
