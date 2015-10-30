Public Class dlgSaveSelectForm

    Dim vsoApp As Visio.Application = Globals.ThisAddIn.Application
    Dim winObj As Visio.Window
    Dim UserRow As Visio.Row

#Region "Subs"

    Private Sub AddGroupShapes()
        If winObj.Selection.Count = 0 Then GoTo Msg1

        Dim strPrompt As String = fNameGroup()
        If strPrompt Is Nothing Then Exit Sub
        If Strings.Trim(strPrompt) = "" Then GoTo Msg

        If fCheckName(strPrompt) Then GoTo Msg2

        Call AddRow(fStringID(), strPrompt)

        Exit Sub
Msg:
        MsgBox("Имя новой группы не задано.", vbInformation, "Ошибка") : Exit Sub
Msg1:
        MsgBox("На текущей странице нет выделенных объектов.", vbInformation, "Ошибка") : Exit Sub
Msg2:
        MsgBox("Это имя группы уже используется. Используйте другое имя.", vbInformation, "Ошибка")
    End Sub

    Private Sub CloneGroup(arg)
        If cmb_ListGroups.SelectedItem = "" Then Exit Sub

        Dim strPrompt As String = fNameGroup()
        If strPrompt Is Nothing Then Exit Sub
        If Strings.Trim(strPrompt) = "" Then GoTo Msg

        If fCheckName(strPrompt) Then GoTo Msg1

        Dim strValue As String = winObj.Shape.Section(242).Row(fGetRowIndex(arg)).Cell(0).ResultStr("")
        Call AddRow(winObj.Shape.Section(242).Row(fGetRowIndex(arg)).Cell(0).ResultStr(""), strPrompt)

        Exit Sub
Msg:
        MsgBox("Имя новой группы не задано.", vbInformation, "Ошибка") : Exit Sub
Msg1:
        MsgBox("Это имя группы уже используется. Используйте другое имя.", vbInformation, "Ошибка")
    End Sub

    Private Sub SelectGroups(arg)
        If cmb_ListGroups.SelectedItem = "" Then Exit Sub

        Dim Shs As Visio.Shapes, ListID() As String, i As Integer
        If ckb_DeSelect.Checked Then winObj.Select(winObj.Page.Shapes.item(1), 256)

        With winObj.Shape
            Shs = .Shapes
            UserRow = .Section(242).Row(fGetRowIndex(arg))
            ListID = Split(UserRow.Cell(0).ResultStr(""), ",")
        End With

        On Error Resume Next
        For i = 0 To UBound(ListID)
            winObj.Select(Shs.ItemFromID(Val(ListID(i))), 2)
        Next
        Me.Close()
    End Sub

    Private Sub AddIdToGroup(arg)
        If winObj.Selection.Count = 0 OrElse cmb_ListGroups.SelectedItem = "" Then Exit Sub

        UserRow = winObj.Shape.Section(242).Row(fGetRowIndex(arg))
        Dim strTemp As String = UserRow.Cell(0).ResultStr("") & "," & fStringID()
        UserRow.Cell(0).FormulaForceU = """" & strTemp & """"

    End Sub

    Private Sub RemoveIdFromGroup(arg)
        If winObj.Selection.Count = 0 OrElse cmb_ListGroups.SelectedItem = "" Then Exit Sub

        Dim j As Integer

        With winObj
            UserRow = .Shape.Section(242).Row(fGetRowIndex(arg))
            Dim strTemp As String = UserRow.Cell(0).ResultStr("")
            For j = 1 To .Selection.Count
                strTemp = fReplace(strTemp, .Selection(j).ID)
            Next
            UserRow.Cell(0).FormulaForceU = """" & strTemp & """"
        End With

    End Sub

    Private Sub RemoveMissingIdFromGroup(arg)
        If cmb_ListGroups.SelectedItem = "" Then Exit Sub

        Dim Shs As Visio.Shapes, j As Integer, ListID() As String, tmp As Integer

        With winObj.Shape
            Shs = .Shapes
            UserRow = .Section(242).Row(fGetRowIndex(arg))
            ListID = Split(UserRow.Cell(0).ResultStr(""), ",")

            On Error Resume Next
            For j = 0 To UBound(ListID)
                tmp = Shs.ItemFromID(Val(ListID(j))).ID
                If Err.Number <> 0 Then
                    UserRow.Cell(0).FormulaForceU = """" & fReplace(UserRow.Cell(0).ResultStr(""), Val(ListID(j))) & """"
                    Err.Clear()
                End If
            Next
        End With

    End Sub

    Private Sub DeleteGroups(arg)
        If cmb_ListGroups.SelectedItem = "" Then Exit Sub

        Dim i As Integer

        With winObj.Shape
            For i = .Section(242).Count - 1 To 0 Step -1
                If arg <> "All" Then
                    If .Section(242).Row(i).Cell(1).ResultStr("") = arg Then
                        .DeleteRow(242, i)
                        Exit For
                    End If
                Else
                    If .Section(242).Row(i).NameU Like "GroupShapes_*" Then .DeleteRow(242, i)
                End If
            Next

            If .Section(242).Count = 0 Then .DeleteSection(242)
        End With

    End Sub

    Private Sub AddRow(arg, arg1)
        Dim NowTime As String = Day(Now) & Hour(Now) & Minute(Now) & Second(Now)

        With winObj.Shape
            If Not .SectionExists(242, 1) Then .AddSection(242)
            .AddNamedRow(242, "GroupShapes_" & NowTime, 0)

            UserRow = .Section(242).Row(.Cells("User.GroupShapes_" & NowTime & ".Value").Row)
            With UserRow
                .Cell(0).FormulaForceU = """" & arg & """"
                .Cell(1).FormulaForceU = """" & arg1 & """"
            End With
        End With

    End Sub

    Private Sub RefreshCmb()
        cmb_ListGroups.Items.Clear()
        cmb_ListGroups.Items.AddRange(Split(fReadGroups, ","))
        If cmb_ListGroups.Items.Count <> 0 Then cmb_ListGroups.SelectedIndex = 0
    End Sub

