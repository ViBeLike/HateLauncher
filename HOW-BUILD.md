# How to Build HyTaLauncher / Как собрать HyTaLauncher

<p align="center">
  <a href="#english">🇬🇧 English</a> | <a href="#russian">🇷🇺 Русский</a>
</p>

---

<a name="english"></a>
## 🇬🇧 English

### Prerequisites

1. **Visual Studio 2022** (Community, Professional, or Enterprise)
   - Download: https://visualstudio.microsoft.com/
   - Required workload: **.NET Desktop Development**

2. **Or .NET 8 SDK** (for command-line build)
   - Download: https://dotnet.microsoft.com/download/dotnet/8.0
   - Minimum version: 8.0.0

3. **Git** (optional, for cloning)
   - Download: https://git-scm.com/

---

### Clone the Repository

```bash
git clone https://github.com/MerryJoyKey-Studio/HyTaLauncher.git
cd HyTaLauncher
```

Or download ZIP from GitHub and extract.

---

### Build with Visual Studio

1. Open `HyTaLauncher.sln` in Visual Studio 2022
2. Wait for NuGet packages to restore automatically
3. Select configuration:
   - **Debug** - for development and testing
   - **Release** - for production build
4. Press `Ctrl+Shift+B` or menu **Build → Build Solution**
5. Output will be in `HyTaLauncher/bin/Debug/net8.0-windows/` or `Release/`

---

### Build with Command Line

```bash
# Navigate to project folder
cd HyTaLauncher

# Restore NuGet packages
dotnet restore

# Build Debug version
dotnet build

# Build Release version
dotnet build -c Release
```

---

### Publish (Create Distributable)

#### Self-contained (includes .NET runtime, ~150MB)

```bash
dotnet publish -c Release -r win-x64 --self-contained true -o ./publish/self-contained
```

#### Framework-dependent (requires .NET 8 installed, ~5MB)

```bash
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish/framework-dependent
```

#### Single file executable

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish/single-file
```

---

### Project Structure

```
HyTaLauncher/
├── HyTaLauncher.sln          # Solution file
├── HyTaLauncher/
│   ├── HyTaLauncher.csproj   # Project file
│   ├── App.xaml              # Application entry point
│   ├── MainWindow.xaml       # Main window UI
│   ├── Services/             # Business logic services
│   │   ├── GameLauncher.cs   # Game download and launch
│   │   ├── ModService.cs     # CurseForge mods integration
│   │   └── ...
│   ├── Helpers/              # Utility classes
│   ├── Resources/            # Icons, images
│   ├── Languages/            # Localization files (JSON)
│   └── Fonts/                # Custom fonts
└── README.md
```

---

### Configuration

The project uses environment variables or `.env` file for API keys:

- `CURSEFORGE_API_KEY` - CurseForge API key (for mods)
- `MIRROR_URL` - Mirror server URL (optional)
- `RUSSIFIER_URL` - Russifier download URL (optional)
- `ONLINEFIX_URL` - Online Fix download URL (optional)

For development, create a `.env` file in the project root or set environment variables.

---

### Troubleshooting

**Error: SDK not found**
- Make sure .NET 8 SDK is installed
- Run `dotnet --list-sdks` to verify

**Error: Workload not installed**
- In Visual Studio Installer, add ".NET Desktop Development" workload

**NuGet restore fails**
- Check internet connection
- Run `dotnet nuget locals all --clear` and try again

---

<a name="russian"></a>
## 🇷🇺 Русский

### Требования

1. **Visual Studio 2022** (Community, Professional или Enterprise)
   - Скачать: https://visualstudio.microsoft.com/ru/
   - Необходимая рабочая нагрузка: **Разработка классических приложений .NET**

2. **Или .NET 8 SDK** (для сборки через командную строку)
   - Скачать: https://dotnet.microsoft.com/download/dotnet/8.0
   - Минимальная версия: 8.0.0

3. **Git** (опционально, для клонирования)
   - Скачать: https://git-scm.com/

---

### Клонирование репозитория

```bash
git clone https://github.com/MerryJoyKey-Studio/HyTaLauncher.git
cd HyTaLauncher
```

Или скачайте ZIP с GitHub и распакуйте.

---

### Сборка в Visual Studio

1. Откройте `HyTaLauncher.sln` в Visual Studio 2022
2. Дождитесь автоматического восстановления NuGet пакетов
3. Выберите конфигурацию:
   - **Debug** - для разработки и тестирования
   - **Release** - для финальной сборки
4. Нажмите `Ctrl+Shift+B` или меню **Сборка → Собрать решение**
5. Результат будет в `HyTaLauncher/bin/Debug/net8.0-windows/` или `Release/`

---

### Сборка через командную строку

```bash
# Перейдите в папку проекта
cd HyTaLauncher

# Восстановите NuGet пакеты
dotnet restore

# Сборка Debug версии
dotnet build

# Сборка Release версии
dotnet build -c Release
```

---

### Публикация (создание дистрибутива)

#### Автономная версия (включает .NET runtime, ~150MB)

```bash
dotnet publish -c Release -r win-x64 --self-contained true -o ./publish/self-contained
```

#### Зависимая от фреймворка (требует установленный .NET 8, ~5MB)

```bash
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish/framework-dependent
```

#### Один исполняемый файл

```bash
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o ./publish/single-file
```

---

### Структура проекта

```
HyTaLauncher/
├── HyTaLauncher.sln          # Файл решения
├── HyTaLauncher/
│   ├── HyTaLauncher.csproj   # Файл проекта
│   ├── App.xaml              # Точка входа приложения
│   ├── MainWindow.xaml       # UI главного окна
│   ├── Services/             # Сервисы бизнес-логики
│   │   ├── GameLauncher.cs   # Загрузка и запуск игры
│   │   ├── ModService.cs     # Интеграция с CurseForge
│   │   └── ...
│   ├── Helpers/              # Вспомогательные классы
│   ├── Resources/            # Иконки, изображения
│   ├── Languages/            # Файлы локализации (JSON)
│   └── Fonts/                # Кастомные шрифты
└── README.md
```

---

### Конфигурация

Проект использует переменные окружения или файл `.env` для API ключей:

- `CURSEFORGE_API_KEY` - API ключ CurseForge (для модов)
- `MIRROR_URL` - URL зеркала (опционально)
- `RUSSIFIER_URL` - URL загрузки русификатора (опционально)
- `ONLINEFIX_URL` - URL загрузки Online Fix (опционально)

Для разработки создайте файл `.env` в корне проекта или установите переменные окружения.

---

### Решение проблем

**Ошибка: SDK не найден**
- Убедитесь, что .NET 8 SDK установлен
- Выполните `dotnet --list-sdks` для проверки

**Ошибка: Рабочая нагрузка не установлена**
- В Visual Studio Installer добавьте "Разработка классических приложений .NET"

**Ошибка восстановления NuGet**
- Проверьте интернет-соединение
- Выполните `dotnet nuget locals all --clear` и попробуйте снова

---

## License / Лицензия

MIT License - свободно используйте, модифицируйте и распространяйте.