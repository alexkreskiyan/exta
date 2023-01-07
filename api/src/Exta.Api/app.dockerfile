FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as builder
COPY . /code
RUN dotnet publish -c release -o /app /code/src/api/Exta.Api

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
RUN apk --no-cache add msttcorefonts-installer fontconfig && \
    update-ms-fonts && \
    fc-cache -f
WORKDIR /app
COPY --from=builder /app /app
CMD ["/app/Exta.Api"]