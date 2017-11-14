
Imports System.Math

Module blast

#Region "Public Fields"

    Public mass, stiff, damp As Double
    Public e_stiff, e_mass As Double

    Public time(5000), Response(5000, 7) As Double
    Public blast_force(5000) As Double
    Public start_time, end_time, step_size, time_step, period As Double
    Public num_step As Integer
    Public Ru, Mp As Double
    Public DIF, SIF, KLMe, KLMp, KE, YEC, YET, YEP As Double
    Public u, ud, udd, restore As Double
    Public iseg, is_type As Integer
    Public fcy, fty As Double
    Public m_inertia, area, zsection, span, spacing, g_density, m_density, e_modulus As Double
    Public max_d, max_t, min_d, ductility As Double
    Public a1, a2, a3, a4, a5, a6 As Double
    Public v1_ae, v1_be, v1_ap, v1_bp, v2_ae, v2_be, v2_ap, v2_bp, v1_mf, v2_mf As Double

#End Region

    ''' <summary>
    ''' Starts the SDOF.
    ''' </summary>
    Sub StartSDOF()

        Dim i As Integer
        Dim delta_f, Delta_u, Delta_ud As Double
        Dim f1, f0 As Double
        Dim rebound As Double = 0

        'Intializes all the required fields
        Initialize()


        max_d = -1.0E+30
        min_d = 1.0E+30

        '
        ' eroor check for step size
        '
        time_step = start_time
        '      If (step_size > period / 20 Or step_size > duration / 20) Then
        'MsgBox(" Integration step size to big to converge, reduce response duration")
        '    Exit Sub
        '     End If
        '
        ' loop over time and generate the response
        '

        For i = 1 To num_step

            time_step = time_step + step_size

            f1 = blast_force(i)
            f0 = blast_force(i - 1)

            delta_f = f1 - f0 + (a2 * e_mass + 3 * damp) * ud + (3 * e_mass + a3 * damp) * udd
            Delta_u = delta_f / (e_stiff + a4 * e_mass + a1 * damp)
            Delta_ud = a1 * Delta_u - 3 * ud - a3 * udd

            u = u + Delta_u
            ud = ud + Delta_ud

            Call blast_state()

            udd = (f1 - damp * ud - restore) / e_mass

            If (u > max_d) Then max_d = u
            If (u < min_d) Then min_d = u

            time(i) = time_step
            Response(i, 1) = u
            Response(i, 2) = ud
            Response(i, 3) = udd
            Response(i, 4) = restore
            Response(i, 5) = f1
            '
            ' set reactions
            '
            If (iseg = 0) Then
                Response(i, 6) = v1_ae * restore + v1_be * f1
                Response(i, 7) = v2_ae * restore + v2_be * f1
            Else
                Response(i, 6) = v1_ap * restore + v1_bp * f1 + v1_mf
                Response(i, 7) = v2_ap * restore + v2_bp * f1 + v2_mf
            End If
            '
            ' check for rebound
            '
            If restore < rebound Then rebound = restore

        Next i

        '
        ' up data the results
        '
        Dim absmax As Double

        BlastForm.max_d.Text = CStr(Format(max_d, "0.00"))
        BlastForm.min_d.Text = CStr(Format(min_d, "0.00"))

        absmax = Abs(max_d)
        If Abs(min_d) > absmax Then absmax = Abs(min_d)
        max_t = Atan(2 * absmax / span) * 45 / Atan(1)
        BlastForm.max_t.Text = CStr(Format(max_t, "0.00"))

        ductility = absmax / (Ru / e_stiff)
        BlastForm.ductility.Text = CStr(Format(ductility, "0.00"))
        BlastForm.rebound_ratio.Text = Format(Abs(rebound) / Ru, "0.00")

        OutputData.Density = m_density
        OutputData.ElasticModulus = e_modulus
        OutputData.YieldStrength = fcy
        OutputData.Mass = mass
        OutputData.DIF = DIF
        OutputData.SIF = SIF
        OutputData.KLMe = KLMe
        OutputData.KLMp = KLMp
        OutputData.EquivalentMass = mass
        OutputData.EquivalentStiffness = stiff
        OutputData.SystemPeriod = period
        OutputData.PlasticMoment = Mp
        OutputData.UltimateResistance = Ru
        OutputData.YieldDisplacement = YET
        OutputData.LamdaMax = max_d
        OutputData.LamdaMin = min_d
        OutputData.DuctilityFactor = ductility
        OutputData.SupportRotation = max_t

    End Sub

    ''' <summary>
    ''' Blast_states this instance.
    ''' </summary>
    Sub blast_state()

        If (iseg = 0) Then
            '
            ' system is in elastic range
            ' 
            If (u >= YEC And u <= YET) Then
                iseg = 0
                e_mass = mass * KLMe
                e_stiff = stiff
                restore = Ru - YET * stiff + u * stiff

            ElseIf (u > YET) Then
                iseg = 1
                e_mass = mass * KLMp
                e_stiff = 0
                restore = Ru
            ElseIf (u < YEC) Then
                iseg = -1
                e_mass = mass * KLMp
                e_stiff = 0
                restore = -Ru
            End If

        ElseIf (iseg = 1 And ud < 0) Then
            ' 
            ' system in tension
            '  
            iseg = 0
            YET = u
            YEC = u - 2 * Ru / stiff
            e_mass = mass * KLMe
            e_stiff = stiff
            restore = Ru

        ElseIf (iseg = -1 And ud > 0) Then
            ' 
            ' system in compression
            '
            iseg = 0
            YEC = u
            YET = u + 2 * Ru / stiff
            e_mass = mass * KLMe
            e_stiff = stiff
            restore = -Ru

        End If
    End Sub

