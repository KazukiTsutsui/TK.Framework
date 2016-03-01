Imports System.Reflection
Imports System

''' <summary>
''' リフレクションに関する補助メソッド群を定義します。
''' このクラスは継承できません。
''' </summary>
Friend NotInheritable Class ReflectionHelper

    ''' <summary>
    ''' 全ての型検索を表現する列挙値を取得します。
    ''' </summary>
    ''' <returns>全ての型検索を示す BindingFlags を返します。</returns>
    Public Shared Function AllBindingFlags() As BindingFlags
        Return BindingFlags.Public Or BindingFlags.NonPublic _
            Or BindingFlags.Instance Or BindingFlags.IgnoreCase Or BindingFlags.Static

    End Function

    ''' <summary>
    ''' プロパティが読み書き可能か否かを取得します。
    ''' </summary>
    ''' <param name="pi">プロパティ情報。</param>
    ''' <returns>True:読み書き可能。,False:読み書き不可。</returns>
    Public Shared Function IsReadAndWriteProperty( pi As PropertyInfo) As Boolean
        Return pi.CanRead AndAlso pi.CanWrite

    End Function

    ''' <summary>
    ''' 指定した名前からメソッド情報を継承元まで再帰的に検索し、最初に見つかった情報を返します。
    ''' </summary>
    ''' <param name="target">対象の型。</param>
    ''' <param name="name">メソッド名。</param>
    ''' <returns>
    ''' MethodInfo クラスのインスタンス。
    ''' 見つからなかった場合は null を返します。
    ''' </returns>
    Public Shared Function FindMethodIncludingBase( target As Type,  name As String) As MethodInfo
        Dim mi As MethodInfo = target.GetMethod(name, ReflectionHelper.AllBindingFlags)
        If mi Is Nothing AndAlso target.BaseType IsNot Nothing Then
            Return FindMethodIncludingBase(target.BaseType, name)

        End If

        Return mi

    End Function

    ''' <summary>
    ''' 指定した名前からフィールド情報を継承元まで再帰的に検索し、最初に見つかった情報を返します。
    ''' </summary>
    ''' <param name="target">対象の型。</param>
    ''' <param name="name">メソッド名。</param>
    ''' <returns>
    ''' FieldInfo クラスのインスタンス。
    ''' 見つからなかった場合は null を返します。
    ''' </returns>
    Public Shared Function FindFieldIncludingBase( target As Type,  name As String) As FieldInfo
        Dim fi As FieldInfo = target.GetField(name, ReflectionHelper.AllBindingFlags)
        If fi Is Nothing AndAlso target.BaseType IsNot Nothing Then
            Return FindFieldIncludingBase(target.BaseType, name)

        End If

        Return fi

    End Function

End Class
