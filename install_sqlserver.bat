@echo off

echo Descargando SQL Server 2019 Express...
powershell -Command "Invoke-WebRequest -Uri https://go.microsoft.com/fwlink/?linkid=866658 -OutFile SQLEXPR.exe"

echo Instalando SQL Server en modo basico...
SQLEXPR.exe /ACTION=Install /FEATURES=SQLEngine /INSTANCENAME=SQLEXPRESS /Q

echo Instalacion completada.
pause
