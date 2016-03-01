Imports System.Drawing
Imports System.Windows.Forms
Imports TK.Framework.Extensions
Imports TK.Framework.Utility
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System

Namespace Utility.Documents

    ''' <summary>
    ''' RTF 形式の文字列を作成する機能を提供します。
    ''' </summary>
    Public Class RtfBuilder
        Implements IRtfBuilder

#Region " Fields "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _defFont As Font

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _defColor As Color

        Private _rtfData As List(Of RtfDatum)

#End Region

#Region " Constructers "

        ''' <summary>
        ''' RtfBuilder クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="defFont">通常使用するフォント。</param>
        ''' <param name="defColor">通常使用する文字色。</param>
        Public Sub New( defFont As Font,  defColor As Color)
            Me._defFont = defFont
            Me._defColor = defColor
            Me._rtfData = New List(Of RtfDatum)

        End Sub

#End Region

#Region " Methods "

        Public Sub Clear() Implements IRtfBuilder.Clear
            Me._rtfData.Clear()

        End Sub

        Public Function AppendLine( txt As String) As RtfBuilder
            Return Me.AppendLine(txt, Me._defFont, Me._defColor)

        End Function

        Public Function AppendLine( txt As String,  font As Font) As RtfBuilder
            Return Me.AppendLine(txt, font, Me._defColor)

        End Function

        Public Function AppendLine( txt As String,  color As Color) As RtfBuilder
            Return Me.AppendLine(txt, Me._defFont, color)

        End Function

        Public Function AppendLine( txt As String,  font As Font,  color As Color) As RtfBuilder
            Return Me.AppendTextCore(String.Concat(txt, Environment.NewLine), font, color)

        End Function

        Public Function Append( txt As String) As RtfBuilder
            Return Me.Append(txt, Me._defFont, Me._defColor)

        End Function

        Public Function Append( txt As String,  font As Font) As RtfBuilder
            Return Me.Append(txt, font, Me._defColor)

        End Function

        Public Function Append( txt As String,  color As Color) As RtfBuilder
            Return Me.Append(txt, Me._defFont, color)

        End Function

        Public Function Append( txt As String,  font As Font,  color As Color) As RtfBuilder
            Return Me.AppendTextCore(txt, font, color)

        End Function

        Protected Function AppendTextCore( txt As String,  font As Font,  color As Color) As RtfBuilder
            ThrowHelper.IfStringOfArgumentnullThenThrow(txt, NameOf(txt))
            ThrowHelper.IfNullArgumentThenThrow(font, NameOf(font))
            ThrowHelper.IfNullArgumentThenThrow(color, NameOf(color))
            Dim rtf As New RtfDatum(txt, font, color)
            Me._rtfData.Add(rtf)

            Return Me

        End Function

        ''' <summary>
        ''' RTF形式の文字列を返します。
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String Implements IRtfBuilder.ToString
            Dim rtxt As RichTextBox = New RichTextBox()
            For Each item As RtfDatum In Me._rtfData
                rtxt.AppendText(item.Text)
                rtxt.SelectionColor = item.Color
                rtxt.SelectionFont = item.Font

            Next

            Return rtxt.Rtf

        End Function

#End Region

#Region " InternalClasses "

        Private NotInheritable Class RtfDatum

            <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _text As String
            Public ReadOnly Property Text() As String
                Get
                    Return _text
                End Get
            End Property

            <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _font As Font
            Public ReadOnly Property Font() As Font
                Get
                    Return _font
                End Get
            End Property

            <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _color As Color
            Public ReadOnly Property Color() As Color
                Get
                    Return _color
                End Get
            End Property

            Private Sub New()
            End Sub

            Public Sub New( text As String,  font As Font,  color As Color)
                Me._text = text
                Me._font = font
                Me._color = color

            End Sub

        End Class

#End Region

#Region " IDisposable "

        Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose( disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: 他の状態を解放します (マネージ オブジェクト)。
                End If
                ' TODO: ユーザー独自の状態を解放します (アンマネージ オブジェクト)。
                ' TODO: 大きなフィールドを null に設定します。

            End If

            Me._defFont = Nothing
            Me._defColor = Color.Empty
            Me._rtfData = Nothing
            Me.disposedValue = True

        End Sub

#Region " IDisposable Support "
        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose( disposing As Boolean) に記述します。
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#End Region

    End Class

End Namespace
