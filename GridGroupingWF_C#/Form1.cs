using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;

namespace DataGrid
{
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();

            this.gridGroupingControl1.AllowProportionalColumnSizing = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.TableModel.Properties.PrintFrame = true;
            this.gridGroupingControl1.ThemesEnabled = true;
            this.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            DataTable dt = CreateTable();
            this.gridGroupingControl1.DataSource = dt;
        }
        #endregion

        #region DataTable
        private DataTable CreateTable()
        {
            string[] name1 = new string[] { "John", "Peter", "Smith", "Jay", "Krish", "Mike" };
            string[] country = new string[] { "UK", "USA", "Pune", "India", "China", "England" };
            string[] city = new string[] { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" };
            string[] scountry = new string[] { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" };
            DataTable dt = new DataTable();
            DataRow dr;
            Random r = new Random();

            dt.Columns.Add("Name");
            dt.Columns.Add("Id");
            dt.Columns.Add("Country");
            dt.Columns.Add("Ship City");
            dt.Columns.Add("Ship Country");
            dt.Columns.Add("Freight");
            dt.Columns.Add("Postal code");
           
            for (int l = 0; l < 20; l++)
            {
                dr = dt.NewRow();
                dr[0] = name1[r.Next(0, 5)];
                dr[1] = "E" + r.Next(30);
                dr[2] = country[r.Next(0, 5)];
                dr[3] = city[r.Next(0, 5)];
                dr[4] = scountry[r.Next(0, 5)];
                dr[5] = r.Next(1000, 2000);
                dr[6] = r.Next(10 + (r.Next(600000, 600100)));
             
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region Event Hanlder

        //To store the sorting info
        public SortColumnDescriptorCollection GridSortCollection;

        private void button1_Click(object sender, EventArgs e)
        {
            GridSortCollection = this.gridGroupingControl1.TableDescriptor.SortedColumns;
            // TableControlCellDrawn Event Subscription
            this.gridGroupingControl1.TableControlCellDrawn += GridGroupingControl1_TableControlCellDrawn;
            GridPrintDocumentAdv printDocument = new GridPrintDocumentAdv(this.gridGroupingControl1.TableControl);
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.ShowIcon = false;
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
                    if (GridSortCollection != null && GridSortCollection.Count > 0)
                    {
                        if (GridSortCollection.Contains(style.TableCellIdentity.Column.MappingName.ToString()))
                        {
                            Rectangle rec = e.Inner.Bounds;

                            rec.X = e.Inner.Bounds.Right - 7;

                            rec.Y = (rec.Y + e.Inner.Bounds.Height / 2) - 2;

                            if (GridSortCollection[style.TableCellIdentity.Column.MappingName.ToString()].SortDirection == ListSortDirection.Ascending)
                            {
                                Point[] ASC = new Point[] { new Point(rec.X + 0, rec.Y + 3), new Point(rec.X + 6, rec.Y + 3), new Point(rec.X + 3, rec.Y - 0) };

                                e.Inner.Graphics.FillPolygon(Brushes.Black, ASC);
                            }

                            else if (GridSortCollection[style.TableCellIdentity.Column.MappingName.ToString()].SortDirection == ListSortDirection.Descending)
                            {
                                Point[] DESC = new Point[] { new Point(rec.X + 0, rec.Y + 0), new Point(rec.X + 6, rec.Y + 0), new Point(rec.X + 3, rec.Y + 3) };

                                e.Inner.Graphics.FillPolygon(Brushes.Black, DESC);
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
