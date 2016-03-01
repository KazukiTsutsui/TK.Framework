Imports TK.Framework.Extensions
Imports System.Collections.Generic
Imports System.Linq

Namespace Utility

    ''' <summary>
    ''' <c>ISnapShot</c> の補助機能を提供します。
    ''' </summary>
    Public NotInheritable Class SnapShot

        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of SnapShot)()

        End Sub

        ''' <summary>
        ''' 変更があった要素が存在するか否かを取得します。
        ''' </summary>
        ''' <returns>True:変更があった。,False:変更がなかった。</returns>
        Public Shared Function ContainsChangedItem( collection As IEnumerable(Of ISnapShot)) As Boolean
            Return collection.FindIndex(Function(x) Not x.Validate()) <> -1

        End Function

        ''' <summary>
        ''' １つのインスタンスに対してスナップショットを実行します。
        ''' </summary>
        ''' <param name="target">スナップショットの対象となっているインスタンス。</param>
        Public Shared Sub ShotOf( collection As IEnumerable(Of ISnapShot),  target As Object)
            Dim snap As ISnapShot = SnapShot.TryGetSnapShot(collection, target)
            If snap IsNot Nothing Then
                snap.Shot()

            End If

        End Sub

        ''' <summary>
        ''' スナップショットの対象から、スナップショットのインスタンスを取得します。
        ''' </summary>
        ''' <param name="target">スナップショットの対象となっているインスタンス。</param>
        ''' <returns>スナップショットのインスタンス。</returns>
        Public Shared Function TryGetSnapShot( collection As IEnumerable(Of ISnapShot),  target As Object) As ISnapShot
            For Each item As ISnapShot In collection
                If item IsNot Nothing AndAlso Object.ReferenceEquals(target, item.GetInstanse()) Then
                    Return item

                End If

            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' 変更があった要素を全て取得します。
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetChangedItems( collection As IEnumerable(Of ISnapShot)) As IEnumerable(Of ISnapShot)
            Dim result As New List(Of ISnapShot)()
            For Each item As ISnapShot In collection
                If Not item.Validate() Then
                    result.Add(item)

                End If

            Next

            Return result.AsReadOnly()

        End Function

        ''' <summary>
        ''' 現在の全ての要素の状態を保存します。
        ''' </summary>
        Public Shared Sub ShotAll( collection As IEnumerable(Of ISnapShot))
            For Each item As ISnapShot In collection
                item.Shot()

            Next

        End Sub


    End Class

End Namespace