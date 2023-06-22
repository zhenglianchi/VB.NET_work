Public Class Merchant
    Private menu As New List(Of KeyValuePair(Of String, Double))

    Private Sub Merchant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMenu()
        RefreshMenuList()
    End Sub

    Private Sub LoadMenu()
        If IO.File.Exists("menu.txt") Then
            Dim lines() As String = IO.File.ReadAllLines("menu.txt")
            For Each line As String In lines
                Dim parts() As String = line.Split(","c)
                menu.Add(New KeyValuePair(Of String, Double)(parts(0), Double.Parse(parts(1))))
            Next
        End If
    End Sub

    Private Sub RefreshMenuList()
        lstMenu.Items.Clear()
        For Each item As KeyValuePair(Of String, Double) In menu
            lstMenu.Items.Add(New ListViewItem({item.Key, item.Value.ToString()}))
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim name As String = txtName.Text.Trim()
        If String.IsNullOrEmpty(name) Then
            MessageBox.Show("请输入菜品名称！")
            Return
        End If
        Dim price As Double
        If Not Double.TryParse(txtPrice.Text.Trim(), price) Then
            MessageBox.Show("请输入正确的价格！")
            Return
        End If
        Dim newItem As New KeyValuePair(Of String, Double)(name, price)
        For i As Integer = 0 To menu.Count - 1
            If menu(i).Key = newItem.Key Then
                menu(i) = newItem
                RefreshMenuList()
                SaveMenu()
                MessageBox.Show("成功修改菜品信息！")
                Return
            End If
        Next
        menu.Add(newItem)
        RefreshMenuList()
        SaveMenu()
        MessageBox.Show("成功添加新菜品！")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim selectedItem As ListViewItem = Nothing
        If lstMenu.SelectedItems.Count > 0 Then
            selectedItem = lstMenu.SelectedItems(0)
        End If
        If selectedItem IsNot Nothing Then
            For i As Integer = 0 To menu.Count - 1
                If menu(i).Key = selectedItem.SubItems(0).Text Then
                    menu.RemoveAt(i)
                    RefreshMenuList()
                    SaveMenu()
                    MessageBox.Show("成功删除菜品！")
                    Return
                End If
            Next
        Else
            MessageBox.Show("请先选择要删除的菜品！")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveMenu()
        MessageBox.Show("成功保存菜单数据！")
    End Sub

    Private Sub SaveMenu()
        Dim lines(menu.Count - 1) As String
        For i As Integer = 0 To menu.Count - 1
            lines(i) = menu(i).Key & "," & menu(i).Value.ToString()
        Next
        IO.File.WriteAllLines("menu.txt", lines)
    End Sub
End Class