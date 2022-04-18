
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Windows;
using TestConsoleApps;


namespace TestConsoleApps
{
    

    internal class Program
    {

        static void Main(string[] args )
        {
            const string goodsFileName = "ShopingCart.txt";
            var goods_manager = new GoodsManager(GoodsSerializer.JSon());
            /* Сначала надо раскомментировать эти строки кода */
            /* Создать файл а потом запустить загрузку файла Json */

            //DateTime dateTime =  DateTime.Today.AddDays(-12);
            //goods_manager.Add("Молоко", dateTime);
            //dateTime = DateTime.Today.AddDays(-14);
            //goods_manager.Add("Масло", dateTime);
            //dateTime = DateTime.Today.AddDays(-7);
            //goods_manager.Add("Сметана", dateTime);

            // goods_manager.SaveTo(goodsFileName);

            goods_manager.LoadFrom(goodsFileName);


            goods_manager.Show();

              Console.ReadLine(); 

        }
    }
}
