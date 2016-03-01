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

#End Region

Namespace Components

    ''' <summary>
    ''' 
    ''' このクラスは継承できません。
    ''' </summary>
    Public NotInheritable Class DataGridViewCommander

#Region " Properties "

        Friend Shared ReadOnly AlternatingRowsDefaultCellStyleBackColor As Color = Color.PowderBlue
        Friend Shared ReadOnly RowsDefaultCellStyleBackColor As Color = Color.WhiteSmoke

#End Region

#Region " Constructers "

        ''' <summary>
        ''' <c>DataGridViewCommander</c> クラスの新しいインスタンスを生成します。
        ''' </summary>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of DataGridViewCommander)()

        End Sub

#End Region

#Region " Methods "

        Public Shared Sub SetDefault( grd As CBLDataGridView)
            grd.RowHeadersVisible = False
            grd.RowsDefaultCellStyle.BackColor = AlternatingRowsDefaultCellStyleBackColor
            grd.AlternatingRowsDefaultCellStyle.BackColor = RowsDefaultCellStyleBackColor
            grd.ClearSelection()

            With Nothing
                Dim style As DataGridViewCellStyle = grd.ColumnHeadersDefaultCellStyle
                style.Alignment = DataGridViewContentAlignment.MiddleCenter
                style.Font = New Font("MS UI Gothic", 10)

            End With

            With Nothing
                Dim style As DataGridViewCellStyle = grd.RowsDefaultCellStyle
                style.Font = New Font("ＭＳ ゴシック", 11)
                style.SelectionForeColor = SystemColors.ControlText
                style.SelectionBackColor = Color.Transparent

            End With
        
            grd.IsSetDefault = True

        End Sub

#End Region

    End Class

End Namespace
