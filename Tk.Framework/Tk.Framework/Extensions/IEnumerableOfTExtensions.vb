Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Extensions

    ''' <summary>
    ''' IEnumerable 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module IEnumerableOfTExtensions

        ''' <summary>
        ''' 述語と一致する全ての要素のインデックスを取得します。
        ''' </summary>
        ''' <typeparam name="T">型。</typeparam>
        ''' <param name="target">対象となるインスタンス。</param>
        ''' <param name="match">検索条件となる述語。</param>
        ''' <returns>述語と一致する全て要素のインデックスを返します。</returns>
        <Extension()> _
        Public Function FindIndexies(Of T)( target As IEnumerable(Of T),  match As Predicate(Of T)) As IEnumerable(Of Integer)
            Return target.FindIndexies(0, match)

        End Function

        <Extension()> _
        Public Function FindIndexies(Of T)( target As IEnumerable(Of T),  startIndex As Integer,  match As Predicate(Of T)) As IEnumerable(Of Integer)
            Return target.FindIndexies(startIndex, target.Count - 1, match)

        End Function

        <Extension()> _
        Public Function FindIndexies(Of T)( target As IEnumerable(Of T),  startIndex As Integer,  count As Integer,  match As Predicate(Of T)) As IEnumerable(Of Integer)
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))

            Dim result As New List(Of Integer)
            For i As Integer = startIndex To count
                If match(target(i)) Then
                    result.Add(i)

                End If

            Next

            Return result

        End Function

        ''' <summary>
        ''' 現在のシーケンスの汎用的な読み取り専用のコレクションを取得します。
        ''' </summary>
        ''' <typeparam name="T">要素の型。</typeparam>
        ''' <param name="target">対象のシーケンス。</param>
        ''' <returns>新しい汎用的な読み取り専用のコレクションを返します。。</returns>
        <Extension()> _
        Public Function AsReadOnly(Of T)( target As IEnumerable(Of T)) As ReadOnlyCollection(Of T)
            Return New ReadOnlyCollection(Of T)(target.ToList())

        End Function

        ''' <summary>
        ''' 指定された述語と一致する要素のインデックスを取得します。
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="target"></param>
        ''' <param name="match"></param>
        ''' <returns></returns>
        <Extension()> _
        Public Function FindIndex(Of T)( target As IEnumerable(Of T),  match As Predicate(Of T)) As Integer
            Return Array.FindIndex(target.ToArray(), match)

        End Function

    End Module

End Namespace

