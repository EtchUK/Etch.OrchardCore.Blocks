using System;

namespace Etch.OrchardCore.Blocks.Utils
{
    public class IndexUtils
    {
        public static string RemoveBlocks(string data)
        {
            foreach (var property in Type.GetType("Etch.OrchardCore.Blocks.EditorJS.Constants").GetFields())
            {
                data = data.Replace($"\"{property.GetRawConstantValue()}\"", string.Empty);
            }

            data = data.Replace("\"data\"", string.Empty);
            data = data.Replace("\"time\"", string.Empty);
            data = data.Replace("\"blocks\"", string.Empty);
            data = data.Replace("\"type\"", string.Empty);
            data = data.Replace("\"version\"", string.Empty);

            return data;
        }
    }
}