# 🚀 Guía de Inicio Rápido - Examen II

## 📋 Contenido del Repositorio

```
examen-2025-ii-si784-u2-KrCrimson/
│
├── 📁 MusicPlayer/              ← Proyecto Music Player con Patrón Command
│   ├── src/                     ← Código fuente
│   │   ├── MusicPlayer/         ← Biblioteca con patrón Command
│   │   └── MusicPlayer.Web/     ← Aplicación web ASP.NET Core
│   ├── tests/                   ← Todas las pruebas
│   │   ├── MusicPlayer.Tests/   ← 15 pruebas unitarias (xUnit)
│   │   ├── MusicPlayer.BDD/     ← 5 escenarios BDD (SpecFlow)
│   │   └── MusicPlayer.UITests/ ← 6 pruebas UI (Selenium)
│   └── MusicPlayer.sln          ← Solución de Visual Studio
│
├── 📁 tests/                    ← Pruebas del Repositorio UPT
│   ├── UPT.UITests/             ← 8 pruebas UI (Selenium + xUnit)
│   └── UPT.BDD/                 ← 7 escenarios BDD (SpecFlow)
│
├── 📁 .github/workflows/        ← CI/CD con GitHub Actions
│   ├── test-coverage.yml        ← Unit + BDD tests Music Player
│   ├── ui-tests.yml             ← UI tests Music Player
│   └── upt-tests.yml            ← UI + BDD tests Repositorio UPT
│
├── 📄 README.md                 ← Documentación principal
└── 📄 PROJECT_COMPLETE_SUMMARY.md ← Resumen completo del proyecto
```

## ⚡ Comandos Rápidos

### 🎵 Music Player

```powershell
# Compilar todo
cd MusicPlayer
dotnet build MusicPlayer.sln --configuration Release

# Ejecutar TODAS las pruebas (26 tests)
dotnet test MusicPlayer.sln

# Ejecutar solo pruebas unitarias (15 tests)
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj

# Ejecutar solo pruebas BDD (5 scenarios)
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj

# Ejecutar aplicación web
cd src/MusicPlayer.Web
dotnet run
# Luego abrir: https://localhost:5001

# Ejecutar pruebas UI (6 tests) - En otra terminal
# Chrome
$env:BROWSER="chrome"
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj

# Firefox
$env:BROWSER="firefox"
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj
```

### 🎓 UPT Repository Tests

```powershell
# Ejecutar pruebas UI (8 tests)
dotnet test tests/UPT.UITests/UPT.UITests.csproj

# Ejecutar pruebas BDD (7 scenarios)
dotnet test tests/UPT.BDD/UPT.BDD.csproj

# Con Firefox
$env:BROWSER="firefox"
dotnet test tests/UPT.UITests/UPT.UITests.csproj
dotnet test tests/UPT.BDD/UPT.BDD.csproj

# Compilar ambos proyectos
dotnet build tests/UPT.UITests/UPT.UITests.csproj --configuration Release
dotnet build tests/UPT.BDD/UPT.BDD.csproj --configuration Release
```

## 📊 Generar Reportes de Cobertura (Music Player)

```powershell
cd MusicPlayer

# Ejecutar tests con cobertura
dotnet test --collect:"XPlat Code Coverage"

# Instalar herramienta de reportes (solo una vez)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Generar reporte HTML
reportgenerator `
  -reports:"**/coverage.cobertura.xml" `
  -targetdir:"coverage-report" `
  -reporttypes:"Html;Badges"

# Abrir reporte en navegador
start coverage-report/index.html
```

## 🎬 Ver Videos de Pruebas (GitHub Pages)

Una vez que ejecutes los workflows en GitHub Actions, los videos estarán disponibles en:

- **Music Player UI Tests**: 
  `https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/ui-tests-report/`

- **UPT Repository Tests**: 
  `https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/upt-test-videos/`

- **Reporte de Cobertura**: 
  `https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/coverage/`

## 🔧 Troubleshooting

### Error: No se encuentra .NET SDK

```powershell
# Verificar instalación
dotnet --version

# Debe mostrar: 8.0.xxx
```

### Error: ChromeDriver no encontrado

```powershell
# Los drivers se descargan automáticamente con el paquete NuGet
# Si hay error, restaurar dependencias
dotnet restore
```

### Error: Puerto 5001 en uso (Music Player Web)

```powershell
# Usar otro puerto
cd MusicPlayer/src/MusicPlayer.Web
dotnet run --urls "http://localhost:5002"
```

### Error: Tests UI no encuentran elementos

```powershell
# Asegúrate de que la aplicación web esté corriendo
# En otra terminal:
cd MusicPlayer/src/MusicPlayer.Web
dotnet run

