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
    ''' IEnumerable または IEnumerable(Of T) を実装したインスタンスの静的な補助メソッドを提供します。
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class EnumerableSetvice

#Region " Constructers "

        ''' <summary>
        ''' <c>EnumerableHelper</c> クラスの新しいインスタンスを生成します。
        ''' </summary>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of EnumerableSetvice)()

        End Sub

#End Region

#Region " Methods "

        Public Shared Function HasItem(Of T)(target As IEnumerable(Of T)) As Boolean
            Return target IsNot Nothing AndAlso target.Count > 0

        End Function

#End Region

    End Class

End Namespace
