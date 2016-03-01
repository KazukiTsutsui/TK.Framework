Imports System.Windows.Forms
Imports System

Namespace Utility.Message

    ''' <summary>
    ''' メッセージボックスの値を定義します。
    ''' </summary>
    Public Interface IMessageSet
        Inherits ICloneable
        Inherits IEquatable(Of IMessageSet)
        Inherits IComparable(Of IMessageSet)

#Region " Properties "

        ''' <summary>
        ''' メッセージ固有のIDを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property Id() As String

        ''' <summary>
        ''' メッセージのテキストを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property Text() As String

        ''' <summary>
        ''' メッセージのタイトルを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property Title() As String

        ''' <summary>
        ''' メッセージに表示するボタンを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property Buttons() As MessageBoxButtons

        ''' <summary>
        ''' メッセージに表示するアイコンを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property Icon() As MessageBoxIcon

        ''' <summary>
        ''' メッセージのデフォルトボタンを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property DefaultButton() As MessageBoxDefaultButton

        ''' <summary>
        ''' メッセージのオプションを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property Options() As MessageBoxOptions

        ''' <summary>
        ''' メッセージのヘルプボタンの表示を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Property DisplayHelpButton() As Boolean

#End Region

    End Interface

End Namespace