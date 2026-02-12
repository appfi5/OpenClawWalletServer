#!/bin/sh
# install.sh - Cross-platform (Linux/macOS) installer for OpenClawWalletServer

set -e

APP_NAME="OpenClawWalletServer"
REPO="appfi5/OpenClawWalletServer"  # 👈 替换为你的 GitHub 用户名/组织
INSTALL_DIR="$HOME/.openclaw"
LOG_FILE="$INSTALL_DIR/openclaw.log"

# Create install dir
mkdir -p "$INSTALL_DIR"
cd "$INSTALL_DIR"

# Detect OS and architecture
UNAME_S=$(uname -s)
UNAME_M=$(uname -m)

OS=""
ARCH=""

case "$UNAME_S" in
    Linux*)
        OS="linux"
        ;;
    Darwin*)
        OS="osx"
        ;;
    *)
        echo "❌ Unsupported OS: $UNAME_S"
        exit 1
        ;;
esac

case "$UNAME_M" in
    x86_64|amd64)
        ARCH="x64"
        ;;
    aarch64|arm64)
        if [ "$OS" = "osx" ]; then
            ARCH="arm64"
        else
            ARCH="x64"  # .NET on Linux ARM64 uses linux-arm64, but many still use x64 emulation
            # Optional: support linux-arm64 if you build it
            # ARCH="arm64"
        fi
        ;;
    *)
        echo "❌ Unsupported architecture: $UNAME_M"
        exit 1
        ;;
esac

# Special case: macOS ARM64
if [ "$OS" = "osx" ] && [ "$UNAME_M" = "arm64" ]; then
    ARCH="arm64"
fi

# Map to .NET RID
if [ "$OS" = "osx" ]; then
    if [ "$ARCH" = "arm64" ]; then
        RID="osx-arm64"
    else
        RID="osx-x64"
    fi
else
    # Assume Linux
    if [ "$ARCH" = "arm64" ]; then
        RID="linux-arm64"
    else
        RID="linux-x64"
    fi
fi

FILE="${APP_NAME}-${RID}.tar.gz"
URL="https://github.com/${REPO}/releases/latest/download/${FILE}"

echo "🔍 Detected OS: $OS, Arch: $UNAME_M → Using ${RID}"
echo "⬇️ Downloading $FILE..."

# Download and extract
curl -L --progress-bar "$URL" | tar -xz
chmod +x "$APP_NAME"

# 如果日志文件不存在，则创建一个
if [ ! -f "$LOG_FILE" ]; then
    touch "$LOG_FILE"
fi

# Stop old process
pkill -f "$APP_NAME" 2>/dev/null || true

# Start in background
nohup "./$APP_NAME" --urls "http://*:8080" > "$LOG_FILE" 2>&1 &
sleep 2

# Get IP for Linux
if [ "$OS" = "Linux" ]; then
    IP=$(hostname -I | awk '{print $1}')
else
    IP="localhost"
fi

echo "✅ OpenClaw Wallet Server started!"
echo "🌐 Access at: http://$IP:8080/openclaw-wallet-server/swagger/index.html"
echo "📄 Log file: $LOG_FILE"