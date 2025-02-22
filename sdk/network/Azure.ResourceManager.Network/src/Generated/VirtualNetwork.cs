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
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a VirtualNetwork along with the instance operations that can be performed on it. </summary>
    public partial class VirtualNetwork : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualNetwork"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _virtualNetworkClientDiagnostics;
        private readonly VirtualNetworksRestOperations _virtualNetworkRestClient;
        private readonly VirtualNetworkData _data;

        /// <summary> Initializes a new instance of the <see cref="VirtualNetwork"/> class for mocking. </summary>
        protected VirtualNetwork()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualNetwork"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal VirtualNetwork(ArmClient armClient, VirtualNetworkData data) : this(armClient, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualNetwork"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualNetwork(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
            _virtualNetworkClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ResourceType, out string virtualNetworkApiVersion);
            _virtualNetworkRestClient = new VirtualNetworksRestOperations(_virtualNetworkClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualNetworkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual VirtualNetworkData Data
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

        /// <summary> Gets the specified virtual network by resource group. </summary>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<VirtualNetwork>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Get");
            scope.Start();
            try
            {
                var response = await _virtualNetworkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualNetworkClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetwork(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified virtual network by resource group. </summary>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<VirtualNetwork> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Get");
            scope.Start();
            try
            {
                var response = _virtualNetworkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw _virtualNetworkClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualNetwork(ArmClient, response.Value), response.GetRawResponse());
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
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.GetAvailableLocations");
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
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.GetAvailableLocations");
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

        /// <summary> Deletes the specified virtual network. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<VirtualNetworkDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Delete");
            scope.Start();
            try
            {
                var response = await _virtualNetworkRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new VirtualNetworkDeleteOperation(_virtualNetworkClientDiagnostics, Pipeline, _virtualNetworkRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes the specified virtual network. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual VirtualNetworkDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Delete");
            scope.Start();
            try
            {
                var response = _virtualNetworkRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new VirtualNetworkDeleteOperation(_virtualNetworkClientDiagnostics, Pipeline, _virtualNetworkRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a virtual network tags. </summary>
        /// <param name="parameters"> Parameters supplied to update virtual network tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<Response<VirtualNetwork>> UpdateAsync(TagsObject parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Update");
            scope.Start();
            try
            {
                var response = await _virtualNetworkRestClient.UpdateTagsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new VirtualNetwork(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates a virtual network tags. </summary>
        /// <param name="parameters"> Parameters supplied to update virtual network tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual Response<VirtualNetwork> Update(TagsObject parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.Update");
            scope.Start();
            try
            {
                var response = _virtualNetworkRestClient.UpdateTags(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                return Response.FromValue(new VirtualNetwork(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks whether a private IP address is available for use. </summary>
        /// <param name="ipAddress"> The private IP address to be verified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ipAddress"/> is null. </exception>
        public async virtual Task<Response<IPAddressAvailabilityResult>> CheckIPAddressAvailabilityAsync(string ipAddress, CancellationToken cancellationToken = default)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.CheckIPAddressAvailability");
            scope.Start();
            try
            {
                var response = await _virtualNetworkRestClient.CheckIPAddressAvailabilityAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ipAddress, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks whether a private IP address is available for use. </summary>
        /// <param name="ipAddress"> The private IP address to be verified. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ipAddress"/> is null. </exception>
        public virtual Response<IPAddressAvailabilityResult> CheckIPAddressAvailability(string ipAddress, CancellationToken cancellationToken = default)
        {
            if (ipAddress == null)
            {
                throw new ArgumentNullException(nameof(ipAddress));
            }

            using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.CheckIPAddressAvailability");
            scope.Start();
            try
            {
                var response = _virtualNetworkRestClient.CheckIPAddressAvailability(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ipAddress, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists usage stats. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualNetworkUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualNetworkUsage> GetUsageAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualNetworkUsage>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.GetUsage");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkRestClient.ListUsageAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualNetworkUsage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.GetUsage");
                scope.Start();
                try
                {
                    var response = await _virtualNetworkRestClient.ListUsageNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists usage stats. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualNetworkUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualNetworkUsage> GetUsage(CancellationToken cancellationToken = default)
        {
            Page<VirtualNetworkUsage> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.GetUsage");
                scope.Start();
                try
                {
                    var response = _virtualNetworkRestClient.ListUsage(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualNetworkUsage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualNetworkClientDiagnostics.CreateScope("VirtualNetwork.GetUsage");
                scope.Start();
                try
                {
                    var response = _virtualNetworkRestClient.ListUsageNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        #region Subnet

        /// <summary> Gets a collection of Subnets in the VirtualNetwork. </summary>
        /// <returns> An object representing collection of Subnets and their operations over a VirtualNetwork. </returns>
        public virtual SubnetCollection GetSubnets()
        {
            return new SubnetCollection(this);
        }
        #endregion

        #region VirtualNetworkPeering

        /// <summary> Gets a collection of VirtualNetworkPeerings in the VirtualNetwork. </summary>
        /// <returns> An object representing collection of VirtualNetworkPeerings and their operations over a VirtualNetwork. </returns>
        public virtual VirtualNetworkPeeringCollection GetVirtualNetworkPeerings()
        {
            return new VirtualNetworkPeeringCollection(this);
        }
        #endregion
    }
}
