@ECHO OFF 
rmdir /s /q 3Infra\Migrations
dotnet ef database drop -p 3Infra -s API  --context DataSchemaContext -f
dotnet ef migrations add build1 -p 3Infra -s API --output-dir Migrations --context DataSchemaContext
dotnet ef database update -p 3Infra -s API --context DataSchemaContext
PAUSE
