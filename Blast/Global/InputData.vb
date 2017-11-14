Imports System.Windows.Media.Imaging
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO

''' <summary>
''' Global Class for saving input data and transferring information
''' </summary>
Public Class InputData

#Region "Enums"

    Public Enum LoadType
        Triangular = 1
        Sinusoidal = 2
        General = 3
    End Enum

    Public Enum PlotType
        Displacement = 1
        Velocity = 2
        Acceleration = 3
        Restoring = 4
        AppliedLoad = 5
    End Enum

#End Region

#Region "Private Fields"

    Private Shared _CurrentOpenFile As String

    'Project Info Data
    Private Shared _firstTimeProjectInfo As Boolean
    Private Shared _projectName As String
    Private Shared _projectSubject As String
    Private Shared _projectUser As String
    Private Shared _projectDate As String

    'Span Form Data
    Private Shared _firstTimeSpanInput As Boolean
    Private Shared _span As Double
    Private Shared _spacing As Double
    Private Shared _spantype As Integer

    'Section Form Data
    Private Shared _firstTimeSectionInput As Boolean
    Private Shared _inertia As Double
    Private Shared _plasticModulus As Double
    Private Shared _area As Double

    'Material Form Data
    Private Shared _firstTimeMaterialInput As Boolean
    Private Shared _glassWeight As Double
    Private Shared _material As String
    Private Shared _materialIndex As Integer

    'Load : Triangular Pulse Data
    Private Shared _firstTimeTriangularPulseInput As Boolean
    Private Shared _pulse As Double
    Private Shared _rise As Double
    Private Shared _duration As Double
    Private Shared _negativePulse As Double
    Private Shared _negativeDuration As Double

    'Load : Sinusoidal Pulse Data
    Private Shared _firstTimeSinusoidalPulseInput As Boolean
    Private Shared _sinAmp As Double
    Private Shared _sinFreq As Double

    'Response Data
    Private Shared _firstTimeResponseData As Boolean
    Private Shared _responseDuration As Double
    Private Shared _responseStepSize As Double

    'Menu Items
    Private Shared _selectedLoadType As LoadType
    Private Shared _selectedPlotType As PlotType

    Private Shared _epropImage As Image
    Private Shared _epropImageLocation As String


    Private Shared _dataOnLoad As New Hashtable
    Private Shared _dataAfterLoad As New Hashtable

#End Region

#Region "Properties"

#Region "Project Info Properties"

    ''' <summary>
    ''' Gets or sets a value indicating whether [first time project info].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time project info]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeProjectInfo() As Boolean
        Get
            Return _firstTimeProjectInfo
        End Get
        Set(ByVal value As Boolean)
            _firstTimeProjectInfo = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the name of the project.
    ''' </summary>
    ''' <value>The name of the project.</value>
    Public Shared Property ProjectName() As String
        Get
            Return _projectName
        End Get
        Set(ByVal value As String)
            _projectName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the project subject.
    ''' </summary>
    ''' <value>The project subject.</value>
    Public Shared Property ProjectSubject() As String
        Get
            Return _projectSubject
        End Get
        Set(ByVal value As String)
            _projectSubject = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the project user.
    ''' </summary>
    ''' <value>The project user.</value>
    Public Shared Property ProjectUser() As String
        Get
            Return _projectUser
        End Get
        Set(ByVal value As String)
            _projectUser = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the project date.
    ''' </summary>
    ''' <value>The project date.</value>
    Public Shared Property ProjectDate() As String
        Get
            Return _projectDate
        End Get
        Set(ByVal value As String)
            _projectDate = value
        End Set
    End Property


#End Region

#Region "Section Data Properties"

    ''' <summary>
    ''' Gets or sets a value indicating whether [first time section data input].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time section data input]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeSectionDataInput() As Boolean
        Get
            Return _firstTimeSectionInput
        End Get
        Set(ByVal value As Boolean)
            _firstTimeSectionInput = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the inertia.
    ''' </summary>
    ''' <value>The inertia.</value>
    Public Shared Property Inertia() As Double
        Get
            Return _inertia
        End Get
        Set(ByVal value As Double)
            _inertia = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the plastic modulus.
    ''' </summary>
    ''' <value>The plastic modulus.</value>
    Public Shared Property PlasticModulus() As Double
        Get
            Return _plasticModulus
        End Get
        Set(ByVal value As Double)
            _plasticModulus = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the area.
    ''' </summary>
    ''' <value>The area.</value>
    Public Shared Property Area() As Double
        Get
            Return _area
        End Get
        Set(ByVal value As Double)
            _area = value
        End Set
    End Property

#End Region

#Region "Span data Properties"

    ''' <summary>
    ''' Gets or sets a value indicating whether [first time span data input].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time span data input]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeSpanDataInput() As Boolean
        Get
            Return _firstTimeSpanInput
        End Get
        Set(ByVal value As Boolean)
            _firstTimeSpanInput = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the span.
    ''' </summary>
    ''' <value>The span.</value>
    Public Shared Property Span() As Double
        Get
            Return _span
        End Get
        Set(ByVal value As Double)
            _span = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the spacing.
    ''' </summary>
    ''' <value>The spacing.</value>
    Public Shared Property Spacing() As Double
        Get
            Return _spacing
        End Get
        Set(ByVal value As Double)
            _spacing = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the span.
    ''' </summary>
    ''' <value>The type of the span.</value>
    Public Shared Property SpanType() As Integer
        Get
            Return _spantype
        End Get
        Set(ByVal value As Integer)
            _spantype = value
        End Set
    End Property
#End Region

#Region "Material Data Properties"

    ''' <summary>
    ''' Gets or sets a value indicating whether [first time material data input].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time material data input]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeMaterialDataInput() As Boolean
        Get
            Return _firstTimeMaterialInput
        End Get
        Set(ByVal value As Boolean)
            _firstTimeMaterialInput = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the glass weight.
    ''' </summary>
    ''' <value>The glass weight.</value>
    Public Shared Property GlassWeight() As Double
        Get
            Return _glassWeight
        End Get
        Set(ByVal value As Double)
            _glassWeight = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the index of the material.
    ''' </summary>
    ''' <value>The index of the material.</value>
    Public Shared Property MaterialIndex() As Integer
        Get
            Return _materialIndex
        End Get
        Set(ByVal value As Integer)
            _materialIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the material value.
    ''' </summary>
    ''' <value>The material value.</value>
    Public Shared Property MaterialValue() As String
        Get
            Return _material
        End Get
        Set(ByVal value As String)
            _material = value
        End Set
    End Property

#End Region

#Region "Triangular Pulse Data Properties"
    ''' <summary>
    ''' Gets or sets a value indicating whether [first time tri pulse input].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time tri pulse input]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeTriPulseInput() As Boolean
        Get
            Return _firstTimeTriangularPulseInput
        End Get
        Set(ByVal value As Boolean)
            _firstTimeTriangularPulseInput = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the pulse.
    ''' </summary>
    ''' <value>The pulse.</value>
    Public Shared Property Pulse() As Double
        Get
            Return _pulse
        End Get
        Set(ByVal value As Double)
            _pulse = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the rise.
    ''' </summary>
    ''' <value>The rise.</value>
    Public Shared Property Rise() As Double
        Get
            Return _rise
        End Get
        Set(ByVal value As Double)
            _rise = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the duration.
    ''' </summary>
    ''' <value>The duration.</value>
    Public Shared Property Duration() As Double
        Get
            Return _duration
        End Get
        Set(ByVal value As Double)
            _duration = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the negative pulse.
    ''' </summary>
    ''' <value>The negative pulse.</value>
    Public Shared Property NegativePulse() As Double
        Get
            Return _negativePulse
        End Get
        Set(ByVal value As Double)
            _negativePulse = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the duration of the negative.
    ''' </summary>
    ''' <value>The duration of the negative.</value>
    Public Shared Property NegativeDuration() As Double
        Get
            Return _negativeDuration
        End Get
        Set(ByVal value As Double)
            _negativeDuration = value
        End Set
    End Property

#End Region

#Region "Sinusoidal Pulse Data Properties"

    ''' <summary>
    ''' Gets or sets a value indicating whether [first time sinusoidal input].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time sinusoidal input]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeSinusoidalInput() As Boolean
        Get
            Return _firstTimeSinusoidalPulseInput
        End Get
        Set(ByVal value As Boolean)
            _firstTimeSinusoidalPulseInput = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the amplitude.
    ''' </summary>
    ''' <value>The amplitude.</value>
    Public Shared Property Amplitude() As Double
        Get
            Return _sinAmp
        End Get
        Set(ByVal value As Double)
            _sinAmp = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the frequency.
    ''' </summary>
    ''' <value>The frequency.</value>
    Public Shared Property Frequency() As Double
        Get
            Return _sinFreq
        End Get
        Set(ByVal value As Double)
            _sinFreq = value
        End Set
    End Property

#End Region

#Region "Response Data Properties"


    ''' <summary>
    ''' Gets or sets a value indicating whether [first time response data].
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if [first time response data]; otherwise, <c>false</c>.
    ''' </value>
    Public Shared Property FirstTimeResponseData() As Boolean
        Get
            Return _firstTimeResponseData
        End Get
        Set(ByVal value As Boolean)
            _firstTimeResponseData = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the duration of the response.
    ''' </summary>
    ''' <value>The duration of the response.</value>
    Public Shared Property ResponseDuration() As Double
        Get
            Return _responseDuration
        End Get
        Set(ByVal value As Double)
            _responseDuration = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the size of the response step.
    ''' </summary>
    ''' <value>The size of the response step.</value>
    Public Shared Property ResponseStepSize() As Double
        Get
            Return _responseStepSize
        End Get
        Set(ByVal value As Double)
            _responseStepSize = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' Gets or sets the type of the current load.
    ''' </summary>
    ''' <value>The type of the current load.</value>
    Public Shared Property CurrentLoadType() As LoadType
        Get
            Return _selectedLoadType
        End Get
        Set(ByVal value As LoadType)
            _selectedLoadType = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the current plot.
    ''' </summary>
    ''' <value>The type of the current plot.</value>
    Public Shared Property CurrentPlotType() As PlotType
        Get
            Return _selectedPlotType
        End Get
        Set(ByVal value As PlotType)
            _selectedPlotType = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the epropoties image.
    ''' </summary>
    ''' <value>The epropoties image.</value>
    Public Shared ReadOnly Property EpropotiesImage() As Image
        Get
            Return _epropImage
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the E properties location.
    ''' </summary>
    ''' <value>The E properties location.</value>
    Public Shared Property EPropertiesLocation() As String
        Get
            Return _epropImageLocation
        End Get
        Set(ByVal value As String)
            _epropImageLocation = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current open F ile.
    ''' </summary>
    ''' <value>The current open F ile.</value>
    Public Shared Property CurrentOpenFIle As String
        Get
            Return _CurrentOpenFile
        End Get
        Set(ByVal value As String)
            _CurrentOpenFile = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the data on load.
    ''' </summary>
    ''' <value>The data on load.</value>
    Public Shared ReadOnly Property DataOnLoad As Hashtable
        Get
            Return _dataOnLoad
        End Get
    End Property

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Gets the eprop values.
    ''' </summary>
    ''' <param name="properties">The properties.</param>
    ''' <returns></returns>
    Private Shared Function GetEpropValues(ByVal properties As String) As Hashtable

        Dim values As New Hashtable()
        Dim propertiesAfterSplit As String() = properties.Split("$")

        Dim s As String
        For Each s In propertiesAfterSplit
            Dim temp As String() = s.Split(":")
            values.Add(temp(0).Replace(" ", ""), temp(1).Replace(" ", ""))
        Next

        Return values
    End Function

    ''' <summary>
    ''' Gets the E blast values.
    ''' </summary>
    ''' <param name="fileloc">The fileloc.</param>
    ''' <returns></returns>
    Private Shared Function GetEBlastValues(ByVal fileloc As String) As Hashtable

        Dim reader As TextReader = Nothing
        Dim values As New Hashtable()
        Try
            reader = New StreamReader(File.OpenRead(fileloc))
            Dim properties As String = reader.ReadToEnd

            Dim valuesAfterSplit As String() = properties.Split("$")

            Dim s As String
            For Each s In valuesAfterSplit
                Dim temp As String() = s.Split("@")
                values.Add(temp(0).Replace(" ", "").Trim, temp(1).Trim)
            Next

        Catch ex As Exception
            Throw ex
        Finally
            If reader IsNot Nothing Then
                reader.Close()
                reader.Dispose()
            End If
        End Try

        Return values
    End Function

    ''' <summary>
    ''' Initializes the eprop to form.
    ''' </summary>
    ''' <param name="values">The values.</param>
    Private Shared Sub initializeEpropToForm(ByVal values As Hashtable)

        If values.ContainsKey("MomentofIntertiaIx") Then
            _inertia = values.Item("MomentofIntertiaIx")
        End If
        If values.ContainsKey("PlasticModulusZx") Then
            _plasticModulus = values.Item("PlasticModulusZx")
        End If
        If values.ContainsKey("Area") Then
            _area = values.Item("Area")
        End If
        _firstTimeSectionInput = False
    End Sub

    ''' <summary>
    ''' Initilizes the E blast values.
    ''' </summary>
    ''' <param name="values">The values.</param>
    Private Shared Sub initilizeEBlastValues(ByVal values As Hashtable)

        _firstTimeProjectInfo = False
        _firstTimeSpanInput = False
        _firstTimeSectionInput = False
        _firstTimeMaterialInput = False
        _firstTimeTriangularPulseInput = False
        _firstTimeSinusoidalPulseInput = False
        _firstTimeResponseData = False

        If values.ContainsKey("_span") Then
            _span = values.Item("_span")
        End If

        If values.ContainsKey("_spacing") Then
            _spacing = values.Item("_spacing")
        End If
        If values.ContainsKey("_spantype") Then
            _spantype = values.Item("_spantype")
        End If
        If values.ContainsKey("_inertia") Then
            _inertia = values.Item("_inertia")
        End If
        If values.ContainsKey("_plasticModulus") Then
            _plasticModulus = values.Item("_plasticModulus")
        End If
        If values.ContainsKey("_area") Then
            _area = values.Item("_area")
        End If
        If values.ContainsKey("_glassWeight") Then
            _glassWeight = values.Item("_glassWeight")
        End If
        If values.ContainsKey("_material") Then
            _material = values.Item("_material")
        End If
        If values.ContainsKey("_materialIndex") Then
            _materialIndex = values.Item("_materialIndex")
        End If

        If values.ContainsKey("_pulse") Then
            _pulse = values.Item("_pulse")
        End If
        If values.ContainsKey("_rise") Then
            _rise = values.Item("_rise")
        End If
        If values.ContainsKey("_duration") Then
            _duration = values.Item("_duration")
        End If
        If values.ContainsKey("_negativePulse") Then
            _negativePulse = values.Item("_negativePulse")
        End If
        If values.ContainsKey("_negativeDuration") Then
            _negativeDuration = values.Item("_negativeDuration")
        End If

        If values.ContainsKey("_sinAmp") Then
            _sinAmp = values.Item("_sinAmp")
        End If
        If values.ContainsKey("_sinFreq") Then
            _sinFreq = values.Item("_sinFreq")
        End If

        If values.ContainsKey("_responseDuration") Then
            _responseDuration = values.Item("_responseDuration")
        End If
        If values.ContainsKey("_responseStepSize") Then
            _responseStepSize = values.Item("_responseStepSize")
        End If

        If values.ContainsKey("_epropImageLocation") Then
            _epropImageLocation = values.Item("_epropImageLocation")
            _epropImage = Image.FromFile(_epropImageLocation)
        End If

        If values.ContainsKey("_projectName") Then
            _projectName = values.Item("_projectName")
        End If

        If values.ContainsKey("_projectUser") Then
            _projectUser = values.Item("_projectUser")
        End If

        If values.ContainsKey("_projectDate") Then
            _projectDate = values.Item("_projectDate")
        End If

        If values.ContainsKey("_projectSubject") Then
            _projectSubject = values.Item("_projectSubject")
        End If

        If values.ContainsKey("_selectedLoadType") Then

            Dim lType As LoadType

            For Each lType In [Enum].GetValues(GetType(LoadType))
                Dim name As String = lType.ToString()

                If name.ToUpper.Equals(values.Item("_selectedLoadType").ToString.ToUpper) Then
                    _selectedLoadType = lType
                    Exit For
                End If
            Next
        End If

        If values.ContainsKey("_selectedPlotType") Then
            Dim pType As PlotType

            For Each pType In [Enum].GetValues(GetType(PlotType))
                Dim name As String = pType.ToString()

                If name.ToUpper.Equals(values.Item("_selectedPlotType").ToString.ToUpper) Then
                    _selectedPlotType = pType
                    Exit For
                End If
            Next
        End If

    End Sub


    ''' <summary>
    ''' Saves the file.
    ''' </summary>
    ''' <param name="FileLoc">The file loc.</param>
    Private Shared Sub SaveFile(ByVal FileLoc As String)

        Dim save As Boolean = False
        If File.Exists(FileLoc) Then
            File.Delete(FileLoc)
        End If
        Dim writer As StreamWriter = Nothing
        Try
            writer = New StreamWriter(File.Create(FileLoc))
            writer.WriteLine("_projectName@" + _projectName)
            writer.WriteLine("$_projectSubject@" + _projectSubject)
            writer.WriteLine("$_projectUser@" + _projectUser)
            writer.WriteLine("$_projectDate@" + _projectDate)
            writer.WriteLine("$_span@" + _span.ToString)
            writer.WriteLine("$_spacing@" + _spacing.ToString)
            writer.WriteLine("$_spantype@" + _spantype.ToString)
            writer.WriteLine("$_inertia@" + _inertia.ToString)
            writer.WriteLine("$_plasticModulus@" + _plasticModulus.ToString)
            writer.WriteLine("$_area@" + _area.ToString)
            writer.WriteLine("$_glassWeight@" + _glassWeight.ToString)
            writer.WriteLine("$_material@" + _material)
            writer.WriteLine("$_materialIndex@" + _materialIndex.ToString)
            writer.WriteLine("$_pulse@" + _pulse.ToString)
            writer.WriteLine("$_rise@" + _rise.ToString)
            writer.WriteLine("$_duration@" + _duration.ToString)
            writer.WriteLine("$_negativePulse@" + _negativePulse.ToString)
            writer.WriteLine("$_negativeDuration@" + _negativeDuration.ToString)
            writer.WriteLine("$_sinAmp@" + _sinAmp.ToString)
            writer.WriteLine("$_sinFreq@" + _sinFreq.ToString)
            writer.WriteLine("$_responseDuration@" + _responseDuration.ToString)
            writer.WriteLine("$_responseStepSize@" + _responseStepSize.ToString)
            writer.WriteLine("$_selectedLoadType@" + _selectedLoadType.ToString)
            writer.WriteLine("$_selectedPlotType@" + _selectedPlotType.ToString)

            If _epropImage IsNot Nothing And Not String.IsNullOrEmpty(_epropImageLocation) Then
                writer.WriteLine("$_epropImageLocation@" + _epropImageLocation)
            End If
            save = True
        Catch ex As Exception
            Throw ex
        Finally
            writer.Close()
            writer.Dispose()
        End Try

        If save Then
            Encrypt(FileLoc)
        End If

    End Sub

    ''' <summary>
    ''' Reads the existing blast file.
    ''' </summary>
    ''' <param name="FileLoc">The file loc.</param>
    Private Shared Sub ReadExistingBlastFile(ByVal FileLoc As String)
        Try
            Dim decryptedFile As String = Decrypt(FileLoc)
            If Not String.IsNullOrEmpty(decryptedFile) Then

                If File.Exists(decryptedFile) Then

                    initilizeEBlastValues(GetEBlastValues(decryptedFile))
                    File.Delete(decryptedFile)
                    _CurrentOpenFile = FileLoc

                    'Will be used to see if there were any changes
                    SaveDataOnFileLoad()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Encryption"

    ''' <summary>
    ''' Decrypts the specified file loc.
    ''' </summary>
    ''' <param name="FileLoc">The file loc.</param>
    ''' <returns></returns>
    Private Shared Function Decrypt(ByVal FileLoc As String) As String

        Dim fsInput As System.IO.FileStream
        Dim fsOutput As System.IO.FileStream

        Dim EncyrptedFileLocation As String = FileLoc
        'Always use the same keyword for encyption and decryption
        'Declare variables for the key and iv.
        'The key needs to hold 256 bits and the iv 128 bits.
        Dim bytKey As Byte() = CreateKey("sveguru")
        Dim bytIV As Byte() = CreateIV("sveguru")

        Dim eblastFileName As String = Path.GetFileNameWithoutExtension(EncyrptedFileLocation)

        Dim decryptedFileLocation As String = Path.GetDirectoryName(EncyrptedFileLocation)

        If (True = decryptedFileLocation.EndsWith("\")) Then
            decryptedFileLocation += eblastFileName + ".ebls.decrypt"
        Else
            decryptedFileLocation += "\" + eblastFileName + ".ebls.decrypt"
        End If

        'Setup file streams to handle input and output.
        fsInput = New System.IO.FileStream(EncyrptedFileLocation, FileMode.Open, FileAccess.Read)
        fsOutput = New System.IO.FileStream(decryptedFileLocation, FileMode.OpenOrCreate, FileAccess.Write)
        fsOutput.SetLength(0) 'make sure fsOutput is empty

        Try


            'Declare variables for encrypt/decrypt process.
            Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing
            Dim lngBytesProcessed As Long = 0 'running count of bytes processed
            Dim lngFileLength As Long = fsInput.Length 'the input file's length
            Dim intBytesInCurrentBlock As Integer 'current bytes being processed
            Dim csCryptoStream As CryptoStream
            'Declare your CryptoServiceProvider.
            Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged

            csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write)

            'Use While to loop until all of the file is processed.
            While lngBytesProcessed < lngFileLength
                'Read file with the input filestream.
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                'Write output file with the cryptostream.
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                'Update lngBytesProcessed
                lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
            End While

            'Close FileStreams and CryptoStream.
            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()

        Catch ex As Exception
            decryptedFileLocation = Nothing
            fsInput.Close()
            fsOutput.Close()
            Dim fileDelete As New System.IO.FileInfo(decryptedFileLocation)
            fileDelete.Delete()
            Throw ex

        End Try

        Return decryptedFileLocation
    End Function


    ''' <summary>
    ''' Encrypts the specified file loc.
    ''' </summary>
    ''' <param name="FileLoc">The file loc.</param>
    Private Shared Sub Encrypt(ByVal FileLoc As String)

        Dim fsInput As System.IO.FileStream
        Dim fsOutput As System.IO.FileStream
        Dim originalFileLocation As String = FileLoc

        Dim eblastFileName As String = Path.GetFileNameWithoutExtension(originalFileLocation)

        Dim encryptedFileLocation As String = Path.GetDirectoryName(originalFileLocation)

        If (True = encryptedFileLocation.EndsWith("\")) Then
            encryptedFileLocation += eblastFileName + ".ebls.encrypt"
        Else
            encryptedFileLocation += "\" + eblastFileName + ".ebls.encrypt"
        End If


        'Always use the same keyword for encyption and decryption
        'Declare variables for the key and iv.
        'The key needs to hold 256 bits and the iv 128 bits.
        Dim bytKey As Byte() = CreateKey("sveguru")
        Dim bytIV As Byte() = CreateIV("sveguru")


        'Start the encryption.

        'Setup file streams to handle input and output.
        fsInput = New System.IO.FileStream(originalFileLocation, FileMode.Open, FileAccess.Read)
        fsOutput = New System.IO.FileStream(encryptedFileLocation, FileMode.OpenOrCreate, FileAccess.Write)
        fsOutput.SetLength(0) 'make sure fsOutput is empty


        Try
            'Declare variables for encrypt/decrypt process.
            Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing
            Dim lngBytesProcessed As Long = 0 'running count of bytes processed
            Dim lngFileLength As Long = fsInput.Length 'the input file's length
            Dim intBytesInCurrentBlock As Integer 'current bytes being processed
            Dim csCryptoStream As CryptoStream
            'Declare your CryptoServiceProvider.
            Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged

            csCryptoStream = New CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write)

            'Use While to loop until all of the file is processed.
            While lngBytesProcessed < lngFileLength
                'Read file with the input filestream.
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                'Write output file with the cryptostream.
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                'Update lngBytesProcessed
                lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
            End While

            'Close FileStreams and CryptoStream.
            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()

            RenameFile(encryptedFileLocation, originalFileLocation)

        Catch ex As Exception
            fsInput.Close()
            fsOutput.Close()
            Dim fileDelete As New System.IO.FileInfo(encryptedFileLocation)
            fileDelete.Delete()
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Renames the file.
    ''' </summary>
    ''' <param name="FilepathOld">The filepath old.</param>
    ''' <param name="FilepathNew">The filepath new.</param>
    Private Shared Sub RenameFile(ByVal FilepathOld As String, ByVal FilepathNew As String)

        If System.IO.File.Exists(FilepathNew) Then
            System.IO.File.Delete(FilepathNew)
        End If

        Dim fi As New FileInfo(FilepathOld)

        If fi.Exists Then
            fi.MoveTo(FilepathNew)
        End If
    End Sub

    ''' <summary>
    ''' Creates the IV.
    ''' </summary>
    ''' <param name="strPassword">The STR password.</param>
    ''' <returns></returns>
    Private Shared Function CreateIV(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytIV(15).  It will hold 128 bits.
        Dim bytIV(15) As Byte

        'Use For Next to put a specific size (128 bits) of 
        'bytResult into bytIV. The 0 To 30 for bytKey used the first 256 bits.
        'of the hashed password. The 32 To 47 will put the next 128 bits into bytIV.
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next

        Return bytIV 'return the IV
    End Function

    ''' <summary>
    ''' Creates the key.
    ''' </summary>
    ''' <param name="strPassword">The STR password.</param>
    ''' <returns></returns>
    Private Shared Function CreateKey(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytKey(31).  It will hold 256 bits.
        Dim bytKey(31) As Byte

        'Use For Next to put a specific size (256 bits) of 
        'bytResult into bytKey. The 0 To 31 will put the first 256 bits
        'of 512 bits into bytKey.
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next

        Return bytKey 'Return the key.
    End Function

#End Region

#Region "Report"

    ''' <summary>
    ''' Gets the picturebox.
    ''' </summary>
    ''' <param name="panel">The panel.</param>
    ''' <returns></returns>
    Private Shared Function GetPicturebox(ByVal panel As Panel) As Bitmap

        Dim image As Bitmap
        Dim graphics As Graphics = panel.CreateGraphics
        Dim s As Size = panel.Size

        image = New Bitmap(s.Width, s.Height, graphics)

        Dim memoryGraphics As Graphics = graphics.FromImage(image)

        Dim startX As Integer = BlastForm.Location.X + panel.Location.X + 9
        Dim startY As Integer = BlastForm.Location.Y + panel.Location.Y + 30


        memoryGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        memoryGraphics.SmoothingMode = SmoothingMode.HighQuality
        memoryGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        memoryGraphics.CompositingQuality = CompositingQuality.HighQuality
        image.SetResolution(600, 300)
        memoryGraphics.CopyFromScreen(startX, startY, 0, 0, s)
        Return image
    End Function


    ''' <summary>
    ''' Sets the resolution.
    ''' </summary>
    ''' <param name="sourceImage">The source image.</param>
    ''' <param name="resolution">The resolution.</param>
    ''' <returns></returns>
    Friend Shared Function SetResolution(ByVal sourceImage As Image, ByVal resolution As Integer) As Image
        Dim reduction As Double = resolution / CInt(sourceImage.HorizontalResolution)
        Using newImage As New Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat)
            newImage.SetResolution(resolution, resolution)
            Dim outImage As New Bitmap(sourceImage, CInt(sourceImage.Width * reduction), CInt(sourceImage.Height * reduction))
            Using g As Graphics = Graphics.FromImage(newImage)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.SmoothingMode = SmoothingMode.HighQuality
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.CompositingQuality = CompositingQuality.HighQuality
                g.DrawImage(outImage, 0, 0)
            End Using
            Return outImage
        End Using
    End Function

#End Region

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Gets the temp folder.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetTempFolder() As String
        Dim tempENV As String = System.Environment.GetEnvironmentVariable("TEMP")
        If False = tempENV.EndsWith("\") Then
            tempENV &= "\Enclos\Blast\"
        Else
            tempENV &= "Enclos\Blast\"
        End If

        If Not Directory.Exists(tempENV) Then
            Directory.CreateDirectory(tempENV)
        End If

        Return tempENV

    End Function

    ''' <summary>
    ''' Initializes this instance.
    ''' </summary>
    Public Shared Sub initialize()

        _firstTimeProjectInfo = True

        _firstTimeSpanInput = True
        _span = 12.5
        _spacing = 5
        _spantype = 0

        _firstTimeSectionInput = True
        _inertia = 15
        _plasticModulus = 5
        _area = 5

        _firstTimeMaterialInput = True
        _glassWeight = 10
        _material = "Aluminum 6061-T6"
        _materialIndex = 0

        _firstTimeTriangularPulseInput = True
        _pulse = 4
        _rise = 0
        _duration = 14
        _negativePulse = 0
        _negativeDuration = 1

        _firstTimeSinusoidalPulseInput = True
        _sinAmp = 4
        _sinFreq = 5

        _firstTimeResponseData = True
        _responseDuration = 0.25
        _responseStepSize = 0.1

        _epropImage = Nothing
        _epropImageLocation = Nothing

        _projectName = Nothing
        _projectUser = System.Environment.UserName
        _projectDate = Now.Date.ToString
        _projectSubject = "Blast Analysis of Mullion"

        _selectedLoadType = LoadType.Triangular
        _selectedPlotType = PlotType.Displacement

    End Sub

    ''' <summary>
    ''' Saves the data on load.
    ''' </summary>
    Public Shared Sub SaveDataOnFileLoad()

        _dataOnLoad.Clear()

        _dataOnLoad.Add("_projectName", _projectName)
        _dataOnLoad.Add("_projectSubject ", _projectSubject)

        _dataOnLoad.Add("_inertia", _inertia)
        _dataOnLoad.Add("_plasticModulus", _plasticModulus)
        _dataOnLoad.Add("_area", _area)

        _dataOnLoad.Add("_span", _span)
        _dataOnLoad.Add("_spacing", _spacing)
        _dataOnLoad.Add("_spantype", _spantype)

        _dataOnLoad.Add("_glassWeight", _glassWeight)
        _dataOnLoad.Add("_material", _material)
        _dataOnLoad.Add("_materialIndex", _materialIndex)

        _dataOnLoad.Add("_pulse", _pulse)
        _dataOnLoad.Add("_rise", _rise)
        _dataOnLoad.Add("_duration", _duration)
        _dataOnLoad.Add("_negativePulse", _negativePulse)
        _dataOnLoad.Add("_negativeDuration", _negativeDuration)

        _dataOnLoad.Add("_sinAmp", _sinAmp)
        _dataOnLoad.Add("_sinFreq", _sinFreq)

        _dataOnLoad.Add("_responseDuration", _responseDuration)
        _dataOnLoad.Add("_responseStepSize", _responseStepSize)

        _dataOnLoad.Add("_epropImageLocation", _epropImageLocation)

        _dataOnLoad.Add("_selectedLoadType", _selectedLoadType)
        _dataOnLoad.Add("_selectedPlotType", _selectedPlotType)

    End Sub


    ''' <summary>
    ''' Loads the eprop file.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadEpropFile() As Integer

        Dim result As Integer = 0
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\" + System.Environment.UserName + "\"
        openFileDialog1.Filter = "Enclos Properties Image (*.eprop.jpg)|*.eprop.jpg|All Files *.*|"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim imagelocation As String = openFileDialog1.FileName

            'Dim fs As New System.IO.FileStream(imagelocation, FileMode.Open, FileAccess.Read, FileShare.Read)

            Dim fileStream As System.IO.Stream = Nothing
            Try
                fileStream = openFileDialog1.OpenFile()
                If (fileStream IsNot Nothing) Then

                    Dim fileXnt As String = Path.GetExtension(imagelocation)
                    If Not fileXnt.ToUpper.Equals(".JPG") And Not fileXnt.ToUpper.Equals(".JPEG") Then
                        result = 1
                        System.Windows.Forms.MessageBox.Show("Invalid Enclos propties file", "Invalid File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Else
                        'Read the metadata
                        Dim myDecoder As JpegBitmapDecoder = New JpegBitmapDecoder(fileStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
                        Dim md As BitmapMetadata = myDecoder.Frames(0).Metadata
                        Dim epropvalues As String = md.GetQuery("/app13/irb/8bimiptc/iptc/{str=Keywords}")

                        If String.IsNullOrEmpty(epropvalues) Then
                            result = 1
                            System.Windows.Forms.MessageBox.Show("Invalid Enclos propties file", "Invalid File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            initializeEpropToForm(GetEpropValues(epropvalues))
                            _epropImage = Image.FromFile(imagelocation)
                            _epropImageLocation = imagelocation
                        End If
                    End If
                End If
            Catch Ex As Exception
                result = 1
                System.Windows.Forms.MessageBox.Show(Ex.ToString, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If (fileStream IsNot Nothing) Then
                    fileStream.Close()
                End If
            End Try
        End If
        Return result
    End Function

    ''' <summary>
    ''' Saves the existing file.
    ''' </summary>
    ''' <param name="FileLoc">The file loc.</param>
    Public Shared Sub SaveExistingFile(ByVal FileLoc As String)
        Try
            SaveFile(FileLoc)
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Saves the new file.
    ''' </summary>
    Public Shared Function SaveNewFile() As Integer
        Dim result As Integer = 0
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.InitialDirectory = "c:\\" + System.Environment.UserName + "\\"
        saveFileDialog1.Filter = "Enclos Mullion Blast(*.ebls)|*.ebls"
        saveFileDialog1.RestoreDirectory = True
        saveFileDialog1.FileName = _projectName

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then

            Try
                SaveFile(saveFileDialog1.FileName)

            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.ToString, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            result = 1
        End If

        Return result

    End Function

    ''' <summary>
    ''' Reads the E blast file.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function LoadFile() As Integer

        Dim result As Integer = 0
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\" + System.Environment.UserName + "\"
        openFileDialog1.Filter = "Enclos Mullion Blast(*.ebls)|*.ebls"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim encryptedFileLocation As String = openFileDialog1.FileName

            Try
                ReadExistingBlastFile(encryptedFileLocation)

            Catch Ex As Exception
                result = 1
                System.Windows.Forms.MessageBox.Show(Ex.ToString, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        Return result
    End Function


    ''' <summary>
    ''' Determines whether this instance has changes.
    ''' </summary>
    ''' <returns>
    ''' <c>true</c> if this instance has changes; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function HasChanges() As Boolean

        Dim changes As Integer = 0

        Dim values As Hashtable = InputData.DataOnLoad

        If values.ContainsKey("_span") Then
            If Not _span = values.Item("_span") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_spacing") Then
            If Not _spacing = values.Item("_spacing") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_spantype") Then
            If Not _spantype = values.Item("_spantype") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_inertia") Then
            If Not _inertia = values.Item("_inertia") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_plasticModulus") Then
            If Not _plasticModulus = values.Item("_plasticModulus") Then
                changes += 1
            End If

        End If
        If values.ContainsKey("_area") Then
            If Not _area = values.Item("_area") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_glassWeight") Then
            If Not _glassWeight = values.Item("_glassWeight") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_material") Then
            If Not _material = values.Item("_material") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_materialIndex") Then
            If Not _materialIndex = values.Item("_materialIndex") Then
                changes += 1
            End If

        End If

        If values.ContainsKey("_pulse") Then
            If Not _pulse = values.Item("_pulse") Then
                changes += 1
            End If

        End If
        If values.ContainsKey("_rise") Then
            If Not _rise = values.Item("_rise") Then
                changes += 1
            End If

        End If
        If values.ContainsKey("_duration") Then
            If Not _duration = values.Item("_duration") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_negativePulse") Then
            If Not _negativePulse = values.Item("_negativePulse") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_negativeDuration") Then
            If Not _negativeDuration = values.Item("_negativeDuration") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_sinAmp") Then
            If Not _sinAmp = values.Item("_sinAmp") Then
                changes += 1
            End If
        End If
        If values.ContainsKey("_sinFreq") Then
            If Not _sinFreq = values.Item("_sinFreq") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_responseDuration") Then
            If Not _responseDuration = values.Item("_responseDuration") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_responseStepSize") Then
            If Not _responseStepSize = values.Item("_responseStepSize") Then
                changes += 1
            End If

        End If

        If values.ContainsKey("_epropImageLocation") Then
            If Not _epropImageLocation = values.Item("_epropImageLocation") Then
                changes += 1
            End If

        End If

        If values.ContainsKey("_projectName") Then
            If Not _projectName = values.Item("_projectName") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_projectUser") Then
            If Not _projectUser = values.Item("_projectUser") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_projectDate") Then
            If Not _projectDate = values.Item("_projectDate") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_projectSubject") Then
            If Not _projectSubject = values.Item("_projectSubject") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_selectedLoadType") Then
            If Not _selectedLoadType = values.Item("_selectedLoadType") Then
                changes += 1
            End If
        End If

        If values.ContainsKey("_selectedPlotType") Then
            If Not _selectedPlotType = values.Item("_selectedPlotType") Then
                changes += 1
            End If
        End If

        If changes > 0 Then
            Return True
        End If

        Return False

    End Function

    ''' <summary>
    ''' Saves the images.
    ''' </summary>
    ''' 
    Public Shared Sub SavePlotImage(ByVal imageName As String)
        Dim image As Bitmap = GetPicturebox(BlastForm.plotPanel)
        image.SetResolution(150, 150)
        image.Save(GetTempFolder() + imageName + ".bmp", ImageFormat.Bmp)
    End Sub

    ''' <summary>
    ''' Saves the load image.
    ''' </summary>
    Public Shared Sub saveLoadImage()
        Dim image As Bitmap = GetPicturebox(BlastForm.plotStressPanel)
        image.SetResolution(150, 150)
        image.Save(GetTempFolder() + "Reactions.bmp")
    End Sub

    ''' <summary>
    ''' Saves the hist image.
    ''' </summary>
    Public Shared Sub SaveHistImage()
        Dim image1 As Bitmap = GetPicturebox(BlastForm.histPanel)
        image1.SetResolution(150, 150)
        image1.Save(GetTempFolder() + "Hist.bmp")
  
    End Sub


    ''' <summary>
    ''' Saves the eprop image for report.
    ''' </summary>
    Public Shared Sub SaveEpropImageForReport()
        Dim s As New Size(100, 100)
        Dim img As New Bitmap(Image.FromFile(InputData.EPropertiesLocation), s)
        'img.SetResolution(100, 100)
        img.Save(GetTempFolder() + "Eprop.bmp")
    End Sub

    ''' <summary>
    ''' Saves the span type image for report.
    ''' </summary>
    Public Shared Sub SaveSpanTypeImageForReport()

        Dim s As New Size(100, 100)

        Dim img As New Bitmap(Image.FromHbitmap(My.Resources.double_span.GetHbitmap), s)
        img.Save(InputData.GetTempFolder + "double_span.bmp")
        img.Dispose()

        img = New Bitmap(Image.FromHbitmap(My.Resources.single_span.GetHbitmap), s)
        img.Save(InputData.GetTempFolder + "single_span.bmp")
        img.Dispose()

    End Sub

    ''' <summary>
    ''' Deletes the temp images.
    ''' </summary>
    Public Shared Sub DeleteTempImages()
        Dim f As FileInfo = Nothing
        Dim D As DirectoryInfo = New DirectoryInfo(GetTempFolder)

        Dim files() As FileInfo = D.GetFiles("*.bmp")

        Try
            For Each f In files
                f.Delete()
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

End Class