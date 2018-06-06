
To auto-generate the models, copy and paste this command on the Package Manager Console with BehaviorAgencyData as selected project
> Scaffold-DbContext "Data Source=localhost\sqlexpress;Initial Catalog=BehaviorAgency_DB;Integrated Security=SSPI;" Microsoft.EntityFrameworkCore.SqlServer -Context DataContext -OutputDir Entities -DataAnnotations



