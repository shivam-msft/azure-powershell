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

using Microsoft.Rest;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    public class PSResourcePool
    {

        /// Gets or sets resource pool id (privateCloudId:vsphereId)
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// Gets azure region
        [JsonProperty(PropertyName = "location")]
        public string Location { get; private set; }

        /// Gets {PSResourcePoolName}
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// Gets the Private Cloud Id
        [JsonProperty(PropertyName = "privateCloudId")]
        public string PrivateCloudId { get; private set; }

        /// Gets hierarchical resource pool name
        [JsonProperty(PropertyName = "properties.fullName")]
        public string FullName { get; private set; }

        /// Gets {resourceProviderNamespace}/{resourceType}
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }


        /// Validate the object.
        /// Thrown if validation fails
        public virtual void Validate()
        {
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
        }

    }
}
