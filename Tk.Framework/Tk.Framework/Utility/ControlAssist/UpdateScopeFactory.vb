Option Strict On
Option Infer Off

Imports TK.Framework.Extensions
Imports System.Reflection
Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic

Namespace Utility.ControlAssist

    ''' <summary>
    ''' コントロールの描画停止処理のスコープを定義します。
    ''' </summary>
    Public NotInheritable Class UpdateScopeFactory

#Region " Constructers "

        ''' <summary>
        ''' BeginUpdateScopeFactory クラスの新しいインスタンスを初期化します。
        ''' このクラスは、インスタンス化を許可しません。
        ''' </summary>
        ''' <exception cref="NotSupportedException">このクラスをインスタンス化した際に発生します。</exception>
        Private Sub New()
            ThrowHelper.NotSupportedConstructer(Of UpdateScopeFactory)()

        End Sub

#End Region

#Region " Methods "

        ''' <summary>
        ''' Control クラスの描画処理のスコープを取得します。
        ''' </summary>
        ''' <param name="target">描画処理を行うコントロール。</param>
        ''' <returns>描画処理のスコープを返します。</returns>
        Public Shared Function Create( target As Control) As IActionScope
            Return New ControlUpdateInternal(target)

        End Function

        ''' <summary>
        ''' ComboBox クラスの描画処理のスコープを取得します。
        ''' </summary>
        ''' <param name="target">描画処理を行う ComboBox 。</param>
        ''' <returns>描画処理のスコープを返します。</returns>
        Public Shared Function Create( target As ComboBox) As IActionScope
            Return New ComboBoxUpdateInternal(target)

        End Function

        ''' <summary>
        ''' ListView クラスの描画処理のスコープを取得します。
        ''' </summary>
        ''' <param name="target">描画処理を行う ListView 。</param>
        ''' <returns>描画処理のスコープを返します。</returns>
        Public Shared Function Create( target As ListView) As IActionScope
            Return New ListViewUpdateInternal(target)

        End Function

        ''' <summary>
        ''' ListBox クラスの描画処理のスコープを取得します。
        ''' </summary>
        ''' <param name="target">描画処理を行う ListBox 。</param>
        ''' <returns>描画処理のスコープを返します。</returns>
        Public Shared Function Create( target As ListBox) As IActionScope
            Return New ListBoxUpdateInternal(target)

        End Function

        ''' <summary>
        ''' TreeView クラスの描画処理のスコープを取得します。
        ''' </summary>
        ''' <param name="target">描画処理を行う TreeView 。</param>
        ''' <returns>描画処理のスコープを返します。</returns>
        Public Shared Function Create( target As TreeView) As IActionScope
            Return New TreeViewUpdateInternal(target)

        End Function

#End Region

#Region " Internal Classes "

        ''' <summary>
        ''' ComboBox の描画処理のスコープを定義します。
        ''' このクラスは継承できません。
        ''' </summary>
        Private NotInheritable Class ComboBoxUpdateInternal
            Inherits ControlActionScope(Of ComboBox)

#Region " Constructers "

            Public Sub New( target As ComboBox)
                MyBase.New(target)

            End Sub

#End Region

#Region " Methods "

            Protected Overrides Function BeginScopeInternal() As Boolean
                Me.Target.BeginUpdate()
                Return True

            End Function

            Protected Overrides Function EndScopeInternal() As Boolean
                Me.Target.EndUpdate()
                Return True

            End Function

#End Region

        End Class

        ''' <summary>
        ''' ListView の描画処理のスコープを定義します。
        ''' このクラスは継承できません。
        ''' </summary>
        Private NotInheritable Class ListViewUpdateInternal
            Inherits ControlActionScope(Of ListView)

#Region " Constructers "

            Public Sub New( target As ListView)
                MyBase.New(target)

            End Sub

#End Region

#Region " Methods "

            Protected Overrides Function BeginScopeInternal() As Boolean
                Me.Target.BeginUpdate()
                Return True

            End Function

            Protected Overrides Function EndScopeInternal() As Boolean
                Me.Target.EndUpdate()
                Return True

            End Function

#End Region

        End Class

        ''' <summary>
        ''' ListBox の描画処理のスコープを定義します。
        ''' このクラスは継承できません。
        ''' </summary>
        Private NotInheritable Class ListBoxUpdateInternal
            Inherits ControlActionScope(Of ListBox)

#Region " Constructers "

            Public Sub New( target As ListBox)
                MyBase.New(target)

            End Sub

#End Region

#Region " Methods "

            Protected Overrides Function BeginScopeInternal() As Boolean
                Me.Target.BeginUpdate()
                Return True

            End Function

            Protected Overrides Function EndScopeInternal() As Boolean
                Me.Target.EndUpdate()
                Return True

            End Function

#End Region

        End Class

        ''' <summary>
        ''' TreeView の描画処理のスコープを定義します。
        ''' このクラスは継承できません。
        ''' </summary>
        Private NotInheritable Class TreeViewUpdateInternal
            Inherits ControlActionScope(Of TreeView)

#Region " Constructers "

            Public Sub New( target As TreeView)
                MyBase.New(target)

            End Sub

#End Region

#Region " Methods "

            Protected Overrides Function BeginScopeInternal() As Boolean
                Me.Target.BeginUpdate()
                Return True

            End Function

            Protected Overrides Function EndScopeInternal() As Boolean
                Me.Target.EndUpdate()
                Return True

            End Function

#End Region

        End Class

        ''' <summary>
        ''' Control の描画処理のスコープを定義します。
        ''' このクラスは継承できません。
        ''' </summary>
        Private NotInheritable Class ControlUpdateInternal
            Inherits ControlActionScope(Of Control)

#Region " Constructers "

            Public Sub New( target As Control)
                MyBase.New(target)

            End Sub

#End Region

#Region " Methods "

            Protected Overrides Function BeginScopeInternal() As Boolean
                Dim t As Type = Me.Target.GetType()
                Dim mi As MethodInfo = t.GetMethod("BeginUpdateInternal", BindingFlags.IgnoreCase Or BindingFlags.NonPublic Or BindingFlags.Instance)
                mi.Invoke(Me.Target, Nothing)
                If mi Is Nothing Then
#If DEBUG Then
                    Throw New NotImplementedException(" BeginUpdateInternal が実装されていない？")

#End If
                    Return False

                End If

                Return True

            End Function

            Protected Overrides Function EndScopeInternal() As Boolean
                Dim t As Type = Me.Target.GetType()
                Dim mi As MethodInfo = t.GetMethod("EndUpdateInternal", BindingFlags.IgnoreCase Or BindingFlags.NonPublic Or BindingFlags.Instance, Type.DefaultBinder, New Type() {}, Nothing)
                If mi Is Nothing Then
#If DEBUG Then
                    Throw New NotImplementedException(" EndUpdateInternal が実装されていない？")

#End If
                    Return False

                End If

                mi.Invoke(Me.Target, Nothing)

                Return True

            End Function

#End Region

        End Class

#End Region

    End Class

End Namespace