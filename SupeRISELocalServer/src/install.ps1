# install.ps1 - Windows installer for OpenClawWallet

$ErrorActionPreference = "Stop"

if (-not [System.Environment]::Is64BitOperatingSystem) {
    Write-Host "❌ 64-bit Windows is required!"
    Write-Host "Your system architecture: $env:PROCESSOR_ARCHITECTURE"
    exit 1
}

$APP_NAME = "OpenClawWalletServer"
$REPO = "appfi5/OpenClawWallet"
$INSTALL_DIR = "$env:USERPROFILE\openClawWallet"
$LOG_FILE = "$INSTALL_DIR\openclaw.log"
$FILE = "${APP_NAME}-win-x64.zip"
$URL = "https://github.com/${REPO}/releases/latest/download/${FILE}"

Write-Host "📁 Install directory: $INSTALL_DIR"

if (-not (Test-Path $INSTALL_DIR)) {
    New-Item -ItemType Directory -Path $INSTALL_DIR -Force | Out-Null
}

Push-Location $INSTALL_DIR

Write-Host "⬇️ Downloading $FILE..."

try {
    Invoke-WebRequest -Uri $URL -OutFile $FILE -UseBasicParsing
}
catch {
    Write-Host "❌ Download failed: $_"
    Write-Host "Please check your network connection and try again."
    Pop-Location
    exit 1
}

Write-Host "📦 Extracting $FILE..."

try {
    Expand-Archive -Path $FILE -DestinationPath . -Force
    Remove-Item $FILE -Force
}
catch {
    Write-Host "❌ Extraction failed: $_"
    Pop-Location
    exit 1
}

if (-not (Test-Path "$APP_NAME.exe")) {
    Write-Host "❌ Executable file not found after extraction!"
    Pop-Location
    exit 1
}

if (-not (Test-Path "appsettings.json") -and -not (Test-Path "appsettings.Production.json")) {
    Write-Host "❌ Configuration file not found after extraction!"
    Pop-Location
    exit 1
}

Write-Host "✅ Download and extraction completed"

if (-not (Test-Path $LOG_FILE)) {
    New-Item -ItemType File -Path $LOG_FILE -Force | Out-Null
}

Write-Host "🔄 Stopping old process..."

Get-Process -Name $APP_NAME -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue

Write-Host "🚀 Starting $APP_NAME..."

Start-Process -FilePath ".\$APP_NAME.exe" -ArgumentList "--urls", "http://*:18799" -NoNewWindow -RedirectStandardOutput $LOG_FILE -RedirectStandardError $LOG_FILE

Start-Sleep -Seconds 2

$IP = "localhost"

Write-Host ""
Write-Host "✅ OpenClaw Wallet Server started!"
Write-Host "🌐 Access at: http://$IP:18799/openclaw-wallet-server/swagger/index.html"
Write-Host "📄 Log file: $LOG_FILE"
Write-Host "📁 Data directory: $INSTALL_DIR\data"

Pop-Location
