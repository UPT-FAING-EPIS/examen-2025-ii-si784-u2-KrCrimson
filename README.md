[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/bTwXPjqC)
[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-2972f46106e565e64193e422d61a12cf1da4916b45550586e14ef0a7c637dd04.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=21411372)

# Examen II - Implementaciones de Pruebas Automatizadas

Este repositorio contiene dos implementaciones completas de pruebas automatizadas:

1. **Music Player** - Implementación del patrón Command con pruebas completas
2. **UPT Repository Tests** - Pruebas de UI para el repositorio institucional de la UPT

## 🎯 Estructura del Proyecto

```
examen-2025-ii-si784-u2-KrCrimson/
├── MusicPlayer/                  # Proyecto Music Player con patrón Command
│   ├── src/
│   │   ├── MusicPlayer/          # Biblioteca con patrón Command
│   │   └── MusicPlayer.Web/      # Aplicación web ASP.NET Core
│   ├── tests/
│   │   ├── MusicPlayer.Tests/    # Pruebas unitarias (15 tests)
│   │   ├── MusicPlayer.BDD/      # Pruebas BDD (5 escenarios)
│   │   └── MusicPlayer.UITests/  # Pruebas de UI Selenium (6 tests)
│   └── MusicPlayer.sln
├── tests/
│   ├── UPT.UITests/              # Pruebas UI del repositorio UPT (8 tests)
│   └── UPT.BDD/                  # Pruebas BDD del repositorio UPT (7 escenarios)
└── .github/
    └── workflows/
        ├── test-coverage.yml     # Tests unitarios y BDD de Music Player
        ├── ui-tests.yml          # Tests UI de Music Player
        └── upt-tests.yml         # Tests UI y BDD del repositorio UPT

```

## 📋 Proyectos Incluidos

### 1. Music Player - Patrón Command (13 puntos)

Implementación completa del patrón de diseño Command para controlar un reproductor de música.

**Características:**
- ✅ Biblioteca con patrón Command (IMusicCommand, PlayCommand, PauseCommand, SkipCommand)
- ✅ Aplicación web ASP.NET Core MVC
- ✅ 15 pruebas unitarias con >80% cobertura
- ✅ 5 escenarios BDD con SpecFlow
- ✅ 6 pruebas UI con Selenium
- ✅ GitHub Actions con reportes de cobertura
- ✅ Videos de ejecución de pruebas
- ✅ Publicación en GitHub Pages

**Componentes del patrón:**
- **IMusicCommand**: Interfaz Command
- **MusicPlayer**: Receiver (ejecuta las acciones reales)
- **PlayCommand, PauseCommand, SkipCommand**: Concrete Commands
- **MusicRemote**: Invoker (ejecuta los comandos)

### 2. UPT Repository Tests - Búsqueda de Tesis

