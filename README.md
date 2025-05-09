![Вигляд гри](https://github.com/visys-dev/.NET---Lab-04---PairGameKeyboard/blob/master/Lab04.gif)
# PairGameKeyboard

**WinForms “Парні Картинки”** — проста гра на запам’ятовування пар кольорів з підтримкою гнучкого розміру поля та керування клавіатурою й мишею.

## Опис

При старті гри відкривається діалог налаштувань, де можна вибрати розмір поля:

- **4×4**
- **6×6**
- **8×8**

Після цього генерується поле із сірих клітинок. За кожен хід ви можете:

1. Клікнути мишею або натиснути **Enter/Space** на виділеній клітинці.
2. Відкриваються два кольорові квадрати.
3. Якщо кольори однакові — ці клітинки блокуються.
4. Якщо різні — повертаються до сірого.
5. Гра завершується, коли всі пари знайдені, і одразу стартує нова гра з поточними налаштуваннями.

## Особливості

- Динамічне створення поля потрібного розміру.
- Підтримка управління мишею та клавіатурними стрілками (Up, Down, Left, Right).
- Підтримка вибору клітинки клавішами Enter/Space.
- Простий, чистий інтерфейс на WinForms (.NET 4.8).

## Структура проєкту

```text
PairGameKeyboard/
├── PairGameKeyboard.sln         # Файл рішення для Visual Studio
├── PairGameKeyboard.csproj      # Проєкт WinForms
│
├── Program.cs                   # Точка входу: відкриття SettingsForm → MainForm
│
├── SettingsForm.cs              # Форма налаштувань: вибір розміру
├── SettingsForm.Designer.cs     # Дизайнер SettingsForm
│
├── MainForm.cs                  # Логіка гри: генерація поля, обробка кліків, клавіатури
├── MainForm.Designer.cs         # Дизайнер MainForm (TableLayoutPanel)
│
└── README.md                    # Опис проєкту
