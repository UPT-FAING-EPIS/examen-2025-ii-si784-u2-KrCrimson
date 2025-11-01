[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/bTwXPjqC)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411372)

# Music Player - Command Pattern Implementation

Este proyecto implementa el patrón de diseño Command para controlar un reproductor de música.

## 🎯 Estructura del Proyecto

```
examen-2025-ii-si784-u2-KrCrimson/
├── src/
│   ├── MusicPlayer/              # Biblioteca principal con el patrón Command
│   └── MusicPlayer.Web/          # Aplicación web ASP.NET Core
├── tests/
│   ├── MusicPlayer.Tests/        # Pruebas unitarias (xUnit)
│   ├── MusicPlayer.BDD/          # Pruebas BDD (SpecFlow)
│   └── MusicPlayer.UITests/      # Pruebas de UI (Selenium)
└── .github/
    └── workflows/                # GitHub Actions workflows
```

## 🏗️ Arquitectura - Patrón Command

El proyecto implementa el patrón Command con los siguientes componentes:

- **IMusicCommand**: Interfaz Command
- **MusicPlayer**: Receiver (ejecuta las acciones reales)
- **PlayCommand, PauseCommand, SkipCommand**: Concrete Commands
- **MusicRemote**: Invoker (ejecuta los comandos)

## 🚀 Requisitos

- .NET 8.0 SDK
- Visual Studio 2022 o VS Code
- Para UI Tests: Chrome y/o Firefox

## 📦 Instalación

```powershell
# Clonar el repositorio
git clone https://github.com/UPT-FAING-EPIS/examen-2025-ii-si784-u2-KrCrimson.git
cd examen-2025-ii-si784-u2-KrCrimson

# Restaurar dependencias
dotnet restore MusicPlayer.sln

# Compilar la solución
dotnet build MusicPlayer.sln
```

## 🧪 Ejecutar Pruebas

### Pruebas Unitarias (80%+ cobertura)
```powershell
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj --collect:"XPlat Code Coverage"
```

### Pruebas BDD (SpecFlow)
```powershell
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj
```

### Pruebas de UI (Selenium)
```powershell
# Primero iniciar la aplicación web
cd src/MusicPlayer.Web
dotnet run

# En otra terminal, ejecutar las pruebas de UI
# Chrome
$env:BROWSER="chrome"
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj

# Firefox
$env:BROWSER="firefox"
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj
```

## 🌐 Ejecutar la Aplicación Web

```powershell
cd src/MusicPlayer.Web
dotnet run
```

Abre tu navegador en: https://localhost:5001

## 📊 Reportes de Cobertura

Los reportes de cobertura se generan automáticamente con GitHub Actions y se publican en GitHub Pages:

- **Reporte de Cobertura**: https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/coverage/
- **Resultados de UI Tests**: https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/ui-tests-report/

## 🎬 GitHub Actions Workflows

### 1. Test Coverage Workflow (`.github/workflows/test-coverage.yml`)

Ejecuta:
- ✅ Pruebas unitarias con cobertura
- ✅ Pruebas BDD
- 📊 Genera reportes de cobertura
- 🚀 Publica en GitHub Pages

### 2. UI Tests Workflow (`.github/workflows/ui-tests.yml`)

Ejecuta:
- 🌐 Pruebas en Chrome y Firefox
- 🎥 Graba videos de las ejecuciones
- 📤 Publica videos en GitHub Pages

## 📈 Cobertura de Pruebas

El proyecto incluye pruebas exhaustivas para:

### Pruebas Unitarias
- ✅ MusicPlayer (Play, Pause, Skip)
- ✅ PlayCommand
- ✅ PauseCommand
- ✅ SkipCommand
- ✅ MusicRemote (con y sin comandos)
- ✅ Cambio dinámico de comandos

### Pruebas BDD (Escenarios)
1. Play a song
2. Pause a song
3. Skip to next song
4. Press button without setting command
5. Change commands dynamically

### Pruebas de UI
1. Carga de página
2. Botón Play
3. Botón Pause
4. Botón Skip
5. Visibilidad de botones
6. Secuencia de comandos múltiples

## 🎯 Puntuación del Examen

- ✅ **1 punto**: Crear la aplicación
- ✅ **2 puntos**: Pruebas unitarias con 80%+ cobertura
- ✅ **1 punto**: Pruebas BDD
- ✅ **3 puntos**: Automatización GitHub Actions (Unit/BDD + GitHub Pages)
- ✅ **1 punto**: Pruebas de UI
- ✅ **3 puntos**: Automatización UI Tests en 2 navegadores
- ✅ **2 puntos**: Generación de videos

**Total: 13 puntos** ✨

## 🛠️ Tecnologías Utilizadas

- **.NET 8.0**: Framework principal
- **ASP.NET Core MVC**: Aplicación web
- **xUnit**: Framework de pruebas unitarias
- **SpecFlow**: Framework BDD
- **Selenium WebDriver**: Pruebas de UI
- **Coverlet**: Cobertura de código
- **ReportGenerator**: Reportes HTML de cobertura
- **GitHub Actions**: CI/CD
- **FFmpeg**: Grabación de videos

## 📝 Configurar GitHub Pages

Para que los reportes se publiquen correctamente:

1. Ve a Settings → Pages en tu repositorio
2. En "Source", selecciona "GitHub Actions"
3. Los workflows publicarán automáticamente en:
   - `/coverage/` - Reportes de cobertura
   - `/ui-tests-report/` - Página de resultados de UI
   - `/ui-tests/` - Videos de pruebas

## 🔧 Desarrollo Local

```powershell
# Restaurar herramientas
dotnet tool restore

# Generar reporte de cobertura local
dotnet test --collect:"XPlat Code Coverage"
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html

# Ver el reporte
start coverage-report/index.html
```

## 📄 Licencia

Este proyecto es parte de un examen académico de la Universidad Privada de Tacna.

## 👨‍💻 Autor

Estudiante: [Tu Nombre]
Curso: SI784 - Verificación y Validación de Software
Universidad Privada de Tacna - FAING - EPIS

---

**Nota**: Asegúrate de habilitar GitHub Pages y tener los permisos necesarios para que los workflows puedan publicar en GitHub Pages.
