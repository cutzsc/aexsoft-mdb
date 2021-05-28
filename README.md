# aexsoft-mdb

## Creating Project

Commands (PowerShell):  
dotnet new sln -o aexsoft-mdb  
dotnet new globaljson --sdk-version 3.1.101 --output aexsoft-mdb/aexsoft-mdb  
dotnet new web --no-https --output aexsoft-mdb/aexsoft-mdb --framework netcoreapp3.1  
dotnet sln aexsoft-mdb add aexsoft-mdb/aexsoft-mdb

dotnet new xunit -o aexsoft-mdb/aexsoft-mdb.Tests --framework netcoreapp3.1  
dotnet sln aexsoft-mdb add aexsoft-mdb/aexsoft-mdb.Tests

Packages:  
dotnet add aexsoft-mdb/aexsoft-mdb.Tests package Moq  
dotnet add aexsoft-mdb/aexsoft-mdb package Microsoft.EntityFrameworkCore.Design  
dotnet add aexsoft-mdb/aexsoft-mdb package Microsoft.EntityFrameworkCore.SqlServer  

## Entities

![model](https://github.com/cutzsc/aexsoft-mdb/blob/main/images/Entities.png?raw=true)

## Release

http://aexsoft-mdb.azurewebsites.net/