Imports System.Reflection
Imports System
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility

    ''' <summary>
    ''' クラスのインスタンスに対する横断的なメソッド群を提供します。
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class ClassService

        ''' <summary>
        ''' ClassService クラスの新しいインスタンスを初期化します。
        ''' このクラスはインスタンス化を許可しません。
        ''' </summary>
        ''' <exception cref="NotSupportedException">このクラスをインスタンス化した際に発生します。</exception>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of ClassService)()

        End Sub

        Public Shared Function EqualFields(Of T)( t1 As T,  t2 As T) As Boolean
            Dim array As FieldInfo() = GetType(T).GetFields(BindingFlags.Instance Or BindingFlags.GetField Or BindingFlags.NonPublic)

            For Each fi As FieldInfo In array
                Dim fieldType As Type = fi.GetType()
                Dim t1Field As Object = fi.GetValue(t1)
                Dim t2Field As Object = fi.GetValue(t2)
                If fieldType.IsClass Then
                    If Not t1Field.Equals(t2Field) Then
                        Return False

                    End If

                Else
                    If t1Field IsNot t2Field Then
                        Return False

                    End If

                End If

            Next

            Return True

        End Function

        ''' <summary>
        ''' 対象のクラスの String 型のフィールド全てを空文字で初期化します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        Public Shared Sub InitializeStringFields(Of T)( target As T)
            Dim targetType As Type = GetType(T)
            Dim array As FieldInfo() = targetType.GetFields(BindingFlags.Instance Or BindingFlags.GetField Or BindingFlags.NonPublic)
            For Each fi As FieldInfo In array.Where(Function(x) x.FieldType Is GetType(String))
                fi.SetValue(target, String.Empty)

            Next

        End Sub

        ''' <summary>
        ''' 型の規定値を返します。
        ''' C# の Default ステートメントと同義の動作を実行します。
        ''' </summary>
        ''' <typeparam name="T">型。</typeparam>
        ''' <returns>規定値。</returns>
        Public Shared Function DefaultAt(Of T)() As T
            Return CType(Nothing, T)

        End Function

        ''' <summary>
        ''' System.String の配列に null または System.String.Empty 文字列が含まれているか否かを取得します。
        ''' </summary>
        ''' <param name="target">System.String の配列。</param>
        ''' <returns>True:含まれている。,False:含まれていない。</returns>
        Public Shared Function IsNullOrEmptyInStrings( target As IEnumerable(Of String)) As Boolean
            '速度重視。
            For Each element As String In target
                If String.IsNullOrEmpty(element) Then
                    Return True

                End If

            Next

            Return False

        End Function

        ''' <summary>
        ''' System.String の配列に null または System.String.Empty 文字列が含まれているか否かを取得します。
        ''' </summary>
        ''' <param name="target">System.String の配列。</param>
        ''' <returns>True:含まれている。,False:含まれていない。</returns>
        Public Shared Function IsNullOrEmptyInStrings( ParamArray target() As String) As Boolean
            Return ClassService.IsNullOrEmptyInStrings(target.AsEnumerable())

        End Function


    End Class

End Namespace