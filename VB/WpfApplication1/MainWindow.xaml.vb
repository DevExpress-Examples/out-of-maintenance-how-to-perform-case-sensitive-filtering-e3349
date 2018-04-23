Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports DevExpress.Data.Filtering.Helpers
Imports System.ComponentModel
Imports DevExpress.Data.Filtering

Namespace WpfApplication1
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Dim coll As New ObservableCollection(Of MyObj)()
			coll.Add(New MyObj() With {.Text = "A", .Number = 1, .Group = "A"})
			coll.Add(New MyObj() With {.Text = "a", .Number = 2, .Group = "A"})
			coll.Add(New MyObj() With {.Text = "a", .Number = 3, .Group = "B"})
			coll.Add(New MyObj() With {.Text = "B", .Number = 4, .Group = "B"})
			gridControl1.ItemsSource = coll
		End Sub

		Private Sub gridControl1_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.RowFilterEventArgs)
			Dim row = gridControl1.GetRowByListIndex(e.ListSourceRowIndex)
			Dim ee As New ExpressionEvaluator(TypeDescriptor.GetProperties(row), gridControl1.FilterCriteria,If(checkEdit1.IsChecked = True, True, False))
			Dim obj As Object = ee.Evaluate(row)

			If obj IsNot Nothing Then
				e.Visible = Convert.ToBoolean(obj)
			End If

			e.Handled = True

		End Sub


		Private Sub checkEdit1_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.Xpf.Editors.EditValueChangedEventArgs)
			gridControl1.RefreshData()
			'CriteriaOperator co = gridControl1.FilterCriteria;
			'gridControl1.FilterCriteria = null;
			'gridControl1.FilterCriteria = co;
		End Sub
	End Class
	Public Class MyObj
		Private _String As String
		Public Property Text() As String
			Get
				Return _String
			End Get
			Set(ByVal value As String)
				_String = value
			End Set
		End Property
		Private _Number As Double
		Public Property Number() As Double
			Get
				Return _Number
			End Get
			Set(ByVal value As Double)
				_Number = value
			End Set
		End Property
		Private _Group As String
		Public Property Group() As String
			Get
				Return _Group
			End Get
			Set(ByVal value As String)
				_Group = value
			End Set
		End Property

	End Class
End Namespace
