<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Customer
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
        Me.lstMenu = New System.Windows.Forms.ListView()
        Me.菜品 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.价格 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstOrder = New System.Windows.Forms.ListView()
        Me.已选菜品 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstMenu
        '
        Me.lstMenu.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.菜品, Me.价格})
        Me.lstMenu.HideSelection = False
        Me.lstMenu.Location = New System.Drawing.Point(77, 44)
        Me.lstMenu.Name = "lstMenu"
        Me.lstMenu.Size = New System.Drawing.Size(193, 264)
        Me.lstMenu.TabIndex = 0
        Me.lstMenu.UseCompatibleStateImageBehavior = False
        Me.lstMenu.View = System.Windows.Forms.View.Details
        '
        '菜品
        '
        Me.菜品.Text = "菜品"
        Me.菜品.Width = 80
        '
        '价格
        '
        Me.价格.Text = "价格"
        '
        'lstOrder
        '
        Me.lstOrder.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.已选菜品, Me.Price})
        Me.lstOrder.HideSelection = False
        Me.lstOrder.Location = New System.Drawing.Point(377, 44)
        Me.lstOrder.Name = "lstOrder"
        Me.lstOrder.Size = New System.Drawing.Size(192, 264)
        Me.lstOrder.TabIndex = 1
        Me.lstOrder.UseCompatibleStateImageBehavior = False
        Me.lstOrder.View = System.Windows.Forms.View.Details
        '
        '已选菜品
        '
        Me.已选菜品.Text = "已选菜品"
        Me.已选菜品.Width = 80
        '
        'Price
        '
        Me.Price.Text = "价格"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(285, 165)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 73)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "删除已选菜品"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(285, 68)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 67)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "添加菜品到已选菜品"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnPay
        '
        Me.btnPay.Location = New System.Drawing.Point(285, 270)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(75, 38)
        Me.btnPay.TabIndex = 9
        Me.btnPay.Text = "支付"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(142, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "可选菜品"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "已选菜品"
        '
        'Customer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 450)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstOrder)
        Me.Controls.Add(Me.lstMenu)
        Me.Name = "Customer"
        Me.Text = "Customer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstMenu As ListView
    Friend WithEvents lstOrder As ListView
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnPay As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents 菜品 As ColumnHeader
    Friend WithEvents 价格 As ColumnHeader
    Friend WithEvents 已选菜品 As ColumnHeader
    Friend WithEvents Price As ColumnHeader
End Class
