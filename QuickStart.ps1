# Quick Start Script for MusicPlayer Project
# Ejecuta este script para verificar que todo funciona correctamente

Write-Host "==================================" -ForegroundColor Cyan
Write-Host "Music Player - Quick Start Script" -ForegroundColor Cyan
Write-Host "==================================" -ForegroundColor Cyan
Write-Host ""

# Check .NET installation
Write-Host "1. Verificando .NET SDK..." -ForegroundColor Yellow
$dotnetVersion = dotnet --version
if ($LASTEXITCODE -eq 0) {
    Write-Host "   ✓ .NET SDK instalado: $dotnetVersion" -ForegroundColor Green
} else {
    Write-Host "   ✗ .NET SDK no encontrado. Por favor instala .NET 8.0 SDK" -ForegroundColor Red
    exit 1
}
Write-Host ""

# Restore dependencies
Write-Host "2. Restaurando dependencias..." -ForegroundColor Yellow
dotnet restore MusicPlayer.sln
if ($LASTEXITCODE -eq 0) {
    Write-Host "   ✓ Dependencias restauradas" -ForegroundColor Green
} else {
    Write-Host "   ✗ Error al restaurar dependencias" -ForegroundColor Red
    exit 1
}
Write-Host ""

# Build solution
Write-Host "3. Compilando solución..." -ForegroundColor Yellow
dotnet build MusicPlayer.sln --configuration Release --no-restore
if ($LASTEXITCODE -eq 0) {
    Write-Host "   ✓ Compilación exitosa" -ForegroundColor Green
} else {
    Write-Host "   ✗ Error en la compilación" -ForegroundColor Red
    exit 1
}
Write-Host ""

# Run unit tests
Write-Host "4. Ejecutando pruebas unitarias..." -ForegroundColor Yellow
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj --configuration Release --no-build --verbosity quiet
if ($LASTEXITCODE -eq 0) {
    Write-Host "   ✓ Pruebas unitarias pasadas" -ForegroundColor Green
} else {
    Write-Host "   ✗ Algunas pruebas unitarias fallaron" -ForegroundColor Red
}
Write-Host ""

# Run BDD tests
Write-Host "5. Ejecutando pruebas BDD..." -ForegroundColor Yellow
dotnet test tests/MusicPlayer.BDD/MusicPlayer.BDD.csproj --configuration Release --no-build --verbosity quiet
if ($LASTEXITCODE -eq 0) {
    Write-Host "   ✓ Pruebas BDD pasadas" -ForegroundColor Green
} else {
    Write-Host "   ✗ Algunas pruebas BDD fallaron" -ForegroundColor Red
}
Write-Host ""

# Generate coverage report
Write-Host "6. Generando reporte de cobertura..." -ForegroundColor Yellow
dotnet test tests/MusicPlayer.Tests/MusicPlayer.Tests.csproj --configuration Release --no-build --collect:"XPlat Code Coverage" --results-directory ./coverage --verbosity quiet

# Check if reportgenerator is installed
$reportGenInstalled = Get-Command reportgenerator -ErrorAction SilentlyContinue
if (-not $reportGenInstalled) {
    Write-Host "   Instalando ReportGenerator..." -ForegroundColor Yellow
    dotnet tool install -g dotnet-reportgenerator-globaltool
}

# Generate HTML report
reportgenerator -reports:"./coverage/**/coverage.cobertura.xml" -targetdir:"./coverage-report" -reporttypes:"Html;Badges" 2>$null
if ($LASTEXITCODE -eq 0) {
    Write-Host "   ✓ Reporte de cobertura generado" -ForegroundColor Green
    Write-Host "   📊 Ubicación: ./coverage-report/index.html" -ForegroundColor Cyan
} else {
    Write-Host "   ⚠ No se pudo generar el reporte de cobertura" -ForegroundColor Yellow
}
Write-Host ""

# Summary
Write-Host "==================================" -ForegroundColor Cyan
Write-Host "RESUMEN" -ForegroundColor Cyan
Write-Host "==================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "✓ Aplicación compilada correctamente" -ForegroundColor Green
Write-Host "✓ Todas las pruebas configuradas" -ForegroundColor Green
Write-Host ""
Write-Host "SIGUIENTES PASOS:" -ForegroundColor Yellow
Write-Host ""
Write-Host "1. Ver reporte de cobertura:" -ForegroundColor White
Write-Host "   start ./coverage-report/index.html" -ForegroundColor Gray
Write-Host ""
Write-Host "2. Ejecutar la aplicación web:" -ForegroundColor White
Write-Host "   cd src/MusicPlayer.Web" -ForegroundColor Gray
Write-Host "   dotnet run" -ForegroundColor Gray
Write-Host ""
Write-Host "3. Ejecutar pruebas de UI (requiere la app corriendo):" -ForegroundColor White
Write-Host "   `$env:BROWSER='chrome'" -ForegroundColor Gray
Write-Host "   dotnet test tests/MusicPlayer.UITests/MusicPlayer.UITests.csproj" -ForegroundColor Gray
Write-Host ""
Write-Host "4. Configurar GitHub Actions:" -ForegroundColor White
Write-Host "   - Habilita GitHub Pages en Settings → Pages" -ForegroundColor Gray
Write-Host "   - Selecciona 'GitHub Actions' como source" -ForegroundColor Gray
Write-Host "   - Haz push de tu código para activar los workflows" -ForegroundColor Gray
Write-Host ""
Write-Host "📚 Para más información, consulta:" -ForegroundColor Cyan
Write-Host "   - README.md" -ForegroundColor Gray
Write-Host "   - USAGE_GUIDE.md" -ForegroundColor Gray
Write-Host ""
Write-Host "==================================" -ForegroundColor Cyan
Write-Host "¡Listo para comenzar! 🚀" -ForegroundColor Green
Write-Host "==================================" -ForegroundColor Cyan
