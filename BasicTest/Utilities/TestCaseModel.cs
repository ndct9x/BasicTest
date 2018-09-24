using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTest
{
    public class TestCaseModel
    {
        public string ElementCode { get; set; }

        public string Value { get; set; }

        public GetBy? GetBy { get; set; }

        public Action? Action { get; set; }

        public Expected? Expected { get; set; }
        public string Message { get; set; }
    }
}
