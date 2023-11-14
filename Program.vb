Imports System

Module Program

    Public Class Employee
        Public Name As String
        Public Company As String
        Public MonthlySalary As Double
        Public Sub New(name As String, company As String, monthlySalary As Double)
            Me.Name = name
            Me.Company = company
            Me.MonthlySalary = monthlySalary
        End Sub
    End Class

    Sub Main()
        Dim exitProgram As Boolean = False

        Do While Not exitProgram
            Header()
            Dim Obj As New Employee("", "", 0)
            Data(Obj)
            DataOutput(Obj)

            Console.Write("Another Inquiry? (Y/N): ")
            Dim userInput As String = Console.ReadLine().Trim()
            If userInput.Equals("N", StringComparison.OrdinalIgnoreCase) Then
                exitProgram = True
            ElseIf userInput.Equals("Y", StringComparison.OrdinalIgnoreCase) Then
                Console.Clear()
            End If
        Loop
    End Sub

    Sub Header()
        Console.WriteLine(" ___________________________________________________________________________________ ")
        Console.WriteLine("|   Univesity of Cebu | Computer Engineering Department | College of Engineering    |")
        Console.WriteLine("|                          BENEFITS, COVERAGE & CONTRIBUTION                        |")
        Console.WriteLine("|                                   INQUIRY SYSTEM                                  |")
        Console.WriteLine("|                Personal Income Tax, SSS, Pag-ibig, and PhilHealth                 |")
        Console.WriteLine("|___________________________________________________________________________________|")
    End Sub

    Public Sub Data(Obj As Employee)
        Console.Write("Name of Employee: aho ")
        Obj.Name = Console.ReadLine()
        Console.Write("Name of Company : ")
        Obj.Company = Console.ReadLine()
        Console.Write("Monthly Salary  : ")
        Obj.MonthlySalary = Double.Parse(Console.ReadLine())
    End Sub

    Public Sub DataOutput(Obj As Employee)
        Console.WriteLine("Income Tax: " & IncomeTax(Obj.MonthlySalary))
        Console.WriteLine("Pag-Ibig  : " & PagIbig(Obj.MonthlySalary))
        Console.WriteLine("SSS       : " & SSS(Obj.MonthlySalary))
        Console.WriteLine("PhilHealth: " & PhilHealth(Obj.MonthlySalary))
    End Sub

    Public Function IncomeTax(MonthlySalary As Double) As Double
        Dim AnnualSalary As Double = MonthlySalary * 12
        Dim tax As Double
        If AnnualSalary <= 250000 Then
            tax = 0

        ElseIf AnnualSalary > 250000 & AnnualSalary <= 400000 Then
            tax = (0.2 * (AnnualSalary - 250000)) / 12

        ElseIf AnnualSalary > 400000 & AnnualSalary <= 800000 Then
            tax = (30000 + (0.25 * (AnnualSalary - 400000))) / 12

        ElseIf AnnualSalary > 800000 & AnnualSalary <= 2000000 Then
            tax = (130000 + (0.3 * (AnnualSalary - 800000))) / 12

        ElseIf AnnualSalary > 2000000 & AnnualSalary <= 8000000 Then
            tax = (490000 + (0.32 * (AnnualSalary - 2000000))) / 12

        Else
            tax = (2410000 + (0.35 * (AnnualSalary - 8000000))) / 12
        End If
        Return tax.ToString("0.00")
    End Function

    Public Function PagIbig(MonthlySalary As Double) As Double
        Dim Ibig As Double
        If MonthlySalary <= 1500 Then
            Ibig = 0.01 * MonthlySalary
        Else
            Ibig = 0.02 * MonthlySalary
        End If

        Return Ibig.ToString("0.00")
    End Function

    Public Function SSS(MonthlySalary As Double) As Double
        Dim SS As Double = 0
        Dim first As Double = 2250
        Dim last As Double = 2749.99
        Dim max As Double = 19750
        Dim j As Integer = 80

        For i As Integer = 1 To 36
            If MonthlySalary < first Then
                SS = j
                Exit For
            ElseIf MonthlySalary > max Then
                SS = 800
                Exit For
            Else
                j += 20
                first += 500
            End If
        Next
        Return SS.ToString("0.00")
    End Function

    Public Function PhilHealth(MonthlySalary As Double) As Double
        Dim Health As Double = 0
        Dim first As Double = 9000
        Dim last As Double = 9999.99
        Dim max As Double = 35000
        Dim j As Double = 112.5

        For i As Integer = 1 To 27
            If MonthlySalary < first Then
                Health = 100
                Exit For

            ElseIf MonthlySalary > max Then
                Health = 437.5
                Exit For

            ElseIf MonthlySalary >= first & MonthlySalary <= last Then
                Health = j
                Exit For

            Else
                j += 12.5
                first += 1000
                last += 1000
            End If
        Next
        Return Health.ToString("0.00")
    End Function

End Module

