FROM  microsoft/dotnet:sdk as builder

WORKDIR /src

COPY . ./
RUN dotnet publish -c Release -o pub

#

FROM  microsoft/dotnet:2.1-sdk

WORKDIR /src

COPY --from=builder /src/Presentation/src/pub .

EXPOSE 5111

CMD ["dotnet", "./Presentation.dll"]