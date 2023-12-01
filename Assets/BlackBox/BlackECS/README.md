# BlackECS
[alpha] 3 итерация ECS подхода к разработке

## Оглавление

<details>
<summary>Список глав</summary>

- [Установка](#Установка)
- [Введение](#Введение)
- [Знакомство с BlackECS](#Знакомство-с-BlackECS)
    - [Цель](#Цель)
    - [Общая концепция](#Общая-концепция)
    - [Документация](#Документация)
    - [Работа над ошибками](#Работа-над-ошибками)
- [Entity](#Entity)
    - [Общее](#Общее-Entity)
    - [Создание Entity](#Создание-Entity)
    - [Поиск Entity по Тегу](#Поиск-Entity-по-Тегу)
    - [Поиск Entities с некоторым Component](#Поиск-Entities-с-некоторым-Component)
    - [Поиск привязанного GameObject к Entity](#Поиск-привязанного-GameObject-к-Entity)
    - [Поиск привязанного Unity.Component к Entity](#Поиск-привязанного-Unity.Component-к-Entity)
    - [Добавление Component](#Добавление-Component) 
    - [Чтение Component](#Чтение-Component)
    - [Удаление Component](#Удаление-Component)
    - [Уничтожить Entity](#Уничтожить-Entity)
    - [Создание неудаляемой Entity](#Создание-неудаляемой-Entity)
- [Component](#Component)
    - [Общее](#Общее-Component)
    - [Работа с данными](#Работа-с-данными)
    - [Установка Unity-компонентов](#Установка-Unity-компонентов )
- [System](#System)
    - [Общее](#Общее-System)
    - [Активация](#Активация)
    - [Завершение работы](#Завершение-работы)
    - [Добавление Component](#Добавление-Component-(System))
    - [Чтение Component](#Чтение-Component-(System))
    - [Удаление Component](#Удаление-Component-(System))
    - [Получить Component](#Получить-Component-(System))
    - [Получить Entity через Unity-компонент](#Получить-Entity-через-Unity-компонент)
    - [Уничтожить Entity](#Уничтожить-Entity-(System))
- [Экспериментальное](#Экспериментальное)


</details>

## Установка

__[GitHub Release](https://github.com/blackroomgames/BlackECS/releases)__

* Перейти по ссылке
* Выбрать актуальный релизный билд **BlackECS_v_X.X.unitypackage**
* Установить Unity пакет в свой проект
* Использовать BlackECS

## Введение

BlackECS инструментарий по реализации DoD без статического инициализации буфера и “разделенными данными и логикой”. Единственная область применения - внутренние игровые проекты в среде Unity. Инструментарий находится на этапе проектного тестирования и коррекции фич, поэтому в некоторые элементы и реализации отмечены тегов [экспериментальное]

# Знакомство с BlackECS

## Цель

BlackECS создана со следующими целями:
* унификация архитектуры внутренних игровых проектов, с участием “низкоуровневых” разработчиков;
* облегчение поддержки проекта на этапе пост-релиза;
* проверка теории применения концепции ECS на небольших проектах типа casual и mid-casual;

## Общая концепция

BlackECS использует стандартную концепцию и именования из классической ECS, которую можно выразить в [диагрмме](https://drive.google.com/file/d/17O03g9mNvYYfKE5JXsC3RlozLct1lo3o/view?usp=sharing)
* Entity - класс идентификатор хранилища, косвенно связан с Компонентами и GameObeject. Также является определителем данных, что хранит Компонент, подробнее в [Работа с данными](#Работа-с-данными);
* Component - класс с данными, связан с Системой и предоставляет для логики данные. Определяет состояние в котором находится Сущность в конкретный промежуток времени;
* System - класс с логикой, связан с Компонентом. Реализует общую логику для всех Сущностей, через работу с данными Компонента;
* World - класс с реализацией всех сервисов необходимых для работы ECS. Выполняет роль посредника для работы с API ECS;

## Документация

- [Концепт BlackECS](https://drive.google.com/file/d/17O03g9mNvYYfKE5JXsC3RlozLct1lo3o/view?usp=sharing)
- [Классы BlackECS](https://drive.google.com/file/d/198VBdNzFFRAe5Z-A5QFYhnzoRIJBd4h_/view?usp=sharing)
- [Поведение Entity](https://drive.google.com/file/d/19abkp1uQoVBfli6b1Mdh41QV4AK-2OyN/view?usp=sharing)
- [Поведение Component](https://drive.google.com/file/d/1JN7ZM5iqxYHl3LiUEwnHbdIyfy1kCRs-/view?usp=sharing)
- [Поведение System](https://drive.google.com/file/d/1Ky8zD7Qp5duEAgBiobX_MJUuhphqACP6/view?usp=sharing)

## Работа над ошибками

BlackECS является 3 итерацией реализации ECS подхода к архитектуре приложения, то была проделана работа над ошибками 2 итерации:
* Добавление объекта World для создания медиатора по работе остальных элементов ECS;
* Рефакторинг внутренней логики по работе с элементами ECS, разбивка на сервисы и хранилища;
* Рефакторинг API методов по работе с основными элементами ECS + исправление именования методов;

* Рефакторинг Entity, переход на класс идентификатор через хеши;
* Технические ограничения для Entity:
    - отказ от наследования, что приводило к создания множества сущностей;
    - отказ от дополнительной настройки сущности при создание, что приводило к усложнению кода ;
    - отказ от концепции “сущность - хранилище компонентов”, переход к концепции “сущность - идентификатор для хранилища данных и компонентов”;

* Рефакторинг Component, переход на класс хранилище специальных данных;
* Технические ограничения для Component:
    - переход от наследования к реализации интерфейса IComponent, который служит для инициализации данных компонента;
    - отказ от любой логики в объекте реализации IComponent(убраны свойства и конструкторы);
    - переход от концепции “много реализаций компонента” к концепции “один компонент, много данных”;
    - переход от концепции “компонент порождает систему” при инициализации или добавления компонента Сущности;

* Рефакторинг System, оптимизация кода и добавление индекса приоритета для обновления системы;
* Рефакторинг System, Система привязана к определенному Компоненту;
* Технические ограничения для System:
    - переход к концепции “не инициализированная система не работает”;
    - [экспериментальное](#Экспериментальное) доступ к работе с другим компонентам, при использование API;

# Entity

## Общее Entity

Сущность в BlackECS является классом идентификатором, основная ответственность сводиться к хранению и использованию хеша. Однако все создаваемые игровые объекты, которые участвуют в игровом процессе, косвенно являются Сущностями. Только через манипуляцией сущностями, можно:

* добавлять/удалять Компоненты и менять состояние Сущности игрового объекта;
* использовать данные Компонента, которые характерны к определенной Сущностью;
* добавлять/удалять игровые объекты привязанные к Сущности;

На текущий момент Сущность имеет следующую [диаграмму поведения](https://drive.google.com/file/d/19abkp1uQoVBfli6b1Mdh41QV4AK-2OyN/view?usp=sharing), данный вид поведения не окончательный и возможны изменения.

**Примечание:** По ссылке на диаграмму, имеется множество листов с именованием соответствующей API методам. 

## Создание Entity

Создание сущности производиться только через обращение к `World`, вызывая метод `CreateEntity`. При этом можно назначить тег и привязать к объекту.
**Примечание:** Тег должен быть уникальным, если тег задается двум Сущностям, то при поиске Сущности будет возвращаться вторая инициализированная Сущность.
**Примечание:** На данный момент реализована тип связи `“1 Сущности - 1 GameObject”`, для корректной работы необходимо соблюдать данный тип связи.

```csharp
using BlackECS;
using UnityEngine;

public sealed class SomeClass : MonoBehaviour
{
    private GameObject _someObject;
    private GameObject _otherObject;

    private void Start()
    {
        //создание сущности, без тега и игрового объекта
        World.CreateEntity();
        //создание сущности, с тегом
        World.CreateEntity("SomeEntity");
        //создание сущности, с игровым объектом
        World.CreateEntity(_someObject);
        //создание сущности, с тегом и игровым объектом
        World.CreateEntity("OtherEntity", _otherObject);
    }
}
```

## Поиск Entity по Тегу

1 - **Тег не повторяется**

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        World.CreateEntity("entity_1"); //Пример: хеш Сущности = 123
        World.CreateEntity("entity_2"); //Пример: хеш Сущности = 321


        Debug.Log(World.GetEntityWithTag("entity_1").GetHashCode()); //Вывод: 123
        Debug.Log(World.GetEntityWithTag("entity_2").GetHashCode()); //Вывод: 321
    }
}
```

2 - **Тег повторяется**

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        World.CreateEntity("entity_1"); //Пример: хеш Сущности = 123
        World.CreateEntity("entity_1"); //Пример: хеш Сущности = 321


        Debug.Log(World.GetEntityWithTag("entity_1").GetHashCode()); //Вывод: 321
    }
}
```

## Поиск Entities с некоторым Component

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        World.CreateEntity()
            .AddComponent<SomeComponent>(); // Hash - 001
        World.CreateEntity()
            .AddComponent<SomeComponent>(); // Hash - 002

        var entities = World.GetEntityCollectionWithComponent<SomeComponent>();

        foreach(var el in entities)
        {
            Debug.Log(el.GetHashCode()); //Вывод: 321
        }
    }
}

## Поиск привязанного GameObject к Entity

Если к сущности привязан `GameObject`, то получить ссылку на него можно через вызов метода `WhereEntityGameObject()`.

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private GameObject _testObject;

    private void Awake()
    {
        _testObject.name = "IamTestObject";
    }
    
    private void Start()
    {
        var entity = World.CreateEntity(gameObject: _testObject);
        
        Debug.Log(entity.WhereEntityGameObject().name);//Вывод: IamTestObject
    }
} 
```

## Поиск привязанного Unity.Component к Entity

Если к сущности привязан `GameObject`, у которого есть Unity-компоненты (наследники `UnityEngine.Component`), то данный компонент можно получить через вызво метода `WhereEntityGameComponent<T>()`. 

**Примечание:** Поиск происходит в через `GetComponentInChildren`, по этому возвращается более старший в иерархии компонент.
**Примечание:** Поиск происходит единожды и результат хешируется, пока Сущность не будет удалена через метод [`Destroy`](#Уничтожить-Entity).

## Добавление Component

В проекте есть два Компонента:
* `Component_1` компонент без полей и при добавление не требуется дополнительная настройка данных;
* `Component_2` компонент с полями и при добавление можно провести дополнительную настройку данных (по желанию);

```csharp
using UnityEngine;
using BlackECS;
using BlackECS.Components;


public sealed class Component_1 : IComponent {}

public sealed class Component_2 : IComponent
{
    public int index; // общее поля для всего компонента 
    public ComponentDataField<string> entityName; // поле с сегментацией по Сущностям
    //можно и так
    public ComponentDataField<string> entityName = new ComponentDataField<string>();
}
```
Для добавления компонента, нужно вызвать метод `AddComponent`.

```csharp
public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        // если требуется добавить “пустой” компонент или без настройки полей данных 
        World.CreateEntity()
            .AddComponent<Component_1>();
        // если требуется провести настройку добавляемого компонента, то необходимо передать callback в качестве аргумента 
            .AddComponent<Component_2>(
                component =>
                {
                    component.index = 1;
                    component.entityName.Value = "entity_test";
                }
            );
    }
}
```

## Чтение Component

[экспериментальное](#Экспериментальное)
В любой момент времени, можно прочитать Компонент у Сущности, для этого используем вызов метода `WhereComponent`
**Примечание:** Если указанного Компонента нет у Сущности, то callback не отрабатывает.
**Примечание:** [экспериментальное](#Экспериментальное)При работе с Компонентом, через callback, поля компонента доступны для изменении.

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        var entity = World.CreateEntity();
        entity.AddComponent<Component_1>()
              .AddComponent<Component_2>();

        entity.WhereComponent<Component_2>(
            component =>
            {
                //доступ к полям компонента
            }
        );
    }
}
```

## Удаление Component

Удаление Компонентов производиться через вызов метода `RemoveComponent`.

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        var entity = World.CreateEntity();
        entity.AddComponent<Component_1>();

        entity.RemoveComponent(typeof(Compoent_1));
    }
}
```

## Уничтожить Entity

Уничтожение Сущности - перевод текущей сущности в неактивное состояние и помещение в коллекцию. Для реализации уничтожения Сущности, необходимо произвести вызов метод `Destroy`. 
Так же уничтожать сущности можно из Системы, что является более оптимальным с учетом концепции BlackECS.

1 - **Уничтожить Entity**

```csharp
using BlackECS;
using UnityEngine;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        var someEntity = World.CreateEntity();
        someEntity.Destroy(); 
    }
}
```
2 - **Уничтожить Entity через System**

```csharp
using UnityEngine;
using BlackECS;
using BlackECS.Systems;
using BlackECS.Components;


public sealed class DestroyComponent : IComponent {}

public sealed class DestroySystem :  BaseSystem<DestroyComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(DestroyComponent component, float deltaTime)
    {
        this.DestroyEntity();
    }
}

public sealed class SomeLogicClass : MonoBehaviour
{
    private void Start()
    {
        //добавить систему в работу
        World.RegistrationSystem<DestroySystem>();

        World.CreateEntity()
            .AddComponent<DestroyComponent>();//добавить компонент для сущности
    }
}
```
**Примечание:** Во всех метода уничтожения Сущности имеется делегат типа `Action<GameObject>` предназначенный для работы привязанным игровым объектом сущности. Вызов данного делегата происходит, только при условие наличие свзи типа `Сущность-GameObject`.

## Создание неудаляемой Entity

[экспериментальное](#Экспериментальное)
Если по логике проекта требуются “неубиваемые” Сущности, т.е. игнорирующие перезагрузку уровня, то для этого нужно воспользоваться методом `DontDestroyOnLoadLevel`.
**Примечание:** По-умолчанию все создаваемые сущности, уничтожены при перезагрузке сцены.

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeClass : MonoBehaviour
{
    private void Start()
    {
        World.CreateEntity()
            .DontDestroyOnLoadLevel();
    }
}
```

# Component

## Общее Component

Компонент это класс определяющий текущее состояние Сущности. Компонент не может содержать логики или другие методы, только поля с данными. Данные имеют следующий тип:
- общие данные для всего Компонента, т.е. данные привязанные к самому Компоненту, изменение которых ведет к изменению работы всей логики связанной Системы;
- данные привязанные к конкретной Сущности, такие данные являются реализацией класса `ComponentDataField`, который выступает в роли прокси. Инициализация таких данных происходит автоматически, при добавление Компонента или регистрации Системы;

Для настройки полей данных Компонента, если это необходимо, в методах по работе с Компонентами, предусмотрен callback.На текущий момент Компонент имеет следующую [диаграмму поведения](https://drive.google.com/file/d/1JN7ZM5iqxYHl3LiUEwnHbdIyfy1kCRs-/view?usp=sharing), данный вид поведения не окончательный и возможны изменения.

## Работа с данными

* Для примера рассмотрим связку Компонент-Система. Компоненты будет хранить два типа данных, в рамках BlackECS, а Система будет выводить в консоль сумму этих данных.

```csharp
using BlackECS.Systems;
using BlackECS.Components;


public sealed class TestDataComponent : IComponent
{
    public int componentDataInt;
    public ComponentDataField<int> entityDataInt;
}

public sealed class TestDataSystem :  BaseSystem<TestDataComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(TestDataComponent component, float deltaTime)
    {
        var result = component.componentDataInt + component.entityDataInt.Value;

        Debug.Log($"Result = {result}");
    }
}
```

Компонент `TestDataComponent` имеет два поля:
`componentDataInt` - данные компонента 1 типа, общие данные компонента;
`entityDataInt` - данные компонента 2 типа, характеризует сегментацию по сущностям;

**Примечание:** Система которая использует Компонент, имеет доступ к чтению/изменению данных 1 и 2 типа с модификатором `public`. Изменение данных 1 типа, не рекомендуется, если это не влияет на рабочую логику проекта.

* Для теста создадим 2 сущности, и добавим для каждой `TestDataComponent`

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeLogicClass : MonoBehaviour
{
    private void Start()
    {
        //создание сущности 1, добавление и настройка компонента для этой сущности
        World.CreateEntity()
            .AddComponent<TestDataComponent>(
                component =>
                {
                    component.componentDataInt = 10;
                    component.entityDataInt.Value = 20;
                }
            );

        //создание сущности 2, добавление и настройка компонента для этой сущности
        World.CreateEntity()
            .AddComponent<TestDataComponent>(
                component =>
                {
                    component.entityDataInt.Value = 50;
                }
            );
    }
}
```

При добавление `TestDataComponent`, при вызове callback настройки, для каждой сущности было установлено значение для поля `entityDataInt` и общее для всего Компонента `componentDataInt` равному `10`.

* При работе Системы, в консоли отобразится следующий результат

```csharp
// ** ALL TICKS **
// Система работает с первой Сущностью
// Result = 30
// Система работает с второй Сущностью
// Result = 60
```

* Если изменить логику работы Системы и добавить изменение поля `componentDataInt`, то результат будет следующим

```csharp
public sealed class TestDataSystem :  BaseSystem<TestDataComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(TestDataComponent component, float deltaTime)
    {
        var result = component.componentDataInt + component.entityDataInt.Value;
        component.componentDataInt += 10;

        Debug.Log($"Result = {result}");
    }
}

//** 1 TICK **
// Система работает с первой Сущностью
// Result = 30
// Система работает с второй Сущностью
// Result = 70

//** 2 TICK **
// Система работает с первой Сущностью
// Result = 50
// Система работает с второй Сущностью
// Result = 90

//etc.
```

* Если изменить логику работы Системы и добавить изменение поля `entityDataInt`, то результат будет следующим

```csharp
public sealed class TestDataSystem :  BaseSystem<TestDataComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(TestDataComponent component, float deltaTime)
    {
        var result = component.componentDataInt + component.entityDataInt.Value;
        component.entityDataInt += 10;

        Debug.Log($"Result = {result}");
    }
}

//** 1 TICK **
// Система работает с первой Сущностью
// Result = 30
// Система работает с второй Сущностью
// Result = 60

//** 2 TICK **
// Система работает с первой Сущностью
// Result = 40
// Система работает с второй Сущностью
// Result = 70

//etc.
```

**Примечание:** При удаление Компонента у Сущности, происходит удаление всех связанных данных 2 типа, при этом данные 1 типа не меняются.
**Примечание:** Для всех связанных данных 2 типа, которые реализуют интерфейс `IDisposable`, при удаление компонента у сущности, происходит автоматичксий вызов метода `Dispose()`. 

## Установка Unity-компонентов

При настройки данных Компонента, кроме установки значения по прямой ссылке, реализован метод `SetComponentValueFromLinkedObject`. Данный метод производит поиск Unity-компонента в связанном `GameObject` и устанавливает полученное значение в соответствующее поле.

**Примечание:** Установка найденного значения идет происходит, в `первое` в классе поле  `ComponentDataField<T>`соответствующего типа.
**Примечание:** Поиск происходит в через `GetComponentInChildren`, по этому возвращается более старший в иерархии компонент.
**Примечание:** Поиск происходит единожды и результат хешируется, пока Сущность не будет удалена через метод [`Destroy`](#Уничтожить-Entity).


```csharp
using UnityEngine;
using BlackECS;
using BlackECS.Components;

public sealed class SomeComponent : IComponent
{
    public ComponentDataField<Transform> ownerTransform;
    public ComponentDataField<Transform> otherTransform;
}

public sealed class SomeLogicClass : MonoBehaviour
{
    private void Start()
    {
        World.CreateEntity()
            .AddComponent<SomeComponent>(
                component =>
                {
                    component.SetComponentValueFromLinkedObject<Transform>();
                }
            );
    }
}
```

В результате после настройки, Компонент имеет следующий вид.

```csharp
using UnityEngine;
using BlackECS;
using BlackECS.Components;

public sealed class SomeComponent : IComponent
{
    public ComponentDataField<Transform> ownerTransform;//поле инициализировано и имеет значение != null
    public ComponentDataField<Transform> otherTransform;//поле инициализировано и имеет значение == null
}
```

# System

## Общее System

Система это класс логики, которая работает с Сущностями у которых “есть” Компонент, к которому привязана Система. Все системы характеризуют:
- `SystemUpdateOrder` свойство, которое показывает порядок выполнения работы Системой, чем ниже значение тем раньше срабатывает Система.
- `OnUpdate` метод обработки Системы, в теле которого описывается вся логика Системы. Данный метод работает для каждой Сущности с Компонентом, что позволяет [работать сегментировано с данными Компонента](#Работа-с-данными)

**Примечание:**  На данный момент реализованное API для Системы, позволяет быстро оперировать с Сущностями и Компонентами, что по большей части использует ранее рассмотренные методы API.

## Активация

Для того чтобы начала работать Система, ее нужно добавить в реестр обновления, для этого используем метод  `RegistrationSystem`

```csharp
using UnityEngine;
using BlackECS;

public sealed class SomeBootstrapClass : MonoBehaviour
{
    private void Awake()
    {
        World.RegistrationSystem<SomeSystem>();
    }
}
```

## Завершение работы

Данная группа методов API Системы позволят завершить работу Системы для Сущности, т.е. происходит удаление Компонента связанного с Системой.

1 - **Метод Завершения**

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        this.ForgetEntity();
        //удаление SomeComponent
    }
}
```

2 - **Метод Перехода**

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        this.TransitToComponent<OtherComponent>(
            component => {}
        );
        //удаление SomeComponent + добавление компонента OtherComponent
    }
}
```

## Добавление Component (System)

Добавление нового Компонента Сущности, без удаления Компонента связанного с системой.

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        this.AddToComponent<OtherComponent>(
            component => {}
        );
    }
}
```

## Чтение Component (System)

[Экспериментальное](#Экспериментальное)
Произвести чтение Компонента у текущей рабочей Сущности.

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        this.ReadComponent<OtherComponent>(
            component => {}
        );
    }
}
```

## Удаление Component (System)

Произвести удаление у текущей рабочей Сущности, указанного Компонента.

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        this.ForgetComponent<OtherComponent>();
    }
}
```

## Получить Component (System)

[Экспериментальное](#Экспериментальное)
Получить указанный Компонент без привязки к Сущности.

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        var componentImplementation = this.RequerComponent<OtherComponent>();
    }
}
```

**Примечание:** Возвращается реализация класса Компонента, семантика по большой части internal, возможно в следующих итерациях удаление данного метода из API.

## Получить Entity через Unity-компонент

[Экспериментальное](#Экспериментальное)
Получить Сущность, связанную с указанным Unity-компонентом.

```csharp
using BlackECS;
using BlackECS.Components;


public sealed class SomeComponent : IComponent
{
    public ComponentDataField<Transform> entityTransfrom;
}

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        var entity = component.GetEntityByLinkedUnityComponent<Transform>();
    }
}
```

**Примечание:** Для правильной работы оптимально использовать Unity-компонент, что имеет прямую связь с иерархией родительского объекта, как вариант `Transform` или `GameObject`.
**Примечание:** Данный метод предназначен для реализации взаимодействия между двумя Сущностями, как пример Система урона, если `не использовать` сторонние `регистры` или `коллекции`.

## Уничтожить Entity (System)

Уничтожаем текущую рабочую Сущность.

```csharp
using BlackECS;

public sealed class SomeSystem :  BaseSystem<SomeComponent>
{
    public override int SystemUpdateOrder => default;

    public override void OnUpdate(SomeComponent component, float deltaTime)
    {
        this.DestroyEntity();
    }
}
```

# Экспериментальное

Данный тег, говорить о том, что фича (элемент кода / конструктивное решение) имеет следующие свойства:
* не проверено на реальном проекте;
* не использовано “низкоуровневым” разработчиком и нет отзыва о фиче;
* является сомнительным решением в рамках выбранной архитектуре и концепции;

После прохождения испытания на реальном проекте или получение дополнительной информации от более “скилового” разработчика. Фича может быть доработана или удалена.

