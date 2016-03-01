Imports System.Windows.Forms
Imports System.ComponentModel
Imports TK.Framework.Extensions
Imports System.Diagnostics
Imports System

Namespace Utility.Events

    ''' <summary>
    ''' Windows 標準のコンポーネントに関するイベント情報を表します。
    ''' </summary>
    Public NotInheritable Class WindowsEventDatum(Of T As Component)
        Inherits Events.EventDatum(Of T)

#Region " Fields "

        ''' <summary>
        ''' ターゲットの EventHandlerList を格納します。
        ''' </summary>
        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _eventHandlerList As EventHandlerList

#End Region

#Region " Constructers "

        Public Sub New( target As T)
            MyBase.New(target)
            Me._eventHandlerList = Me.GetEvents()

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 対象の EventHandlerList を取得します。
        ''' </summary>
        ''' <returns>EventHandlerList を返します。</returns>
        Private Function GetEvents() As EventHandlerList
            Dim mi As Reflection.MethodInfo = ReflectionHelper.FindMethodIncludingBase(Me.TargetType, "get_Event")
            'null は絶対にないはず。
            Return DirectCast(mi.Invoke(Target, New Object() {}), EventHandlerList)

        End Function

        ''' <summary>
        ''' イベント名からイベントを追加します。
        ''' </summary>
        ''' <param name="name">イベント名。</param>
        Public Overrides Sub [AddHandler]( name As String)
            Dim pair As KeyDelegatePair = Me.GetEventHandlerCore(name)
#If DEBUG Then
            If pair.Key Is Nothing Then
                Dim msg As String = String.Format("{0} は実装されていないイベントです。", name)
                Throw New NotImplementedException(msg)

            End If

#End If

            Me._eventHandlerList.AddHandler(pair.Key, pair.Method)

        End Sub

        Public Overrides Function GetEventHandler( eventName As String) As System.Delegate
            Return Me.GetEventHandlerCore(eventName).Method

        End Function

        ''' <summary>
        ''' イベント名から、現在関連付けられているデリゲートを削除します。
        ''' </summary>
        ''' <param name="name">イベント名。</param>
        Public Overrides Sub [RemoveHandler]( name As String)
            Dim pair As KeyDelegatePair = Me.GetEventHandlerCore(name)
            Me._eventHandlerList.RemoveHandler(pair.Key, pair.Method)

        End Sub

        ''' <summary>
        ''' イベント名からイベントのキーを取得します。
        ''' </summary>
        ''' <param name="eventName">イベント名。</param>
        ''' <returns>イベントのキー。</returns>
        Private Function GetEventKey( eventName As String) As Object
            '.Net Framework 内のイベント格納変数は全て「 Event + イベント名」で宣言されている。
            Dim fi As Reflection.FieldInfo = ReflectionHelper.FindFieldIncludingBase(Me.TargetType, String.Concat("Event", eventName))
            If fi Is Nothing Then
                Return Nothing

            End If

            Return fi.GetValue(Me.Target)

        End Function

        ''' <summary>
        ''' イベントハンドラのキーとそのペアとなるデリゲートインスタンスを取得します。
        ''' </summary>
        ''' <param name="name">イベント名。</param>
        ''' <returns>イベントハンドラのキーとそのペアとなるデリゲートインスタンス。</returns>
        Private Function GetEventHandlerCore( name As String) As KeyDelegatePair
            Dim key As Object = Me.GetEventKey(name)
            Dim result As New KeyDelegatePair(key, Me._eventHandlerList(key))
            Return result

        End Function

#End Region

#Region " Internal Structure "

        ''' <summary>
        ''' EventHandlerList の要素を表現します。
        ''' </summary>
        Private Structure KeyDelegatePair

            ''' <summary>
            ''' イベントのデリゲート。
            ''' </summary>
            Public Method As [Delegate]

            ''' <summary>
            ''' イベントのキー。
            ''' </summary>
            ''' <remarks></remarks>
            Public Key As Object

            Public Sub New( key As Object,  method As [Delegate])
                Me.Key = key
                Me.Method = method

            End Sub

        End Structure

#End Region

    End Class

End Namespace

