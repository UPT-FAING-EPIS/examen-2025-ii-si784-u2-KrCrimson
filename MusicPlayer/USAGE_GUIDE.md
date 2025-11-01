# Guía de Uso - Music Player Test Suite

## 📋 Índice

1. [Ejecución Local](#ejecución-local)
2. [GitHub Actions](#github-actions)
3. [Visualizar Reportes](#visualizar-reportes)
4. [Solución de Problemas](#solución-de-problemas)

## 🚀 Ejecución Local

### Pre-requisitos

```powershell
# Verificar instalación de .NET
dotnet --version
# Debe ser 8.0 o superior

# Instalar herramientas globales
dotnet tool install -g dotnet-reportgenerator-globaltool
```

### Paso 1: Clonar y Compilar

```powershell
# Clonar repositorio
git clone https://github.com/UPT-FAING-EPIS/examen-2025-ii-si784-u2-KrCrimson.git
cd examen-2025-ii-si784-u2-KrCrimson

# Restaurar y compilar
dotnet restore
dotnet build --configuration Release
```

### Paso 2: Ejecutar Pruebas Unitarias

```powershell
# Ejecutar con cobertura
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj `
  --configuration Release `
  --collect:"XPlat Code Coverage" `
  --results-directory ./coverage

# Generar reporte HTML
reportgenerator `
  -reports:"./coverage/**/coverage.cobertura.xml" `
  -targetdir:"./coverage/report" `
  -reporttypes:"Html;Badges"

# Abrir reporte
start ./coverage/report/index.html
```

### Paso 3: Ejecutar Pruebas BDD

```powershell
# Ejecutar pruebas SpecFlow
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj --configuration Release

# Ver resultados en la consola
```

### Paso 4: Ejecutar Pruebas de UI

```powershell
# Terminal 1: Iniciar la aplicación web
cd src/MusicPlayer.Web
dotnet run --configuration Release

# Terminal 2: Ejecutar pruebas en Chrome
$env:BROWSER="chrome"
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj

# Ejecutar pruebas en Firefox
$env:BROWSER="firefox"
dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj
```

## ⚙️ GitHub Actions

### Configuración Inicial

1. **Habilitar GitHub Pages**:
   - Ve a `Settings` → `Pages`
   - En "Source", selecciona `GitHub Actions`
   - Guarda los cambios

2. **Permisos del Workflow**:
   - Ve a `Settings` → `Actions` → `General`
   - En "Workflow permissions", selecciona `Read and write permissions`
   - Marca `Allow GitHub Actions to create and approve pull requests`
   - Guarda los cambios

### Workflows Disponibles

#### 1. Test Coverage Workflow

**Trigger**: Push a `main` o `develop`, Pull Requests

**Ejecuta**:
- Pruebas unitarias con cobertura
- Pruebas BDD
- Genera reportes HTML
- Publica en GitHub Pages (solo en main)

**URL del Reporte**: 
```
https://<tu-usuario>.github.io/<tu-repo>/coverage/
```

#### 2. UI Tests Workflow

**Trigger**: Push a `main` o `develop`, Pull Requests, Manual

**Ejecuta**:
- Inicia la aplicación web
- Ejecuta pruebas en Chrome y Firefox en paralelo
- Graba videos de cada ejecución
- Publica resultados y videos en GitHub Pages

**URL de Resultados**: 
```
https://<tu-usuario>.github.io/<tu-repo>/ui-tests-report/
```

### Ejecutar Workflow Manualmente

1. Ve a la pestaña `Actions`
2. Selecciona el workflow deseado
3. Haz clic en `Run workflow`
4. Selecciona la rama
5. Haz clic en `Run workflow`

## 📊 Visualizar Reportes

### Reportes de Cobertura

Después de ejecutar el workflow, los reportes estarán disponibles en:

```
https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/coverage/
```

**Contenido**:
- Resumen de cobertura por proyecto
- Cobertura detallada por clase
- Líneas cubiertas/no cubiertas
- Badges de cobertura

### Reportes de UI Tests

Videos y resultados en:

```
https://UPT-FAING-EPIS.github.io/examen-2025-ii-si784-u2-KrCrimson/ui-tests-report/
```

**Contenido**:
- Videos de ejecución en Chrome
- Videos de ejecución en Firefox
- Información del commit y branch

### Artefactos en GitHub Actions

Los workflows también generan artefactos descargables:

1. Ve a la pestaña `Actions`
2. Selecciona la ejecución deseada
3. Baja hasta `Artifacts`
4. Descarga:
   - `coverage-report`: Reporte HTML de cobertura
   - `test-results`: Resultados de pruebas
   - `test-video-chrome`: Video de Chrome
   - `test-video-firefox`: Video de Firefox

## 🔧 Solución de Problemas

### Error: "No se puede conectar a la aplicación web"

```powershell
# Verificar que la aplicación esté corriendo
netstat -ano | findstr :5000

# Si no está corriendo, iniciarla:
cd src/MusicPlayer.Web
dotnet run
```

### Error: "ChromeDriver no encontrado"

```powershell
# Reinstalar el paquete
dotnet add tests/MusicPlayer.UITests package Selenium.WebDriver.ChromeDriver
```

### Error: "Cobertura menor al 80%"

```powershell
# Ver reporte detallado
reportgenerator `
  -reports:"./coverage/**/coverage.cobertura.xml" `
  -targetdir:"./coverage/report" `
  -reporttypes:"Html"

# Abrir y revisar clases sin cobertura
start ./coverage/report/index.html
```

### GitHub Actions: "Permission denied"

1. Ve a `Settings` → `Actions` → `General`
2. En "Workflow permissions", selecciona `Read and write permissions`
3. Guarda y re-ejecuta el workflow

### GitHub Pages: "404 Not Found"

1. Espera 2-3 minutos después del deploy
2. Verifica que GitHub Pages esté habilitado
3. Verifica la URL (debe incluir el nombre del repo)
4. Limpia caché del navegador

### Videos no se generan en GitHub Actions

El workflow incluye grabación con FFmpeg y Xvfb. Si falla:

1. Revisa los logs del step "Start video recording"
2. Verifica que FFmpeg esté instalado
3. Asegúrate de que el DISPLAY esté configurado

## 📝 Comandos Útiles

```powershell
# Ver estructura del proyecto
tree /F /A

# Limpiar solución
dotnet clean

# Ejecutar solo una prueba específica
dotnet test --filter "FullyQualifiedName~PlayCommand"

# Ver cobertura en consola
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov

# Verificar versión de navegadores
chrome --version
firefox --version

# Detener todos los procesos de dotnet
taskkill /F /IM dotnet.exe
```

## 🎓 Tips para el Examen

1. **Antes de entregar**:
   - ✅ Ejecuta todas las pruebas localmente
   - ✅ Verifica que la cobertura sea >= 80%
   - ✅ Revisa que los workflows pasen en GitHub
   - ✅ Confirma que GitHub Pages esté publicado

2. **Para debugging**:
   - Usa los artefactos de GitHub Actions
   - Revisa los logs de cada step
   - Ejecuta localmente primero

3. **Documentación**:
   - Actualiza el README.md con tu nombre
   - Agrega screenshots si es necesario
   - Documenta cualquier cambio adicional

## 📞 Soporte

Si tienes problemas:

1. Revisa esta guía
2. Consulta los logs de GitHub Actions
3. Verifica la configuración de GitHub Pages
4. Contacta al profesor del curso

---

**Última actualización**: Octubre 2025
