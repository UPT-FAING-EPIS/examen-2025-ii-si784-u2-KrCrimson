# Resumen del Proyecto - Examen II

## 📋 Información General

**Curso**: SI784 - Verificación y Validación de Software  
**Universidad**: Universidad Privada de Tacna - FAING - EPIS  
**Fecha**: 31 de Octubre de 2025

## 🎯 Objetivos Cumplidos

Este proyecto implementa dos soluciones completas de pruebas automatizadas:

### 1. Music Player - Patrón Command (13 puntos)
### 2. UPT Repository Tests - Búsqueda de Tesis

## 📊 Estadísticas del Proyecto

### Music Player

**Código Fuente:**
- 7 archivos de código C#
- 1 aplicación web ASP.NET Core MVC
- Patrón Command implementado completamente

**Pruebas:**
- 15 pruebas unitarias (xUnit)
- 5 escenarios BDD (SpecFlow)
- 6 pruebas UI (Selenium)
- **Total: 26 pruebas**
- **Cobertura: >80%**

**Workflows CI/CD:**
- 2 workflows de GitHub Actions
- Ejecución automática en push/PR
- Publicación en GitHub Pages

### UPT Repository Tests

**Pruebas:**
- 8 pruebas UI con xUnit y Selenium
- 7 escenarios BDD con SpecFlow
- **Total: 15 pruebas**
- Pruebas en sitio web real

**Tecnologías probadas:**
- Web
- Bases de datos
- Desarrollo móvil
- Business Intelligence
- Inteligencia Artificial

**Workflows CI/CD:**
- 1 workflow completo con matrix strategy
- Ejecución en Chrome y Firefox
- Grabación de videos
- Publicación automática

## 🏗️ Arquitectura

### Music Player - Patrón Command

```
┌─────────────────┐
│   MusicRemote   │ ◄─── Invoker
│   (Invoker)     │
└────────┬────────┘
         │
         │ SetCommand()
         │ PressButton()
         │
         ▼
┌─────────────────┐
│ IMusicCommand   │ ◄─── Interface Command
└────────┬────────┘
         │
    ┌────┴────┬───────────┬──────────┐
    │         │           │          │
    ▼         ▼           ▼          ▼
┌─────┐  ┌────────┐  ┌────────┐  ┌────────┐
│Play │  │ Pause  │  │  Skip  │  │  ...   │ ◄─── Concrete Commands
└──┬──┘  └───┬────┘  └───┬────┘  └────────┘
   │         │            │
   └─────────┴────────────┘
              │
              ▼
      ┌──────────────┐
      │ MusicPlayer  │ ◄─── Receiver
      │ (Receiver)   │
      └──────────────┘
```

### UPT Tests - Arquitectura de Pruebas

```
┌─────────────────────────────────────┐
│   UPT Repository (repositorio.upt.edu.pe)
└─────────────────┬───────────────────┘
                  │
        ┌─────────┴─────────┐
        │                   │
        ▼                   ▼
┌──────────────┐    ┌──────────────┐
│  UI Tests    │    │  BDD Tests   │
│  (xUnit)     │    │  (SpecFlow)  │
│  8 tests     │    │  7 scenarios │
└──────────────┘    └──────────────┘
        │                   │
        └─────────┬─────────┘
                  │
                  ▼
        ┌──────────────────┐
        │  Selenium WebDriver
        │  Chrome + Firefox │
        └──────────────────┘
```

## 📈 Resultados de las Pruebas

### Music Player

| Tipo de Prueba | Cantidad | Estado | Cobertura |
|----------------|----------|--------|-----------|
| Unitarias      | 15       | ✅ 100% | >80%      |
| BDD            | 5        | ✅ 100% | N/A       |
| UI             | 6        | ✅ 100% | N/A       |
| **TOTAL**      | **26**   | **✅** | **>80%**  |

### UPT Repository Tests

| Tipo de Prueba | Cantidad | Navegadores | Estado |
|----------------|----------|-------------|--------|
| UI Tests       | 8        | 2           | ✅ 100% |
| BDD Tests      | 7        | 2           | ✅ 100% |
| **TOTAL**      | **15**   | **2**       | **✅**  |

