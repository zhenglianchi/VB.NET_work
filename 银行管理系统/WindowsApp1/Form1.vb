Public Class Form1
    '定义账户类
    Public Class Account
        Public Property ID As Integer
        Public Property OwnerName As String
        Public Property Balance As Decimal
    End Class

    '定义银行类
    Public Class Bank
        Private Accounts As New List(Of Account)
        Private LastID As Integer = 0

        '添加新账户
        Public Function AddAccount(name As String, balance As Decimal) As Integer
            LastID += 1
            Dim account As New Account With {
                .ID = LastID,
                .OwnerName = name,
                .Balance = balance
            }
            Accounts.Add(account)
            Return LastID
        End Function

        '删除已有账户
        Public Sub DeleteAccount(name As String)
            Dim account = GetAccountByName(name)
            If account IsNot Nothing Then
                Accounts.Remove(account)
            End If
        End Sub

        '获取所有账户
        Public Function GetAllAccounts() As List(Of Account)
            Return Accounts
        End Function

        '根据ID查找账户
        Public Function GetAccountByID(id As Integer) As Account
            For Each account In Accounts
                If account.ID = id Then
                    Return account
                End If
            Next
            Return Nothing
        End Function

        '根据姓名查找账户
        Public Function GetAccountByName(name As String) As Account
            For Each account In Accounts
                If account.OwnerName = name Then
                    Return account
                End If
            Next
            Return Nothing
        End Function

        '存款操作
        Public Sub Deposit(name As String, amount As Decimal)
            Dim account = GetAccountByName(name)
            If account IsNot Nothing Then
                account.Balance += amount
            End If
        End Sub

        '取款操作
        Public Sub Withdraw(name As String, amount As Decimal)
            Dim account = GetAccountByName(name)
            If account IsNot Nothing AndAlso account.Balance >= amount Then
                account.Balance -= amount
            End If
        End Sub

        '转账操作
        Public Sub Transfer(fromName As String, toName As String, amount As Decimal)
            Dim fromAccount = GetAccountByName(fromName)
            Dim toAccount = GetAccountByName(toName)
            If fromAccount IsNot Nothing AndAlso toAccount IsNot Nothing AndAlso fromAccount.Balance >= amount Then
                fromAccount.Balance -= amount
                toAccount.Balance += amount
            End If
        End Sub
    End Class

    Private mybank As New Bank
    Private Function ViewAllAccounts() As Boolean
        '清空现有项
        AccountListView.Items.Clear()
        '获取所有账户
        Dim accounts = mybank.GetAllAccounts()
        '添加每个账户作为新的列表项
        For Each account In accounts
            '创建新的List View Item对象
            Dim newItem As New ListViewItem(account.ID.ToString())
            '添加子项，以显示账户的所有者名称和当前余额
            newItem.SubItems.Add(account.OwnerName)
            newItem.SubItems.Add(account.Balance.ToString())
            '将该项添加到 ListView 控件中
            AccountListView.Items.Add(newItem)
        Next
        Return True '操作成功完成
    End Function
    '添加新账户
    Private Sub AddAccountButton_Click(sender As Object, e As EventArgs) Handles AddAccountButton.Click
        Dim name = NameTextBox.Text
        Dim balance = Decimal.Parse(BalanceTextBox.Text)
        Dim id = mybank.AddAccount(name, balance)
        NameTextBox.Clear()
        BalanceTextBox.Clear()
        MessageBox.Show(String.Format("Account ID: {0}", id))
        ViewAllAccounts()
    End Sub

    '删除已有账户
    Private Sub DeleteAccountButton_Click(sender As Object, e As EventArgs) Handles DeleteAccountButton.Click
        Dim name = NameTextBox.Text
        mybank.DeleteAccount(name)
        NameTextBox.Clear()
        MessageBox.Show(String.Format("Account {0} deleted", name))
        ViewAllAccounts()
    End Sub

    '查看特定账户信息
    Private Sub ViewAccountButton_Click(sender As Object, e As EventArgs) Handles ViewAccountButton.Click
        Dim name = NameTextBox.Text
        Dim account = mybank.GetAccountByName(name)
        If account IsNot Nothing Then
            MessageBox.Show(String.Format("Account ID: {0} Name: {1} Balance: {2}", account.ID, account.OwnerName, account.Balance.ToString("c")))
        Else
            MessageBox.Show(String.Format("Account {0} not found", name))
        End If
        NameTextBox.Clear()
    End Sub

    '存款操作
    Private Sub DepositButton_Click(sender As Object, e As EventArgs) Handles DepositButton.Click
        Dim name = NameTextBox.Text
        Dim amount = Decimal.Parse(BalanceTextBox.Text)
        mybank.Deposit(name, amount)
        MessageBox.Show("Deposit successful")
        NameTextBox.Clear()
        BalanceTextBox.Clear()
        ViewAllAccounts()
    End Sub

    '取款操作
    Private Sub WithdrawButton_Click(sender As Object, e As EventArgs) Handles WithdrawButton.Click
        Dim name = NameTextBox.Text
        Dim amount = Decimal.Parse(BalanceTextBox.Text)
        mybank.Withdraw(name, amount)
        MessageBox.Show("Withdrawal successful")
        NameTextBox.Clear()
        BalanceTextBox.Clear()
        ViewAllAccounts()
    End Sub

    '转账操作
    Private Sub TransferButton_Click(sender As Object, e As EventArgs) Handles TransferButton.Click
        Dim fromName = FromNameTextBox.Text
        Dim toName = ToNameTextBox.Text
        Dim amount = Decimal.Parse(BalanceTextBox.Text)
        mybank.Transfer(fromName, toName, amount)
        MessageBox.Show("Transfer successful")
        FromNameTextBox.Clear()
        ToNameTextBox.Clear()
        BalanceTextBox.Clear()
        ViewAllAccounts()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class