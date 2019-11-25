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
using Microsoft.Azure.Commands.VMwareCloudSimple.Common;
using Microsoft.Azure.Commands.VMwareCloudSimple.Helpers;
using Microsoft.Azure.Management.VMwareCloudSimple.Models;

namespace Microsoft.Azure.Commands.VMwareCloudSimple
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMwareDiskConfig", DefaultParameterSetName = CreateParameterSet), OutputType(typeof(PSVirtualDisk))]
    public class NewVMwareDiskConfigCommand : VMwareCloudSimpleBaseCmdlet
    {
        private const string CreateParameterSet = "CreateParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = CreateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Id of the controller. Input 1000 for SCSI controller 0, and 15000 for SATA controller 0.")]
        [ValidateNotNullOrEmpty]
        public string Controller { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The disk independence mode.")]
        [ValidateNotNullOrEmpty]
        public DiskIndependenceMode Mode { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateParameterSet, ValueFromPipelineByPropertyName = false, HelpMessage = "The amount of disk size in KB.")]
        [ValidateNotNullOrEmpty]
        public int Size { get; set; }

        public override void ExecuteCmdlet()
        {
            var diskObject = new VirtualDisk(controllerId: Controller, independenceMode: Mode, totalSize: Size);
            WriteObject(diskObject.ToPSVirtualDisk());
        }
    }
}