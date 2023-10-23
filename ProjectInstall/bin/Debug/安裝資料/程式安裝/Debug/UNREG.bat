echo off
RegAsm.exe /u /tlb /codebase clsShiniCss.dll
del clsShiniCss.tlb
RegAsm.exe /u clsShiniCss.dll
