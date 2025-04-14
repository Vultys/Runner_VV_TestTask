# 🏃‍♂️ Endless Runner Game (Unity + Zenject)

Це простий endless runner-проєкт, розроблений в Unity з акцентом на **чисту архітектуру**, **DI (Zenject)**, **розширюваність**, **модульність** та **оптимізацію**.

---

## 🎮 Геймплей

- Гравець автоматично біжить вперед.
- Можна рухатися вліво/вправо між лініями.
- Зустрічаються **перешкоди** — зіткнення веде до програшу.
- Збираються **фрукти** — кожен тип має свій колір, цінність і лічильник.
- Після програшу гравець потрапляє до **Lobby**, де зберігається статистика попередніх ігор.

---

## 🔧 Технології

- **Unity** (рекомендовано 2022.3+ LTS)
- **Zenject** для Dependency Injection
- **ScriptableObjects** для конфігурації фруктів/перешкод
- **Локальне збереження** результатів через `PlayerPrefs`

---

## 🧩 Основні системи

- `IGameState` – система управління станами (Loading, Lobby, Gameplay)
- `IPlayerInput` – обробка інпуту
- `IScoreSystem` – підрахунок очок та фруктів
- `ISaveSystem` – збереження результатів і рейтингу
- `IPlatformSpawner`, `IObstacleSpawner`, `IFruitSpawner` – відповідальні за появу об'єктів

---

## 🍓 Конфігурація фруктів

Фрукти описані в `FruitConfig` (ScriptableObject), який містить:

- Тип (`FruitType`)
- Кількість очок
- Префаб

---

## 🧠 Архітектура

- **DI через Zenject** — кожна система інжектується
- **GameStateMachine** — перемикає стани гри

---

## 🗃️ Збереження ігор

- `GameResult` зберігає `score`, `timestamp`
- Результати серіалізуються в JSON і зберігаються локально
- Сортуються за очками і показуються в `Lobby`

---

## 📈 Можливі розширення

- Скін-система для гравця
- Інтеграція з Firebase/Leaderboard
- Більше типів фруктів/перешкод
- Бонуси/Powerups

---

## 💡 Автоматизація та оптимізація

- Обмеження кількості платформ в грі
- Варіативність через конфіги, а не глибоку логіку

---

## 👨‍💻 Автор

Проєкт створено з метою навчання архітектурі Unity-проєктів із використанням Zenject та хороших практик розробки.

Витрачено часу: 16 годин