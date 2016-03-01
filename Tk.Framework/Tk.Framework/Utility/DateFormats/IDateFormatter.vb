Namespace Utility.DateFormats

    Public Interface IDateFormatter(Of TPatam)

        Function ToNutralFormat( target As TPatam) As String
        Function ToNutralSlashFormat( target As TPatam) As String
        Function ToJapaneseFormat( target As TPatam) As String
        Function ToJapaneseFormatInAlpha( target As TPatam) As String
        Function ToClippedForm( target As TPatam) As String

    End Interface

End Namespace