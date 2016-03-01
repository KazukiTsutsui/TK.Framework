Imports System.Runtime.CompilerServices
Imports System.Text
Imports System

Namespace Extensions

    ''' <summary>
    ''' System.Text.StringBuilder の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module StringBuilderExtensions

        ''' <summary>
        ''' 格納されている文字列を全て削除し、容量を新たに設定します。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <param name="capacity">容量。</param>
        <Extension()> _
        Public Sub ClearString( target As StringBuilder,  capacity As Integer)
            target.Length = 0
            target.Capacity = capacity

        End Sub

        ''' <summary>
        ''' 0 個以上の書式指定を含んでいる書式付き文字列と既定の行終端記号をこのインスタンスに追加します。
        ''' 各書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <param name="format">複合書式指定文字列。</param>
        ''' <param name="arg0">書式指定するオブジェクト。</param>
        ''' <returns> format が追加されたこのインスタンスへの参照。format の書式指定は、対応するオブジェクト引数の文字列形式に置換されます。</returns>
        <Extension()> _
        Public Function AppendFormatAndLine( target As StringBuilder,  format As String,  arg0 As String) As StringBuilder
            Return target.AppendFormat(format, arg0).AppendLine()

        End Function

        ''' <summary>
        ''' 0 個以上の書式指定を含んでいる書式付き文字列と既定の行終端記号をこのインスタンスに追加します。
        ''' 各書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <param name="format">複合書式指定文字列。</param>
        ''' <param name="arg0">書式指定する第 1 オブジェクト。</param>
        ''' <param name="arg1">書式指定する第 2 オブジェクト。</param>
        ''' <returns> format が追加されたこのインスタンスへの参照。format の書式指定は、対応するオブジェクト引数の文字列形式に置換されます。</returns>
        <Extension()> _
        Public Function AppendFormatAndLine( target As StringBuilder,  format As String,  arg0 As String,  arg1 As String) As StringBuilder
            Return target.AppendFormat(format, arg0, arg1).AppendLine()

        End Function

        ''' <summary>
        ''' 0 個以上の書式指定を含んでいる書式付き文字列と既定の行終端記号をこのインスタンスに追加します。
        ''' 各書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <param name="format">複合書式指定文字列。</param>
        ''' <param name="arg0">書式指定する第 1 オブジェクト。</param>
        ''' <param name="arg1">書式指定する第 2 オブジェクト。</param>
        ''' <param name="arg2">書式指定する第 3 オブジェクト。</param>
        ''' <returns> format が追加されたこのインスタンスへの参照。format の書式指定は、対応するオブジェクト引数の文字列形式に置換されます。</returns>
        <Extension()> _
        Public Function AppendFormatAndLine( target As StringBuilder,  format As String,  arg0 As String,  arg1 As String,  arg2 As String) As StringBuilder
            Return target.AppendFormat(format, arg0, arg1, arg2).AppendLine()

        End Function

        ''' <summary>
        ''' 0 個以上の書式指定を含んでいる書式付き文字列と既定の行終端記号をこのインスタンスに追加します。
        ''' 各書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <param name="format">複合書式指定文字列。</param>
        ''' <param name="args">書式指定するオブジェクトの配列。</param>
        ''' <returns>
        '''  format が追加されたこのインスタンスへの参照。
        '''  format の書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </returns>
        <Extension()> _
        Public Function AppendFormatAndLine( target As StringBuilder,  format As String,  ParamArray args() As String) As StringBuilder
            Return target.AppendFormat(format, args).AppendLine()

        End Function

        ''' <summary>
        ''' 0 個以上の書式指定を含んでいる書式付き文字列と既定の行終端記号をこのインスタンスに追加します。
        ''' 各書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </summary>
        ''' <param name="target">対象のインスタンス。</param>
        ''' <param name="provider">カルチャ固有の書式情報を提供する System.IFormatProvider 。</param>
        ''' <param name="format">複合書式指定文字列。</param>
        ''' <param name="args">書式指定するオブジェクトの配列。</param>
        ''' <returns>
        '''  format が追加されたこのインスタンスへの参照。
        '''  format の書式指定は、対応するオブジェクト引数の文字列形式に置換されます。
        ''' </returns>
        <Extension()> _
        Public Function AppendFormatAndLine( target As StringBuilder,  provider As IFormatProvider,  format As String,  ParamArray args() As Object) As StringBuilder
            Return target.AppendFormat(provider, format, args).AppendLine()

        End Function

    End Module

End Namespace