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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;


namespace Microsoft.Azure.Commands.VMwareCloudSimple.Models
{
    // Defines values for PSVirtualMachineStatus.
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PSVirtualMachineStatus
    {
        [EnumMember(Value = "running")]
        Running,
        [EnumMember(Value = "suspended")]
        Suspended,
        [EnumMember(Value = "poweredoff")]
        Poweredoff,
        [EnumMember(Value = "updating")]
        Updating,
        [EnumMember(Value = "deallocating")]
        Deallocating,
        [EnumMember(Value = "deleting")]
        Deleting
    }
    internal static class PSVirtualMachineStatusEnumExtension
    {
        internal static string ToSerializedValue(this PSVirtualMachineStatus? value)
        {
            return value == null ? null : ((PSVirtualMachineStatus)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this PSVirtualMachineStatus value)
        {
            switch (value)
            {
                case PSVirtualMachineStatus.Running:
                    return "running";
                case PSVirtualMachineStatus.Suspended:
                    return "suspended";
                case PSVirtualMachineStatus.Poweredoff:
                    return "poweredoff";
                case PSVirtualMachineStatus.Updating:
                    return "updating";
                case PSVirtualMachineStatus.Deallocating:
                    return "deallocating";
                case PSVirtualMachineStatus.Deleting:
                    return "deleting";
            }
            return null;
        }

        internal static PSVirtualMachineStatus? ParsePSVirtualMachineStatus(this string value)
        {
            switch (value)
            {
                case "running":
                    return PSVirtualMachineStatus.Running;
                case "suspended":
                    return PSVirtualMachineStatus.Suspended;
                case "poweredoff":
                    return PSVirtualMachineStatus.Poweredoff;
                case "updating":
                    return PSVirtualMachineStatus.Updating;
                case "deallocating":
                    return PSVirtualMachineStatus.Deallocating;
                case "deleting":
                    return PSVirtualMachineStatus.Deleting;
            }
            return null;
        }
    }
}
