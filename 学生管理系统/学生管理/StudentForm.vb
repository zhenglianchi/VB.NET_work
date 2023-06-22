Imports System.IO

Public Class StudentForm
    Private students As New List(Of Student)()

    Private Sub StudentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 加载学生信息到ListView控件
        LoadStudentInfo()
    End Sub

    Private Sub LoadStudentInfo()
        ' 从文件中读取学生信息
        students.Clear()
        Dim lines As String() = File.ReadAllLines("student.txt")
        For Each line As String In lines
            Dim fields As String() = line.Split(","c)
            If fields.Length = 3 Then
                Dim studentNo As String = fields(0).Trim()
                Dim name As String = fields(1).Trim()
                Dim major As String = fields(2).Trim()
                students.Add(New Student(studentNo, name, major))
            End If
        Next

        ' 清空ListView控件的项
        StudentListView.Items.Clear()

        ' 添加学生信息到ListView控件
        For Each student As Student In students
            Dim item As New ListViewItem(student.StudentNo)
            item.SubItems.Add(student.Name)
            item.SubItems.Add(student.Major)

            StudentListView.Items.Add(item)
        Next
    End Sub

    Private Sub SaveStudentInfo()
        ' 将学生信息保存到文件
        Using writer As New StreamWriter("student.txt")
            For Each student As Student In students
                writer.WriteLine(String.Format("{0},{1},{2}", student.StudentNo, student.Name, student.Major))
            Next
        End Using
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        ' 弹出消息框并输入新学生信息
        Dim studentNo As String = InputBox("请输入学生学号：")
        Dim name As String = InputBox("请输入学生姓名：")
        Dim major As String = InputBox("请输入学生班级：")

        ' 检查是否输入了有效的学生信息
        If String.IsNullOrEmpty(studentNo) OrElse String.IsNullOrEmpty(name) OrElse String.IsNullOrEmpty(major) Then
            MessageBox.Show("学生信息输入不完整，请重新输入！", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 创建学生对象并将输入的学生信息赋值给对象的属性
        Dim newStudent As New Student(studentNo, name, major)
        students.Add(newStudent)

        ' 将学生信息保存到文件
        SaveStudentInfo()

        ' 添加新学生信息到ListView控件
        Dim item As New ListViewItem(newStudent.StudentNo)
        item.SubItems.Add(newStudent.Name)
        item.SubItems.Add(newStudent.Major)
        StudentListView.Items.Add(item)

        MessageBox.Show("成功添加学生：" & newStudent.Name, "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If StudentListView.SelectedItems.Count > 0 Then
            Dim selectedStudentNo As String = StudentListView.SelectedItems(0).Text
            Dim result As DialogResult = MessageBox.Show("确认删除学生信息？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' 移除选中的学生信息
                Dim deleteIndex As Integer = students.FindIndex(Function(student) student.StudentNo = selectedStudentNo)
                If deleteIndex >= 0 Then
                    students.RemoveAt(deleteIndex)

                    ' 更新文件中的学生信息
                    SaveStudentInfo()

                    ' 从ListView中移除选中的项
                    StudentListView.SelectedItems(0).Remove()
                End If
            End If
        Else
            MessageBox.Show("请选择要删除的学生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        If StudentListView.SelectedItems.Count > 0 Then
            Dim selectedStudentNo As String = StudentListView.SelectedItems(0).Text

            ' 查找选中学生的索引
            Dim editIndex As Integer = students.FindIndex(Function(student) student.StudentNo = selectedStudentNo)
            If editIndex >= 0 Then
                Dim editedStudent As Student = students(editIndex)

                ' 弹出消息框并输入编辑后的学生信息
                Dim newName As String = InputBox("请输入学生姓名：", , editedStudent.Name)
                Dim newMajor As String = InputBox("请输入学生班级：", , editedStudent.Major)

                ' 检查是否输入了有效的学生信息
                If String.IsNullOrEmpty(newName) OrElse String.IsNullOrEmpty(newMajor) Then
                    MessageBox.Show("学生信息输入不完整，请重新输入！", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' 更新学生信息
                editedStudent.Name = newName
                editedStudent.Major = newMajor

                ' 更新文件中的学生信息
                SaveStudentInfo()

                ' 更新ListView中对应的项
                StudentListView.SelectedItems(0).SubItems(1).Text = newName
                StudentListView.SelectedItems(0).SubItems(2).Text = newMajor

                MessageBox.Show("成功编辑学生：" & editedStudent.Name, "编辑成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("请选择要编辑的学生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Dim keyword As String = InputBox("请输入要查找的学生学号：").Trim()

        ' 根据关键字搜索学生姓名，并在ListView中进行筛选显示
        If Not String.IsNullOrEmpty(keyword) Then
            For Each item As ListViewItem In StudentListView.Items
                If Not item.SubItems(0).Text.Contains(keyword) Then
                    item.Remove()
                End If
            Next
        Else
            LoadStudentInfo() ' 搜索关键字为空时，重新加载所有学生信息
        End If
    End Sub
End Class

Public Class Student
    Public Property StudentNo As String
    Public Property Name As String
    Public Property Major As String

    Public Sub New(studentNo As String, name As String, major As String)
        Me.StudentNo = studentNo
        Me.Name = name
        Me.Major = major
    End Sub
End Class