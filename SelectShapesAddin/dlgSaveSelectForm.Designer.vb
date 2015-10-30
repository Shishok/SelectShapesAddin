<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSaveSelectForm
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
        Me.cmb_ListGroups = New System.Windows.Forms.ComboBox()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.btn_NewGroup = New System.Windows.Forms.Button()
        Me.btn_AddToGroup = New System.Windows.Forms.Button()
        Me.btn_DeleteGroup = New System.Windows.Forms.Button()
        Me.btn_RemoveFromGroup = New System.Windows.Forms.Button()
        Me.btn_DeleteAll = New System.Windows.Forms.Button()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.btn_CloneGroup = New System.Windows.Forms.Button()
        Me.btn_DelMissing = New System.Windows.Forms.Button()
        Me.ckb_DeSelect = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmb_ListGroups
        '
        Me.cmb_ListGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ListGroups.FormattingEnabled = True
        Me.cmb_ListGroups.Location = New System.Drawing.Point(85, 12)
        Me.cmb_ListGroups.Name = "cmb_ListGroups"
        Me.cmb_ListGroups.Size = New System.Drawing.Size(234, 21)
        Me.cmb_ListGroups.TabIndex = 1
        '
        'lbl_Name
        '
        Me.lbl_Name.AutoSize = True
        Me.lbl_Name.Location = New System.Drawing.Point(8, 15)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(71, 13)
        Me.lbl_Name.TabIndex = 3
        Me.lbl_Name.Text = "Имя группы:"
        '
        'btn_Close
        '
        Me.btn_Close.AccessibleDescription = "Отмена"
        Me.btn_Close.AccessibleName = "Cancel"
        Me.btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Close.AutoSize = True
        Me.btn_Close.Location = New System.Drawing.Point(260, 199)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(61, 23)
        Me.btn_Close.TabIndex = 9
        Me.btn_Close.Text = "Закрыть"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'btn_NewGroup
        '
        Me.btn_NewGroup.AccessibleDescription = "Отмена"
        Me.btn_NewGroup.AccessibleName = "Cancel"
        Me.btn_NewGroup.AutoSize = True
        Me.btn_NewGroup.Location = New System.Drawing.Point(11, 53)
        Me.btn_NewGroup.Name = "btn_NewGroup"
        Me.btn_NewGroup.Size = New System.Drawing.Size(96, 23)
        Me.btn_NewGroup.TabIndex = 2
        Me.btn_NewGroup.Text = "Новая группа"
        Me.btn_NewGroup.UseVisualStyleBackColor = True
        '
        'btn_AddToGroup
        '
        Me.btn_AddToGroup.AccessibleDescription = "Отмена"
        Me.btn_AddToGroup.AccessibleName = "Cancel"
        Me.btn_AddToGroup.AutoSize = True
        Me.btn_AddToGroup.Location = New System.Drawing.Point(113, 53)
        Me.btn_AddToGroup.Name = "btn_AddToGroup"
        Me.btn_AddToGroup.Size = New System.Drawing.Size(206, 23)
        Me.btn_AddToGroup.TabIndex = 3
        Me.btn_AddToGroup.Text = "Добавить выделенное в группу"
        Me.btn_AddToGroup.UseVisualStyleBackColor = True
        '
        'btn_DeleteGroup
        '
        Me.btn_DeleteGroup.AccessibleDescription = "Отмена"
        Me.btn_DeleteGroup.AccessibleName = "Cancel"
        Me.btn_DeleteGroup.AutoSize = True
        Me.btn_DeleteGroup.Location = New System.Drawing.Point(11, 82)
        Me.btn_DeleteGroup.Name = "btn_DeleteGroup"
        Me.btn_DeleteGroup.Size = New System.Drawing.Size(96, 23)
        Me.btn_DeleteGroup.TabIndex = 4
        Me.btn_DeleteGroup.Text = "Удалить группу"
        Me.btn_DeleteGroup.UseVisualStyleBackColor = True
        '
        'btn_RemoveFromGroup
        '
        Me.btn_RemoveFromGroup.AccessibleDescription = "Отмена"
        Me.btn_RemoveFromGroup.AccessibleName = "Cancel"
        Me.btn_RemoveFromGroup.AutoSize = True
        Me.btn_RemoveFromGroup.Location = New System.Drawing.Point(113, 82)
        Me.btn_RemoveFromGroup.Name = "btn_RemoveFromGroup"
        Me.btn_RemoveFromGroup.Size = New System.Drawing.Size(206, 23)
        Me.btn_RemoveFromGroup.TabIndex = 5
        Me.btn_RemoveFromGroup.Text = "Удалить выделенное из группы"
        Me.btn_RemoveFromGroup.UseVisualStyleBackColor = True
        '
        'btn_DeleteAll
        '
        Me.btn_DeleteAll.AccessibleDescription = "Отмена"
        Me.btn_DeleteAll.AccessibleName = "Cancel"
        Me.btn_DeleteAll.AutoSize = True
        Me.btn_DeleteAll.Location = New System.Drawing.Point(12, 120)
        Me.btn_DeleteAll.Name = "btn_DeleteAll"
        Me.btn_DeleteAll.Size = New System.Drawing.Size(95, 23)
        Me.btn_DeleteAll.TabIndex = 6
        Me.btn_DeleteAll.Text = "Удалить все"
        Me.btn_DeleteAll.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.AccessibleDescription = "Отмена"
        Me.btn_OK.AccessibleName = "Cancel"
        Me.btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_OK.AutoSize = True
        Me.btn_OK.Location = New System.Drawing.Point(193, 199)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(61, 23)
        Me.btn_OK.TabIndex = 8
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_CloneGroup
        '
        Me.btn_CloneGroup.AccessibleDescription = "Отмена"
        Me.btn_CloneGroup.AccessibleName = "Cancel"
        Me.btn_CloneGroup.AutoSize = True
        Me.btn_CloneGroup.Location = New System.Drawing.Point(193, 120)
        Me.btn_CloneGroup.Name = "btn_CloneGroup"
        Me.btn_CloneGroup.Size = New System.Drawing.Size(126, 23)
        Me.btn_CloneGroup.TabIndex = 7
        Me.btn_CloneGroup.Text = "Клонировать группу"
        Me.btn_CloneGroup.UseVisualStyleBackColor = True
        '
        'btn_DelMissing
        '
        Me.btn_DelMissing.AccessibleDescription = "Отмена"
        Me.btn_DelMissing.AccessibleName = "Cancel"
        Me.btn_DelMissing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_DelMissing.AutoSize = True
        Me.btn_DelMissing.Location = New System.Drawing.Point(12, 199)
        Me.btn_DelMissing.Name = "btn_DelMissing"
        Me.btn_DelMissing.Size = New System.Drawing.Size(166, 23)
        Me.btn_DelMissing.TabIndex = 10
        Me.btn_DelMissing.Text = "Удалить несуществующие ID"
        Me.btn_DelMissing.UseVisualStyleBackColor = True
        '
        'ckb_DeSelect
        '
        Me.ckb_DeSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckb_DeSelect.Checked = True
        Me.ckb_DeSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckb_DeSelect.Location = New System.Drawing.Point(12, 158)
        Me.ckb_DeSelect.Name = "ckb_DeSelect"
        Me.ckb_DeSelect.Size = New System.Drawing.Size(307, 24)
        Me.ckb_DeSelect.TabIndex = 11
        Me.ckb_DeSelect.Text = "Снимать предыдущее выделение"
        Me.ckb_DeSelect.UseVisualStyleBackColor = True
        '
        'dlgSaveSelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 234)
        Me.Controls.Add(Me.ckb_DeSelect)
        Me.Controls.Add(Me.btn_DelMissing)
        Me.Controls.Add(Me.btn_CloneGroup)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_DeleteAll)
        Me.Controls.Add(Me.btn_RemoveFromGroup)
        Me.Controls.Add(Me.btn_DeleteGroup)
        Me.Controls.Add(Me.btn_AddToGroup)
        Me.Controls.Add(Me.btn_NewGroup)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.cmb_ListGroups)
        Me.Controls.Add(Me.lbl_Name)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(345, 272)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(345, 272)
        Me.Name = "dlgSaveSelectForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Группы объектов"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_ListGroups As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Name As System.Windows.Forms.Label
    Friend WithEvents btn_Close As System.Windows.Forms.Button
    Friend WithEvents btn_NewGroup As System.Windows.Forms.Button
    Friend WithEvents btn_AddToGroup As System.Windows.Forms.Button
    Friend WithEvents btn_DeleteGroup As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveFromGroup As System.Windows.Forms.Button
    Friend WithEvents btn_DeleteAll As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_CloneGroup As System.Windows.Forms.Button
    Friend WithEvents btn_DelMissing As System.Windows.Forms.Button
    Friend WithEvents ckb_DeSelect As System.Windows.Forms.CheckBox
End Class
