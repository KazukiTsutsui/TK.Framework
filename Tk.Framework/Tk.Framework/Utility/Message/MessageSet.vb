Imports System.Windows.Forms
Imports System.Diagnostics
Imports System

Namespace Utility.Message

    ''' <summary>
    ''' メッセージボックスに表示する値を定義します。
    ''' このクラスは継承できません。
    ''' </summary>
    <DebuggerDisplay("タイトル:{Title},テキスト:{Text}")> _
    <Serializable()> _
    Public NotInheritable Class MessageSet
        Implements IMessageSet

#Region " Fields "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private Shared ReadOnly _comparer As StringComparer = StringComparer.CurrentCulture

        ''' <summary>
        ''' MessageSet クラスの空の値を取得します。
        ''' </summary>
        Public Shared ReadOnly Empty As New MessageSet()

#End Region

#Region " Constructers "

        ''' <summary>
        ''' MessageSet クラスの新しいインスタンスを初期化します。
        ''' </summary>
        Public Sub New()
        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' MessageSet クラスの大小を比較します。
        ''' </summary>
        ''' <param name="target1"></param>
        ''' <param name="target2"></param>
        ''' <returns></returns>
        Public Shared Function Compare( target1 As MessageSet,  target2 As MessageSet) As Integer
            SyncLock New Object
                Return _comparer.Compare(target1.Id, target2.Id)

            End SyncLock

        End Function

        Public Sub SetParameters( id As String, _
                                  text As String, _
                                  title As String, _
                                  buttons As MessageBoxButtons, _
                                  defaultButton As MessageBoxDefaultButton, _
                                  icon As MessageBoxIcon, _
                                  options As MessageBoxOptions, _
                                  displayHelpButton As Boolean)
            Me.Id = id
            Me.Text = text
            Me.Title = title
            Me.Buttons = buttons
            Me.DefaultButton = defaultButton
            Me.DisplayHelpButton = displayHelpButton
            Me.Icon = icon
            Me.Options = options

        End Sub

        ''' <summary>
        ''' 指定された MessageSet クラスのインスタンスと等しいかどうかを取得します。
        ''' </summary>
        ''' <param name="obj">比較するインスタンス。</param>
        ''' <returns>True:等しい。,False:等しくない。</returns>
        Public Overrides Function Equals( obj As Object) As Boolean
            Return Me.Equals(DirectCast(obj, MessageSet))

        End Function

#End Region

#Region " IMessageSet "

#Region " Properties "

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _id As String = String.Empty
        ''' <summary>
        ''' メッセージ固有のIDを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property Id() As String Implements IMessageSet.Id
            Get
                Return _id
            End Get
            Set( value As String)
                _id = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _text As String = String.Empty
        ''' <summary>
        ''' メッセージのテキストを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property Text() As String Implements IMessageSet.Text
            Get
                Return _text
            End Get
            Set( value As String)
                _text = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _title As String = String.Empty
        ''' <summary>
        ''' メッセージのタイトルを取得または設定します。
        ''' </summary>
        ''' <value></value>
        Public Property Title() As String Implements IMessageSet.Title
            Get
                Return _title
            End Get
            Set( value As String)
                _title = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _buttons As MessageBoxButtons
        ''' <summary>
        ''' メッセージに表示するボタンを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property Buttons() As MessageBoxButtons Implements IMessageSet.Buttons
            Get
                Return _buttons
            End Get
            Set( value As MessageBoxButtons)
                _buttons = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _icon As MessageBoxIcon
        ''' <summary>
        ''' メッセージに表示するアイコンを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property Icon() As MessageBoxIcon Implements IMessageSet.Icon
            Get
                Return _icon
            End Get
            Set( value As MessageBoxIcon)
                _icon = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _defaultButton As MessageBoxDefaultButton
        ''' <summary>
        ''' メッセージのデフォルトボタンを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property DefaultButton() As MessageBoxDefaultButton Implements IMessageSet.DefaultButton
            Get
                Return _defaultButton
            End Get
            Set( value As MessageBoxDefaultButton)
                _defaultButton = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _options As MessageBoxOptions
        ''' <summary>
        ''' メッセージのオプションを取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property Options() As MessageBoxOptions Implements IMessageSet.Options
            Get
                Return _options
            End Get
            Set( value As MessageBoxOptions)
                _options = value
            End Set
        End Property

        <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
        Private _displayHeplButton As Boolean
        ''' <summary>
        ''' メッセージのヘルプボタンの表示を取得または設定します。
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        Public Property DisplayHelpButton() As Boolean Implements IMessageSet.DisplayHelpButton
            Get
                Return _displayHeplButton
            End Get
            Set( value As Boolean)
                _displayHeplButton = value
            End Set
        End Property

#End Region

#Region " ICloneable "

        ''' <summary>
        ''' MessageSet クラスをコピーします。
        ''' </summary>
        ''' <returns>コピーした新しいインスタンス。</returns>
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim result As New MessageSet()
            result.Text = Me.Text
            result.Title = Me.Title
            result.Buttons = Me.Buttons
            result.DefaultButton = Me.DefaultButton
            result.DisplayHelpButton = Me.DisplayHelpButton
            result.Icon = Me.Icon
            result.Options = Me.Options

            Return result

        End Function

#End Region

#Region " IEquatable "

        ''' <summary>
        ''' 指定された MessageSet クラスのインスタンスと等しいかどうかを取得します。
        ''' </summary>
        ''' <param name="other">比較するインスタンス。</param>
        ''' <returns>True:等しい。,False:等しくない。</returns>
        Public Overloads Function Equals( other As IMessageSet) As Boolean Implements System.IEquatable(Of IMessageSet).Equals
            If other Is Nothing Then Return False

            If _comparer.Compare(Me.Id, other.Id) <> 0 Then Return False
            If Me.Buttons.Equals(other.Buttons) Then Return False
            If Me.DefaultButton.Equals(other.DefaultButton) Then Return False
            If Me.DisplayHelpButton.Equals(other.DisplayHelpButton) Then Return False
            If Me.Icon.Equals(other.Icon) Then Return False
            If Me.Options.Equals(other.Options) Then Return False
            If _comparer.Compare(Me.Text, other.Text) <> 0 Then Return False
            If _comparer.Compare(Me.Title, other.Title) <> 0 Then Return False

            Return True

        End Function

#End Region

#Region " IComparable "

        ''' <summary>
        ''' 指定された MessageSet クラスのインスタンスと比較します。
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        Public Function CompareTo( other As IMessageSet) As Integer Implements System.IComparable(Of IMessageSet).CompareTo
            If other Is Nothing Then Return -1
            Return _comparer.Compare(Me.Id, other.Id)

        End Function

#End Region

#End Region

    End Class

End Namespace