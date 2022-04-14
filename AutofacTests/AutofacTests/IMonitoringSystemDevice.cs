using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTests
{
    public interface IMonitoringSystemDevice
    {
        // A где прописывать метод GetMonitorData ?
        IEnumerator<IMonitorData> GetMonitorData();

    }
}
