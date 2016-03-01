Option Strict On
Option Infer Off

Imports System.Windows.Forms
Imports System
Imports System.Diagnostics

Namespace Utility.ControlAssist

    ''' <summary>
    ''' TextBox のテキストの値を保存します。
    ''' </summary>
    Public Class TextBoxSnapShot
        Inherits SnapShotBase(Of TextBox, String)

#Region " Constructers "

        ''' <summary>
        ''' TextBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' テキストを大小区別して比較します。
        ''' </summary>
        ''' <param name="target">対象となる TextBox 。</param>
        Public Sub New( target As TextBox)
            Me.New(target, StringComparer.CurrentCulture)

        End Sub

        ''' <summary>
        ''' TextBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象となる TextBox 。</param>
        ''' <param name="comparer">文字列の比較演算子。</param>
        Public Sub New( target As TextBox,  comparer As StringComparer)
            MyBase.New(target, comparer)
            AddHandler Me.Target.TextChanged, AddressOf TextChanged

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function GetParameter() As String
            Return Me.Target.Text

        End Function

#End Region

        Private Sub TextChanged( sender As Object,  e As EventArgs)
            Debugger.Break()

        End Sub

    End Class

End Namespace

