using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTest
{
    public static class Constants
    {
        public static class UnexpectedMessage
        {
            public const string NotDisplay = "Element code: {0}, get by: {1} must invisible";
            public const string StillDisplay = "Element code: {0}, get by: {1} must visible";
            public const string CantSelect = "Element code: {0}, get by: {1} can\'t select value {2}";
            public const string CantFindElement = "Element code: {0}, get by: {1} is not exist";
        }
    }
}
