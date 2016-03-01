Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics

#End Region

Namespace Utility

    ''' <summary>
    ''' 
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class CollectionService

#Region " Constructers "

        ''' <summary>
        ''' <c></c> クラスの新しいインスタンスを生成します。
        ''' </summary>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of CollectionService)()

        End Sub

#End Region

#Region " Methods "

        Public Shared Function HasItem( collection As ICollection) As Boolean
            Return collection IsNot Nothing AndAlso collection.Count > 0

        End Function

        Public Shared Function Count( collention As ICollection) As Integer
            Dim result As Integer = 0
            If collention Is Nothing Then
                result = collention.Count

            End If

            Return result
        End Function

#End Region

    End Class

End Namespace