Pruebas automatizadas para el repositorio institucional de la UPT (https://repositorio.upt.edu.pe/)

**Características:**
- ✅ 8 pruebas UI con Selenium (xUnit)
- ✅ 7 escenarios BDD con SpecFlow en español
- ✅ Búsqueda de tesis sobre tecnologías: web, bases de datos, móvil, BI, IA
- ✅ Ejecución en Chrome y Firefox
- ✅ Videos de las pruebas
- ✅ GitHub Actions para automatización

**Escenarios de prueba:**
- Acceso al repositorio
- Búsqueda de diferentes tecnologías
- Verificación de resultados relevantes

## 🚀 Requisitos

- .NET 8.0 SDK
- Visual Studio 2022 o VS Code
- Para UI Tests: Chrome y/ou Firefox

## 📦 Instalación y Ejecución

### Music Player

```powershell
# Restaurar y compilar
cd MusicPlayer
dotnet restore MusicPlayer.sln
dotnet build MusicPlayer.sln --configuration Release

# Ejecutar pruebas unitarias
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj

# Ejecutar pruebas BDD
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj

# Ejecutar aplicación web
cd src/MusicPlayer.Web
dotnet run

# Ejecutar pruebas UI (requiere la aplicación corriendo)
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj
```

### UPT Repository Tests

```powershell
# Restaurar y compilar
dotnet restore tests/UPT.UITests/UPT.UITests.csproj
dotnet build tests/UPT.UITests/UPT.UITests.csproj --configuration Release

# Ejecutar pruebas UI
dotnet test tests/UPT.UITests/UPT.UITests.csproj

# Ejecutar pruebas BDD
dotnet restore tests/UPT.BDD/UPT.BDD.csproj
dotnet build tests/UPT.BDD/UPT.BDD.csproj --configuration Release
dotnet test tests/UPT.BDD/UPT.BDD.csproj

# Ejecutar con navegador específico
$env:BROWSER="firefox"
dotnet test tests/UPT.UITests/UPT.UITests.csproj
```

## 🧪 Ejecutar Pruebas

### Music Player - Pruebas Unitarias (80%+ cobertura)
```powershell
cd MusicPlayer
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj --collect:"XPlat Code Coverage"
```

### Music Player - Pruebas BDD (SpecFlow)
```powershell
cd MusicPlayer
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj
```

### Music Player - Pruebas de UI (Selenium)
```powershell
# Primero iniciar la aplicación web
cd MusicPlayer/src/MusicPlayer.Web
dotnet run

# En otra terminal, ejecutar las pruebas de UI
# Chrome
$env:BROWSER="chrome"
dotnet test MusicPlayer/tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj

# Firefox
$env:BROWSER="firefox"
dotnet test MusicPlayer/tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj
```

### UPT Repository - Pruebas UI
```powershell
# Chrome (por defecto)
dotnet test tests/UPT.UITests/UPT.UITests.csproj

# Firefox
$env:BROWSER="firefox"
dotnet test tests/UPT.UITests/UPT.UITests.csproj
```

### UPT Repository - Pruebas BDD
```powershell
# Chrome (por defecto)
dotnet test tests/UPT.BDD/UPT.BDD.csproj

# Firefox
$env:BROWSER="firefox"
dotnet test tests/UPT.BDD/UPT.BDD.csproj
```

## 🌐 Ejecutar la Aplicación Web Music Player

```powershell
cd MusicPlayer/src/MusicPlayer.Web
dotnet run
```

Abre tu navegador en: https://localhost:5001

## 📊 Reportes de Cobertura

Los reportes se generan automáticamente con GitHub Actions y se publican en GitHub Pages:

- **Cobertura Music Player**: https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/coverage/
- **Videos Music Player**: https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/ui-tests-report/
- **Videos UPT Tests**: https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/upt-test-videos/

## 🎬 GitHub Actions Workflows

### 1. Test Coverage Workflow (`.github/workflows/test-coverage.yml`)

**Music Player - Pruebas unitarias y BDD:**
- ✅ Ejecuta 15 pruebas unitarias
- ✅ Ejecuta 5 escenarios BDD
- 📊 Genera reportes de cobertura
- 🚀 Publica en GitHub Pages

### 2. UI Tests Workflow (`.github/workflows/ui-tests.yml`)

**Music Player - Pruebas de interfaz:**
- 🌐 Ejecuta 6 pruebas en Chrome y Firefox
- 🎥 Graba videos de las ejecuciones
- 📤 Publica videos en GitHub Pages

### 3. UPT Tests Workflow (`.github/workflows/upt-tests.yml`)

**Repositorio UPT - Pruebas de búsqueda:**
- 🌐 Ejecuta 8 pruebas UI en Chrome y Firefox
- 🌐 Ejecuta 7 escenarios BDD en Chrome y Firefox
- 🎥 Graba videos de todas las ejecuciones
- 📤 Publica videos en GitHub Pages

## 📈 Cobertura de Pruebas

### Music Player - Pruebas Unitarias (15 tests)
- ✅ MusicPlayerTests (3 tests): Play, Pause, Skip
- ✅ PlayCommandTests (2 tests): Execute, GetDescription
- ✅ PauseCommandTests (2 tests): Execute, GetDescription
- ✅ SkipCommandTests (2 tests): Execute, GetDescription
- ✅ MusicRemoteTests (6 tests): con/sin comandos, cambio dinámico

### Music Player - Pruebas BDD (5 escenarios)
1. Play a song
2. Pause a song
3. Skip to next song
4. Press button without setting command
5. Change commands dynamically

### Music Player - Pruebas de UI (6 tests)
1. Carga de página
2. Botón Play funciona
3. Botón Pause funciona
4. Botón Skip funciona
5. Todos los botones visibles
6. Secuencia de comandos múltiples

### UPT Repository - Pruebas UI (8 tests)
1. Repositorio carga correctamente
2. Búsqueda de "web"
3. Búsqueda de "base de datos"
4. Búsqueda de "movil"
5. Búsqueda de "business intelligence"
6. Búsqueda de "inteligencia artificial"
7. Verificación de resultados Web
8. Verificación de contenido específico por tecnología

### UPT Repository - Pruebas BDD (7 escenarios)
1. Acceso al repositorio UPT
2-6. Búsqueda de 5 tecnologías (esquema de escenario con ejemplos)
7. Verificación de contenido relevante

## 🎯 Puntuación del Examen

### Music Player (13 puntos)
- ✅ **1 punto**: Crear la aplicación
- ✅ **2 puntos**: Pruebas unitarias con 80%+ cobertura
- ✅ **1 punto**: Pruebas BDD
- ✅ **3 puntos**: Automatización GitHub Actions (Unit/BDD + GitHub Pages)
- ✅ **1 punto**: Pruebas de UI
- ✅ **3 puntos**: Automatización UI Tests en 2 navegadores
- ✅ **2 puntos**: Generación de videos

### UPT Repository Tests (adicional)
- ✅ **8 pruebas UI** con Selenium en xUnit
- ✅ **7 escenarios BDD** con SpecFlow en español
- ✅ **Automatización completa** con GitHub Actions
- ✅ **Videos** de ejecución en Chrome y Firefox
- ✅ **Publicación** en GitHub Pages

**Total Music Player: 13 puntos** ✨
**Adicional UPT Tests: Implementación completa** 🚀

## 🛠️ Tecnologías Utilizadas

- **.NET 8.0**: Framework principal
- **ASP.NET Core MVC**: Aplicación web Music Player
- **xUnit**: Framework de pruebas unitarias
- **SpecFlow**: Framework BDD con Gherkin
- **Selenium WebDriver**: Pruebas de UI automatizadas
- **ChromeDriver/GeckoDriver**: Controladores de navegadores
- **Coverlet**: Cobertura de código
- **ReportGenerator**: Reportes HTML de cobertura
- **GitHub Actions**: CI/CD
- **FFmpeg**: Grabación de videos
- **FluentAssertions**: Assertions expresivas para BDD

## 📝 Configurar GitHub Pages

Para que los reportes se publiquen correctamente:

1. Ve a Settings → Pages en tu repositorio
2. En "Source", selecciona "GitHub Actions"
3. Los workflows publicarán automáticamente en:
   - `/coverage/` - Reportes de cobertura Music Player
   - `/ui-tests-report/` - Videos de UI Music Player
   - `/upt-test-videos/` - Videos de tests del repositorio UPT

## 🔧 Desarrollo Local

```powershell
# Generar reporte de cobertura local para Music Player
cd MusicPlayer
dotnet test --collect:"XPlat Code Coverage"
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html

# Ver el reporte
start coverage-report/index.html
```

## 📚 Documentación Adicional

- **Music Player**: Ver `MusicPlayer/README.md` para más detalles
- **Instalación**: Ver `MusicPlayer/INSTALL.md` para guía detallada
- **Uso**: Ver `MusicPlayer/USAGE_GUIDE.md` para ejemplos de uso
- **Resumen**: Ver `MusicPlayer/PROJECT_SUMMARY.md` para resumen del proyecto

## 🏆 Características Destacadas

### Music Player
- ✅ Patrón Command implementado correctamente
- ✅ Arquitectura limpia y desacoplada
- ✅ 100% de tests pasando (20 tests totales)
- ✅ Cobertura > 80%
- ✅ CI/CD completo con GitHub Actions
- ✅ Videos de pruebas automatizadas

### UPT Repository Tests  
- ✅ Pruebas en sitio web real (https://repositorio.upt.edu.pe/)
- ✅ BDD en español con escenarios del dominio
- ✅ 5 tecnologías diferentes probadas
- ✅ Ejecución paralela en múltiples navegadores
- ✅ Manejo robusto de timeouts y esperas
- ✅ Verificación de contenido relevante

## 📄 Licencia

Este proyecto es parte de un examen académico de la Universidad Privada de Tacna.

## 👨‍💻 Autor

Curso: SI784 - Verificación y Validación de Software  
Universidad Privada de Tacna - FAING - EPIS

---

**Nota**: Asegúrate de habilitar GitHub Pages y tener los permisos necesarios para que los workflows puedan publicar en GitHub Pages.