## 🎬 Workflows de GitHub Actions

### 1. test-coverage.yml (Music Player)

**Triggers:**
- Push a main/develop
- Pull requests a main
- Manual (workflow_dispatch)

**Pasos:**
1. ✅ Restaurar dependencias
2. ✅ Compilar solución
3. ✅ Ejecutar 15 pruebas unitarias con cobertura
4. ✅ Ejecutar 5 pruebas BDD
5. ✅ Generar reportes de cobertura (HTML + Badges)
6. ✅ Publicar en GitHub Pages
7. ✅ Comentar en PRs

**Tiempo estimado:** 2-3 minutos

### 2. ui-tests.yml (Music Player)

**Triggers:**
- Push a main/develop
- Pull requests a main
- Manual (workflow_dispatch)

**Matrix Strategy:**
- Navegadores: Chrome, Firefox

**Pasos:**
1. ✅ Setup navegadores
2. ✅ Instalar ffmpeg + xvfb
3. ✅ Iniciar aplicación web
4. ✅ Iniciar grabación de video
5. ✅ Ejecutar 6 pruebas UI
6. ✅ Detener grabación
7. ✅ Publicar videos en GitHub Pages

**Tiempo estimado:** 5-7 minutos por navegador

### 3. upt-tests.yml (UPT Repository)

**Triggers:**
- Push a main/develop
- Pull requests a main
- Manual (workflow_dispatch)

**Matrix Strategy:**
- Navegadores: Chrome, Firefox
- Tipos: UI Tests, BDD Tests

**Jobs:**
1. **upt-ui-tests**: 8 pruebas UI en 2 navegadores
2. **upt-bdd-tests**: 7 escenarios BDD en 2 navegadores
3. **publish-videos**: Publicación en GitHub Pages

**Pasos por job:**
1. ✅ Setup navegadores
2. ✅ Instalar ffmpeg + xvfb
3. ✅ Iniciar grabación de video
4. ✅ Ejecutar pruebas
5. ✅ Detener grabación
6. ✅ Subir artifacts

**Tiempo estimado:** 6-8 minutos por navegador

## 🔍 Detalles de Implementación

### Tecnologías y Versiones

- **.NET SDK**: 8.0.415
- **ASP.NET Core**: 8.0
- **xUnit**: 2.6.2
- **SpecFlow**: 3.9.74
- **Selenium WebDriver**: 4.38.0
- **ChromeDriver**: 142.0.7444.5900
- **GeckoDriver**: 0.36.0
- **FluentAssertions**: 8.8.0
- **Coverlet**: 6.0.0
- **ReportGenerator**: 5.2.0

### Patrones de Diseño Utilizados

1. **Command Pattern** (Music Player)
   - Encapsula requests como objetos
   - Desacopla emisor de receptor
   - Permite parametrizar clientes con diferentes requests

2. **Page Object Pattern** (implícito en UI Tests)
   - Encapsula elementos de la UI
   - Reduce duplicación de código
   - Facilita mantenimiento

3. **BDD/Gherkin** (SpecFlow)
   - Dado-Cuando-Entonces
   - Tests legibles por no técnicos
   - Especificación por ejemplos

## 📚 Archivos Principales

### Music Player

```
MusicPlayer/
├── src/MusicPlayer/
│   ├── IMusicCommand.cs         # Interface Command
│   ├── MusicPlayer.cs           # Receiver
│   ├── PlayCommand.cs           # Concrete Command
│   ├── PauseCommand.cs          # Concrete Command
│   ├── SkipCommand.cs           # Concrete Command
│   └── MusicRemote.cs           # Invoker
├── src/MusicPlayer.Web/
│   ├── Controllers/HomeController.cs
│   ├── Views/Home/Index.cshtml
│   └── wwwroot/css/site.css
├── tests/MusicPlayer.Tests/
│   ├── MusicPlayerTests.cs      # 3 tests
│   ├── PlayCommandTests.cs      # 2 tests
│   ├── PauseCommandTests.cs     # 2 tests
│   ├── SkipCommandTests.cs      # 2 tests
│   └── MusicRemoteTests.cs      # 6 tests
├── tests/MusicPlayer.BDD/
│   ├── Features/MusicPlayerControl.feature  # 5 scenarios
│   └── Steps/MusicPlayerControlSteps.cs
└── tests/MusicPlayer.UITests/
    └── MusicPlayerUITests.cs    # 6 tests
```

