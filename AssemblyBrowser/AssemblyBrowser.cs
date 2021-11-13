using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using AssemblyBrowser.Containers;
using AssemblyBrowser.Formatter;

namespace AssemblyBrowser
{
    class AssemblyBrowser
    {
        public List<Container> GetAssemblyInfo(string filePath)
        {

            string extension = Path.GetExtension(filePath);
            if (!extension.Equals(".dll") && !extension.Equals(".exe"))
            {
                throw new FileIsNotAssemblyException("Passed filepath is not assembly");
            }
            return null;
        }
    }
}
