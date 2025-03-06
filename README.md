```
EmployeeManagementSystem/
│── EmployeeManagementSystem.sln  # 解决方案文件
│── App.config                     # 数据库连接字符串配置
│── Models/
│   ├── Employee.vb                 # 员工类
│   ├── AppDbContext.vb             # 数据库上下文 (LINQ to SQL)
│── Forms/
│   ├── Form1.vb                    # 主要 UI 界面 (员工管理)
│── Data/
│   ├── EmployeeRepository.vb       # 业务逻辑层 (CRUD 操作)
│── bin/                            # 编译后的文件
│── obj/                            # 编译时的临时文件
```

### 安装 Entity Framework

```
CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Department NVARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL
);
```

```
<configuration>
  <connectionStrings>
    <add name="EmployeeDB"
         connectionString="Server=LAPTOP-75SCS0RS\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True"
         providerName="System.Data.SqlClient"/>
  </connectionStrings>
</configuration>
```

```
Imports System.Data.Entity

Public Class AppDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=EmployeeDB") ' 读取 App.config 的连接字符串
    End Sub

    Public Property Employees As DbSet(Of Employee)
End Class
```

### 