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
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PSNICType
    {
        [EnumMember(Value = "E1000")]
        E1000,
        [EnumMember(Value = "E1000E")]
        E1000E,
        [EnumMember(Value = "PCNET32")]
        PCNET32,
        [EnumMember(Value = "VMXNET")]
        VMXNET,
        [EnumMember(Value = "VMXNET2")]
        VMXNET2,
        [EnumMember(Value = "VMXNET3")]
        VMXNET3
    }

    internal static class PSNICTypeEnumExtension
    {
        internal static string ToSerializedValue(this PSNICType? value)
        {
            return value == null ? null : ((PSNICType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this PSNICType value)
        {
            switch (value)
            {
                case PSNICType.E1000:
                    return "E1000";
                case PSNICType.E1000E:
                    return "E1000E";
                case PSNICType.PCNET32:
                    return "PCNET32";
                case PSNICType.VMXNET:
                    return "VMXNET";
                case PSNICType.VMXNET2:
                    return "VMXNET2";
                case PSNICType.VMXNET3:
                    return "VMXNET3";
            }
            return null;
        }

        internal static PSNICType? ParseNICType(this string value)
        {
            switch (value)
            {
                case "E1000":
                    return PSNICType.E1000;
                case "E1000E":
                    return PSNICType.E1000E;
                case "PCNET32":
                    return PSNICType.PCNET32;
                case "VMXNET":
                    return PSNICType.VMXNET;
                case "VMXNET2":
                    return PSNICType.VMXNET2;
                case "VMXNET3":
                    return PSNICType.VMXNET3;
            }
            return null;
        }
    }

}
