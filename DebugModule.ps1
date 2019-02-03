Set-Location ..\..\..\..\

# .\build.ps1

$trashFolders = Get-ChildItem -Path ".trash"

$lastTrashFolder = $trashFolders[-1]

Set-Location $lastTrashFolder

Set-Location "artifacts"

Import-Module .\TIKSN-PowerShell-Cmdlets.psd1
