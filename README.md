# TEQWorld
## Задача 1:
### Инструкция по запуску

1. Для начала клонируйте репозиторий с гитхаба на свой ПК.
```bash
git clone https://github.com/japo0nn/TEQWorld.git
cd TEQWorld
```

2. Установите все зависимости:
```bash
dotnet restore
```

3. Скачайте SQlite

https://www.sqlite.org/download.html

4. Запуск проекта
```bash
dotnet run Web/Web.csproj
```

### Инструкция по тесту

5. Откройте страницу Swagger

http://localhost:5001/swagger

6. Найдите endpoint `api/items/upload` и загрзуите файл который находится по пути `/TEQWorld/Web/TEQ.xlsx`.

7. Используйте endpoint-ы `api/groups/get-all` и `api/groups/{id}` для получения списка групп(или получения группы по id). Важно заметить, если у вас еще не найдены группы товаров, подождите максимум 5 минут, возможно TaskManager с группировкой товаров уже запустился и придется подождать. (Или вы можете вручную поменять delay. Откройте файл класса по пути `TEQWorld/Infrastructure/HostedServices/GrouperTaskManager.cs` и поменяйте значение переменной _delay, к примеру на TimeSpan.FromSeconds(10), для более быстрой обработки товаров).


## Задача 2: 
  1. ИСП - 8/10
    - СКОР - 8/10
    - ПСР - 7/10
    - СРОК - 10/10
  2. КАЧ - 7/10
    -ДЕТ - 10/10
    -МШТ - 6/10
    -КЧР - 7/10
  4. ВАР - 8/10
    - ПРВ - 6/10
    - ИМПР - 10/10
    - ЭФФ - 7/10
  5. СОЦ - 8/10
    - ИНИЦ - 7/10
    - КОМ - 10/10
    - ВОВЛ - 8/10

Общее сред. значение: 7.75/10

## Задача 3:

![Результат 16personalities](images/16p.jpg)
