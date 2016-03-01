Imports System.Collections.Generic

Namespace Utility.Message

    ''' <summary>
    ''' MessageSet クラスの一意となるキーを比較します。
    ''' </summary>
    Public Class MessageSetEqualityComparer
        Implements IEqualityComparer(Of IMessageSet)

        Public Overloads Function Equals( x As IMessageSet,  y As IMessageSet) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of IMessageSet).Equals
            Return x.Equals(y)

        End Function

        Public Function GetHashCode1( obj As IMessageSet) As Integer Implements System.Collections.Generic.IEqualityComparer(Of IMessageSet).GetHashCode
            Return obj.Id.GetHashCode()

        End Function

    End Class

End Namespace