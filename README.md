# Cvtex

To create migrations in custom folder execute command:
    dotnet ef  migrations add Initial -o ../Cvtex.Infrastructure/Migrations 
    
    --context EsportshubApi.Models.ApplicationDbContext - additional parameter when context is not define in project.

To create publication execute command:
    dotnet publish --configuration Release
go to directory /bin/Release/netcoreapp2.2
    dotnet Cvtex.Api.dll

Dockerfile jest to manifest w którym mówimy co ma się stać aby nasza aplikacja mogła się uruchomić

Jeśli chcielibyśmy zbudować obraz z innego pliku niż defaultowego wykonujemy komende:
    docker build -f Dockerfile.production -t cvtex-api .
    cvtex-api - co chcemy zbudować
    . - gdzie ma się znaleźć nasz docker file? (kropka)
    -t - tag czyli nazwa naszego obrazu

docker images

docker run -p 5000:5001 cvtex-api
    -p 5000:5001 - wystawiam aplikację na porcie publicznym 5000, działająca na porcie prywatnym 5001
