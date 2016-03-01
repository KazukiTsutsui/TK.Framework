Imports System.Runtime.CompilerServices

Namespace Extensions

    ''' <summary>
    ''' Integer 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module IntegerExtensions

        ''' <summary>
        ''' 正負を逆転させた System.Integer のインスタンスを取得します。
        ''' </summary>
        ''' <param name="target"></param>
        ''' <returns></returns>
        <Extension()> _
        Public Function Reverse( target As Integer) As Integer
            Return target * -1

        End Function

        ''' <summary>
        ''' インスタンスに 1 の整数を加算します。
        ''' </summary>
        ''' <param name="target"></param>
        <Extension()> _
        Public Sub Increment(ByRef target As Integer)
            target.Increment(1)

        End Sub

        ''' <summary>
        ''' インスタンスから 1 の整数を減算します。
        ''' </summary>
        ''' <param name="target"></param>
        <Extension()> _
        Public Sub Decrement(ByRef target As Integer)
            target.Decrement(1)

        End Sub

        ''' <summary>
        ''' インスタンスに指定した数値分を加算します。
        ''' </summary>
        ''' <param name="target"></param>
        ''' <param name="value"></param>
        <Extension()> _
        Public Sub Increment(ByRef target As Integer,  value As Integer)
            target += value

        End Sub

        ''' <summary>
        ''' インスタンスに指定した数値分を減算します。
        ''' </summary>
        ''' <param name="target"></param>
        ''' <param name="value"></param>
        <Extension()> _
        Public Sub Decrement(ByRef target As Integer,  value As Integer)
            target -= value

        End Sub


    End Module

End Namespace
