''' <summary>
''' Class to enter user input for material data
''' </summary>
Public Class MaterialDataForm

#Region "Fields"
    Private glassWeightValidationFailed As Boolean = False

    Private _glassWeightOnLoad As Double
    Private _materialIndexOnLoad As Integer
#End Region

#Region "Private Call backs"

    ''' <summary>
    ''' Handles the Load event of the MaterialDataForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub MaterialDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()
        _glassWeightOnLoad = InputData.GlassWeight
        _materialIndexOnLoad = InputData.MaterialIndex
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the glassWeightTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub glassWeightTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles glassWeightTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = glassWeightTBox.Text

            If value <= 0 Then
                glassWeightValidationFailed = True
            Else
                glassWeightValidationFailed = False
            End If
        Catch ex As Exception
            glassWeightValidationFailed = True
        End Try

        If glassWeightValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Glass Weight has to be greater than zero", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            glassWeightTBox.ForeColor = errTxtColor
            'inertiaTBox.Focus()
        Else
            glassWeightTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the OkBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub OkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click

        InputData.GlassWeight = Me.glassWeightTBox.Text
        InputData.MaterialIndex = Me.materialLBox.SelectedIndex
        InputData.MaterialValue = Me.materialLBox.SelectedItem

        'Saves the values
        InputData.FirstTimeMaterialDataInput = False

        Me.Close()

    End Sub

    Private Sub ResetDefaultBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultBtn.Click

        InputData.FirstTimeMaterialDataInput = True
        PopulateData()
        glassWeightValidationFailed = False
        glassWeightTBox.ForeColor = Color.Black

        UpdateValidation()

    End Sub

    Private Sub ResetLatestBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLatestBtn.Click
        InputData.FirstTimeMaterialDataInput = False
        glassWeightValidationFailed = False
        glassWeightTBox.ForeColor = Color.Black
        UpdateValidation()

        Me.glassWeightTBox.Text = CStr(Format(_glassWeightOnLoad, "0.00"))
        Me.materialLBox.SelectedIndex = _materialIndexOnLoad
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        If InputData.FirstTimeMaterialDataInput Then
            Me.glassWeightTBox.Text = "10.00"
            Me.materialLBox.SelectedIndex = 0
        Else
            Me.glassWeightTBox.Text = CStr(Format(InputData.GlassWeight, "0.00"))
            Me.materialLBox.SelectedIndex = InputData.MaterialIndex
        End If

    End Sub

    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not glassWeightValidationFailed Then
            Me.OkBtn.Enabled = True
        Else
            Me.OkBtn.Enabled = False
        End If

    End Sub

#End Region






End Class