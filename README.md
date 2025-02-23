# OrderApp


## Содержание

- [Описание](#описание)
- [Стек](#стек)
- [Установка](#установка)
- [База данных](#база-данных)

## Описание

WebApi приложение для фильтрации заказов по району и времени доставки.

Параметры можно задать вручную, но также в конфигурационном файле установлены значения по умолчанию (Район - "Central", Время первой доставки - 01.01.2024 12:30:00)


## Стек:

•	C#

•	PostgreSQL

•	ASP.NET Core

•	Dapper

•	Npgsql

## Установка

1. Клонируйте репозиторий:
   
   ```bash
   git clone https://github.com/cyber1311/OrderApp.git

2. Перейдите в директорию проекта:

   ```bash
   cd OrderApp

3. Создайте базу данных по схеме из файла scrips/init.sql

4. Настройте подключение к базе данных в файле appsettings.json.

5. Запустите приложение:

   ```bash
   dotnet run

## База данных

![Модель базы данных](<db_model.png>)

В таблице districts хранятся все районы, в которые поступают заказы. На данный момент там есть записи о пяти районах.

В таблице orders хранятся все заказы. На данный момент она заполнена 53 записями.

Таблица delivery_log хранит логи.

В таблицу delivery_order записывается результат фильтрации.