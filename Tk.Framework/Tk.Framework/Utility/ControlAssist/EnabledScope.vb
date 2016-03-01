Option Strict On
Option Infer Off

Imports System.Windows.Forms
Imports System.Diagnostics

Namespace Utility.ControlAssist

    ''' <summary>
    ''' コントロールのEnabledの切替のスコープを定義します。
    ''' </summary>
    Public NotInheritable Class EnabledScope
        Inherits ControlActionScope(Of Control, Boolean)

#Region " Fields "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _saveEnabled As Boolean

#End Region

#Region " Constructers "

        ''' <summary>
        ''' EnabledScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        Public Sub New( target As Control)
            Me.New(target, False)

        End Sub

        ''' <summary>
        ''' EnabledScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        ''' <param name="scopeInEnabled">スコープ内の Enabled 。</param>
        Public Sub New( target As Control,  scopeInEnabled As Boolean)
            MyBase.New(target, scopeInEnabled)

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function BeginScopeInternal() As Boolean
            If Me.Target.Enabled <> Me.ConstructParam Then
                Me._saveEnabled = Me.Target.Enabled
                Me.Target.Enabled = Me.ConstructParam
                Return True

            End If

            Return False

        End Function

        Protected Overrides Function EndScopeInternal() As Boolean
            If Me.Target.Enabled <> Me._saveEnabled Then
                Me.Target.Enabled = Me._saveEnabled
                Return True

            End If

            Return False

        End Function

#End Region

    End Class

End Namespace