@echo off
echo Deletando todas as pastas 'obj' e 'bin' no diretório atual e seus subdiretórios...
for /d /r . %%d in (obj bin) do (
    if exist "%%d" (
        echo Deletando "%%d"
        rmdir /s /q "%%d"
    )
)
echo Concluído!
pause
