Public Class dlgSelectForm

    Dim vsoApp As Visio.Application = Globals.ThisAddIn.Application
    Dim winObj As Visio.Window
    Dim strTemp() As String
    Dim intSel As Integer
    Dim booSG As Boolean
    Dim visSelObj As Object

    Private Sub dlgSelectForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        winObj = vsoApp.ActiveWindow
        lstProperties.Items.AddRange(Split(My.Resources.ResourceManager.GetString("Все_объекты"), ","))
        CountSel()
        SaveSettings(0)
    End Sub

    Private Sub dlgSelectForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If arrSH(4) = 1 Then
            cmbValue.Text = arrSH(2) : arrSH(4) = 0
            AddOperator(Switch(arrSH(1) = 0, 1, arrSH(1) = 1, 2, arrSH(1) = 2, 2))
        Else
            CountSel()
        End If
    End Sub

    Private Sub lstProperties_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstProperties.SelectedIndexChanged
        cmbValue.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDown
        cmbValue.Items.Clear()
        cmbArea.Text = ""
        cmbValue.Sorted = True
        cmbValue.Text = ""


        'Dim IntID As Integer
        'Dim SelObj As Visio.Selection = winObj.Selection

        'If SelObj.Count <> 0 Then
        '    IntID = SelObj(1).ID
        'Else
        '    SelObj.IterationMode = Visio.VisSelectMode.visSelModeOnlySub + Visio.VisSelectMode.visSelModeSkipSuper '2304
        '    IntID = SelObj(1).ID
        'End If

        Select Case lstProperties.SelectedItem
            Case "Типы объектов"
                AddOperator(0)
                cmbValue.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
                cmbValue.Sorted = False
                cmbValue.Items.AddRange(TypeObject())
            Case "Слой"
                AddOperator(2)
                cmbValue.Sorted = False
                cmbValue.Items.AddRange(LayersName())
                cmbValue.Text = FtxtV()
            Case "Текст", "Имя фигуры"
                AddOperator(2)
                cmbValue.Text = FtxtV()
            Case "ID фигуры", "Ширина", "Высота", "Угол", "Положение X", "Положение Y", "Начало X", "Начало Y", "Конец X", "Конец Y"
                AddOperator(1)
                cmbValue.Text = FtxtV()
            Case "Имя мастера"
                AddOperator(2)
                cmbValue.Items.AddRange(MastersName())
                cmbValue.Text = FtxtV()
            Case "Стиль текста"
                AddOperator(2)
                cmbValue.Items.AddRange(StylesName())
                cmbValue.Text = FtxtV()
            Case "Стиль линии"
                AddOperator(2)
                cmbValue.Items.AddRange(StylesName())
                cmbValue.Text = FtxtV()
            Case "Стиль заливки"
                AddOperator(2)
                cmbValue.Items.AddRange(StylesName())
                cmbValue.Text = FtxtV()
            Case "Шрифт"
                AddOperator(2)
                cmbValue.Items.AddRange(FontsName())
                cmbValue.Text = FtxtV()
                Exit Sub
            Case "Размер шрифта"
                AddOperator(1)
                cmbValue.Sorted = False
                cmbValue.Items.AddRange(Split(My.Resources.ResourceManager.GetString(Replace(lstProperties.SelectedItem, " ", "_", 1)), ","))
                cmbValue.Text = FtxtV()
            Case "Длина", "Периметр", "Площадь", "Угол", "Сглаживание угла", "Тип линии", "Тип заливки", "Толщина линии"
                AddOperator(1) : cmbValue.Text = FtxtV()
            Case "Цвет заливки", "Цвет линии", "Цвет шрифта", "Количество субфигур"
                AddOperator(1) : cmbValue.Text = FtxtV()
            Case "Data123" : AddOperator(2) : cmbValue.Text = FtxtV()
            Case "Shapesheet"
                'AddOperator(3) 
                frmNewFRM1 = New dlgShapeSheetForm
                frmNewFRM1.ShowDialog()
        End Select

        If cmbValue.Items.Count <> 0 AndAlso cmbValue.Text = "" Then cmbValue.SelectedIndex = 0
    End Sub

    Private Sub RunProgramm()
        booSG = winObj.ShowGuides
        If Not winObj.ShowGuides Then winObj.ShowGuides = True

        If ckbNewSet.Checked Then
            winObj.Select(winObj.Page.Shapes.item(1), 256)
            cmbArea.SelectedIndex = 0
            ckbAddSelected.Checked = True
        End If

        If cmbArea.SelectedIndex = 0 AndAlso winObj.Selection.Count < 2 Then
            ckbAddSelected.Checked = True : visSelObj = winObj.Page.Shapes : intSel = 2
        ElseIf cmbArea.SelectedIndex = 0 And winObj.Selection.Count > 1 And ckbAddSelected.Checked Then
            visSelObj = winObj.Page.Shapes : intSel = 2
        ElseIf cmbArea.SelectedIndex = 0 And winObj.Selection.Count > 1 And Not ckbAddSelected.Checked Then
            visSelObj = winObj.Page.Shapes : intSel = 1
        ElseIf cmbArea.SelectedIndex = 1 And winObj.Selection.Count < 2 Then
            ckbAddSelected.Checked = True : cmbArea.SelectedIndex = 1 : Exit Sub
        ElseIf cmbArea.SelectedIndex = 1 And winObj.Selection.Count > 1 And ckbAddSelected.Checked Then
            visSelObj = winObj.Selection : winObj.Select(winObj.Page.Shapes.item(1), 256) : intSel = 2
        ElseIf cmbArea.SelectedIndex = 1 And winObj.Selection.Count > 1 And Not ckbAddSelected.Checked Then
            visSelObj = winObj.Selection : intSel = 1
        End If

        On Error GoTo Msg

        Select Case lstProperties.SelectedItem
            Case "Типы объектов" : SelectTypeObj()
            Case "Слой" : SelectByLayer()
            Case "Имя мастера" : SelectByMasterName()
            Case "Имя фигуры" : SelectShapeByName()
            Case "ID фигуры" : SelectShapeByID()
            Case "Стиль текста" : SelectByStyleText()
            Case "Стиль линии" : SelectByStyleLine()
            Case "Стиль заливки" : SelectByStyleFill()
            Case "Длина" : SelectByLength()
            Case "Периметр" : SelectByPerimetr()
            Case "Площадь" : SelectByArea()
            Case "Текст" : SelectShapeText()
            Case "Ширина" : SelectShapeByCell("Width")
            Case "Высота" : SelectShapeByCell("Height")
            Case "Угол" : SelectShapeByCell("Angle")
            Case "Положение X" : SelectShapeByCell("PinX")
            Case "Положение Y" : SelectShapeByCell("PinY")
            Case "Начало X" : SelectShapeByCell("BeginX")
            Case "Начало Y" : SelectShapeByCell("BeginY")
            Case "Конец X" : SelectShapeByCell("EndX")
            Case "Конец Y" : SelectShapeByCell("EndY")
            Case "Сглаживание угла" : SelectShapeByCell("Rounding")
            Case "Тип линии" : SelectByTypeColor("LinePattern")
            Case "Тип заливки" : SelectByTypeColor("FillPattern")
            Case "Толщина линии" : SelectShapeByCell("LineWeight")
            Case "Цвет заливки" : SelectByTypeColor("FillForegnd")
            Case "Цвет линии" : SelectByTypeColor("LineColor")
            Case "Цвет шрифта" : SelectByTypeColor("Char.Color[1]")
            Case "Размер шрифта" : SelectBySizeFont()
            Case "Шрифт" : SelectByFont()
            Case "Количество субфигур" : SelectByCountSub()
            Case "Data123" : SelectByData()
            Case "Shapesheet" : SelectShapesheet()
        End Select

        winObj.ShowGuides = booSG
        visSelObj = Nothing : Erase strTemp
        Exit Sub

