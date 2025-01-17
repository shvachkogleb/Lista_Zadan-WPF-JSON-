using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    internal class ToDoModel : INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _IsDone { get; set; }

        private string _Text;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Text
        {
            get => _Text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Text cannot be null or empty");
                }
                if (_Text == value)
                {
                    return;
                }

                _Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public bool IsDone
        {
            get { return _IsDone; }
            set 
            {
                if (IsDone == value)
                    return;
                _IsDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
    }
}
