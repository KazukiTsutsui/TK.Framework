#Region " Imports Drivers "

Imports System
Imports System.Text
Imports TK.Framework.Extensions

#End Region

Namespace Utility

    ''' <summary>
    ''' StringBuilder をキャッシュし、メモリ節約と実行速度向上を提供します。
    ''' </summary>
    Public NotInheritable Class StringBuilderCache

#Region " Fields "

        ''' <summary>
        ''' 360 Byte が最も効率の良い容量とのこと。
        ''' The value 360 was chosen in discussion with performance experts as a compromise between using
        ''' as litle memory (per thread) as possible and still covering a large part of short-lived
        ''' StringBuilder creations on the startup path of VS designers.
        ''' </summary>
        Private Const MAX_BUILDER_SIZE As Integer = 360

        ''' <summary>
        ''' スレッド毎に一意なインスタンス。
        ''' </summary>
        <ThreadStatic()> _
        Private Shared BuilderInstance As StringBuilder

        ''' <summary>
        ''' StringBuilder のデフォルト容量。
        ''' FWからは見れないのでここでも宣言。
        ''' </summary>
        ''' <remarks></remarks>
        Friend Const DEFAULT_SIZE As Integer = 16I

#End Region

#Region " Constructers "

        Private Sub New()
        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' キャッシュから適切な System.Text.StringBuilder のインスタンスを得ます。
        ''' </summary>
        ''' <param name="capacity">容量。</param>
        ''' <returns>適切な StringBuilder のインスタンスを返します。</returns>
        Public Shared Function Acquire(Optional  capacity As Integer = DEFAULT_SIZE) As StringBuilder
            If (capacity <= MAX_BUILDER_SIZE) Then
                Dim sb As StringBuilder = StringBuilderCache.BuilderInstance
                If sb IsNot Nothing Then
                    '// Avoid stringbuilder block fragmentation by getting a new StringBuilder
                    '// when the requested size is larger than the current capacity
                    If capacity <= sb.Capacity Then
                        StringBuilderCache.BuilderInstance = Nothing
                        sb.Clear()
                        Return sb

                    End If

                End If

            End If

            Return New StringBuilder(capacity)

        End Function

        ''' <summary>
        ''' System.Text.StringBuilder のインスタンスを解放します。
        ''' </summary>
        ''' <param name="sb">対象となるインスタンス。</param>
        Public Shared Sub Release( sb As StringBuilder)
            If (sb.Capacity <= MAX_BUILDER_SIZE) Then
                StringBuilderCache.BuilderInstance = sb

            End If

        End Sub

        ''' <summary>
        ''' System.Text.StringBuilder のインスタンスから System.String の取得とリソースの解放を同時に実行します。
        ''' </summary>
        ''' <param name="sb">対象となるインスタンス。</param>
        ''' <returns>文字列。</returns>
        Public Shared Function GetStringAndRelease( sb As StringBuilder) As String
            Dim result As String = sb.ToString()
            Release(sb)
            Return result

        End Function

#End Region

    End Class

End Namespace