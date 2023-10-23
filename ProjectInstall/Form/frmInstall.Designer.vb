<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstall
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstall))
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tabcInstallMain = New System.Windows.Forms.TabControl()
        Me.TabInstall1 = New System.Windows.Forms.TabPage()
        Me.txtGuidance = New System.Windows.Forms.TextBox()
        Me.lblTitleSub = New System.Windows.Forms.Label()
        Me.lblTitleMain = New System.Windows.Forms.Label()
        Me.TabInstall2 = New System.Windows.Forms.TabPage()
        Me.trevInstallDetail = New System.Windows.Forms.TreeView()
        Me.ImglInstallIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.lnlSelectInstall = New System.Windows.Forms.Label()
        Me.TabInstall3 = New System.Windows.Forms.TabPage()
        Me.lblWarringText = New System.Windows.Forms.Label()
        Me.btnConnectTest = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.lblSetAdminAcc = New System.Windows.Forms.Label()
        Me.TabInstall4 = New System.Windows.Forms.TabPage()
        Me.trevResult = New System.Windows.Forms.TreeView()
        Me.ImglResult = New System.Windows.Forms.ImageList(Me.components)
        Me.lblCkInstallItem = New System.Windows.Forms.Label()
        Me.TabInstall5 = New System.Windows.Forms.TabPage()
        Me.prgProcess = New System.Windows.Forms.ProgressBar()
        Me.txtOutputResult = New System.Windows.Forms.TextBox()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.TabInstall6 = New System.Windows.Forms.TabPage()
        Me.lblLastExitMsg = New System.Windows.Forms.Label()
        Me.lblLastMsg = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.skeSkin = New Sunisoft.IrisSkin.SkinEngine()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabcInstallMain.SuspendLayout()
        Me.TabInstall1.SuspendLayout()
        Me.TabInstall2.SuspendLayout()
        Me.TabInstall3.SuspendLayout()
        Me.TabInstall4.SuspendLayout()
        Me.TabInstall5.SuspendLayout()
        Me.TabInstall6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNext.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnNext.Location = New System.Drawing.Point(102, 375)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 32)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = ">下一步(&N)"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Location = New System.Drawing.Point(356, 375)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 32)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "(&C)關閉"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabcInstallMain
        '
        Me.tabcInstallMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabcInstallMain.Controls.Add(Me.TabInstall1)
        Me.tabcInstallMain.Controls.Add(Me.TabInstall2)
        Me.tabcInstallMain.Controls.Add(Me.TabInstall3)
        Me.tabcInstallMain.Controls.Add(Me.TabInstall4)
        Me.tabcInstallMain.Controls.Add(Me.TabInstall5)
        Me.tabcInstallMain.Controls.Add(Me.TabInstall6)
        Me.tabcInstallMain.Location = New System.Drawing.Point(0, 37)
        Me.tabcInstallMain.Name = "tabcInstallMain"
        Me.tabcInstallMain.SelectedIndex = 0
        Me.tabcInstallMain.Size = New System.Drawing.Size(443, 332)
        Me.tabcInstallMain.TabIndex = 4
        Me.tabcInstallMain.Tag = "Result"
        '
        'TabInstall1
        '
        Me.TabInstall1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabInstall1.Controls.Add(Me.txtGuidance)
        Me.TabInstall1.Controls.Add(Me.lblTitleSub)
        Me.TabInstall1.Controls.Add(Me.lblTitleMain)
        Me.TabInstall1.Location = New System.Drawing.Point(4, 26)
        Me.TabInstall1.Name = "TabInstall1"
        Me.TabInstall1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInstall1.Size = New System.Drawing.Size(435, 302)
        Me.TabInstall1.TabIndex = 0
        Me.TabInstall1.Text = "-"
        '
        'txtGuidance
        '
        Me.txtGuidance.BackColor = System.Drawing.Color.White
        Me.txtGuidance.Location = New System.Drawing.Point(26, 102)
        Me.txtGuidance.Multiline = True
        Me.txtGuidance.Name = "txtGuidance"
        Me.txtGuidance.ReadOnly = True
        Me.txtGuidance.Size = New System.Drawing.Size(379, 170)
        Me.txtGuidance.TabIndex = 2
        Me.txtGuidance.Text = "這個精靈將會引導您完成 客製程式 的安裝作業" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "在開始之前請先關閉以下程式" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "按一下 [下一步] 繼續進行" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblTitleSub
        '
        Me.lblTitleSub.AutoSize = True
        Me.lblTitleSub.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblTitleSub.Location = New System.Drawing.Point(222, 56)
        Me.lblTitleSub.Name = "lblTitleSub"
        Me.lblTitleSub.Size = New System.Drawing.Size(182, 16)
        Me.lblTitleSub.TabIndex = 1
        Me.lblTitleSub.Text = "客製程式安裝介面 精靈"
        '
        'lblTitleMain
        '
        Me.lblTitleMain.AutoSize = True
        Me.lblTitleMain.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblTitleMain.Location = New System.Drawing.Point(23, 28)
        Me.lblTitleMain.Name = "lblTitleMain"
        Me.lblTitleMain.Size = New System.Drawing.Size(75, 16)
        Me.lblTitleMain.TabIndex = 0
        Me.lblTitleMain.Text = "歡迎使用"
        '
        'TabInstall2
        '
        Me.TabInstall2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabInstall2.Controls.Add(Me.trevInstallDetail)
        Me.TabInstall2.Controls.Add(Me.lnlSelectInstall)
        Me.TabInstall2.Location = New System.Drawing.Point(4, 26)
        Me.TabInstall2.Name = "TabInstall2"
        Me.TabInstall2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInstall2.Size = New System.Drawing.Size(435, 302)
        Me.TabInstall2.TabIndex = 1
        Me.TabInstall2.Text = "-"
        '
        'trevInstallDetail
        '
        Me.trevInstallDetail.CheckBoxes = True
        Me.trevInstallDetail.ImageIndex = 0
        Me.trevInstallDetail.ImageList = Me.ImglInstallIcon
        Me.trevInstallDetail.Location = New System.Drawing.Point(26, 57)
        Me.trevInstallDetail.Name = "trevInstallDetail"
        Me.trevInstallDetail.SelectedImageIndex = 0
        Me.trevInstallDetail.Size = New System.Drawing.Size(379, 227)
        Me.trevInstallDetail.TabIndex = 3
        '
        'ImglInstallIcon
        '
        Me.ImglInstallIcon.ImageStream = CType(resources.GetObject("ImglInstallIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImglInstallIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.ImglInstallIcon.Images.SetKeyName(0, "folder.ico")
        Me.ImglInstallIcon.Images.SetKeyName(1, "coding.ico")
        Me.ImglInstallIcon.Images.SetKeyName(2, "EXCEL.ico")
        Me.ImglInstallIcon.Images.SetKeyName(3, "word.ico")
        Me.ImglInstallIcon.Images.SetKeyName(4, "config.ico")
        '
        'lnlSelectInstall
        '
        Me.lnlSelectInstall.AutoSize = True
        Me.lnlSelectInstall.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lnlSelectInstall.Location = New System.Drawing.Point(23, 28)
        Me.lnlSelectInstall.Name = "lnlSelectInstall"
        Me.lnlSelectInstall.Size = New System.Drawing.Size(143, 16)
        Me.lnlSelectInstall.TabIndex = 2
        Me.lnlSelectInstall.Text = "請勾選更新項目："
        '
        'TabInstall3
        '
        Me.TabInstall3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabInstall3.Controls.Add(Me.lblWarringText)
        Me.TabInstall3.Controls.Add(Me.btnConnectTest)
        Me.TabInstall3.Controls.Add(Me.txtPassword)
        Me.TabInstall3.Controls.Add(Me.txtAccount)
        Me.TabInstall3.Controls.Add(Me.lblPassword)
        Me.TabInstall3.Controls.Add(Me.lblAccount)
        Me.TabInstall3.Controls.Add(Me.lblSetAdminAcc)
        Me.TabInstall3.Location = New System.Drawing.Point(4, 26)
        Me.TabInstall3.Name = "TabInstall3"
        Me.TabInstall3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInstall3.Size = New System.Drawing.Size(435, 302)
        Me.TabInstall3.TabIndex = 2
        Me.TabInstall3.Text = "-"
        '
        'lblWarringText
        '
        Me.lblWarringText.AutoSize = True
        Me.lblWarringText.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblWarringText.ForeColor = System.Drawing.Color.Red
        Me.lblWarringText.Location = New System.Drawing.Point(167, 232)
        Me.lblWarringText.Name = "lblWarringText"
        Me.lblWarringText.Size = New System.Drawing.Size(245, 64)
        Me.lblWarringText.TabIndex = 7
        Me.lblWarringText.Text = "請注意！輸入管理者帳戶及密碼" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "否則會導致程式註冊無法成功！" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnConnectTest
        '
        Me.btnConnectTest.Location = New System.Drawing.Point(277, 101)
        Me.btnConnectTest.Name = "btnConnectTest"
        Me.btnConnectTest.Size = New System.Drawing.Size(75, 27)
        Me.btnConnectTest.TabIndex = 6
        Me.btnConnectTest.Text = "測試"
        Me.btnConnectTest.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(90, 162)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(160, 27)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.Text = "plm"
        '
        'txtAccount
        '
        Me.txtAccount.Location = New System.Drawing.Point(90, 101)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(160, 27)
        Me.txtAccount.TabIndex = 4
        Me.txtAccount.Text = "Administrator"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(28, 168)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(55, 16)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "密碼："
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(28, 107)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(55, 16)
        Me.lblAccount.TabIndex = 2
        Me.lblAccount.Text = "帳號："
        '
        'lblSetAdminAcc
        '
        Me.lblSetAdminAcc.AutoSize = True
        Me.lblSetAdminAcc.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSetAdminAcc.Location = New System.Drawing.Point(23, 29)
        Me.lblSetAdminAcc.Name = "lblSetAdminAcc"
        Me.lblSetAdminAcc.Size = New System.Drawing.Size(194, 16)
        Me.lblSetAdminAcc.TabIndex = 1
        Me.lblSetAdminAcc.Text = "請輸入管理者帳號和密碼"
        '
        'TabInstall4
        '
        Me.TabInstall4.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabInstall4.Controls.Add(Me.trevResult)
        Me.TabInstall4.Controls.Add(Me.lblCkInstallItem)
        Me.TabInstall4.Location = New System.Drawing.Point(4, 26)
        Me.TabInstall4.Name = "TabInstall4"
        Me.TabInstall4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInstall4.Size = New System.Drawing.Size(435, 302)
        Me.TabInstall4.TabIndex = 3
        Me.TabInstall4.Text = "-"
        '
        'trevResult
        '
        Me.trevResult.ImageIndex = 0
        Me.trevResult.ImageList = Me.ImglResult
        Me.trevResult.Location = New System.Drawing.Point(26, 61)
        Me.trevResult.Name = "trevResult"
        Me.trevResult.SelectedImageIndex = 0
        Me.trevResult.Size = New System.Drawing.Size(376, 218)
        Me.trevResult.TabIndex = 3
        '
        'ImglResult
        '
        Me.ImglResult.ImageStream = CType(resources.GetObject("ImglResult.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImglResult.TransparentColor = System.Drawing.Color.Transparent
        Me.ImglResult.Images.SetKeyName(0, "diskette.png")
        Me.ImglResult.Images.SetKeyName(1, "Recorrect.ico")
        Me.ImglResult.Images.SetKeyName(2, "ReError.ico")
        '
        'lblCkInstallItem
        '
        Me.lblCkInstallItem.AutoSize = True
        Me.lblCkInstallItem.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblCkInstallItem.Location = New System.Drawing.Point(23, 29)
        Me.lblCkInstallItem.Name = "lblCkInstallItem"
        Me.lblCkInstallItem.Size = New System.Drawing.Size(143, 16)
        Me.lblCkInstallItem.TabIndex = 2
        Me.lblCkInstallItem.Text = "請檢查安裝項目："
        '
        'TabInstall5
        '
        Me.TabInstall5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabInstall5.Controls.Add(Me.prgProcess)
        Me.TabInstall5.Controls.Add(Me.txtOutputResult)
        Me.TabInstall5.Controls.Add(Me.lblProcess)
        Me.TabInstall5.Location = New System.Drawing.Point(4, 26)
        Me.TabInstall5.Name = "TabInstall5"
        Me.TabInstall5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInstall5.Size = New System.Drawing.Size(435, 302)
        Me.TabInstall5.TabIndex = 4
        Me.TabInstall5.Text = "-"
        '
        'prgProcess
        '
        Me.prgProcess.BackColor = System.Drawing.Color.Lime
        Me.prgProcess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.prgProcess.Location = New System.Drawing.Point(89, 27)
        Me.prgProcess.Maximum = 3
        Me.prgProcess.Name = "prgProcess"
        Me.prgProcess.Size = New System.Drawing.Size(321, 23)
        Me.prgProcess.TabIndex = 8
        '
        'txtOutputResult
        '
        Me.txtOutputResult.Location = New System.Drawing.Point(27, 56)
        Me.txtOutputResult.Multiline = True
        Me.txtOutputResult.Name = "txtOutputResult"
        Me.txtOutputResult.ReadOnly = True
        Me.txtOutputResult.Size = New System.Drawing.Size(383, 226)
        Me.txtOutputResult.TabIndex = 7
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblProcess.Location = New System.Drawing.Point(24, 30)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(58, 16)
        Me.lblProcess.TabIndex = 6
        Me.lblProcess.Text = "進度："
        '
        'TabInstall6
        '
        Me.TabInstall6.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabInstall6.Controls.Add(Me.lblLastExitMsg)
        Me.TabInstall6.Controls.Add(Me.lblLastMsg)
        Me.TabInstall6.Location = New System.Drawing.Point(4, 26)
        Me.TabInstall6.Name = "TabInstall6"
        Me.TabInstall6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabInstall6.Size = New System.Drawing.Size(435, 302)
        Me.TabInstall6.TabIndex = 5
        Me.TabInstall6.Text = "-"
        '
        'lblLastExitMsg
        '
        Me.lblLastExitMsg.AutoSize = True
        Me.lblLastExitMsg.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLastExitMsg.Location = New System.Drawing.Point(263, 66)
        Me.lblLastExitMsg.Name = "lblLastExitMsg"
        Me.lblLastExitMsg.Size = New System.Drawing.Size(143, 16)
        Me.lblLastExitMsg.TabIndex = 5
        Me.lblLastExitMsg.Text = "請點擊確認離開！"
        '
        'lblLastMsg
        '
        Me.lblLastMsg.AutoSize = True
        Me.lblLastMsg.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLastMsg.Location = New System.Drawing.Point(22, 29)
        Me.lblLastMsg.Name = "lblLastMsg"
        Me.lblLastMsg.Size = New System.Drawing.Size(126, 32)
        Me.lblLastMsg.TabIndex = 4
        Me.lblLastMsg.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "安裝作業已完成"
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBack.Location = New System.Drawing.Point(4, 375)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(92, 32)
        Me.btnBack.TabIndex = 5
        Me.btnBack.Text = "<上一步(&B)"
        Me.btnBack.UseVisualStyleBackColor = True
        Me.btnBack.Visible = False
        '
        'skeSkin
        '
        Me.skeSkin.__DrawButtonFocusRectangle = True
        Me.skeSkin.DisabledButtonTextColor = System.Drawing.Color.Gray
        Me.skeSkin.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText
        Me.skeSkin.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.skeSkin.ResSysMenuClose = "關閉(&C)"
        Me.skeSkin.ResSysMenuMax = "最大化/還原(&X)"
        Me.skeSkin.SerialNumber = ""
        Me.skeSkin.SkinFile = Nothing
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, -2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 68)
        Me.Panel1.TabIndex = 6
        '
        'frmInstall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(442, 407)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.tabcInstallMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Icon = Global.ProjectInstall.My.Resources.Resources.System_install
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "客製程式安裝介面"
        Me.tabcInstallMain.ResumeLayout(False)
        Me.TabInstall1.ResumeLayout(False)
        Me.TabInstall1.PerformLayout()
        Me.TabInstall2.ResumeLayout(False)
        Me.TabInstall2.PerformLayout()
        Me.TabInstall3.ResumeLayout(False)
        Me.TabInstall3.PerformLayout()
        Me.TabInstall4.ResumeLayout(False)
        Me.TabInstall4.PerformLayout()
        Me.TabInstall5.ResumeLayout(False)
        Me.TabInstall5.PerformLayout()
        Me.TabInstall6.ResumeLayout(False)
        Me.TabInstall6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tabcInstallMain As System.Windows.Forms.TabControl
    Friend WithEvents TabInstall1 As System.Windows.Forms.TabPage
    Friend WithEvents TabInstall2 As System.Windows.Forms.TabPage
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents TabInstall3 As System.Windows.Forms.TabPage
    Friend WithEvents txtGuidance As System.Windows.Forms.TextBox
    Friend WithEvents lblTitleSub As System.Windows.Forms.Label
    Friend WithEvents lblTitleMain As System.Windows.Forms.Label
    Friend WithEvents trevInstallDetail As System.Windows.Forms.TreeView
    Friend WithEvents lnlSelectInstall As System.Windows.Forms.Label
    Friend WithEvents ImglInstallIcon As System.Windows.Forms.ImageList
    Friend WithEvents btnConnectTest As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents lblSetAdminAcc As System.Windows.Forms.Label
    Friend WithEvents TabInstall4 As System.Windows.Forms.TabPage
    Friend WithEvents lblCkInstallItem As System.Windows.Forms.Label
    Friend WithEvents lblWarringText As System.Windows.Forms.Label
    Friend WithEvents trevResult As System.Windows.Forms.TreeView
    Friend WithEvents ImglResult As System.Windows.Forms.ImageList
    Friend WithEvents skeSkin As Sunisoft.IrisSkin.SkinEngine
    Friend WithEvents TabInstall5 As System.Windows.Forms.TabPage
    Friend WithEvents TabInstall6 As System.Windows.Forms.TabPage
    Friend WithEvents prgProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents txtOutputResult As System.Windows.Forms.TextBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents lblLastExitMsg As System.Windows.Forms.Label
    Friend WithEvents lblLastMsg As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
