<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTracker
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
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.lblSecondsLeft = New System.Windows.Forms.Label()
        Me.lblParticipants = New System.Windows.Forms.Label()
        Me.niCountDown = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SuspendLayout()
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(197, 226)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(75, 23)
        Me.cmdStart.TabIndex = 0
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'lblSecondsLeft
        '
        Me.lblSecondsLeft.AutoSize = True
        Me.lblSecondsLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 80.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecondsLeft.Location = New System.Drawing.Point(57, 24)
        Me.lblSecondsLeft.Name = "lblSecondsLeft"
        Me.lblSecondsLeft.Size = New System.Drawing.Size(170, 120)
        Me.lblSecondsLeft.TabIndex = 1
        Me.lblSecondsLeft.Text = "##"
        '
        'lblParticipants
        '
        Me.lblParticipants.AutoSize = True
        Me.lblParticipants.Location = New System.Drawing.Point(114, 172)
        Me.lblParticipants.Name = "lblParticipants"
        Me.lblParticipants.Size = New System.Drawing.Size(56, 13)
        Me.lblParticipants.TabIndex = 2
        Me.lblParticipants.Text = "#######"
        '
        'niCountDown
        '
        Me.niCountDown.Text = "/r/theButton"
        Me.niCountDown.Visible = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.lblParticipants)
        Me.Controls.Add(Me.lblSecondsLeft)
        Me.Controls.Add(Me.cmdStart)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents lblSecondsLeft As System.Windows.Forms.Label
    Friend WithEvents lblParticipants As System.Windows.Forms.Label
    Friend WithEvents niCountDown As System.Windows.Forms.NotifyIcon

End Class
