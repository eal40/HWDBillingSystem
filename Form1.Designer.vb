<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblUsername = New Label()
        lblGender = New Label()
        lblEmail = New Label()
        lblPassword = New Label()
        lblInput = New Label()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        gender = New Label()
        Label3 = New Label()
        Label4 = New Label()
        txtUsername = New TextBox()
        txtEmail = New TextBox()
        txtPassword = New TextBox()
        rbMale = New RadioButton()
        rbFemale = New RadioButton()
        btnSubmit = New Button()
        Label5 = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        lblDisplayUsername = New Label()
        lblDisplayPassword = New Label()
        lblDisplayGender = New Label()
        lblDisplayEmail = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(524, 145)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(78, 20)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username:"
        ' 
        ' lblGender
        ' 
        lblGender.AutoSize = True
        lblGender.Location = New Point(524, 212)
        lblGender.Name = "lblGender"
        lblGender.Size = New Size(57, 20)
        lblGender.TabIndex = 1
        lblGender.Text = "Gender"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(524, 283)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(49, 20)
        lblEmail.TabIndex = 2
        lblEmail.Text = "Email:"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(524, 357)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(73, 20)
        lblPassword.TabIndex = 3
        lblPassword.Text = "Password:"
        ' 
        ' lblInput
        ' 
        lblInput.AutoSize = True
        lblInput.Location = New Point(244, 49)
        lblInput.Name = "lblInput"
        lblInput.Size = New Size(76, 20)
        lblInput.TabIndex = 4
        lblInput.Text = "User Input"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = SystemColors.ActiveCaption
        PictureBox1.Location = New Point(83, 94)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(377, 366)
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(102, 145)
        Label1.Name = "Label1"
        Label1.Size = New Size(78, 20)
        Label1.TabIndex = 6
        Label1.Text = "Username:"
        ' 
        ' gender
        ' 
        gender.AutoSize = True
        gender.Location = New Point(102, 202)
        gender.Name = "gender"
        gender.Size = New Size(57, 20)
        gender.TabIndex = 7
        gender.Text = "Gender"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(102, 283)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 20)
        Label3.TabIndex = 8
        Label3.Text = "Email:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(102, 357)
        Label4.Name = "Label4"
        Label4.Size = New Size(73, 20)
        Label4.TabIndex = 9
        Label4.Text = "Password:"
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(186, 145)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(204, 27)
        txtUsername.TabIndex = 10
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(181, 280)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(204, 27)
        txtEmail.TabIndex = 11
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(181, 350)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(204, 27)
        txtPassword.TabIndex = 12
        ' 
        ' rbMale
        ' 
        rbMale.AutoSize = True
        rbMale.Location = New Point(207, 202)
        rbMale.Name = "rbMale"
        rbMale.Size = New Size(63, 24)
        rbMale.TabIndex = 13
        rbMale.TabStop = True
        rbMale.Text = "Male"
        rbMale.UseVisualStyleBackColor = True
        ' 
        ' rbFemale
        ' 
        rbFemale.AutoSize = True
        rbFemale.Location = New Point(307, 202)
        rbFemale.Name = "rbFemale"
        rbFemale.Size = New Size(78, 24)
        rbFemale.TabIndex = 14
        rbFemale.TabStop = True
        rbFemale.Text = "Female"
        rbFemale.UseVisualStyleBackColor = True
        ' 
        ' btnSubmit
        ' 
        btnSubmit.Location = New Point(226, 411)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(94, 29)
        btnSubmit.TabIndex = 15
        btnSubmit.Text = "Submit"
        btnSubmit.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(635, 148)
        Label5.Name = "Label5"
        Label5.Size = New Size(0, 20)
        Label5.TabIndex = 16
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' lblDisplayUsername
        ' 
        lblDisplayUsername.AutoSize = True
        lblDisplayUsername.Location = New Point(654, 148)
        lblDisplayUsername.Name = "lblDisplayUsername"
        lblDisplayUsername.Size = New Size(0, 20)
        lblDisplayUsername.TabIndex = 24
        ' 
        ' lblDisplayPassword
        ' 
        lblDisplayPassword.AutoSize = True
        lblDisplayPassword.Location = New Point(654, 357)
        lblDisplayPassword.Name = "lblDisplayPassword"
        lblDisplayPassword.Size = New Size(0, 20)
        lblDisplayPassword.TabIndex = 25
        ' 
        ' lblDisplayGender
        ' 
        lblDisplayGender.AutoSize = True
        lblDisplayGender.Location = New Point(654, 212)
        lblDisplayGender.Name = "lblDisplayGender"
        lblDisplayGender.Size = New Size(0, 20)
        lblDisplayGender.TabIndex = 26
        ' 
        ' lblDisplayEmail
        ' 
        lblDisplayEmail.AutoSize = True
        lblDisplayEmail.Location = New Point(654, 287)
        lblDisplayEmail.Name = "lblDisplayEmail"
        lblDisplayEmail.Size = New Size(0, 20)
        lblDisplayEmail.TabIndex = 27
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1035, 504)
        Controls.Add(lblDisplayEmail)
        Controls.Add(lblDisplayGender)
        Controls.Add(lblDisplayPassword)
        Controls.Add(lblDisplayUsername)
        Controls.Add(Label5)
        Controls.Add(btnSubmit)
        Controls.Add(rbFemale)
        Controls.Add(rbMale)
        Controls.Add(txtPassword)
        Controls.Add(txtEmail)
        Controls.Add(txtUsername)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(gender)
        Controls.Add(Label1)
        Controls.Add(lblInput)
        Controls.Add(lblPassword)
        Controls.Add(lblEmail)
        Controls.Add(lblGender)
        Controls.Add(lblUsername)
        Controls.Add(PictureBox1)
        Name = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblUsername As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblInput As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gender As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents rbMale As RadioButton
    Friend WithEvents rbFemale As RadioButton
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents lblDisplayUsername As Label
    Friend WithEvents lblDisplayPassword As Label
    Friend WithEvents lblDisplayGender As Label
    Friend WithEvents lblDisplayEmail As Label

End Class
