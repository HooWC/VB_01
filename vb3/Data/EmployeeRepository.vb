Public Class EmployeeRepository
    Public Function GetAllEmployees() As List(Of Employee)
        Using db As New AppDbContext()
            Return db.Employees.ToList()
        End Using
    End Function

    Public Function AddEmployee(emp As Employee) As Boolean
        Using db As New AppDbContext()
            db.Employees.Add(emp)
            db.SaveChanges()
            Return True
        End Using
    End Function

    Public Function UpdateEmployee(emp As Employee) As Boolean
        Using db As New AppDbContext()
            Dim existing = db.Employees.Find(emp.EmployeeID)
            If existing IsNot Nothing Then
                existing.Name = emp.Name
                existing.Department = emp.Department
                existing.Salary = emp.Salary
                db.SaveChanges()
                Return True
            End If
            Return False
        End Using
    End Function

    Public Function DeleteEmployee(id As Integer) As Boolean
        Using db As New AppDbContext()
            Dim emp = db.Employees.Find(id)
            If emp IsNot Nothing Then
                db.Employees.Remove(emp)
                db.SaveChanges()
                Return True
            End If
            Return False
        End Using
    End Function
End Class
