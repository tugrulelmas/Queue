FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY Abioka.Queue.Common/*.csproj ./Abioka.Queue.Common/
COPY Abioka.Queue.Sender/*.csproj ./Abioka.Queue.Sender/
RUN cd Abioka.Queue.Sender && dotnet restore

COPY Abioka.Queue.Common ./Abioka.Queue.Common/
COPY Abioka.Queue.Sender ./Abioka.Queue.Sender/
RUN cd Abioka.Queue.Sender && dotnet build

FROM build AS publish
WORKDIR /app/Abioka.Queue.Sender
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2.0-aspnetcore-runtime-alpine
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=publish /app/Abioka.Queue.Sender/out ./
ENTRYPOINT ["dotnet", "Abioka.Queue.Sender.dll"]