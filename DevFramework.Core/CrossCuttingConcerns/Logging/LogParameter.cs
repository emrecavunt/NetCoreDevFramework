using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }
}
