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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.VMwareCloudSimple;
using Microsoft.Azure.Commands.VMwareCloudSimple.Helpers;
using Microsoft.Azure.Management.VMwareCloudSimple.Models;

namespace Microsoft.Azure.Commands.VMwareCloudSimple
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMwareDisk", DefaultParameterSetName = AddByVmNameAndDiskParamsParameterSet), OutputType(typeof(PSVirtualMachine))]
    public class AddVMwareDiskCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string AddByVmNameAndDiskParamsParameterSet = "AddByVmNameAndDiskParamsParameterSet";
        private const string AddByVmObjectAndDiskParamsParameterSet = "AddByVmObjectAndDiskParamsParameterSet";
        private const string AddByVmResourceIdandDiskParamsParameterSet = "AddByVmResourceIdandDiskParamsParameterSet";
        private const string AddByVmNameAndDiskObjParameterSet = "AddByVmNameAndDiskObjParameterSet";
        private const string AddByVmObjectAndDiskObjParameterSet = "AddByVmObjectAndDiskObjParameterSet";
        private const string AddByVmResourceIdAndDiskObjParameterSet = "AddByVmResourceIdAndDiskObjParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = AddByVmNameAndDiskParamsParameterSet, HelpMessage = "Name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = AddByVmNameAndDiskObjParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddByVmNameAndDiskParamsParameterSet, HelpMessage = "Name of the virtual machine.")]
        [Parameter(Mandatory = true, ParameterSetName = AddByVmNameAndDiskObjParameterSet, HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddByVmResourceIdandDiskParamsParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the virtual machine.")]
        [Parameter(Mandatory = true, ParameterSetName = AddByVmResourceIdAndDiskObjParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddByVmObjectAndDiskParamsParameterSet, HelpMessage = "Virtual machine object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddByVmObjectAndDiskObjParameterSet, HelpMessage = "Virtual machine object.")]
        [ValidateNotNull]
        public PSVirtualMachine VM { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddByVmNameAndDiskObjParameterSet, HelpMessage = "Virtual disk object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddByVmObjectAndDiskObjParameterSet, HelpMessage = "Virtual disk object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AddByVmResourceIdAndDiskObjParameterSet, HelpMessage = "Virtual disk object.")]
        [ValidateNotNull]
        public PSVirtualDisk Disk { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddByVmNameAndDiskParamsParameterSet, HelpMessage = "Id of the controller. Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddByVmObjectAndDiskParamsParameterSet, HelpMessage = "Id of the controller. Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddByVmResourceIdandDiskParamsParameterSet, HelpMessage = "Id of the controller. Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.")]
        [ValidateNotNullOrEmpty]
        public string Controller { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddByVmNameAndDiskParamsParameterSet, HelpMessage = "The disk independence mode.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddByVmObjectAndDiskParamsParameterSet, HelpMessage = "The disk independence mode.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AddByVmResourceIdandDiskParamsParameterSet, HelpMessage = "The disk independence mode.")]
        [ValidateNotNullOrEmpty]
        public DiskIndependenceMode Mode { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AddByVmNameAndDiskParamsParameterSet, HelpMessage = "The amount of disk size in KB.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AddByVmObjectAndDiskParamsParameterSet, HelpMessage = "The amount of disk size in KB.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AddByVmResourceIdandDiskParamsParameterSet, HelpMessage = "The amount of disk size in KB.")]
        [ValidateNotNullOrEmpty]
        public int Size { get; set; }

        public override void ExecuteCmdlet()
        {

            switch (ParameterSetName)
            {
                case AddByVmNameAndDiskParamsParameterSet: case AddByVmObjectAndDiskParamsParameterSet: case AddByVmResourceIdandDiskParamsParameterSet:
                    {
                        var diskObject = new VirtualDisk(controllerId: Controller, independenceMode: Mode, totalSize: Size);
                        this.Disk = diskObject.ToPSVirtualDisk();
                        break;
                    }
            }

            switch (ParameterSetName)
            {
                case AddByVmNameAndDiskParamsParameterSet:
                case AddByVmNameAndDiskObjParameterSet:
                {
                        var result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        this.VM = result.ToPSVirtualMachine();
                        break;
                    }
                case AddByVmResourceIdandDiskParamsParameterSet:
                case AddByVmResourceIdAndDiskObjParameterSet:
                {
                        var resourceIdentifier = new ResourceIdentifier(this.VMResourceId);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.VMName = resourceIdentifier.ResourceName;
                        var result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        this.VM = result.ToPSVirtualMachine();
                        break;
                    }
            }
            this.VM.Disks.Add(this.Disk);
            WriteObject(this.VM);

        }
    }
}