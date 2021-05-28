Imports Microsoft.VisualBasic
Imports System
Namespace DataGrid
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
			Me.button1 = New System.Windows.Forms.Button()
			CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridGroupingControl1
			' 
			Me.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb((CInt(Fix((CByte(64))))), (CInt(Fix((CByte(0))))), (CInt(Fix((CByte(120))))), (CInt(Fix((CByte(215))))))
			Me.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
			Me.gridGroupingControl1.Location = New System.Drawing.Point(-4, -2)
			Me.gridGroupingControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
			Me.gridGroupingControl1.Name = "gridGroupingControl1"
			Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
			Me.gridGroupingControl1.Size = New System.Drawing.Size(1135, 588)
			Me.gridGroupingControl1.TabIndex = 0
			Me.gridGroupingControl1.Text = "gridGroupingControl1"
			Me.gridGroupingControl1.UseRightToLeftCompatibleTextBox = True
			Me.gridGroupingControl1.VersionInfo = "12.4400.0.24"
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(1162, 96)
			Me.button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(112, 35)
			Me.button1.TabIndex = 1
			Me.button1.Text = "Preview"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(9F, 20F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1297, 622)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.gridGroupingControl1)
			Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.ShowIcon = False
			Me.Text = "Print Preview"
			CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
		Private WithEvents button1 As System.Windows.Forms.Button
	End Class
End Namespace

