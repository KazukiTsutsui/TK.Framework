Imports System.Windows.Forms
Imports TK.Framework.Utility.Events
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Utility.Events

    ''' <summary>
    ''' Windows 標準のコンポーネントで発生するイベントのスコープを表します。
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public NotInheritable Class StandardEventAddHandlerScope(Of T As Component)
        Inherits ActionScope(Of T, String)

#Region " Fields "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _name As String

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _datum As WindowsEventDatum(Of T)

#End Region

#Region " Constructers "

        ''' <summary>
        ''' WindowsEventAddHandlerScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象となるコンポーネント。</param>
        ''' <param name="eventName">イベント名。</param>
        Public Sub New( target As T,  eventName As String)
            MyBase.New(target, eventName)
            Me._datum = New WindowsEventDatum(Of T)(target)

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function BeginScopeInternal() As Boolean
            Me._datum.AddHandler(Me._name)
            Return True

        End Function

        Protected Overrides Function EndScopeInternal() As Boolean
            Me._datum.RemoveHandler(Me._name)
            Return True

        End Function

#End Region

    End Class

End Namespace