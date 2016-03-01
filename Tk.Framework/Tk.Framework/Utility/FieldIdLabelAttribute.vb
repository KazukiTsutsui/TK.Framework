Imports System.Diagnostics
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Utility

    ''' <summary>
    ''' フィールドの名前とそのペアになる ID を定義します。
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Field)> _
    <DebuggerDisplay("Name = {Name}, ID = {Id}")> _
    Public NotInheritable Class FieldIdLabelAttribute
        Inherits Attribute

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
         Private _name As String
        ''' <summary>
        ''' 名前を取得します。
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Name() As String
            Get
                Return Me._name
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _id As String
        ''' <summary>
        ''' ID を取得します。
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Id() As String
            Get
                Return Me._id
            End Get
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' FieldIdLabelAttribute クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="name">名前。</param>
        ''' <param name="id"> ID 。</param>
        Public Sub New( name As String,  id As String)
            Me._name = name
            Me._id = id

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 名前と ID の連結文字列を取得します。
        ''' </summary>
        ''' <returns>名前と ID をコンマ区切りで連結した System.String 。</returns>
        Public Overrides Function ToString() As String
            Return Me.ToString(",")

        End Function

        ''' <summary>
        ''' 名前と ID を指定文字列で連結文字列を取得します。
        ''' </summary>
        ''' <returns>名前と ID を指定された区切り文字で連結した System.String 。</returns>
        Public Overloads Function ToString( separator As String) As String
            Return String.Concat(Me.Name, separator, Me.Id)

        End Function

        ''' <summary>
        ''' 列挙値に割り振られた ID を大小区別して比較し、関連付けられた FieldIdLabelAttribute のインスタンスを取得します。
        ''' </summary>
        ''' <typeparam name="TEnum">列挙値の型。</typeparam>
        ''' <param name="id"> ID 。</param>
        ''' <returns>関連付けられた FieldIdLabelAttribute のインスタンスを返します。</returns>
        Public Shared Function GetInstanseFromId(Of TEnum)( id As String) As FieldIdLabelAttribute
            Return FieldIdLabelAttribute.GetInstanseFromId(Of TEnum)(id, StringComparer.CurrentCulture)

        End Function

        ''' <summary>
        ''' 列挙値に割り振られた ID から、関連付けられた最初に見つかった FieldIdLabelAttribute のインスタンスを取得します。
        ''' </summary>
        ''' <typeparam name="TEnum">列挙値の型。</typeparam>
        ''' <param name="id"> ID 。</param>
        ''' <param name="comparer"> StringComparer から派生した比較演算子。</param>
        ''' <returns>関連付けられた FieldIdLabelAttribute のインスタンスを返します。</returns>
        Public Shared Function GetInstanseFromId(Of TEnum)( id As String,  comparer As StringComparer) As FieldIdLabelAttribute
            Dim arry As IEnumerable(Of [Enum]) = FieldIdLabelAttribute.GetEnumIterator(GetType(TEnum))

            For Each item As [Enum] In arry
                Dim instanse As FieldIdLabelAttribute = EnumCustomAttributeCache.Acquire(Of FieldIdLabelAttribute)(item)
                If instanse IsNot Nothing AndAlso comparer.Compare(instanse.Id, id) = 0 Then
                    Return instanse

                End If

            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' 列挙値に割り振られた ID を大小区別して比較し、関連付けられた列挙値 TEnum のインスタンスを取得します。
        ''' </summary>
        ''' <typeparam name="TEnum">列挙値の型。</typeparam>
        ''' <param name="id"> ID 。</param>
        ''' <returns>関連付けられた列挙値 TEnum のインスタンスを返します。</returns>
        Public Shared Function GetEnumFromId(Of TEnum)( id As String) As TEnum
            Return FieldIdLabelAttribute.GetEnumFromId(Of TEnum)(id, StringComparer.CurrentCulture)

        End Function

        ''' <summary>
        ''' 列挙値に割り振られた ID から、関連付けられた列挙値 TEnum のインスタンスを取得します。
        ''' </summary>
        ''' <typeparam name="TEnum">列挙値の型。</typeparam>
        ''' <param name="id"> ID 。</param>
        ''' <param name="comparer"> StringComparer から派生した比較演算子。</param>
        ''' <returns>関連付けられた列挙値 TEnum のインスタンスを返します。</returns>
        Public Shared Function GetEnumFromId(Of TEnum)( id As String,  comparer As StringComparer) As TEnum
            Dim t As Type = GetType(TEnum)
            Dim arry As IEnumerable(Of [Enum]) = FieldIdLabelAttribute.GetEnumIterator(t)

            For Each item As [Enum] In arry
                Dim instanse As FieldIdLabelAttribute = EnumCustomAttributeCache.Acquire(Of FieldIdLabelAttribute)(item)
                If instanse IsNot Nothing AndAlso comparer.Compare(instanse.Id, id) = 0 Then
                    Return DirectCast([Enum].ToObject(t, item), TEnum)

                End If

            Next

            Return ClassService.DefaultAt(Of TEnum)()

        End Function

        Private Shared Function GetEnumIterator( t As Type) As IEnumerable(Of [Enum])
            Dim arry As IEnumerable(Of [Enum]) = [Enum].GetValues(t).Cast(Of [Enum])()
            Return arry

        End Function

#End Region

    End Class

End Namespace

