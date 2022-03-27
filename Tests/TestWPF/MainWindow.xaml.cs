using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* запуск программы  */
        public MainWindow()
        {
            InitializeComponent();
          
            
            Dispatcher.Invoke(() => Title = "Time to start program " + __SyncTime.ToString());

        }

        /* Создание объекта только для чтения для lock */
        private static readonly object __SyncRoot = new object();

        /* Создание объекта только для чтения для отчета секунд, когда запустится новый поток  */
        /* Не понадобился, потому что потоки не переключаются у меня */
        private static readonly DateTime __SyncTime = DateTime.Now;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* Я попытался запустить несколько потоков и для каждого создал свой TextBox */
            /* Однако работает только один. Я что-то сделал неправильно, подскажите, пожайлуста, что? */

            TextBox[]  textBoxes = { TextBox1,TextBox2,TextBox3,TextBox4,TextBox5 };
            
            int Timeout = 500;
            
            var threads_list = new List<Thread>();

            Thread[] thread = new Thread[textBoxes.Length];

            for (int i = thread.Length - 1; i > 0; i--) { 

            thread[i] = new Thread(() =>
            {
                lock   (__SyncRoot)
                { 
                    this.Dispatcher.BeginInvoke(() =>
                {
                    textBoxes[i].Text = string.Empty;
                    var result =  Thread.CurrentThread.ManagedThreadId.ToString() + " " +fib(21).ToString()+" "+ DateTime.Now.ToString() + Environment.NewLine; ;
                     textBoxes[i].Text = result;
                                
                });
                }                     
            });

            thread[i].IsBackground = true;
            /* Добавляем в список поток */
            threads_list.Add(thread[i]); 
            }

            /* Запуск всех потоков  из списка */
            foreach (var threads in threads_list) 
            {   
                    threads.Start();    
                    Thread.Sleep(Timeout);
            }
                    
        }
        /* Расчет 21 числа Фибоначчи */
        static decimal fib(decimal n)
        {
            if (n == 0 || n == 1)
                return n;

            return fib(n - 1) + fib(n - 2);

        }

    }
}
