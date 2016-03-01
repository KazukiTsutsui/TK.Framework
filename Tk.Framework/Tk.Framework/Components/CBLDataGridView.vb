Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Drawing
Imports TK.Framework.Utility

#End Region

Namespace Components

    ''' <summary>
    ''' 
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class CBLDataGridView
        Inherits DataGridView


#Region " Constructers "

        ''' <summary>
        ''' <c>CBLDataGridView</c> クラスの新しいインスタンスを初期化します。
        ''' </summary>
        Public Sub New()
            MyBase.New()
            Me._isSetDefault = False
            Me.DoubleBuffered = True

        End Sub

#End Region

#Region " Overrides "

        Protected Overrides Sub OnCellPainting( e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor

            MyBase.OnCellPainting(e)

        End Sub


        Protected Overrides Sub OnScroll( e As System.Windows.Forms.ScrollEventArgs)
            MyBase.OnScroll(e)
            Me.Invalidate()

        End Sub

        Protected Overrides Sub OnResize( e As System.EventArgs)
            MyBase.OnResize(e)
            Me.Invalidate()

        End Sub

        Protected Overrides Sub OnPaint( e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            If Me._selectionSchema Is Nothing Then
                Return

            End If

            Dim g As Graphics = e.Graphics
            Dim arry As List(Of Rectangle) = Me.GetRangeDisplayRectangle()
            If CollectionService.HasItem(arry) Then
                For Each item As Rectangle In arry
                    Using pen As New Pen(Color.Blue, 2)
                        g.DrawRectangle(pen, item)
                        Me.Invalidate()

                    End Using

                Next

            End If

        End Sub

#End Region

    End Class

End Namespace
