Imports System.Windows.Forms

Public Class dlgShapeSheetForm

    Dim vsoApp As Visio.Application = Globals.ThisAddIn.Application
    Dim winObj As Visio.Window

    Private Sub dlgShapeSheetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        winObj = vsoApp.ActiveWindow

        cmbSections.Items.Clear()
        Dim Vr As String = Replace(vsoApp.Version, ".", ",", 1)
        Vr = Strings.Left(Vr, InStr(vsoApp.Version, ",") - 1)

        cmbSections.Items.AddRange(Split(My.Resources.ResourceManager.GetString("ShapeSheet" & Vr), ","))
        cmbSections.SelectedIndex = 0
        rdbNumber.Checked = True

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        arrSH(0) = cmbCells.Text
        arrSH(1) = Switch(rdbNumber.Checked = True, 0, rdbString.Checked = True, 1, rdbFormula.Checked = True, 2)
        arrSH(2) = txtValue.Text
        arrSH(4) = 1
        Me.Close()
    End Sub

    Private Sub cmbSections_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbSections.SelectedIndexChanged

        Dim strInd As String = Replace(cmbSections.SelectedItem, "1", "", 1)
        strInd = Replace(strInd, "3", "", 1) : strInd = Replace(strInd, "-", "_", 1)
        cmbCells.Items.Clear()
        cmbCells.Items.AddRange(Split(My.Resources.ResourceManager.GetString(Replace(strInd, " ", "_", 1)), ","))
        If cmbCells.Items.Count > 0 Then cmbCells.SelectedIndex = 0

    End Sub

    Private Sub cmbCells_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCells.SelectedIndexChanged
        txtValue.Text = FtxtValue()
    End Sub

    Private Function FtxtValue()

        If winObj.Selection.Count <> 0 AndAlso winObj.Selection(1).CellExistsU(cmbCells.Text, 0) Then
            With winObj.Selection(1).Cells(cmbCells.Text)
                Dim cmbVal As Integer = Switch(rdbNumber.Checked = True, 0, rdbString.Checked = True, 1, rdbFormula.Checked = True, 2)
                Dim Un As Integer = .Units
                arrSH(3) = Un
                Return Switch(cmbVal = 0, .Result(Un), cmbVal = 1, .ResultStr(Un), cmbVal = 2, .FormulaU)
            End With
        Else
            Return ""
        End If

    End Function

    Private Sub rdbNumber_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNumber.CheckedChanged
        txtValue.Text = FtxtValue()
    End Sub

    Private Sub rdbString_CheckedChanged(sender As Object, e As EventArgs) Handles rdbString.CheckedChanged
        txtValue.Text = FtxtValue()
    End Sub

    Private Sub rdbFormula_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFormula.CheckedChanged
        txtValue.Text = FtxtValue()
    End Sub

    Private Sub dlgShapeSheetForm_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmNewFRM1 = Nothing
    End Sub

End Class