# Guía de Instalación - Music Player Project

## ⚠️ Requisito Obligatorio: .NET SDK 8.0

Este proyecto requiere **.NET 8.0 SDK** para funcionar.

## 📥 Instalación de .NET 8.0 SDK

### Opción 1: Instalador directo de Microsoft (Recomendado)

1. **Descarga el instalador**:
   - Ve a: https://dotnet.microsoft.com/download/dotnet/8.0
   - Descarga el **SDK 8.0** (no solo el Runtime)
   - Para Windows: Descarga el instalador `.exe` de 64-bit

2. **Ejecuta el instalador**:
   - Haz doble clic en el archivo descargado
   - Sigue el asistente de instalación
   - Acepta los términos de licencia
   - Espera a que termine la instalación

3. **Verifica la instalación**:
   ```powershell
   # Cierra y abre una nueva ventana de PowerShell
   dotnet --version
   # Debería mostrar: 8.0.x
   ```

### Opción 2: Usando winget (Windows Package Manager)

```powershell
# Si tienes winget instalado
winget install Microsoft.DotNet.SDK.8
```

### Opción 3: Usando Chocolatey

```powershell
# Si tienes Chocolatey instalado
choco install dotnet-sdk
```

## ✅ Verificación Post-Instalación

Después de instalar .NET SDK, verifica que todo esté correcto:

```powershell
# 1. Verificar versión de .NET
dotnet --version
# Esperado: 8.0.x

# 2. Ver información completa
dotnet --info

# 3. Listar SDKs instalados
dotnet --list-sdks
```

## 🚀 Ejecutar el Proyecto

Una vez instalado .NET SDK:

### Paso 1: Restaurar dependencias

```powershell
dotnet restore MusicPlayer.sln
```

### Paso 2: Compilar la solución

```powershell
dotnet build MusicPlayer.sln --configuration Release
```

### Paso 3: Ejecutar pruebas unitarias

```powershell
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj
```

### Paso 4: Ejecutar pruebas BDD

```powershell
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj
```

### Paso 5: Ejecutar la aplicación web

```powershell
cd src/MusicPlayer.Web
dotnet run
```

Luego abre tu navegador en: `https://localhost:5001` o `http://localhost:5000`

## 🧪 Ejecutar Pruebas con Cobertura

```powershell
# Ejecutar pruebas con cobertura
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj `
  --collect:"XPlat Code Coverage" `
  --results-directory ./coverage

# Instalar ReportGenerator (solo primera vez)
dotnet tool install -g dotnet-reportgenerator-globaltool

# Generar reporte HTML
reportgenerator `
  -reports:"./coverage/**/coverage.cobertura.xml" `
  -targetdir:"./coverage-report" `
  -reporttypes:"Html;Badges"

# Abrir el reporte
start ./coverage-report/index.html
```

## 🌐 Pruebas de UI (Opcional para desarrollo local)

Para ejecutar las pruebas de UI necesitas:

1. **Instalar Chrome o Firefox**
   - Chrome: https://www.google.com/chrome/
   - Firefox: https://www.mozilla.org/firefox/

2. **Ejecutar la aplicación web** (en una terminal):
   ```powershell
   cd src/MusicPlayer.Web
   dotnet run
   ```

3. **Ejecutar las pruebas UI** (en otra terminal):
   ```powershell
   # Para Chrome
   $env:BROWSER="chrome"
   dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj

   # Para Firefox
   $env:BROWSER="firefox"
   dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj
   ```

## 🔧 Solución de Problemas

### "dotnet no se reconoce como comando"

**Causa**: .NET SDK no está instalado o no está en el PATH.

**Solución**:
1. Instala .NET SDK 8.0 (ver arriba)
2. Cierra y abre una nueva terminal PowerShell
3. Verifica: `dotnet --version`

### Error de política de ejecución de scripts

**Solución**:
```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```

### "No se encuentra MSBuild"

**Causa**: Instalaste solo el Runtime, no el SDK.

**Solución**: Instala el SDK completo de .NET 8.0

### Errores de compilación

```powershell
# Limpiar y reconstruir
dotnet clean
dotnet restore
dotnet build
```

## 📋 Checklist de Instalación

- [ ] .NET 8.0 SDK instalado
- [ ] `dotnet --version` funciona y muestra 8.0.x
- [ ] `dotnet restore` funciona sin errores
- [ ] `dotnet build` compila exitosamente
- [ ] Las pruebas unitarias pasan
- [ ] (Opcional) Chrome o Firefox instalado para UI tests

## 🎓 Para el Examen

### Mínimo Requerido (sin navegadores)

1. ✅ .NET SDK 8.0
2. ✅ Código compilando sin errores
3. ✅ Pruebas unitarias pasando (>80% cobertura)
4. ✅ Pruebas BDD pasando

### Completo (con UI Tests)

Todo lo anterior más:
1. ✅ Chrome o Firefox instalado
2. ✅ Pruebas UI pasando en navegador

### GitHub Actions (No requiere instalación local)

Los workflows de GitHub Actions ya tienen todo configurado:
- .NET SDK
- Chrome y Firefox
- FFmpeg para videos
- Todo se ejecuta automáticamente en la nube

## 📞 Ayuda Adicional

Si después de instalar .NET SDK sigues teniendo problemas:

1. **Reinicia tu computadora** después de instalar .NET SDK
2. **Abre una nueva terminal PowerShell** como Administrador
3. Verifica variables de entorno:
   ```powershell
   $env:PATH -split ';' | Select-String 'dotnet'
   ```

## 🔗 Enlaces Útiles

- **Descargar .NET 8.0**: https://dotnet.microsoft.com/download/dotnet/8.0
- **Documentación .NET**: https://docs.microsoft.com/dotnet/
- **Tutorial de instalación**: https://docs.microsoft.com/dotnet/core/install/windows

---

**Nota**: Este proyecto está diseñado para .NET 8.0. No uses versiones anteriores (7.0, 6.0, etc.) ya que algunos features pueden no estar disponibles.

**¡Una vez instalado .NET SDK, todo debería funcionar sin problemas!** 🚀
