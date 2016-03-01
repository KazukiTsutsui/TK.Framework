Option Strict On
Option Infer Off

Imports System.Windows.Forms
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' ComboBox の選択テキストのスナップショット機能を提供します。
    ''' </summary>
    Public NotInheritable Class ComboBoxSelectedTextSnapShot
        Inherits SnapShotBase(Of ComboBox, String)

        ''' <summary>
        ''' ComboBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' 選択テキストを大小区別して比較します。
        ''' </summary>
        ''' <param name="target">対象の ComboBox 。</param>
        Public Sub New( target As ComboBox)
            Me.New(target, StringComparer.CurrentCulture)

        End Sub

        ''' <summary>
        ''' ComboBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象の ComboBox 。</param>
        ''' <param name="comparer">選択テキストの比較演算子。</param>
        Public Sub New( target As ComboBox,  comparer As StringComparer)
            MyBase.New(target, comparer)

        End Sub

        Protected Overrides Function GetParameter() As String
            Return Me.Target.SelectedText

        End Function

    End Class

    ''' <summary>
    ''' ComboBox の選択アイテムのスナップショット機能を提供します。
    ''' </summary>
    ''' <typeparam name="TParam"></typeparam>
    Public NotInheritable Class ComboBoxItemSnapShot(Of TParam)
        Inherits SnapShotBase(Of ComboBox, TParam)

        ''' <summary>
        ''' ComboBoxItemSnapShot(Of TParam) クラスの新しいインスタンスを初期化します。
        ''' 選択オブジェクトを既定の演算子で比較します。
        ''' </summary>
        ''' <param name="target">対象の ComboBox 。</param>
        Public Sub New( target As ComboBox)
            Me.New(target, EqualityComparer(Of TParam).Default)

        End Sub

        ''' <summary>
        ''' ComboBoxItemSnapShot(Of TParam) クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象の ComboBox 。</param>
        ''' <param name="comparer"></param>
        ''' <remarks></remarks>
        Public Sub New( target As ComboBox,  comparer As IEqualityComparer(Of TParam))
            MyBase.New(target, comparer)

        End Sub

        Protected Overrides Function GetParameter() As TParam
            Return DirectCast(Me.Target.SelectedItem, TParam)

        End Function

    End Class

End Namespace

