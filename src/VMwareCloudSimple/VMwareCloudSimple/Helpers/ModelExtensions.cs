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
// ----------------------------------------------------------------------------------

using AutoMapper;
using Microsoft.Azure.Commands.VMwareCloudSimple.Models;
using Microsoft.Azure.Management.VMwareCloudSimple.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Helpers
{
    public static class ModelExtensions
    {
        public static PSVirtualMachine ToPSVirtualMachine(this VirtualMachine vm)
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<VirtualMachine, PSVirtualMachine>();
                    cfg.CreateMap<VirtualDiskController, PSVirtualDiskController>();
                    cfg.CreateMap<VirtualDisk, PSVirtualDisk>();
                    cfg.CreateMap<DiskIndependenceMode, PSDiskIndependenceMode>();
                    cfg.CreateMap<GuestOSType, PSGuestOSType>();
                    cfg.CreateMap<VirtualNic, PSVirtualNic>();
                    cfg.CreateMap<GuestOSNICCustomization, PSGuestOSNICCustomization>();
                    cfg.CreateMap<VirtualNetwork, PSVirtualNetwork>();
                    cfg.CreateMap<NICType, PSNICType>();
                    cfg.CreateMap<ResourcePool, PSResourcePool>();
                    cfg.CreateMap<VirtualMachineStatus, PSVirtualMachineStatus>();
                }
            );
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<VirtualMachine, PSVirtualMachine>(vm);
        }

        public static VirtualMachine ToVirtualMachine(this PSVirtualMachine vm)
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<PSVirtualMachine, VirtualMachine>();
                    cfg.CreateMap<PSVirtualDiskController, VirtualDiskController>();
                    cfg.CreateMap<PSVirtualDisk, VirtualDisk>();
                    cfg.CreateMap<PSDiskIndependenceMode, DiskIndependenceMode>();
                    cfg.CreateMap<PSGuestOSType, GuestOSType>();
                    cfg.CreateMap<PSVirtualNic, VirtualNic>();
                    cfg.CreateMap<PSGuestOSNICCustomization, GuestOSNICCustomization>();
                    cfg.CreateMap<PSVirtualNetwork, VirtualNetwork>();
                    cfg.CreateMap<PSNICType, NICType>();
                    cfg.CreateMap<PSResourcePool, ResourcePool>();
                    cfg.CreateMap<PSVirtualMachineStatus, VirtualMachineStatus>();
                }
            );
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<PSVirtualMachine, VirtualMachine>(vm);
        }

        public static PSVirtualDisk ToPSVirtualDisk(this VirtualDisk disk)
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<VirtualDisk, PSVirtualDisk>();
                    cfg.CreateMap<DiskIndependenceMode, PSDiskIndependenceMode>();
                }
            );
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<VirtualDisk, PSVirtualDisk>(disk);
        }

        public static VirtualDisk ToVirtualDisk(this PSVirtualDisk disk)
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<PSVirtualDisk, VirtualDisk>();
                    cfg.CreateMap<PSDiskIndependenceMode, DiskIndependenceMode>();
                }
            );
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<PSVirtualDisk, VirtualDisk>(disk);
        }

        public static List<PSVirtualDisk> ToPSVirtualDisk(this IList<VirtualDisk> disks)
        {
            List<PSVirtualDisk> convertedDisks = new List<PSVirtualDisk>();
            foreach (var disk in disks)
                convertedDisks.Add(disk.ToPSVirtualDisk());
            return convertedDisks;
        }

        public static List<VirtualDisk> ToVirtualDisk(this IList<PSVirtualDisk> disks)
        {
            List<VirtualDisk> convertedDisks = new List<VirtualDisk>();
            foreach (var disk in disks)
                convertedDisks.Add(disk.ToVirtualDisk());
            return convertedDisks;
        }

        public static PSVirtualNic ToPSVirtualNic(this VirtualNic nic)
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<VirtualNic, PSVirtualNic>();
                    cfg.CreateMap<GuestOSNICCustomization, PSGuestOSNICCustomization>();
                    cfg.CreateMap<VirtualNetwork, PSVirtualNetwork>();
                    cfg.CreateMap<NICType, PSNICType>();
                }
            );
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<VirtualNic, PSVirtualNic>(nic);
        }

        public static VirtualNic ToVirtualNic(this PSVirtualNic nic)
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<PSVirtualNic, VirtualNic>();
                    cfg.CreateMap<PSGuestOSNICCustomization, GuestOSNICCustomization>();
                    cfg.CreateMap<PSVirtualNetwork, VirtualNetwork>();
                    cfg.CreateMap<PSNICType, NICType>();
                }
            );
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<PSVirtualNic, VirtualNic>(nic);
        }

        public static List <PSVirtualNic> ToPSVirtualNic(this IList <VirtualNic> nics)
        {
            List<PSVirtualNic> convertedNics = new List<PSVirtualNic>();
            foreach (var nic in nics)
                convertedNics.Add(nic.ToPSVirtualNic());
            return convertedNics;
        }

        public static List <VirtualNic> ToVirtualNic(this IList <PSVirtualNic> nics)
        {
            List<VirtualNic> convertedNics = new List<VirtualNic>();
            foreach (var nic in nics)
                convertedNics.Add(nic.ToVirtualNic());
            return convertedNics;
        }




    }

    public static class CommandUtils
    {
        public static List <PSVirtualNic> ModifyNicsAccordingToUserInput(IList <PSVirtualNic> templateNics, IList <PSVirtualNic> inputNics)
        {
            //Populating the nic names of vm-template in a dictionary,
            //and mapping them to their index in templateNics list
            Hashtable vmTemplateNicNames = new Hashtable();
            var templateNicsList = new List<PSVirtualNic>(templateNics);

            for (int i = 0; i < templateNicsList.Count; i++)
            {
                vmTemplateNicNames.Add(templateNicsList[i].VirtualNicName, i);
            }

            if (inputNics == null)
                return templateNicsList;

            //If nic name entered by the user exist in vm-template,
            //then override the nic in vm-template.
            //Else create a new nic.
            foreach (PSVirtualNic nic in inputNics)
            {
                if (nic.VirtualNicName == null || (!vmTemplateNicNames.ContainsKey(nic.VirtualNicName)) )
                {
                    templateNicsList.Add(nic);
                }
                else
                {
                    int index = (int)vmTemplateNicNames[nic.VirtualNicName];
                    templateNicsList[index] = nic;
                }
            }

            return templateNicsList;
        }

        public static List <PSVirtualDisk> ModifyDisksAccordingToUserInput(IList <PSVirtualDisk> templateDisks, IList <PSVirtualDisk> inputDisks)
        {
            //Populating the disk names of vm-template in a dictionary,
            //and mapping them to their index in templateDisks list
            Hashtable vmTemplateDiskNames = new Hashtable();
            var templateDisksList = new List<PSVirtualDisk>(templateDisks);

            for (int i = 0; i < templateDisksList.Count; i++)
            {
                vmTemplateDiskNames.Add(templateDisksList[i].VirtualDiskName, i);
            }

            if (inputDisks == null)
                return templateDisksList;

            //If disk name entered by the user exist in vm-template,
            //then override the disk in vm-template.
            //Else create a new disk.
            foreach (PSVirtualDisk disk in inputDisks)
            {
                if (disk.VirtualDiskName == null || (!vmTemplateDiskNames.ContainsKey(disk.VirtualDiskName)))
                {
                    templateDisksList.Add(disk);
                }
                else
                {
                    int index = (int)vmTemplateDiskNames[disk.VirtualDiskName];
                    templateDisksList[index] = disk;
                }
            }
            return templateDisksList;
        }


        //public static T DeepCopy<T>(T obj)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(stream, obj);
        //        stream.Position = 0;

        //        return (T)formatter.Deserialize(stream);
        //    }
        //}
        public static T DeepCopy<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }
}
