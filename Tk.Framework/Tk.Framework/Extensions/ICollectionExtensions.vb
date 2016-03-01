Imports System.Runtime.CompilerServices
Imports System.Collections.Generic
Imports System.Collections

Namespace Extensions

    ''' <summary>
    ''' ICollection 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module ICollectionExtensions

        ''' <summary>
        ''' コレクションの要素数が対象の値より小さいか否かを取得します。
        ''' </summary>
        ''' <param name="target">要素数を比較するコレクション。</param>
        ''' <param name="value">比較する値。</param>
        ''' <returns>True:要素数より小さい。,False:要素数以上。</returns>
        <Extension()> _
        Public Function CountGreaterThen( target As ICollection,  value As Integer) As Boolean
            Return target.Count > value

        End Function

        ''' <summary>
        ''' コレクションの要素数が対象の値より大きいか否かを取得します。
        ''' </summary>
        ''' <param name="target">要素数を比較するコレクション。</param>
        ''' <param name="value">比較する値。</param>
        ''' <returns>True:要素数より大きい。,False:要素数以下。</returns>
        <Extension()> _
        Public Function CountLessThen( target As ICollection,  value As Integer) As Boolean
            Return target.Count < value

        End Function

        ''' <summary>
        ''' コレクションの要素数が対象の値より小さいか否かを取得します。
        ''' </summary>
        ''' <param name="target">要素数を比較するコレクション。</param>
        ''' <param name="value">比較する値。</param>
        ''' <returns>True:要素数より小さい。,False:要素数以上。</returns>
        <Extension()> _
        Public Function CountGreaterThen(Of T)( target As ICollection(Of T),  value As Integer) As Boolean
            Return target.Count > value

        End Function

        ''' <summary>
        ''' コレクションの要素数が対象の値より大きいか否かを取得します。
        ''' </summary>
        ''' <param name="target">要素数を比較するコレクション。</param>
        ''' <param name="value">比較する値。</param>
        ''' <returns>True:要素数より大きい。,False:要素数以下。</returns>
        <Extension()> _
        Public Function CountLessThen(Of T)( target As ICollection(Of T),  value As Integer) As Boolean
            Return target.Count < value

        End Function

    End Module

End Namespace
