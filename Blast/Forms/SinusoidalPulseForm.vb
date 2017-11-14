Public Class SinusoidalPulseForm

#Region "Fields"
    Private amplitudeValidationFailed As Boolean = False
    Private frequencyValidationFailed As Boolean = False

    Private _ampOnLoad As Double
    Private _freqOnLoad As Double
#End Region

#Region "Private Call Backs"

    ''' <summary>
    ''' Handles the Load event of the SinusoidalPulseForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub SinusoidalPulseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()
        _ampOnLoad = InputData.Amplitude
        _freqOnLoad = InputData.Frequency
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the sinAmpTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub sinAmpTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sinAmpTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.sinAmpTBox.Text.Trim())
            If value <= 0 Then
                amplitudeValidationFailed = True
            Else
                amplitudeValidationFailed = False
            End If
        Catch ex As Exception
            amplitudeValidationFailed = True
        End Try

        If amplitudeValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Amplitude has be a natural number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sinAmpTBox.ForeColor = errTxtColor
        Else
            sinAmpTBox.ForeColor = txtColor
        End If

        UpdateValidation()
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the sinFreqTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub sinFreqTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sinFreqTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.sinFreqTBox.Text.Trim())
            If value <= 0 Then
                frequencyValidationFailed = True
            Else
                frequencyValidationFailed = False
            End If

        Catch ex As Exception
            frequencyValidationFailed = True
        End Try

        If frequencyValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Frequency has be a natural number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sinFreqTBox.ForeColor = errTxtColor
        Else
            sinFreqTBox.ForeColor = txtColor
        End If

        UpdateValidation()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the OkBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub OkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click

        InputData.Amplitude = Me.sinAmpTBox.Text
        InputData.Frequency = Me.sinFreqTBox.Text

        'Saves the values
        InputData.FirstTimeSinusoidalInput = False

        Me.Close()
    End Sub

    Private Sub ResetDefaultBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultBtn.Click
        InputData.FirstTimeSinusoidalInput = True
        PopulateData()
        amplitudeValidationFailed = False
        frequencyValidationFailed = False
        sinAmpTBox.ForeColor = Color.Black
        sinFreqTBox.ForeColor = Color.Black
        UpdateValidation()
    End Sub

    Private Sub ResetLatestBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLatestBtn.Click
        InputData.FirstTimeSinusoidalInput = False
        amplitudeValidationFailed = False
        frequencyValidationFailed = False
        sinAmpTBox.ForeColor = Color.Black
        sinFreqTBox.ForeColor = Color.Black
        UpdateValidation()

        Me.sinAmpTBox.Text = CStr(Format(_ampOnLoad, "0.00"))
        Me.sinFreqTBox.Text = CStr(Format(_freqOnLoad, "0.00"))

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        If InputData.FirstTimeSinusoidalInput Then
            Me.sinAmpTBox.Text = "4.00"
            Me.sinFreqTBox.Text = "5.00"
        Else
            Me.sinAmpTBox.Text = CStr(Format(InputData.Amplitude, "0.00"))
            Me.sinFreqTBox.Text = CStr(Format(InputData.Frequency, "0.00"))
        End If

    End Sub

    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not amplitudeValidationFailed And Not frequencyValidationFailed Then
            Me.OkBtn.Enabled = True
        Else
            Me.OkBtn.Enabled = False
        End If

    End Sub

#End Region




End Class