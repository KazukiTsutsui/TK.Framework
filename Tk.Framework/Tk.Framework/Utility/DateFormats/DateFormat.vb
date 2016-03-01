Imports System.Diagnostics

Namespace Utility.DateFormats

    ''' <summary>
    ''' 日付のフォーマットを定義します。
    ''' </summary>
    Public NotInheritable Class DateFormat

        Public Shared ReadOnly [Default] As New Value("yyyy/MM/dd")
        Public Shared ReadOnly yyyyMMdd As New Value("yyyyMMdd")

#Region " InnerClasses "

        Public NotInheritable Class Value

            <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _format As String
            Public ReadOnly Property Format() As String
                Get
                    Return _format
                End Get
            End Property

            Public Sub New( format As String)
                Me._format = format

            End Sub


        End Class

#End Region

    End Class

End Namespace

