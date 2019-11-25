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
using Microsoft.Rest;
using Newtonsoft.Json;


namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    public class PSVirtualNic
    {

        // Gets or sets guest OS customization for nic
        [JsonProperty(PropertyName = "customization")]
        public PSGuestOSNICCustomization Customization { get; set; }

        // Gets or sets NIC ip address
        [JsonProperty(PropertyName = "ipAddresses")]
        public IList<string> IpAddresses { get; set; }

        // Gets or sets NIC MAC address
        [JsonProperty(PropertyName = "macAddress")]
        public string MacAddress { get; set; }

        // Gets or sets virtual Network
        [JsonProperty(PropertyName = "network")]
        public PSVirtualNetwork Network { get; set; }

        // Gets or sets NIC type. Possible values include: 'E1000', 'E1000E',
        // 'PCNET32', 'VMXNET', 'VMXNET2', 'VMXNET3'
        [JsonProperty(PropertyName = "nicType")]
        public PSNICType NicType { get; set; }

        // Gets or sets is NIC powered on/off on boot
        [JsonProperty(PropertyName = "powerOnBoot")]
        public bool? PowerOnBoot { get; set; }

        // Gets or sets NIC id
        [JsonProperty(PropertyName = "virtualNicId")]
        public string VirtualNicId { get; set; }

        // Gets NIC name
        [JsonProperty(PropertyName = "virtualNicName")]
        public string VirtualNicName { get; private set; }

        // Validate the object.
        public virtual void Validate()
        {
            if (Network == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Network");
            }
            if (Network != null)
            {
                Network.Validate();
            }
        }
    }
}
