$NamespacePrefix = Read-Host -Prompt 'Solution prefix to replace Repetiva'
Write-Host "Renaming Repetiva to $NamespacePrefix"

gci -r -include "*.sln","*.csproj","*.cs" |
 foreach-object { $a = $_.fullname; ( get-content $a ) |
 foreach-object { $_ -replace 'Repetiva',$NamespacePrefix }  | 
set-content $a }

Get-ChildItem -Filter *.sln | Rename-Item -NewName { $_.Name -replace 'Repetiva', $NamespacePrefix }
Get-ChildItem -Path .\ -Directory | Rename-Item -NewName { $_.Name -replace 'Repetiva',$NamespacePrefix }
Get-ChildItem -Recurse -Filter *.csproj | Rename-Item -NewName { $_.Name -replace 'Repetiva', $NamespacePrefix }
