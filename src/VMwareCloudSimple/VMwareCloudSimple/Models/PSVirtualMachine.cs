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

using Microsoft.Azure.Management.VMwareCloudSimple.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    public class PSVirtualMachine
    {

        // Gets or sets the property of 'Id'
        public string Id { get; set; }

        // Gets or sets the property of 'Location'
        public string Location { get; set; }

        // Gets or sets the property of 'Name'
        public string Name { get; set; }

        // Gets or sets the property of 'AmountofRam'
        public int AmountOfRam { get; set; }

        // Gets or sets the property of 'Controllers'
        public IList<VirtualDiskController> Controllers { get; private set; }

        // Gets or sets the property of 'Disks'
        public IList<VirtualDisk> Disks { get; set; }

        // Gets or sets the property of 'Dnsname'
        public string Dnsname { get; private set; }

        // Gets or sets the property of 'ExposeToGuestVM'
        public bool? ExposeToGuestVM { get; set; }

        // Gets or sets the property of 'Folder'
        public string Folder { get; private set; }

        // Gets or sets the property of 'GuestOS'
        public string GuestOS { get; private set; }

        // Gets or sets the property of 'GuestOSType'
        public GuestOSType GuestOSType { get; private set; }

        // Gets or sets the property of 'Nics'
        public IList<VirtualNic> Nics { get; set; }

        // Gets or sets the property of 'NumberOfCores'
        public int NumberOfCores { get; set; }

        // Gets or sets the property of 'Password'
        public string Password { get; set; }

        // Gets or sets the property of 'PrivateCloudId'
        public string PrivateCloudId { get; set; }

        // Gets or sets the property of 'ProvisioningState'
        public string ProvisioningState { get; private set; }


        // Gets or sets the property of 'PublicIP'
        public string PublicIP { get; private set; }

        // Gets or sets the property of 'ResourcePool'
        public ResourcePool ResourcePool { get; set; }

        // Gets or sets the property of 'Status'
        public VirtualMachineStatus? Status { get; private set; }

        // Gets or sets the property of 'TemplateId'
        public string TemplateId { get; set; }

        // Gets or sets the property of 'Username'
        public string Username { get; set; }

        // Gets or sets the property of 'VSphereNetworks'
        public IList<string> VSphereNetworks { get; set; }

        // Gets or sets the property of 'VmId'
        public string VmId { get; private set; }

        // Gets or sets the property of 'Vmwaretools'
        public string Vmwaretools { get; private set; }

        // Gets or sets the property of 'Tags'
        public IDictionary<string, string> Tags { get; set; }

        // Gets or sets the property of 'Type'
        public string Type { get; private set; }

    }
}
