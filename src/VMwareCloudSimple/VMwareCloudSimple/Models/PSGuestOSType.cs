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
    // Defines values for PSGuestOSType.
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PSGuestOSType
    {
        [EnumMember(Value = "linux")]
        Linux,
        [EnumMember(Value = "windows")]
        Windows,
        [EnumMember(Value = "other")]
        Other
    }
    internal static class PSGuestOSTypeEnumExtension
    {
        internal static string ToSerializedValue(this PSGuestOSType? value)
        {
            return value == null ? null : ((PSGuestOSType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this PSGuestOSType value)
        {
            switch (value)
            {
                case PSGuestOSType.Linux:
                    return "linux";
                case PSGuestOSType.Windows:
                    return "windows";
                case PSGuestOSType.Other:
                    return "other";
            }
            return null;
        }

        internal static PSGuestOSType? ParsePSGuestOSType(this string value)
        {
            switch (value)
            {
                case "linux":
                    return PSGuestOSType.Linux;
                case "windows":
                    return PSGuestOSType.Windows;
                case "other":
                    return PSGuestOSType.Other;
            }
            return null;
        }
    }

}
