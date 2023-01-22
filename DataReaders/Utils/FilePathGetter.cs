using System.Reflection;

namespace DataReaders.Utils;

public static class FilePathGetter
{
    public static string GetPath(string fileName)
    {
        var executablePath = Assembly.GetExecutingAssembly().GetName().CodeBase;

        var path = Path.GetDirectoryName(executablePath);

        path = path!.Remove(0, 6);

        return $"{path}/{fileName}";
    }
}