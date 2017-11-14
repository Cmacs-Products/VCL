''' <summary>
''' Class to enter user input for Section data
''' </summary>
Public Class SectionDataForm

#Region "Fields"

    Private iValidationFailed As Boolean = False
    Private zValidationFailed As Boolean = False
    Private areaValidationFailed As Boolean = False

    Private _iOnLoad As Double
    Private _zOnLoad As Double
    Private _areaOnLoad As Double


#End Region
    
#Region "Private Call Backs"

    ''' <summary>
    ''' Handles the Load event of the SectionDataForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub SectionDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()
        _iOnLoad = InputData.Inertia
        _zOnLoad = InputData.PlasticModulus
        _areaOnLoad = InputData.Area
    End Sub

    ''' <summary>
    ''' Handles the Click event of the OkBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub OkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click
        InputData.Inertia = Me.inertiaTBox.Text
        InputData.PlasticModulus = Me.plasticModulsTBox.Text
        InputData.Area = Me.areaTBox.Text

        'Saves the values
        InputData.FirstTimeSectionDataInput = False

        Me.Close()
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the inertiaTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub inertiaTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inertiaTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = inertiaTBox.Text

            If value <= 0 Or value > 10000 Then
                iValidationFailed = True
            Else
                iValidationFailed = False
            End If
        Catch ex As Exception
            iValidationFailed = True
        End Try

        If iValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Inertia has to be between 1 and 10000", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            inertiaTBox.ForeColor = errTxtColor
            'inertiaTBox.Focus()
        Else
            inertiaTBox.ForeColor = txtColor
        End If

        UpdateValidation()
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the sectionTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub plasticModulsTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plasticModulsTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = plasticModulsTBox.Text

            If value <= 0 Then
                zValidationFailed = True
            Else
                zValidationFailed = False
            End If
        Catch ex As Exception
            zValidationFailed = True
        End Try

        If zValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Plastic Section Moudlus has to greater than zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            plasticModulsTBox.ForeColor = errTxtColor
        Else
            plasticModulsTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the areaTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub areaTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles areaTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = areaTBox.Text

            If value <= 0 Then
                areaValidationFailed = True
            Else
                areaValidationFailed = False
            End If
        Catch ex As Exception
            areaValidationFailed = True
        End Try

        If areaValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Area has to greater than zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            areaTBox.ForeColor = errTxtColor
        Else
            areaTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the ResetBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResetBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultBtn.Click

        InputData.FirstTimeSectionDataInput = True

        PopulateData()

        iValidationFailed = False
        zValidationFailed = False
        areaValidationFailed = False

        inertiaTBox.ForeColor = Color.Black
        plasticModulsTBox.ForeColor = Color.Black
        areaTBox.ForeColor = Color.Black

        UpdateValidation()

    End Sub

    Private Sub ResetLatestBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLatestBtn.Click
        InputData.FirstTimeSectionDataInput = False
        iValidationFailed = False
        zValidationFailed = False
        areaValidationFailed = False

        inertiaTBox.ForeColor = Color.Black
        plasticModulsTBox.ForeColor = Color.Black
        areaTBox.ForeColor = Color.Black

        UpdateValidation()

        Me.inertiaTBox.Text = CStr(Format(_iOnLoad, "0.00"))
        Me.plasticModulsTBox.Text = CStr(Format(_zOnLoad, "0.00"))
        Me.areaTBox.Text = CStr(Format(_areaOnLoad, "0.00"))

    End Sub
#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        If InputData.FirstTimeSectionDataInput Then
            Me.inertiaTBox.Text = "15.00"
            Me.plasticModulsTBox.Text = "5.00"
            Me.areaTBox.Text = "5.00"
        Else
            Me.inertiaTBox.Text = CStr(Format(InputData.Inertia, "0.00"))
            Me.plasticModulsTBox.Text = CStr(Format(InputData.PlasticModulus, "0.00"))
            Me.areaTBox.Text = CStr(Format(InputData.Area, "0.00"))
        End If

    End Sub

    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not iValidationFailed And Not zValidationFailed And Not areaValidationFailed Then
            Me.OkBtn.Enabled = True
        Else
            Me.OkBtn.Enabled = False
        End If

    End Sub

#End Region


End Class