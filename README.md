# NetCoreSreviceWithTopShelf
Host .net Core console app as windows service

To run as a console app:

` dotnet run ` 

To install as a Windows service, first publish targetting Windows:

` dotnet publish NetCoreSreviceWithTopShelf.csproj -r win10-x64 `

and then use the Topshelf install command on the .exe file:

`cd NetCoreSreviceWithTopShelf\bin\Debug\netcoreapp2.2\win10-x64\publish
NetCoreSreviceWithTopShelf.exe install`
