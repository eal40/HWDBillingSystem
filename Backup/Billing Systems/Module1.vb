Module Module1
    Public usertype As String
    Public userId As String
    Public sql As String
    Public dt As New DataTable
    Public da As New OleDb.OleDbDataAdapter
    Public Function myDBmodule() As OleDb.OleDbConnection
        Return New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & _
                                         Application.StartupPath & "\db_billing.accdb")
    End Function
    Dim con As OleDb.OleDbConnection = myDBmodule()
    Public Sub myselectstatements(ByVal sql As String, ByVal dtg As DataGridView)
        Try
            con.Open()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, con)
            Dim dt As New DataTable
            da.Fill(dt)
            dtg.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        ' Form1.TextBox1.Text = Total().ToString("c")
    End Sub
    Public Sub mysql(ByVal sql As String)
        Try
            con.Open()
            da = New OleDb.OleDbDataAdapter(sql, con)
            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        con.Close()
    End Sub
    Public Sub mycbo(ByVal sql As String, ByVal cbo As ComboBox)
        Try
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, con)
            Dim ds As New DataSet
            da.Fill(ds, "db_billing")
            With cbo
                .DataSource = ds.Tables(0)
                .ValueMember = "cuscode"
                .DisplayMember = "cusfname"
            End With

         
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub mycbotax(ByVal sql As String, ByVal cbo As ComboBox)
        Try
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, con)
            Dim ds As New DataSet
            da.Fill(ds, "db_billing")
            cbo.DataSource = ds.Tables(0)
            cbo.ValueMember = "taxable"
            cbo.DisplayMember = "cusfname"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub janAutoNumber(ByVal sql As String)
        Try
            con.Open()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(sql, con)
            Dim dt As New DataTable
            da.Fill(dt)
            Form1.TxtAddCus_Code.Text = dt.Rows.Count & "code"
            Form1.TxtCreateInvoice_InvoiceNum.Text = "000" & dt.Rows.Count - 1
            Files.TxtAddCus_Code.Text = dt.Rows.Count & "code"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub
    Public Sub loginSub(ByVal username As TextBox, ByVal pass As TextBox)
        Try
            con.Open()
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter _
            ("SELECT * FROM tbluser WHERE username='" & username.Text & "' and pass='" & pass.Text & "'", con)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                usertype = dt.Rows(0).Item("type")
                userId = dt.Rows(0).Item("user_id")
                MsgBox("Welcome " & usertype)
                Form1.lnkLogout.Text = "Logout " & usertype
                Form1.GroupBox3.Visible = False

                If usertype = "Staff" Then
                    With Form1.TabControl1.TabPages
                        ' .Add(Form1.TabItems)
                        .Add(Form1.TabInvoie)
                        .Add(Form1.TabCustomers)
                        '  .Add(Form1.TabStaff)
                        ' .Add(Form1.TabSettings)
                        .Add(Form1.TabReports)
                        .Add(Form1.TabMyAccount)
                    End With
                Else
                    With Form1.TabControl1.TabPages
                        ' .Add(Form1.TabItems)
                        .Add(Form1.TabInvoie)
                        .Add(Form1.TabCustomers)
                        .Add(Form1.TabStaff)
                        .Add(Form1.TabSettings)
                        .Add(Form1.TabReports)
                        .Add(Form1.TabMyAccount)
                    End With
                End If

                smartClear(Form1.GroupBox3)

            Else
                MsgBox("Account does not exist! Please contact Administrator", MsgBoxStyle.Exclamation, "Not Exist")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub
End Module
