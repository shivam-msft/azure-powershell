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
using Microsoft.Rest;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    public class PSVirtualDiskController
    {

        // Gets controller's id
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        // Gets the display name of Controller
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        // Gets dik controller subtype (VMWARE_PARAVIRTUAL, BUS_PARALLEL,
        // LSI_PARALLEL, LSI_SAS)
        [JsonProperty(PropertyName = "subType")]
        public string SubType { get; private set; }

        // Gets disk controller type (SCSI)
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

    }
}
