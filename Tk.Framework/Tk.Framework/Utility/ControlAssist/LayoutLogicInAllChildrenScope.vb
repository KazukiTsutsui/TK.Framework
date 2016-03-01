Option Strict On
Option Infer Off

Imports TK.Framework.Utility
Imports System.Windows.Forms
Imports TK.Framework.Extensions
Imports System.Diagnostics
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' 対象の子コントロールを含む全てのレイアウトロジックのスコープを定義します。
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class LayoutLogicInAllChildrenScope
        Inherits ControlActionScope(Of Control, Boolean)

#Region " Fields "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _controls As IEnumerable(Of Control)

#End Region

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
            Me._controls = Me.Target.GetAllControls()

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function BeginScopeInternal() As Boolean
            For Each child As Control In _controls
                child.SuspendLayout()

            Next

            Return True

        End Function

        Protected Overrides Function EndScopeInternal() As Boolean
            For Each child As Control In _controls
                child.ResumeLayout(Me.ConstructParam)

            Next

            Return True

        End Function

#End Region

    End Class

End Namespace
