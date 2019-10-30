using System.Collections.Generic;

namespace Cvtex.Core.Domain
{
    public class UploadFile
    {
        public List<string> Files { get; protected set; }
        public string Name { get; protected set; }
        public int MyProperty { get; protected set; }
    }
}