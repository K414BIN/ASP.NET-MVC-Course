using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestConsoleApps;

namespace TestConsoleApps
{
    public static class SynchronizationTests
    {
        public static void EventsTests()
        {
            var manual_event = new ManualResetEvent(false);
            var auto_event = new AutoResetEvent(false);

            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++) 
            { 
                threads[i] = new Thread(() => 
                {
                    var thread_id = Environment.CurrentManagedThreadId;
                    Console.WriteLine("Поток {0} создан и ждет разрешения на выполнение: {1:HH:mm:ss:ffff}" ,thread_id,DateTime.Now);
                    manual_event.WaitOne(); 
                    Console.WriteLine("Поток {0} завершил свою работу: {1:HH:mm:ss:ffff}", thread_id,DateTime.Now   );
                    manual_event.Reset();   
                });
                threads[i].Start();
                Thread.Sleep(100);
            }
            
            Console.WriteLine("Создание поток выполнено");
            Console.ReadLine(); 
            Console.WriteLine("Потокам разрешено выполнение");
            manual_event.Set();
            Console.ReadLine();
        }

        public static void MutexSemaphoreTests()
        {
            Mutex mutex = new Mutex(true, "Название нашего приложения",out var is_created_new);
            mutex.WaitOne();
           
            //var semaphore = new Semaphore(0, 8);

            //semaphore.WaitOne();

            //if (!semaphore.WaitOne(3000))
            //{
            //        return;
            //}
           
            try
            {
                Console.WriteLine("Критическая секция");
            }
            finally
            {
               
              //  semaphore.Release();
                mutex.ReleaseMutex();
            }
        }

        public static void MonitorTests()
        { 
            var __SyncRoot = new object();

            lock (__SyncRoot)
            {
                Console.WriteLine("Критическая секция");
            }

            Monitor.Enter( __SyncRoot );
            try
            {
                Console.WriteLine("Критическая секция");
            }
            finally
            {
                Monitor.Exit( __SyncRoot ); 
            }
        }


            public static void Run() 
            {

                EventsTests();
            }
         
    }   
}
