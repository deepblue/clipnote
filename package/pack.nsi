!include MUI2.nsh
;!include WinMessages.nsh

Name "ClipNote"

OutFile "clipnote_setup_081.exe"

InstallDir $PROGRAMFILES\Springnote\ClipNote
InstallDirRegKey HKLM Software\ClipNote ""

RequestExecutionLevel user

!define MUI_ABORTWARNING
!define MUI_FINISHPAGE_RUN "$INSTDIR\ClipNote.exe"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
  
!insertmacro MUI_UNPAGE_WELCOME  
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "English"


; The stuff to install
Section "Program FIles"

  SectionIn RO
  
  Call IsDotNETInstalled
  Pop $R3
  StrCmp $R3 0 +3
    
    DetailPrint "Found .NET framework!"
    Goto +4
    
    ; else
    DetailPrint "Can't find .NET Framework!"
    MessageBox MB_OK|MB_ICONEXCLAMATION "The .NET Framework 3.5 is not installed on your PC.  Use Windows Update to install the .NET Framework or later, or download it from the web page."
	;ExecShell open "http://www.microsoft.com/downloads/details.aspx?FamilyID=262d25e3-f589-4842-8157-034d1e7cf3a3&DisplayLang=en"
	Abort
  
  ;IfFileExists "$INSTDIR\ClipNote.exe" 0 +3
  ;Exec '"$INSTDIR\ClipNote.exe" /stop'
  ;Sleep 1000
  
  SetOutPath $INSTDIR
  File ..\bin\Release\SpringnoteSharp.dll
  File ..\bin\Release\ClipNote.exe

  WriteRegStr HKLM Software\ClipNote "" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ClipNote" "DisplayName" "ClipNote"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ClipNote" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ClipNote" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ClipNote" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

SectionEnd ; end the section

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\ClipNote"
  CreateShortCut "$SMPROGRAMS\ClipNote\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\ClipNote\ClipNote.lnk" "$INSTDIR\ClipNote.exe" "" "$INSTDIR\ClipNote.exe" 0
  
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  IfFileExists "$INSTDIR\ClipNote.exe" 0 +3
  Exec '"$INSTDIR\ClipNote.exe" /stop'
  Sleep 1000
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ClipNote"
  DeleteRegKey HKLM "SOFTWARE\ClipNote"
  DeleteRegValue HKCU "SOFTWARE\Microsoft\Windows\CurrentVersion\Run" "ClipNote"
 
  ; Remove files and uninstaller
  Delete $INSTDIR\*.*

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\ClipNote\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\ClipNote"
  RMDir "$INSTDIR"
  RMDIR /r "$LOCALAPPDATA\Springnote\ClipNote"

SectionEnd




; IsDotNETInstalled
;
; Usage:
;   Call IsDotNETInstalled
;   Pop $0
;   StrCmp $0 1 found.NETFramework no.NETFramework
Function IsDotNETInstalled
  Push $0
  Push $1
  Push $2
  Push $3
  Push $4
 
  ReadRegStr $4 HKEY_LOCAL_MACHINE \
    "Software\Microsoft\.NETFramework" "InstallRoot"
  # remove trailing back slash
  Push $4
  Exch $EXEDIR
  Exch $EXEDIR
  Pop $4
  # if the root directory doesn't exist .NET is not installed
  IfFileExists $4 0 noDotNET
 
  StrCpy $0 0
 
  EnumStart:
 
    EnumRegKey $2 HKEY_LOCAL_MACHINE \
      "Software\Microsoft\.NETFramework\Policy"  $0
    IntOp $0 $0 + 1
    StrCmp $2 "" noDotNET
 
    StrCpy $1 0
 
    EnumPolicy:
 
      EnumRegValue $3 HKEY_LOCAL_MACHINE \
        "Software\Microsoft\.NETFramework\Policy\$2" $1
      IntOp $1 $1 + 1
       StrCmp $3 "" EnumStart
        IfFileExists "$4\$2.$3" foundDotNET EnumPolicy
 
  noDotNET:
    StrCpy $0 0
    Goto done
 
  foundDotNET:
    StrCpy $0 1
 
  done:
    Pop $4
    Pop $3
    Pop $2
    Pop $1
    Exch $0
FunctionEnd