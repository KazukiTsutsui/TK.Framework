Imports TK.Framework.Extensions
Imports System.Runtime.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Collections

Namespace Utility

    ''' <summary>
    ''' 列挙値に関連付くカスタム属性インスタンスのキャッシュ機能を提供します。
    ''' インスタンス取得から明示的な解放を実行するまで、同一のインスタンスを保持します。
    ''' </summary>
    Public NotInheritable Class EnumCustomAttributeCache

#Region " Properties "

        ''' <summary>
        ''' キャッシュ。
        ''' </summary>
        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared ReadOnly AttributeCache As Dictionary(Of [Enum], AttrHash)

#End Region

#Region " Constructers "

        ''' <summary>
        ''' EnumCustomAttributeCache クラスの新しいインスタンスを初期化します。
        ''' このクラスはインスタンス化できません。
        ''' </summary>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of EnumCustomAttributeCache)()

        End Sub

        Shared Sub New()
            AttributeCache = New Dictionary(Of [Enum], AttrHash)

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' キャッシュの同期オブジェクトを取得します。
        ''' </summary>
        ''' <returns>キャッシュの排他制御オブジェクト。</returns>
        Private Shared Function GetSyncRoot() As Object
            Return DirectCast(AttributeCache, ICollection).SyncRoot

        End Function

        ''' <summary>
        ''' カスタム属性を取得します。
        ''' 取得したカスタム属性のインスタンスは、解放を実行するまで同一のインスタンスが保持されます。
        ''' </summary>
        ''' <typeparam name="T">カスタム属性の型。</typeparam>
        ''' <param name="source">カスタム属性と関連付く列挙値。</param>
        ''' <returns>カスタム属性を返します。</returns>
        Public Shared Function Acquire(Of T As Attribute)( source As [Enum]) As T
            SyncLock EnumCustomAttributeCache.GetSyncRoot()
                Dim element As AttrHash = EnumCustomAttributeCache.GetElement(source)
                Dim attrType As Type = GetType(T)
                If Not element.ContainsKey(attrType) Then
                    Dim attr As Attribute = source.GetCustomeAttribute(Of T)()
                    element.Add(attrType, attr)

                End If

                Return TryCast(element(attrType), T)

            End SyncLock

        End Function

        ''' <summary>
        ''' 全てのカスタム属性を取得します。
        ''' 取得したカスタム属性のインスタンスは、解放時まで保持されます。
        ''' </summary>
        ''' <param name="source">カスタム属性と関連付く列挙値。</param>
        ''' <returns>関連付く全てのカスタム属性を返します。</returns>
        Public Shared Function AcquireAll( source As [Enum]) As IEnumerable(Of Attribute)
            SyncLock EnumCustomAttributeCache.GetSyncRoot()
                Dim element As AttrHash = EnumCustomAttributeCache.GetElement(source)
                Dim attrs As Attribute() = source.GetCustomeAttributes()
                For Each attrOne As Attribute In attrs
                    Dim attrType As Type = attrOne.GetType()
                    If Not element.ContainsKey(attrType) Then
                        element.Add(attrType, attrOne)

                    End If

                Next

                Return element.Values

            End SyncLock

        End Function

        ''' <summary>
        ''' 列挙値と紐付く、既存または新しい AttrHash のインスタンスを取得します。
        ''' 排他制御はかけないため、呼び出し側でロックする必要があります。
        ''' </summary>
        ''' <param name="source">対象の列挙値。</param>
        ''' <returns>列挙値と紐付く、既存または新しい AttrHash のインスタンス。</returns>
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Private Shared Function GetElement( source As [Enum]) As AttrHash
            If AttributeCache.ContainsKey(source) Then
                AttributeCache.Add(source, New AttrHash())

            End If

            Return AttributeCache(source)

        End Function

        ''' <summary>
        ''' 列挙値と紐付く属性を削除します。
        ''' </summary>
        ''' <typeparam name="T">属性の型。</typeparam>
        ''' <param name="source">列挙値。</param>
        ''' <returns>True:削除成功。,False:削除失敗。</returns>
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Public Shared Function Remove(Of T As Attribute)( source As [Enum]) As Boolean
            If Not AttributeCache.ContainsKey(source) Then
                Return False

            End If

            SyncLock EnumCustomAttributeCache.GetSyncRoot()
                Dim element As AttrHash = AttributeCache(source)
                Dim attrType As Type = GetType(T)
                If Not element.ContainsKey(attrType) Then
                    Return False

                End If

                Return element.Remove(attrType)

            End SyncLock

        End Function

        ''' <summary>
        ''' 取得した属性のキャッシュを全てクリアします。
        ''' 属性を再度インスタンス化するコストを考慮して使用してください。
        ''' </summary>
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Public Shared Sub Release()
            SyncLock EnumCustomAttributeCache.GetSyncRoot()
                For Each attr As KeyValuePair(Of [Enum], AttrHash) In AttributeCache
                    attr.Value.Clear()

                Next

                AttributeCache.Clear()

            End SyncLock

        End Sub

        ''' <summary>
        ''' 型指定が面倒なので。
        ''' </summary>
        Private NotInheritable Class AttrHash
            Inherits Dictionary(Of Type, Attribute)

        End Class

#End Region

    End Class

End Namespace