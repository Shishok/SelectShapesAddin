<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgShapeSheetForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.cmbSections = New System.Windows.Forms.ComboBox()
        Me.cmbCells = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdbNumber = New System.Windows.Forms.RadioButton()
        Me.rdbString = New System.Windows.Forms.RadioButton()
        Me.rdbFormula = New System.Windows.Forms.RadioButton()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_OK
        '
        Me.btn_OK.AccessibleDescription = "Отмена"
        Me.btn_OK.AccessibleName = "Cancel"
        Me.btn_OK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.Location = New System.Drawing.Point(216, 151)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(88, 23)
        Me.btn_OK.TabIndex = 27
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'cmbSections
        '
        Me.cmbSections.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSections.FormattingEnabled = True
        Me.cmbSections.Items.AddRange(New Object() {"Страница", "Выделенные объекты"})
        Me.cmbSections.Location = New System.Drawing.Point(81, 12)
        Me.cmbSections.Name = "cmbSections"
        Me.cmbSections.Size = New System.Drawing.Size(223, 21)
        Me.cmbSections.TabIndex = 39
        '
        'cmbCells
        '
        Me.cmbCells.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCells.FormattingEnabled = True
        Me.cmbCells.Items.AddRange(New Object() {"Страница", "Выделенные объекты"})
        Me.cmbCells.Location = New System.Drawing.Point(81, 46)
        Me.cmbCells.Name = "cmbCells"
        Me.cmbCells.Size = New System.Drawing.Size(223, 21)
        Me.cmbCells.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Ячейка:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Секция:"
        '
        'txtValue
        '
        Me.txtValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValue.Location = New System.Drawing.Point(81, 110)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(223, 20)
        Me.txtValue.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Значение:"
        '
        'rdbNumber
        '
        Me.rdbNumber.AutoSize = True
        Me.rdbNumber.Location = New System.Drawing.Point(16, 80)
        Me.rdbNumber.Name = "rdbNumber"
        Me.rdbNumber.Size = New System.Drawing.Size(57, 17)
        Me.rdbNumber.TabIndex = 48
        Me.rdbNumber.Text = "Число"
        Me.rdbNumber.UseVisualStyleBackColor = True
        '
        'rdbString
        '
        Me.rdbString.AutoSize = True
        Me.rdbString.Location = New System.Drawing.Point(121, 80)
        Me.rdbString.Name = "rdbString"
        Me.rdbString.Size = New System.Drawing.Size(61, 17)
        Me.rdbString.TabIndex = 49
        Me.rdbString.Text = "Строка"
        Me.rdbString.UseVisualStyleBackColor = True
        '
        'rdbFormula
        '
        Me.rdbFormula.AutoSize = True
        Me.rdbFormula.Location = New System.Drawing.Point(231, 80)
        Me.rdbFormula.Name = "rdbFormula"
        Me.rdbFormula.Size = New System.Drawing.Size(73, 17)
        Me.rdbFormula.TabIndex = 50
        Me.rdbFormula.Text = "Формула"
        Me.rdbFormula.UseVisualStyleBackColor = True
        '
        'lblLine
        '
        Me.lblLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLine.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblLine.Location = New System.Drawing.Point(15, 141)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(289, 1)
        Me.lblLine.TabIndex = 51
        '
        'dlgShapeSheetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 188)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.rdbFormula)
        Me.Controls.Add(Me.rdbString)
        Me.Controls.Add(Me.rdbNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbCells)
        Me.Controls.Add(Me.cmbSections)
        Me.Controls.Add(Me.btn_OK)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(650, 226)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(335, 226)
        Me.Name = "dlgShapeSheetForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Shapesheet"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents cmbSections As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCells As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdbNumber As System.Windows.Forms.RadioButton
    Friend WithEvents rdbString As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFormula As System.Windows.Forms.RadioButton
    Friend WithEvents lblLine As System.Windows.Forms.Label
End Class
