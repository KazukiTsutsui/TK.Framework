Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics

#End Region

Namespace Temp

    ''' <summary>
    ''' インスタンスのプール機能を提供します。
    ''' </summary>
    Public MustInherit Class InstancePool(Of TKey, TValue)

#Region " Fields "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _instanceCache As Dictionary(Of TKey, TValue)

#End Region

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _maxCapacity As Integer
        Public Property MaxCapacity() As Integer
            Get
                Return _maxCapacity
            End Get
            Set( value As Integer)
                _maxCapacity = value
            End Set
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' <c>InstancePool</c> クラスの新しいインスタンスを生成します。
        ''' </summary>
        Protected Sub New( capacity As Integer)
            Me._maxCapacity = capacity
            Me._instanceCache = New Dictionary(Of TKey, TValue)(capacity)

        End Sub

#End Region

#Region " Methods "

        Public Function GetValue( key As TKey) As TValue
            Dim cache As Dictionary(Of TKey, TValue) = Me._instanceCache
            If Not cache.ContainsKey(key) Then
                Me.TrimInstance()

                Dim value As TValue = Me.GetInstanceFromKey(key)
                cache.Add(key, value)

            End If

            Return cache(key)

        End Function

        Protected MustOverride Function GetInstanceFromKey( key As TKey) As TValue

        Public Function Release( key As TKey) As Boolean
            Return Me._instanceCache.Remove(key)

        End Function

        ''' <summary>
        ''' 最大容量を超えている場合に、インスタンスの数を調整します。
        ''' </summary>
        Private Sub TrimInstance()
            If Me.MaxCapacity = -1 Then
                Return

            End If

            Dim cache As Dictionary(Of TKey, TValue) = Me._instanceCache
            For i As Integer = cache.Count To Me.MaxCapacity Step -1
                'null がキーになることはない。
                Dim removeKey As TKey = cache.FirstOrDefault().Key
                cache.Remove(removeKey)

            Next

        End Sub

#End Region

    End Class

End Namespace
