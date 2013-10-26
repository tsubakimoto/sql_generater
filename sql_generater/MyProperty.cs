using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace sql_generater
{
    public class MyProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

#if false
        private string _Message = string.Empty;
        public string Message
        {
            get { return this._Message; }
            set
            {
                if (value != this._Message)
                {
                    this._Message = value;
                    NotifyPropertyChanged("Message");
                }
            }
        }
#endif
    }
}
