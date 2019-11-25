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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    /// Defines values for PSDiskIndependenceMode.
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PSDiskIndependenceMode
    {
        [EnumMember(Value = "persistent")]
        Persistent,
        [EnumMember(Value = "independent_persistent")]
        IndependentPersistent,
        [EnumMember(Value = "independent_nonpersistent")]
        IndependentNonpersistent
    }
    internal static class PSDiskIndependenceModeEnumExtension
    {
        internal static string ToSerializedValue(this PSDiskIndependenceMode? value)
        {
            return value == null ? null : ((PSDiskIndependenceMode)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this PSDiskIndependenceMode value)
        {
            switch (value)
            {
                case PSDiskIndependenceMode.Persistent:
                    return "persistent";
                case PSDiskIndependenceMode.IndependentPersistent:
                    return "independent_persistent";
                case PSDiskIndependenceMode.IndependentNonpersistent:
                    return "independent_nonpersistent";
            }
            return null;
        }

        internal static PSDiskIndependenceMode? ParsePSDiskIndependenceMode(this string value)
        {
            switch (value)
            {
                case "persistent":
                    return PSDiskIndependenceMode.Persistent;
                case "independent_persistent":
                    return PSDiskIndependenceMode.IndependentPersistent;
                case "independent_nonpersistent":
                    return PSDiskIndependenceMode.IndependentNonpersistent;
            }
            return null;
        }
    }

}
