rem yourTest.bat  
@echo off  
MyMainTest  
@if "%ERRORLEVEL%" == "0" goto ok  
  
:fail  
    echo Execution Failed  
    echo return value = %ERRORLEVEL%  
    goto end  
  
:ok  
    echo Execution succeeded  
    echo Return value = %ERRORLEVEL%  
    goto end  
  
:end  