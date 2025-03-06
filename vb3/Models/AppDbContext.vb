Imports System.Data.Entity
Imports System.Runtime.Remoting.Contexts

Public Class AppDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=EmployeeDB") ' 读取 App.config 的连接字符串
    End Sub

    Public Property Employees As DbSet(Of Employee)
End Class
