# Stage 1: Build environment with .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

# Устанавлиаем рабочую директорию внутри контейнера
WORKDIR /app

# Копируем проектные файлы
COPY . .

# Восстанавливаем зависимости
RUN dotnet restore

# Сборка проекта
RUN dotnet build --configuration Release --no-restore

# Точка входа по умолчанию
CMD ["dotnet", "--version"]

