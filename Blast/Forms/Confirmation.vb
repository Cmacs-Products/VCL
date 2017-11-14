Public Class Confirmation

    Private Shared _todo As String = "CANCEL"
    Public ReadOnly Property TODO As String
        Get
            Return _todo
        End Get
    End Property

    Private Sub saveChangesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveChangesBtn.Click
        _todo = "SAVE"
        Me.Close()

    End Sub

    Private Sub ignoreChangesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ignoreChangesBtn.Click
        _todo = "IGNORE"
        Me.Close()
    End Sub

    Private Sub cancelChangesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelChangesBtn.Click
        _todo = "CANCEL"
        Me.Close()
    End Sub

    Private Sub Confirmation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not String.IsNullOrEmpty(InputData.CurrentOpenFIle) Then
            cautionLabel.Text = "Do you want to save the changes to" + InputData.CurrentOpenFIle + " ?"
        End If

    End Sub

End Class