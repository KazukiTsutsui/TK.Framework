Imports System.Diagnostics
Imports System

Namespace Utility.DateFormats

    Public MustInherit Class StringDateFormatter
        Implements IDateFormatter(Of String)

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _targetFormat As String
        Protected ReadOnly Property TargetFormat() As String
            Get
                Return Me._targetFormat
            End Get
        End Property

#End Region

#Region " Constructers "

        Protected Sub New( targetFormat As String)
            Me._targetFormat = targetFormat

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 対象の文字列が既定のフォーマットで渡されているか否かを取得します。
        ''' </summary>
        ''' <param name="target">対象文字列。</param>
        ''' <returns> True :既定の文字列と一致する。, False :既定の文字列と一致しない。</returns>
        Protected Overridable Function CanConvert( target As String) As Boolean
            If String.IsNullOrEmpty(target) Then
                Return False

            End If

            If target.Length <> TargetFormat.Length Then
                Return False

            End If

            Return True

        End Function

        Public Function ToClippedForm( target As String) As String Implements IDateFormatter(Of String).ToClippedForm
            Throw New NotImplementedException

        End Function

        Public Function ToJapaneseFormat( target As String) As String Implements IDateFormatter(Of String).ToJapaneseFormat
            Throw New NotImplementedException

        End Function

        Public Function ToJapaneseFormatInAlpha( target As String) As String Implements IDateFormatter(Of String).ToJapaneseFormatInAlpha
            Throw New NotImplementedException

        End Function

        Public Function ToNutralFormat( target As String) As String Implements IDateFormatter(Of String).ToNutralFormat
            If Not Me.CanConvert(target) Then
                Return String.Empty

            End If

            Return target

        End Function

        Public Function ToNutralSlashFormat( target As String) As String Implements IDateFormatter(Of String).ToNutralSlashFormat
            Throw New NotImplementedException

        End Function

#End Region

    End Class

End Namespace

