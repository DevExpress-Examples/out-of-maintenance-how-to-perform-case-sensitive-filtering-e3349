Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Collections.ObjectModel
Imports DevExpress.Data.Filtering.Helpers
Imports System.ComponentModel

Namespace WpfApplication1

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim coll As ObservableCollection(Of MyObj) = New ObservableCollection(Of MyObj)()
            coll.Add(New MyObj() With {.Text = "A", .Number = 1, .Group = "A"})
            coll.Add(New MyObj() With {.Text = "a", .Number = 2, .Group = "A"})
            coll.Add(New MyObj() With {.Text = "a", .Number = 3, .Group = "B"})
            coll.Add(New MyObj() With {.Text = "B", .Number = 4, .Group = "B"})
            Me.gridControl1.ItemsSource = coll
        End Sub

        Private Sub gridControl1_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.RowFilterEventArgs)
            Dim row = Me.gridControl1.GetRowByListIndex(e.ListSourceRowIndex)
            Dim ee As ExpressionEvaluator = New ExpressionEvaluator(TypeDescriptor.GetProperties(row), Me.gridControl1.FilterCriteria, If(Me.checkEdit1.IsChecked = True, True, False))
            Dim obj As Object = ee.Evaluate(row)
            If obj IsNot Nothing Then e.Visible = Convert.ToBoolean(obj)
            e.Handled = True
        End Sub

        Private Sub checkEdit1_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Editors.EditValueChangedEventArgs)
            Me.gridControl1.RefreshData()
        'CriteriaOperator co = gridControl1.FilterCriteria;
        'gridControl1.FilterCriteria = null;
        'gridControl1.FilterCriteria = co;
        End Sub
    End Class

    Public Class MyObj

        Private _String As String

        Public Property Text As String
            Get
                Return _String
            End Get

            Set(ByVal value As String)
                _String = value
            End Set
        End Property

        Private _Number As Double

        Public Property Number As Double
            Get
                Return _Number
            End Get

            Set(ByVal value As Double)
                _Number = value
            End Set
        End Property

        Private _Group As String

        Public Property Group As String
            Get
                Return _Group
            End Get

            Set(ByVal value As String)
                _Group = value
            End Set
        End Property
    End Class
End Namespace
