Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports System.Windows.Forms

#End Region

Namespace Components

    ''' <summary>
    ''' 
    ''' </summary>
    Public Interface ICblDataGridViewCellRangeSelection

        Function GetSelectionRange() As IEnumerable(Of DataGridViewCellRange)

    End Interface

    Public NotInheritable Class SingleRangeSelection
        Implements ICblDataGridViewCellRangeSelection

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _grd As CBLDataGridView

        Public Sub New( grd As CBLDataGridView)
            Me._grd = grd

        End Sub

        Public Function GetSelectionRange() As IEnumerable(Of DataGridViewCellRange) Implements ICblDataGridViewCellRangeSelection.GetSelectionRange
            Dim cells As DataGridViewSelectedCellCollection = Me._grd.SelectedCells
            Dim result As New List(Of DataGridViewCellRange)(cells.Count)
            For Each item As DataGridViewCell In cells
                result.Add(New DataGridViewCellRange(Me._grd, item.RowIndex, item.ColumnIndex))

            Next

            Return result

        End Function
    End Class

    Public NotInheritable Class RowRangeSelection
        Implements ICblDataGridViewCellRangeSelection

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _grd As CBLDataGridView

        Public Sub New( grd As CBLDataGridView)
            Me._grd = grd

        End Sub

        Public Function GetSelectionRange() As System.Collections.Generic.IEnumerable(Of DataGridViewCellRange) Implements ICblDataGridViewCellRangeSelection.GetSelectionRange
            Dim cells As DataGridViewSelectedCellCollection = Me._grd.SelectedCells
            Dim result As New List(Of DataGridViewCellRange)(cells.Count)
            Dim col As Integer = Me._grd.ColumnCount
            Me._grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For Each item As DataGridViewCell In cells
                result.Add(New DataGridViewCellRange(Me._grd, item.RowIndex, 0, 1, col, True))

            Next

            Return result

        End Function

    End Class

    Public NotInheritable Class CrossRangeSelection
        Implements ICblDataGridViewCellRangeSelection

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _grd As CBLDataGridView

        Public Sub New( grd As CBLDataGridView)
            Me._grd = grd

        End Sub

        Public Function GetSelectionRange() As System.Collections.Generic.IEnumerable(Of DataGridViewCellRange) Implements ICblDataGridViewCellRangeSelection.GetSelectionRange
            Dim cells As DataGridViewSelectedCellCollection = Me._grd.SelectedCells
            Dim result As New List(Of DataGridViewCellRange)(cells.Count)
            Dim col As Integer = Me._grd.ColumnCount
            Dim row As Integer = Me._grd.RowCount
            Me._grd.SelectionMode = DataGridViewSelectionMode.CellSelect

            For Each item As DataGridViewCell In cells
                result.Add(New DataGridViewCellRange(Me._grd, item.RowIndex, 0, 1, col))
                result.Add(New DataGridViewCellRange(Me._grd, 0, item.ColumnIndex, row, 1))

            Next

            Return result

        End Function

    End Class

End Namespace