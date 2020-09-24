param([String]$RabbitDllPath = "not specified")
Set-ExecutionPolicy Unrestricted

Write-Host "Rabbit DLL Path: "
Write-Host $RabbitDllPath -ForegroundColor Green

$absoluteRabbitDllPath = Resolve-Path $RabbitDllPath

Write-Host "Absolute Rabbit Dll Path: "

[Reflection,Assembly]::LoadFile($absoluteRabbitDllPath)

Write-Host "Setting up RabbitMQ Connection Factory"
$factory = New-Object RabbitMQ.Client.ConnectionFactory
$hostNameProp = [RabbitMQ.Client.ConnctionFactory].GetField("HostName")
$hostNameProp.SetValue($factory, "localhost")

$usernameProp = [RabbitMQ.Client.ConnctionFactory].GetField("UserName")
$usernameProp.SetValue($factory, "guest")

$passwordProp = [RabbitMQ.Client.ConnctionFactory].GetField("Password")
$passwordProp.SetValue($factory, "guest")

$createConnectionMethod = [RabbitMQ.Client.ConnctionFactory].GetMethod(