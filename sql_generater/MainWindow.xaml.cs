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
        private MyProperty Pt { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Pt = new MyProperty();
            this.DataContext = Pt;
        }

        private void BtnDialog_Click(object sender, RoutedEventArgs e)
        {
            var prevDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (Pt.LogFile != null) prevDirectory = Pt.LogFile.DirectoryName;

            var dialog = new OpenFileDialog()
            {
                FileName = string.Empty,
                DefaultExt = "*.log",
                InitialDirectory = prevDirectory
            };

            if (dialog.ShowDialog() == true)
            {
                Pt.LogFile = new FileInfo(dialog.FileName);
                if (Pt.LogFile.Exists)
                {
                    ShowLog();
                }
                else
                {
                    Pt.ProcessMsg = "ファイルが見つかりません。";
                }
            }
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowLog()
        {
            using (var st = Pt.LogFile.OpenText())
            {
                Pt.AnalyzedLog = st.ReadToEnd();
            }
        }
    }
}