Msg:
        MsgBox("Ошибка!" & vbNewLine & "Возможно оператор не соотвествует заданному типу значения", 48, "Быстрый выбор")
        winObj.Selection = visSelObj
        visSelObj = Nothing : Erase strTemp
    End Sub

#Region "Functions"

    Private Function SelSh(a, b) As Boolean

        Select Case cmbOperator.SelectedItem
            Case "= Равно" : Return a = b
            Case "<> Не равно" : Return a <> b
            Case "> Больше" : Return a > b
            Case "< Меньше" : Return a < b
            Case ">= Больше/равно" : Return a >= b
            Case "<= Меньше/равно" : Return a <= b
            Case "Соответствует шаблону" : Return a Like b
            Case "Не соответствует шаблону" : Return Not a Like b
            Case "Выбрать все" : Return True
        End Select

    End Function

    Private Function FtxtV()
        ' ************************************** Свести все функции сюда!!!!!
        If winObj.Selection.Count = 0 Then
            Return ""
        Else
            With winObj.Selection(1)
                'winObj.Page.Shapes.ItemFromID(intID)
                Select Case lstProperties.SelectedItem
                    Case "Слой"
                        If .CellExists("LayerMember", 0) Then
                            If InStr(1, .Cells("LayerMember").ResultStr(""), ";") = 0 Then
                                Return winObj.Page.Layers(CInt(.Cells("LayerMember").Result("")) + 1).Name
                            Else
                                Return winObj.Page.Layers(Val(Strings.Left(.Cells("LayerMember").ResultStr(""), InStr(1, .Cells("LayerMember").ResultStr(""), ";"))) + 1).Name
                            End If
                        Else
                            Return "Слои отсутствуют"
                        End If
                    Case "Текст" : Return .Characters.Text
                    Case "Стиль текста" : Return .TextStyle
                    Case "Стиль линии" : Return .LineStyle
                    Case "Стиль заливки" : Return .FillStyle
                    Case "Имя мастера" : If Not .Master Is Nothing Then Return .Master.Name
                    Case "Имя фигуры" : Return .Name
                    Case "ID фигуры" : Return .ID
                    Case "Ширина" : Return .Cells("Width").Result(64)
                    Case "Высота" : Return .Cells("Height").Result(64)
                    Case "Угол" : Return .Cells("Angle").Result("deg")
                    Case "Положение X" : Return .Cells("PinX").Result(64)
                    Case "Положение Y" : Return .Cells("PinY").Result(64)
                    Case "Начало X" : Return .Cells("BeginX").Result(64)
                    Case "Начало Y" : Return .Cells("BeginY").Result(64)
                    Case "Конец X" : Return .Cells("EndX").Result(64)
                    Case "Конец Y" : Return .Cells("EndY").Result(64)
                    Case "Количество субфигур" : Return .Shapes.Count
                    Case "Размер шрифта" : Return CSng(.Cells("Char.Size[1]").Result("pt"))
                    Case "Длина" : If .OneD = -1 Then Return vsoApp.ConvertResult(.LengthIU, "in", 64)
                    Case "Периметр" : If .Type <> 2 AndAlso .OneD <> -1 Then Return vsoApp.ConvertResult(.LengthIU, "in", 64)
                    Case "Площадь" : If .Type = 2 Or .Type = 3 Then Return vsoApp.ConvertResult(vsoApp.ConvertResult(.AreaIU, "in", 64), "in", 64)
                    Case "Сглаживание угла" : Return .Cells("Rounding").Result(64)
                    Case "Тип линии" : Return .Cells("LinePattern").Result("")
                    Case "Тип заливки" : Return .Cells("FillPattern").Result("")
                    Case "Толщина линии" : Return .Cells("LineWeight").Result("pt")
                    Case "Цвет заливки" : Return .Cells("FillForegnd").Result("")
                    Case "Цвет линии" : Return .Cells("LineColor").Result("")
                    Case "Цвет шрифта" : Return .Cells("Char.Color[1]").Result("")
                    Case "Шрифт" : Return vsoApp.ActiveDocument.Fonts(.Cells("Char.Font[1]").Result("")).Name
                    Case "Data123" : Return .Data1 & .Data2 & .Data3
                End Select
            End With
        End If

    End Function

    Private Function TypeObject()
        TypeObject = Split(My.Resources.ResourceManager.GetString(Replace(lstProperties.SelectedItem, " ", "_", 1)), ",")
    End Function

    Private Function LayersName()
        ReDim strTemp(winObj.Page.Layers.Count)
        strTemp(0) = "Слои отсутствуют"
        For i = 1 To winObj.Page.Layers.Count
            strTemp(i) = winObj.Page.Layers(i).Name
        Next
        LayersName = strTemp
    End Function

    Private Function StylesName()
        Erase strTemp
        vsoApp.ActiveDocument.Styles.GetNames(strTemp)
        StylesName = strTemp
    End Function

    Private Function MastersName()
        Erase strTemp
        vsoApp.ActiveDocument.Masters.GetNames(strTemp)
        MastersName = strTemp
    End Function

    Private Function FontsName()
        ReDim strTemp(vsoApp.ActiveDocument.Fonts.Count - 1)

        For i = 1 To vsoApp.ActiveDocument.Fonts.Count
            strTemp(i - 1) = vsoApp.ActiveDocument.Fonts(i).Name
        Next
        FontsName = strTemp
    End Function

    Private Function MsgNotNum()
        MsgBox("Ошибка!" & vbNewLine & "Значение - " & cmbValue.Text & " не является числом", 48, "Быстрый выбор")
    End Function

