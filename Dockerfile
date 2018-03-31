FROM microsoft/dotnet:2.0.6-runtime
COPY ./publish/ /app
WORKDIR /app
EXPOSE 80/tcp
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "Clientes.Microservice.dll"]
