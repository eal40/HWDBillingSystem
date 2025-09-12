Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Public Class Form1
    Private Sub BtnAddCus_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCus_Save.Click
        Try
            If lbladdcus.Text = "Add Customer" Then
                sql = "INSERT INTO tblcustomer (cusfname,cuslname,cusnckname," _
                   & "cusaddress,phone ,mobile, cuscode,status,actions)" _
                   & "VALUES ('" & TxtAddCus_Fname.Text & "' , '" & TxtAddCus_Lname.Text _
                   & "','" & TxtAddCus_NickName.Text & "','" & TxtAddCus_Address.Text _
                   & "','" & TxtAddCus_Phone.Text & "','" & TxtAddCus_Mobile.Text & _
                   "','" & TxtAddCus_Code.Text & "','" & "open" & "','Active')"
                mysql(sql)
                MsgBox("Customer Save", , "Save")
            Else
                sql = "UPDATE tblcustomer SET cusfname='" & TxtAddCus_Fname.Text & _
                "',cuslname='" & TxtAddCus_Lname.Text & "',cusnckname='" & TxtAddCus_NickName.Text & _
                "'," & "cusaddress='" & TxtAddCus_Address.Text & "',phone='" & TxtAddCus_Phone.Text & _
                "',mobile='" & TxtAddCus_Mobile.Text & "' WHERE cuscode='" & TxtAddCus_Code.Text & "'"
                mysql(sql)
                MsgBox("Customer has been updated.", , "Update")
                lbladdcus.Text = "Add Customer"
            End If
         

            smartClear(Pnl_AddCustomer)
            '''''''''''''''''''''''''
            sql = "SELECT * FROM tblcustomer"
            janAutoNumber(sql)

            'lbladdcus.Text = "Add Customer"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tls_addcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tls_addcustomer.Click
        Try
            Pnl_EnterPayment.Dock = DockStyle.None
            Pnl_EnterPayment.SendToBack()
            Pnl_ManageCustomer.Dock = DockStyle.None
            Pnl_ManageCustomer.SendToBack()
            Pnl_AddCustomer.BringToFront()
            Pnl_AddCustomer.Dock = DockStyle.Fill


            smartClear(Pnl_AddCustomer)
            '''''''''''''''''''''''''''''''''
            sql = "SELECT * FROM tblcustomer"
            janAutoNumber(sql)
            '''''''''''''''''''''''''''''''''
            lbladdcus.Text = "Add Customer"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub BtnCreateInvioce_SearchCus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateInvioce_SearchCus.Click

        Try
            sql = "SELECT c.cuscode as [code] ,c.cusfname as [customer name] , c.cuslname as [last name] ," _
                & "c.cusaddress as [address] FROM tblcustomer as c WHERE  c.status = 'PAID' AND actions='Active'"
            myselectstatements(sql, Files.DataGridView1)
            ''''''''''''''''''''''''
            ' datacolumsvisible(Files.DataGridView1)
            Files.Show()
        Catch ex As Exception
            MsgBox(ex.Message & "All customer are not paying yet", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub BtnCreateInvioce_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateInvioce_Save.Click
        Try
            'If CboCreateInvoice_Customer.Text = "---Please Select Customer---" Then
            '    MsgBox("Select Customer First", MsgBoxStyle.Exclamation, "Select")
            'Else
            sql = "INSERT INTO tblcreateinvoice " & _
                "(invnum,invdate,invdue,description,quantity,unitprice,unit" & _
                ",discount,total1,taxable,remarks,cuscode ) VALUES ('" & TxtCreateInvoice_InvoiceNum.Text & _
                "','" & DtpCreateInvoice_InvoiceDate.Text & "','" & DtpCreateInvoice_DueDate.Text & _
                "','" & TxtCreateInvoice_Description.Text & "','" & TxtCreateInvoice_Quantity.Text & _
                "','" & TxtCreateInvoice_UnitPrice.Text & "','" & TxtCreateInvoice_Unit.Text & _
                "','" & TxtCreateInvoice_Discount.Text & "','" & TxtcreateInvoice_total1.Text & _
                "','" & ChkCreateInvoice_Taxable.Checked & "','" & TxtCreateInvoice_Remarks.Text & _
                "','" & CboCreateInvoice_Customer.SelectedValue.ToString & "')"
            mysql(sql)

            sql = "INSERT INTO tblsummary  (subtotal,salestax,total2,amountdue,status,invnum,cuscode,credit) " & _
            "VALUES ('" & TxtCreateInvoice_SubTotal.Text & "','" & TxtCreateInvoice_Salestax.Text & _
            "','" & TxtCreateInvoice_Totals.Text & "','" & TxtCreateInvoice_AmountDue.Text & _
            "','pay now','" & TxtCreateInvoice_InvoiceNum.Text & _
            "','" & CboCreateInvoice_Customer.SelectedValue.ToString & "','0')"
            mysql(sql)

            sql = "UPDATE tblcustomer SET  status = 'pay now' WHERE cuscode = '" & CboCreateInvoice_Customer.SelectedValue.ToString & "'"
            mysql(sql)
            MsgBox("invoice issued", , "invoice")

            invoiceclear()
            sql = "SELECT * FROM tblcreateinvoice"
            janAutoNumber(sql)
            'End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TxtCreateInvoice_SubTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreateInvoice_SubTotal.TextChanged
        Try
            TxtCreateInvoice_Totals.Text = TxtCreateInvoice_SubTotal.Text
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCreateInvoice_Quantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreateInvoice_Quantity.TextChanged
        Try
            TxtcreateInvoice_total1.Text = (TxtCreateInvoice_Quantity.Text)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TxtCreateInvoice_UnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreateInvoice_UnitPrice.TextChanged
        Try
            TxtcreateInvoice_total1.Text = TxtCreateInvoice_Quantity.Text * Convert.ToDouble(TxtCreateInvoice_UnitPrice.Text)
            TxtcreateInvoice_total1.Text = TxtcreateInvoice_total1.Text - Convert.ToDouble(Val(TxtCreateInvoice_Discount.Text)) * Convert.ToDouble(TxtcreateInvoice_total1.Text / 100)
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCreateInvoice_Discount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreateInvoice_Discount.TextChanged

        Try
            TxtcreateInvoice_total1.Text = TxtCreateInvoice_Quantity.Text * Convert.ToDouble(TxtCreateInvoice_UnitPrice.Text)
            TxtcreateInvoice_total1.Text = TxtcreateInvoice_total1.Text - Convert.ToDouble(Val(TxtCreateInvoice_Discount.Text)) * Convert.ToDouble(TxtcreateInvoice_total1.Text / 100)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ChkCreateInvoice_Taxable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCreateInvoice_Taxable.CheckedChanged
        Try
            If ChkCreateInvoice_Taxable.CheckState = CheckState.Checked Then
                TxtCreateInvoice_Salestax.Text = TxtcreateInvoice_total1.Text * Convert.ToDouble(0.12)
            Else
                TxtCreateInvoice_Salestax.Text = Nothing
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TxtCreateInvoice_Salestax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreateInvoice_Salestax.TextChanged
        Try
            TxtCreateInvoice_Totals.Text = TxtCreateInvoice_SubTotal.Text + Convert.ToDouble(Val(TxtCreateInvoice_Salestax.Text))
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCreateInvoice_Totals_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreateInvoice_Totals.TextChanged
        Try
            TxtCreateInvoice_AmountDue.Text = TxtCreateInvoice_Totals.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtcreateInvoice_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtcreateInvoice_total1.TextChanged
        Try
            TxtCreateInvoice_SubTotal.Text = TxtcreateInvoice_total1.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub tls_invoiceReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tls_invoiceReports.Click
        Try
            Pnl_InvoiceReports.Visible = True
            Pnl_InvoiceReports.Dock = DockStyle.Fill
            Pnl_InvoiceReports.BringToFront()

            ' Pnl_TaxReports.Visible = False
            Pnl_TaxReports.Dock = DockStyle.None

            'Pnl_PaymentsReports.Visible = False
            Pnl_PaymentsReports.Dock = DockStyle.None


            ''''''''''''''''''
            ''''''''''''''''''''''
            sql = "SELECT * FROM tblcustomer"
            mycbo(sql, CboInvoiceReport_AllCus)
            CboInvoiceReport_AllCus.Text = "All Customer"
            ''''''''''''''''''''''''''''''

            sql = " SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name]  ,i.invnum as " _
                & " [Invoice Number] ,i.invdate as [Invoice Date],i.invdue as " _
                & "[Due Date],s.total2 as [Amount(pesos)],  paymentdate as [Payment Date] ," _
                & "s.status as [Status]  FROM tblcustomer c,tblcreateinvoice " _
                & "i,tblsummary s where c.cuscode=i.cuscode and i.invnum = s.invnum "
            myselectstatements(sql, DtgInvoiceReport_ViewAll)
            'Dim tot As Integer = 0

            'For i As Integer = 0 To DtgInvoiceReport_ViewAll.RowCount - 1

            '    tot += DtgInvoiceReport_ViewAll.Rows(i).Cells(4).Value
            'Next

            'If tot = 0 Then

            '    MessageBox.Show("No Records Found")

            'End If

            '''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DtpInvoiceReport_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpInvoiceReport_From.ValueChanged
        Try




            If DtpInvoiceReport_From.Text = "" Then
                MsgBox("no query")
            Else
                sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                    & ",i.invdate as [Invoice date],i.invdue as [Due Date]," _
                    & "s.total2 as [Amount] ,  paymentdate as [Payment Date] , " _
                    & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                    & " c.cuscode=i.cuscode and i.invnum = s.invnum and i.invdate like '%" _
                    & DtpInvoiceReport_From.Text & "%'"
                myselectstatements(sql, DtgInvoiceReport_ViewAll)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DtpInvoiceReport_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpInvoiceReport_To.ValueChanged
        Try
            If DtpInvoiceReport_From.Text = "" Then
                MsgBox("no query")
            Else
                sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                    & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                    & "s.total2 as [Amount] , paymentdate as [Payment Date] , " _
                    & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                    & " c.cuscode=i.cuscode and i.invnum = s.invnum and i.invdue like '%" _
                    & DtpInvoiceReport_To.Text & "%'"
                myselectstatements(sql, DtgInvoiceReport_ViewAll)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try

            sql = " SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as " _
                    & " [Invoice Number] ,i.invdate as [Invoice date],i.invdue as " _
                    & "[Due Date],s.total2 as [Amount],  paymentdate as [Payment Date] , " _
                    & "s.status as [status]  FROM tblcustomer c,tblcreateinvoice " _
                    & "i,tblsummary s where c.cuscode=i.cuscode and i.invnum = s.invnum "
            myselectstatements(sql, DtgInvoiceReport_ViewAll)
            CboInvoiceReport_AllCus.Text = "All Customer"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tls_enterpay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tls_enterpay.Click
        Try

            Pnl_AddCustomer.Dock = DockStyle.None
            Pnl_ManageCustomer.Dock = DockStyle.None
            Pnl_EnterPayment.Dock = DockStyle.Fill
            Pnl_EnterPayment.BringToFront()
            '''''''''''''''''''''
            sql = "SELECT * FROM tblcustomer WHERE status = 'pay now'"
            mycbo(sql, CboEnterPay_Customer)
            CboEnterPay_Customer.Text = "---Select Customer----"
            DtgEnterPay_InvoiceNumAmount.Columns.Clear()
            LblEnterPay_TotalAmount.Text = "0"
            LblEnterPay_AvailCredit.Text = "0"
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub TxtEnterPay_NetAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEnterPay_NetAmount.TextChanged
        Try
            If TxtEnterPay_Credit.Text >= LblEnterPay_TotalAmount.Text Then
                TxtEnterPay_Status1.Text = "PAID"
                TxtEnterPay_Credit.Text = Val(TxtEnterPay_NetAmount.Text) + Convert.ToDouble(Val(LblEnterPay_AvailCredit.Text))
                TxtEnterPay_Credit.Text = Val(TxtEnterPay_Credit.Text) - Convert.ToDouble(Val(LblEnterPay_TotalAmount.Text))
            Else
                If TxtEnterPay_NetAmount.Text = "" Then
                    TxtEnterPay_Credit.Clear()
                    TxtEnterPay_Status1.Clear()
                Else
                    TxtEnterPay_Credit.Text = Val(TxtEnterPay_NetAmount.Text) + Convert.ToDouble(Val(LblEnterPay_AvailCredit.Text))
                    TxtEnterPay_Credit.Text = Val(TxtEnterPay_Credit.Text) - Convert.ToDouble(Val(LblEnterPay_TotalAmount.Text))
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnEnterPay_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnterPay_Add.Click
        Try
            If TxtEnterPay_Credit.Text < 0 Or CboEnterPay_Customer.Text = "" Then
                MsgBox("Innvalid amount to pay.", MsgBoxStyle.Exclamation, "Pay")
            Else
                
                sql = "UPDATE tblsummary as s,tblcustomer as c,tblcreateinvoice as i SET [total2] ='" _
                    & LblEnterPay_TotalAmount.Text & "', s.[credit] ='" & TxtEnterPay_Credit.Text & _
                    "', s.[netamount] ='0', s.[status] ='PAID' , i.[remarks] ='" _
                    & TxtEnterPay_Remarks.Text & "',c.[status] = 'PAID', paymentdate = now " _
                    & "WHERE s.invnum = i.invnum And i.cuscode = c.cuscode And " _
                    & "c.cusfname like '%" & CboEnterPay_Customer.Text & "%'"
                mysql(sql)
                CboEnterPay_Customer.Text = "---select customer----"
                TxtEnterPay_Remarks.Clear()
                TxtEnterPay_NetAmount.Clear()
                DtgEnterPay_InvoiceNumAmount.Columns.Clear()
                MsgBox("Payments Saved.", , "Payment")
                LblEnterPay_AvailCredit.Text = "0"
                LblEnterPay_TotalAmount.Text = "0"

                Call tls_enterpay_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub TxtEnterPay_Status_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEnterPay_Credit.TextChanged
        Try
            If TxtEnterPay_Credit.Text = "0" Then
                TxtEnterPay_Status1.Text = "PAID"
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub DtpOpenInvoice_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpOpenInvoice_From.ValueChanged
        Try

            sql = "SELECT (c.cusfname & ' ' & c.cuslname) as [Customer Name],i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(pesos)], paymentdate as [Payment Date] ," _
                & " s.status as [Status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum and s.status = 'pay now' and i.invdate like '%" _
                & DtpOpenInvoice_From.Text & "%'"
            myselectstatements(sql, DtgOpenInvoice_View)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DtpOpenInvoice_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpOpenInvoice_To.ValueChanged
        Try

            sql = "SELECT (c.cusfname & ' ' & c.cuslname) as [Customer Name],i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(pesos)], paymentdate as [Payment Date] ," _
                & " s.status as [Status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum and s.status = 'pay now' and i.invdate like '%" _
                & DtpOpenInvoice_To.Text & "%'"
            myselectstatements(sql, DtgOpenInvoice_View)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message & " in Button7_Click")
        End Try


    End Sub

    Private Sub tls_payReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tls_payReports.Click
        Try

            Pnl_PaymentsReports.Visible = True
            Pnl_PaymentsReports.Dock = DockStyle.Fill
            Pnl_PaymentsReports.BringToFront()

            ' Pnl_TaxReports.Visible = False
            Pnl_TaxReports.Dock = DockStyle.None

            ' Pnl_InvoiceReports.Visible = False
            Pnl_InvoiceReports.Dock = DockStyle.None


            ''''''''''''''''''''''''''''''''''''''''
            sql = "SELECT * FROM tblcustomer WHERE status = 'PAID'"
            mycbo(sql, CboPayReports_AllCus)
            CboPayReports_AllCus.Text = "All Customers"
            '''''''''''''''''''''''''''''
            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(pesos)], paymentdate as [Payment Date] , s.status as " _
                & "[Status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum and s.status = 'PAID'"
            myselectstatements(sql, DtgPayReports_TotalView)
            ''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tls_taxReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tls_taxReports.Click
        Try
            DtgPayReports_TotalView.Columns.Clear()
            Pnl_TaxReports.Visible = True
            Pnl_TaxReports.Dock = DockStyle.Fill
            Pnl_TaxReports.BringToFront()

            'Pnl_PaymentsReports.Visible = False
            Pnl_PaymentsReports.Dock = DockStyle.None

            'Pnl_InvoiceReports.Visible = False
            Pnl_InvoiceReports.Dock = DockStyle.None
            '''''''''''''''''''''''''''''''''
            sql = "SELECT * FROM tblcustomer as c,tblcreateinvoice " _
            & "as i WHERE c.cuscode = i.cuscode and i.taxable = 'true'"
            mycbotax(sql, CboTaxReport_AllCus)
            CboTaxReport_AllCus.Text = "All Customers"
            ''''''''''''''''''''''''''''''
            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
               & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
               & "s.total2 as [Amount(pesos)],s.salestax as [Tax], " _
               & "paymentdate as [Payment Date] , s.status as [Status] " _
               & "FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
               & " c.cuscode=i.cuscode and i.invnum = s.invnum and i.taxable = 'true' "
            myselectstatements(sql, DtgTaxReport_TotalView)
            ''''''''''''''''''''''''''''''''''''''
            Dim tot As Integer = 0
            For i As Integer = 0 To DtgTaxReport_TotalView.RowCount - 1
                tot += DtgTaxReport_TotalView.Rows(i).Cells(5).Value
            Next

            If tot = 0 Then
                MessageBox.Show("No Records Found")

            End If

            TextBox3.Text = tot
            '''''''''''''''''''''''''''''

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CboPayReports_AllCus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPayReports_AllCus.SelectedIndexChanged

        Try
            If CboPayReports_AllCus.Text = "" Then
                MsgBox("no query")
                CboPayReports_AllCus.Text = "All Customers"
            Else
                sql = " SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as " _
                    & " [Invoice Number] ,i.invdate as [Invoice Date],i.invdue as " _
                    & "[Due Date],s.total2 as [Amount(Pesos)],  paymentdate as [Payment Date] , " _
                    & "s.status as [status]  FROM tblcustomer c,tblcreateinvoice " _
                    & "i,tblsummary s where c.cuscode=i.cuscode and i.invnum = s.invnum" _
                    & " and s.status = 'PAID' and c.cuscode = '" _
                    & CboPayReports_AllCus.SelectedValue.ToString & "'"
                myselectstatements(sql, DtgPayReports_TotalView)
            End If

        Catch ex As Exception
            'MsgBox(ex.Message & "in CboPayReports_AllCus_SelectedIndexChanged")
        End Try

    End Sub

    Private Sub BtnPayReports_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPayReports_Go.Click
        Try
            CboInvoiceReport_AllCus.Text = "All Customer"
            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(pesos)], paymentdate as [Payment Date] , s.status as " _
                & "[Status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum and s.status = '" _
                & "PAID" & "'"
            myselectstatements(sql, DtgPayReports_TotalView)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  
#Region "Animation"
    Const timer_interval As Integer = 15 ' INTERVAL IN MILLISECONDS
    Protected current_gradient_shift As Integer = 10
    Protected gradiant_step As Integer = 5
    Private Sub Timer_Tick(ByVal obj As Object, ByVal ea As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = Format(Now, "long time")
        ToolStripStatusLabel2.Text = Format(Now, "short date")
        'SET THE GRAPHICS OBJECT IN THE FORM
        Dim grafx As Graphics = CreateGraphics()

        'SET AND DETERMINE THE SIZE,FONT AND TEXT.
        Dim fnt As New Font("Segoe UI", 90, _
            FontStyle.Bold, GraphicsUnit.Point)
        Dim start_text As String = "Billing System" 'APPEAR THE TEXT IN THE FIRST LOAD
        Dim fnt_size As New SizeF(grafx.MeasureString(start_text, fnt))

        'SET THE TEXT THAT TO BE CENTERED IN THE CLIENT AREA.
        Dim ptf_text_start As New PointF( _
            CSng(ClientSize.Width - fnt_size.Width) / 2, _
           CSng(ClientSize.Height - fnt_size.Height) / 2)


        'FOR THE ANIMATION EFFECT, SET THE GRADIENT START AND ITS END POINT.
        Dim ptf_gradient_start As New PointF(0, 0)
        Dim ptf_gradient_end As New PointF(current_gradient_shift, 130)


        'USE THE BRUSH FOR DRAWING THE TEXT.
        Dim gradient_brush As New LinearGradientBrush(ptf_gradient_start, _
            ptf_gradient_end, Color.Aqua, BackColor)

        'THE TEXT DRAW AT THE CENTERED OF THE CLIENT AREA.
        grafx.DrawString(start_text, fnt, gradient_brush, ptf_text_start)
        grafx.Dispose()

        'REVERSING THE GRADIENT WHEN IT GETS TO A CERTAIN VALUE
        current_gradient_shift += gradiant_step
        If current_gradient_shift = 500 Then
            gradiant_step = -5
        ElseIf current_gradient_shift = -50 Then
            gradiant_step = 5
        End If
    End Sub

#End Region
    Public Sub removetab()

        With TabControl1.TabPages
            .Remove(TabItems)
            .Remove(TabInvoie)
            .Remove(TabCustomers)
            .Remove(TabStaff)
            .Remove(TabSettings)
            .Remove(TabMyAccount)
            .Remove(TabReports)
        End With

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  

        Timer1.Start()
        Try

            TabControl2.SelectedTab = TabPage1
            sql = "SELECT invnum FROM tblcreateinvoice"
            mysql(sql)
 

            sql = "SELECT * FROM tblcustomer WHERE status = 'PAID' or  status ='open'"
            mycbo(sql, CboCreateInvoice_Customer)
            CboCreateInvoice_Customer.Text = "---Please Select Customer---"

            sql = "SELECT * FROM tblcreateinvoice"
            janAutoNumber(sql)

            sql = "SELECT staff_id as [ID], (staff_lname & ', ' & staff_fname & ' ' & staff_mname) as [Name]," & _
            "staff_dbirth as [Date of Birth],datediff('yyyy',staff_dbirth, now) as [Age],staff_add as [Address] " & _
            ",status as [Status] FROM tblstaff,tbluser WHERE staff_id=user_id and type = 'Staff'"
            myselectstatements(sql, dtgStaff_List)


            removetab()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DtpPayReports_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpPayReports_From.ValueChanged
        Try

            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(Pesos)] ,  paymentdate as [Payment Date] , " _
                & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum and s.status = 'PAID' and i.invdate like '%" _
                & DtpPayReports_From.Text & "%'"
            myselectstatements(sql, DtgPayReports_TotalView)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DtpPayReports_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpPayReports_To.ValueChanged
        Try

            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(Pesos)] ,  paymentdate as [Payment Date] , " _
                & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum and s.status = 'PAID' and i.invdate like '%" _
                & DtpPayReports_To.Text & "%'"
            myselectstatements(sql, DtgPayReports_TotalView)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DtpTaxReport_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpTaxReport_From.ValueChanged
        Try

            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(Pesos)] , s.salestax as [Tax], paymentdate as [Payment Date] , " _
                & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum  and i.invdate like '%" _
                & DtpTaxReport_From.Text & "%'"
            myselectstatements(sql, DtgTaxReport_TotalView)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DtpTaxReport_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpTaxReport_To.ValueChanged
        Try

            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                & "s.total2 as [Amount(Pesos)] , s.salestax as [Tax], paymentdate as [Payment Date] , " _
                & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                & " c.cuscode=i.cuscode and i.invnum = s.invnum  and i.invdate like '%" _
                & DtpTaxReport_To.Text & "%'"
            myselectstatements(sql, DtgTaxReport_TotalView)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnTaxReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTaxReport_Go.Click
        Try
            CboInvoiceReport_AllCus.Text = "All Customer"
            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
               & ",i.invdate as [Invoice date],i.invdue as [Due Date]," _
               & "s.total2 as [Amount(Pesos)] , s.salestax as [Tax], paymentdate as [Payment Date] , " _
               & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
               & " c.cuscode=i.cuscode and i.invnum = s.invnum "
            myselectstatements(sql, DtgTaxReport_TotalView)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CboEnterPay_Customer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEnterPay_Customer.SelectedIndexChanged

        Try

            'MsgBox(CboEnterPay_Customer.SelectedValue.ToString)

            sql = "SELECT i.invnum AS [Invoice number], s.total2 AS " _
                           & "[Amount(pesos)],s.credit FROM tblcustomer AS c, tblcreateinvoice " _
                           & "AS i, tblsummary AS s WHERE c.cuscode = i.cuscode " _
                           & "and s.invnum = i.invnum  and c.cuscode = '" _
                           & CboEnterPay_Customer.SelectedValue.ToString & "'"
            myselectstatements(sql, DtgEnterPay_InvoiceNumAmount)
            mysql(sql)

            Dim totamount As Double
            Dim credit As Double
         
            For Each r As DataRow In dt.Rows
                totamount += r.Item(1)
                credit += r.Item(2)
            Next
            LblEnterPay_TotalAmount.Text = totamount
            LblEnterPay_AvailCredit.Text = credit
      
          
        Catch ex As Exception
            '    MsgBox(ex.Message & " in CboEnterPay_Customer_SelectedIndexChanged")
        End Try
    End Sub


    Private Sub CboInvoiceReport_AllCus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboInvoiceReport_AllCus.SelectedIndexChanged
        Try
            If CboInvoiceReport_All.Text = "" Then
                MsgBox("no query")
            Else
                sql = " SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name]  ,i.invnum as " _
                    & " [Invoice Number] ,i.invdate as [Invoice Date],i.invdue as " _
                    & "[Due Date],s.total2 as [Amount], paymentdate as [Payment Date] , " _
                    & "s.status as [status]  FROM tblcustomer c,tblcreateinvoice " _
                    & "i,tblsummary s where c.cuscode=i.cuscode and i.invnum = s.invnum " _
                    & "and c.cuscode = '" & CboInvoiceReport_AllCus.SelectedValue.ToString & "'"
                myselectstatements(sql, DtgInvoiceReport_ViewAll)
            End If
        Catch ex As Exception
            'MsgBox(ex.Message & " in CboInvoiceReport_AllCus_SelectedIndexChanged")
        End Try

    End Sub

    Private Sub CboTaxReport_AllCus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTaxReport_AllCus.SelectedIndexChanged
        Try
            sql = "SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name] ,i.invnum as [Invoice Number]" _
                           & ",i.invdate as [Invoice Date],i.invdue as [Due Date]," _
                           & "s.total2 as [Amount(Pesos)] , s.salestax as [Tax],paymentdate as [Payment Date] , " _
                           & "s.status as [status] FROM tblcustomer c,tblcreateinvoice i,tblsummary s WHERE" _
                           & " c.cuscode=i.cuscode and i.invnum = s.invnum  and i.taxable = 'true' and c.cuscode = '" _
                           & CboTaxReport_AllCus.SelectedValue.ToString & "'"
            myselectstatements(sql, DtgTaxReport_TotalView)
        Catch ex As Exception
            ' MsgBox(ex.Message & " in CboTaxReport_AllCus_SelectedIndexChanged")
        End Try

    End Sub

    Private Sub TabControl2_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl2.Selected
        Try

            sql = " SELECT (c.cusfname & ' ' & c.cuslname)  as [Customer Name]  ,i.invnum as " _
                & " [Invoice Number] ,i.invdate as [Invoice Date],i.invdue as " _
                & "[Due Date],s.total2 as [Amount(pesos)], paymentdate as [Payment Date]," _
                & "s.status as [Status]  FROM tblcustomer c,tblcreateinvoice " _
                & "i,tblsummary s where c.cuscode=i.cuscode and i.invnum = s.invnum " _
                & "and s.status = 'pay now' AND actions= 'Active'"
            myselectstatements(sql, DtgOpenInvoice_View)
            'dtg_btn_show_del(DtgOpenInvoice_View)
        Catch ex As Exception
            MsgBox(ex.Message & "in TabControl2_Selected")
        End Try


    End Sub

    Private Sub tls_managecus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tls_managecus.Click
        Try
            Pnl_ManageCustomer.Dock = DockStyle.Fill
            Pnl_ManageCustomer.BringToFront()
            Pnl_AddCustomer.Dock = DockStyle.None
            Pnl_EnterPayment.Dock = DockStyle.None

            sql = "SELECT cuscode as [Customer Code],cusfname as [First Name],cuslname as [Last Name],cusaddress as [Address] " & _
            "FROM tblcustomer WHERE actions='Active'"
            myselectstatements(sql, DtgManageCus_ViewRecord)
        Catch ex As Exception
            MsgBox(ex.Message & " in tls_managecus_Click")
        End Try
    End Sub



    Private Sub Pnl_TaxSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pnl_TaxSettings.Click, Label51.Click
        Try
            Pnl_TaxSettings.Dock = DockStyle.Fill
            Pnl_TaxSettings.BringToFront()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Pnl_TaxSettings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pnl_TaxSettings.DoubleClick, Label51.DoubleClick
        Pnl_TaxSettings.Dock = DockStyle.None
    End Sub

    Private Sub Pnl_Reminder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pnl_Reminder.Click, Label68.Click
        Try
            Pnl_Reminder.Dock = DockStyle.Fill
            Pnl_Reminder.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Pnl_Reminder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pnl_Reminder.DoubleClick, Label68.DoubleClick
        Try
            Pnl_Reminder.Dock = DockStyle.None
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Pnl_GeneralSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pnl_GeneralSettings.Click, Label41.Click
        Try
            Pnl_GeneralSettings.Dock = DockStyle.Fill
            Pnl_GeneralSettings.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Pnl_GeneralSettings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pnl_GeneralSettings.DoubleClick, Label41.DoubleClick
        Pnl_GeneralSettings.Dock = DockStyle.None
    End Sub



    Private Sub Pnl_GeneralSettings_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pnl_TaxSettings.MouseHover, Pnl_Reminder.MouseHover, Pnl_GeneralSettings.MouseHover, Label68.MouseHover, Label51.MouseHover, Label41.MouseHover
        If TypeOf sender Is Panel Then

        End If
    End Sub

    Private Sub Label61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label61.Click

    End Sub

    Private Sub BtnAddStaff_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddStaff_Save.Click
        Try
            sql = "SELECT staff_id FROM tblstaff WHERE staff_id = '" & txtstaff_id.Text & "'"
            mysql(sql)
            If dt.Rows.Count > 0 Then
                sql = "UPDATE tblstaff SET staff_fname='" & TxtStaff_Fname.Text & "',staff_lname='" & TxtStaff_Lname.Text & _
                                            "',staff_mname='" & txtStaff_Mname.Text & "',staff_dbirth='" & dtpStaff_dbirth.Value & _
                                            "',staff_add='" & TxtStaff_Address.Text & "', staff_tell='" & TxtStaff_Phone.Text & _
                                            "',staff_mobile='" & TxtStaff_Mobile.Text & "',staff_fax='" & TxtStaff_Fax.Text & _
                                            "' WHERE staff_id='" & txtstaff_id.Text & "'"
                mysql(sql)
                MsgBox("Staff information has been updated.", , "Update")
            Else
                sql = "INSERT INTO tblstaff (staff_id,staff_fname,staff_lname," & _
                                            "staff_mname,staff_dbirth,staff_add," & _
                                            "staff_tell,staff_mobile,staff_fax,status,type) " & _
                                            "VALUES ('" & txtstaff_id.Text & "','" & _
                                            TxtStaff_Fname.Text & "','" & TxtStaff_Lname.Text _
                                            & "','" & txtStaff_Mname.Text & "','" & dtpStaff_dbirth.Value _
                                            & "','" & TxtStaff_Address.Text & "','" & TxtStaff_Phone.Text _
                                            & "','" & TxtStaff_Mobile.Text & "','" & TxtStaff_Fax.Text & "','ACTIVE')"
                mysql(sql)

                sql = "INSERT INTO tbluser (user_id,username, pass,type) " & _
                "VALUES ('" & txtstaff_id.Text & "','" & txtusername.Text & "','" & txtpass.Text & "','Staff')"
                mysql(sql)
                MsgBox("New Staff has been saved.", , "Save")
            End If

            smartClear(GroupBox2)

            ' Call Form1_Load(sender, e)
            GroupBox2.Enabled = False


            sql = "SELECT staff_id as [ID], (staff_lname & ', ' & staff_fname & ' ' & staff_mname) as [Name]," & _
             "staff_dbirth as [Date of Birth],datediff('yyyy',staff_dbirth, now) as [Age],staff_add as [Address] " & _
             ",status as [Status] FROM tblstaff,tbluser WHERE staff_id=user_id and type = 'Staff'"
            myselectstatements(sql, dtgStaff_List)
        Catch ex As Exception
            MsgBox("You must fill up all the fields given in the area." & ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try
    End Sub

    Private Sub btnStaffAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStaffAdd.Click
        GroupBox2.Enabled = True
        smartClear(GroupBox2)
        dtpStaff_dbirth.Value = Now
    End Sub

    Private Sub btnStaffEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStaffEdit.Click
        GroupBox2.Enabled = True
        Try
            txtstaff_id.Text = dtgStaff_List.CurrentRow.Cells(0).Value.ToString
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtstaff_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtstaff_id.TextChanged
        Try
            sql = "SELECT * FROM tblstaff,tbluser WHERE staff_id=user_id and staff_id = '" & txtstaff_id.Text & "'"
            mysql(sql)
            If dt.Rows.Count > 0 Then
                TxtStaff_Fname.Text = dt.Rows(0).Item("staff_fname")
                txtStaff_Mname.Text = dt.Rows(0).Item("staff_mname")
                TxtStaff_Lname.Text = dt.Rows(0).Item("staff_lname")
                dtpStaff_dbirth.Value = dt.Rows(0).Item("staff_dbirth")
                TxtStaff_Address.Text = dt.Rows(0).Item("staff_add")
                TxtStaff_Phone.Text = dt.Rows(0).Item("staff_tell")
                TxtStaff_Mobile.Text = dt.Rows(0).Item("staff_mobile")
                TxtStaff_Fax.Text = dt.Rows(0).Item("staff_fax")
                txtusername.Text = dt.Rows(0).Item("username")
                txtpass.Text = dt.Rows(0).Item("pass")
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in txtstaff_id_TextChanged")
        End Try
    End Sub

    Private Sub btnStaffDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStaffDelete.Click
        Try
            If btnStaffDelete.Text = "Active Now" Then
                sql = "UPDATE tblstaff SET status ='ACTIVE' WHERE staff_id ='" & dtgStaff_List.CurrentRow.Cells(0).Value & "'"
                mysql(sql)
            Else
                sql = "UPDATE tblstaff SET status ='NOT ACTIVE' WHERE staff_id ='" & dtgStaff_List.CurrentRow.Cells(0).Value & "'"
                mysql(sql)
            End If

            Call Form1_Load(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgStaff_List_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
    Handles dtgStaff_List.CellClick
        Try
            If dtgStaff_List.CurrentRow.Cells(5).Value = "NOT ACTIVE" Then
                btnStaffDelete.Text = "Active Now"
            Else
                btnStaffDelete.Text = "De activate"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddSer_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnServiceSave.Click
        Try
            sql = "INSERT INTO tblservices (service_name,service_desc,service_unitprice,service_unit,service_type)" & _
            " VALUES ('" & TxtServiceName.Text & "','" & TxtServiceDesc.Text & "','" & TxtServiceUnitPrice.Text & _
            "','" & CboServiceUnit.Text & "','" & CboServiceType.Text & "')"
            mysql(sql)
            MsgBox("New service has been saved.", , "Service Save")
        Catch ex As Exception
            MsgBox(ex.Message & " in BtnAddSer_Save_Click.")
        End Try
    End Sub
 
    Private Sub TabControl3_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl3.Selected
        Try
            sql = "SELECT service_id as [ID],service_name as [Service Name], " & _
            "service_desc as [Service Description], service_unitprice as [Unit Price], " & _
            "service_unit as [Unit],service_type as [Type] FROM tblservices"
            myselectstatements(sql, DtgManageSer_Description)
        Catch ex As Exception
            MsgBox(ex.Message & " in TabControl3_Selected")
        End Try
    End Sub

    Private Sub BtnManageCus_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnManageCus_Search.Click
        Try
            sql = "SELECT cuscode as [Customer Code], cusfname as [First Name],cuslname as [Last Name],cusaddress as [Address] " & _
            "FROM tblcustomer WHERE cuscode LIKE '%" & TxtManageCus_id.Text & "%' AND actions='Active'"
            myselectstatements(sql, DtgManageCus_ViewRecord)
        Catch ex As Exception
            MsgBox(ex.Message & "in BtnManageCus_Search_Click.")
        End Try
    End Sub

    Private Sub BtnManageCus_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnManageCus_Go.Click
        Try
            If CboManageCus_ActionUsers.Text = "Delete" Then
                sql = "UPDATE tblcustomer SET actions ='Deleted' WHERE cuscode ='" & _
                DtgManageCus_ViewRecord.CurrentRow.Cells(0).Value & "'"
                mysql(sql)
                MsgBox("Customer has been deleted.", , "Delete")
                Call tls_managecus_Click(sender, e)
            ElseIf CboManageCus_ActionUsers.Text = "Edit" Then
                Pnl_ManageCustomer.Dock = DockStyle.None
                Pnl_ManageCustomer.SendToBack()
                Pnl_EnterPayment.Dock = DockStyle.None
                Pnl_EnterPayment.SendToBack()
                Pnl_AddCustomer.Dock = DockStyle.Fill
                Pnl_AddCustomer.BringToFront()
                lbladdcus.Text = "Update Customer"
                TxtAddCus_Code.Text = DtgManageCus_ViewRecord.CurrentRow.Cells(0).Value.ToString
                sql = "SELECT * FROM tblcustomer WHERE cuscode like '%" & TxtAddCus_Code.Text & "%'"
                mysql(sql)
                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        TxtAddCus_Fname.Text = .Item("cusfname")
                        TxtAddCus_Lname.Text = .Item("cuslname")
                        TxtAddCus_NickName.Text = .Item("cusnckname")
                        TxtAddCus_Address.Text = .Item("cusaddress")
                        TxtAddCus_Phone.Text = .Item("phone")
                        TxtAddCus_Mobile.Text = .Item("mobile")
                       
                    End With
                End If
            Else
                MsgBox("Select your Actions", MsgBoxStyle.Information, "Action")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in BtnManageCus_Go_Click.")
        End Try
    End Sub

    Private Sub TxtAddCus_Code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TxtAddCus_Code.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnProfile_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProfile_Save.Click
        Try
            If lnkLogout.Text = "Logout " & usertype Then
                sql = "UPDATE tblstaff SET staff_fname='" & TxtProfile_Fname.Text & "',staff_lname='" & TxtProfile_Lname.Text & _
                       "',staff_mname='" & TxtProfile_Mname.Text & _
                       "',staff_add='" & TxtProfile_Address.Text & "', staff_tell='" & TxtProfile_Phone.Text & _
                       "',staff_mobile='" & TxtProfile_Mobile.Text & "',staff_fax='" & TxtProfile_Fax.Text & _
                       "' WHERE staff_id='" & userId & "'"
                mysql(sql)

                sql = "UPDATE tbluser SET username='" & txtMyUsername.Text & _
                "', pass =  '" & txtMyPassword.Text & "'  WHERE user_id = '" & userId & "'"
                mysql(sql)
                MsgBox("Account has been updated", , "Update user accounts")
                smartClear(Pnl_MyProfile)
                selectedtab()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Try
            loginSub(txtLoginusername, txtLoginpassword)
        Catch ex As Exception
            MsgBox(ex.Message & " in btnlogin_Click")
        End Try
    End Sub

    Private Sub lnkLogout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLogout.LinkClicked
        Try
            With TabControl1.TabPages
                .Remove(TabItems)
                .Remove(TabInvoie)
                .Remove(TabCustomers)
                .Remove(TabStaff)
                .Remove(TabSettings)
                .Remove(TabMyAccount)
                .Remove(TabReports)
            End With
            GroupBox3.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message & " in lnkLogout_LinkClicked")
        End Try
    End Sub


    Private Sub btnAdminSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminSave.Click
        Try
            sql = "INSERT INTO tbluser (user_id,username,pass,type) " & _
            "VALUES ('" & txtAdminuserId.Text & "','" & txtAdminUsername.Text & _
            "','" & txtAdminPassword.Text & "','Administrator')"
            mysql(sql)

            sql = "INSERT INTO tblstaff (staff_id,status) VALUES ('" & txtAdminuserId.Text & "','ACTIVE')"
            mysql(sql)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub selectedtab()
        Try
            sql = "SELECT user_id as [ID], username as [Username] FROM tbluser WHERE type = 'Administrator'"
            myselectstatements(sql, dtgadminList)


            sql = "SELECT * FROM tblstaff,tbluser WHERE user_id=staff_id and user_id='" & userId & "'"
            mysql(sql)
            With dt.Rows(0)
                txtMyUsername.Text = .Item("username")
                txtMyPassword.Text = .Item("pass")
                TxtProfile_Fname.Text = .Item("staff_fname")
                TxtProfile_Mname.Text = .Item("staff_mname")
                TxtProfile_Lname.Text = .Item("staff_lname")
                TxtProfile_Address.Text = .Item("staff_add")
                TxtProfile_Phone.Text = .Item("staff_tell")
                TxtProfile_Mobile.Text = .Item("staff_mobile")
                TxtProfile_Fax.Text = .Item("staff_fax")

            End With
        Catch ex As Exception
            'MsgBox(ex.Message & " in TabControl1_Selected")
        End Try
    End Sub

    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        selectedtab()
        sql = "SELECT * FROM tblcustomer"
        janAutoNumber(sql)
    End Sub



    Private Sub Pnl_EnterPayment_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_EnterPayment.Paint

    End Sub

    Private Sub Pnl_AddCustomer_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_AddCustomer.Paint

    End Sub

    Private Sub TxtAddCus_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAddCus_Mobile.TextChanged

    End Sub

    Private Sub Label39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label39.Click

    End Sub

    Private Sub CboCreateInvoice_Customer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCreateInvoice_Customer.SelectedIndexChanged

    End Sub

    Private Sub TxtCreateInvoice_PONum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
