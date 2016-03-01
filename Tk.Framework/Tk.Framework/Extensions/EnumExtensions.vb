Imports System.Runtime.CompilerServices
Imports TK.Framework.Utility
Imports System
Imports System.Linq
Imports System.Text

Namespace Extensions

    ''' <summary>
    ''' 列挙型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module EnumExtensions

        ''' <summary>
        ''' 関連付けられた名前を取得します。
        ''' </summary>
        ''' <param name="source">対象となる列挙値。</param>
        ''' <returns>関連付けられた名前を返します。</returns>
        <Extension()> _
        Public Function GetAliasName( source As [Enum]) As String
            Dim attr As FieldLabelAttribute = EnumCustomAttributeCache.Acquire(Of FieldLabelAttribute)(source)
            If attr Is Nothing Then
                Return String.Empty

            End If

            Return attr.Name

        End Function

        ''' <summary>
        ''' 関連付けられた ID を取得します。
        ''' </summary>
        ''' <param name="source">対象となる列挙値。</param>
        ''' <returns></returns>
        <Extension()> _
        Public Function GetIdFromFieldIdLabel( source As [Enum]) As String
            Return source.GetCustomeAttribute(Of FieldIdLabelAttribute)().Id

        End Function

        ''' <summary>
        ''' 関連付けられた ID を取得します。
        ''' </summary>
        ''' <param name="source">対象となる列挙値。</param>
        ''' <returns></returns>
        <Extension()> _
        Public Function GetNameFromFieldIdLabel( source As [Enum]) As String
            Return source.GetCustomeAttribute(Of FieldIdLabelAttribute)().Name

        End Function


        ''' <summary>
        ''' 列挙値と関連付いたカスタム属性を取得します。
        ''' </summary>
        ''' <typeparam name="TAttribute">カスタム属性の型。</typeparam>
        ''' <param name="source">対象となる列挙値。</param>
        ''' <returns>列挙値と関連付いたカスタム属性を返します。</returns>
        <Extension()> _
        Public Function GetCustomeAttribute(Of TAttribute As Attribute)( source As [Enum]) As TAttribute
            Dim mi As Reflection.MemberInfo = EnumExtensions.GetMemberInternal(source)
            If mi IsNot Nothing Then
                Dim attr As Attribute = Attribute.GetCustomAttribute(mi, GetType(TAttribute))
                Return TryCast(attr, TAttribute)

            End If

            Return Nothing

        End Function

        ''' <summary>
        ''' 列挙値と関連付いたカスタム属性の配列を取得します。
        ''' </summary>
        ''' <param name="source">対象となる列挙値。</param>
        ''' <returns>列挙値と関連付いたカスタム属性を返します。</returns>
        <Extension()> _
        Public Function GetCustomeAttributes( source As [Enum]) As Attribute()
            Dim mi As Reflection.MemberInfo = EnumExtensions.GetMemberInternal(source)
            Dim result As Attribute() = Attribute.GetCustomAttributes(mi)

            Return result

        End Function

        Private Function GetMemberInternal( source As [Enum]) As Reflection.MemberInfo
            Dim enumType As Type = source.GetType()
            Dim name As String = [Enum].GetName(enumType, source)
            Dim mi As Reflection.MemberInfo = enumType.GetMember(name, ReflectionHelper.AllBindingFlags).First()

            Return mi

        End Function


    End Module

End Namespace