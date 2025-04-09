using C4WX1.Tests.SysConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.Shared
{
    public class C4WX1State : StateFixture
    {
        public int CreateCount { get; } = SysConfigFaker.CreateCount();

        public List<int> InsertedIds { get; set; } = [];
    }
}
