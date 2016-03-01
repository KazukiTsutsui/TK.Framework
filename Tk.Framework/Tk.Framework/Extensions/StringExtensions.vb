Imports System.Runtime.CompilerServices
Imports System.Text
Imports System
Imports System.Collections.Generic

Namespace Extensions

    ''' <summary>
    ''' String 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module StringExtensions

        ''' <summary>
        ''' 文字列を改行毎に区切った配列を返します。
        ''' </summary>
        ''' <param name="target">対象とする文字列。</param>
        ''' <param name="splitOptions">空の文字列を含めるかどうか。</param>
        ''' <returns>改行毎に区切られた配列。</returns>
        <Extension()> _
        Public Function SplitLine( target As String, Optional  splitOptions As StringSplitOptions = StringSplitOptions.None) As String()
            Dim arry As String() = New String() {Environment.NewLine}
            Return target.Split(arry, splitOptions)

        End Function

        ''' <summary>
        ''' 複数の置換対象文字列を新しい文字列に置き換えます。
        ''' </summary>
        ''' <param name="target">対象となる文字列。</param>
        ''' <param name="oldChars">古い文字列の配列。</param>
        ''' <param name="newChar">新しい文字列。</param>
        ''' <returns>対象文字列を置き換えた新しい文字列。</returns>
        <Extension()> _
        Public Function ReplaceMany( target As String,  oldChars As IEnumerable(Of String),  newChar As String) As String
            Dim sb As New StringBuilder(target)
            For Each item As String In oldChars
                sb.Replace(item, newChar)

            Next

            Return sb.ToString()

        End Function

        <Extension()> _
        Public Function ReplaceEmpty( target As String,  removeString As String) As String
            Return target.Replace(removeString, String.Empty)

        End Function

        <Extension()> _
        Public Function ReplaceEmpty( target As String,  removeChar As Char) As String
            Static empty As Char = Convert.ToChar(String.Empty)
            Return target.Replace(removeChar, empty)

        End Function

    End Module

End Namespace
