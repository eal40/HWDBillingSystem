Public Class Files
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            sql = "SELECT c.cuscode as [code] ,c.cusfname as [customer name] , c.cuslname as [last name] ," _
                & "c.cusaddress as [address] FROM tblcustomer as c WHERE  c.status = 'PAID' AND actions='Active'" _
                & " and c.cuscode Like '" & TextBox1.Text & "%'"
            myselectstatements(sql, DataGridView1)
            '''''''''''''''''''''''''''
            datacolumsvisible(DataGridView1)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        GroupBox1.Show()
        ''''''''''''''''''''''''''''''''
        DataGridView1.Hide()
        sql = "SELECT * FROM tblcustomer"
        janAutoNumber(sql)
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            'If DataGridView1.CurrentRow.Cells(8).Value.ToString() = Nothing Then
            '    datagridselect()
            'Else
            '    datagridselect()
            '    Form1.TxtCreateInvoice_InvoiceNum.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString()
            'End If

            Form1.CboCreateInvoice_Customer.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
            Me.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

  
   
    Private Sub BtnAddCus_Save2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCus_Save2.Click
        Try
            sql = "INSERT INTO tblcustomer (cusfname,cuslname,cusnckname," _
                & "cusaddress,phone,mobile,  cuscode,status,actions)" _
                & "VALUES ('" & TxtAddCus_Fname.Text & "' , '" & TxtAddCus_Lname.Text _
                & "','" & TxtAddCus_NickName.Text & "','" & TxtAddCus_Address.Text _
                & "','" & TxtAddCus_Phone.Text & "','" & TxtAddCus_Mobile.Text & "','" & _
                TxtAddCus_Code.Text & "','" & "open" & "','Active')"
            mysql(sql)
            ''''''''''''''''''''''''''''
            ''sql = "INSERT INTO tblcreateinvoice (cuscode)" _
            ''    & " VALUES ('" & TxtAddCus_Code.Text & "')"
            ''mysql(sql)
            '''''''''''''''''''''''''
            ''sql = "INSERT INTO tblsummary (cuscode,status,credit)" _
            ''   & " VALUES ('" & TxtAddCus_Code.Text & "','" & "open" & "','" & "0" & "')"
            ''mysql(sql)
            MsgBox("Customer Save", , "Save")
            '''''''''''''''''''''''''''''''''''''
            smartClear(GroupBox1)
            ''''''''''''''''
            sql = "SELECT * FROM tblcustomer"
            janAutoNumber(sql)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Hide()
        Call TextBox1_TextChanged(sender, e)
        DataGridView1.Show()
    End Sub

    Private Sub Files_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label35.Click

    End Sub

    Private Sub Label38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label38.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
