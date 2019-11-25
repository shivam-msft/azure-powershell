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
using System;

namespace Microsoft.Azure.Commands.VMwareCloudSimple
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMwareDisk", DefaultParameterSetName = GetByVmNameParameterSet), OutputType(typeof(PSVirtualMachine))]
    public class GetVMwareDiskCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string GetByVmNameParameterSet = "GetByVmNameParameterSet";
        private const string GetByVmResourceIdParameterSet = "GetByVmResourceIdParameterSet";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByVmNameParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByVmNameParameterSet, HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByVmResourceIdParameterSet, HelpMessage = "Resource Id of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the disk.")]
        [ValidateNotNull]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            VirtualMachine vm_result = null;

            switch (ParameterSetName)
            {
                case GetByVmNameParameterSet:
                    {
                        vm_result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        break;
                    }
                case GetByVmResourceIdParameterSet:
                    {
                        var resourceIdentifier = new ResourceIdentifier(this.VMResourceId);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.VMName = resourceIdentifier.ResourceName;
                        vm_result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        break;
                    }
            }

            bool foundDisk = false;
            foreach (var disk in vm_result.Disks)
            {
                if (disk.VirtualDiskName == Name)
                {
                    WriteObject(disk.ToPSVirtualDisk());
                    foundDisk = true;
                }
            }
            if (!foundDisk)
                throw new Exception(string.Format("'{0}' not present in the given virtual machine.", Name));
        }
    }
}