Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports System.Drawing

#End Region

Namespace Components

    Partial NotInheritable Class CBLDataGridView

        Private Structure RangeResult

            Public ReadOnly Row As Integer
            Public ReadOnly Col As Integer
            Public ReadOnly Rectangle As Rectangle

            Public Shared ReadOnly Empty As RangeResult

            Public Sub New( row As Integer,  col As Integer,  r As Rectangle)
                Me.Row = row
                Me.Col = col
                Me.Rectangle = r

            End Sub

        End Structure

    End Class

End Namespace
