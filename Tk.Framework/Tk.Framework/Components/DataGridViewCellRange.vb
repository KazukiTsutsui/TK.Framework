Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Tk.Framework.Utility

#End Region

Namespace Components

    <DebuggerDisplay("{Me.ToString()}")>
    Public NotInheritable Class DataGridViewCellRange
        Implements IEquatable(Of DataGridViewCellRange)

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        Private _rowIndex As Integer
        Public ReadOnly Property RowIndex() As Integer
            Get
                Return Me._rowIndex
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        Private _colmunIndex As Integer
        Public ReadOnly Property ColmunIndex() As Integer
            Get
                Return Me._colmunIndex
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        Private _rowCount As Integer
        Public ReadOnly Property RowCount() As Integer
            Get
                Return Me._rowCount
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        Private _colCount As Integer
        Public ReadOnly Property ColmunCount() As Integer
            Get
                Return Me._colCount
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        Private _owner As DataGridView
        Public ReadOnly Property Owner() As DataGridView
            Get
                Return Me._owner
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)>
        Private _containsHeader As Boolean
        Public ReadOnly Property ContainsHeader() As Boolean
            Get
                Return Me._containsHeader
            End Get
        End Property


#End Region

        Public Sub New(owner As DataGridView, rowIndex As Integer, colIndex As Integer)
            Me.New(owner, rowIndex, colIndex, 1, 1)

        End Sub

        Public Sub New(owner As DataGridView, rowIndex As Integer, colmunIndex As Integer, rowCount As Integer, colmunCount As Integer)
            Me.New(owner, rowIndex, colmunIndex, rowCount, colmunCount, False)

        End Sub

        Public Sub New(owner As DataGridView, rowIndex As Integer, colmunIndex As Integer, rowCount As Integer, colmunCount As Integer, containsHeader As Boolean)
            ThrowHelper.IfIndexGreaterOfRangeThenThrow(0, rowIndex, NameOf(rowIndex))
            ThrowHelper.IfIndexGreaterOfRangeThenThrow(0, colmunIndex, NameOf(colmunIndex))
            ThrowHelper.IfIndexGreaterOfRangeThenThrow(1, rowCount, NameOf(rowCount))
            ThrowHelper.IfIndexGreaterOfRangeThenThrow(1, colmunCount, NameOf(colmunCount))

            Me._rowIndex = rowIndex
            Me._colmunIndex = colmunIndex
            Me._rowCount = rowCount
            Me._colCount = colmunCount
            Me._owner = owner
            Me._containsHeader = containsHeader

        End Sub


        Public Overrides Function Equals(obj As Object) As Boolean
            Return Me.Equals(TryCast(obj, DataGridViewCellRange))

        End Function

        Public Overloads Function Equals(other As DataGridViewCellRange) As Boolean Implements System.IEquatable(Of DataGridViewCellRange).Equals
            If other Is Nothing Then
                Return False

            End If

            If Not DataGridView.ReferenceEquals(Me.Owner, other.Owner) Then Return False
            If Me._rowIndex <> other.RowIndex Then Return False
            If Me._colmunIndex <> other.ColmunIndex Then Return False
            If Me._rowCount <> other.RowCount Then Return False
            If Me._colCount <> other.ColmunCount Then Return False
            Return True

        End Function

        Public Function ContainsCell(rowIndex As Integer, colIndex As Integer) As Boolean
            If IntegerPair.Contains(Me.ColmunIndex, Me.ColmunIndex + Me.ColmunCount, colIndex) Then
                If IntegerPair.Contains(Me.RowIndex, Me.RowIndex + Me.RowCount, rowIndex) Then
                    Return True

                End If

            End If

            Return False

        End Function

    End Class

End Namespace
