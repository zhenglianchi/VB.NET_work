<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CoursesListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SelectedCoursesListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.DropButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CoursesListView
        '
        Me.CoursesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.CoursesListView.HideSelection = False
        Me.CoursesListView.Location = New System.Drawing.Point(75, 52)
        Me.CoursesListView.Name = "CoursesListView"
        Me.CoursesListView.Size = New System.Drawing.Size(298, 292)
        Me.CoursesListView.TabIndex = 0
        Me.CoursesListView.UseCompatibleStateImageBehavior = False
        Me.CoursesListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "课程名"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "老师"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "是否已选"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "已选人数"
        '
        'SelectedCoursesListView
        '
        Me.SelectedCoursesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.SelectedCoursesListView.HideSelection = False
        Me.SelectedCoursesListView.Location = New System.Drawing.Point(415, 52)
        Me.SelectedCoursesListView.Name = "SelectedCoursesListView"
        Me.SelectedCoursesListView.Size = New System.Drawing.Size(306, 292)
        Me.SelectedCoursesListView.TabIndex = 1
        Me.SelectedCoursesListView.UseCompatibleStateImageBehavior = False
        Me.SelectedCoursesListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "课程名"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "老师"
        Me.ColumnHeader6.Width = 80
        '
        'SelectButton
        '
        Me.SelectButton.Location = New System.Drawing.Point(215, 372)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(75, 35)
        Me.SelectButton.TabIndex = 2
        Me.SelectButton.Text = "选课"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'DropButton
        '
        Me.DropButton.Location = New System.Drawing.Point(451, 372)
        Me.DropButton.Name = "DropButton"
        Me.DropButton.Size = New System.Drawing.Size(75, 35)
        Me.DropButton.TabIndex = 3
        Me.DropButton.Text = "退选"
        Me.DropButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DropButton)
        Me.Controls.Add(Me.SelectButton)
        Me.Controls.Add(Me.SelectedCoursesListView)
        Me.Controls.Add(Me.CoursesListView)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CoursesListView As ListView
    Friend WithEvents SelectedCoursesListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents SelectButton As Button
    Friend WithEvents DropButton As Button
End Class
