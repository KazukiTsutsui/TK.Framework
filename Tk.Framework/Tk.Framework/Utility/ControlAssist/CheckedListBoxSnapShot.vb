Option Strict On
Option Infer Off

Imports System.Windows.Forms
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' CheckedListBox のスナップショット機能を提供します。
    ''' </summary>
    ''' <typeparam name="TItem"></typeparam>
    Public NotInheritable Class CheckedListBoxSnapShot(Of TItem)
        Inherits SnapShotBase(Of CheckedListBox, TItem())

#Region " Constructers "

        ''' <summary>
        ''' CheckedListBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' 既定の演算子を用いて比較します。
        ''' </summary>
        ''' <param name="target">対象となる CheckedListBox 。</param>
        Public Sub New( target As CheckedListBox)
            Me.New(target, New CheckedListBoxSnapShot(Of TItem).DefaultComparer(EqualityComparer(Of TItem).Default))

        End Sub

        ''' <summary>
        ''' CheckedListBoxSnapShot クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="target">対象となる CheckedListBox 。</param>
        ''' <param name="comparer">比較演算子。</param>
        Public Sub New( target As CheckedListBox,  comparer As IEqualityComparer(Of TItem()))
            MyBase.New(target, comparer)

        End Sub

#End Region

        Protected Overrides Function GetParameter() As TItem()
            Return Me.Target.SelectedItems.OfType(Of TItem)().ToArray()

        End Function

#Region " InnerClasses "

        ''' <summary>
        ''' CheckedListBoxSnapShot クラスの既定の比較演算子を提供します。
        ''' </summary>
        Public NotInheritable Class DefaultComparer
            Implements IEqualityComparer(Of TItem())

#Region " Fields "

            <DebuggerBrowsable(DebuggerBrowsableState.Never)> _
            Private _elementComparer As IEqualityComparer(Of TItem)

#End Region

#Region " Constructers "

            ''' <summary>
            ''' DefaultComparer クラスの新しいインスタンスを初期化します。
            ''' </summary>
            ''' <param name="elementComparer">要素の比較演算子。</param>
            Public Sub New( elementComparer As IEqualityComparer(Of TItem))
                ThrowHelper.IfNullArgumentThenThrow(elementComparer, NameOf(elementComparer))
                Me._elementComparer = elementComparer

            End Sub

#End Region

#Region " Methods "

            Public Overloads Function Equals( x As TItem(),  y As TItem()) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of TItem()).Equals
                Dim isXnull As Boolean = x Is Nothing
                Dim isYnull As Boolean = y Is Nothing

                If isXnull AndAlso isYnull Then Return True '両方Nothingならば等価。
                If isXnull OrElse isYnull Then Return False '片方がNothingならば等価でない。
                If x.Count <> y.Count Then Return False '数が違えば等価ではない。

                For i As Integer = 0I To x.Count - 1
                    If Not Me._elementComparer.Equals(x(i), y(i)) Then
                        Return False

                    End If

                Next

                Return True

            End Function

            Public Overloads Function GetHashCode( obj As TItem()) As Integer Implements System.Collections.Generic.IEqualityComparer(Of TItem()).GetHashCode
                Return obj.GetHashCode()

            End Function

#End Region

        End Class

#End Region

    End Class

End Namespace
