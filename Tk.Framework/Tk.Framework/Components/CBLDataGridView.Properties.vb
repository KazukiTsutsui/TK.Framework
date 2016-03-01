Option Strict On
Option Infer Off

#Region " Imports Drivers "

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Diagnostics

#End Region

Namespace Components

    Partial NotInheritable Class CBLDataGridView

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _selectionSchema As ICblDataGridViewCellRangeSelection
        Public ReadOnly Property SelectionSchema() As ICblDataGridViewCellRangeSelection
            Get
                Return _selectionSchema
            End Get
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _isSetDefault As Boolean
        Friend Property IsSetDefault() As Boolean
            Get
                Return Me._isSetDefault
            End Get
            Set( value As Boolean)
                Me._isSetDefault = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _useCustomSelectionMode As Boolean
        Public Property UseCustomSelectionMode() As Boolean
            Get
                Return _useCustomSelectionMode
            End Get
            Set( value As Boolean)
                _useCustomSelectionMode = value
            End Set
        End Property

#End Region

    End Class

End Namespace
