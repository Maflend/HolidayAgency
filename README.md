# ✨ HolidayAgency (Праздничное агенство) ✨
[![my profile](https://img.shields.io/badge/%3C%2F%3E%20with%20%E2%99%A5%20by-NHN_Cloud-ff1414.svg)](https://github.com/Maflend)

##  🚩 Features
### Сотрудник
- Вести учет мероприятий. От момента создания заказа до его закрытия.
- Управлять финансами.

### Посетитель
- Создать заказ.
- Просматривать мероприятия, отзывы, фотоотчеты.

<br>

## 📦 Packages

| Name | Reference |
|------|-----------|
| FluentValidation     |   https://github.com/FluentValidation/FluentValidation        |
| FluentResults     |  https://github.com/altmann/FluentResults         |
| MediatR     |  https://github.com/jbogard/MediatR         |
| AutoMapper     | https://github.com/AutoMapper/AutoMapper          |

<br>

## 🏬 Architecture
Архитектура построена по мотивам CleanArchitecture и VerticalSlises.
Архитектура конечных точек реализована с помощью Minimal api.

<br>

### ![HowToUse](https://github.com/Maflend/HolidayAgency/assets/59286805/d2af0cd1-0dd2-416d-a8d4-9363a7441267)

## 🚀 Запуск бэкенда:
<details><summary>Запуск docker compose</summary>
<br>
Запуск производится с помощью docker compose. <br>
Для запуска можно выбрать два варианта: <br>
- Docker Compose. Запуск всех контейнеров кроме pgadmin <br>
- Docker Compose With pgadmin. Запустит все контейнеры и pgadmin. Порт смотреть в docker-compose.yml
<br>
</details>

<details><summary>Подготовка базы данных</summary>
<br>
После поднятия базы данных, необходимо применить миграции к базе данных. <br>
Применение миграций: <br>
1. В качестве запускаемого проекта выбрать HA.Api. <br>
2. Открыть Package manager console. Выбрать проект HA.Infrastructure.EF. <br>
3. Написать команду <br>
  
```sh
update-database
```
<br>
4. Ждать применение миграций.
<br>
</details>

<br>
✨ v1.0 ✨