#End Region

#Region "Functions"

    Private Function fCheckName(arg) As Boolean
        For i = 0 To cmb_ListGroups.Items.Count - 1
            If cmb_ListGroups.Items(i) = arg Then Return True
        Next
    End Function

    Private Function fGetRowIndex(arg) As Integer
        With winObj.Shape
            For i = 0 To .Section(242).Count - 1
                If .Section(242).Row(i).Cell(1).ResultStr("") = arg Then Return i
            Next
        End With
    End Function

    Private Function fStringID() As String
        Dim strValue As String = ""
        Dim Sh As Visio.Shape

        For Each Sh In winObj.Selection
            strValue = strValue & Sh.ID & ","
        Next
        Return Strings.Left(strValue, Strings.Len(strValue) - 1)
    End Function

    Private Function fNameGroup() As String
        Return Replace$(InputBox("Введите имя для группы выделенных фигур", "Новая группа", "Группа "), ",", "_", 1, -1)
    End Function

    Private Function fReadGroups() As String
        Dim i As Integer, strTemp As String = ""

        With winObj.Shape
            If .SectionExists(242, 1) Then
                For i = 0 To .Section(242).Count - 1
                    If .Section(242).Row(i).NameU Like "GroupShapes_###*" Then
                        strTemp = strTemp & .Section(242).Row(i).Cell(1).ResultStr("") & ","
                    End If
                Next
                Return Strings.Left(strTemp, Strings.Len(strTemp) - 1)
            Else
                Return ""
            End If
        End With
    End Function

    Private Function fReplace(Text, iID) As String
        Return Replace$(Replace$(Replace$(Replace$("*" & Text & "*", "," & iID & ",", ",", 1, 1), "*" & iID & ",", "", 1, 1), "," & iID & "*", "", 1, 1), "*", "")
    End Function

#End Region

#Region "Form Procedure"

    Private Sub dlgSaveSelectForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        winObj = vsoApp.ActiveWindow
        Call RefreshCmb()
    End Sub

    Private Sub btn_NewGroup_Click(sender As Object, e As EventArgs) Handles btn_NewGroup.Click
        Call AddGroupShapes()
        Call RefreshCmb()
    End Sub

    Private Sub btn_DeleteGroup_Click(sender As Object, e As EventArgs) Handles btn_DeleteGroup.Click
        Call DeleteGroups(cmb_ListGroups.SelectedItem)
        Call RefreshCmb()
        If cmb_ListGroups.Items.Count = 0 Then Me.Close()
    End Sub

    Private Sub btn_AddToGroup_Click(sender As Object, e As EventArgs) Handles btn_AddToGroup.Click
        AddIdToGroup(cmb_ListGroups.SelectedItem)
    End Sub

    Private Sub btn_RemoveFromGroup_Click(sender As Object, e As EventArgs) Handles btn_RemoveFromGroup.Click
        RemoveIdFromGroup(cmb_ListGroups.SelectedItem)
    End Sub

    Private Sub btn_DeleteAll_Click(sender As Object, e As EventArgs) Handles btn_DeleteAll.Click
        Call DeleteGroups("All")
        Me.Close()
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Call SelectGroups(cmb_ListGroups.SelectedItem)
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

    Private Sub btn_CloneGroup_Click(sender As Object, e As EventArgs) Handles btn_CloneGroup.Click
        CloneGroup(cmb_ListGroups.SelectedItem)
        Call RefreshCmb()
    End Sub

    Private Sub btn_DelMissing_Click(sender As Object, e As EventArgs) Handles btn_DelMissing.Click
        RemoveMissingIdFromGroup(cmb_ListGroups.SelectedItem)
    End Sub

#End Region

End Class