using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Diagnostics;
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
     
            Dispatcher.Invoke(() => Title = "Time to start program " + DateTime.Now.ToString());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* Я попытался запустить несколько потоков и для каждого создал свой TextBox */
            /* Однако работает только один. Я что-то сделал неправильно, подскажите, пожайлуста, что? */

            TextBox[]  textBoxes = { TextBox1,TextBox2,TextBox3,TextBox4,TextBox5 };
            
            int Timeout = 500;

            var auto_event = new AutoResetEvent(false);

            var threads_list = new List<Thread>();

            Thread[] thread = new Thread[textBoxes.Length];
            
            for (int j = thread.Length - 1 ; j >= 0 ;j--) {

                     int i = j;// Добавлена локальная переменная
                     /* В 50% случаев запуска наблюдаю Dead Lock  - ЦП 0% активности всех процессов в окне диагностики */
                     /* Отладить возникающую ошибку у меня не получается - мне не хватает знаний */
                     thread[i] = new Thread(() =>
                     {
              
                            this.Dispatcher.BeginInvoke(() =>
                            {
                  
                                textBoxes[i].Text = string.Empty;
                    
                                var thread_id = Environment.CurrentManagedThreadId;
                    
                                var result = thread_id.ToString() + " " +fib(21).ToString()+" "+ DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine; ;
                                auto_event.WaitOne();
                                textBoxes[i].Text = result;
                    
                            });
                                     
                     });

            thread[i].IsBackground = true;
            /* Добавляем в список поток */
            threads_list.Add(thread[i]); 
            }

            /* Запуск всех потоков  из списка */
            foreach (var threads in threads_list) 
            {   
                    /* Создание Event запуск и остановка  таймера */
                    var timer = Stopwatch.StartNew();   
                    threads.Start();    
                    Thread.Sleep(Timeout);
                    auto_event.Set();
                    /* Создание Event остановка timer */
                    /* Не сработало */
                    timer.Stop();
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
