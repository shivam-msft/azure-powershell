Current status of work:
------------------------

Cmdlets completed:
VM cmdlets: Get-AzVMwareVM, New-AzVMwareVM (Incomplete without the NIC cmdlets)
Disk cmdlets: 'New-AzVMwareDiskConfig', 'Add-AzVMwareDisk', 'New-AzVMwareDisk', 'Remove-AzVMwareDisk', 'Get-AzVMwareDisk'

Future work:
- Add name or id support for parameters.
- Custom validators like positive integer only for cores, ram, etc.
- Check Async, and asyncNext operations in SDK. Async behaviour for commands guidelines.
- Location default to resource's group location.
- Setting default for parameters.
- Author help for all commands.
- Author tests. 
Service principal creation steps:
az ad sp create-for-rbac --name avs-powershell-test;
az role assignment create --role Contributor --assignee <appId>  --subscription 67dabe03-217a-4d30-97a0-40387d7bbec1
- Follow design guidelines for PSH (https://github.com/Azure/azure-powershell/tree/master/documentation/development-docs/design-guidelines):
Wrapped SDK type for output. For no output (add pass through)
Add ShouldProcess for cmdlets that change object on server.
AsJob for long running operations
Required parameters sets.
Piping practices
Parameter practices
Module practices
Should process, confirm impact


Dev guide:
------------

Official dev docs: https://github.com/Azure/azure-powershell/tree/master/documentation/development-docs

Setup:
	1. Setup basic prerequisites and environment setup following this guide: https://github.com/Azure/azure-powershell/blob/master/documentation/development-docs/azure-powershell-developer-guide.md#prerequisites
	Central repo: https://github.com/Azure/azure-powershell
	Local fork: https://github.com/shivam-msft/azure-powershell
	2. Copy paste the code (VMwareCloudSimple) folder in azure-powershell/src/
	3. Develop the PowerShell module in VS.
	4. Include the new cmdlet in the file Az.VMwareCloudSimple.psd1 (cmdlets to export section)
	5. Build it from VS (You might need to build using cmd once).
	6. You can test by using Debug>Start, or open PowerShell and import module: Import-Module D:/PowerShell_for_VMwareCS/azure-powershell/artifacts/Debug/Az.VMwareCloudSimple/Az.VMwareCloudSimple.psd1;

Logging in to PowerShell subscription:
	1. Login to PowerShell: Connect-AzAccount
	2.  $context = Get-AzSubscription -SubscriptionId 67dabe03-217a-4d30-97a0-40387d7bbec1
	3. Set-AzContext $context


Generating help:
	1. If you have markdown files generated, and made changes in them directly. Go to step 3.
	2. Write help for params in VS. Build in VS.
	3. If you made changes in your source code, you need to generate new markdown files:
		a. Open PowerShell.
		b. $PathToModuleManifest = <path-to-repo-root>\artifacts\Debug\Az.VMwareCloudSimple\Az.VMwareCloudSimple.psd1>
		$PathToModuleManifest = "D:\PowerShell_for_VMwareCS\azure-powershell\artifacts\Debug\Az.VMwareCloudSimple\Az.VMwareCloudSimple.psd1"
		c. Import-Module -Name $PathToModuleManifest
		d. $PathToHelpFolder = "<path-to-repo-root>\src\VMwareCloudSimple\VMwareCloudSimple\help"
		$PathToHelpFolder = "D:\PowerShell_for_VMwareCS\azure-powershell\src\VMwareCloudSimple\VMwareCloudSimple\help"
			i. For new cmdlets:
				New-MarkdownHelp -Module Az.VMwareCloudSimple -OutputFolder $PathToHelpFolder -AlphabeticParamsOrder -UseFullTypeName -WithModulePage
			ii. For updating existing cmdlets:
				Update-MarkdownHelpModule -Path $PathToHelpFolder -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName
	4. Now, the markdown files have been updated in src, if you build in VS, they will get updated in artifacts folder.
	5. Build dll-Help.xml file from artifacts help:
		a. $PathToHelpFolder = "D:\PowerShell_for_VMwareCS\azure-powershell\artifacts\Debug\Az.VMwareCloudSimple\help"
		b. $PathToOutputFolder = "D:\PowerShell_for_VMwareCS\azure-powershell\artifacts\Debug\Az.VMwareCloudSimple"
		c. New-ExternalHelp -Path $PathToHelpFolder -OutputPath $PathToOutputFolder
