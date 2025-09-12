Module Module2
    Public Sub smartClear(ByVal grp As Object)
        For Each txt As Control In grp.controls
            If txt.GetType Is GetType(TextBox) Then
                txt.Text = Nothing
            End If
        Next
    End Sub
   
    Public Sub invoiceclear()
        Form1.TxtCreateInvoice_Description.Clear()
        Form1.TxtCreateInvoice_Quantity.Clear()
        Form1.TxtcreateInvoice_total1.Clear()
        Form1.TxtCreateInvoice_Remarks.Text = ""
        Form1.TxtCreateInvoice_SubTotal.Clear()
        Form1.TxtCreateInvoice_Totals.Clear()
        Form1.TxtCreateInvoice_AmountDue.Clear()
        Form1.DtpCreateInvoice_DueDate.Text = Now
        Form1.DtpCreateInvoice_InvoiceDate.Text = Now
        Form1.CboCreateInvoice_Customer.Text = "---Please Select Customer---"
        Form1.TxtCreateInvoice_UnitPrice.Clear()
        Form1.TxtCreateInvoice_Discount.Text = ""
        Form1.ChkCreateInvoice_Taxable.Checked = False
        Form1.TxtCreateInvoice_Salestax.Text = Nothing
    End Sub
    Public Sub datacolumsvisible(ByVal dtg As DataGridView)
        dtg.Rows(0).Visible = False
        dtg.Columns.Item(4).Visible = False
        'Files.DataGridView1.Columns.Item(5).Visible = False
        dtg.Columns.Item(6).Visible = False
        dtg.Columns.Item(7).Visible = False
        dtg.Columns.Item(8).Visible = False
    End Sub
    'Public Sub hideall_pnl()
    '    Form1.Pnl_OpenInvoice.Hide()
    '    Form1.Pnl_CreateInvioce.Hide()
    '    Form1.Pnl_InvoiceReports.Hide()
    '    Form1.Pnl_PaymentsReports.Hide()
    '    Form1.Pnl_TaxReports.Hide()
    '    Form1.Pnl_AddCustomer.Hide()
    '    Form1.Pnl_EnterPayment.Hide()
    '    Form1.Pnl_ManageCustomer.Hide()
    'End Sub
    'Public Sub datagridselect()
    '    Form1.CboCreateInvoice_Customer.Text = Files.DataGridView1.CurrentRow.Cells(4).Value.ToString()
    '    Form1.txtCreateInvoice_status.Text = Files.DataGridView1.CurrentRow.Cells(5).Value.ToString()
    '    Form1.DtpCreateInvoice_DueDate.Text = Files.DataGridView1.CurrentRow.Cells(6).Value.ToString()
    '    Form1.DtpCreateInvoice_InvoiceDate.Text = Files.DataGridView1.CurrentRow.Cells(7).Value.ToString()
    'End Sub
    Public Sub dtg_img_show_del(ByVal dtg As DataGridView)
        ''''''''''''''''''''''''''
        Dim img As New DataGridViewCheckBoxColumn
        'Dim inimg As Image = Image.FromFile("c:\" & Application.StartupPath & "\dat")
        'Dim inimg As Image = Image.FromHbitmap("c:\" & Application.StartupPath & "\dat")
        dtg.Columns.Add(img)
        img.HeaderText = ""
        img.Name = "img"
        ''''''''''''''''''''''''''''''
    End Sub
    Public Sub dtg_btn_show_del(ByVal grid As DataGridView)
        Dim btn As New DataGridViewButtonColumn()
        grid.Columns.Add(btn)
        btn.HeaderText = "delete"
        btn.Text = "delete"
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
        Exit Sub
    End Sub
    Public Sub InsertCustomer()

    End Sub
End Module
