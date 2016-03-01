Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports TK.Framework.Extensions
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System

Namespace Extensions

    ''' <summary>
    ''' Control 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Module ControlExtensions

        ''' <summary>
        ''' 自身を含む子のコントロールを全て取得します。
        ''' </summary>
        ''' <param name="target">対象のコントロール。</param>
        ''' <returns>自身を含む子のコントロールの配列。</returns>
        <Extension()> _
        Public Function GetAllControls( target As Control) As IEnumerable(Of Control)
            Dim result As New List(Of Control)
            result.Add(target)

            For Each child As Control In target.Controls
                result.AddRange(child.GetAllControls())

            Next

            Return result

        End Function

        <Extension()> _
        Public Function GetAllControlsWithoutParent( target As Control) As IEnumerable(Of Control)
            Dim result As List(Of Control) = DirectCast(target.GetAllControls(), List(Of Control))
            result.Remove(target)

            Return result

        End Function

        <Extension()> _
        Public Function IsDesignMode( target As Control) As Boolean
            Dim returnFlag As Boolean = False
            If (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                returnFlag = True

            ElseIf (Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV") _
                    OrElse Process.GetCurrentProcess().ProcessName.ToUpper().Equals("VCSEXPRESS")) Then
                returnFlag = True

            ElseIf (AppDomain.CurrentDomain.FriendlyName = "DefaultDomain") Then
                returnFlag = True

            End If

            Return returnFlag

        End Function


    End Module

End Namespace