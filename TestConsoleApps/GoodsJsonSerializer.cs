using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace TestConsoleApps
{
    internal class GoodsJsonSerializer : GoodsSerializer
    {
        public override void Serialize(Stream stream, List<Goods> goods)
        {
            JsonSerializer.Serialize(stream,goods);
        }

        public override List<Goods> Deserialize(Stream stream)
        {
            return JsonSerializer.Deserialize<List<Goods>>(stream)
             ?? throw new InvalidOperationException("Не удалось получить объект класса Список товаров");
        }

    }
}
