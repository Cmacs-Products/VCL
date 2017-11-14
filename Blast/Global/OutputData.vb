''' <summary>
''' Class to update the report
''' </summary>
Public Class OutputData

#Region "Private Fields"
    Private Shared _density As Double
    Private Shared _elasticModulus As Double
    Private Shared _yieldStrength As Double
    Private Shared _mass As Double
    Private Shared _dif As Double
    Private Shared _sif As Double
    Private Shared _klme As Double
    Private Shared _klmp As Double
    Private Shared _equivalentMass As Double
    Private Shared _equivalentStiffness As Double
    Private Shared _systemPeriod As Double
    Private Shared _plasticMoment As Double
    Private Shared _ultimateResistance As Double
    Private Shared _yield As Double
    Private Shared _lambaMax As Double
    Private Shared _lamdaMin As Double
    Private Shared _ductility As Double
    Private Shared _rotation As Double
#End Region

#Region "Properties"


    ''' <summary>
    ''' Gets or sets the density.
    ''' </summary>
    ''' <value>The density.</value>
    Public Shared Property Density() As Double
        Get
            Return _density
        End Get
        Set(ByVal value As Double)
            _density = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the elastic modulus.
    ''' </summary>
    ''' <value>The elastic modulus.</value>
    Public Shared Property ElasticModulus() As Double
        Get
            Return _elasticModulus
        End Get
        Set(ByVal value As Double)
            _elasticModulus = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the yield strength.
    ''' </summary>
    ''' <value>The yield strength.</value>
    Public Shared Property YieldStrength() As Double
        Get
            Return _yieldStrength
        End Get
        Set(ByVal value As Double)
            _yieldStrength = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the mass.
    ''' </summary>
    ''' <value>The mass.</value>
    Public Shared Property Mass() As Double
        Get
            Return _mass
        End Get
        Set(ByVal value As Double)
            _mass = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the DIF.
    ''' </summary>
    ''' <value>The DIF.</value>
    Public Shared Property DIF() As Double
        Get
            Return _dif
        End Get
        Set(ByVal value As Double)
            _dif = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the SIF.
    ''' </summary>
    ''' <value>The SIF.</value>
    Public Shared Property SIF() As Double
        Get
            Return _sif
        End Get
        Set(ByVal value As Double)
            _sif = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the KL me.
    ''' </summary>
    ''' <value>The KL me.</value>
    Public Shared Property KLMe() As Double
        Get
            Return _klme
        End Get
        Set(ByVal value As Double)
            _klme = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the KL mp.
    ''' </summary>
    ''' <value>The KL mp.</value>
    Public Shared Property KLMp() As Double
        Get
            Return _klmp
        End Get
        Set(ByVal value As Double)
            _klmp = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the equivalent mass.
    ''' </summary>
    ''' <value>The equivalent mass.</value>
    Public Shared Property EquivalentMass() As Double
        Get
            Return _equivalentMass
        End Get
        Set(ByVal value As Double)
            _equivalentMass = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the equivalent stiffness.
    ''' </summary>
    ''' <value>The equivalent stiffness.</value>
    Public Shared Property EquivalentStiffness() As Double
        Get
            Return _equivalentStiffness
        End Get
        Set(ByVal value As Double)
            _equivalentStiffness = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the system period.
    ''' </summary>
    ''' <value>The system period.</value>
    Public Shared Property SystemPeriod() As Double
        Get
            Return _systemPeriod
        End Get
        Set(ByVal value As Double)
            _systemPeriod = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the plastic moment.
    ''' </summary>
    ''' <value>The plastic moment.</value>
    Public Shared Property PlasticMoment() As Double
        Get
            Return _plasticMoment
        End Get
        Set(ByVal value As Double)
            _plasticMoment = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ultimate resistance.
    ''' </summary>
    ''' <value>The ultimate resistance.</value>
    Public Shared Property UltimateResistance() As Double
        Get
            Return _ultimateResistance
        End Get
        Set(ByVal value As Double)
            _ultimateResistance = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the yield displacement.
    ''' </summary>
    ''' <value>The yield displacement.</value>
    Public Shared Property YieldDisplacement() As Double
        Get
            Return _yield
        End Get
        Set(ByVal value As Double)
            _yield = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the lamda max.
    ''' </summary>
    ''' <value>The lamda max.</value>
    Public Shared Property LamdaMax() As Double
        Get
            Return _lambaMax
        End Get
        Set(ByVal value As Double)
            _lambaMax = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the lamda min.
    ''' </summary>
    ''' <value>The lamda min.</value>
    Public Shared Property LamdaMin() As Double
        Get
            Return _lamdaMin
        End Get
        Set(ByVal value As Double)
            _lamdaMin = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ductility factor.
    ''' </summary>
    ''' <value>The ductility factor.</value>
    Public Shared Property DuctilityFactor() As Double
        Get
            Return _ductility
        End Get
        Set(ByVal value As Double)
            _ductility = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the support rotation.
    ''' </summary>
    ''' <value>The support rotation.</value>
    Public Shared Property SupportRotation() As Double
        Get
            Return _rotation
        End Get
        Set(ByVal value As Double)
            _rotation = value
        End Set
    End Property

#End Region

End Class
