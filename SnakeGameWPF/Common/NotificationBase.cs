using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameWPF.Common
{
    public class NotificationBase : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        /// <summary>
        /// The RaisePropertyChanged method is called raise a property changed event. 
        /// </summary>
        /// <param name="property"></param>
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
