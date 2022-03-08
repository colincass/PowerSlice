param ([string]$versionSuffix = "",
  [string]$configuration = "Release")
$ErrorActionPreference = "Stop"

# Set location to the Solution directory
(Get-Item $PSScriptRoot).Parent.FullName | Push-Location

[xml] $versionFile = Get-Content "./build/DependencyVersions.props"
$node = $versionFile.SelectSingleNode("Project/PropertyGroup/CmsCoreVersionCommon")
$coreVersion = $node.InnerText
$parts = $coreVersion.Split(".")
$major = [int]::Parse($parts[0]) + 1
$coreNextMajorVersion = ($major.ToString() + ".0.0") 

$findNode = $versionFile.SelectSingleNode("Project/PropertyGroup/FindVersionCommon")
$findVersion = $findNode.InnerText
$findParts = $findVersion.Split(".")
$findMajor = [int]::Parse($findParts[0]) + 1
$findNextMajorVersion = $findMajor.ToString() 

$fwNode = $versionFile.SelectSingleNode("Project/PropertyGroup/FrameworkVersionCommon")
$fwVersion = $fwNode.InnerText
$fwParts = $fwVersion.Split(".")
$fwMajor = [int]::Parse($fwParts[0]) + 1
$fwNextMajorVersion = ($fwMajor.ToString() + ".0.0") 

[xml] $versionFile = Get-Content "./PowerSlice/version.props"
$pVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/VersionPrefix").InnerText + $versionSuffix 

dotnet pack --no-restore --no-build -c $configuration /p:PackageVersion=$pVersion /p:CoreVersion=$coreVersion /p:CoreNextMajorVersion=$coreNextMajorVersion /p:FindVersion=$findVersion /p:FindindNextMajorVersion=$findNextMajorVersion /p:FwVersion=$fwVersion /p:FwNextMajorVersion=$fwNextMajorVersion PowerSlice.sln

Pop-Location

