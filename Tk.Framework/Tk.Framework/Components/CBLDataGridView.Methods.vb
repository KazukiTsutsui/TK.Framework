Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports TK.Framework.Utility

#End Region

Namespace Components

    Partial NotInheritable Class CBLDataGridView

#Region " PublicMethods "

        Public Sub SetSelectionRange(selectionSchema As ICblDataGridViewCellRangeSelection)
            If selectionSchema Is Nothing Then
                Throw New ArgumentNullException("selectionSchema")

            End If

            Me._selectionSchema = selectionSchema

        End Sub

        Public Function GetRowRangeDisplayRectangle(rowIndex As Integer, startColIndex As Integer, colCount As Integer) As Rectangle
            Dim lst As New List(Of Rectangle)(colCount)

            For j As Integer = rowIndex To colCount
                lst.Add(Me.GetCellDisplayRectangle(startColIndex, j, False))

            Next

            Return lst.Aggregate(AddressOf Rectangle.Union)

        End Function

        Public Function GetCellRangeDisplayRectangle(range As DataGridViewCellRange) As Rectangle
            Dim starting As RangeResult = Me.GetDisplayStartingCellRectangle(range)

            Dim width As Integer = starting.Rectangle.Width
            Dim height As Integer = starting.Rectangle.Height

            For j As Integer = starting.Row + 1 To range.RowCount + range.RowIndex - 1
                height += Me.GetCellDisplayRectangle(range.ColmunIndex, j, False).Height

            Next

            For j As Integer = starting.Col + 1 To range.ColmunCount + range.ColmunIndex - 1
                width += Me.GetCellDisplayRectangle(j, range.RowIndex, False).Width

            Next

            Return New Rectangle(starting.Rectangle.Location, New Size(width, height))

        End Function


#End Region

#Region " InternalMethods "

        Private Function GetDisplayStartingCellRectangle(range As DataGridViewCellRange) As RangeResult
            ThrowHelper.IfNullArgumentThenThrow(range, NameOf(range))

            Dim row As Integer = range.RowIndex
            Dim col As Integer = range.ColmunIndex

            If Me(col, row).Displayed Then
                Return New RangeResult(row, col, Me.GetCellDisplayRectangle(col, row, False))

            End If

            Dim first As DataGridViewCell = Me.FirstDisplayedCell
            If first IsNot Nothing Then

                Dim containsRow As Boolean = IntegerPair.Contains(row, range.RowCount - 1, first.RowIndex)
                Dim containsCol As Boolean = IntegerPair.Contains(col, range.ColmunCount - 1, first.ColumnIndex)

                If containsRow AndAlso containsCol Then
                    Return New RangeResult(first.RowIndex, first.ColumnIndex, Me.GetCellDisplayRectangle(first.ColumnIndex, first.RowIndex, False))

                End If

                If containsRow Then
                    Return New RangeResult(first.RowIndex, col, Me.GetCellDisplayRectangle(col, first.RowIndex, False))

                End If

                If containsCol Then
                    Return New RangeResult(row, range.ColmunIndex, Me.GetCellDisplayRectangle(first.ColumnIndex, row, False))

                End If

            End If

            Return RangeResult.Empty

        End Function

        Private Function GetRangeDisplayRectangle() As List(Of Rectangle)
            Dim ranges As IEnumerable(Of DataGridViewCellRange) = Me._selectionSchema.GetSelectionRange()
            If CollectionService.HasItem(TryCast(ranges, ICollection)) Then
                Dim arry As New List(Of Rectangle)(ranges.Count - 1)
                For i As Integer = 0 To ranges.Count - 1
                    Dim range As Rectangle = Me.GetCellRangeDisplayRectangle(ranges(i))
                    range.Size = New Size(range.Size.Width - 1, range.Size.Width - 1) '微調整
                    arry.Add(range)

                Next

                Return arry

            End If

            Return Nothing

        End Function

#End Region

    End Class

End Namespace
