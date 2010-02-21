msbuild .\Publish.csproj /p:Configuration=Release /p:CCNetLabel=0.0.0


if ($LastExitCode -eq 0)
{
	if (Test-Path 'C:\Program Files\NCover')
    {
		& 'C:\Program Files\NCover\NCoverExplorer.Console.exe' .\Reports\*.coverage.xml /s:.\Reports\ncover-fullreport.xml /h:.\Reports\Coverage\ /r:FullCoverageReport
	}
	else
	{
		& 'Library\NCoverExplorer\NCoverExplorer.console.exe' .\Reports\*.coverage.xml /s:.\Reports\ncover-fullreport.xml
	}
}