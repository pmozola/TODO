call npm install src\client\todo\
dotnet restore src\api\todo.api\
dotnet build src\api\todo.api\
dotnet test src\api\ToDo.Domain.Tests
start /d "." dotnet run --project src\api\todo.api\ --port 4201
cd src\client\todo\src
ng serve