#End Region

#Region "Func. Procedure"

    Private Sub MainSel(id)

        Select Case ckbSubSh.Checked
            Case False : winObj.Select(id, intSel)
            Case True : winObj.Select(winObj.Page.Shapes.ItemFromID(id), 3)
        End Select

    End Sub

    Private Sub SelectTypeObj()
        Dim sh As Visio.Shape

        For Each sh In visSelObj
            Select Case cmbValue.Text
                Case "Простая фигура"
                    If sh.Type <> 2 Then winObj.Select(sh, intSel)
                Case "Одномерная фигура"
                    If sh.OneD = -1 Then winObj.Select(sh, intSel)
                Case "Коннектор"
                    If sh.OneD = -1 AndAlso sh.CellsU("ObjType").Result("") = 2 Then winObj.Select(sh, intSel)
                Case "Сгруппированная фигура"
                    If sh.Type = 2 Then winObj.Select(sh, intSel)
                Case "Надпись"
                    If sh.Type <> 2 AndAlso sh.Characters.Text <> "" AndAlso sh.Cells("LinePattern").Result("") = 0 AndAlso sh.Cells("FillPattern").Result("") = 0 Then winObj.Select(sh, intSel)
                Case "Выноска"
                    If sh.CellExistsU("User.msvStructureType", 0) AndAlso sh.Cells("User.msvStructureType").ResultStr("") = "Callout" Then winObj.Select(sh, intSel)
                Case "Размер"
                    If sh.CellExistsU("Prop.Extensions", 0) AndAlso sh.Cells("Prop.Extensions.Label").ResultStr("") = "Выносные линии" Then winObj.Select(sh, intSel)
                Case "Контейнер"
                    If sh.CellExistsU("User.msvStructureType", 0) AndAlso sh.Cells("User.msvStructureType").ResultStr("") = "Container" Then winObj.Select(sh, intSel)
                Case "Направляющая"
                    If sh.Type = 5 Then winObj.Select(sh, intSel)
                Case "Растровый рисунок"
                    If sh.ForeignType = 32 Then winObj.Select(sh, intSel)
                Case "Метафайл"
                    If sh.ForeignType = 16 Then winObj.Select(sh, intSel)
                Case "Объект OLE"
                    If sh.ForeignType = -32256 Then winObj.Select(sh, intSel)
                Case "Рукописный объект"
                    If sh.ForeignType = 64 Then winObj.Select(sh, intSel)
            End Select
        Next

    End Sub

    Private Sub SelectByData()
        Dim sh As Visio.Shape

        For Each sh In visSelObj
            If SelSh(sh.Data1, cmbValue.Text) Or SelSh(sh.Data2, cmbValue.Text) Or SelSh(sh.Data3, cmbValue.Text) Then winObj.Select(sh, intSel)
        Next
    End Sub

    Private Sub SelectByLayer()
        Dim sh As Visio.Shape, LayObj As Visio.Layer, i As Integer = 0

        For Each sh In visSelObj
            For i = 1 To sh.LayerCount
                LayObj = sh.Layer(i)
                If Not LayObj Is Nothing Then
                    If SelSh(LayObj.Name, cmbValue.Text) Then
                        winObj.Select(sh, intSel)
                        Exit For
                    End If
                End If
            Next
            If sh.LayerCount = 0 AndAlso SelSh("Слои отсутствуют", cmbValue.Text) Then winObj.Select(sh, intSel)
        Next
    End Sub

    Private Sub SelectByStyleText()
        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).TextStyle, cmbValue.Text) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectByStyleLine()
        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).LineStyle, cmbValue.Text) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectByStyleFill()
        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).FillStyle, cmbValue.Text) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectShapeText()
        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).Characters.Text, cmbValue.Text) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectByMasterName()
        Dim sh As Visio.Shape
        Dim Mastr As Visio.Master

        For Each sh In visSelObj
            Mastr = sh.Master
            If Not Mastr Is Nothing Then
                If SelSh(Mastr.Name, cmbValue.Text) Then winObj.Select(sh, intSel)
            End If
        Next
    End Sub

    Private Sub SelectShapeByID()
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If
        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).ID, Val(cmbValue.Text)) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectShapeByName()
        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).Name, cmbValue.Text) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectByTypeColor(strCellName)
        Dim sh As Visio.Shape

        For Each sh In visSelObj
            If SelSh(CInt(sh.Cells(strCellName).Result("")), cmbValue.Text) Then winObj.Select(sh, intSel)
        Next

    End Sub

    Private Sub SelectShapeByCell(strCellName)
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If
        Dim sh As Visio.Shape
        Dim strDim = 64

        Select Case strCellName
            Case "Angle" : strDim = 81
            Case "LineWeight" : strDim = 50
        End Select

        Dim strVal = Replace(cmbValue.Text, ".", ",", 1)
        Dim d As Byte = InStr(1, strVal, ",")

        If d <> 0 Then d = Len(strVal) - d

        strVal = Math.Round(CDbl(cmbValue.Text), d, MidpointRounding.AwayFromZero)

        For Each sh In visSelObj
            If sh.CellExistsU(strCellName, 0) AndAlso SelSh(Math.Round(sh.Cells(strCellName).Result(strDim), d, MidpointRounding.AwayFromZero), strVal) Then winObj.Select(sh, intSel)
        Next

    End Sub

    Private Sub SelectShapesheet()
        Dim sh As Visio.Shape

        Dim C = arrSH(0)
        Dim R As Byte = arrSH(1)
        Dim V, V1, strVal
        Dim d As Byte

        Select Case R
            Case 0
                strVal = Replace(cmbValue.Text, ".", ",", 1)
                d = InStr(1, strVal, ",")
                If d <> 0 Then d = Len(strVal) - d
                strVal = Math.Round(CDbl(cmbValue.Text), d, MidpointRounding.AwayFromZero)
            Case 1, 2
                strVal = cmbValue.Text
        End Select

        For Each sh In visSelObj
            With sh
                If .CellExistsU(C, 0) Then
                    V = Switch(R = 0, Math.Round(.Cells(C).Result(arrSH(3)), d, MidpointRounding.AwayFromZero), R = 1, .Cells(C).ResultStr(arrSH(3)), R = 2, .Cells(C).FormulaU)
                    V1 = Switch(R = 0, strVal, R = 1, strVal, R = 2, strVal)
                    If SelSh(V, V1) Then winObj.Select(sh, intSel)
                End If
            End With
        Next

    End Sub

    Private Sub SelectBySizeFont()
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If

        Dim intSize As Single = CSng(cmbValue.Text)

        If intSize < 1 Then Exit Sub
        For i = 1 To visSelObj.Count
            'If SelSh(CSng(visSelObj(i).Cells("Char.Size[1]").Result("pt")), CSng(intSize)) Then MainSel(visSelObj(i).Id)
            If SelSh(CSng(visSelObj(i).Cells("Char.Size[1]").Result("pt")), CSng(intSize)) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectByFont()
        Dim intFont As Integer = vsoApp.ActiveDocument.Fonts(cmbValue.Text).ID

        For i = 1 To visSelObj.Count
            If SelSh(visSelObj(i).Cells("Char.Font[1]").Result(""), intFont) Then winObj.Select(visSelObj(i), intSel)
        Next
    End Sub

    Private Sub SelectByCountSub()
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If
        Dim sh As Visio.Shape
        Dim intVal As Integer = Int(cmbValue.Text)

        If intVal < 1 Then Exit Sub
        For Each sh In visSelObj
            If sh.Type = 2 AndAlso SelSh(sh.Shapes.Count, intVal) Then winObj.Select(sh, intSel)
        Next
    End Sub

    Private Sub SelectByLength()
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If
        Dim sh As Visio.Shape
        Dim strVal = Replace(cmbValue.Text, ".", ",", 1)
        Dim d As Byte = InStr(1, strVal, ",")

        If d <> 0 Then d = Len(strVal) - d
        strVal = Math.Round(CDbl(strVal), d, MidpointRounding.AwayFromZero)

        For Each sh In visSelObj
            With sh
                If .OneD = -1 Then
                    If SelSh(Math.Round(vsoApp.ConvertResult(.LengthIU, "in", 64), d, MidpointRounding.AwayFromZero), strVal) Then winObj.Select(sh, intSel)
                End If
            End With
        Next

    End Sub

    Private Sub SelectByPerimetr()
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If
        Dim sh As Visio.Shape
        Dim strVal = Replace(cmbValue.Text, ".", ",", 1)
        Dim d As Byte = InStr(1, strVal, ",")

        If d <> 0 Then d = Len(strVal) - d
        strVal = Math.Round(CDbl(strVal), d, MidpointRounding.AwayFromZero)

        For Each sh In visSelObj
            With sh
                If .Type <> 2 AndAlso .OneD <> -1 Then
                    If SelSh(Math.Round(vsoApp.ConvertResult(.LengthIU, "in", 64), d, MidpointRounding.AwayFromZero), strVal) Then winObj.Select(sh, intSel)
                End If
            End With
        Next

    End Sub

    Private Sub SelectByArea()
        If Not IsNumeric(cmbValue.Text) Then
            MsgNotNum()
            Exit Sub
        End If
        Dim sh As Visio.Shape
        Dim strVal = Replace(cmbValue.Text, ".", ",", 1)
        Dim d As Byte = InStr(1, strVal, ",")

        If d <> 0 Then d = Len(strVal) - d
        strVal = Math.Round(CDbl(strVal), d, MidpointRounding.AwayFromZero)

        For Each sh In visSelObj
            With sh
                If .Type = 2 Or .Type = 3 Then
                    If SelSh(Math.Round(vsoApp.ConvertResult(.AreaIU, "in", 64), d, MidpointRounding.AwayFromZero), strVal) Then winObj.Select(sh, intSel)
                End If
            End With
        Next

    End Sub

    Private Sub CountSel()
        If winObj IsNot Nothing Then
            cmbArea.SelectedIndex = Switch(winObj.Selection.Count < 2, 0, winObj.Selection.Count > 1, 1)
            lblReport.Text = winObj.Page.Shapes.Count & " / " & winObj.Selection.Count
        End If
    End Sub

    Private Sub AddOperator(arg)
        cmbOperator.Items.Clear()

        cmbOperator.Items.AddRange({"= Равно", "<> Не равно"})

        Select Case arg
            Case 1 : cmbOperator.Items.AddRange({"> Больше", "< Меньше", ">= Больше/равно", "<= Меньше/равно"})
            Case 2 : cmbOperator.Items.AddRange({"Соответствует шаблону", "Не соответствует шаблону"})
                'Case 3 : cmbOperator.Items.AddRange({"> Больше", "< Меньше", ">= Больше/равно", "<= Меньше/равно", "Соответствует шаблону", "Не соответствует шаблону"})
        End Select

        cmbOperator.SelectedIndex = 0
    End Sub

    Private Sub SaveSettings(arg)
        Const An As String = "SelectShapesAddin", Sc As String = "Settings"
        Select Case arg
            Case 0
                If GetSetting(AppName:=An, Section:=Sc, Key:="Top") <> "" Then
                    Me.Top = GetSetting(AppName:=An, Section:=Sc, Key:="Top")
                    Me.Left = GetSetting(AppName:=An, Section:=Sc, Key:="Left")
                    Me.Height = GetSetting(AppName:=An, Section:=Sc, Key:="Height")

                    If Int(GetSetting(AppName:=An, Section:=Sc, Key:="Properties")) <> 32 Then
                        lstProperties.SelectedIndex = Int(GetSetting(AppName:=An, Section:=Sc, Key:="Properties"))
                        cmbOperator.SelectedIndex = Int(GetSetting(AppName:=An, Section:=Sc, Key:="Operator"))
                        If winObj.Selection.Count = 0 Then cmbValue.Text = GetSetting(AppName:=An, Section:=Sc, Key:="Value")
                    End If
                End If
            Case 1
                SaveSetting(AppName:=An, Section:=Sc, Key:="Top", Setting:=Me.Top)
                SaveSetting(AppName:=An, Section:=Sc, Key:="Left", Setting:=Me.Left)
                SaveSetting(AppName:=An, Section:=Sc, Key:="Height", Setting:=Me.Height)
                SaveSetting(AppName:=An, Section:=Sc, Key:="Properties", Setting:=lstProperties.SelectedIndex)
                SaveSetting(AppName:=An, Section:=Sc, Key:="Operator", Setting:=cmbOperator.SelectedIndex)
                SaveSetting(AppName:=An, Section:=Sc, Key:="Value", Setting:=cmbValue.Text)
        End Select
    End Sub

#End Region

    Private Sub btn_Apply_Click(sender As Object, e As EventArgs) Handles btn_Apply.Click
        lblReport.Text = "......" : Me.Refresh()
        RunProgramm()
        CountSel()
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        RunProgramm()
        SaveSettings(1)
        Me.Close()
    End Sub

    Private Sub dlgSelectForm_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmNewFRM = Nothing
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        SaveSettings(1)
        Me.Close()
    End Sub

End Class