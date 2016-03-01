Imports TK.Framework.Utility.ControlAssist
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TK.Framework.Utility
Imports System.Collections.Generic
Imports System
Imports System.Linq

Namespace Extensions

    ''' <summary>
    ''' ControlsExtensions 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module ControlsExtensions

        ''' <summary>
        ''' 子のコントロールを全て解放します。
        ''' </summary>
        ''' <param name="target"></param>
        <Extension()> _
        Public Sub DisposeAll( target As Control.ControlCollection)
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))

            Static selecter As Func(Of Control, IEnumerable(Of Control)) = Function(x) x.GetAllControlsWithoutParent()
            Static predicate As Func(Of Control, Boolean) = Function(x) ControlHelper.IsAlive(x)

            Dim lst As IEnumerable(Of Control) = target.SelectFrom(selecter).SelectMany(Function(x) x).Where(predicate)
            For Each item As Control In lst
                item.Dispose()

            Next

            For Each item As Control In target
                target.Remove(item)

            Next

        End Sub

        ''' <summary>
        ''' 述語に基づいてフィルタ処理済みの新しいインスタンスのシーケンスを返します。
        ''' </summary>
        ''' <param name="target"></param>
        ''' <param name="predicate"></param>
        ''' <returns></returns>
        <Extension()> _
        Public Function WhereFrom( target As Control.ControlCollection,  predicate As Predicate(Of Control)) As IEnumerable(Of Control)
            Dim result As New List(Of Control)
            For Each item As Control In target
                If predicate(item) Then
                    result.Add(item)

                End If

            Next

            Return result

        End Function

        ''' <summary>
        ''' 各要素を述語に基づいて射影したシーケンスを取得します。
        ''' 評価は実行時に行います。
        ''' </summary>
        ''' <typeparam name="TResult">戻り値の型。</typeparam>
        ''' <param name="target">対象となる ControlCollection のインスタンス。</param>
        ''' <param name="selector">要素を射影する述語。</param>
        ''' <returns>各要素を述語に基づいて射影したシーケンスを返します。</returns>
        <Extension()> _
        Public Function SelectFrom(Of TResult)( target As Control.ControlCollection,  selector As Func(Of Control, TResult)) As IEnumerable(Of TResult)
            Dim result As New List(Of TResult)
            For Each item As Control In target
                result.Add(selector.Invoke(item))

            Next

            Return result

        End Function

        ''' <summary>
        ''' ControlCollection の最初の要素を取り出します。
        ''' ControlCollection に含まれていない場合は、既定の値を返します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <returns>ControlCollection の最初の要素または既定の値を返します。</returns>
        <Extension()> _
        Public Function FirstOrDefault( target As Control.ControlCollection) As Control
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))
            If target Is Nothing OrElse target.Count = 0 Then
                Return ClassService.DefaultAt(Of Control)()

            End If

            Return target.First()

        End Function

        ''' <summary>
        ''' ControlCollection の最後の要素を取り出します。
        ''' ControlCollection に含まれていない場合は、既定の値を返します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <returns>ControlCollection の最後の要素または既定の値を返します。</returns>
        <Extension()> _
        Public Function LastOrDefault( target As Control.ControlCollection) As Control
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))
            If target Is Nothing OrElse target.Count = 0 Then
                Return ClassService.DefaultAt(Of Control)()

            End If

            Return target.Last()

        End Function

        ''' <summary>
        ''' ControlCollection の最初の要素を取り出します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <returns>ControlCollection の最初の要素を返します。</returns>
        ''' <exception cref="InvalidOperationException">ソースシーケンスが空の場合にスローします。</exception>
        <Extension()> _
        Public Function First( target As Control.ControlCollection) As Control
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))
            If target.Count = 0 Then
                Throw New InvalidOperationException("ソースシーケンスが空です。")

            End If

            Return target(0)

        End Function

        ''' <summary>
        ''' ControlCollection の最後の要素を取り出します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <returns>ControlCollection の最後の要素を返します。</returns>
        ''' <exception cref="InvalidOperationException">ソースシーケンスが空の場合にスローします。</exception>
        <Extension()> _
        Public Function Last( target As Control.ControlCollection) As Control
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))
            If target.Count = 0 Then
                Throw New InvalidOperationException("ソースシーケンスが空です。")

            End If

            Return target(target.Count - 1)

        End Function

    End Module

End Namespace
