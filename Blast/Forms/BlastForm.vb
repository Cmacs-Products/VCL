Imports System.math
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop

Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Runtime.InteropServices

Public Class BlastForm

#Region "Print Field Members"

    Private PrintPageSettings As New PageSettings

    Private memoryImage As Bitmap

    Private Property psw As Integer

    Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal _
    hdcDest As IntPtr, ByVal nXDest As Integer, ByVal _
    nYDest As Integer, ByVal nWidth As Integer, ByVal _
    nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc _
    As Integer, ByVal nYSrc As Integer, ByVal dwRop As  _
    System.Int32) As Boolean
    Private Const SRCCOPY As Integer = &HCC0020

#End Region

#Region "Private Call Backs"

    ''' <summary>
    ''' Handles the Load event of the BlastForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub BlastForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Initilaize all input forms with default inputs
        InputData.initialize()

        'Default Start
        TriangularPulseToolStripMenuItem.Checked = True
        InputData.CurrentLoadType = InputData.LoadType.Triangular

        DisplacementToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Displacement

        'For Future use: Disable
        LoadFromWINGARDToolStripMenuItem.Enabled = False
        'Strand7ToolStripMenuItem.Enabled = False
        'COMSOLToolStripMenuItem.Enabled = False

        RefreshEntireForm()

        'Will be used to see if there were any changes
        InputData.SaveDataOnFileLoad()

    End Sub

    ''' <summary>
    ''' Handles the Paint event of the plot control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub plot_Paint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plotPanel.Paint
        Plotter.GenerateGraphs(1, 1)
    End Sub

    ''' <summary>
    ''' Handles the Paint event of the plotStressPanel control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub plotStressPanel_Paint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plotStressPanel.Paint
        Plotter.GenerateGraphs(6, 2)
    End Sub

    ''' <summary>
    ''' Handles the Paint event of the histPanel control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub histPanel_Paint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles histPanel.Paint
        Plotter.GenerateHistGraph()
    End Sub

    Private Sub plotStressPanel_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles plotStressPanel.MouseClick
        'stressGraphValue.Visible = True

        Dim LocalMousePosition As Point
        LocalMousePosition = plotStressPanel.PointToClient(Cursor.Position)

        Dim xLoc As Double = 0.0
        Dim yLoc As Double = 0.0

        Debug.WriteLine(plotStressPanel.Location)
        Debug.WriteLine(plotStressPanel.Size.Width)
        Debug.WriteLine(plotStressPanel.Size.Height)
        Debug.WriteLine(LocalMousePosition.X)
        Debug.WriteLine(LocalMousePosition.Y)
        Debug.WriteLine(InputData.ResponseDuration)
        Debug.WriteLine(InputData.ResponseStepSize)

        If LocalMousePosition.Y = plotStressPanel.Size.Height / 2 Then
            yLoc = 0
        ElseIf LocalMousePosition.Y < plotStressPanel.Size.Height / 2 Then
            yLoc = (plotStressPanel.Size.Height / 2 - LocalMousePosition.Y) / (plotStressPanel.Size.Height / 2 / (InputData.Amplitude + 4))
        ElseIf LocalMousePosition.Y > plotStressPanel.Size.Height / 2 Then
            yLoc = (plotStressPanel.Size.Height / 2 - LocalMousePosition.Y) / (plotStressPanel.Size.Height / 2 / (InputData.Amplitude + 4))
        End If

        stressGraphValue.Text = "X = " & ((LocalMousePosition.X * plotStressPanel.Size.Width / 1000) - 20).ToString & ", Y= " & CStr(Format(yLoc, "0.00"))

    End Sub
        

    Private Sub plotStressPanel_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plotStressPanel.MouseLeave
        stressGraphValue.Visible = False
    End Sub


