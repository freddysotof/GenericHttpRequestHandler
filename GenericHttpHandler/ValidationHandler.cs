using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHttpHandler
{
    public class ValidationHandler<T>
    {
        public bool IsValid { get; set; }
        public ErrorHandler Error { get; set; }
        public T Object { get; set; }

    }
}
