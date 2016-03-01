Imports System.ComponentModel
Imports System.Reflection
Imports TK.Framework.Extensions
Imports System
Imports System.Diagnostics

Namespace Utility.Events

    ''' <summary>
    ''' イベント情報を表します。
    ''' </summary>
    Public MustInherit Class EventDatum(Of T)
        Implements IEventDatum

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _target As T
        Protected ReadOnly Property Target() As T
            Get
                Return Me._target
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _targetType As Type
        Protected ReadOnly Property TargetType() As Type
            Get
                Return Me._targetType
            End Get
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' EventDatum クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">イベント情報を取得するインスタンス。</param>
        Public Sub New( target As T)
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))
            Me._target = target
            Me._targetType = target.GetType()

        End Sub

#End Region

        Public MustOverride Sub [AddHandler]( name As String) Implements IEventDatum.AddHandler
        Public MustOverride Function GetEventHandler( eventName As String) As System.Delegate Implements IEventDatum.GetEventHandler
        Public MustOverride Sub [RemoveHandler]( name As String) Implements IEventDatum.RemoveHandler

    End Class

End Namespace
