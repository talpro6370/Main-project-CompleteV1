using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    public class progressBarStatus: INotifyPropertyChanged
    {
        public progressBarStatus()
        {
            ProgBarValue = 0;
        }
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int progBarValue;
        public int ProgBarValue
        {
            get
            {
                return progBarValue;
            }
            set
            {
                progBarValue = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
