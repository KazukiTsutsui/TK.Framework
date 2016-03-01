Imports TK.Framework.Extensions
Imports System.Runtime.CompilerServices
Imports System
Imports System.Linq

''' <summary>
''' 定型的な例外のスローを補助します。
''' このクラスは継承できません。
''' </summary>
Friend NotInheritable Class ThrowHelper

#Region " Constructers "

    ''' <summary>
    ''' ThrowHelper クラスの新しいインスタンスを初期化します。
    ''' このクラスはインスタンス化を許可しません。
    ''' </summary>
    ''' <exception cref="NotSupportedException">このクラスをインスタンス化した際に発生します。</exception>
    Private Sub New()
        ThrowHelper.NotSupportedConstructer(Of ThrowHelper)()

    End Sub

#End Region

#Region " Methods "

    ''' <summary>
    ''' 引数が null 値だった場合に System.ArgumentNullException をスローします。
    ''' </summary>
    ''' <typeparam name="T">対象となる引数の型。</typeparam>
    ''' <param name="target">検査する引数。</param>
    ''' <param name="name">変数名。</param>
    ''' <exception cref="ArgumentnullException">引数が null だった場合にスローします。</exception>
    Friend Shared Sub IfNullArgumentThenThrow(Of T)( target As T,  name As String)
        If target.IsNull() Then
            Throw New ArgumentNullException(name)

        End If

    End Sub

    ''' <summary>
    ''' String 型の引数チェックを行います。
    ''' null 値の場合は ArgumentnullException をスローし、空文字の場合は ArgumentException をスローします。
    ''' </summary>
    ''' <param name="target">対象のインスタンス。</param>
    ''' <param name="name">変数名。</param>
    ''' <exception cref="ArgumentException">空文字だった場合にスローします。</exception>
    ''' <exception cref="ArgumentnullException">Nothing だった場合にスローします。</exception>
    Friend Shared Sub IfStringOfArgumentnullThenThrow( target As String,  name As String)
        IfNullArgumentThenThrow(target, name)
        If target.Length = 0 Then
            Throw New ArgumentException(name)

        End If

    End Sub

    ''' <summary>
    ''' 引数が境界値を超えていた場合に System.ArgumentOutOfRangeException をスローします。
    ''' </summary>
    ''' <param name="min">最小値。</param>
    ''' <param name="max">最大値。</param>
    ''' <param name="index">インデックスとして渡された引数。</param>
    ''' <param name="name">変数名。</param>
    Friend Shared Sub IfOutOfRangeThenThrow( min As Integer,  max As Integer,  index As Integer,  name As String)
        If min > index OrElse index > max Then
            Throw New ArgumentOutOfRangeException(name)

        End If

    End Sub

    ''' <summary>
    ''' 引数が最大の境界値を超えていた場合に System.ArgumentOutOfRangeException をスローします。
    ''' </summary>
    ''' <param name="max">最大値。</param>
    ''' <param name="index">インデックスとして渡された引数。</param>
    ''' <param name="name">変数名。</param>
    Friend Shared Sub IfIndexLessOfRangeArgumentThenThrow( max As Integer,  index As Integer,  name As String)
        If index > max Then
            Throw New ArgumentOutOfRangeException(name)

        End If

    End Sub

    ''' <summary>
    ''' 引数が最小の境界値を超えていた場合に System.ArgumentOutOfRangeException をスローします。
    ''' </summary>
    ''' <param name="min">最小値。</param>
    ''' <param name="index">インデックスとして渡された引数。</param>
    ''' <param name="name">変数名。</param>
    Friend Shared Sub IfIndexGreaterOfRangeThenThrow( min As Integer,  index As Integer,  name As String)
        If index < min Then
            Throw New ArgumentOutOfRangeException(name)

        End If

    End Sub

    ''' <summary>
    ''' 述語に一致した場合、 System.ArgumentException をスローします。
    ''' </summary>
    ''' <typeparam name="T">型。</typeparam>
    ''' <param name="match">引数の評価式。</param>
    ''' <param name="param">引数。</param>
    ''' <param name="name">変数名。</param>
    Friend Shared Sub IfMatchArgumentThenThrow(Of T)( match As Predicate(Of T),  param As T,  name As String)
        IfMatchArgumentThenThrow(match.Invoke(param), name)

    End Sub

    Friend Shared Sub IfMatchArgumentThenThrow( isThrow As Boolean,  name As String)
        If isThrow Then
            Throw New ArgumentException(name)

        End If

    End Sub

    ''' <summary>
    ''' インスタンス化を許可しないクラスのコンストラクタで System.NotSupportedException をスローします。
    ''' </summary>
    ''' <typeparam name="T">インスタンス化を許可しないクラスの型。</typeparam>
    ''' <exception cref="NotSupportedException">呼び出し時にスローします。</exception>
    Friend Shared Sub NotSupportedConstructer(Of T As Class)()
        Dim name As String = GetType(T).Name
        Dim format As String = "{0} クラスのコンストラクタの呼び出しはサポートされていません。"
        Dim msg As String = String.Format(format, name)
        Throw New NotSupportedException(msg)

    End Sub

    ''' <summary>
    ''' 指定したファイルが見つからない場合に System.IO.FileNotFoundException をスローします。
    ''' </summary>
    ''' <param name="path">ファイルパス。</param>
    Friend Shared Sub IfFileNotFoundThenThrow( path As String)
        If Not IO.File.Exists(path) Then
            Throw New IO.FileNotFoundException("ファイルが見つかりませんでした。", path)

        End If

    End Sub

    ''' <summary>
    ''' 指定したディレクトリが見つからない場合に System.IO.DirectoryNotFoundException をスローします。
    ''' </summary>
    ''' <param name="path">ディレクトリパス。</param>
    Friend Shared Sub IfDirectoryNotFoundThenThrow( path As String)
        If IO.Directory.Exists(path) Then
            Throw New IO.DirectoryNotFoundException("指定されたフォルダが見つかりませんでした。")

        End If

    End Sub

#End Region

End Class