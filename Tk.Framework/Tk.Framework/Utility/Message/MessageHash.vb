Imports System.Collections.Generic
Imports System
Imports System.Diagnostics

Namespace Utility.Message

    ''' <summary>
    ''' 一つのメッセージファイルに含まれる MessageSet クラスのシーケンスを定義します。
    ''' このクラスは継承できません。
    ''' </summary>
    <Serializable()> _
    Public NotInheritable Class MessageCache
        Implements ICollection(Of IMessageSet)

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _cache As HashSet(Of IMessageSet)

#Region " Constructers "

        Public Sub New()
            Me._cache = New HashSet(Of IMessageSet)(New MessageSetEqualityComparer())

        End Sub

        Public Sub New( enumerable As IEnumerable(Of IMessageSet))
            Me._cache = New HashSet(Of IMessageSet)(enumerable, New MessageSetEqualityComparer())

        End Sub

#End Region

#Region " Methods "

        Public Function Add( item As MessageSet) As Boolean
            Return Me._cache.Add(item)

        End Function

#End Region

#Region " ICollection(Of MessageSet) "

        Private Sub AddInternal( item As IMessageSet) Implements System.Collections.Generic.ICollection(Of IMessageSet).Add
            Me._cache.Add(item)

        End Sub

        Public Sub Clear() Implements System.Collections.Generic.ICollection(Of IMessageSet).Clear
            Me._cache.Clear()

        End Sub

        Public Function Contains( item As IMessageSet) As Boolean Implements System.Collections.Generic.ICollection(Of IMessageSet).Contains
            Return Me._cache.Contains(item)

        End Function

        Public Sub CopyTo( array() As IMessageSet,  arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of IMessageSet).CopyTo
            Me._cache.CopyTo(array, arrayIndex)

        End Sub

        Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of IMessageSet).Count
            Get
                Return Me._cache.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of IMessageSet).IsReadOnly
            Get
                Return False
            End Get
        End Property

        Public Function Remove( item As IMessageSet) As Boolean Implements System.Collections.Generic.ICollection(Of IMessageSet).Remove
            Return Me._cache.Remove(item)

        End Function

        Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of IMessageSet) Implements System.Collections.Generic.IEnumerable(Of IMessageSet).GetEnumerator
            Return Me._cache.GetEnumerator()

        End Function

        Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.GetEnumerator()

        End Function

#End Region

    End Class

End Namespace