#Region "File Menu Callbacks"

    ''' <summary>
    ''' Handles the Click event of the ProjectInfoToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ProjectInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectInfoToolStripMenuItem.Click
        Dim piForm As New ProjectInfoForm()
        piForm.ShowDialog()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the PrintToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Use Capture Screen If you want to Capture the frame of the Form as well
        ' memoryImage = GetFormWithFrame()

        'To Capture the form without the frame use GetFormWithoutFrame
        memoryImage = GetFormWithoutFrame()
        memoryImage.Save("C:\Temp\BlastTest.bmp")

        PrintDialog1.Document = PrintDocument1
        PrintDialog1.PrintToFile = False

        PrintDialog1.PrinterSettings.DefaultPageSettings.Landscape = True
        Dim result As DialogResult = PrintDialog1.ShowDialog

        If (result = DialogResult.OK) Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the PrintSetupToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub PrintSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TODO 
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ExitToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try

            If InputData.HasChanges() Then
                Dim confirmDlg As New Confirmation()
                confirmDlg.ShowDialog()
                If confirmDlg.TODO.ToUpper.Equals("SAVE") Then
                    If String.IsNullOrEmpty(InputData.CurrentOpenFIle) Then
                        If InputData.SaveNewFile() <> 1 Then
                            Me.Close()
                            End
                        End If
                    Else
                        InputData.SaveExistingFile(InputData.CurrentOpenFIle)
                        Me.Close()
                        End
                    End If
                ElseIf confirmDlg.TODO.ToUpper.Equals("IGNORE") Then
                    Me.Close()
                    End
                ElseIf confirmDlg.TODO.ToUpper.Equals("CANCEL") Then
                    'DO Nothing
                End If
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Error while exiting : " + ex.ToString)
        Finally
            InputData.DeleteTempImages()
        End Try
    End Sub

#End Region

#Region "Model Strip Callbacks"

    ''' <summary>
    ''' Handles the Click event of the InputToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub UserInputToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserInputToolStripMenuItem.Click
        Dim sectionForm As New SectionDataForm
        sectionForm.ShowDialog()
        RefreshEntireForm()
    End Sub


    ''' <summary>
    ''' Handles the Click event of the LoadFromACADToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub LoadFromEPROPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadFromEPROPToolStripMenuItem.Click

        'No Errors
        If InputData.LoadEpropFile() = 0 Then
            RefreshEntireForm()
            Me.ePropPictureBox.Image = InputData.EpropotiesImage
        End If

    End Sub

    ''' <summary>
    ''' Handles the Click event of the SpanToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub SpanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpanToolStripMenuItem.Click
        Dim sdForm As New SpanDataForm
        sdForm.ShowDialog()
        RefreshEntireForm()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the MaterialToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub MaterialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialToolStripMenuItem.Click
        Dim materialForm As New MaterialDataForm
        materialForm.ShowDialog()
        RefreshEntireForm()
    End Sub

#End Region

#Region "Load Menu Callbacks"

    ''' <summary>
    ''' Handles the Click event of the TriangularPulseToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub TriangularPulseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriangularPulseToolStripMenuItem.Click
        ClearLoadMenu()
        TriangularPulseToolStripMenuItem.Checked = True
        InputData.CurrentLoadType = InputData.LoadType.Triangular

        Dim triForm As New TriangularPulseForm
        triForm.ShowDialog()

        RefreshEntireForm()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the ToolStripMenuItem4 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SinusoidalToolStripMenuItem.Click
        ClearLoadMenu()
        SinusoidalToolStripMenuItem.Checked = True
        InputData.CurrentLoadType = InputData.LoadType.Sinusoidal

        Dim sinForm As New SinusoidalPulseForm
        sinForm.ShowDialog()

        RefreshEntireForm()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the GeneralToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub GeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralToolStripMenuItem.Click
        ClearLoadMenu()
        GeneralToolStripMenuItem.Checked = True
        InputData.CurrentLoadType = InputData.LoadType.General

        GeneralDataForm.Visible = True
    End Sub

#End Region

