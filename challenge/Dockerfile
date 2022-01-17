FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY bin/Release/net6.0/publish/ App/
EXPOSE 80
EXPOSE 7258
WORKDIR /App
ENTRYPOINT ["dotnet", "challenge.dll"]
