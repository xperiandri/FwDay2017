## Запуск проектов
Все демо созданы в Visual Studio 2017 на новом csproj для MSBuild 15

## Демо 1 - [SwashBuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

## Демо 2 - [Microsoft ASP.NET API Versioning](https://github.com/Microsoft/aspnet-api-versioning)

## Демо 3 - SwashBuckle + ASP.NET API Versioning
Чтобы запустить Демо 3 нужно скачать репозиторий [SwashBuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) и подключить 3 проекта из него в решение. Какие проекты будет понятно их отстутсвующих проектов в решении.
Это связано с ошибкой в Swashbuckle.AspNetCore версий 1.0.0-rc2 и 1.0.0-rc3

Запустив Demo3Start вы сможете посмотреть почему SwashBuckle так просто не работает с API Versioning

## Демо 4 - генерация кода из swagger.json
Для генерации клиента нужно в контекстном меню проекта выбрать Add/REST API Client... и дать ему схему swagger.json