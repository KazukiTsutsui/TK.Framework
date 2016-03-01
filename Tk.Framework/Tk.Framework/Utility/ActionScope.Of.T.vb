Imports TK.Framework.Extensions
Imports System.Diagnostics
Imports System

Namespace Utility

    ''' <summary>
    ''' 特定の動作のスコープを実装します。
    ''' </summary>
    ''' <typeparam name="T">対象となる型。</typeparam>
    Public MustInherit Class ActionScope(Of T)
        Implements IActionScope

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _isBigined As Boolean
        ''' <summary>
        ''' 初期化処理を実行済みか否かを取得します。
        ''' </summary>
        Public ReadOnly Property IsBegined() As Boolean Implements IActionScope.IsBegined
            Get
                Return Me._isBigined
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _target As T
        ''' <summary>
        ''' スコープを定義する対象を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Protected ReadOnly Property Target() As T
            Get
                Return Me._target
            End Get
        End Property

#End Region

#Region " Constoructers "

        ''' <summary>
        ''' ActionScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">スコープを定義する対象。</param>
        ''' <exception cref="ArgumentnullException">スコープ処理の対象となる引数が null の場合にスローします。</exception>
        Protected Sub New( target As T)
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))

            Me._target = target
            Me._isBigined = False

            Me.BeginAction()

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 開始処理を試みます。
        ''' </summary>
        Public Function BeginAction() As Boolean Implements IActionScope.BeginAction
            If Not Me._isBigined AndAlso Me.CanActionInternal() Then
                Me._isBigined = Me.BeginScopeInternal()

            End If

            Return Me._isBigined

        End Function

        Private Function CanActionInternal() As Boolean
            Return Me.Target.IsNotNull() AndAlso Me.CanAction()

        End Function

        ''' <summary>
        ''' 一連の動作を実行可能か否かを取得します。
        ''' </summary>
        ''' <returns>True:実行できます。,False:実行できません。</returns>
        Protected Overridable Function CanAction() As Boolean Implements IActionScope.CanAction
            Return True

        End Function

        ''' <summary>
        ''' スコープ開始時の動作を実行します。
        ''' </summary>
        ''' <returns>True:正常に実行。,False:実行不可。</returns>
        Protected MustOverride Function BeginScopeInternal() As Boolean
        ''' <summary>
        ''' スコープ終了時の動作を実行します。
        ''' </summary>
        ''' <returns>True:正常に実行。,False:実行不可。</returns>
        Protected MustOverride Function EndScopeInternal() As Boolean

#End Region

#Region " IDisposable Support "

        ''' <summary>
        ''' 終了処理を実行します。
        '''  GC によるメモリの解放は行いません。
        ''' </summary>
        Public Sub Terminate() Implements IDisposable.Dispose
            If Me._isBigined AndAlso Me.CanActionInternal() Then
                If Me.EndScopeInternal() Then
                    Me._isBigined = False

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace