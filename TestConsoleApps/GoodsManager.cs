using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApps
{
    public class GoodsManager
    {
        private readonly IGoodsSerializer _Serializer;
        private int _LastFreeId = 1;
        private List<Goods> _Goods = new List<Goods>();
        public GoodsManager (IGoodsSerializer Serializer)
        {
            _Serializer = Serializer;
        }
        public Goods Add(string Name, DateTime BestBefore)
        {
            Goods goods = new Goods
            {
                Name = Name, 
                BestBefore = BestBefore,
                Id= _LastFreeId++,
            };
           
        
        _Goods.Add(goods);
            return goods;
        }


        public void Show()
        {
            foreach (Goods good in _Goods)
            {
                Console.Write(good.Id.ToString());
                Console.Write("  ");
                Console.Write(good.Name);
                Console.Write("  ");
                Console.WriteLine(good.BestBefore.ToString("yyyy-dd-MM"));
            }
        }

        public FileInfo SaveTo(string FilePath)
          {
        var file = new FileInfo(FilePath);

        using (var JSon = file.Create())
            _Serializer.Serialize(JSon, _Goods);

        return file;
          }

         public void LoadFrom(string FilePath)
         {
                
            try
            {
                FileStream JSon = File.OpenRead(FilePath);
                _Goods = _Serializer.Deserialize(JSon);
            }
            catch (System.IO.FileNotFoundException)
            {
               //throw new System.IO.FileNotFoundException(FilePath);
               //Решил ничего не делать, если такого файла нет
               return;
            }  
          
          
          if (_Goods.Count == 0) return;

         _LastFreeId = _Goods.Max(item => item.Id) + 1;
         }
}
     }
