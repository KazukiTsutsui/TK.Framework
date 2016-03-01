Imports System.Runtime.CompilerServices

Namespace Extensions

    ''' <summary>
    ''' Integer 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module LongExtensions

        ''' <summary>
        ''' インスタンスに 1 の整数を加算します。
        ''' </summary>
        ''' <param name="target"></param>
        <Extension()> _
        Public Sub Increment(ByRef target As Long)
            target.Increment(1)

        End Sub

        ''' <summary>
        ''' インスタンスから 1 の整数を減算します。
        ''' </summary>
        ''' <param name="target"></param>
        <Extension()> _
        Public Sub Decrement(ByRef target As Long)
            target.Decrement(1)

        End Sub

        ''' <summary>
        ''' インスタンスに指定した数値分を加算します。
        ''' </summary>
        ''' <param name="target"></param>
        ''' <param name="value"></param>
        <Extension()> _
        Public Sub Increment(ByRef target As Long,  value As Long)
            target += value

        End Sub

        ''' <summary>
        ''' インスタンスに指定した数値分を減算します。
        ''' </summary>
        ''' <param name="target"></param>
        ''' <param name="value"></param>
        <Extension()> _
        Public Sub Decrement(ByRef target As Long,  value As Long)
            target -= value

        End Sub


    End Module

End Namespace
