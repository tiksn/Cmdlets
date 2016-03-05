;NSIS Modern User Interface

;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "TIKSN PowerShell Cmdlets"
  OutFile "Bin\Local Deploy.exe"

  ;Default installation folder
  InstallDir "$DOCUMENTS\WindowsPowerShell\Modules\TIKSN-PowerShell-Cmdlets"
  
  ;Request application privileges for Windows Vista
  RequestExecutionLevel user

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

;  !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
;  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Binaries" Binaries

  SetOutPath "$INSTDIR"
  
  File /r "Bin\Release\*"

SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_Binaries ${LANG_ENGLISH} "Module binary files."

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${Binaries} $(DESC_Binaries)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
