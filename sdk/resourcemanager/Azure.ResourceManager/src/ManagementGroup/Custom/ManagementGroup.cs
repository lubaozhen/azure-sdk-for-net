// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management.Models;

[assembly:CodeGenSuppressType("SearchOptions")]
[assembly:CodeGenSuppressType("EntityViewOptions")]
[assembly:CodeGenSuppressType("TenantExtensions")] // Moved code to Custom/Tenant
[assembly:CodeGenSuppressType("AzureAsyncOperationResults")]
[assembly:CodeGenSuppressType("ErrorResponse")]
[assembly:CodeGenSuppressType("ErrorDetails")] // No target and additionalInfo properties, therefore it's not replaced by common type
[assembly:CodeGenSuppressType("ManagementGroupUpdateOperation")]
namespace Azure.ResourceManager.Management
{
    /// <summary> A Class representing a ManagementGroup along with the instance operations that can be performed on it. </summary>
    [CodeGenSuppress("CheckNameAvailabilityAsync", typeof(CheckNameAvailabilityOptions), typeof(CancellationToken))]
    [CodeGenSuppress("CheckNameAvailability", typeof(CheckNameAvailabilityOptions), typeof(CancellationToken))]
    public partial class ManagementGroup : ArmResource
    {
    }
}
