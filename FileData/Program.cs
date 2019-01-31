using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (!ValidateArguments(args))
            {
                Console.WriteLine("Error: Invalid Arguments");
                return;
            }
            var checkType = args[0].ToLower().EndsWith("v") == true
                 ? CheckType.version
                 : CheckType.size;
            Console.WriteLine(ProcessFile(checkType, args[1]));
        }

        public static string ProcessFile(CheckType checkType, string path)
        {
            var fileDetails = new FileDetails();
            return checkType == CheckType.version
                ? $"File Version: {fileDetails.Version(path)}"
                : $"File Size: {fileDetails.Size(path)}";
        }
        public static bool ValidateArguments(string[] args)
        {
            return ((args.Length == 2)
                && ((args[0].ToLower().EndsWith("v")) || (args[0].ToLower().EndsWith("s")))
                && (!string.IsNullOrEmpty(args[1])));
        }
    }
}
