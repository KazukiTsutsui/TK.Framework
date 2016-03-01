Option Strict On
Option Infer Off

Imports System.Windows.Forms
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' CheckBox クラスのスナップショットを提供します。
    ''' </summary>
    Public NotInheritable Class CheckBoxSnapShot
        Inherits SnapShotBase(Of CheckBox, Boolean)

#Region " Constructers "

        ''' <summary>
        ''' CheckBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象とする CheckBox 。</param>
        ''' <remarks></remarks>
        Public Sub New( target As CheckBox)
            MyBase.New(target, EqualityComparer(Of Boolean).Default)

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function GetParameter() As Boolean
            Return Me.Target.Checked

        End Function

#End Region

    End Class

End Namespace
