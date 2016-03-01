Imports System
Imports Microsoft.VisualBasic

Namespace Utility

    ''' <summary>
    ''' スナップショットの基本的な機能を提供します。
    ''' </summary>
    Public Interface ISnapShot

        ''' <summary>
        ''' スナップショットをリセットします。
        ''' </summary>
        Sub Reset()

        ''' <summary>
        ''' スナップショットを保存します。
        ''' </summary>
        Sub Shot()

        ''' <summary>
        ''' 保存した値から変更があったか否かを検証します。
        ''' </summary>
        ''' <returns></returns>
        Function Validate() As Boolean

        ''' <summary>
        ''' スナップショットの対象となるインスタンスを取得します。
        ''' </summary>
        ''' <returns></returns>
        Function GetInstanse() As Object

        Sub Raise()

    End Interface

End Namespace
