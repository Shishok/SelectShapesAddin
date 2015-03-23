Imports System.Drawing
Imports System.Windows.Forms


Partial Public Class Addin
    Public Property Application As Microsoft.Office.Interop.Visio.Application
    Dim SelObj As Visio.Selection
    Dim tmpExt As Boolean = False
    Dim tmpR As Boolean = False
    Dim tmpL As Boolean = False

    Public Sub OnCommand(commandId As String)
        Select Case commandId
            Case "ExtSelect"
                If tmpExt Then
                    Application.DoCmd(1909)
                    tmpExt = False
                    Return
                Else
                    Application.DoCmd(1909)
                    tmpExt = True
                    Return
                End If
            Case "RectSelect"
                Application.DoCmd(1223)
                tmpR = True : tmpL = False
                If tmpExt Then SelObj = Application.ActiveWindow.Selection
                UpdateRibbon()
                Return
            Case "LineSelect"
                Application.DoCmd(1221)
                tmpL = True : tmpR = False
                If tmpExt Then SelObj = Application.ActiveWindow.Selection
                UpdateRibbon()
                Return
            Case "QuickSelect"
                If Application.ActiveWindow.Page.Shapes.Count = 0 Then Exit Sub
                If frmNewFRM Is Nothing Then
                    frmNewFRM = New dlgSelectForm
                    frmNewFRM.Show()
                End If
                Return

        End Select
    End Sub

    Public Function IsCommandEnabled(commandId As String) As Boolean
        Select Case commandId
            Case "QuickSelect", "ExtSelect", "RectSelect", "LineSelect"
                Return Application IsNot Nothing AndAlso Application.ActiveWindow IsNot Nothing
        End Select
    End Function

    Public Function IsCommandPressed(commandId As String) As Boolean
        Select Case commandId
            Case "RectSelect"
                Return tmpR
            Case "LineSelect"
                Return tmpL
            Case "ExtSelect"
                Return tmpExt
        End Select
    End Function

    Public Function GetCommandLabel(command As String) As String
        Return My.Resources.ResourceManager.GetString(command & "_Label")
    End Function

    Sub Startup(app As Object)
        Application = DirectCast(app, Microsoft.Office.Interop.Visio.Application)
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)
        AddHandler Application.ShapeAdded, AddressOf Application_ShapeAdded
        AddHandler Application.DocumentCreated, AddressOf Application_DocumentListChanged
        AddHandler Application.DocumentOpened, AddressOf Application_DocumentListChanged
        AddHandler Application.BeforeDocumentClose, AddressOf Application_DocumentListChanged
    End Sub

    Private Sub Application_ShapeAdded(ByVal Sh As Microsoft.Office.Interop.Visio.Shape)
        If tmpR Or tmpL Then
            Dim Sel As Visio.Selection
            Sel = Sh.SpatialNeighbors(11, 0, 0)
            Application.ActiveWindow.Selection = Sel
            Sh.Delete()
            Application.DoCmd(1907)
            tmpR = False : tmpL = False
            If tmpExt Then
                For Each Sh In SelObj
                    Application.ActiveWindow.Select(Sh, 2)
                Next
            End If
            SelObj = Nothing
            UpdateRibbon()
        End If
    End Sub

    Private Sub Application_DocumentListChanged(ByVal doc As Microsoft.Office.Interop.Visio.Document)
        UpdateRibbon()
    End Sub

    Sub UpdateUI()
        UpdateRibbon()
    End Sub

End Class