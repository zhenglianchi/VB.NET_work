Imports System.IO

Public Class LoginForm
    Private ReadOnly _accountFilePath As String = "account.txt"
    Private _rememberedAccount As String = ""

    Private Function LoadAccounts() As List(Of Account)
        Dim accounts As New List(Of Account)

        Try
            If Not File.Exists(_accountFilePath) Then
                Return accounts
            End If

            Using reader As New StreamReader(_accountFilePath)
                While Not reader.EndOfStream
                    accounts.Add(Account.FromString(reader.ReadLine()))
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("无法读取账户信息文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return accounts
    End Function

    Private Sub SaveAccount(account As Account)
        Using writer As New StreamWriter(_accountFilePath, True)
            writer.WriteLine(account.ToString())
        End Using
    End Sub

    Private Sub Login()
        Dim accounts As List(Of Account) = LoadAccounts()

        Dim currentAccount As Account = Nothing

        For Each account In accounts
            If account.Username = txtUsername.Text AndAlso account.Password = txtPassword.Text Then
                currentAccount = account
                Exit For
            End If
        Next

        If currentAccount Is Nothing Then
            MessageBox.Show("用户名或密码错误！", "登录失败")
            Return
        End If

        ' 更新 _rememberedAccount 变量
        _rememberedAccount = String.Format("{0},{1},{2}", txtUsername.Text, txtPassword.Text, currentAccount.Type)

        MessageBox.Show("登录成功")
        Me.Hide()
        If currentAccount.Type = "商家" Then
            Merchant.ShowDialog()
        Else
            Customer.ShowDialog()
        End If
        Me.Close()
    End Sub

    Private Sub Register()
        Dim username As String = InputBox("请输入用户名：")
        If String.IsNullOrEmpty(username) Then
            Return
        End If

        Dim password As String = InputBox("请输入密码：")
        If String.IsNullOrEmpty(password) Then
            Return
        End If

        Dim type As String = ""
        Do Until type = "消费者" Or type = "商家"
            type = InputBox("请选择用户类型（消费者/商家）：")
            If String.IsNullOrEmpty(type) Then
                Return
            End If
        Loop

        Dim accounts As List(Of Account) = LoadAccounts()

        For Each account In accounts
            If account.Username = username Then
                MessageBox.Show("该用户已存在！", "注册失败")
                Return
            End If
        Next

        SaveAccount(New Account(username, password, type))
        MessageBox.Show("注册成功！", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login()
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Register()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim accounts As List(Of Account) = LoadAccounts()

        If Not String.IsNullOrEmpty(_rememberedAccount) Then
            Dim parts() As String = _rememberedAccount.Split(",")
            txtUsername.Text = parts(0)
            txtPassword.Text = parts(1)
        End If
    End Sub
End Class

Public Class Account
    Public Property Username As String
    Public Property Password As String
    Public Property Type As String

    Public Sub New(username As String, password As String, type As String)
        Me.Username = username
        Me.Password = password
        Me.Type = type
    End Sub

    Public Shared Function FromString(text As String) As Account
        Dim parts() As String = text.Split(",")
        If parts.Length <> 3 Then
            Throw New FormatException("账户信息格式不正确！")
        End If
        Return New Account(parts(0), parts(1), parts(2))
    End Function
End Class