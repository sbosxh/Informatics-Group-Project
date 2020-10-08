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
Option Infer Off
Option Explicit On
<Serializable()> Public Class Poverty
    Inherits Organization
    Implements IDonate
    Private _Unemployed As Integer = 0

    '******************************************************************************************************** Constructor **************************************************************************************************
    Public Sub New(_NameofIndiv As String, numIndiv As Integer)
        MyBase.New(_NameofIndiv, numIndiv)
    End Sub
    Public Sub New(orgname As String)
        MyBase.New(orgname)
    End Sub
    '************************************************************************************************ Property Methods *************************************************************************************************
    Public Property Unemployed As Integer
        Get
            Return _Unemployed
        End Get
        Set(value As Integer)
            _Unemployed = value
        End Set
    End Property
    '************************************************************************************************ Methods *************************************************************************************************
    Public Overrides Function Levels() As Integer
        If _Unemployed < (Population * 15 / 100) Then
            Level = 0
        Else
            Level = 1
        End If
        Return Level
    End Function

    Public Overrides Function CalcTot() As Double
        Return MyBase.CalcTot()
    End Function

    Public Overrides Function Display() As String  'add on
        Return MyBase.Display()
    End Function
    Public Overrides Function Display2() As String  'add on
        Return MyBase.Display2()
    End Function
End Class