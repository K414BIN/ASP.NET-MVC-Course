using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApps
{
    public abstract class GoodsSerializer : IGoodsSerializer
    {
  

        public static  GoodsSerializer JSon() => new GoodsJsonSerializer();
        
        public abstract List<Goods> Deserialize(Stream stream);
        

        public abstract void Serialize(Stream stream, List<Goods> goods);

        public static GoodsSerializer Create()
        {
            return new GoodsJsonSerializer();
        }

    }
}
