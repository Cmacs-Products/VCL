Imports System.Math

''' <summary>
''' Class for generating all the graphs
''' </summary>
Public Class Plotter

#Region "Public Methods"

    ''' <summary>
    ''' Generates the graphs.
    ''' </summary>
    ''' <param name="iunit">The iunit.</param>
    ''' <param name="plot_type">The plot_type.</param>
    Public Shared Sub GenerateGraphs(ByVal iunit As Integer, ByVal plot_type As Integer)
        Dim g As System.Drawing.Graphics

        Dim PenColor As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim cc() As Color = {Color.FloralWhite, Color.Red, Color.Black, Color.Blue, Color.Yellow, Color.Cyan, Color.Orange, Color.Gray, Color.Gold}

        Dim av As New Bitmap(901, 251)

        Dim i, imax, imin As Integer
        Dim xmin, xmax, ymin, ymax As Double
        Dim title As String
        '
        ' set the plot typeDisplacementToolStripMenuItem
        '
        Dim psw, psh As Integer
        If plot_type = 1 Then
            g = BlastForm.plotPanel.CreateGraphics
            psh = BlastForm.plotPanel.Size.Height
            psw = BlastForm.plotPanel.Size.Width

        Else
            g = BlastForm.plotStressPanel.CreateGraphics
            psh = BlastForm.plotStressPanel.Size.Height
            psw = BlastForm.plotStressPanel.Size.Width

        End If
        ' clear the picture box
        '
        Dim BrushColor As New SolidBrush(Color.White)
        g.FillRectangle(BrushColor, 0, 0, psw, psh)
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.SmoothingMode = SmoothingMode.HighQuality
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.CompositingQuality = CompositingQuality.HighQuality

        title = " "
        If (iunit = 1) Then
            title = "    Displacement (in)   "
        ElseIf (iunit = 2) Then
            title = "    Velocity (in-sec)  "
        ElseIf (iunit = 3) Then
            title = "Acceleration (in-sec2)  "
        ElseIf (iunit = 4) Then
            title = " Resistance (kisp)  "
        ElseIf (iunit = 5) Then
            title = " Applied Pulse (kips)     "
        ElseIf (iunit = 6) Then
            title = "    Reactions (kips)     "
        End If


        xmin = start_time
        xmax = end_time
        ymin = 1000000
        ymax = -1000000
        imax = 0
        imin = 0

        Dim Max2 As Double = 0.0

        For i = 0 To num_step
            If (Response(i, iunit) > ymax) Then
                ymax = Response(i, iunit)
                imax = i
            End If

            If (Response(i, iunit) < ymin) Then
                ymin = Response(i, iunit)
                imin = i
            End If

        Next




        Dim xoff As Integer = 20

        ymax = Abs(ymax)
        If (Math.Round(ymax, 0) > ymax) Then
            ymax = Math.Round(ymax, 0)
        Else
            ymax = Math.Round(ymax, 0) + 1
        End If

        If (Abs(ymin) > ymax) Then ymax = Abs(ymin)
        ymin = -ymax


        Dim scale_x, scale_y As Double
        scale_x = (psw - xoff) / (xmax - xmin)
        scale_y = -psh * 0.95 / (ymax - ymin)
        '
        ' draw the axis
        '
        Dim x_from, y_from, x_to, y_to As Integer
        Dim tt As Double


        g.FillRectangle(Brushes.LightGray, 0, 0, xoff, psh)
        g.TranslateTransform(5, psh / 2 + 55)
        g.RotateTransform(-90)
        g.DrawString(title, New Font("Arial", 8), Brushes.RoyalBlue, 0, 0)
        g.ResetTransform()
        g.DrawString(CStr(Format(ymax, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, 0, 0)
        g.DrawString(CStr(Format(ymin, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, 0, psh - 10)
        '


        For i = 1 To 7
            y_from = i * psh / 8
            y_to = y_from
            g.DrawLine(Pens.LightGray, xoff, y_from, psw, y_to)

        Next

        x_from = scale_x * xmin + xoff
        x_to = scale_x * xmax + xoff
        y_from = psh / 2
        y_to = psh / 2
        PenColor.Color = cc(0)
        g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)



        tt = start_time
        y_from = 0
        y_to = psh
        g.DrawLine(Pens.Black, xoff, y_from, xoff, y_to)

        For i = 1 To 9

            x_from = i * psw / 10 + xoff
            x_to = x_from
            g.DrawLine(Pens.LightGray, x_from, y_from, x_to, y_to)
            tt = (xmax - xmin) * i / 10
            g.DrawString(CStr(Format(tt, " 0.000")), New Font("Arial", 6), Brushes.RoyalBlue, x_to - (CStr(Format(tt, " 0.000")).Length) * 3, psh / 2)

        Next

        BlastForm.plotPanel.Visible = True


        PenColor.Color = cc(plot_type)

        For i = 0 To num_step - 1
            x_from = scale_x * time(i) + xoff
            x_to = scale_x * time(i + 1) + xoff
            y_from = scale_y * Response(i, iunit) + psh / 2
            y_to = scale_y * Response(i + 1, iunit) + psh / 2
            g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)
        Next

        PenColor.Color = cc(2)

        x_from = scale_x * time(imax) + xoff
        x_to = x_from
        y_from = scale_y * 0 + psh / 2
        y_to = scale_y * Response(imax, iunit) + psh / 2
        g.DrawLine(Pens.Red, x_from, y_from, x_to, y_to)
        g.FillPie(Brushes.Red, x_to - 4, y_to - 4, 8, 8, 0, 360)
        g.DrawString(CStr(Format(Response(imax, iunit), " 0.00")), New Font("Arial", 6), Brushes.RoyalBlue, x_to + 8, y_to)

        x_from = scale_x * time(imin) + xoff
        x_to = x_from
        y_from = scale_y * 0 + psh / 2
        y_to = scale_y * Response(imin, iunit) + psh / 2
        g.DrawLine(Pens.Blue, x_from, y_from, x_to, y_to)
        g.FillPie(Brushes.Blue, x_to - 4, y_to - 4, 8, 8, 0, 360)
        g.DrawString(CStr(Format(Response(imin, iunit), " 0.00")), New Font("Arial", 6), Brushes.DarkBlue, x_to + 8, y_to - 2)

        If (iunit = 6) Then
            PenColor.Color = cc(1)

            For i = 0 To num_step - 1
                x_from = scale_x * time(i) + xoff
                x_to = scale_x * time(i + 1) + xoff
                y_from = scale_y * Response(i, iunit + 1) + psh / 2
                y_to = scale_y * Response(i + 1, iunit + 1) + psh / 2
                g.DrawLine(PenColor, x_from, y_from, x_to, y_to)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Generates the hist graph.
    ''' </summary>
    Public Shared Sub GenerateHistGraph()
        Dim g As System.Drawing.Graphics
        g = BlastForm.histPanel.CreateGraphics
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.SmoothingMode = SmoothingMode.HighQuality
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.CompositingQuality = CompositingQuality.HighQuality

        Dim PenColor As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim cc() As Color = {Color.Red, Color.Gold, Color.FloralWhite, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Cyan, Color.Gray}


        Dim i As Integer
        Dim xmin, xmax, ymin, ymax As Double
        Dim title As String
        '
        ' clear the picture box
        '
        Dim psw, psh As Integer
        psh = BlastForm.histPanel.Size.Height
        psw = BlastForm.histPanel.Size.Width
        Dim BrushColor As New SolidBrush(Color.White)
        g.FillRectangle(BrushColor, 0, 0, psw, psh)

        title = " "

        xmin = 1000000
        xmax = -1000000
        ymin = 1000000
        ymax = -10000000
        '
        For i = 0 To num_step

            If (Response(i, 1) > xmax) Then xmax = Response(i, 1)
            If (Response(i, 1) < xmin) Then xmin = Response(i, 1)

            If (Response(i, 4) > ymax) Then ymax = Response(i, 4)
            If (Response(i, 4) < ymin) Then ymin = Response(i, 4)


        Next

        xmax = Abs(xmax)
        If (Abs(xmin) > xmax) Then xmax = Abs(xmin)
        xmin = -xmax

        ymax = Abs(ymax)
        If (Abs(ymin) > ymax) Then ymax = Abs(ymin)
        ymin = -ymax
        If Ru > ymax Then
            ymax = Ru
            ymin = -Ru
        End If
        '
        ' write the status
        '
        Dim xoff As Integer = 20
        Dim scale_x, scale_y As Double
        scale_x = (psw - xoff) * 0.85 / (xmax - xmin)
        scale_y = -psh * 0.85 / (ymax - ymin)


        g.FillRectangle(Brushes.LightGray, 0, 0, xoff, psh)
        g.TranslateTransform(5, psh / 2 + 45)
        g.RotateTransform(-90)
        g.DrawString("Resistanse (kisp)", New Font("Arial", 8), Brushes.RoyalBlue, 0, 0)
        g.ResetTransform()
        '
        g.DrawString(CStr(Format(ymax, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, 0, 0)
        g.DrawString(CStr(Format(ymin, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, 0, psh - 10)


        g.DrawString(CStr(Format(xmin, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, xoff, (psh) / 2 + 1)
        g.DrawString(CStr(Format(xmax, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, psw - xoff, (psh) / 2 + 1)

        '

        Dim x_from, y_from, x_to, y_to As Integer

        x_from = psw / 2 + xoff
        y_from = 0
        x_to = x_from
        y_to = psh
        g.DrawLine(Pens.DimGray, x_from, y_from, x_to, y_to)

        x_from = xoff
        y_from = psh / 2
        x_to = psw + xoff
        y_to = y_from
        g.DrawLine(Pens.DimGray, x_from, y_from, x_to, y_to)

        PenColor.Color = cc(0)

        x_from = xoff
        x_to = psw + xoff

        y_from = scale_y * Ru + psh / 2
        y_to = y_from
        g.DrawLine(PenColor, x_from, y_from, x_to, y_to)

        y_from = -scale_y * Ru + psh / 2
        y_to = y_from
        g.DrawLine(PenColor, x_from, y_from, x_to, y_to)



        For i = 0 To num_step - 1
            x_from = scale_x * Response(i, 1) + psw / 2 + xoff
            x_to = scale_x * Response(i + 1, 1) + psw / 2 + xoff

            y_from = scale_y * Response(i, 4) + psh / 2
            y_to = scale_y * Response(i + 1, 4) + psh / 2
            g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)
        Next


    End Sub

    ''' <summary>
    ''' Generates the pulse graph.
    ''' </summary>
    ''' <param name="destination">The destination.</param>
    Public Shared Sub GeneratePulseGraph(ByVal destination As Panel)

        Dim xmin, xmax, ymin, ymax As Double
        Dim title As String 'set the plot type
        Dim psw, psh As Integer
        Dim x_from, y_from, x_to, y_to As Integer ' draw the axis

        Dim g As System.Drawing.Graphics
        Dim size As Size = destination.Size

        g = destination.CreateGraphics
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.SmoothingMode = SmoothingMode.HighQuality
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.CompositingQuality = CompositingQuality.HighQuality

        psh = size.Height
        psw = size.Width

        g.FillRectangle(Brushes.LightGray, 0, 0, psw, psh) ' clear the picture box

        title = "Pressure (psi)"

        xmin = 0
        xmax = InputData.Duration + InputData.NegativeDuration
        ymax = InputData.Pulse
        ymin = -ymax


        Dim xoff As Integer = 20
        Dim scale_x, scale_y As Double
        scale_x = (psw - xoff) / (xmax - xmin)
        scale_y = -psh * 0.95 / (ymax - ymin)

        g.FillRectangle(Brushes.LightGray, 0, 0, xoff, psh)
        g.TranslateTransform(5, psh / 2 + 55)
        g.RotateTransform(-90)
        g.DrawString(title, New Font("Arial", 8), Brushes.RoyalBlue, 0, 0)
        g.ResetTransform()
        g.DrawString(CStr(Format(ymax, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, 0, 0)
        g.DrawString(CStr(Format(ymin, " 0.0")), New Font("Arial", 6), Brushes.RoyalBlue, 0, psh - 10)
        '


        x_from = scale_x * xmin + xoff
        x_to = scale_x * xmax + xoff
        y_from = +psh / 2
        y_to = psh / 2
        g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)


        y_from = 0
        y_to = psh
        g.DrawLine(Pens.Black, xoff, y_from, xoff, y_to)
        '
        ' postive pulse
        '
        Dim ppt(2) As Point
        '

        ppt(0).X = scale_x * 0 + xoff
        ppt(0).Y = scale_y * 0 + psh / 2
        ppt(1).X = scale_x * InputData.Rise + xoff
        ppt(1).Y = scale_y * ymax + psh / 2
        ppt(2).X = scale_x * +InputData.Duration + xoff 'Veguru
        ppt(2).Y = scale_y * 0 + psh / 2
        g.FillPolygon(Brushes.Crimson, ppt)
        g.DrawPolygon(Pens.Black, ppt)
        g.DrawString(InputData.Pulse, New Font("Arial", 6), Brushes.RoyalBlue, ppt(1).X + 4, ppt(1).Y - 4)
        g.DrawString(InputData.Rise, New Font("Arial", 6), Brushes.RoyalBlue, ppt(1).X - 2, psh / 2 + 4)

        g.DrawString(InputData.Duration, New Font("Arial", 6), Brushes.RoyalBlue, ppt(2).X - 4, psh / 2 + 4)

        y_from = psh / 2
        g.DrawLine(Pens.Gray, ppt(1).X, y_from, ppt(1).X, ppt(1).Y)
        '
        ' negative pressure
        '
        Dim tf, tr, td, fac, tt As Double

        fac = 1.0 - InputData.NegativePulse / InputData.Pulse
        tr = InputData.Rise
        td = InputData.Duration
        tt = td + InputData.NegativeDuration
        tf = tr + (td - tr) * fac

        ppt(0).X = scale_x * +InputData.Duration + xoff
        ppt(0).Y = scale_y * 0 + psh / 2
        ppt(1).X = scale_x * tf + xoff
        ppt(1).Y = scale_y * InputData.NegativePulse + psh / 2
        ppt(2).X = scale_x * xmax + xoff
        ppt(2).Y = scale_y * 0 + psh / 2
        g.FillPolygon(Brushes.DarkSalmon, ppt)
        g.DrawPolygon(Pens.Black, ppt)
        g.DrawString(TriangularPulseForm.netagivePulseTBox.Text, New Font("Arial", 6), Brushes.RoyalBlue, ppt(1).X + 4, ppt(1).Y + 4)
        g.DrawString(Format(tf, "0"), New Font("Arial", 6), Brushes.RoyalBlue, ppt(1).X - 2, psh / 2 - 12)

        g.DrawString(Format(tt, "0"), New Font("Arial", 6), Brushes.RoyalBlue, ppt(2).X - 15, psh / 2 - 12)
        y_from = psh / 2
        g.DrawLine(Pens.Gray, ppt(1).X, y_from, ppt(1).X, ppt(1).Y)
        '
        destination.Update()
    End Sub

    ''' <summary>
    ''' Generates the graphs for report.
    ''' </summary>
    ''' <param name="iunit">The iunit.</param>
    ''' <param name="plot_type">The plot_type.</param>
    Public Shared Sub GenerateGraphsForReport(ByVal iunit As Integer, ByVal plot_type As Integer)
        Dim g As System.Drawing.Graphics

        Dim PenColor As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim cc() As Color = {Color.FloralWhite, Color.Red, Color.Black, Color.Blue, Color.Yellow, Color.Cyan, Color.Orange, Color.Gray, Color.Gold}



        Dim i, imax, imin As Integer
        Dim xmin, xmax, ymin, ymax As Double
        Dim title As String
        '
        ' set the plot typeDisplacementToolStripMenuItem
        '
        Dim psw, psh As Integer
        If plot_type = 1 Then
            g = BlastForm.plotPanel.CreateGraphics
            psh = BlastForm.plotPanel.Size.Height
            psw = BlastForm.plotPanel.Size.Width

        Else
            g = BlastForm.plotStressPanel.CreateGraphics
            psh = BlastForm.plotStressPanel.Size.Height
            psw = BlastForm.plotStressPanel.Size.Width

        End If

        ' clear the picture box
        '

        g.SmoothingMode = SmoothingMode.HighQuality
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.CompositingQuality = CompositingQuality.HighQuality

        Dim BrushColor As New SolidBrush(Color.White)
        g.FillRectangle(BrushColor, 0, 0, psw, psh)


        title = " "
        If (iunit = 1) Then
            title = "    Displacement (in)   "
        ElseIf (iunit = 2) Then
            title = "    Velocity (in-sec)  "
        ElseIf (iunit = 3) Then
            title = "Acceleration (in-sec2)  "
        ElseIf (iunit = 4) Then
            title = " Resistance (kisp)  "
        ElseIf (iunit = 5) Then
            title = " Applied Pulse (kips)     "
        ElseIf (iunit = 6) Then
            title = "    Reactions (kips)     "
        End If


        xmin = start_time
        xmax = end_time
        ymin = 1000000
        ymax = -1000000
        imax = 0
        imin = 0

        Dim Max2 As Double = 0.0

        For i = 0 To num_step
            If (Response(i, iunit) > ymax) Then
                ymax = Response(i, iunit)
                imax = i
            End If

            If (Response(i, iunit) < ymin) Then
                ymin = Response(i, iunit)
                imin = i
            End If

        Next




        Dim xoff As Integer = 20

        ymax = Abs(ymax)
        If (Math.Round(ymax, 0) > ymax) Then
            ymax = Math.Round(ymax, 0)
        Else
            ymax = Math.Round(ymax, 0) + 1
        End If

        If (Abs(ymin) > ymax) Then ymax = Abs(ymin)
        ymin = -ymax


        Dim scale_x, scale_y As Double
        scale_x = (psw - xoff) / (xmax - xmin)
        scale_y = -psh * 0.95 / (ymax - ymin)
        '
        ' draw the axis
        '
        Dim x_from, y_from, x_to, y_to As Integer
        Dim tt As Double


        g.FillRectangle(Brushes.White, 0, 0, xoff, psh)
        g.TranslateTransform(5, psh / 2 + 55)
        g.RotateTransform(-90)
        'g.DrawString(title, New Font("Arial", 10), Brushes.Black, 0, 0)
        g.ResetTransform()
        g.DrawString(CStr(Format(ymax, " 0.0")), New Font("Arial", 8), Brushes.Black, -1, 0)
        g.DrawString(CStr(Format(ymin, " 0.0")), New Font("Arial", 8), Brushes.Black, -1, psh - 12)
        '


        For i = 1 To 7
            y_from = i * psh / 8
            y_to = y_from
            g.DrawLine(Pens.Black, xoff, y_from, psw, y_to)

        Next

        x_from = scale_x * xmin + xoff
        x_to = scale_x * xmax + xoff
        y_from = psh / 2
        y_to = psh / 2
        PenColor.Color = cc(0)
        g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)



        tt = start_time
        y_from = 0
        y_to = psh
        g.DrawLine(Pens.Black, xoff, y_from, xoff, y_to)

        For i = 1 To 9

            x_from = i * psw / 10 + xoff
            x_to = x_from
            g.DrawLine(Pens.LightGray, x_from, y_from, x_to, y_to)
            tt = (xmax - xmin) * i / 10
            g.DrawString(CStr(Format(tt, " 0.000")), New Font("Arial", 8), Brushes.Black, x_to - (CStr(Format(tt, " 0.000")).Length) * 3, psh / 2)

        Next

        BlastForm.plotPanel.Visible = True


        PenColor.Color = cc(plot_type)

        For i = 0 To num_step - 1
            x_from = scale_x * time(i) + xoff
            x_to = scale_x * time(i + 1) + xoff
            y_from = scale_y * Response(i, iunit) + psh / 2
            y_to = scale_y * Response(i + 1, iunit) + psh / 2
            g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)
        Next

        PenColor.Color = cc(2)

        x_from = scale_x * time(imax) + xoff
        x_to = x_from
        y_from = scale_y * 0 + psh / 2
        y_to = scale_y * Response(imax, iunit) + psh / 2
        g.DrawLine(Pens.Red, x_from, y_from, x_to, y_to)
        g.FillPie(Brushes.Red, x_to - 4, y_to - 4, 8, 8, 0, 360)
        g.DrawString(CStr(Format(Response(imax, iunit), " 0.00")), New Font("Arial", 10), Brushes.Black, x_to + 8, y_to)

        x_from = scale_x * time(imin) + xoff
        x_to = x_from
        y_from = scale_y * 0 + psh / 2
        y_to = scale_y * Response(imin, iunit) + psh / 2
        g.DrawLine(Pens.Blue, x_from, y_from, x_to, y_to)
        g.FillPie(Brushes.Blue, x_to - 4, y_to - 4, 8, 8, 0, 360)
        g.DrawString(CStr(Format(Response(imin, iunit), " 0.00")), New Font("Arial", 10), Brushes.Black, x_to + 8, y_to - 2)

        If (iunit = 6) Then
            PenColor.Color = cc(1)

            For i = 0 To num_step - 1
                x_from = scale_x * time(i) + xoff
                x_to = scale_x * time(i + 1) + xoff
                y_from = scale_y * Response(i, iunit + 1) + psh / 2
                y_to = scale_y * Response(i + 1, iunit + 1) + psh / 2
                g.DrawLine(PenColor, x_from, y_from, x_to, y_to)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Generates the hist graph for report.
    ''' </summary>
    Public Shared Sub GenerateHistGraphForReport()
        Dim g As System.Drawing.Graphics
        g = BlastForm.histPanel.CreateGraphics

        Dim PenColor As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim cc() As Color = {Color.Red, Color.Gold, Color.FloralWhite, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Cyan, Color.Gray}


        Dim i As Integer
        Dim xmin, xmax, ymin, ymax As Double
        Dim title As String
        '
        ' clear the picture box
        '
        Dim psw, psh As Integer
        psh = BlastForm.histPanel.Size.Height
        psw = BlastForm.histPanel.Size.Width
        Dim BrushColor As New SolidBrush(Color.White)
        g.FillRectangle(BrushColor, 0, 0, psw, psh)

        title = " "

        xmin = 1000000
        xmax = -1000000
        ymin = 1000000
        ymax = -10000000
        '
        For i = 0 To num_step

            If (Response(i, 1) > xmax) Then xmax = Response(i, 1)
            If (Response(i, 1) < xmin) Then xmin = Response(i, 1)

            If (Response(i, 4) > ymax) Then ymax = Response(i, 4)
            If (Response(i, 4) < ymin) Then ymin = Response(i, 4)


        Next

        xmax = Abs(xmax)
        If (Abs(xmin) > xmax) Then xmax = Abs(xmin)
        xmin = -xmax

        ymax = Abs(ymax)
        If (Abs(ymin) > ymax) Then ymax = Abs(ymin)
        ymin = -ymax
        If Ru > ymax Then
            ymax = Ru
            ymin = -Ru
        End If
        '
        ' write the status
        '
        Dim xoff As Integer = 20
        Dim scale_x, scale_y As Double
        scale_x = (psw - xoff) * 0.85 / (xmax - xmin)
        scale_y = -psh * 0.85 / (ymax - ymin)


        g.FillRectangle(Brushes.White, 0, 0, xoff, psh)
        g.TranslateTransform(5, psh / 2 + 45)
        g.RotateTransform(-90)
        g.DrawString("Resistanse (kisp)", New Font("Arial", 10), Brushes.Black, 0, 0)
        g.ResetTransform()
        '
        g.DrawString(CStr(Format(ymax, " 0.0")), New Font("Arial", 8), Brushes.Black, -1, 0)
        g.DrawString(CStr(Format(ymin, " 0.0")), New Font("Arial", 8), Brushes.Black, -1, psh - 12)


        g.DrawString(CStr(Format(xmin, " 0.0")), New Font("Arial", 8), Brushes.Black, xoff, (psh) / 2 + 1)
        g.DrawString(CStr(Format(xmax, " 0.0")), New Font("Arial", 8), Brushes.Black, psw - xoff - 5, (psh) / 2 + 1)

        '

        Dim x_from, y_from, x_to, y_to As Integer

        x_from = psw / 2 + xoff
        y_from = 0
        x_to = x_from
        y_to = psh
        g.DrawLine(Pens.DimGray, x_from, y_from, x_to, y_to)

        x_from = xoff
        y_from = psh / 2
        x_to = psw + xoff
        y_to = y_from
        g.DrawLine(Pens.DimGray, x_from, y_from, x_to, y_to)

        PenColor.Color = cc(0)

        x_from = xoff
        x_to = psw + xoff

        y_from = scale_y * Ru + psh / 2
        y_to = y_from
        g.DrawLine(PenColor, x_from, y_from, x_to, y_to)

        y_from = -scale_y * Ru + psh / 2
        y_to = y_from
        g.DrawLine(PenColor, x_from, y_from, x_to, y_to)



        For i = 0 To num_step - 1
            x_from = scale_x * Response(i, 1) + psw / 2 + xoff
            x_to = scale_x * Response(i + 1, 1) + psw / 2 + xoff

            y_from = scale_y * Response(i, 4) + psh / 2
            y_to = scale_y * Response(i + 1, 4) + psh / 2
            g.DrawLine(Pens.Black, x_from, y_from, x_to, y_to)
        Next


    End Sub

#End Region

End Class
