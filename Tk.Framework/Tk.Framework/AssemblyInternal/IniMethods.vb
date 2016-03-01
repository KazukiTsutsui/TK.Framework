Imports System.Runtime.InteropServices
Imports System.Text
Imports System

Partial NotInheritable Class NativeMethods

    <DllImport("KERNEL32.DLL")> _
    Public Shared Function GetPrivateProfileString( lpAppName As String,  lpKeyName As String,  lpDefault As String,  lpReturnedString As StringBuilder,  nSize As UInt32,  lpFileName As String) As UInt32
    End Function

    <DllImport("KERNEL32.DLL", EntryPoint:="GetPrivateProfileStringA")> _
    Public Shared Function GetPrivateProfileStringByByteArray( lpAppName As String,  lpKeyName As String,  lpDefault As String,  lpReturnedString As Byte(),  nSize As UInt32,  lpFileName As String) As UInt32
    End Function

    <DllImport("KERNEL32.DLL")> _
    Public Shared Function GetPrivateProfileInt( lpAppName As String,  lpKeyName As String,  nDefault As Integer,  lpFileName As String) As UInt32
    End Function

End Class