Imports System
Imports System.Diagnostics

Namespace Utility

    ''' <summary>
    ''' フィールド名を定義します。
    ''' </summary>
    <AttributeUsage(AttributeTargets.Field)> _
    <DebuggerDisplay("Name = {Name}")> _
    Public NotInheritable Class FieldLabelAttribute
        Inherits Attribute

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _name As String
        ''' <summary>
        ''' フィールド名を取得します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public ReadOnly Property Name() As String
            Get
                Return Me._name
            End Get
        End Property

#End Region

#Region " Constructers "

        ''' <summary>
        ''' FieldLabelAttribute クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="name">名前を指定します。</param>
        Public Sub New( name As String)
            Me._name = name

        End Sub

#End Region

    End Class

End Namespace