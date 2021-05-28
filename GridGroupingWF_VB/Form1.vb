Imports Microsoft.VisualBasic
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Namespace DataGrid
	Partial Public Class Form1
		Inherits Form
		#Region "Constructor"
		Public Sub New()
			InitializeComponent()

			Me.gridGroupingControl1.AllowProportionalColumnSizing = True
			Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False
			Me.gridGroupingControl1.TableModel.Properties.PrintFrame = True
			Me.gridGroupingControl1.ThemesEnabled = True
			Me.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
			Dim dt As DataTable = CreateTable()
			Me.gridGroupingControl1.DataSource = dt
		End Sub
		#End Region

		#Region "DataTable"
		Private Function CreateTable() As DataTable
			Dim name1() As String = { "John", "Peter", "Smith", "Jay", "Krish", "Mike" }
			Dim country() As String = { "UK", "USA", "Pune", "India", "China", "England" }
			Dim city() As String = { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" }
			Dim scountry() As String = { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" }
			Dim dt As New DataTable()
			Dim dr As DataRow
			Dim r As New Random()

			dt.Columns.Add("Name")
			dt.Columns.Add("Id")
			dt.Columns.Add("Country")
			dt.Columns.Add("Ship City")
			dt.Columns.Add("Ship Country")
			dt.Columns.Add("Freight")
			dt.Columns.Add("Postal code")

			For l As Integer = 0 To 19
				dr = dt.NewRow()
				dr(0) = name1(r.Next(0, 5))
				dr(1) = "E" & r.Next(30)
				dr(2) = country(r.Next(0, 5))
				dr(3) = city(r.Next(0, 5))
				dr(4) = scountry(r.Next(0, 5))
				dr(5) = r.Next(1000, 2000)
				dr(6) = r.Next(10 + (r.Next(600000, 600100)))

				dt.Rows.Add(dr)
			Next l
			Return dt
		End Function
		#End Region

		#Region "Event Hanlder"

		'To store the sorting info
		Public GridSortCollection As SortColumnDescriptorCollection

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			GridSortCollection = Me.gridGroupingControl1.TableDescriptor.SortedColumns
			' TableControlCellDrawn Event Subscription
			AddHandler Me.gridGroupingControl1.TableControlCellDrawn, AddressOf GridGroupingControl1_TableControlCellDrawn
			Dim printDocument As New GridPrintDocumentAdv(Me.gridGroupingControl1.TableControl)
			Dim previewDialog As New PrintPreviewDialog()
			previewDialog.ShowIcon = False
			previewDialog.Document = printDocument
			previewDialog.Show()
		End Sub

		'Used to draw a sort icon while printing
		Private Sub GridGroupingControl1_TableControlCellDrawn(ByVal sender As Object, ByVal e As GridTableControlDrawCellEventArgs)
			If e.TableControl.PrintingMode Then
				Dim style As GridTableCellStyleInfo = TryCast(e.Inner.Style, GridTableCellStyleInfo)

				If style IsNot Nothing AndAlso style.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.ColumnHeader AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
					If GridSortCollection IsNot Nothing AndAlso GridSortCollection.Count > 0 Then
						If GridSortCollection.Contains(style.TableCellIdentity.Column.MappingName.ToString()) Then
							Dim rec As Rectangle = e.Inner.Bounds

							rec.X = e.Inner.Bounds.Right - 7

							rec.Y = (rec.Y + e.Inner.Bounds.Height \ 2) - 2

							If GridSortCollection(style.TableCellIdentity.Column.MappingName.ToString()).SortDirection = ListSortDirection.Ascending Then
								Dim ASC() As Point = { New Point(rec.X + 0, rec.Y + 3), New Point(rec.X + 6, rec.Y + 3), New Point(rec.X + 3, rec.Y - 0) }

								e.Inner.Graphics.FillPolygon(Brushes.Black, ASC)

							ElseIf GridSortCollection(style.TableCellIdentity.Column.MappingName.ToString()).SortDirection = ListSortDirection.Descending Then
								Dim DESC() As Point = { New Point(rec.X + 0, rec.Y + 0), New Point(rec.X + 6, rec.Y + 0), New Point(rec.X + 3, rec.Y + 3) }

								e.Inner.Graphics.FillPolygon(Brushes.Black, DESC)
							End If
						End If
					End If
				End If
			End If
		End Sub
		#End Region
	End Class
End Namespace
