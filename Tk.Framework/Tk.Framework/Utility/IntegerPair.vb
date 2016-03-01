
#Region " Impoerts Drivers "

Imports System
Imports System.Diagnostics
Imports TK.Framework.Extensions

#End Region

Namespace Utility

    ''' <summary>
    ''' System.Integer の幅を表します。
    ''' </summary>
    Public NotInheritable Class IntegerPair

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _start As Integer
        ''' <summary>
        ''' 開始数値。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property [Start]() As Integer
            Get
                Return Me._start
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _end As Integer
        ''' <summary>
        ''' 終端数値。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property [End]() As Integer
            Get
                Return Me._end
            End Get
        End Property

#End Region

        Public Sub New( startIndex As Integer,  endIndex As Integer)
            ThrowHelper.IfMatchArgumentThenThrow(IntegerPair.Validate(startIndex, endIndex), NameOf(startIndex) & NameOf(endIndex))
            Me._start = startIndex
            Me._end = endIndex

        End Sub

        ''' <summary>
        ''' 幅の間隔を返します。
        ''' </summary>
        ''' <returns></returns>
        Public Function Abs() As Decimal
            If Me._start < 0 Then
                If Me._end < 0 Then
                    Return Me._start + Me._end

                End If

                Return Me._end + Me._start.Reverse()

            End If

            Return Me._end - Me._start

        End Function

        Public Shared Function Validate( startIndex As Integer,  endIndex As Integer) As Boolean
            Return startIndex <> -1 AndAlso endIndex <> -1 AndAlso startIndex < endIndex

        End Function

        Public Shared Function Contains( startIndex As Integer,  endIndex As Integer,  value As Integer) As Boolean
            Return startIndex <= value AndAlso endIndex >= value

        End Function

    End Class

End Namespace
