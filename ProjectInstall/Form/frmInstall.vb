Option Explicit On
Option Strict On

Imports System.Xml
Imports System.Security
Imports Sunisoft.IrisSkin
Imports System.IO

Public Class frmInstall

#Region "   Private Declaration     "

    'System VarName
    Private MessageShow As New ProjectErrorMessage.clsShowBox
    Private LintMainPage As Integer = 1
    Private LstrDestPath As String = String.Empty
    Private LstrSettingXmlPath As String = Application.StartupPath & "\InstallProperty.xml"
    Private LstrCodeInstallPath As String = Application.StartupPath & "\安裝資料\"
    Private LhashInstallDetail As New Hashtable

    'xml標籤名稱
    Private LstrTypeName As String = "Type"
    Private LstrDescName As String = "name"
    Private LstrthrowName As String = "throw"
    Private LstrDestPathName As String = "Destpath"
    Private LstrSourPathName As String = "sourpath"
    Private LstrRegeCodeName As String = "RegeCode"
    Private LstrRegeResultName As String = "RegeditResult"
    Private LstrUnRegeCodeName As String = "UnRegeCode"

    'Install Tabpage Tag
    Private LstrTabStart As String = "Start"


    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" _
    (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer

#End Region

#Region "   Private Sub     "

    '同步選擇子階節點(樹狀)
    Private Sub CheckChildNodes(ByVal checkedNode As TreeNode, ByVal IsCheck As Boolean)
        Try
            For Each node As TreeNode In checkedNode.Nodes
                node.Checked = IsCheck
                CheckChildNodes(node, IsCheck)
            Next
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        End Try
    End Sub
    '取出節點全部的資料
    Public Sub ExtractXmlNodeAttribute(ByVal trevNode As TreeNode, ByRef hashXmlData As Hashtable)
        Dim objXMLDoc As New XmlDocument
        Dim objNode As XmlNode = Nothing
        Dim I As Integer
        Try
            objXMLDoc.LoadXml(trevNode.Name)
            objNode = CType(objXMLDoc.DocumentElement, XmlNode)
            For I = 0 To objNode.Attributes.Count - 1
                If hashXmlData.ContainsKey(objNode.Attributes.Item(I).Name) = False Then
                    hashXmlData.Add(objNode.Attributes.Item(I).Name, objNode.Attributes.Item(I).Value)
                End If
            Next
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        Finally
            objNode = Nothing
            objXMLDoc = Nothing
        End Try
    End Sub
    '設定介面皮膚
    Private Sub SetSkinFile(ByVal skin As SkinEngine, ByVal bytes As Byte())
        Try
            Using memoryStream As IO.MemoryStream = New IO.MemoryStream(bytes)
                skin.SkinStream = memoryStream
            End Using
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        End Try
    End Sub

#End Region

#Region "   Private Function     "

    '顯示安裝細項內容
    Private Function LoadInstallDetail(ByRef strErrMsg As String) As Boolean
        Dim objXMLDoc As New XmlDocument
        Dim objRoot As XmlNode = Nothing
        Dim objIntDtal As XmlNode
        Dim objFoldNoList As XmlNodeList
        Dim objFoldNo As XmlNode
        Dim TrevNode As TreeNode
        LoadInstallDetail = False
        Try
            If IO.File.Exists(LstrSettingXmlPath) = False Then strErrMsg = "安裝細項檔案[" & LstrSettingXmlPath & "]不存在，將關閉安裝作業程序！" : Exit Try
            objXMLDoc.Load(LstrSettingXmlPath)
            objRoot = CType(objXMLDoc.DocumentElement, XmlNode)
            objIntDtal = objRoot.SelectSingleNode("INSTALL_DETAIL")
            objFoldNoList = objIntDtal.SelectNodes("object")
            For Each objFoldNo In objFoldNoList
                If GetXMLAttribute(objFoldNo, "name") = "" Then strErrMsg = "節點未輸入name標籤內容，將關閉安裝作業程序！" : Exit Try
                TrevNode = Me.trevInstallDetail.Nodes.Add(objFoldNo.OuterXml, GetXMLAttribute(objFoldNo, "name"))
                If ChangeImgListIcon(TrevNode, GetXMLAttribute(objFoldNo, "Type"), strErrMsg) = False Then Exit Try
                If LoadInstallDetail(objFoldNo, TrevNode, strErrMsg) = False Then Exit Try
            Next
            LoadInstallDetail = True
        Catch ex As Exception
            strErrMsg = "產生安裝細項資料時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        Finally
            objRoot = Nothing
            TrevNode = Nothing
            objFoldNo = Nothing
            objXMLDoc = Nothing
            objIntDtal = Nothing
            objFoldNoList = Nothing
        End Try
    End Function
    '顯示安裝細項內容(迭代)
    Private Function LoadInstallDetail(ByVal objNode As XmlNode, ByVal trevTopNode As TreeNode, ByRef strErrMsg As String) As Boolean
        Dim TrevNode As TreeNode
        Dim objFoldNoList As XmlNodeList
        Dim objFoldNo As XmlNode
        LoadInstallDetail = False
        Try
            objFoldNoList = objNode.SelectNodes("Item")
            For Each objFoldNo In objFoldNoList
                If GetXMLAttribute(objFoldNo, "name") = "" Then strErrMsg = "節點未輸入name標籤內容，將關閉安裝作業程序！" : Exit Try
                TrevNode = trevTopNode.Nodes.Add(objFoldNo.OuterXml, GetXMLAttribute(objFoldNo, "name"))
                If ChangeImgListIcon(TrevNode, GetXMLAttribute(objFoldNo, "Type"), strErrMsg) = False Then Exit Try
                If LoadInstallDetail(objFoldNo, TrevNode, strErrMsg) = False Then Exit Try
            Next
            LoadInstallDetail = True
        Catch ex As Exception
            strErrMsg = "產生安裝細項資料時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        Finally
            TrevNode = Nothing
            objFoldNo = Nothing
            objFoldNoList = Nothing
        End Try
    End Function
    '更改樹狀圖示
    Private Function ChangeImgListIcon(ByVal trevNode As TreeNode, ByVal strType As String, ByRef strErrMsg As String) As Boolean
        ChangeImgListIcon = False
        Try
            Select Case strType.ToUpper     '預設為資料夾圖示
                Case "FOLDER"
                    trevNode.ImageIndex = 0 : trevNode.SelectedImageIndex = 0
                Case "DOCUMENT"
                    trevNode.ImageIndex = 1 : trevNode.SelectedImageIndex = 1
                Case "EXCEL"
                    trevNode.ImageIndex = 2 : trevNode.SelectedImageIndex = 2
                Case "WORD"
                    trevNode.ImageIndex = 3 : trevNode.SelectedImageIndex = 3
                Case "CONFIG"
                    trevNode.ImageIndex = 4 : trevNode.SelectedImageIndex = 4
                Case Else
                    trevNode.ImageIndex = 0 : trevNode.SelectedImageIndex = 0
            End Select
            ChangeImgListIcon = True
        Catch ex As Exception
            strErrMsg = "更換節點圖示時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        End Try
    End Function
    '取出選擇的項目
    Private Function ExtractTreeNodeSelete(ByVal trevTopNode As TreeNode, ByRef strErrMsg As String) As Boolean
        Dim trevDestNode, trevNode As TreeNode            'trevDestNode資料放置   ,   trevNode暫存節點
        Dim hashDestDetail As New Hashtable
        ExtractTreeNodeSelete = False
        Try
            For Each trevDestNode In Me.trevInstallDetail.Nodes
                '初始化資料
                hashDestDetail = New Hashtable : LstrDestPath = String.Empty
                '若有勾選擇才直行節點複製
                If trevDestNode.Checked = False Then Continue For
                ExtractXmlNodeAttribute(trevDestNode, hashDestDetail)
                '紀錄資料搬移的目的地位置
                If hashDestDetail.ContainsKey(LstrDestPathName) = True Then
                    LstrDestPath = hashDestDetail.Item(LstrDestPathName).ToString.Trim
                    '確認指定的位置是否存在指定的資料夾
                    If IO.Directory.Exists(LstrDestPath) = False Then IO.Directory.CreateDirectory(LstrDestPath)
                    '  strErrMsg = "指定搬移檔案位置的路徑[" & LstrDestPath & "]不存在" & vbCrLf & "請重新設定參數定義" : Exit Try
                Else
                    Continue For
                End If
                '執行子階節點屬性檢查
                For Each trevNode In trevDestNode.Nodes
                    '再次確認節點勾選狀態
                    If trevNode.Checked = False Then Continue For
                    '複製原有節點至確認的樹結構中
                    If CopyNodeToAnotherNode(trevNode, trevTopNode, strErrMsg) = False Then Exit Try
                Next
            Next
            ExtractTreeNodeSelete = True
        Catch ex As Exception
            strErrMsg = "取出節點資訊時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        Finally
            trevNode = Nothing
            trevDestNode = Nothing
            hashDestDetail = Nothing
        End Try
    End Function
    '複製樹節點及其子階
    Private Function CopyNodeToAnotherNode(ByVal trevSourNode As TreeNode, ByVal trevDestNode As TreeNode, ByRef strErrMsg As String) As Boolean
        Dim trevNode, trevNewNode As TreeNode
        Dim hashDestDetail As New Hashtable
        Dim strSourPathName As String = String.Empty
        CopyNodeToAnotherNode = False
        Try
            '取出來原節點資料
            ExtractXmlNodeAttribute(trevSourNode, hashDestDetail)
            If hashDestDetail.Count = 0 Then strErrMsg = "節點資料不存在" : Exit Try
            '加入節點檢查/屬性資料
            If hashDestDetail.ContainsKey(LstrDestPathName) = False Then
                hashDestDetail.Add(LstrDestPathName, LstrDestPath)
            Else
                '確認指定的位置是否存在指定的資料夾
                'If IO.Directory.Exists(hashDestDetail.Item(LstrDestPathName).ToString.Trim) = False Then strErrMsg = "指定搬移檔案位置的路徑[" & LstrDestPath & "]不存在" & vbCrLf & "請重新設定參數定義" : Exit Try
                If IO.Directory.Exists(hashDestDetail.Item(LstrDestPathName).ToString.Trim) = False Then IO.Directory.CreateDirectory(hashDestDetail.Item(LstrDestPathName).ToString.Trim)
                LstrDestPath = hashDestDetail.Item(LstrDestPathName).ToString.Trim
            End If

            '檢查標籤內容若沒問題則記錄到全域的資料中
            If CheckHashTagExist(hashDestDetail, strErrMsg) = False Then Exit Try
            LhashInstallDetail.Add((LhashInstallDetail.Count + 1).ToString.Trim, hashDestDetail)
            '複製節點資料到另外的樹結構上
            trevNewNode = trevDestNode.Nodes.Add((LhashInstallDetail.Count).ToString.Trim, trevSourNode.Text)
            Select Case hashDestDetail.Item(LstrTypeName).ToString.Trim.ToUpper
                Case "FOLDER"   'Type為資料夾的情況下檢查資料夾來源實體路徑有無存在
                    If IO.Directory.Exists(LstrCodeInstallPath & hashDestDetail.Item(LstrSourPathName).ToString.Trim & hashDestDetail.Item(LstrDescName).ToString.Trim) = False Then
                        IO.Directory.CreateDirectory(LstrCodeInstallPath & hashDestDetail.Item(LstrSourPathName).ToString.Trim & hashDestDetail.Item(LstrDescName).ToString.Trim)
                        'trevNewNode.ImageIndex = 2 : trevNewNode.SelectedImageIndex = 2 : trevNewNode.Text = trevNewNode.Text & "--[不存在]"
                        'btnNext.Enabled = False
                    Else
                        trevNewNode.ImageIndex = 1 : trevNewNode.SelectedImageIndex = 1
                    End If
                Case Else       'Type為其他(檔案)的情況下檢查檔案來源實體路徑有無存在
                    If IO.File.Exists(LstrCodeInstallPath & hashDestDetail.Item(LstrSourPathName).ToString.Trim & hashDestDetail.Item(LstrDescName).ToString.Trim) = False Then
                        trevNewNode.ImageIndex = 2 : trevNewNode.SelectedImageIndex = 2 : trevNewNode.Text = trevNewNode.Text & "--[不存在]"
                        btnNext.Enabled = False
                    Else
                        trevNewNode.ImageIndex = 1 : trevNewNode.SelectedImageIndex = 1
                    End If
            End Select
            '進行迭代資料寫入
            For Each trevNode In trevSourNode.Nodes
                If trevNode.Checked = False Then Continue For
                CopyNodeToAnotherNode(trevNode, trevNewNode, strErrMsg)
            Next

            CopyNodeToAnotherNode = True
        Catch ex As Exception
            strErrMsg = "確認選擇節點的時候發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        Finally
            trevNode = Nothing
            trevNewNode = Nothing
            hashDestDetail = Nothing
        End Try
    End Function
    '檢查安裝的標籤內容是否存在
    Private Function CheckHashTagExist(ByVal hashTable As Hashtable, ByRef strErrMsg As String) As Boolean
        CheckHashTagExist = False
        Try
            If hashTable.ContainsKey(LstrDestPathName) = False Then
                strErrMsg = "已檢查到缺少標籤欄位[" & LstrDestPathName & "]請補上內容" : Exit Try
            ElseIf hashTable.ContainsKey(LstrSourPathName) = False Then
                strErrMsg = "已檢查到缺少標籤欄位[" & LstrSourPathName & "]請補上內容" : Exit Try
            ElseIf hashTable.ContainsKey(LstrthrowName) = False Then
                strErrMsg = "已檢查到缺少標籤欄位[" & LstrthrowName & "]請補上內容" : Exit Try
            ElseIf hashTable.ContainsKey(LstrDescName) = False Then
                strErrMsg = "已檢查到缺少標籤欄位[" & LstrDescName & "]請補上內容" : Exit Try
            ElseIf hashTable.ContainsKey(LstrTypeName) = False Then
                strErrMsg = "已檢查到缺少標籤欄位[" & LstrTypeName & "]請補上內容" : Exit Try
            End If
            CheckHashTagExist = True
        Catch ex As Exception
            strErrMsg = "檢查標籤內容時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        End Try
    End Function
    '執行程式註冊
    Private Function ExecutionDebugRegister(ByVal strRegisterDllPath As String, ByVal strArgument As String, ByRef strErrMsg As String) As Boolean
        Dim ProcessStartInfo As New ProcessStartInfo(strRegisterDllPath)
        Dim process As New Process
        ExecutionDebugRegister = False
        Try
            '首先要進行解除登入檔作業
            With ProcessStartInfo
                'The following properties run the new process as administrator
                .WorkingDirectory = strArgument
                .Arguments = "CD " & strArgument
                .UseShellExecute = False
                .Verb = "runas"
                .WindowStyle = ProcessWindowStyle.Normal
                .CreateNoWindow = False
                .UserName = txtAccount.Text.Trim
                .Password = ConvertToSecureString(txtPassword.Text.Trim)
            End With
            process = process.Start(ProcessStartInfo)
            process.WaitForExit()

            ExecutionDebugRegister = True
        Catch ex As Exception
            strErrMsg = "取出節點資訊時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
            If Not process Is Nothing Then process.Close() : process.Dispose() : process.Kill()
        End Try
    End Function
    '解查程式有無成功註冊
    Private Function CheckCodeCorrectRes(ByVal strCheckFile As String, ByRef strErrMsg As String) As Boolean
        CheckCodeCorrectRes = False
        Try
            System.Threading.Thread.Sleep(1000)
            If IO.File.Exists(strCheckFile) = True Then
                'Update Complete
                CheckCodeCorrectRes = True
            Else
                'Update Failed
                strErrMsg = "主程式更新失敗，未找到新版本的tlb檔案" & vbCrLf & "程式更新失敗，將返回上一個步驟！" : Exit Try
            End If
        Catch ex As Exception
            strErrMsg = "檢查程式註冊時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        End Try
    End Function
    '檢查輸入的cmd帳戶為最高權限或帳密輸入是否正確
    Private Function CheckExecuteAccountCorrect() As Boolean
        Dim process As New Process
        Dim ProcessStartInfo As New ProcessStartInfo("cmd.exe")
        Try
            With ProcessStartInfo
                ' The following properties run the new process as administrator
                .UseShellExecute = False
                .Verb = "runas"
                .WindowStyle = ProcessWindowStyle.Normal
                .CreateNoWindow = False
                .UserName = txtAccount.Text.Trim
                .Password = ConvertToSecureString(txtPassword.Text.Trim)
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            process = process.Start(ProcessStartInfo)
            If Not process Is Nothing Then process.Kill()
            CheckExecuteAccountCorrect = True
        Catch ex As Exception
            CheckExecuteAccountCorrect = False
        Finally
            process = Nothing
            ProcessStartInfo = Nothing
        End Try
    End Function
    '轉換密碼變數
    Private Function ConvertToSecureString(ByVal str As String) As SecureString
        Dim password As New SecureString
        For Each c As Char In str.ToCharArray
            password.AppendChar(c)
        Next
        Return password
    End Function
    '執行檔案的搬移~程式的安裝
    Private Function InstallCodeAndFileTranslate(ByVal trevTopNode As TreeNode, ByRef strErrMsg As String) As Boolean
        Dim trevNode As TreeNode = Nothing
        Dim hashXmlData As Hashtable
        InstallCodeAndFileTranslate = False
        Try
            If trevTopNode Is Nothing Then
                For Each trevNode In Me.trevResult.Nodes
                    If Not trevNode.Tag Is Nothing Then         '由Tag判斷是否為單純顯示或匯入資料
                        If trevNode.Name.ToString.Trim <> "" Then
                            '取出基本資料
                            hashXmlData = New Hashtable : hashXmlData = CType(LhashInstallDetail.Item(trevNode.Name), Hashtable)
                            If CopyFileAndResCode(hashXmlData, strErrMsg) = False Then Exit Try
                        Else
                            '進入迭代
                            If InstallCodeAndFileTranslate(trevNode, strErrMsg) = False Then Exit Try
                        End If
                    End If
                Next
            Else
                For Each trevNode In trevTopNode.Nodes
                    If trevNode.Tag Is Nothing Then         '由Tag判斷是否為單純顯示或匯入資料
                        If trevNode.Name.ToString.Trim <> "" Then
                            '取出基本資料
                            hashXmlData = New Hashtable : hashXmlData = CType(LhashInstallDetail.Item(trevNode.Name), Hashtable)
                            If CopyFileAndResCode(hashXmlData, strErrMsg) = False Then Exit Try
                        End If
                        '再次進入迭代
                        If InstallCodeAndFileTranslate(trevNode, strErrMsg) = False Then Exit Try
                    End If
                Next
            End If

            InstallCodeAndFileTranslate = True
        Catch ex As Exception
            strErrMsg = "執行檔案搬移及安裝程式時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        Finally
            trevNode = Nothing
            hashXmlData = Nothing
        End Try
    End Function
    '執行檔案安裝/搬移 副程式
    Private Function CopyFileAndResCode(ByVal hashXmlData As Hashtable, ByRef strErrMsg As String) As Boolean

        Dim Files As String()
        Dim strTypeName As String = String.Empty
        Dim strDescName As String = String.Empty
        Dim strDestPath As String = String.Empty
        Dim strSourPath As String = String.Empty
        Dim strRegeCode As String = String.Empty
        Dim strFileName As String = String.Empty
        Dim strThrowName As String = String.Empty
        Dim strRegeResult As String = String.Empty
        Dim strUnRegeCode As String = String.Empty
        Dim blnThrowFile As Boolean = False

        CopyFileAndResCode = False
        Try
            If hashXmlData.ContainsKey(LstrDescName) = True Then strDescName = hashXmlData.Item(LstrDescName).ToString.Trim '名稱
            If hashXmlData.ContainsKey(LstrthrowName) = True Then strThrowName = hashXmlData.Item(LstrthrowName).ToString.Trim '是否搬移
            If hashXmlData.ContainsKey(LstrDestPathName) = True Then strDestPath = hashXmlData.Item(LstrDestPathName).ToString.Trim '目的地路徑
            If hashXmlData.ContainsKey(LstrSourPathName) = True Then strSourPath = hashXmlData.Item(LstrSourPathName).ToString.Trim '來源路徑
            If hashXmlData.ContainsKey(LstrRegeCodeName) = True Then strRegeCode = hashXmlData.Item(LstrRegeCodeName).ToString.Trim '註冊登入程式
            If hashXmlData.ContainsKey(LstrUnRegeCodeName) = True Then strUnRegeCode = hashXmlData.Item(LstrUnRegeCodeName).ToString.Trim '解除登陸程式
            If hashXmlData.ContainsKey(LstrRegeResultName) = True Then strRegeResult = hashXmlData.Item(LstrRegeResultName).ToString.Trim '註冊登入結果
            If hashXmlData.ContainsKey(LstrTypeName) = True Then strTypeName = hashXmlData.Item(LstrTypeName).ToString.Trim
            If Boolean.TryParse(strThrowName, False) = True Then blnThrowFile = CBool(strThrowName) '判斷讀取字串是否為true/false 若都不是則默認為false

            If strRegeCode.Trim <> "" And strUnRegeCode <> "" Then
                prgProcess.Value += 1
                txtOutputResult.Text += "註冊程式搬移中.."
                '程式註冊相關
                If strDestPath.Substring(strDestPath.Length - 1, 1) <> "\" Then strDestPath &= "\"
                '程式解除登入   (使用者管理者權限)  
                If IO.File.Exists(strDestPath & strDescName & "\" & strUnRegeCode) = True Then
                    If ExecutionDebugRegister(strDestPath & strDescName & "\" & strUnRegeCode, strDestPath & strDescName, strErrMsg) = False Then Exit Try
                End If
                '先賦予資料夾權限(預防無法刪除的錯誤)
                If GrantControlAuthForDir(strDestPath & strDescName, strErrMsg) = False Then Exit Try
                '先進行原本檔案的刪除
                If IO.Directory.Exists(strDestPath & strDescName) Then IO.Directory.Delete(strDestPath & strDescName, True)
                '將安裝包的資料夾同檔案進行搬移
                IO.Directory.CreateDirectory(strDestPath & strDescName)
                '再次賦予資料夾權限(預防無法刪除的錯誤)
                If GrantControlAuthForDir(strDestPath & strDescName, strErrMsg) = False Then Exit Try
                Threading.Thread.Sleep(1500)
                prgProcess.Value += 1
                txtOutputResult.Text += vbCrLf & "註冊程式搬移中..已完成"
                txtOutputResult.Text += vbCrLf & "註冊程式註冊中.."
                Files = System.IO.Directory.GetFiles(LstrCodeInstallPath & strSourPath & strDescName)
                For Each File As String In Files
                    strFileName = System.IO.Path.GetFileName(File)
                    IO.File.Copy(File, strDestPath & strDescName & "\" & IO.Path.GetFileName(File), True)
                Next
                '程式註冊
                If ExecutionDebugRegister(strDestPath & strDescName & "\" & strRegeCode, strDestPath & strDescName, strErrMsg) = False Then Exit Try
                Threading.Thread.Sleep(1500)        '等待1.5秒
                If CheckCodeCorrectRes(strDestPath & strDescName & "\" & strRegeResult, strErrMsg) = False Then btnBack_Click(btnBack, New System.EventArgs) : Exit Try
                prgProcess.Value += 1
                txtOutputResult.Text += vbCrLf & "註冊程式註冊中..已完成"
                txtOutputResult.Text += vbCrLf & "註冊程式設定中.."
            Else
                '一般檔案搬移
                If blnThrowFile = True Then
                    Select Case strTypeName.Trim.ToUpper
                        Case "FOLDER"
                            '先賦予資料夾權限(預防無法刪除的錯誤)
                            If GrantControlAuthForDir(strDestPath & strDescName, strErrMsg) = False Then Exit Try
                            '先進行原本檔案的刪除
                            If IO.Directory.Exists(strDestPath & strDescName) Then IO.Directory.Delete(strDestPath & strDescName)
                            '將安裝包的資料夾同檔案進行搬移
                            If strDestPath.Substring(strDestPath.Length - 1, 1) <> "\" Then strDestPath &= "\"
                            IO.Directory.CreateDirectory(strDestPath & strDescName)
                            '再次賦予資料夾權限(預防無法刪除的錯誤)
                            If GrantControlAuthForDir(strDestPath & strDescName, strErrMsg) = False Then Exit Try
                            Files = System.IO.Directory.GetFiles(LstrCodeInstallPath & strSourPath & strDescName)
                            For Each File As String In Files
                                strFileName = System.IO.Path.GetFileName(File)
                                IO.File.Copy(File, strDestPath & strDescName & "\" & IO.Path.GetFileName(File), True)
                            Next
                        Case Else
                            '先進行原本檔案的刪除
                            If strDestPath.Substring(strDestPath.Length - 1, 1) <> "\" Then strDestPath &= "\"
                            If IO.File.Exists(strDestPath & strDescName) Then IO.File.Delete(strDestPath & strDescName)
                            '將安裝包的文件進行搬移
                            IO.File.Copy(LstrCodeInstallPath & strSourPath & strDescName, strDestPath & strDescName, True)
                    End Select
                End If
            End If

            CopyFileAndResCode = True
        Catch ex As Exception
            strErrMsg = "執行檔案搬移及安裝程式時發生錯誤，原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        End Try
    End Function
    '檢查檔案或資料夾有無被鎖定
    Private Function CheckFileAndDirIsLock(ByRef strErrMsg As String) As Boolean

        Dim IsError = True
        Dim ReadIO As FileStream = Nothing
        Dim Mcu_Save_CSV_File As String = "Read/Data/123.csv"

        CheckFileAndDirIsLock = False
        Try
            While IsError = True
                Try
                    ReadIO = File.OpenRead(Mcu_Save_CSV_File)       '/開啟檔案等待有無錯誤訊息
                    IsError = False                                 '/預設沒有錯誤狀態
                Catch Have_Read As System.IO.IOException
                    '/讀取Have_Read.GetType.ToString目前狀態
                    '/當出現System.IO.FileNotFoundException為檔案路徑不存在
                    '/當出現System.IO.IOException為檔案被占用
                    If Have_Read.GetType.ToString = "System.IO.FileNotFoundException" Then
                        File.Create(Mcu_Save_CSV_File).Dispose()
                        FileClose()
                    Else
                        strErrMsg = "目前檔案被開啟，請關閉檔案後再試"
                    End If
                End Try
            End While
            If Not ReadIO Is Nothing Then ReadIO.Close() '/關閉開啟的檔案

            CheckFileAndDirIsLock = True
        Catch ex As Exception
            strErrMsg = "檔案被鎖定，無法正確執行刪除作業，請關閉檔案後再執行此操作" & vbCrLf & "原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        End Try
    End Function
    '給予設定的資料夾完全控制的權限
    Private Function GrantControlAuthForDir(ByVal strDirectory As String, ByRef strErrMsg As String) As Boolean
        Dim ProcessStartInfo As New ProcessStartInfo("cmd.exe")
        Dim process As New Process
        GrantControlAuthForDir = False
        Try

            '首先要進行解除登入檔作業
            With ProcessStartInfo
                'The following properties run the new process as administrator
                .Arguments = "icacls " & strDirectory.Replace("\", "/") & " /grant everyone:F /T"
                .UseShellExecute = False
                .Verb = "runas"
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = False
                .UserName = txtAccount.Text.Trim
                .Password = ConvertToSecureString(txtPassword.Text.Trim)
                .RedirectStandardInput = True
                .RedirectStandardOutput = True
                .RedirectStandardError = True
            End With
            process = process.Start(ProcessStartInfo)
            process.StandardInput.WriteLine(ProcessStartInfo.Arguments)
            process.StandardInput.AutoFlush = True
            process.WaitForExit(100)
            'process.Kill()

            GrantControlAuthForDir = True
        Catch ex As Exception
            strErrMsg = "賦予權限時發生錯誤，請重新確認使用者權限管理" & vbCrLf & "原因：" & vbCrLf & ex.Message & System.Environment.NewLine & ex.StackTrace
        End Try
    End Function

#End Region

#Region "   Form   "

    Private Sub frmInstall_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim strErrMsg As String = String.Empty
        Try
            '介面設計資源版面調整
            SetSkinFile(skeSkin, My.Resources.mp10) : skeSkin.DisableTag = 9999
            '固定介面大小
            Me.MaximumSize = Me.Size : Me.MinimumSize = Me.Size
            '帶入安裝包的xml資訊
            If LoadInstallDetail(strErrMsg) = False Then MessageShow.showErrMessageBox(strErrMsg, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error) : Me.Close()
            Me.trevInstallDetail.ExpandAll()
            '修改字體顏色
            lblWarringText.ForeColor = Color.Red
            Me.tabcInstallMain.SelectedTab.BackColor = Color.LightSkyBlue
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error) : Me.Close()
        End Try
    End Sub

#End Region

#Region "   Button   "

    '下一步
    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Dim trevNode As TreeNode
        Dim strErrMsg As String = String.Empty
        Try
            If btnNext.Text.IndexOf("下一步") > -1 Then
                LintMainPage += 1
                '接換頁籤
                Me.tabcInstallMain.SelectedTab = CType(tabcInstallMain.Controls("TabInstall" & LintMainPage.ToString), TabPage)
                If Me.tabcInstallMain.SelectedTab.BackColor <> Color.LightSkyBlue Then Me.tabcInstallMain.SelectedTab.BackColor = Color.LightSkyBlue
                '控制頁簽變量：tabcInstallMain.Controls.Count - 2
                If LintMainPage = tabcInstallMain.Controls.Count - 2 Then btnNext.Visible = True : btnNext.Text = "(&O)完成"
                btnBack.Visible = True
                '檢查最終結果
                If btnNext.Text.IndexOf("完成") > -1 Then
                    If CheckExecuteAccountCorrect() = False Then
                        btnNext.Enabled = False
                        trevNode = Me.trevResult.Nodes.Add("所輸入Windows帳號密碼不正確！")
                        trevNode.Tag = "Check" : trevNode.ImageIndex = 2 : trevNode.SelectedImageIndex = 2
                        btnClose.Enabled = False
                    Else
                        '初始化資料
                        btnNext.Enabled = True : LhashInstallDetail = New Hashtable
                        '設定基本複製樹資料
                        trevNode = Me.trevResult.Nodes.Add("所輸入Windows帳號密碼正確！")
                        trevNode.Tag = "Check" : trevNode.ImageIndex = 1 : trevNode.SelectedImageIndex = 1
                        trevNode = Me.trevResult.Nodes.Add("以下為安裝項目的細項：")
                        trevNode.Tag = "Check" : trevNode.ImageIndex = 0 : trevNode.SelectedImageIndex = 0
                        '帶入確認資訊
                        If ExtractTreeNodeSelete(trevNode, strErrMsg) = False Then MessageShow.showErrMessageBox(strErrMsg, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error) : btnBack_Click(btnBack, New System.EventArgs)
                        Me.trevResult.ExpandAll()
                    End If
                End If
            ElseIf btnNext.Text.IndexOf("完成") > -1 Then
                If MessageBox.Show("請問是否選擇完成安裝/更新SmarTeam客製程式的作業內容？", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    '接換頁籤(安裝進度)
                    LintMainPage += 1
                    Me.tabcInstallMain.SelectedTab = CType(tabcInstallMain.Controls("TabInstall" & LintMainPage.ToString), TabPage)
                    If Me.tabcInstallMain.SelectedTab.BackColor <> Color.LightSkyBlue Then Me.tabcInstallMain.SelectedTab.BackColor = Color.LightSkyBlue
                    btnClose.Enabled = False
                    '取出安裝資料和搬移檔案
                    If InstallCodeAndFileTranslate(Nothing, strErrMsg) = False Then MessageShow.showErrMessageBox(strErrMsg, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
                    '接換頁籤(結果)
                    LintMainPage += 1
                    Me.tabcInstallMain.SelectedTab = CType(tabcInstallMain.Controls("TabInstall" & LintMainPage.ToString), TabPage)
                    If Me.tabcInstallMain.SelectedTab.BackColor <> Color.LightSkyBlue Then Me.tabcInstallMain.SelectedTab.BackColor = Color.LightSkyBlue
                    btnNext.Text = "(&P)確認" : btnBack.Visible = False
                End If
            ElseIf btnNext.Text.IndexOf("確認") > -1 Then
                Me.Close()
            End If
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        Finally
            trevNode = Nothing
            btnClose.Enabled = True
        End Try
    End Sub
    '上一步
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Try
            btnClose.Enabled = True : LintMainPage -= 1
            Me.tabcInstallMain.SelectedTab = CType(tabcInstallMain.Controls("TabInstall" & LintMainPage.ToString), TabPage)
            If LintMainPage = 1 Then btnBack.Visible = False
            If btnNext.Text.IndexOf("完成") > -1 Then
                btnNext.Visible = True : btnNext.Text = ">下一步(&N)"
                trevResult.Nodes.Clear() : btnNext.Enabled = True
            End If
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        End Try
    End Sub
    '關閉
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        End Try
    End Sub
    '測試電腦登入帳號密碼是否正確
    Private Sub btnConnectTest_Click(sender As System.Object, e As System.EventArgs) Handles btnConnectTest.Click
        Try
            If CheckExecuteAccountCorrect() = True Then
                MessageBox.Show("測試登入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("測試登入失敗！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        End Try
    End Sub

#End Region

#Region "   TreeView   "

    Private Sub trevInstallDetail_AfterCheck(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles trevInstallDetail.AfterCheck
        Try
            CheckChildNodes(e.Node, e.Node.Checked)
        Catch ex As Exception
            MessageShow.showErrMessageBox(ex, "錯誤", ProjectErrorMessage.clsShowBox.IconSetting.Error)
        End Try
    End Sub

#End Region

End Class

' Private LarrPageList As New ArrayList

'Dim tbPage As TabPage
'tbPage = TabControl1.TabPages.Item(0)
'LarrPageList.Add(tbPage)
'TabControl1.TabPages.Remove(tbPage)

'TabControl1.TabPages.Insert(0, LarrPageList.Item(0))
'LarrPageList.RemoveAt(0)
