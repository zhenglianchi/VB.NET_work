Imports System.IO

Public Class MainForm
    Private account As String

    Public Sub New(account As String)
        InitializeComponent()
        Me.account = account
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCourses()
        LoadSelectedCourses()
    End Sub

    Private Sub LoadCourses()
        ' 从 courses.txt 文件中读取所有课程信息
        Dim lines As String() = File.ReadAllLines("courses.txt")

        For Each line As String In lines
            Dim fields As String() = line.Split(",")
            Dim courseName As String = fields(0)
            Dim teacherName As String = fields(1)
            Dim selected As Boolean = IsCourseSelected(courseName)
            Dim selectedCount As Integer = GetSelectedCourseCount(courseName)

            Dim item As New ListViewItem({courseName, teacherName, selected.ToString(), selectedCount.ToString()})
            CoursesListView.Items.Add(item)
        Next
    End Sub

    Private Sub LoadSelectedCourses()
        ' 根据当前账户从 selected_courses.txt 文件中读取已选课程信息
        Dim lines As String() = File.ReadAllLines("selected_courses.txt")

        For Each line As String In lines
            Dim fields As String() = line.Split(",")
            Dim savedAccount As String = fields(0)
            Dim courseName As String = fields(1)
            Dim teacherName As String = fields(2)

            If account = savedAccount Then
                Dim item As New ListViewItem({courseName, teacherName})
                SelectedCoursesListView.Items.Add(item)

                ' 更新课程信息列表中的已选人数和是否已选
                For Each listItem As ListViewItem In CoursesListView.Items
                    If listItem.Text = courseName Then
                        listItem.SubItems(2).Text = "True"
                        listItem.SubItems(3).Text = GetSelectedCourseCount(courseName).ToString()
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

    Private Function IsCourseSelected(courseName As String) As Boolean
        ' 从 selected_courses.txt 文件中检查当前账户是否已选该课程
        Dim lines As String() = File.ReadAllLines("selected_courses.txt")

        For Each line As String In lines
            Dim fields As String() = line.Split(",")
            Dim savedAccount As String = fields(0)
            Dim savedCourseName As String = fields(1)

            If account = savedAccount AndAlso courseName = savedCourseName Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function GetSelectedCourseCount(courseName As String) As Integer
        ' 从 selected_courses.txt 文件中获取已选该课程的人数
        Dim lines As String() = File.ReadAllLines("selected_courses.txt")
        Dim count As Integer = 0

        For Each line As String In lines
            Dim fields As String() = line.Split(",")
            Dim savedCourseName As String = fields(1)

            If courseName = savedCourseName Then
                count += 1
            End If
        Next

        Return count
    End Function

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        If CoursesListView.SelectedItems.Count > 0 Then
            Dim selectedCourseName As String = CoursesListView.SelectedItems(0).Text

            If Not IsCourseSelected(selectedCourseName) Then
                ' 将当前账户对应的已选课程信息保存到 selected_courses.txt 文件中
                Dim line As String = String.Format("{0},{1},{2}", account, selectedCourseName, CoursesListView.SelectedItems(0).SubItems(1).Text)
                Using writer As New StreamWriter("selected_courses.txt", True)
                    writer.WriteLine(line)
                End Using

                ' 更新已选课程列表
                Dim item As New ListViewItem({selectedCourseName, CoursesListView.SelectedItems(0).SubItems(1).Text})
                SelectedCoursesListView.Items.Add(item)

                ' 更新课程信息列表中的已选人数和是否已选
                For Each listItem As ListViewItem In CoursesListView.Items
                    If listItem.Text = selectedCourseName Then
                        listItem.SubItems(2).Text = "True"
                        listItem.SubItems(3).Text = GetSelectedCourseCount(selectedCourseName).ToString()
                        Exit For
                    End If
                Next
            Else
                MessageBox.Show("该课程已被选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub DropButton_Click(sender As Object, e As EventArgs) Handles DropButton.Click
        If SelectedCoursesListView.SelectedItems.Count > 0 Then
            Dim droppedCourseName As String = SelectedCoursesListView.SelectedItems(0).Text

            ' 从 selected_courses.txt 文件中移除当前账户对应的已选课程信息
            Dim lines As List(Of String) = File.ReadAllLines("selected_courses.txt").ToList()

            For i As Integer = lines.Count - 1 To 0 Step -1
                Dim fields As String() = lines(i).Split(",")
                Dim savedAccount As String = fields(0)
                Dim courseName As String = fields(1)

                If account = savedAccount AndAlso courseName = droppedCourseName Then
                    lines.RemoveAt(i)
                    Exit For
                End If
            Next

            File.WriteAllLines("selected_courses.txt", lines.ToArray())

            ' 更新已选课程列表
            SelectedCoursesListView.SelectedItems(0).Remove()

            ' 更新课程信息列表中的已选人数和是否已选
            For Each listItem As ListViewItem In CoursesListView.Items
                If listItem.Text = droppedCourseName Then
                    listItem.SubItems(2).Text = "False"
                    listItem.SubItems(3).Text = GetSelectedCourseCount(droppedCourseName).ToString()
                    Exit For
                End If
            Next
        End If
    End Sub
End Class