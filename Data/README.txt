To generate the database objects run the command bellow 

--dotnet ef dbcontext scaffold "Host=localhost;Database=ErikasBistro;Username=erikaBistroUser;Password=123456" Npgsql.EntityFrameworkCore.PostgreSQL -c ApplicationDbContext --force --output-dir .\Data