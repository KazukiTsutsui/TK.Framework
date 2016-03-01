Imports System.Text
Imports TK.Framework.Extensions
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility

    ''' <summary>
    ''' 文字の開始文字と終端文字がペアとなっている単純な形式を表します。
    ''' </summary>
    <DebuggerDisplay("{ToString()}")> _
    Public NotInheritable Class CharPair
        Implements IEquatable(Of CharPair)

#Region " Fields "

        Public Shared ReadOnly EscapeCode As New CharPair("{"c, "}"c)

#End Region

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _start As Char
        ''' <summary>
        ''' 開始文字。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property [Start]() As Char
            Get
                Return Me._start
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _end As Char
        ''' <summary>
        ''' 終端文字。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property [End]() As Char
            Get
                Return Me._end
            End Get
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' StringPair クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="start">開始文字。</param>
        ''' <param name="end">終端文字。</param>
        Public Sub New( start As Char,  [end] As Char)
            Me._start = start
            Me._end = [end]

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 指定した文字列の最初と最後が、現在のインスタンスのフォーマットと一致するか否かを取得します。
        ''' </summary>
        ''' <param name="value">検査する文字列。</param>
        ''' <returns>True:一致する。,False:一致しない。</returns>
        Public Function IsPair( value As String) As Boolean
            Return Me.IsPair(value, StringComparison.CurrentCulture)

        End Function

        ''' <summary>
        ''' 指定した文字列の最初と最後が、現在のインスタンスのフォーマットと一致するか否かを取得します。
        ''' </summary>
        ''' <param name="value">検査する文字列。</param>
        ''' <param name="comparison">比較演算子。</param>
        ''' <returns>True:一致する。,False:一致しない。</returns>
        Public Function IsPair( value As String,  comparison As StringComparison) As Boolean
            Return value.StartsWith(Me._start, comparison) AndAlso value.EndsWith(Me._end, comparison)

        End Function

        ''' <summary>
        ''' 指定した文字列に、現在のインスタンスのフォーマットが含まれるか否かを取得します。
        ''' </summary>
        ''' <param name="value">検査する文字列。</param>
        ''' <returns>True:含む。,False:含まない。</returns>
        Public Function ContainsPair( value As String) As Boolean
            Return Me.ContainsPair(value, StringComparison.CurrentCulture)

        End Function

        ''' <summary>
        ''' 指定した文字列に、現在のインスタンスのフォーマットが含まれるか否かを取得します。
        ''' </summary>
        ''' <param name="value">検査する文字列。</param>
        ''' <param name="comparison">比較演算子。</param>
        ''' <returns>True:含む。,False:含まない。</returns>
        Public Function ContainsPair( value As String,  comparison As StringComparison) As Boolean
            Dim count As Integer = value.Count
            Dim startIndex As Integer = value.IndexOf(Me._start, 0, count, comparison)
            Dim endIndex As Integer = value.IndexOf(Me._end, 0, count, comparison)
            Return IntegerPair.Validate(startIndex, endIndex)

        End Function

        ''' <summary>
        ''' 文字列の開始文字と終端文字のペアを含む書式内の文字列を返します。
        ''' ペアが含まれていない場合、空文字を返します。
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        Public Function Extraction( value As String) As String
            Return Me.Extraction(value, StringComparison.CurrentCulture)

        End Function

        Public Function Extraction( value As String,  comparison As StringComparison) As String
            Return String.Concat(Me.Start, Me.ExtractionCore(value, comparison), Me.End)

        End Function

        Public Function ExtractionWithoutPair( value As String) As String
            Return Me.ExtractionWithoutPair(value, StringComparison.CurrentCulture)

        End Function

        Public Function ExtractionWithoutPair( value As String,  comparison As StringComparison) As String
            Dim result As String = Me.ExtractionCore(value, comparison)
            Return result

        End Function

        Private Function ExtractionCore( value As String,  comparison As StringComparison) As String
            Dim stIndex As Integer = value.IndexOf(Me._start, 0, value.Count, comparison)
            '開始文字列がなければ抜ける。
            If stIndex = -1I Then Return String.Empty

            Dim arry As Char() = value.ToCharArray()
            Dim startCounter As Integer = 1 '開始文字のカウンタ。

            stIndex.Increment() '一つ進める。
            For i As Integer = stIndex To arry.Count - 1
                Select Case arry(i)
                    Case Me._start
                        startCounter.Increment()

                    Case Me._end
                        If startCounter = 1I Then
                            Return value.Substring(stIndex, i - stIndex)

                        End If

                        startCounter.Decrement()

                End Select

            Next

            Return String.Empty

        End Function

        Public Overrides Function Equals( obj As Object) As Boolean
            Return Me.Equals(DirectCast(obj, CharPair))

        End Function

        Public Overloads Function Equals( other As CharPair) As Boolean Implements System.IEquatable(Of CharPair).Equals
            Return String.Compare(Me.Start, other.Start, StringComparison.CurrentCulture) = 0 AndAlso String.Compare(Me.End, other.End, StringComparison.CurrentCulture) = 0

        End Function

        Public Overrides Function ToString() As String
            Return New String(New Char() {Me.Start, Me.End})

        End Function

#End Region

    End Class

End Namespace