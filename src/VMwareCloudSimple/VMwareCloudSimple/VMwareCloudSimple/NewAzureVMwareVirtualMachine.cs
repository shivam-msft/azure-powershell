// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Management.Automation;
using Microsoft.Azure.Commands.VMwareCloudSimple.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.VMwareCloudSimple.Common;
using Microsoft.Azure.Management.VMwareCloudSimple;
using Microsoft.Azure.Management.VMwareCloudSimple.Models;
using Microsoft.Azure.Commands.VMwareCloudSimple.Helpers;
using System.Linq;
using System;
using System.Collections.Generic;


namespace Microsoft.Azure.Commands.VMwareCloudSimple
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMwareVM", DefaultParameterSetName = SimpleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSVirtualMachine))]
    public class NewVirtualMachineCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string ObjectParameterSet = "ObjectParameterSet";
        private const string SimpleParameterSet = "SimpleParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "VMware virtual machine object which would be used to create the VM. To obtain a VMware virtual machine object, use the New-AzVmwareVMConfig cmdlet. Other cmdlets can be used to configure the virtual machine, such as Add-AzVmwareVMDisk and Add-AzVmwareVMNetworkInterface.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the virtual machine.")]
        [Parameter(Mandatory = true, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name or ID of the VMware private cloud.")]
        [ValidateNotNullOrEmpty]
        public string PrivateCloud { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "ID of the vSphere template from which this virtual machine will be created.You can also pass the basename of the ID.")]
        [ValidateNotNullOrEmpty]
        public string Template { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "ID of the VMware resource pool for this virtual machine in your VMware Private Cloud.You can also pass the basename of the ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourcePool { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The number of CPU cores required.The default is taken from the vSphere VM template specified.")]
        public int Cores { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Will expose full CPU virtualization to the guest operating system. The default is taken from the vSphere VM template specified.")]
        public SwitchParameter ExposeToGuestVM { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Region in which the private cloud is present.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The amount of memory in MB.The default is taken from the vSphere VM template specified.")]
        public int Ram { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of VMware NIC objects. By default, the NICs will be added according to the vSphere VM template. You can add more NICs, or modify NICs specified in the VM template. If a NIC name already exists in the VM template, that NIC would be modified according to the user input. If a NIC name does not exist in the VM template, a new NIC would be created and a new name will be assigned to it.")]
        public List <PSVirtualNic> NetworkInterface { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SimpleParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "List of VMware disk objects. By default, the disks will be added according to the vSphere VM template. You can add more disks, or modify disks specified in the VM template. If a disk name already exists in the VM template, that disk would be modified according to the user input. If a disk name does not exist in the VM template, a new disk would be created and a new name will be assigned to it.")]
        public List <PSVirtualDisk> Disk { get; set; }


        public override void ExecuteCmdlet()
        {
            VirtualMachine existingResource = null;
            try
            {
                existingResource = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.Name);
            }
            catch
            {
                existingResource = null;
            }

            if (existingResource != null)
            {
                throw new Exception(string.Format("A VMware virtual machine with name '{0}' in resource group '{1}' already exists. Please use Set/Update-AzVMwareVM to update an existing VMware virtual machine.", this.Name, this.ResourceGroupName));
            }

            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    {
                        existingResource = this.VM.ToVirtualMachine();
                        break;
                    }
                case SimpleParameterSet:
                    {
                        string templateName = this.Template.Split('/').Last();
                        string privateCloudName = this.PrivateCloud.Split('/').Last();

                        VirtualMachineTemplate VmTemplate = this.VMwareCloudSimpleClient.VirtualMachineTemplates.Get(this.Location, privateCloudName, templateName);

                        this.Cores = (this.MyInvocation.BoundParameters.ContainsKey("Cores")) ? this.Cores : VmTemplate.NumberOfCores ?? default(int);
                        this.Ram = (this.MyInvocation.BoundParameters.ContainsKey("Ram")) ? this.Ram : VmTemplate.AmountOfRam ?? default(int);
   
                        if (!this.MyInvocation.BoundParameters.ContainsKey("ExposeToGuestVM"))
                            this.ExposeToGuestVM = VmTemplate.ExposeToGuestVM ?? default(bool);

                        List<PSVirtualDisk> temp = VmTemplate.Disks.ToPSVirtualDisk();

                        this.Disk = CommandUtils.ModifyDisksAccordingToUserInput(VmTemplate.Disks.ToPSVirtualDisk(), this.Disk);
                        this.NetworkInterface = CommandUtils.ModifyNicsAccordingToUserInput(VmTemplate.Nics.ToPSVirtualNic(), this.NetworkInterface);

                        existingResource = new VirtualMachine()
                        {
                            Location = this.Location,
                            AmountOfRam = this.Ram,
                            Disks = this.Disk.ToVirtualDisk(),
                            ExposeToGuestVM = this.ExposeToGuestVM,
                            Nics = this.NetworkInterface.ToVirtualNic(),
                            NumberOfCores = this.Cores,
                            PrivateCloudId = this.PrivateCloud,
                            ResourcePool = new ResourcePool() { Id = this.ResourcePool },
                            TemplateId = this.Template
                        };
                        break;
                    }
            }

            if (this.ShouldProcess(this.Name, string.Format("Creating a new VMware virtual machine in resource group '{0}' with name '{1}'.", this.ResourceGroupName, this.Name)))
            {
                var result = this.VMwareCloudSimpleClient.VirtualMachines.CreateOrUpdate(ResourceGroupName, this.Name, existingResource);
                WriteObject(result.ToPSVirtualMachine());
            }

        }
    }
}