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
        }

        private static readonly object __SyncRoot = new object();

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
                lock   (__SyncRoot) { 
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    var result = "\n" + Thread.CurrentThread.ManagedThreadId.ToString() + " " + Thread.CurrentThread.ThreadState.ToString() +" " + DateTime.Now.ToString();
                     textBoxes[i].Text = result;
                                
                });
                }                     
            });
            

            thread[i].IsBackground = true;
            threads_list.Add(thread[i]); 
            }

            foreach (var threads in threads_list) 
            {   
                    threads.Start();    
                    Thread.Sleep(Timeout);
            }
        }
    }
}
