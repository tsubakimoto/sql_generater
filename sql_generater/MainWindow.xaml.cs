using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace sql_generater
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private string prevDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public MyProperty Pt { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = Pt;
        }

        private void BtnDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                FileName = string.Empty,
                DefaultExt = "*.log",
                InitialDirectory = prevDirectory
            };

            if (dialog.ShowDialog() == true)
            {
                var fi = new FileInfo(dialog.FileName);
                if (fi.Exists)
                {
                    prevDirectory = fi.DirectoryName;
                    this.LogFile.Text = fi.FullName;

                    ShowLog(fi);
                }
                else
                {
                    this.ProcessMsg.Text = "ファイルが見つかりません。";
                    this.ProcessMsg.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowLog(FileInfo fi)
        {
            using (var st = fi.OpenText())
            {
                this.AnalyzedLog.Text = st.ReadToEnd();
            }
        }
    }
}
