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
using Newtonsoft.Json;
using System.Collections;
using System.Linq;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    public class PSGuestOSNICCustomization
    {

        // Gets or sets IP address allocation method. Possible values include:
        // 'static', 'dynamic'
        [JsonProperty(PropertyName = "allocation")]
        public string Allocation { get; set; }

        // Gets or sets list of dns servers to use
        [JsonProperty(PropertyName = "dnsServers")]
        public IList<string> DnsServers { get; set; }

        // Gets or sets gateway addresses assigned to nic
        [JsonProperty(PropertyName = "gateway")]
        public IList<string> Gateway { get; set; }

        // Gets or sets static ip address for nic
        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        // Gets or sets network mask for nic
        [JsonProperty(PropertyName = "mask")]
        public string Mask { get; set; }

        // Gets or sets primary WINS server for Windows
        [JsonProperty(PropertyName = "primaryWinsServer")]
        public string PrimaryWinsServer { get; set; }

        // Gets or sets secondary WINS server for Windows
        [JsonProperty(PropertyName = "secondaryWinsServer")]
        public string SecondaryWinsServer { get; set; }

    }
}
