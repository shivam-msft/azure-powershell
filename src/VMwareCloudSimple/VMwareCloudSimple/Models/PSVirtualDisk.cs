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
    public class PSVirtualDisk
    {

        // Gets or sets disk's Controller id
        [JsonProperty(PropertyName = "controllerId")]
        public string ControllerId { get; set; }

        // Gets or sets disk's independence mode type. Possible values
        // include: 'persistent', 'independent_persistent',
        // 'independent_nonpersistent'
        [JsonProperty(PropertyName = "independenceMode")]
        public PSDiskIndependenceMode IndependenceMode { get; set; }


        // Gets or sets disk's total size
        [JsonProperty(PropertyName = "totalSize")]
        public int TotalSize { get; set; }

        // Gets or sets disk's id
        [JsonProperty(PropertyName = "virtualDiskId")]
        public string VirtualDiskId { get; set; }

        // Gets disk's display name
        [JsonProperty(PropertyName = "virtualDiskName")]
        public string VirtualDiskName { get; private set; }

        // Validate the object.
        // <exception cref="ValidationException">
        // Thrown if validation fails
        // </exception>
        public virtual void Validate()
        {
            if (ControllerId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ControllerId");
            }
        }

    }
}
