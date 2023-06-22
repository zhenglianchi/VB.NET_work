Imports System.IO

Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 窗体加载时初始化账户信息文件(account.txt)
        InitializeAccountFile()
    End Sub

    Private Sub InitializeAccountFile()
        Dim accountFilePath As String = "account.txt"

        ' 检查账户信息文件是否存在，如果不存在则创建文件
        If Not File.Exists(accountFilePath) Then
            File.Create(accountFilePath).Dispose()
        End If
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim accountFilePath As String = "account.txt"
        Dim username As String = UsernameTextBox.Text.Trim()
        Dim password As String = PasswordTextBox.Text.Trim()

        ' 读取账户信息文件中的账户信息
        Dim accountInfo As String = File.ReadAllText(accountFilePath)

        ' 验证用户名和密码是否匹配
        If accountInfo.Contains(username & "," & password) Then
            ' 登录成功，显示学生管理页面
            Dim studentForm As New StudentForm()
            Me.Hide()
            studentForm.ShowDialog()
            Me.Close()
        Else
            ' 登录失败，显示错误提示
            MessageBox.Show("用户名或密码错误，请重新输入！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click
        Dim accountFilePath As String = "account.txt"
        Dim username As String = InputBox("请输入要注册的用户名：")
        Dim password As String = InputBox("请输入要注册的密码：")

        ' 检查用户名和密码是否为空
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("用户名和密码不能为空！", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 读取账户信息文件中的账户信息
        Dim accountInfo As String() = File.ReadAllLines(accountFilePath)

        ' 验证账户是否已存在
        Dim isExistingUser As Boolean = False
        For Each accountLine As String In accountInfo
            Dim accountParts As String() = accountLine.Split(","c)
            If accountParts.Length = 2 AndAlso accountParts(0) = username Then
                isExistingUser = True
                Exit For
            End If
        Next

        ' 验证账户是否已存在，或者密码与已存在账户的密码相同
        If isExistingUser Then
            MessageBox.Show("该用户名已被注册，请尝试其他用户名！", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' 注册成功，将新账户信息追加写入账户信息文件
            File.AppendAllText(accountFilePath, username & "," & password & Environment.NewLine)
            MessageBox.Show("注册成功！", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
