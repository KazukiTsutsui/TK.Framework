Imports System

Namespace Utility.Documents

    ''' <summary>
    ''' RTF 作成機能を定義します。
    ''' </summary>
    Public Interface IRtfBuilder
        Inherits IDisposable

        ''' <summary>
        ''' RTF 形式の文字列を取得します。
        ''' </summary>
        ''' <returns> RTF 形式の文字列を返します。</returns>
        Function ToString() As String

        ''' <summary>
        ''' 文字列をクリアします。
        ''' </summary>
        Sub Clear()

    End Interface

End Namespace

