''' <summary>
''' Class to edit response data 
''' </summary>
Public Class ResponseDataForm

#Region "Fields"
    Private durationValidationFailed As Boolean = False
    Private stepSizeValidationFailed As Boolean = False

    Private _durationOnLoad As Double
    Private _stepSizeOnLoad As Double

#End Region

#Region "Private Call backs"

    ''' <summary>
    ''' Handles the Load event of the ResponseDataForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResponseDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()
        _durationOnLoad = InputData.ResponseDuration
        _stepSizeOnLoad = InputData.ResponseStepSize

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the responseDurationTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub responseDurationTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles responseDurationTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = responseDurationTBox.Text
            If value <= 0 Then
                durationValidationFailed = True
            Else
                durationValidationFailed = False
            End If
        Catch ex As Exception
            durationValidationFailed = True
        End Try

        If durationValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Response Duration has to be greater than zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            responseDurationTBox.ForeColor = errTxtColor
        Else
            responseDurationTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the responseStepSizeTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub responseStepSizeTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles responseStepSizeTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = responseStepSizeTBox.Text
            If value <= 0 Then
                stepSizeValidationFailed = True
            Else
                stepSizeValidationFailed = False
            End If
        Catch ex As Exception
            stepSizeValidationFailed = True
        End Try

        If stepSizeValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Response Step Size has to be greater than zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            responseStepSizeTBox.ForeColor = errTxtColor
        Else
            responseStepSizeTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the OkBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub OkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click

        InputData.ResponseDuration = responseDurationTBox.Text
        InputData.ResponseStepSize = responseStepSizeTBox.Text
        
        InputData.FirstTimeResponseData = False
        Me.Close()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ResetBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultBtn.Click

        InputData.FirstTimeResponseData = True

        PopulateData()

        durationValidationFailed = False
        stepSizeValidationFailed = False
        responseDurationTBox.ForeColor = Color.Black
        responseStepSizeTBox.ForeColor = Color.Black

        UpdateValidation()
    End Sub

    Private Sub ResetLatestBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLatestBtn.Click

        InputData.FirstTimeResponseData = False
        durationValidationFailed = False
        stepSizeValidationFailed = False
        responseDurationTBox.ForeColor = Color.Black
        responseStepSizeTBox.ForeColor = Color.Black

        UpdateValidation()

        Me.responseDurationTBox.Text = CStr(Format(_durationOnLoad, "0.00"))
        Me.responseStepSizeTBox.Text = CStr(Format(_stepSizeOnLoad, "0.00"))

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        If InputData.FirstTimeResponseData Then
            Me.responseDurationTBox.Text = "0.25"
            Me.responseStepSizeTBox.Text = "0.10"
        Else
            Me.responseDurationTBox.Text = CStr(Format(InputData.ResponseDuration, "0.00"))
            Me.responseStepSizeTBox.Text = CStr(Format(InputData.ResponseStepSize, "0.00"))
        End If

    End Sub

    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not durationValidationFailed And Not stepSizeValidationFailed Then
            Me.OkBtn.Enabled = True
        Else
            Me.OkBtn.Enabled = False
        End If

    End Sub

#End Region



End Class