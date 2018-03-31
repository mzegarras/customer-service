FROM microsoft/dotnet:2.0.6-runtime
COPY ./netcoreapp2.0/ /app
WORKDIR /app
EXPOSE 80/tcp
ENV ASPNETCORE_URLS http://*:80
ENTRYPOINT ["dotnet", "Clientes.Microservice.dll"]
