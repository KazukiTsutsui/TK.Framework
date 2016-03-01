Option Strict On
Option Infer Off

Imports System.Windows.Forms

Namespace Utility.ControlAssist

    ''' <summary>
    ''' コントロールの変更に関するスコープを定義します。
    ''' </summary>
    ''' <typeparam name="T">コントロール。</typeparam>
    Public MustInherit Class ControlActionScope(Of T As Control)
        Inherits ActionScope(Of T)

#Region " Constructers "

        ''' <summary>
        ''' ControlScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        Protected Sub New( target As T)
            MyBase.New(target)

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' スコープ開始時の動作を取得します。
        ''' </summary>
        ''' <returns>True:正常に実行。,False:実行不可。</returns>
        Protected MustOverride Overrides Function BeginScopeInternal() As Boolean

        ''' <summary>
        ''' スコープ終了時の動作を取得します。
        ''' </summary>
        ''' <returns>True:正常に実行。,False:実行不可。</returns>
        Protected MustOverride Overrides Function EndScopeInternal() As Boolean

        ''' <summary>
        ''' コントロールの動作を実行可能か否かを取得します。
        ''' </summary>
        ''' <returns>True:実行可能。,False:実行不可。</returns>
        Protected Overrides Function CanAction() As Boolean
            Return Not Me.Target.IsDisposed

        End Function

#End Region

    End Class


    ''' <summary>
    ''' コントロールの変更に関するスコープを定義します。
    ''' </summary>
    ''' <typeparam name="T">コントロール。</typeparam>
    Public MustInherit Class ControlActionScope(Of T As Control, Tparam)
        Inherits ActionScope(Of T, Tparam)

#Region " Constructers "

        ''' <summary>
        ''' ControlScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        ''' <param name="params">初期化子。</param>
        Protected Sub New( target As T,  params As Tparam)
            MyBase.New(target, params)

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' スコープ開始時の動作を取得します。
        ''' </summary>
        ''' <returns>True:正常に実行。,False:実行不可。</returns>
        Protected MustOverride Overrides Function BeginScopeInternal() As Boolean

        ''' <summary>
        ''' スコープ終了時の動作を取得します。
        ''' </summary>
        ''' <returns>True:正常に実行。,False:実行不可。</returns>
        Protected MustOverride Overrides Function EndScopeInternal() As Boolean

        ''' <summary>
        ''' コントロールの動作を実行可能か否かを取得します。
        ''' </summary>
        ''' <returns>True:実行可能。,False:実行不可。</returns>
        Protected Overrides Function CanAction() As Boolean
            Return Not Me.Target.IsDisposed

        End Function

#End Region

    End Class

End Namespace
