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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Management.VMwareCloudSimple;
using Microsoft.Azure.Management.VMwareCloudSimple.Models;
using System;
using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Common;

namespace Microsoft.Azure.Commands.VMwareCloudSimple.Common
{
    public abstract class VMwareCloudSimpleBaseCmdlet : AzureRMCmdlet
    {
        private VMwareCloudSimpleManagementClientWrapper _VMwareCloudSimpleManagementClientWrapper;

        private ActiveDirectoryClientWrapper _activeDirectoryClientWrapper;


        public IVMwareCloudSimpleClient VMwareCloudSimpleClient
        {
            get
            {
                if (_VMwareCloudSimpleManagementClientWrapper == null)
                {
                    _VMwareCloudSimpleManagementClientWrapper = new VMwareCloudSimpleManagementClientWrapper(DefaultProfile.DefaultContext);
                }

                _VMwareCloudSimpleManagementClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                _VMwareCloudSimpleManagementClientWrapper.ErrorLogger = WriteErrorWithTimestamp;

                return _VMwareCloudSimpleManagementClientWrapper.VMwareCloudSimpleClient;
            }

            set { _VMwareCloudSimpleManagementClientWrapper = new VMwareCloudSimpleManagementClientWrapper(value); }
        }

        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClientWrapper == null)
                {
                    _activeDirectoryClientWrapper = new ActiveDirectoryClientWrapper(DefaultProfile.DefaultContext);
                }

                return _activeDirectoryClientWrapper.ActiveDirectoryClient;
            }
        }

        public string AccessPolicyID
        {
            get
            {
                ADObjectFilterOptions _options = new ADObjectFilterOptions()
                {
                    Id = DefaultProfile.DefaultContext.Account.Id
                };
                return ActiveDirectoryClient.GetObjectId(_options).ToString();
            }
        }

        public string TenantID
        {
            get
            {
                return DefaultProfile.DefaultContext.Tenant.Id;
            }
        }

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action"></param>
        protected void RunCmdLet(Action action)
        {
            try
            {
                action();
            }
            catch (CSRPErrorException ex)
            {
                throw new PSInvalidOperationException(ex.Message, ex);
            }
        }

    }
}
