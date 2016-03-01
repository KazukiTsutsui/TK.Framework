Imports System.Collections.Generic
Imports System

Namespace Utility

    ''' <summary>
    ''' スコープの集合を定義します。
    ''' </summary>
    Public NotInheritable Class AggregationScope
        Inherits ActionScope(Of IEnumerable(Of IActionScope))

        Public Sub New( ParamArray target As IActionScope())
            MyBase.New(target)

        End Sub

        Public Sub New( target As IEnumerable(Of IActionScope))
            MyBase.New(target)

        End Sub

        Protected Overrides Function BeginScopeInternal() As Boolean
            For Each action As IActionScope In Me.Target
                If Not action.IsBegined Then
                    action.BeginAction()

                End If

            Next

            Return True

        End Function

        Protected Overrides Function EndScopeInternal() As Boolean
            For Each action As IActionScope In Me.Target
                action.Dispose()

            Next

            Return True

        End Function

    End Class

End Namespace