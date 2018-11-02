FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY Abioka.Queue.Common/*.csproj ./Abioka.Queue.Common/
COPY Abioka.Queue.Receiver/*.csproj ./Abioka.Queue.Receiver/
RUN cd Abioka.Queue.Receiver && dotnet restore

COPY Abioka.Queue.Common ./Abioka.Queue.Common/
COPY Abioka.Queue.Receiver ./Abioka.Queue.Receiver/
RUN cd Abioka.Queue.Receiver && dotnet build

FROM build AS publish
WORKDIR /app/Abioka.Queue.Receiver
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
COPY --from=publish /app/Abioka.Queue.Receiver/out ./
ENTRYPOINT ["dotnet", "Abioka.Queue.Receiver.dll"]