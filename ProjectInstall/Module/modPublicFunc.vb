Option Explicit On
Option Strict On

Imports System.Xml

Module modPublicFunc

#Region "   Public Function     "

    '取出XML資料
    Public Function ExtractXmlNodeInSet(ByVal strXmlData As String, _
                                        ByVal strXmlName As String, _
                                        ByVal strXmlNodeName As String, _
                                        ByRef strErrMsg As String) As XmlNode

        Dim objXMLDoc As New XmlDocument
        Dim objRoot As XmlNode = Nothing
        ExtractXmlNodeInSet = Nothing
        Try
            objXMLDoc.LoadXml(strXmlData)
            If objXMLDoc.DocumentElement Is Nothing Then strErrMsg = "[" & strXmlName & "]取得不到任何要素，請管理人員維護參數定義" : Exit Try
            objRoot = CType(objXMLDoc.DocumentElement, XmlNode)
            If objRoot.SelectSingleNode(strXmlNodeName) Is Nothing Then
                strErrMsg = "[" & strXmlName & "]取得不到[" & strXmlNodeName & "]要素，請管理人員維護參數定義" : Exit Try
            Else
                ExtractXmlNodeInSet = objRoot.SelectSingleNode(strXmlNodeName)
            End If
        Catch ex As Exception
            strErrMsg = ex.Message & System.Environment.NewLine & ex.StackTrace
        Finally
            objRoot = Nothing
            objXMLDoc = Nothing
        End Try
    End Function

    Public Function GetXMLAttribute(ByVal oElement As XmlElement, ByVal strAttribute As String, ByVal strDefault As String) As String
        Dim strRetValue As String = ""
        GetXMLAttribute = ""
        Try
            strRetValue = oElement.GetAttribute(strAttribute)
            If strRetValue = "" Then strRetValue = strDefault
            GetXMLAttribute = strRetValue
        Catch ex As Exception

        End Try
    End Function

    Public Function GetXMLAttribute(ByVal oNode As XmlNode, ByVal strAttribute As String) As String
        Dim oElement As XmlElement
        Dim LstrRetValue As String = String.Empty
        Dim strDefault As String = String.Empty
        GetXMLAttribute = ""
        Try
            oElement = CType(oNode, XmlElement)
            LstrRetValue = GetXMLAttribute(oElement, strAttribute, strDefault)
            GetXMLAttribute = LstrRetValue
        Catch ex As Exception
            GetXMLAttribute = ""
        End Try
    End Function

    Public Function SetXMLAttribute(ByRef oElement As XmlElement, ByVal strAttribute As String, ByVal strValue As String) As Boolean
        Try
            oElement.SetAttribute(strAttribute, strValue)
            SetXMLAttribute = True
        Catch ex As Exception
            SetXMLAttribute = False
        End Try
    End Function

    Public Function SetXMLAttribute(ByRef oNode As XmlNode, ByVal strAttribute As String, ByVal strValue As String) As Boolean
        Dim oElement As XmlElement
        Try
            oElement = CType(oNode, XmlElement)
            SetXMLAttribute(oElement, strAttribute, strValue)
            SetXMLAttribute = True
        Catch ex As Exception
            SetXMLAttribute = False
        End Try
    End Function

#End Region

End Module
