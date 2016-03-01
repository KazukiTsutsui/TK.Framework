Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility

    ''' <summary>
    ''' スナップショットの基本クラスを表します。
    ''' </summary>
    ''' <typeparam name="TParam"></typeparam>
    Public MustInherit Class SnapShotBase(Of TTarget, TParam)
        Implements ISnapShot


#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _isShoted As Boolean

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _target As TTarget
        ''' <summary>
        ''' 対象となるオブジェクトを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Protected ReadOnly Property Target() As TTarget
            Get
                Return Me._target
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _saveParam As TParam
        ''' <summary>
        ''' 保存したパラメーターを取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Protected ReadOnly Property SaveParam() As TParam
            Get
                Return Me._saveParam
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _comparer As IEqualityComparer(Of TParam)
        ''' <summary>
        ''' 比較演算子を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Protected ReadOnly Property Comparer() As IEqualityComparer(Of TParam)
            Get
                Return Me._comparer
            End Get
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' SnapShot(Of T) クラスの新しいインスタンスを初期化します。
        ''' この呼び出しは、既定の比較演算子を使用します。
        ''' </summary>
        ''' <param name="target">対象とするオブジェクト。</param>
        Protected Sub New( target As TTarget)
            Me.New(target, EqualityComparer(Of TParam).Default)

        End Sub

        ''' <summary>
        ''' SnapShot(Of T) クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象とするオブジェクト。</param>
        ''' <param name="comparer">ショット前と後を比較する IEqualityComparer のインスタンス。</param>
        ''' <exception cref="ArgumentnullException">引数に null を指定した場合にスローします。</exception>
        Protected Sub New( target As TTarget,  comparer As IEqualityComparer(Of TParam))
            ThrowHelper.IfNullArgumentThenThrow(target, NameOf(target))
            ThrowHelper.IfNullArgumentThenThrow(comparer, NameOf(comparer))

            Me._target = target
            Me._comparer = comparer

            Me.Reset()

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 現在のパラメータを取得します。
        ''' </summary>
        ''' <returns>現在のパラメータを返します。</returns>
        Protected MustOverride Function GetParameter() As TParam

        ''' <summary>
        ''' 現在の状態を保存します。
        ''' </summary>
        Public Overridable Sub Shot() Implements ISnapShot.Shot
            Me._saveParam = Me.GetParameter()
            _isShoted = True

        End Sub

        ''' <summary>
        ''' 保存済のパラメータと現在のパラメータを検証します。
        ''' </summary>
        ''' <returns>True:等価。,False:等価でない。もしくは保存をしていない。</returns>
        Public Overridable Function Validate() As Boolean Implements ISnapShot.Validate
            If Not Me._isShoted Then
                Return False

            End If

            Return Me.Comparer.Equals(Me.SaveParam, Me.GetParameter())

        End Function

        ''' <summary>
        ''' リセットします。
        ''' </summary>
        Public Overridable Sub Reset() Implements ISnapShot.Reset
            Me._isShoted = False
            Me._saveParam = Nothing

        End Sub

        Public Function GetTarget() As Object Implements ISnapShot.GetInstanse
            Return Me.Target

        End Function

#End Region

        Public Sub Raise() Implements ISnapShot.Raise

        End Sub
    End Class

End Namespace

