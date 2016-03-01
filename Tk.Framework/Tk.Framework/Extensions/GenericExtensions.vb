Imports System.Runtime.CompilerServices

Namespace Extensions

    ''' <summary>
    ''' ジェネリックな型の拡張メソッド群を提供します。
    ''' </summary>
    <Microsoft.VisualBasic.HideModuleName()> _
    Module GenericExtensions

        ''' <summary>
        ''' 対象のインスタンスが null か否かを取得します。
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="target"></param>
        ''' <returns>True:null 。,False:null でない。</returns>
        <Extension()> _
        Public Function IsNull(Of T)( target As T) As Boolean
            Return target Is Nothing

        End Function

        ''' <summary>
        ''' 対象のインスタンスが null ではないか否かを取得します。
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="target"></param>
        ''' <returns>True:null でない。,False:null 。</returns>
        <Extension()> _
        Public Function IsNotNull(Of T)( target As T) As Boolean
            Return target IsNot Nothing

        End Function

    End Module

End Namespace