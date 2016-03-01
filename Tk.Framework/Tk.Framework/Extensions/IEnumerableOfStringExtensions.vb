Imports System.Runtime.CompilerServices
Imports TK.Framework.Utility
Imports System.Collections.Generic
Imports System
Imports System.Linq
Imports System.Text

Namespace Extensions

    ''' <summary>
    ''' IEnumerable(Of String) 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Module IEnumerableOfStringExtensions

        ''' <summary>
        ''' シーケンスの文字列を結合した値を取得します。
        ''' </summary>
        ''' <param name="target">IEnumerable(Of String) 型のインスタンス。</param>
        ''' <param name="splitter">区切り文字。</param>
        ''' <returns>シーケンスの文字列を結合した値を返します。</returns>
        <Extension()> _
        Public Function Join( target As IEnumerable(Of String), Optional  splitter As String = ",") As String
            Dim sb As StringBuilder = StringBuilderCache.Acquire()
            For Each s As String In target
                sb.Append(s)
                sb.Append(splitter)

            Next

            sb.Length = sb.Length - splitter.Length '最後のsplitterを削除。

            Return StringBuilderCache.GetStringAndRelease(sb)

        End Function

        ''' <summary>
        ''' 格納文字列の合計容量を取得します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <returns>格納文字列の合計容量を System.Integet で返します。</returns>
        ''' <exception cref=" OverflowException"> 2147483647 を超える場合は、OverflowException がスローされます。</exception>
        <Extension()> _
        Public Function GetValueCapacity( target As IEnumerable(Of String)) As Integer
            Dim result As Integer
            For i As Integer = 0 To target.Count - 1
                result += target(i).Length

            Next

            Return result

            '低速なのでコメントアウト。
            'Return target.Sum(Function(x As String) x.Length)

        End Function

    End Module

End Namespace