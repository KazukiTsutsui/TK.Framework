Option Strict On
Option Infer Off

Imports System.Windows.Forms

Namespace Utility.ControlAssist

    ''' <summary>
    ''' コントロールのレイアウトロジックのスコープを定義します。
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class LayoutLogicScope
        Inherits ControlActionScope(Of Control, Boolean)

#Region " Constructers "

        ''' <summary>
        ''' LayoutLogicScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        Public Sub New( target As Control)
            Me.New(target, False)

        End Sub

        ''' <summary>
        ''' LayoutLogicScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        ''' <param name="performLayout">保留中のレイアウトの要求を実行する場合は true。それ以外の場合は false。</param>
        Public Sub New( target As Control,  performLayout As Boolean)
            MyBase.New(target, performLayout)

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function BeginScopeInternal() As Boolean
            Me.Target.SuspendLayout()
            Return True

        End Function

        Protected Overrides Function EndScopeInternal() As Boolean
            Me.Target.ResumeLayout(Me.ConstructParam)
            Me.Target.PerformLayout()
            Return True

        End Function

#End Region

    End Class

End Namespace