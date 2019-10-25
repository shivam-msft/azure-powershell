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

namespace Microsoft.Azure.Commands.VMwareCloudSimple
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmwareVm", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSVirtualMachine))]
    public class GetVirtualMachineCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {

            switch (ParameterSetName)
            {
                case GetByNameParameterSet:
                    {
                        var result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.Name);                        
                        WriteObject(result.ToPSVirtualMachine());
                        break;
                    }
                case GetByResourceIdParameterSet:
                    {
                        var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                        this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                        this.Name = resourceIdentifier.ResourceName;
                        var result = this.VMwareCloudSimpleClient.VirtualMachines.Get(this.ResourceGroupName, this.Name);
                        WriteObject(result.ToPSVirtualMachine());
                        break;
                    }
                case ListParameterSet:
                    {
                        var result = this.VMwareCloudSimpleClient.VirtualMachines.ListByResourceGroup(this.ResourceGroupName).Select(p => p.ToPSVirtualMachine());
                        WriteObject(result);
                        break;
                    }
            }
        }
    }
}