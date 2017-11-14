Public Class ProjectInfoForm

#Region "Fields"
    Private nameValidationFailed As Boolean = False
    Private subjectValidationFailed As Boolean = False
#End Region

#Region "Private Call backs"


    ''' <summary>
    ''' Handles the Load event of the ProjectInfoForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ProjectInfoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the PrintBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click
        InputData.ProjectName = projectTBox.Text
        InputData.ProjectSubject = subjectTBox.Text
        InputData.ProjectUser = engineerTBox.Text
        InputData.ProjectDate = pDateTBox.Text

        InputData.FirstTimeProjectInfo = False

        Me.Close()
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the projectTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub projectTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles projectTBox.Leave
        Try
            Dim value As String = projectTBox.Text

            If String.IsNullOrEmpty(value) Then
                nameValidationFailed = True
            Else
                nameValidationFailed = False
            End If
        Catch ex As Exception
            nameValidationFailed = True
        End Try

        If nameValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Project Name cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        UpdateValidation()
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the subjectTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub subjectTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subjectTBox.Leave
        Try
            Dim value As String = subjectTBox.Text

            If String.IsNullOrEmpty(value) Then
                subjectValidationFailed = True
            Else
                subjectValidationFailed = False
            End If
        Catch ex As Exception
            subjectValidationFailed = True
        End Try

        If subjectValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Subject cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        UpdateValidation()
    End Sub

    Private Sub CnclBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CnclBtn.Click
        Me.Close()
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        Me.engineerTBox.ReadOnly = True
        Me.pDateTBox.ReadOnly = True

        If InputData.FirstTimeProjectInfo Then
            Me.subjectTBox.Text = "Blast Analysis of Mullion"
            Me.engineerTBox.Text = System.Environment.UserName
            Me.pDateTBox.Text = Now
            Me.PrintBtn.Enabled = False
        Else
            Me.projectTBox.Text = InputData.ProjectName
            Me.subjectTBox.Text = InputData.ProjectSubject
            Me.engineerTBox.Text = InputData.ProjectUser
            Me.pDateTBox.Text = InputData.ProjectDate
        End If


    End Sub

    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not nameValidationFailed And Not subjectValidationFailed Then
            Me.PrintBtn.Enabled = True
        Else
            Me.PrintBtn.Enabled = False
        End If

    End Sub

#End Region

End Class