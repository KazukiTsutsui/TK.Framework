Option Strict On
Option Infer Off

Imports TK.Framework.Extensions
Imports System.Windows.Forms
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' カーソル変更のスコープを定義します。
    ''' </summary>
    Public NotInheritable Class CursorScope
        Inherits ControlActionScope(Of Control, Cursor)

#Region " Fields "

        ''' <summary>
        ''' スコープ内のカーソル。
        ''' </summary>
        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _scopeInCursor As Cursor

        ''' <summary>
        ''' 対象の最初のカーソル。
        ''' </summary>
        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _saveCursor As Cursor

#End Region

#Region " Constructers "

        ''' <summary>
        ''' CursorScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">待ち状態の対象とするコントロール。</param>
        Public Sub New( target As Control)
            Me.New(target, Cursors.WaitCursor)

        End Sub

        ''' <summary>
        ''' CursorScope クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        ''' <param name="scopeInCursor">対象スコープ内のカーソル。</param>
        Public Sub New( target As Control,  scopeInCursor As Cursor)
            MyBase.New(target, scopeInCursor)

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' スコープを開始します。
        ''' </summary>
        ''' <returns></returns>
        Protected Overrides Function BeginScopeInternal() As Boolean
            If Me.Target.Cursor <> Me.ConstructParam Then
                Me._saveCursor = Me.Target.Cursor
                Me.Target.Cursor = Me.ConstructParam
                Return True

            End If

            Return False

        End Function

        ''' <summary>
        ''' スコープを終了します。
        ''' </summary>
        ''' <returns></returns>
        Protected Overrides Function EndScopeInternal() As Boolean
            If Me.Target.Cursor <> Me._saveCursor Then
                Me.Target.Cursor = Me._saveCursor
                Return True

            End If

            Return False

        End Function

#End Region

    End Class

End Namespace