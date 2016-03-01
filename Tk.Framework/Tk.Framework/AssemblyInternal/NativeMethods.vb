''' <summary>
''' Win32API を定義します。
''' </summary>
Friend NotInheritable Class NativeMethods

#Region " Constructers "

    ''' <summary>
    ''' NativeMethods クラスの新しいインスタンスを初期化します。
    ''' このクラスはインスタンス化を許可しません。
    ''' </summary>
    ''' <exception cref="System.NotSupportedException">このクラスをインスタンス化した際に発生します。</exception>
    Private Sub New()
        ThrowHelper.NotSupportedConstructer(Of NativeMethods)()

    End Sub

#End Region

End Class