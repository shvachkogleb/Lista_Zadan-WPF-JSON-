using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> _todoDataList = new BindingList<ToDoModel>();
        private FileIOService _fileIOService;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void dgTodoList_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(AppDomain.CurrentDomain.BaseDirectory + "\\data.json");
            try  {
                _todoDataList = _fileIOService.LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); Close(); }


            DGTodoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType) {
                case ListChangedType.ItemAdded:
                    try
                    {
                        _fileIOService.SaveData(sender);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); Close(); }
                    break;
                case ListChangedType.ItemDeleted:
                    try
                    {
                        _fileIOService.SaveData(sender);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); Close(); }
                    break;

                case ListChangedType.ItemChanged:
                    try
                    {
                        _fileIOService.SaveData(sender);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); Close(); };
                    break;
                case ListChangedType.ItemMoved:
                    try
                    {
                        _fileIOService.SaveData(sender);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); Close(); }
                    break;
                case ListChangedType.Reset:
                    try
                    {
                        _fileIOService.SaveData(sender);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); Close(); }
                    break;
            }
        }
    }
}
