<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSelectForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSelectForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.lstProperties = New System.Windows.Forms.ListBox()
        Me.lblTitlProp = New System.Windows.Forms.Label()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_Apply = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbOperator = New System.Windows.Forms.ComboBox()
        Me.cmbValue = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.ckbAddSelected = New System.Windows.Forms.CheckBox()
        Me.ckbSubSh = New System.Windows.Forms.CheckBox()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.ckbNewSet = New System.Windows.Forms.CheckBox()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Применить:"
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Items.AddRange(New Object() {"Страница", "Выделенные объекты"})
        Me.cmbArea.Location = New System.Drawing.Point(79, 12)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(193, 21)
        Me.cmbArea.TabIndex = 1
        '
        'lstProperties
        '
        Me.lstProperties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstProperties.FormattingEnabled = True
        Me.lstProperties.Location = New System.Drawing.Point(14, 53)
        Me.lstProperties.Name = "lstProperties"
        Me.lstProperties.Size = New System.Drawing.Size(287, 173)
        Me.lstProperties.TabIndex = 3
        '
        'lblTitlProp
        '
        Me.lblTitlProp.AutoSize = True
        Me.lblTitlProp.Location = New System.Drawing.Point(11, 36)
        Me.lblTitlProp.Name = "lblTitlProp"
        Me.lblTitlProp.Size = New System.Drawing.Size(58, 13)
        Me.lblTitlProp.TabIndex = 5
        Me.lblTitlProp.Text = "Свойства:"
        '
        'btn_OK
        '
        Me.btn_OK.AccessibleDescription = "Отмена"
        Me.btn_OK.AccessibleName = "Cancel"
        Me.btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.AutoSize = True
        Me.btn_OK.Location = New System.Drawing.Point(175, 330)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(61, 23)
        Me.btn_OK.TabIndex = 10
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Apply
        '
        Me.btn_Apply.AccessibleDescription = "OK"
        Me.btn_Apply.AccessibleName = "OK"
        Me.btn_Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Apply.AutoSize = True
        Me.btn_Apply.Location = New System.Drawing.Point(95, 330)
        Me.btn_Apply.Name = "btn_Apply"
        Me.btn_Apply.Size = New System.Drawing.Size(74, 23)
        Me.btn_Apply.TabIndex = 9
        Me.btn_Apply.Text = "Применить"
        Me.btn_Apply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Оператор:"
        '
        'cmbOperator
        '
        Me.cmbOperator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperator.FormattingEnabled = True
        Me.cmbOperator.Location = New System.Drawing.Point(80, 239)
        Me.cmbOperator.Name = "cmbOperator"
        Me.cmbOperator.Size = New System.Drawing.Size(222, 21)
        Me.cmbOperator.TabIndex = 4
        '
        'cmbValue
        '
        Me.cmbValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbValue.FormattingEnabled = True
        Me.cmbValue.Items.AddRange(New Object() {"Выбрать все", "Слои отсутствуют"})
        Me.cmbValue.Location = New System.Drawing.Point(80, 266)
        Me.cmbValue.Name = "cmbValue"
        Me.cmbValue.Size = New System.Drawing.Size(222, 21)
        Me.cmbValue.Sorted = True
        Me.cmbValue.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Значение:"
        '
        'lblLine
        '
        Me.lblLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLine.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.lblLine.Location = New System.Drawing.Point(12, 320)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(289, 1)
        Me.lblLine.TabIndex = 21
        '
        'lblReport
        '
        Me.lblReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReport.Location = New System.Drawing.Point(12, 335)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(75, 13)
        Me.lblReport.TabIndex = 23
        '
        'ckbAddSelected
        '
        Me.ckbAddSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckbAddSelected.Checked = True
        Me.ckbAddSelected.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbAddSelected.Location = New System.Drawing.Point(15, 292)
        Me.ckbAddSelected.Name = "ckbAddSelected"
        Me.ckbAddSelected.Size = New System.Drawing.Size(84, 24)
        Me.ckbAddSelected.TabIndex = 6
        Me.ckbAddSelected.Text = "Выделять"
        Me.ckbAddSelected.UseVisualStyleBackColor = True
        '
        'ckbSubSh
        '
        Me.ckbSubSh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckbSubSh.Enabled = False
        Me.ckbSubSh.Location = New System.Drawing.Point(215, 293)
        Me.ckbSubSh.Name = "ckbSubSh"
        Me.ckbSubSh.Size = New System.Drawing.Size(86, 24)
        Me.ckbSubSh.TabIndex = 8
        Me.ckbSubSh.Text = "Субфигуры"
        Me.ckbSubSh.UseVisualStyleBackColor = True
        '
        'btn_Close
        '
        Me.btn_Close.AccessibleDescription = "Отмена"
        Me.btn_Close.AccessibleName = "Cancel"
        Me.btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Close.AutoSize = True
        Me.btn_Close.Location = New System.Drawing.Point(242, 330)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(61, 23)
        Me.btn_Close.TabIndex = 11
        Me.btn_Close.Text = "Закрыть"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'ckbNewSet
        '
        Me.ckbNewSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckbNewSet.Location = New System.Drawing.Point(105, 292)
        Me.ckbNewSet.Name = "ckbNewSet"
        Me.ckbNewSet.Size = New System.Drawing.Size(104, 24)
        Me.ckbNewSet.TabIndex = 7
        Me.ckbNewSet.Text = "Новый набор"
        Me.ckbNewSet.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Image = CType(resources.GetObject("btn_Save.Image"), System.Drawing.Image)
        Me.btn_Save.Location = New System.Drawing.Point(277, 10)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(25, 25)
        Me.btn_Save.TabIndex = 2
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        '
        'dlgSelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 362)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.ckbNewSet)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.ckbSubSh)
        Me.Controls.Add(Me.ckbAddSelected)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.cmbValue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbOperator)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Apply)
        Me.Controls.Add(Me.lblTitlProp)
        Me.Controls.Add(Me.lstProperties)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(330, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(330, 400)
        Me.Name = "dlgSelectForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Быстрый выбор"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
    Friend WithEvents lstProperties As System.Windows.Forms.ListBox
    Friend WithEvents lblTitlProp As System.Windows.Forms.Label
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Apply As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbOperator As System.Windows.Forms.ComboBox
    Friend WithEvents cmbValue As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents ckbAddSelected As System.Windows.Forms.CheckBox
    Friend WithEvents ckbSubSh As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Close As System.Windows.Forms.Button
    Friend WithEvents ckbNewSet As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
