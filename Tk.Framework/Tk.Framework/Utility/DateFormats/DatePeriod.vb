Imports TK.Framework.Extensions
Imports System
Imports System.Diagnostics
Imports System.Text

Namespace Utility.DateFormats

    ''' <summary>
    ''' 日付の期間を表します。
    ''' </summary>
    Public NotInheritable Class DatePeriod

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _startDate As DateTime
        ''' <summary>
        ''' 期間の開始日を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property StartDate() As DateTime
            Get
                Return Me._startDate
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _endDate As DateTime
        ''' <summary>
        ''' 期間の終了日を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property EndDate() As DateTime
            Get
                Return _endDate
            End Get
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' DatePeriod クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="startDate">開始日。</param>
        ''' <param name="endDate">終了日。</param>
        Public Sub New( startDate As DateTime,  endDate As DateTime)
            If Not ValidatePeriod(startDate, endDate) Then
                Dim sb As StringBuilder = StringBuilderCache.Acquire()
                sb.AppendLine("指定した期間が不正です。")
                sb.AppendFormatAndLine("{0}～{1}", startDate.ToString("yyyy/MM/dd"), endDate.ToString("yyyy/MM/dd"))
                Dim msg As String = StringBuilderCache.GetStringAndRelease(sb)

                Throw New ArgumentException(msg)

            End If

            Me._startDate = startDate
            Me._endDate = endDate

        End Sub

        ''' <summary>
        ''' DatePeriod クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="startDate">開始日を表す文字列。</param>
        ''' <param name="endDate">終了日を表す文字列。</param>
        ''' <param name="converter">文字列を日付に変換するコンバーター。</param>
        Public Sub New( startDate As String,  endDate As String,  converter As Converter(Of String, DateTime))
            Me.New(converter(startDate), converter(endDate))

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 安全に DatePeriod クラスの新しいインスタンスを初期化します。
        ''' 開始日が終了日より後日に設定されている場合は、開始日と終了日を同日に設定します。
        ''' </summary>
        ''' <param name="startDate">開始日。</param>
        ''' <param name="endDate">終了日。</param>
        ''' <returns> DatePeriod クラスの新しいインスタンスを取得します。</returns>
        Public Shared Function SafeNew( startDate As DateTime,  endDate As DateTime) As DatePeriod
            Dim s As DateTime = startDate
            Dim e As DateTime = endDate
            If Not ValidatePeriod(s, e) Then
                s = e

            End If

            Return New DatePeriod(s, e)

        End Function

        ''' <summary>
        ''' 開始日と終了日の期間が正常に設定されているか否かを取得します。
        ''' </summary>
        ''' <param name="startDate">開始日。</param>
        ''' <param name="endDate">終了日。</param>
        ''' <returns>True:正常に設定されている。,False:設定されていない。</returns>
        Public Shared Function ValidatePeriod( startDate As DateTime,  endDate As DateTime) As Boolean
            Dim result As Boolean = startDate <= endDate
            Return result

        End Function

        ''' <summary>
        ''' 期間内に存在する日付か否かを取得します。
        ''' </summary>
        ''' <param name="target">比較対象の日付。</param>
        ''' <returns>True:期間内。,False:期間外</returns>
        Public Function Contains( target As DateTime) As Boolean
            Dim result As Boolean = Me.StartDate >= target AndAlso Me.EndDate <= target
            Return result

        End Function

        ''' <summary>
        ''' 指定した日数分、期間を進めます。
        ''' </summary>
        ''' <param name="day">進める日数。</param>
        ''' <returns>追加操作が完了した後のこのインスタンスへの参照。</returns>
        Public Function MoveDay( day As Double) As DatePeriod
            Me._startDate = Me.StartDate.AddDays(day)
            Me._endDate = Me.EndDate.AddDays(day)
            Return Me

        End Function

        ''' <summary>
        ''' 指定した年数分、期間を進めます。
        ''' </summary>
        ''' <param name="year">進める年数。</param>
        ''' <returns>追加操作が完了した後のこのインスタンスへの参照。</returns>
        Public Function MoveYear( year As Integer) As DatePeriod
            Me._startDate = Me.StartDate.AddYears(year)
            Me._endDate = Me.EndDate.AddYears(year)
            Return Me

        End Function

        ''' <summary>
        ''' 指定した月数分、期間を進めます。
        ''' </summary>
        ''' <param name="month">進める月数。</param>
        ''' <returns>追加操作が完了した後のこのインスタンスへの参照。</returns>
        Public Function MoveMonth( month As Integer) As DatePeriod
            Me._startDate = Me.StartDate.AddMonths(month)
            Me._endDate = Me.EndDate.AddMonths(month)
            Return Me

        End Function

        ''' <summary>
        ''' 指定した期間内に対象の日付が含まれるか否かを取得します。
        ''' </summary>
        ''' <param name="startYmd">開始日。</param>
        ''' <param name="endYmd">終了日。</param>
        ''' <param name="target">確認する日付。</param>
        ''' <returns>True:期間内。,False:期間外</returns>
        Public Shared Function Contains( startYmd As DateTime,  endYmd As DateTime,  target As DateTime) As Boolean
            Dim result As Boolean = startYmd <= target AndAlso endYmd >= target
            Return result

        End Function

        Public Function ToStringPeriodFormat(Optional  separator As String = "") As String
            'TODO:
            Throw New NotImplementedException

        End Function

#End Region

    End Class

End Namespace