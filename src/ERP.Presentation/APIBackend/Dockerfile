#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ERP.Presentation/APIBackend/ERP.Presentation.APIBackend.csproj", "src/ERP.Presentation/APIBackend/"]
RUN dotnet restore "src/ERP.Presentation/APIBackend/ERP.Presentation.APIBackend.csproj"
COPY . .
WORKDIR "/src/ERP.Presentation.APIBackend"
WORKDIR "/src/src/ERP.Presentation/APIBackend"
RUN dotnet build "ERP.Presentation.APIBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ERP.Presentation.APIBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ERP.Presentation.APIBackend.dll"]