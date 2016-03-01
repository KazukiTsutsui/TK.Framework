Imports System

Namespace Utility

    ''' <summary>
    ''' 対となっている動作のスコープを定義します。
    ''' </summary>
    Public Interface IActionScope
        Inherits IDisposable

        ''' <summary>
        ''' 開始を試みます。
        ''' </summary>
        Function BeginAction() As Boolean

        ''' <summary>
        ''' コントロールの動作を実行可能か否かを取得します。
        ''' </summary>
        ''' <returns>True:実行可能。,False:実行不可。</returns>
        Function CanAction() As Boolean

        ''' <summary>
        ''' 開始済みか否かを取得します。
        ''' </summary>
        ''' <value>True:開始済み。,False:開始していない。</value>
        ReadOnly Property IsBegined() As Boolean

    End Interface

End Namespace