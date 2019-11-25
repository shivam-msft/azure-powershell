---
external help file: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.dll-Help.xml
Module Name: Az.VMwareCloudSimple
online version:
schema: 2.0.0
---

# New-AzVMwareDisk

## SYNOPSIS
Creates a disk in a VMware virtual machine.

## SYNTAX

### CreateByVmNameAndDiskParamsParameterSet (Default)
```
New-AzVMwareDisk -ResourceGroupName <String> -VMName <String> -Controller <String> -Mode <DiskIndependenceMode>
 -Size <Int32> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CreateByVmNameAndDiskObjParameterSet
```
New-AzVMwareDisk -ResourceGroupName <String> -VMName <String> -Disk <PSVirtualDisk>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CreateByVmResourceIdAndDiskObjParameterSet
```
New-AzVMwareDisk -VMResourceId <String> -Disk <PSVirtualDisk> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### CreateByVmResourceIdAndDiskParamsParameterSet
```
New-AzVMwareDisk -VMResourceId <String> -Controller <String> -Mode <DiskIndependenceMode> -Size <Int32>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVMwareDisk cmdlet creates a disk in a existing VMware virtual machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Controller
Id of the controller.
Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.

```yaml
Type: System.String
Parameter Sets: CreateByVmNameAndDiskParamsParameterSet, CreateByVmResourceIdAndDiskParamsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -Disk
Virtual disk object.

```yaml
Type: Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualDisk
Parameter Sets: CreateByVmNameAndDiskObjParameterSet, CreateByVmResourceIdAndDiskObjParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Mode
The disk independence mode.

```yaml
Type: Microsoft.Azure.Management.VMwareCloudSimple.Models.DiskIndependenceMode
Parameter Sets: CreateByVmNameAndDiskParamsParameterSet, CreateByVmResourceIdAndDiskParamsParameterSet
Aliases:
Accepted values: Persistent, IndependentPersistent, IndependentNonpersistent

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: CreateByVmNameAndDiskParamsParameterSet, CreateByVmNameAndDiskObjParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Size
The amount of disk size in KB.

```yaml
Type: System.Int32
Parameter Sets: CreateByVmNameAndDiskParamsParameterSet, CreateByVmResourceIdAndDiskParamsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMName
Name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: CreateByVmNameAndDiskParamsParameterSet, CreateByVmNameAndDiskObjParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMResourceId
Resource Id of the virtual machine.

```yaml
Type: System.String
Parameter Sets: CreateByVmResourceIdAndDiskObjParameterSet, CreateByVmResourceIdAndDiskParamsParameterSet
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

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualDisk

### Microsoft.Azure.Management.VMwareCloudSimple.Models.DiskIndependenceMode

## OUTPUTS

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
