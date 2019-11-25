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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMwareDisk", DefaultParameterSetName = CreateByVmNameAndDiskParamsParameterSet), OutputType(typeof(PSVirtualMachine))]
    public class NewVMwareDiskCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string CreateByVmNameAndDiskObjParameterSet = "CreateByVmNameAndDiskObjParameterSet";
        private const string CreateByVmResourceIdAndDiskObjParameterSet = "CreateByVmResourceIdAndDiskObjParameterSet";
        private const string CreateByVmNameAndDiskParamsParameterSet = "CreateByVmNameAndDiskParamsParameterSet";
        private const string CreateByVmResourceIdAndDiskParamsParameterSet = "CreateByVmResourceIdAndDiskParamsParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = CreateByVmNameAndDiskObjParameterSet, HelpMessage = "Name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByVmNameAndDiskParamsParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateByVmNameAndDiskObjParameterSet, HelpMessage = "Name of the virtual machine.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByVmNameAndDiskParamsParameterSet, HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateByVmResourceIdAndDiskObjParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the virtual machine.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByVmResourceIdAndDiskParamsParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByVmNameAndDiskObjParameterSet, HelpMessage = "Virtual disk object.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByVmResourceIdAndDiskObjParameterSet, HelpMessage = "Virtual disk object.")]
        [ValidateNotNull]
        public PSVirtualDisk Disk { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateByVmNameAndDiskParamsParameterSet, HelpMessage = "Id of the controller. Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateByVmResourceIdAndDiskParamsParameterSet, HelpMessage = "Id of the controller. Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.")]
        [ValidateNotNullOrEmpty]
        public string Controller { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateByVmNameAndDiskParamsParameterSet, HelpMessage = "The disk independence mode.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = CreateByVmResourceIdAndDiskParamsParameterSet, HelpMessage = "The disk independence mode.")]
        [ValidateNotNullOrEmpty]
        public DiskIndependenceMode Mode { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByVmNameAndDiskParamsParameterSet, HelpMessage = "The amount of disk size in KB.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = CreateByVmResourceIdAndDiskParamsParameterSet, HelpMessage = "The amount of disk size in KB.")]
        [ValidateNotNullOrEmpty]
        public int Size { get; set; }

        public override void ExecuteCmdlet()
        {

            switch (ParameterSetName)
            {
                case CreateByVmNameAndDiskParamsParameterSet:
                case CreateByVmResourceIdAndDiskParamsParameterSet:
                    {
                        var diskObject = new VirtualDisk(controllerId: Controller, independenceMode: Mode, totalSize: Size);
                        this.Disk = diskObject.ToPSVirtualDisk();
                        break;
                    }
            }

            PSVirtualMachine VM = null;

            switch (ParameterSetName)
            {
                case CreateByVmNameAndDiskObjParameterSet:
                case CreateByVmNameAndDiskParamsParameterSet:
                    {
                        var vm_result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        VM = vm_result.ToPSVirtualMachine();
                        break;
                    }
                case CreateByVmResourceIdAndDiskParamsParameterSet:
                case CreateByVmResourceIdAndDiskObjParameterSet:
                {
                        var resourceIdentifier = new ResourceIdentifier(this.VMResourceId);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.VMName = resourceIdentifier.ResourceName;
                        var vm_result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        VM  = vm_result.ToPSVirtualMachine();
                        break;
                    }
            }

            VM.Disks.Add(this.Disk);
            var result = this.VMwareCloudSimpleClient.VirtualMachines.CreateOrUpdate(this.ResourceGroupName, this.VMName, VM.ToVirtualMachine());
            WriteObject(result.ToPSVirtualMachine());

        }
    }
}