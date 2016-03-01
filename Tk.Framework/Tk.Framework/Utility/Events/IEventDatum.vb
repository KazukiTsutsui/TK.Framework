Imports System

Namespace Utility.Events

    ''' <summary>
    ''' イベント情報を定義します。
    ''' </summary>
    Public Interface IEventDatum

        Sub [AddHandler]( name As String)
        Sub [RemoveHandler]( name As String)
        Function GetEventHandler( eventName As String) As [Delegate]

    End Interface

End Namespace