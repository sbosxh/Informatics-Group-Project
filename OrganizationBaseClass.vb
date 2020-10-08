'*************** Group Details ******************

'1. M Malim 
' Student Number: 220087951
'
'2. JL Mabaso 
' Student Number: 220003048
'
'3. ME Segoe 
' Student Number: 220034440
'
'4. T Kgatla 
' Student Number: 220012348
Option Strict On
Option Explicit On
Option Infer Off
<Serializable()> Public MustInherit Class Organization

    Implements IDonate

    '********************* Attributes **************************
    Private Shared _NextIndiv As Integer
    Private _OrgName As String
    Private _Level As Integer
    Private _NameofIndiv As String = ""
    Private _Amount() As Double
    Protected _FinancialGoal As Double = 0
    Private _Population As Integer = 0
    Private _Country As String = ""

    '******************************************************************************************************** Constructor **************************************************************************************************
    Public Sub New(_NameofIndiv As String, numIndiv As Integer)
        Me._NameofIndiv = _NameofIndiv
        ReDim _Amount(numIndiv)
    End Sub
    Public Sub New(orgname As String)
        _OrgName = orgname
    End Sub

    '************************************************************************************************ Property Methods *************************************************************************************************
    Public Property FinancialGoal As Double
        Get
            Return _FinancialGoal
        End Get
        Set(value As Double)
            _FinancialGoal = value
        End Set
    End Property
    Public Property Level As Integer
        Get
            Return _Level
        End Get
        Set(value As Integer)
            If value < 0 Then
                _Level = 0
            Else
                _Level = value
            End If
        End Set
    End Property

    Public Property Population() As Integer
        Set(value As Integer)
            _Population = value
        End Set
        Get
            Return _Population
        End Get
    End Property
    Public Property OrgName() As String
        Set(value As String)
            _OrgName = value
        End Set
        Get
            Return _OrgName
        End Get
    End Property
    Public Property Country() As String
        Set(value As String)
            _Country = value
        End Set
        Get
            Return _Country
        End Get
    End Property
    Public Property Amount(index As Integer) As Double
        Get
            Return _Amount(index)
        End Get
        Set(value As Double)
            _Amount(index) = value
        End Set
    End Property

    '************************************************************************************************ Methods *************************************************************************************************
    Private Function NextC() As Integer   'utility method for used for shared
        _NextIndiv += 1
        Return _NextIndiv
    End Function

    Public Overridable Function Display() As String    'For organization
        Return "Organization name: " & OrgName & Environment.NewLine & "Country Name: " _
            & Country & Environment.NewLine _
            & "Population " _
            & Population & Environment.NewLine & " Financial goal: " & GoalReached() & Environment.NewLine
    End Function

    Public Overridable Function Display2() As String  ''For Client
        Dim d As Double
        For t As Integer = 1 To _Amount.Length - 1
            d = _Amount(t)
        Next t
        Return "Client: " & NextC() _
           & Environment.NewLine & "Client name: " _
           & _NameofIndiv & Environment.NewLine & "Amount: " & d & Environment.NewLine & "Total: " & GoalReached()
    End Function

    Public MustOverride Function Levels() As Integer    'unknown calculation yet, hence mustoverride

    Public Function OrganizationAcceptance() As String
        Dim Alert As String
        If Levels() <= 0 Then
            Alert = "Your application has been rejected"
        Else
            Alert = "Your application has been accepted"
        End If
        Return Alert
    End Function

    Public Function GoalReached() As String Implements IDonate.GoalReached   'use of interface
        Dim Answer As String
        'Calculating the total
        Dim Total As Double = 0
        For a As Integer = 1 To _Amount.Length - 1
            Total += _Amount(a)
        Next a

        For t As Integer = 1 To _Amount.Length - 1
            If _FinancialGoal <= Total Then
                Answer = "Congratulations, the financial goal has been reached."
            Else
                Answer = "Sorry, the financial goal was not attained."
            End If
        Next t
        Return Answer
    End Function
End Class