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
            var sqlList = GetSqlList();
            var inserts = from sql in sqlList where sql.ToLower().StartsWith("insert") select sql;
            var updates = from sql in sqlList where sql.ToLower().StartsWith("update") select sql;
            var deletes = from sql in sqlList where sql.ToLower().StartsWith("delete") select sql;
        }

        private void ShowLog()
        {
            using (var st = Pt.LogFile.OpenText())
            {
                Pt.AnalyzedLog = st.ReadToEnd();
            }
        }

        private IEnumerable<string> GetSqlList()
        {
            // ログ先頭の日時、処理種別、DB種別を除外する（今は無理やり）
            return from log in GetLogCollection() select log.Remove(0, 43);
        }

        private List<string> GetLogCollection()
        {
            return Pt.AnalyzedLog.Split('\n').ToList();
        }
    }
}
