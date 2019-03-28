# Тестовый проект с EventFlow

| CI Service | Status |
|------------|:------:|
| AppVeyor   | [![Build status](https://ci.appveyor.com/api/projects/status/by9po0yr2huqte90?svg=true)](https://ci.appveyor.com/project/castlerek/eventflow-testing) |

В данном тестовом проекте происходят следующие действия:
1. команда отправляется в агрегат с идентификатором `aggregateId` и химической формулой Триптофана (как пример)
2. после публикации команды - происходит выборка модели чтения
3. в тесте проверяем, что химическая формула - достигла данную модель чтения
