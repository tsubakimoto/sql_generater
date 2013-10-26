using System.IO;

namespace sql_generater
{
    class MyProperty : NotifyPropertyBase
    {
        private FileInfo logFile;
        public FileInfo LogFile
        {
            get { return this.logFile; }
            set
            {
                this.logFile = value;
                OnPropertyChanged("LogFile");
            }
        }

        private string analyzedLog;
        public string AnalyzedLog
        {
            get { return this.analyzedLog; }
            set
            {
                this.analyzedLog = value;
                OnPropertyChanged("AnalyzedLog");
            }
        }

        private string processMsg;
        public string ProcessMsg
        {
            get { return this.processMsg; }
            set
            {
                this.processMsg = value;
                OnPropertyChanged("ProcessMsg");
            }
        }
    }
}
