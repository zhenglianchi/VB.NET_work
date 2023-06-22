Public Class Customer
    Private menu As New List(Of KeyValuePair(Of String, Double))
    Private order As New List(Of KeyValuePair(Of String, Double))

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("menu.txt") Then
            Dim lines() As String = IO.File.ReadAllLines("menu.txt")
            For Each line As String In lines
                Dim parts() As String = line.Split(","c)
                menu.Add(New KeyValuePair(Of String, Double)(parts(0), Double.Parse(parts(1))))
            Next
            RefreshMenuList()
        End If
    End Sub

    Private Sub RefreshMenuList()
        lstMenu.Items.Clear()
        For Each item As KeyValuePair(Of String, Double) In menu
            lstMenu.Items.Add(New ListViewItem({item.Key, item.Value.ToString()}))
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim selectedItem As ListViewItem = Nothing
        If lstMenu.SelectedItems.Count > 0 Then
            selectedItem = lstMenu.SelectedItems(0)
        End If
        If selectedItem IsNot Nothing Then
            Dim itemName As String = selectedItem.SubItems(0).Text
            Dim itemPrice As Double = Double.Parse(selectedItem.SubItems(1).Text)
            order.Add(New KeyValuePair(Of String, Double)(itemName, itemPrice))
            RefreshOrderList()
        Else
            MessageBox.Show("请先选择要添加的菜品！")
        End If
    End Sub

    Private Sub RefreshOrderList()
        lstOrder.Items.Clear()
        For Each item As KeyValuePair(Of String, Double) In order
            lstOrder.Items.Add(New ListViewItem({item.Key, item.Value.ToString()}))
        Next
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim selectedItem As ListViewItem = Nothing
        If lstOrder.SelectedItems.Count > 0 Then
            selectedItem = lstOrder.SelectedItems(0)
        End If
        If selectedItem IsNot Nothing Then
            Dim itemName As String = selectedItem.SubItems(0).Text
            For i As Integer = 0 To order.Count - 1
                If order(i).Key = itemName Then
                    order.RemoveAt(i)
                    RefreshOrderList()
                    Return
                End If
            Next
        Else
            MessageBox.Show("请先选择要删除的菜品！")
        End If
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim totalCost As Double = 0
        For Each item As KeyValuePair(Of String, Double) In order
            totalCost += item.Value
        Next
        MessageBox.Show(String.Format("您一共消费了 {0:0.00} 元。", totalCost))
        RefreshOrderList()
    End Sub
End Class