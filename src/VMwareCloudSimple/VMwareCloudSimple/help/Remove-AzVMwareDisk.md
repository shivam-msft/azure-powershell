---
external help file: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.dll-Help.xml
Module Name: Az.VMwareCloudSimple
online version:
schema: 2.0.0
---

# Remove-AzVMwareDisk

## SYNOPSIS
Removes a disk from a VMware VM.

## SYNTAX

### RemoveByVmNameParameterSet (Default)
```
Remove-AzVMwareDisk -ResourceGroupName <String> -VMName <String>
 -Name <System.Collections.Generic.List`1[System.String]> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### RemoveByVmResourceIdParameterSet
```
Remove-AzVMwareDisk -VMResourceId <String> -Name <System.Collections.Generic.List`1[System.String]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzVMwareDisk cmdlet removes a disk from a VMware VM.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
List of names of the disks you want to remove.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: RemoveByVmNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMName
Name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: RemoveByVmNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMResourceId
Resource Id of the virtual machine.

```yaml
Type: System.String
Parameter Sets: RemoveByVmResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