# Espera a que muestre: "Now listening on: https://localhost:5001"
# Luego ejecuta los tests UI
```

## 📈 Estadísticas Rápidas

| Proyecto | Tests Unitarios | Tests BDD | Tests UI | Total | Cobertura |
|----------|-----------------|-----------|----------|-------|-----------|
| Music Player | 15 | 5 | 6 | 26 | >80% |
| UPT Repository | 0 | 7 | 8 | 15 | N/A |
| **TOTAL** | **15** | **12** | **14** | **41** | **>80%** |

## 🎯 Checklist de Verificación

### Antes de hacer push a GitHub:

- [ ] Todas las pruebas pasan localmente
  ```powershell
  cd MusicPlayer
  dotnet test MusicPlayer.sln
  dotnet test ../tests/UPT.UITests/UPT.UITests.csproj
  dotnet test ../tests/UPT.BDD/UPT.BDD.csproj
  ```

- [ ] No hay errores de compilación
  ```powershell
  dotnet build MusicPlayer/MusicPlayer.sln --configuration Release
  dotnet build tests/UPT.UITests/UPT.UITests.csproj --configuration Release
  dotnet build tests/UPT.BDD/UPT.BDD.csproj --configuration Release
  ```

- [ ] GitHub Pages está habilitado
  - Settings → Pages → Source: "GitHub Actions"

### Después de hacer push:

- [ ] Verificar workflows en Actions tab
- [ ] Esperar a que todos los workflows terminen (verde ✅)
- [ ] Verificar publicación en GitHub Pages
- [ ] Revisar videos generados

## 🚀 Ejecutar Todo de una Vez

### PowerShell Script (Windows)

```powershell
# Guardar como run-all-tests.ps1

Write-Host "🎵 Ejecutando pruebas de Music Player..." -ForegroundColor Cyan
cd MusicPlayer
dotnet test MusicPlayer.sln

Write-Host "`n🎓 Ejecutando pruebas UI de UPT..." -ForegroundColor Cyan
cd ..
dotnet test tests/UPT.UITests/UPT.UITests.csproj

Write-Host "`n🎓 Ejecutando pruebas BDD de UPT..." -ForegroundColor Cyan
dotnet test tests/UPT.BDD/UPT.BDD.csproj

Write-Host "`n✅ ¡Todas las pruebas completadas!" -ForegroundColor Green
```

Ejecutar:
```powershell
.\run-all-tests.ps1
```

### Bash Script (Linux/Mac)

```bash
# Guardar como run-all-tests.sh

echo "🎵 Ejecutando pruebas de Music Player..."
cd MusicPlayer
dotnet test MusicPlayer.sln

echo -e "\n🎓 Ejecutando pruebas UI de UPT..."
cd ..
dotnet test tests/UPT.UITests/UPT.UITests.csproj

echo -e "\n🎓 Ejecutando pruebas BDD de UPT..."
dotnet test tests/UPT.BDD/UPT.BDD.csproj

echo -e "\n✅ ¡Todas las pruebas completadas!"
```

Ejecutar:
```bash
chmod +x run-all-tests.sh
./run-all-tests.sh
```

## 📚 Documentación Adicional

- **README.md** - Documentación completa del proyecto
- **PROJECT_COMPLETE_SUMMARY.md** - Resumen detallado con estadísticas
- **MusicPlayer/INSTALL.md** - Guía de instalación detallada
- **MusicPlayer/USAGE_GUIDE.md** - Guía de uso con ejemplos
- **MusicPlayer/PROJECT_SUMMARY.md** - Resumen del Music Player

## 🆘 Ayuda

¿Problemas? Revisa:
1. Que tengas .NET 8.0 SDK instalado
2. Que las dependencias estén restauradas (`dotnet restore`)
3. Que los navegadores (Chrome/Firefox) estén instalados para UI tests
4. Los logs de GitHub Actions si falla el CI/CD

## 📧 Contacto

**Curso**: SI784 - Verificación y Validación de Software  
**Universidad**: Universidad Privada de Tacna - FAING - EPIS

---

**¡Listo para usar!** 🚀

Última actualización: 31 de Octubre de 2025
