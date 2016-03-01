Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports System.Diagnostics

Namespace Components

    ''' <summary>
    ''' スプリッターに色の入った SplitContainer を定義します。
    ''' </summary>
    Public NotInheritable Class HighLightSplitContainer
        Inherits SplitContainer

#Region " Constructers "

        ''' <summary>
        ''' HighLightSplitContainer クラスの新しいインスタンスを初期化します。
        ''' </summary>
        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.ResizeRedraw, True)

        End Sub

#End Region

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _splitColor As Color = Color.Silver
        ''' <summary>
        ''' スプリッターの色を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        <Description("スプリッターの色を取得または設定します。")> _
        <DefaultValue(GetType(Color), "Color.Silver")> _
        Public Property SplitColor() As Color
            Get
                Return _splitColor
            End Get
            Set( value As Color)
                _splitColor = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _isChangeSplitColor As Boolean = True
        ''' <summary>
        ''' スプリッターの色を変更するか否かを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns>True:設定します。,False:設定しません。</returns>
        <Description("スプリッターの色を変更するか否かを取得または設定します。")> _
        <DefaultValue(GetType(Boolean), "True")> _
        Public Property IsChangeSplitColor() As Boolean
            Get
                Return _isChangeSplitColor
            End Get
            Set( value As Boolean)
                _isChangeSplitColor = value
            End Set
        End Property

#End Region

#Region " Methods "

        Protected Overrides Sub OnPaint( e As System.Windows.Forms.PaintEventArgs)
            If Me.IsChangeSplitColor AndAlso Me.Visible Then
                Dim g As Graphics = e.Graphics
                Using p As Pen = New Pen(Me.SplitColor, Me.SplitterWidth)
                    g.DrawRectangle(p, Me.SplitterRectangle)

                End Using

            End If

            MyBase.OnPaint(e)

        End Sub

        Protected Overrides Sub OnResize( e As System.EventArgs)
            MyBase.OnResize(e)

        End Sub

#End Region

    End Class

End Namespace

