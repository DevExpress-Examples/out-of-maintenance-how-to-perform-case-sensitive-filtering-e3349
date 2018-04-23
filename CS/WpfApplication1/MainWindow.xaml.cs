using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using DevExpress.Data.Filtering.Helpers;
using System.ComponentModel;
using DevExpress.Data.Filtering;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<MyObj> coll = new ObservableCollection<MyObj>();
            coll.Add(new MyObj() { Text = "A", Number = 1, Group = "A" });
            coll.Add(new MyObj() { Text = "a", Number = 2, Group = "A" });
            coll.Add(new MyObj() { Text = "a", Number = 3, Group = "B" });
            coll.Add(new MyObj() { Text = "B", Number = 4, Group = "B" });
            gridControl1.ItemsSource = coll;
        }

        private void gridControl1_CustomRowFilter(object sender, DevExpress.Xpf.Grid.RowFilterEventArgs e)
        {
            var row = gridControl1.GetRowByListIndex(e.ListSourceRowIndex);
            ExpressionEvaluator ee = new ExpressionEvaluator(TypeDescriptor.GetProperties(row), gridControl1.FilterCriteria, checkEdit1.IsChecked == true ? true : false);
            object obj = ee.Evaluate(row);

            if (obj != null)
                e.Visible = Convert.ToBoolean(obj);

            e.Handled = true;

        }


        private void checkEdit1_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            gridControl1.RefreshData();
            //CriteriaOperator co = gridControl1.FilterCriteria;
            //gridControl1.FilterCriteria = null;
            //gridControl1.FilterCriteria = co;
        }
    }
    public class MyObj
    {
        private string _String;
        public string Text
        {
            get { return _String; }
            set
            {
                _String = value;
            }
        }
        private double _Number;
        public double Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
            }
        }
        private string _Group;
        public string Group
        {
            get { return _Group; }
            set
            {
                _Group = value;
            }
        }

    }
}
