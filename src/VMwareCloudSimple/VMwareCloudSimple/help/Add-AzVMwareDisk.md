---
external help file: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.dll-Help.xml
Module Name: Az.VMwareCloudSimple
online version:
schema: 2.0.0
---

# Add-AzVMwareDisk

## SYNOPSIS
Adds a disk to a VMware virtual machine.

## SYNTAX

### AddByVmNameAndDiskParamsParameterSet (Default)
```
Add-AzVMwareDisk -ResourceGroupName <String> -VMName <String> -Controller <String> -Mode <DiskIndependenceMode>
 -Size <Int32> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AddByVmNameAndDiskObjParameterSet
```
Add-AzVMwareDisk -ResourceGroupName <String> -VMName <String> -Disk <PSVirtualDisk>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AddByVmResourceIdandDiskParamsParameterSet
```
Add-AzVMwareDisk -VMResourceId <String> -Controller <String> -Mode <DiskIndependenceMode> -Size <Int32>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AddByVmResourceIdAndDiskObjParameterSet
```
Add-AzVMwareDisk -VMResourceId <String> -Disk <PSVirtualDisk> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### AddByVmObjectAndDiskParamsParameterSet
```
Add-AzVMwareDisk -VM <PSVirtualMachine> -Controller <String> -Mode <DiskIndependenceMode> -Size <Int32>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AddByVmObjectAndDiskObjParameterSet
```
Add-AzVMwareDisk -VM <PSVirtualMachine> -Disk <PSVirtualDisk> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Add-AzVMwareDisk cmdlet adds a disk to a VMware virtual machine. You can add a disk when you create a virtual machine, or you can add a disk to an existing virtual machine. The disk addition takes place in the local virtual machine object. To deploy it, you need to run the Create-AzVM Or Update-AzVM command.

## EXAMPLES

### Example 1
```powershell
PS C:\> $VirtualMachine = New-AzVMwareVMConfig -PrivateCloud MyPrivateCloud -Template MyVmTemplate -ResourcePool MyResourcePool -Location eastus
PS C:\> $VirtualMachine = Add-AzVMwareDisk -VM $VirtualMachine -Controller 1000 -Mode persistent -Size 16777216
PS C:\> New-AzVMwareVM -ResourceGroupName MyResourceGroup -VM $VirtualMachine -Name MyVirtualMachine
```

{{ Add example description here }}

## PARAMETERS

### -Controller
Id of the controller.
Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.

```yaml
Type: System.String
Parameter Sets: AddByVmNameAndDiskParamsParameterSet, AddByVmResourceIdandDiskParamsParameterSet, AddByVmObjectAndDiskParamsParameterSet
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
Parameter Sets: AddByVmNameAndDiskObjParameterSet, AddByVmResourceIdAndDiskObjParameterSet, AddByVmObjectAndDiskObjParameterSet
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
Parameter Sets: AddByVmNameAndDiskParamsParameterSet, AddByVmResourceIdandDiskParamsParameterSet, AddByVmObjectAndDiskParamsParameterSet
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
Parameter Sets: AddByVmNameAndDiskParamsParameterSet, AddByVmNameAndDiskObjParameterSet
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
Parameter Sets: AddByVmNameAndDiskParamsParameterSet, AddByVmResourceIdandDiskParamsParameterSet, AddByVmObjectAndDiskParamsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
Virtual machine object.

```yaml
Type: Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine
Parameter Sets: AddByVmObjectAndDiskParamsParameterSet, AddByVmObjectAndDiskObjParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VMName
Name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: AddByVmNameAndDiskParamsParameterSet, AddByVmNameAndDiskObjParameterSet
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
Parameter Sets: AddByVmResourceIdandDiskParamsParameterSet, AddByVmResourceIdAndDiskObjParameterSet
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

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualDisk

### Microsoft.Azure.Management.VMwareCloudSimple.Models.DiskIndependenceMode

## OUTPUTS

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
