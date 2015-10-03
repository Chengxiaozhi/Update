using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUpdate.Entity
{
    public class FileENT
    {
        public string FileFullName { get; set; }

        public string Src { get; set; }

        public string Version { get; set; }

        public int Size { get; set; }

        public UpdateOption Option { get; set; }
    }

}
