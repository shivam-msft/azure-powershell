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
using System.Linq;
using Microsoft.Azure.Management.VMwareCloudSimple.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.VMwareCloudSimple
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMwareDisk", DefaultParameterSetName = RemoveByVmNameParameterSet), OutputType(typeof(PSVirtualMachine))]
    public class RemoveVMwareDiskCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string RemoveByVmNameParameterSet = "RemoveByVmNameParameterSet";
        private const string RemoveByVmResourceIdParameterSet = "RemoveByVmResourceIdParameterSet";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByVmNameParameterSet, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByVmNameParameterSet, HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByVmResourceIdParameterSet, HelpMessage = "Resource Id of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string VMResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "List of names of the disks you want to remove.")]
        [ValidateNotNull]
        public List <String> Name { get; set; }

        public override void ExecuteCmdlet()
        {
            VirtualMachine vm_result = null;

            switch (ParameterSetName)
            {
                case RemoveByVmNameParameterSet:
                    {
                        vm_result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        break;
                    }
                case RemoveByVmResourceIdParameterSet:
                    {
                        var resourceIdentifier = new ResourceIdentifier(this.VMResourceId);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.VMName = resourceIdentifier.ResourceName;
                        vm_result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.VMName);
                        break;
                    }
            }

            //Hash table to maintain the nics not deleted
            Hashtable notDeletedDisksDict = new Hashtable();
            foreach (var diskName in this.Name)
            {
                var item = vm_result.Disks.SingleOrDefault(x => x.VirtualDiskName == diskName);
                if (item != null)
                    vm_result.Disks.Remove(item);
                else
                    notDeletedDisksDict[diskName] = true;
            }

            var result = this.VMwareCloudSimpleClient.VirtualMachines.CreateOrUpdate(this.ResourceGroupName, this.VMName, vm_result);

            string notDeletedDisks = String.Empty;

            foreach (var diskName in notDeletedDisksDict.Keys)
                    notDeletedDisks = notDeletedDisks + diskName + ", ";

            if (notDeletedDisks != String.Empty)
            {
                notDeletedDisks = notDeletedDisks.Substring(0, notDeletedDisks.Length - 2);
                throw new Exception(string.Format("'{0}' not present in the given virtual machine. Other disks (if mentioned) were deleted.", notDeletedDisks));
            }
            WriteObject(result.ToPSVirtualMachine());

        }
    }
}