---
external help file: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.dll-Help.xml
Module Name: Az.VMwareCloudSimple
online version:
schema: 2.0.0
---

# New-AzVMwareVM

## SYNOPSIS
Creates a VMware virtual machine.

## SYNTAX

### SimpleParameterSet (Default)
```
New-AzVMwareVM -ResourceGroupName <String> -Name <String> -PrivateCloud <String> -Template <String>
 -ResourcePool <String> [-Cores <Int32>] [-ExposeToGuestVM] -Location <String> [-Ram <Int32>]
 [-NetworkInterface <System.Collections.Generic.List`1[Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualNic]>]
 [-Disk <System.Collections.Generic.List`1[Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualDisk]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ObjectParameterSet
```
New-AzVMwareVM -ResourceGroupName <String> -VM <PSVirtualMachine> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVMwareVM cmdlet creates a VMware virtual machine.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Cores
The number of CPU cores required.The default is taken from the vSphere VM template specified.

```yaml
Type: System.Int32
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
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
List of VMware disk objects.
By default, the disks will be added according to the vSphere VM template.
You can add more disks, or modify disks specified in the VM template.
If a disk name already exists in the VM template, that disk would be modified according to the user input.
If a disk name does not exist in the VM template, a new disk would be created and a new name will be assigned to it.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualDisk]
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExposeToGuestVM
Will expose full CPU virtualization to the guest operating system.
The default is taken from the vSphere VM template specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Region in which the private cloud is present.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkInterface
List of VMware NIC objects.
By default, the NICs will be added according to the vSphere VM template.
You can add more NICs, or modify NICs specified in the VM template.
If a NIC name already exists in the VM template, that NIC would be modified according to the user input.
If a NIC name does not exist in the VM template, a new NIC would be created and a new name will be assigned to it.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualNic]
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateCloud
Name or ID of the VMware private cloud.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Ram
The amount of memory in MB.The default is taken from the vSphere VM template specified.

```yaml
Type: System.Int32
Parameter Sets: SimpleParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourcePool
ID of the VMware resource pool for this virtual machine in your VMware Private Cloud.You can also pass the basename of the ID.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Template
ID of the vSphere template from which this virtual machine will be created.You can also pass the basename of the ID.

```yaml
Type: System.String
Parameter Sets: SimpleParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VM
VMware virtual machine object which would be used to create the VM.
To obtain a VMware virtual machine object, use the New-AzVmwareVMConfig cmdlet.
Other cmdlets can be used to configure the virtual machine, such as Add-AzVmwareVMDisk and Add-AzVmwareVMNetworkInterface.

```yaml
Type: Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine
Parameter Sets: ObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine

### System.Int32

### System.Management.Automation.SwitchParameter

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualNic, Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualDisk, Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### Microsoft.Azure.Commands.VMwareCloudSimple.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