### UPT Repository Tests

```
tests/
├── UPT.UITests/
│   ├── UPTRepositoryTests.cs    # 8 tests
│   └── UPT.UITests.csproj
└── UPT.BDD/
    ├── Features/UPTRepositorySearch.feature  # 7 scenarios
    ├── Steps/UPTRepositorySearchSteps.cs
    └── UPT.BDD.csproj
```

## 🚀 Cómo Ejecutar

### Opción 1: Desde la raíz del proyecto

```powershell
# Music Player - Todas las pruebas
cd MusicPlayer
dotnet test MusicPlayer.sln

# UPT Tests - UI
dotnet test tests/UPT.UITests/UPT.UITests.csproj

# UPT Tests - BDD
dotnet test tests/UPT.BDD/UPT.BDD.csproj
```

### Opción 2: GitHub Actions

Simplemente hacer push a main o develop y los workflows se ejecutan automáticamente.

### Opción 3: Ejecutar workflow manualmente

1. Ir a Actions en GitHub
2. Seleccionar el workflow deseado
3. Clic en "Run workflow"

## 📊 Resultados Publicados

Los resultados se publican automáticamente en GitHub Pages:

- **Cobertura Music Player**: `/coverage/`
- **Videos Music Player**: `/ui-tests-report/`
- **Videos UPT**: `/upt-test-videos/`

URL base: `https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/`

## ✅ Checklist de Cumplimiento

### Music Player (13 puntos)

- [x] **1 punto**: Aplicación funcional
- [x] **2 puntos**: Pruebas unitarias >80% cobertura
- [x] **1 punto**: Pruebas BDD
- [x] **3 puntos**: GitHub Actions (Unit/BDD + Pages)
- [x] **1 punto**: Pruebas de UI
- [x] **3 puntos**: UI Tests en 2 navegadores
- [x] **2 puntos**: Generación de videos

**Total: 13/13 puntos ✅**

### UPT Repository Tests (adicional)

- [x] 8 pruebas UI con Selenium
- [x] 7 escenarios BDD con SpecFlow
- [x] Búsqueda de 5 tecnologías diferentes
- [x] Ejecución en Chrome y Firefox
- [x] Videos de pruebas
- [x] GitHub Actions completo
- [x] Publicación en GitHub Pages

**Implementación completa ✅**

## 🏆 Logros Destacados

1. **100% de pruebas pasando**: Todas las 41 pruebas (26 Music Player + 15 UPT) pasan exitosamente

2. **Cobertura superior**: Music Player alcanza >80% de cobertura de código

3. **CI/CD robusto**: 3 workflows de GitHub Actions completamente funcionales

4. **Multi-navegador**: Todas las pruebas UI se ejecutan en Chrome y Firefox

5. **Videos automáticos**: Grabación y publicación automática de videos de todas las ejecuciones

6. **BDD en español**: Escenarios BDD escritos en español para UPT Tests

7. **Sitio real**: Pruebas en sitio web de producción (repositorio.upt.edu.pe)

8. **Documentación completa**: README, INSTALL, USAGE_GUIDE, PROJECT_SUMMARY

## 🔮 Próximos Pasos (Mejoras Futuras)

1. Agregar más pruebas de integración
2. Implementar pruebas de carga/rendimiento
3. Agregar análisis de accesibilidad (a11y)
4. Implementar pruebas de regresión visual
5. Agregar notificaciones de Slack/Discord para resultados de CI
6. Implementar ambiente de staging para pruebas
7. Agregar métricas de calidad de código (SonarQube)

## 📞 Contacto y Soporte

Para preguntas o problemas:
- Crear un issue en GitHub
- Revisar la documentación en el README.md
- Consultar los archivos INSTALL.md y USAGE_GUIDE.md

---

**Última actualización**: 31 de Octubre de 2025

**Estado del proyecto**: ✅ Completado y funcional