#Region "Plot Menu Callbacks"

    ''' <summary>
    ''' Handles the Click event of the DisplacementToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub DisplacementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplacementToolStripMenuItem.Click
        ClearPlotMenu()
        DisplacementToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Displacement
        Plotter.GenerateGraphs(1, 1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the VelocityToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub VelocityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VelocityToolStripMenuItem.Click
        ClearPlotMenu()
        VelocityToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Velocity
        Plotter.GenerateGraphs(2, 1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the AccelerationToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub AccelerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccelerationToolStripMenuItem.Click
        ClearPlotMenu()
        AccelerationToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Acceleration
        Plotter.GenerateGraphs(3, 1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the RestoringToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub RestoringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoringToolStripMenuItem.Click
        ClearPlotMenu()
        RestoringToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Restoring
        Plotter.GenerateGraphs(4, 1)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the AppliedLoadToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub AppliedLoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppliedLoadToolStripMenuItem.Click
        ClearPlotMenu()
        AppliedLoadToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.AppliedLoad
        Plotter.GenerateGraphs(5, 1)
    End Sub

#End Region

#Region "Solution Menu Callbacks"

    ''' <summary>
    ''' Handles the Click event of the CalculateToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub CalculateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefereshToolStripMenuItem.Click
        ClearPlotMenu()
        DisplacementToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Displacement

        RefreshEntireForm()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the ResposeDataToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResposeDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResposeDataToolStripMenuItem.Click
        Dim responseData As New ResponseDataForm
        responseData.ShowDialog()
        RefreshEntireForm()
    End Sub


#End Region

#Region "Help Menu Callbacks"

    ''' <summary>
    ''' Handles the Click event of the TheoryToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub TheoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TheoryToolStripMenuItem.Click

        'TODO - TJ
    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutInfoForm.Visible = True
    End Sub

#End Region

    ''' <summary>
    ''' Handles the Click event of the ePropPictureBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ePropPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ePropPictureBox.Click
        'TODO Referesh the info as from the image
    End Sub


#End Region

#Region "Private Methods"

    Private Sub RefreshEntireForm()

        'populates the Blast form labels
        UpdateMullionDataLabels()

        'Initializes,Calculates and Updates the results
        StartSDOF()

        'Me.plotPanel.Invalidate()
        If InputData.CurrentPlotType = InputData.PlotType.Displacement Then
            Plotter.GenerateGraphs(1, 1)
        ElseIf InputData.CurrentPlotType = InputData.PlotType.Velocity Then
            Plotter.GenerateGraphs(2, 1)
        ElseIf InputData.CurrentPlotType = InputData.PlotType.Acceleration Then
            Plotter.GenerateGraphs(3, 1)
        ElseIf InputData.CurrentPlotType = InputData.PlotType.Restoring Then
            Plotter.GenerateGraphs(4, 1)
        ElseIf InputData.CurrentPlotType = InputData.PlotType.AppliedLoad Then
            Plotter.GenerateGraphs(5, 1)
        End If

        Me.plotStressPanel.Invalidate()
        Me.histPanel.Invalidate()

    End Sub

    ''' <summary>
    ''' Updates the mullion data labels.
    ''' </summary>
    Private Sub UpdateMullionDataLabels()

        Me.inertiaValueLabel.Text = CStr(Format(InputData.Inertia, "0.00"))
        Me.plasticModValueLabel.Text = CStr(Format(InputData.PlasticModulus, "0.00"))
        Me.areaValueLabel.Text = CStr(Format(InputData.Area, "0.00"))
        Me.spanValueLabel.Text = CStr(Format(InputData.Span, "0.00"))
        Me.spacingValueLabel.Text = CStr(Format(InputData.Spacing, "0.00"))

        If InputData.SpanType = 1 Then
            Me.spanTypeValueLabel.Text = "Double Span"
        Else
            Me.spanTypeValueLabel.Text = "Single Span"
        End If

        Me.glassWeightValueLabel.Text = CStr(Format(InputData.GlassWeight, "0.00"))
        Me.materialValueLabel.Text = InputData.MaterialValue

        ClearLoadMenu()
        ClearPlotMenu()

        If InputData.CurrentLoadType = InputData.LoadType.Triangular Then
            TriangularPulseToolStripMenuItem.Checked = True
        ElseIf InputData.CurrentLoadType = InputData.LoadType.Sinusoidal Then
            SinusoidalToolStripMenuItem.Checked = True
        ElseIf InputData.CurrentLoadType = InputData.LoadType.General Then
            GeneralToolStripMenuItem.Checked = True
        End If

        If InputData.CurrentPlotType = InputData.PlotType.Displacement Then
            DisplacementToolStripMenuItem.Checked = True
        ElseIf InputData.CurrentPlotType = InputData.PlotType.Velocity Then
            VelocityToolStripMenuItem.Checked = True
        ElseIf InputData.CurrentPlotType = InputData.PlotType.Acceleration Then
            AccelerationToolStripMenuItem.Checked = True
        ElseIf InputData.CurrentPlotType = InputData.PlotType.AppliedLoad Then
            AppliedLoadToolStripMenuItem.Checked = True
        ElseIf InputData.CurrentPlotType = InputData.PlotType.Restoring Then
            RestoringToolStripMenuItem.Checked = True
        End If

        If Not String.IsNullOrEmpty(InputData.EPropertiesLocation) Then
            If File.Exists(InputData.EPropertiesLocation) Then
                Me.ePropPictureBox.Image = Image.FromFile(InputData.EPropertiesLocation)
            End If
        End If


    End Sub

    ''' <summary>
    ''' Clears the plot menu.
    ''' </summary>
    Private Sub ClearPlotMenu()
        DisplacementToolStripMenuItem.Checked = False
        VelocityToolStripMenuItem.Checked = False
        AccelerationToolStripMenuItem.Checked = False
        RestoringToolStripMenuItem.Checked = False
        AppliedLoadToolStripMenuItem.Checked = False
    End Sub

    ''' <summary>
    ''' Clears the load menu.
    ''' </summary>
    Private Sub ClearLoadMenu()
        TriangularPulseToolStripMenuItem.Checked = False
        SinusoidalToolStripMenuItem.Checked = False
        GeneralToolStripMenuItem.Checked = False
    End Sub

    ''' <summary>
    ''' Gets the form without frame.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetFormWithoutFrame() As Bitmap
        ' Get this form's Graphics object.
        Dim me_gr As Graphics = Me.CreateGraphics

        ' Make a Bitmap to hold the image.
        Dim bm As New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height, me_gr)
        Dim bm_gr As Graphics = Graphics.FromImage(bm)
        Dim bm_hdc As IntPtr = bm_gr.GetHdc

        ' Get the form's hDC. We must do this after 
        ' creating the new Bitmap, which uses me_gr.
        Dim me_hdc As IntPtr = me_gr.GetHdc

        ' BitBlt the form's image onto the Bitmap.
        BitBlt(bm_hdc, 0, 0, Me.ClientSize.Width, _
            Me.ClientSize.Height, _
            me_hdc, 0, 0, SRCCOPY)
        me_gr.ReleaseHdc(me_hdc)
        bm_gr.ReleaseHdc(bm_hdc)

        ' Return the result.
        Return bm
    End Function

    ''' <summary>
    ''' Gets the form with frame.
    ''' </summary>
    ''' <returns></returns>
    Private Function GetFormWithFrame() As Bitmap
        Dim myImage As Bitmap

        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = Me.Size
        myImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(myImage)
        memoryGraphics.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, s)
        Return myImage
    End Function

    ''' <summary>
    ''' Handles the PrintPage event of the printDocument1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs" /> instance containing the event data.</param>
    Private Sub printDocument1_PrintPage(ByVal sender As System.Object, _
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles _
       PrintDocument1.PrintPage

        Dim x As Integer = e.MarginBounds.X
        Dim y As Integer = e.MarginBounds.Y
        Dim Width As Integer = memoryImage.Width
        Dim Height As Integer = memoryImage.Height


        If ((Width / e.MarginBounds.Width) > (Height / e.MarginBounds.Height)) Then
            Width = e.MarginBounds.Width
            Height = memoryImage.Height * e.MarginBounds.Width / memoryImage.Width()
        Else
            Height = e.MarginBounds.Height
            Width = memoryImage.Width * e.MarginBounds.Height / memoryImage.Height()
        End If

        Dim destRect As System.Drawing.Rectangle = New System.Drawing.Rectangle(x, y, Width, Height)

        e.Graphics.DrawImage(memoryImage, destRect, 0, 0, memoryImage.Width, memoryImage.Height, System.Drawing.GraphicsUnit.Pixel)


    End Sub

#End Region

#Region "Changes "

    Private Sub CreateNewBlast()
        'Initilaize all input forms with default inputs
        InputData.initialize()

        'Default Start
        ClearLoadMenu()
        TriangularPulseToolStripMenuItem.Checked = True
        InputData.CurrentLoadType = InputData.LoadType.Triangular

        ClearPlotMenu()
        DisplacementToolStripMenuItem.Checked = True
        InputData.CurrentPlotType = InputData.PlotType.Displacement

        'For Future use: Disable
        LoadFromWINGARDToolStripMenuItem.Enabled = False

        'Strand7ToolStripMenuItem.Enabled = False
        'COMSOLToolStripMenuItem.Enabled = False

        RefreshEntireForm()

        Me.ePropPictureBox.Image = Nothing
        InputData.EPropertiesLocation = String.Empty

        'Will be used to see if there were any changes
        InputData.SaveDataOnFileLoad()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the NewToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

        If InputData.HasChanges() Then
            Dim confirmDlg As New Confirmation()
            confirmDlg.ShowDialog()
            If confirmDlg.TODO.ToUpper.Equals("SAVE") Then
                If String.IsNullOrEmpty(InputData.CurrentOpenFIle) Then
                    If InputData.SaveNewFile() <> 1 Then
                        CreateNewBlast()
                    End If
                Else
                    InputData.SaveExistingFile(InputData.CurrentOpenFIle)
                    CreateNewBlast()
                End If

            ElseIf confirmDlg.TODO.ToUpper.Equals("IGNORE") Then
                CreateNewBlast()
            ElseIf confirmDlg.TODO.ToUpper.Equals("CANCEL") Then
                'DO Nothing
            End If
        Else
            CreateNewBlast()
        End If
    End Sub

    ''' <summary>
    ''' Handles the Click event of the SaveToolStripMenuItem control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If String.IsNullOrEmpty(InputData.CurrentOpenFIle) Then
            InputData.SaveNewFile()
        Else
            InputData.SaveExistingFile(InputData.CurrentOpenFIle)
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        If InputData.HasChanges() Then
            Dim confirmDlg As New Confirmation()
            confirmDlg.ShowDialog()
            If confirmDlg.TODO.ToUpper.Equals("SAVE") Then
                If String.IsNullOrEmpty(InputData.CurrentOpenFIle) Then
                    If InputData.SaveNewFile() <> 1 Then
                        If InputData.LoadFile() = 0 Then
                            RefreshEntireForm()
                        End If
                    End If
                Else
                    InputData.SaveExistingFile(InputData.CurrentOpenFIle)
                    If InputData.LoadFile() = 0 Then
                        RefreshEntireForm()
                    End If
                End If

            ElseIf confirmDlg.TODO.ToUpper.Equals("IGNORE") Then
                If InputData.LoadFile() = 0 Then
                    RefreshEntireForm()
                End If
            ElseIf confirmDlg.TODO.ToUpper.Equals("CANCEL") Then
                'DO Nothing
            End If
        Else
            If InputData.LoadFile() = 0 Then
                RefreshEntireForm()
            End If
        End If



    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        InputData.SaveNewFile()
    End Sub

#End Region



    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click


        If Not File.Exists(InputData.GetTempFolder + "Report.dotx") Then

            Dim oFileStream As System.IO.FileStream
            oFileStream = New System.IO.FileStream(InputData.GetTempFolder + "Report.dotx", System.IO.FileMode.Create)

            Dim data() As Byte = My.Resources.Report.ToArray

            oFileStream.Write(data, 0, data.Length)
            oFileStream.Close()

        End If

        InputData.SaveSpanTypeImageForReport()

        Plotter.GenerateGraphsForReport(6, 2)
        InputData.saveLoadImage()

        Plotter.GenerateHistGraphForReport()
        InputData.SaveHistImage()


        Dim value As InputData.PlotType = InputData.CurrentPlotType

        InputData.CurrentPlotType = InputData.PlotType.Displacement
        Plotter.GenerateGraphsForReport(1, 1)
        InputData.SavePlotImage("Displacement")

        InputData.CurrentPlotType = InputData.PlotType.Velocity
        Plotter.GenerateGraphsForReport(2, 1)
        InputData.SavePlotImage("Velocity")

        InputData.CurrentPlotType = InputData.PlotType.Acceleration
        Plotter.GenerateGraphsForReport(3, 1)
        InputData.SavePlotImage("Acceleration")

        InputData.CurrentPlotType = InputData.PlotType.Restoring
        Plotter.GenerateGraphsForReport(4, 1)
        InputData.SavePlotImage("Restoring")

        InputData.CurrentPlotType = InputData.PlotType.AppliedLoad
        Plotter.GenerateGraphsForReport(5, 1)
        InputData.SavePlotImage("AppliedLoad")


        InputData.CurrentPlotType = value
        RefreshEntireForm()





        Dim oWord As Word.Application
        Dim oDoc As Word.Document

        Try

            oWord = CreateObject("Word.Application")
            oWord.Visible = True

            oDoc = oWord.Documents.Add(InputData.GetTempFolder() + "Report.dotx ")
            Dim PIctureLocation As String = InputData.GetTempFolder()

            'Header values 
            oDoc.Bookmarks("projectName_value").Range.Text = InputData.ProjectName
            oDoc.Bookmarks("projectSubject_value").Range.Text = InputData.ProjectSubject
            oDoc.Bookmarks("projectDate_value").Range.Text = InputData.ProjectDate
            oDoc.Bookmarks("projectEngineer_value").Range.Text = InputData.ProjectUser

            'Section Property 

            oDoc.Bookmarks("area_value").Range.Text = CStr(Format(InputData.Area, "0.00"))
            oDoc.Bookmarks("i_value").Range.Text = CStr(Format(InputData.Inertia, "0.00"))
            oDoc.Bookmarks("z_value").Range.Text = CStr(Format(InputData.PlasticModulus, "0.00"))
            If Not String.IsNullOrEmpty(InputData.EPropertiesLocation) Then
                If File.Exists(InputData.EPropertiesLocation) Then
                    InputData.SaveEpropImageForReport()
                    oDoc.Bookmarks("eprop_image").Range.InlineShapes.AddPicture(PIctureLocation + "Eprop.bmp")
                End If
            End If


            'Beam Data
            oDoc.Bookmarks("span_value").Range.Text = CStr(Format(InputData.Span, "0.00"))
            oDoc.Bookmarks("spacing_value").Range.Text = CStr(Format(InputData.Spacing, "0.00"))
            If InputData.SpanType = 1 Then
                oDoc.Bookmarks("spanType_value").Range.Text = "Double"
                oDoc.Bookmarks("spanType_image").Range.InlineShapes.AddPicture(PIctureLocation + "double_span.bmp")
                oDoc.Bookmarks("alpha_value").Range.Text = "1/160"
                oDoc.Bookmarks("beta_value").Range.Text = "12"
            Else
                oDoc.Bookmarks("spanType_value").Range.Text = "Single"
                oDoc.Bookmarks("spanType_image").Range.InlineShapes.AddPicture(PIctureLocation + "single_span.bmp")
                oDoc.Bookmarks("alpha_value").Range.Text = "5/384"
                oDoc.Bookmarks("beta_value").Range.Text = "8"
            End If

            'Material Data
            oDoc.Bookmarks("material_value").Range.Text = InputData.MaterialValue
            oDoc.Bookmarks("density_value").Range.Text = CStr(Format(OutputData.Density, "0.00"))
            oDoc.Bookmarks("glassWeight_value").Range.Text = CStr(Format(InputData.GlassWeight, "0.00"))
            oDoc.Bookmarks("e_value").Range.Text = CStr(Format(OutputData.ElasticModulus, "0"))
            oDoc.Bookmarks("fy_value").Range.Text = CStr(Format(OutputData.YieldStrength, "0.00"))
            oDoc.Bookmarks("mt_value").Range.Text = "TODO" ' (Format(OutputData.Mass, "0.00"))
            oDoc.Bookmarks("dif_value").Range.Text = CStr(Format(OutputData.DIF, "0.00"))
            oDoc.Bookmarks("sif_value").Range.Text = CStr(Format(OutputData.SIF, "0.00"))

            'SDOF Properties
            oDoc.Bookmarks("klme_value").Range.Text = CStr(Format(OutputData.KLMe, "0.00"))
            oDoc.Bookmarks("klmp_value").Range.Text = CStr(Format(OutputData.KLMp, "0.00"))
            oDoc.Bookmarks("me_value").Range.Text = CStr(Format(OutputData.EquivalentMass, "0.00E00"))
            oDoc.Bookmarks("ke_value").Range.Text = CStr(Format(OutputData.EquivalentStiffness, "0.00"))
            oDoc.Bookmarks("t_value").Range.Text = CStr(Format(OutputData.SystemPeriod, "0.00"))

            'Results
            oDoc.Bookmarks("mp_value").Range.Text = CStr(Format(OutputData.PlasticMoment, "0.00"))
            oDoc.Bookmarks("ru_value").Range.Text = CStr(Format(OutputData.UltimateResistance, "0.00"))
            oDoc.Bookmarks("ye_value").Range.Text = CStr(Format(OutputData.YieldDisplacement, "0.00"))
            oDoc.Bookmarks("lamdaMax_value").Range.Text = CStr(Format(OutputData.LamdaMax, "0.00"))
            oDoc.Bookmarks("lamdaMin_value").Range.Text = CStr(Format(OutputData.LamdaMin, "0.00"))
            oDoc.Bookmarks("u_value").Range.Text = CStr(Format(OutputData.DuctilityFactor, "0.00"))
            oDoc.Bookmarks("thetaMax_value").Range.Text = CStr(Format(OutputData.SupportRotation, "0.00"))

            oDoc.Bookmarks("hist_image").Range.InlineShapes.AddPicture(PIctureLocation + "Hist.bmp")

            'Graphs
            oDoc.Bookmarks("displacement_image").Range.InlineShapes.AddPicture(PIctureLocation + "Displacement.bmp")
            oDoc.Bookmarks("velocity_image").Range.InlineShapes.AddPicture(PIctureLocation + "Velocity.bmp")
            oDoc.Bookmarks("restoring_image").Range.InlineShapes.AddPicture(PIctureLocation + "Restoring.bmp")
            oDoc.Bookmarks("appliedLoad_image").Range.InlineShapes.AddPicture(PIctureLocation + "AppliedLoad.bmp")
            oDoc.Bookmarks("reactions_image").Range.InlineShapes.AddPicture(PIctureLocation + "Reactions.bmp")


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            InputData.DeleteTempImages()
        End Try
    End Sub


End Class
