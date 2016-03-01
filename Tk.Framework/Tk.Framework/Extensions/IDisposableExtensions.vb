Imports System.Runtime.CompilerServices
Imports System

Namespace Extensions

    ''' <summary>
    ''' IDisposable クラスの拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module IDisposableExtensions

        ''' <summary>
        ''' null でない場合に破棄します。
        ''' </summary>
        ''' <param name="target"></param>
        <Extension()> _
        Public Sub NotNullThenDispose( target As IDisposable)
            If target IsNot Nothing Then
                target.Dispose()

            End If

        End Sub

    End Module

End Namespace
