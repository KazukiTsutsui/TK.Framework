Option Strict On
Option Infer Off

Imports System.Windows.Forms
Imports TK.Framework.Extensions
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' コントロールの操作に関する横断的な関数群を提供します。
    ''' </summary>
    Public NotInheritable Class ControlHelper

#Region " Constructers "

        ''' <summary>
        ''' <c>ControlHelper</c> クラスの新しいインスタンスを初期化します。
        ''' このクラスはインスタンス化を許可しません。
        ''' </summary>
        ''' <exception cref="NotSupportedException">このクラスをインスタンス化した際に発生します。</exception>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of ControlHelper)()

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' 対象のコントロールが、操作可能か否かを取得します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        ''' <returns></returns>
        Public Shared Function IsAlive( target As Control) As Boolean
            Return target.IsNotNull() AndAlso Not target.IsDisposed

        End Function

        ''' <summary>
        ''' コントロールのインスタンスが存在し破棄されていない場合に、コントロールを破棄します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        Public Shared Sub DisposeSafe( target As Control)
            If ControlHelper.IsAlive(target) Then
                target.Dispose()

            End If

        End Sub

#End Region

    End Class

End Namespace

