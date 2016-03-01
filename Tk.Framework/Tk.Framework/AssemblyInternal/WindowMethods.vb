Imports System.Runtime.InteropServices
Imports System

Partial NotInheritable Class NativeMethods

    ''' <summary>
    ''' 指定されたウィンドウを作成したスレッドの ID を取得します。必要であれば、ウィンドウを作成したプロセスの ID も取得できます。
    ''' </summary>
    ''' <param name="hWnd">ウィンドウのハンドルを指定します。</param>
    ''' <param name="ProcessId">
    ''' プロセス ID を受け取る変数へのポインタを指定します。
    ''' ポインタを指定すると、それが指す変数にプロセス ID がコピーされます。
    ''' null を指定した場合は、プロセス ID の取得は行われません。 </param>
    ''' <returns>ウィンドウを作成したスレッドの ID が返ります。</returns>
    <DllImport("user32.dll")> _
    Public Shared Function GetWindowThreadProcessId( hWnd As IntPtr,  ProcessId As IntPtr) As Integer
    End Function

    ''' <summary>
    ''' フォアグラウンドウィンドウ（ 現在ユーザーが作業しているウィンドウ）のハンドルを返します。
    ''' Windows システムは、フォアグラウンドウィンドウを生成したスレッドに対して、他のスレッドよりも若干高い優先順位を割り当てます。
    ''' </summary>
    ''' <returns>
    ''' フォアグラウンドウィンドウのハンドルが返ります。
    ''' フォアグラウンドウィンドウのハンドルは、ウィンドウがフォーカスを失ったなどの
    ''' 特定の状況下で null になる場合もあります。
    ''' </returns>
    <DllImport("user32.dll")> _
    Public Shared Function GetForegroundWindow() As IntPtr
    End Function

    ''' <summary>
    ''' 特定のスレッドの入力処理機構を別のスレッドにアタッチします。
    ''' </summary>
    ''' <param name="idAttach">
    ''' 別のスレッドにアタッチするスレッドの識別子を指定します。
    ''' システムスレッドをアタッチすることはできません。 </param>
    ''' <param name="idAttachTo">
    ''' アタッチ先スレッドの識別子を指定します。システムスレッドは指定できません。
    ''' スレッドをそれ自体にアタッチすることはできません。
    ''' そのため、idAttachTo と idAttach を同じにすることはできません。 
    ''' </param>
    ''' <param name="fAttach">
    ''' スレッドをアタッチするかデタッチするか指定します。
    ''' TRUE に設定すると、2 つのスレッドがアタッチされます。
    ''' FALSE に設定すると、スレッドがデタッチされます。 
    ''' </param>
    ''' <returns>
    ''' 関数が成功すると、0 以外の値が返ります。
    ''' 関数が失敗すると、0 が返ります。拡張エラー情報がないため、GetLastError 関数は使わないでください。
    ''' </returns>
    <DllImport("user32.dll")> _
    Public Shared Function AttachThreadInput( idAttach As Integer,  idAttachTo As Integer,  fAttach As Boolean) As Boolean
    End Function


End Class