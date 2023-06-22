Imports System.IO

Public Class LoginForm
    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim account As String = AccountTextBox.Text.Trim()
        Dim password As String = PasswordTextBox.Text.Trim()

        ' 检查用户输入的账号和密码是否正确
        If ValidateLogin(account, password) Then
            Dim mainForm As New MainForm(account)
            Me.Hide()
            mainForm.ShowDialog()
            Me.Close()
        Else
            MessageBox.Show("登录失败，请检查账号和密码是否正确！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click
        Dim account As String = AccountTextBox.Text.Trim()
        Dim password As String = PasswordTextBox.Text.Trim()

        ' 检查账号是否已存在
        If IsAccountExists(account) Then
            MessageBox.Show("该账号已被注册，请尝试其他账号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ' 将账号和密码保存到 user.txt 文件中
            Dim line As String = String.Format("{0},{1}", account, password)
            Using writer As New StreamWriter("user.txt", True)
                writer.WriteLine(line)
            End Using

            MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function ValidateLogin(account As String, password As String) As Boolean
        Dim lines As String() = File.ReadAllLines("user.txt")

        For Each line As String In lines
            Dim fields As String() = line.Split(",")
            Dim savedAccount As String = fields(0)
            Dim savedPassword As String = fields(1)

            If account = savedAccount AndAlso password = savedPassword Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function IsAccountExists(account As String) As Boolean
        Dim lines As String() = File.ReadAllLines("user.txt")

        For Each line As String In lines
            Dim fields As String() = line.Split(",")
            Dim savedAccount As String = fields(0)

            If account = savedAccount Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class