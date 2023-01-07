FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as builder
COPY . /code
RUN dotnet publish -c release -o /app /code/api/src/Exta.Api

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
RUN apk --no-cache add msttcorefonts-installer fontconfig && \
    update-ms-fonts && \
    fc-cache -f
WORKDIR /app
COPY --from=builder /app /app
CMD ["/app/Exta.Api"]