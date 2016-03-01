Imports System.Runtime.CompilerServices
Imports System.Linq

Namespace Extensions

    ''' <summary>
    ''' 配列の拡張メソッド群を定義します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module ArrayExtensions

        ''' <summary>
        ''' 要素数が指定した値より大きいか否かを取得します。
        ''' </summary>
        ''' <typeparam name="T">配列の型。</typeparam>
        ''' <param name="target">対象となる配列。</param>
        ''' <param name="value">比較対象となる数値。</param>
        ''' <returns>True:要素数が指定した数値より大きい。,False:要素数が指定した数値以下。</returns>
        <Extension()> _
        Public Function CountGreaterThen(Of T)( target As T(),  value As Integer) As Boolean
            Return target.Count > value

        End Function

        ''' <summary>
        ''' 要素数が指定した値より小さいか否かを取得します。
        ''' </summary>
        ''' <typeparam name="T">配列の型。</typeparam>
        ''' <param name="target">対象となる配列。</param>
        ''' <param name="value">比較対象となる数値。</param>
        ''' <returns>True:要素数が指定した数値より小さい。,False:要素数が指定した数値以上。</returns>
        <Extension()> _
        Public Function CountLessThen(Of T)( target As T(),  value As Integer) As Boolean
            Return target.Count < value

        End Function

    End Module

End Namespace
