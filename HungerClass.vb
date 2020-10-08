'*************** Group Details ******************t

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
<Serializable()> Public Class Hunger
    Inherits Organization
    Implements IDonate

    Private _Fat As Double
    Private _Deaths As Integer = 0
    Private _Food As String = ""
    Private _Calories As Integer = 0
    Private _Caloriesfromfat As Integer = 0

    '******************************************************************************************************** Constructor **************************************************************************************************
    Public Sub New(_NameofIndiv As String, numIndiv As Integer)
        MyBase.New(_NameofIndiv, numIndiv)
    End Sub
    Public Sub New(Orgname As String)
        MyBase.New(Orgname)
    End Sub
    '************************************************************************************************ Property Methods *************************************************************************************************
    Public Property Food As String
        Get
            Return _Food
        End Get
        Set(value As String)
            _Food = value
        End Set
    End Property

    Public Property Calories() As Integer
        Set(value As Integer)
            _Calories = value
        End Set
        Get
            Return _Calories
        End Get
    End Property

    Public Property Caloriesfromfat() As Integer
        Set(value As Integer)
            _Caloriesfromfat = value
        End Set
        Get
            Return _Caloriesfromfat
        End Get
    End Property
    Public Property Fat() As Double
        Set(value As Double)
            _Fat = value
        End Set
        Get
            Return _Fat
        End Get
    End Property

    Public Property Deaths As Integer
        Get
            Return _Deaths
        End Get
        Set(value As Integer)
            If value < 0 Then
                _Deaths = 0
            Else
                _Deaths = value
            End If
        End Set
    End Property
    '************************************************************************************************ Methods *************************************************************************************************
    Public Overrides Function CalcTot() As Double
        Return MyBase.CalcTot()
    End Function

    Public Function CalcFat() As Double   'calculating the amount of fat in the food
        _Fat = _Caloriesfromfat / _Calories
        Return _Fat
    End Function

    Public Overrides Function Display() As String   'add on
        Return MyBase.Display()
    End Function

    Public Overrides Function Display2() As String   'optional at the moment
        Return MyBase.Display2() & Environment.NewLine & "Amount of fat in the calories you contributed towards fighting hunger is: " & Format(CalcFat(), "0.00") & " units" & Environment.NewLine
    End Function

    Public Overrides Function levels() As Integer
        If _Deaths < (Population * 5 / 100) Then
            Level = 0
        Else
            Level = 1
        End If
        Return level
    End Function
End Class