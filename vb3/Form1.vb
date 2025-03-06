Public Class Form1
    Private repo As New EmployeeRepository()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployees()
    End Sub

    Private Sub LoadEmployees()
        dgvEmployees.DataSource = repo.GetAllEmployees()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim emp As New Employee With {
            .Name = txtName.Text,
            .Department = txtDepartment.Text,
            .Salary = Decimal.Parse(txtSalary.Text)
        }
        repo.AddEmployee(emp)
        LoadEmployees()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvEmployees.SelectedRows.Count > 0 Then
            Dim emp As New Employee With {
                .EmployeeID = CInt(dgvEmployees.SelectedRows(0).Cells(0).Value),
                .Name = txtName.Text,
                .Department = txtDepartment.Text,
                .Salary = Decimal.Parse(txtSalary.Text)
            }
            repo.UpdateEmployee(emp)
            LoadEmployees()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEmployees.SelectedRows.Count > 0 Then
            Dim id As Integer = CInt(dgvEmployees.SelectedRows(0).Cells(0).Value)
            repo.DeleteEmployee(id)
            LoadEmployees()
        End If
    End Sub
End Class
