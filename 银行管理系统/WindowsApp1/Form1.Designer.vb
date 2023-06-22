<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.BalanceTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AddAccountButton = New System.Windows.Forms.Button()
        Me.DeleteAccountButton = New System.Windows.Forms.Button()
        Me.AccountListView = New System.Windows.Forms.ListView()
        Me.Aid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Aname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Abalance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DepositButton = New System.Windows.Forms.Button()
        Me.WithdrawButton = New System.Windows.Forms.Button()
        Me.TransferButton = New System.Windows.Forms.Button()
        Me.ViewAccountButton = New System.Windows.Forms.Button()
        Me.FromNameTextBox = New System.Windows.Forms.TextBox()
        Me.ToNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Acount Name"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(165, 61)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(100, 25)
        Me.NameTextBox.TabIndex = 1
        '
        'BalanceTextBox
        '
        Me.BalanceTextBox.Location = New System.Drawing.Point(165, 109)
        Me.BalanceTextBox.Name = "BalanceTextBox"
        Me.BalanceTextBox.Size = New System.Drawing.Size(100, 25)
        Me.BalanceTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "balance"
        '
        'AddAccountButton
        '
        Me.AddAccountButton.Location = New System.Drawing.Point(68, 156)
        Me.AddAccountButton.Name = "AddAccountButton"
        Me.AddAccountButton.Size = New System.Drawing.Size(108, 34)
        Me.AddAccountButton.TabIndex = 4
        Me.AddAccountButton.Text = "添加新账户"
        Me.AddAccountButton.UseVisualStyleBackColor = True
        '
        'DeleteAccountButton
        '
        Me.DeleteAccountButton.Location = New System.Drawing.Point(261, 156)
        Me.DeleteAccountButton.Name = "DeleteAccountButton"
        Me.DeleteAccountButton.Size = New System.Drawing.Size(108, 34)
        Me.DeleteAccountButton.TabIndex = 5
        Me.DeleteAccountButton.Text = "删除已有账户"
        Me.DeleteAccountButton.UseVisualStyleBackColor = True
        '
        'AccountListView
        '
        Me.AccountListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Aid, Me.Aname, Me.Abalance})
        Me.AccountListView.HideSelection = False
        Me.AccountListView.Location = New System.Drawing.Point(410, 37)
        Me.AccountListView.Name = "AccountListView"
        Me.AccountListView.Size = New System.Drawing.Size(304, 300)
        Me.AccountListView.TabIndex = 6
        Me.AccountListView.UseCompatibleStateImageBehavior = False
        Me.AccountListView.View = System.Windows.Forms.View.Details
        '
        'Aid
        '
        Me.Aid.Text = "ID"
        Me.Aid.Width = 50
        '
        'Aname
        '
        Me.Aname.Text = "Name"
        Me.Aname.Width = 70
        '
        'Abalance
        '
        Me.Abalance.Text = "Balance"
        Me.Abalance.Width = 100
        '
        'DepositButton
        '
        Me.DepositButton.Location = New System.Drawing.Point(68, 206)
        Me.DepositButton.Name = "DepositButton"
        Me.DepositButton.Size = New System.Drawing.Size(75, 36)
        Me.DepositButton.TabIndex = 8
        Me.DepositButton.Text = "存款"
        Me.DepositButton.UseVisualStyleBackColor = True
        '
        'WithdrawButton
        '
        Me.WithdrawButton.Location = New System.Drawing.Point(178, 206)
        Me.WithdrawButton.Name = "WithdrawButton"
        Me.WithdrawButton.Size = New System.Drawing.Size(75, 36)
        Me.WithdrawButton.TabIndex = 7
        Me.WithdrawButton.Text = "取款"
        Me.WithdrawButton.UseVisualStyleBackColor = True
        '
        'TransferButton
        '
        Me.TransferButton.Location = New System.Drawing.Point(294, 206)
        Me.TransferButton.Name = "TransferButton"
        Me.TransferButton.Size = New System.Drawing.Size(75, 36)
        Me.TransferButton.TabIndex = 9
        Me.TransferButton.Text = "转账"
        Me.TransferButton.UseVisualStyleBackColor = True
        '
        'ViewAccountButton
        '
        Me.ViewAccountButton.Location = New System.Drawing.Point(137, 268)
        Me.ViewAccountButton.Name = "ViewAccountButton"
        Me.ViewAccountButton.Size = New System.Drawing.Size(142, 33)
        Me.ViewAccountButton.TabIndex = 11
        Me.ViewAccountButton.Text = "查看特定账户信息"
        Me.ViewAccountButton.UseVisualStyleBackColor = True
        '
        'FromNameTextBox
        '
        Me.FromNameTextBox.Location = New System.Drawing.Point(165, 329)
        Me.FromNameTextBox.Name = "FromNameTextBox"
        Me.FromNameTextBox.Size = New System.Drawing.Size(100, 25)
        Me.FromNameTextBox.TabIndex = 12
        '
        'ToNameTextBox
        '
        Me.ToNameTextBox.Location = New System.Drawing.Point(165, 385)
        Me.ToNameTextBox.Name = "ToNameTextBox"
        Me.ToNameTextBox.Size = New System.Drawing.Size(100, 25)
        Me.ToNameTextBox.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 388)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "to Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(80, 339)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "from Name"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ToNameTextBox)
        Me.Controls.Add(Me.FromNameTextBox)
        Me.Controls.Add(Me.ViewAccountButton)
        Me.Controls.Add(Me.TransferButton)
        Me.Controls.Add(Me.DepositButton)
        Me.Controls.Add(Me.WithdrawButton)
        Me.Controls.Add(Me.AccountListView)
        Me.Controls.Add(Me.DeleteAccountButton)
        Me.Controls.Add(Me.AddAccountButton)
        Me.Controls.Add(Me.BalanceTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents BalanceTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AddAccountButton As Button
    Friend WithEvents DeleteAccountButton As Button
    Friend WithEvents AccountListView As ListView
    Friend WithEvents DepositButton As Button
    Friend WithEvents WithdrawButton As Button
    Friend WithEvents TransferButton As Button
    Friend WithEvents ViewAccountButton As Button
    Friend WithEvents FromNameTextBox As TextBox
    Friend WithEvents ToNameTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Aid As ColumnHeader
    Friend WithEvents Aname As ColumnHeader
    Friend WithEvents Abalance As ColumnHeader
End Class
