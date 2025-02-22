// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A Class representing a SiteSlotPrivateAccess along with the instance operations that can be performed on it. </summary>
    public partial class SiteSlotPrivateAccess : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SiteSlotPrivateAccess"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _siteSlotPrivateAccessWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotPrivateAccessWebAppsRestClient;
        private readonly PrivateAccessData _data;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotPrivateAccess"/> class for mocking. </summary>
        protected SiteSlotPrivateAccess()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SiteSlotPrivateAccess"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SiteSlotPrivateAccess(ArmClient armClient, PrivateAccessData data) : this(armClient, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotPrivateAccess"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SiteSlotPrivateAccess(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
            _siteSlotPrivateAccessWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ResourceType, out string siteSlotPrivateAccessWebAppsApiVersion);
            _siteSlotPrivateAccessWebAppsRestClient = new WebAppsRestOperations(_siteSlotPrivateAccessWebAppsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, siteSlotPrivateAccessWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Web/sites/slots/privateAccess";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PrivateAccessData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// OperationId: WebApps_GetPrivateAccessSlot
        /// <summary> Description for Gets data around private site access enablement and authorized Virtual Networks that can access the site. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<SiteSlotPrivateAccess>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateScope("SiteSlotPrivateAccess.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotPrivateAccessWebAppsRestClient.GetPrivateAccessSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SiteSlotPrivateAccess(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// OperationId: WebApps_GetPrivateAccessSlot
        /// <summary> Description for Gets data around private site access enablement and authorized Virtual Networks that can access the site. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SiteSlotPrivateAccess> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateScope("SiteSlotPrivateAccess.Get");
            scope.Start();
            try
            {
                var response = _siteSlotPrivateAccessWebAppsRestClient.GetPrivateAccessSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotPrivateAccess(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public async virtual Task<IEnumerable<AzureLocation>> GetAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateScope("SiteSlotPrivateAccess.GetAvailableLocations");
            scope.Start();
            try
            {
                return await ListAvailableLocationsAsync(ResourceType, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of locations that may take multiple service requests to iterate over. </returns>
        public virtual IEnumerable<AzureLocation> GetAvailableLocations(CancellationToken cancellationToken = default)
        {
            using var scope = _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateScope("SiteSlotPrivateAccess.GetAvailableLocations");
            scope.Start();
            try
            {
                return ListAvailableLocations(ResourceType, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// OperationId: WebApps_PutPrivateAccessVnetSlot
        /// <summary> Description for Sets data around private site access enablement and authorized Virtual Networks that can access the site. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="access"> The information for the private access. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="access"/> is null. </exception>
        public async virtual Task<SiteSlotPrivateAccessCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, PrivateAccessData access, CancellationToken cancellationToken = default)
        {
            if (access == null)
            {
                throw new ArgumentNullException(nameof(access));
            }

            using var scope = _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateScope("SiteSlotPrivateAccess.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteSlotPrivateAccessWebAppsRestClient.PutPrivateAccessVnetSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, access, cancellationToken).ConfigureAwait(false);
                var operation = new SiteSlotPrivateAccessCreateOrUpdateOperation(ArmClient, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/privateAccess/virtualNetworks
        /// OperationId: WebApps_PutPrivateAccessVnetSlot
        /// <summary> Description for Sets data around private site access enablement and authorized Virtual Networks that can access the site. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="access"> The information for the private access. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="access"/> is null. </exception>
        public virtual SiteSlotPrivateAccessCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, PrivateAccessData access, CancellationToken cancellationToken = default)
        {
            if (access == null)
            {
                throw new ArgumentNullException(nameof(access));
            }

            using var scope = _siteSlotPrivateAccessWebAppsClientDiagnostics.CreateScope("SiteSlotPrivateAccess.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteSlotPrivateAccessWebAppsRestClient.PutPrivateAccessVnetSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, access, cancellationToken);
                var operation = new SiteSlotPrivateAccessCreateOrUpdateOperation(ArmClient, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
