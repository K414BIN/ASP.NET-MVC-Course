using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Threading.Tasks;

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
            CancelButton.IsEnabled = false; 
        }

        private CancellationTokenSource? _ProcessingCancellation;

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button StartButton) return;
            var thread_id = Thread.CurrentThread.ManagedThreadId;

            StartButton.IsEnabled = false;
            CancelButton.IsEnabled = true;

            IProgress<double> progress = new Progress<double>(p => ProgressInformer.Value = p * 100);

            var cancellation_source = new CancellationTokenSource();

            _ProcessingCancellation = cancellation_source;

            try {
                    var thread_id1 = Thread.CurrentThread.ManagedThreadId;
                    var result = await  SomeImportantCalculationsAsync(20,progress,cancellation_source.Token).ConfigureAwait(true);    
                    var thread_id2 = Thread.CurrentThread.ManagedThreadId;
                    TextBlock.Text = result.ToString();
            }
            catch (OperationCanceledException )
                {  
                  progress.Report(0);
                  TextBlock.Text = "Операция была отменена!";
                }
            StartButton.IsEnabled = true;
            CancelButton.IsEnabled = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _ProcessingCancellation?.Cancel();
        }

        private async Task<DateTime> SomeImportantCalculationsAsync( int Timeout  = 100,IProgress<double> Progress = null,CancellationToken Cancel=default )
        {
          
            Cancel.ThrowIfCancellationRequested();
            const  int  counter = 100;
            if ( Timeout > 0 )
            {
                for (int i = 0; i < counter; i++)
                {
                    if (Cancel.IsCancellationRequested) { Cancel.ThrowIfCancellationRequested(); }
                   
                    await Task.Delay(Timeout).ConfigureAwait(false);
                   
                    Progress?.Report((double)i / counter);
                }
            }
            Progress?.Report(1);
            Cancel.ThrowIfCancellationRequested();
          
            return DateTime.Now;    
        }  
    }
}
