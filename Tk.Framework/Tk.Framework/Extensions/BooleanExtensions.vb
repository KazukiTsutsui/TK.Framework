Imports System.Runtime.CompilerServices

Namespace Extensions

    ''' <summary>
    ''' Boolean 型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Public Module BooleanExtensions

        ''' <summary>
        ''' 値が False か否かを取得します。
        ''' </summary>
        ''' <param name="target">対象の Boolen 型のインスタンス。</param>
        ''' <returns>True:False。,False:True。</returns>
        <Extension()> _
        Public Function IsFalse( target As Boolean) As Boolean
            Return Not target

        End Function

    End Module

End Namespace
