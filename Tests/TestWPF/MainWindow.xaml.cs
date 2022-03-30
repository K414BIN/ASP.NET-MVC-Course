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
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher.Invoke(() => Title = "Time to start program " + DateTime.Now.ToString());
            MyEventsAndThreads();
        }

        private static readonly object __SyncRoot = new object();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyEventsAndThreads();
        }
        private void MyEventsAndThreads()
        {
            /* Я попытался запустить несколько потоков и для каждого создал свой TextBox */
            /* Однако работает только один. Я что-то сделал неправильно, подскажите, пожалуйста, что? */

            TextBox[]  textBoxes = { TextBox1,TextBox2,TextBox3,TextBox4,TextBox5 };
            
            int Timeout = 500;
            
            var threads_list = new List<Thread>();

            Thread[] thread = new Thread[textBoxes.Length];
            
            var auto_event = new AutoResetEvent(false);

            for (int i = thread.Length - 1; i >=0; i--) { 

            thread[i] = new Thread(() =>
            {
              
                Application.Current.Dispatcher.BeginInvoke(() =>
                {

                    var thread_id = Environment.CurrentManagedThreadId;
            
                    var result = thread_id.ToString()+" " + DateTime.Now.ToString("HH: mm:ss: fff");
                    auto_event.WaitOne();
                    textBoxes[i].Text = result;
                         
                    auto_event.Reset(); 
                });
                                  
            });
            

            thread[i].IsBackground = true;
            threads_list.Add(thread[i]); 
            }

            foreach (var threads in threads_list) 
            {   
                    threads.Start();    
                    Thread.Sleep(Timeout);
                     auto_event.Set();
                    
            }
        }
    }
}
