# How to display a sort icon on print preview in WinForms GridGroupingControl?
Draw a sort icon at the column header in print preview by using the [SortColumnDescriptorCollection](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Grouping.SortColumnDescriptorCollection.html) to store the sorted columns. Then, subscribe to the [TableControlCellDrawn](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl.html#Syncfusion_Windows_Forms_Grid_Grouping_GridGroupingControl_TableControlCellDrawn) and draw a triangle sorted icon as per the ListSortDirection.



### C#
```csharp
//To store the sorting info
public SortColumnDescriptorCollection gridSortCollection;
 
//Print preview click
private void button1_Click(object sender, EventArgs e)
{
    gridSortCollection = this.gridGroupingControl1.TableDescriptor.SortedColumns;
    //Wiring TableControlCellDrawn event 
    this.gridGroupingControl1.TableControlCellDrawn += GridGroupingControl1_TableControlCellDrawn;

    GridPrintDocumentAdv printDocument = new GridPrintDocumentAdv(this.gridGroupingControl1.TableControl);
    PrintPreviewDialog previewDialog = new PrintPreviewDialog();
    previewDialog.Document = printDocument;
    previewDialog.Show();
}

//Used to draw a sort icon while printing
private void GridGroupingControl1_TableControlCellDrawn(object sender, GridTableControlDrawCellEventArgs e)
{
    if (e.TableControl.PrintingMode)
    {
        GridTableCellStyleInfo style = e.Inner.Style as GridTableCellStyleInfo;

        if (style != null && style.TableCellIdentity.DisplayElement.Kind == Syncfusion.Grouping.DisplayElementKind.ColumnHeader

        && style.TableCellIdentity.TableCellType == GridTableCellType.ColumnHeaderCell)
        {
            if (gridSortCollection != null && gridSortCollection.Count > 0)
            {
                if (gridSortCollection.Contains(style.TableCellIdentity.Column.MappingName.ToString()))
                {
                    Rectangle rec = e.Inner.Bounds;

                    rec.X = e.Inner.Bounds.Right - 7;

                    rec.Y = (rec.Y + e.Inner.Bounds.Height / 2) - 2;

                    if (gridSortCollection[style.TableCellIdentity.Column.MappingName.ToString()].SortDirection == ListSortDirection.Ascending)
                    {
                        Point[] ASC = new Point[] { new Point(rec.X + 0, rec.Y + 3), new Point(rec.X + 6, rec.Y + 3), new Point(rec.X + 3, rec.Y - 0) };

                        e.Inner.Graphics.FillPolygon(Brushes.Black, ASC);
                    }

                    else if (gridSortCollection[style.TableCellIdentity.Column.MappingName.ToString()].SortDirection == ListSortDirection.Descending)
                    {
                        Point[] DESC = new Point[] { new Point(rec.X + 0, rec.Y + 0), new Point(rec.X + 6, rec.Y + 0), new Point(rec.X + 3, rec.Y + 3) };

                        e.Inner.Graphics.FillPolygon(Brushes.Black, DESC);
                    }
                }
            }
        }
    }
}
```

### VB
```vb
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
                        Dim ASC() As Point = {New Point(rec.X + 0, rec.Y + 3), New Point(rec.X + 6, rec.Y + 3), New Point(rec.X + 3, rec.Y - 0)}

                        e.Inner.Graphics.FillPolygon(Brushes.Black, ASC)

                    ElseIf GridSortCollection(style.TableCellIdentity.Column.MappingName.ToString()).SortDirection = ListSortDirection.Descending Then
                        Dim DESC() As Point = {New Point(rec.X + 0, rec.Y + 0), New Point(rec.X + 6, rec.Y + 0), New Point(rec.X + 3, rec.Y + 3)}

                        e.Inner.Graphics.FillPolygon(Brushes.Black, DESC)
                    End If
                End If
            End If
        End If
    End If
End Sub
```
