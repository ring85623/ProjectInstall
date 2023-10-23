echo off
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /u /tlb /codebase clsShiniCss.dll
del clsShiniCss.tlb
C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /tlb /codebase clsShiniCss.dll
