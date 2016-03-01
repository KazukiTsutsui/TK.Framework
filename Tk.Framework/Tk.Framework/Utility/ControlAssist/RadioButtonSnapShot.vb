Option Strict On
Option Infer Off

Imports System.Windows.Forms

Namespace Utility.ControlAssist

    ''' <summary>
    ''' RadioButton のスナップショット機能を提供します。
    ''' </summary>
    Public NotInheritable Class RadioButtonSnapShot
        Inherits SnapShotBase(Of RadioButton, Boolean)

#Region " Constructers "

        ''' <summary>
        ''' RadioButtonSnapShot クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象の RadioButton 。</param>
        Public Sub New( target As RadioButton)
            MyBase.New(target)

        End Sub

#End Region

#Region " Methods "

        Protected Overrides Function GetParameter() As Boolean
            Return Me.Target.Checked

        End Function

#End Region

    End Class

End Namespace