#Region "Private Methods"

    ''' <summary>
    ''' Initializes the force parameters.
    ''' </summary>
    Private Sub InitializeForceParameters()

        Dim i As Integer
        Dim tt, fff As Double
        Dim pulse, duration, rise_time, negative_duration, negative_pulse As Double

        span = InputData.Span * 12
        spacing = InputData.Spacing * 12

        If InputData.CurrentLoadType = InputData.LoadType.Triangular Then

            Dim fac, tpn, t_total
            pulse = InputData.Pulse * span * spacing / 1000
            duration = InputData.Duration / 1000
            rise_time = InputData.Rise / 1000
            negative_duration = InputData.NegativeDuration / 1000
            negative_pulse = InputData.NegativePulse * span * spacing / 1000
            t_total = duration + negative_duration

            If Math.Abs(pulse) > 0 Then
                fac = 1.0 - negative_pulse / pulse
                tpn = rise_time + (duration - rise_time) * fac
            Else
                tpn = duration
            End If

            For i = 0 To num_step
                tt = i * step_size
                fff = 0
                If (tt > t_total) Then
                    fff = 0.0
                ElseIf (rise_time > 0 And tt <= rise_time) Then
                    fff = tt * pulse / rise_time
                ElseIf (tt > rise_time And tt <= tpn) Then
                    fff = pulse * (1.0 - (tt - rise_time) / (duration - rise_time))
                ElseIf (t_total - tpn) > 0.0 Then
                    fff = negative_pulse - (negative_pulse) * (tt - tpn) / (t_total - tpn)
                End If
                blast_force(i) = fff
            Next i


        ElseIf InputData.CurrentLoadType = InputData.LoadType.Sinusoidal Then

            Dim sine_amp, sine_freq As Double
            sine_amp = InputData.Amplitude * span * spacing / 1000
            sine_freq = InputData.Frequency

            For i = 0 To num_step
                tt = i * step_size
                blast_force(i) = sine_amp * Sin(tt * sine_freq * 2.0 * Math.PI)
            Next

        End If

    End Sub

    ''' <summary>
    ''' Initializes the integration parameters.
    ''' </summary>
    Private Sub InitializeIntegrationParameters()
        start_time = 0.0

        end_time = InputData.ResponseDuration
        step_size = InputData.ResponseStepSize / 1000
        num_step = Math.Truncate((end_time - start_time) / step_size)
        If num_step > 5000 Then num_step = 5000

        a1 = 3 / step_size
        a2 = 6 / step_size
        a3 = step_size / 2
        a4 = 6 / step_size ^ 2
    End Sub

    ''' <summary>
    ''' Initializes this instance.
    ''' </summary>
    Private Sub Initialize()

        InitializeIntegrationParameters()

        InitializeForceParameters()

        '
        ' get mullion propery
        '
        span = InputData.Span * 12
        spacing = InputData.Spacing * 12
        area = InputData.Area
        m_inertia = InputData.Inertia
        zsection = InputData.PlasticModulus
        g_density = InputData.GlassWeight

        '
        ' get the span type
        '
        If InputData.SpanType = 1 Then
            is_type = 2
        Else
            is_type = 1
        End If
        '
        ' get material type
        '
        Dim mat_index As Integer
        mat_index = InputData.MaterialIndex
        If (mat_index = 0) Then
            fcy = 25.0
            fty = 25.0
            m_density = 170
            e_modulus = 10100
            DIF = 1.02
            SIF = 1.2
        ElseIf (mat_index = 1) Then
            fcy = 13.0
            fty = 13.0
            m_density = 170
            e_modulus = 10100
            DIF = 1.02
            SIF = 1.2
        ElseIf (mat_index = 2) Then
            fcy = 36
            fty = 36
            m_density = 490
            e_modulus = 29000
            DIF = 1.29
            SIF = 1.1
        ElseIf (mat_index = 3) Then
            fcy = 50
            fty = 50
            m_density = 490
            e_modulus = 29000
            DIF = 1.19
            SIF = 1.1
        ElseIf (mat_index = 4) Then
            fcy = 30
            fty = 30
            m_density = 490
            e_modulus = 28000
            DIF = 1.18
            SIF = 1.1
        End If

        BlastForm.fy.Text = CStr(Format(fcy, "0.00"))
        BlastForm.e_modulus.Text = CStr(Format(e_modulus, "0."))
        BlastForm.DIF.Text = CStr(Format(DIF, "0.00"))
        BlastForm.SIF.Text = CStr(Format(SIF, "0.00"))

        ' 
        ' set equivlancy  factors
        '
        Dim sfac, rfac As Double
        If InputData.SpanType = 0 Then
            KLMe = 0.5 / 0.64
            KLMp = 0.33 / 0.5
            sfac = 384 / 5
            rfac = 8

            v1_ae = 0.39
            v1_be = 0.11
            v1_ap = 0.38
            v1_bp = 0.12

            v2_ae = 0.39
            v2_be = 0.11
            v2_ap = 0.38
            v2_bp = 0.12

        Else
            KLMe = (0.45 / 0.58 + 0.5 / 0.64) / 2
            KLMp = 0.33 / 0.5
            sfac = 160
            rfac = 12

            v1_ae = 0.26
            v1_be = 0.12
            v1_ap = 0.43
            v1_bp = 0.19


            v2_ae = 0.38
            v2_be = 0.12
            v2_ap = 0.38
            v2_bp = 0.12
        End If
        BlastForm.KLMe.Text = CStr(Format(KLMe, "0.00"))
        BlastForm.KLMp.Text = CStr(Format(KLMp, "0.00"))
        '  '
        ' compute ultimate capacities
        '

        Mp = zsection * DIF * SIF * fcy
        Ru = rfac * Mp / span
        BlastForm.MP.Text = CStr(Format(Mp, "0.00"))
        BlastForm.RU.Text = CStr(Format(Ru, "0.00"))
        '
        ' se the moment factors for the reactions
        '

        If InputData.SpanType = 0 Then
            v1_mf = 0.0
            v2_mf = 0.0
        Else
            v1_mf = Mp / span
            v2_mf = -Mp / span
        End If

        ' compute equivanat system properties
        '
        ' 
        stiff = sfac * e_modulus * m_inertia / (span ^ 3)
        mass = ((m_density * area * span / 1728) + (g_density * spacing * span / 144)) / (1000 * 32.2 * 12)
        BlastForm.Ke.Text = CStr(Format(stiff, "0.000"))
        BlastForm.mass.Text = CStr(Format(mass, "0.0000"))
        period = (8.0 * Atan(1.0) / Sqrt(stiff / (KLMe * mass))) * 1000
        BlastForm.period.Text = CStr(Format(period, "0.0"))
        damp = 0.01 * 2 * Sqrt(stiff * KLMe * mass)

        '
        ' find the yield displacemnt
        '
        YET = Ru / stiff
        YEC = -YET
        BlastForm.Ye.Text = Format(YET, "0.00")
        '
        ' read pule info
        '

        '
        ' set initial values
        '
        Dim f0 As Double
        f0 = blast_force(0)

        time(0) = 0
        Response(0, 1) = 0
        Response(0, 2) = 0
        Response(0, 3) = f0 / (mass * KLMe)
        Response(0, 4) = 0
        Response(0, 5) = f0
        Response(0, 6) = 0
        Response(0, 7) = 0

        iseg = 0
        u = 0
        ud = 0
        udd = f0 / (mass * KLMe)

        e_mass = KLMe * mass
        e_stiff = stiff
    End Sub

#End Region

End Module

