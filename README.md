# Design Camp Tasks

## Правила

1. Сделайте fork этого репозитория. Раздайте права на него всем членам своей команды.
2. Каждый push в master этого форка будет считаться отправкой решения на проверку.
3. Текущее состояние игры доступно в виде Json тут: https://design-camp.firebaseio.com/camp.json Можете написать код по скачиванию, парсингу и красивому отображению любых данных из этого json-а. Либо можете поставить расширение JSONView к своему браузеру, для более комфортного просмотра этого json-а.
4. Ваша цель — набирать релизные баллы! Они набираются во время так называемых "релизов".
5. "Релизы" происходят периодически, примерно раз в 10 минут. В кашим релизным баллам прибавляются баллы, заработанные последней на момент релиза версией вашего решения. 
Другими словами, если запушить некорректные правки, то в ближайший релиз можно сильно огрести. Всё как в жизни!

## Вам нельзя

* менять имена трех уже созданных проектов, и пути их сборки. Иначе проверяющая система не сможет найти exe-файлы для проверки.
* существенно менять csproj файлы проектов. Это может помешать проверяющей системе собрать ваш солюшен.
* работать с файловой системой, сетью, запускать другие процессы, работать с реестром, обращаться к API операционной системы и делать прочие действия, которые могут быть восприняты, как вредоносные.
* подглядывать в репозитории других команд. В конце концов это не спортивно и не интересно! После окончания сможете вдоволь наизучать чужие решения!

## Вам можно

* создавать новые проекты в солюшене.
* подключать через nuget нужные вам зависимости.
* создавать ветки, если не хотите, чтобы ваши коммиты считались отправкой решения на проверку.

## Задачи

[Формулировки заданий и текущие результаты](http://design-camp.github.io)
