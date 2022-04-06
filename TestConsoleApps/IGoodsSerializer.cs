using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace TestConsoleApps
{
    public interface IGoodsSerializer
    {
        void Serialize(Stream stream, List<Goods> goods);
        List<Goods> Deserialize(Stream stream); 
    }
}
