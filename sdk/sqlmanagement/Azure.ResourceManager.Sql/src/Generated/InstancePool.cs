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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a InstancePool along with the instance operations that can be performed on it. </summary>
    public partial class InstancePool : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="InstancePool"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instancePoolName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _instancePoolClientDiagnostics;
        private readonly InstancePoolsRestOperations _instancePoolRestClient;
        private readonly ClientDiagnostics _managedInstanceClientDiagnostics;
        private readonly ManagedInstancesRestOperations _managedInstanceRestClient;
        private readonly ClientDiagnostics _usagesClientDiagnostics;
        private readonly UsagesRestOperations _usagesRestClient;
        private readonly InstancePoolData _data;

        /// <summary> Initializes a new instance of the <see cref="InstancePool"/> class for mocking. </summary>
        protected InstancePool()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "InstancePool"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal InstancePool(ArmClient armClient, InstancePoolData data) : this(armClient, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="InstancePool"/> class. </summary>
        /// <param name="armClient"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal InstancePool(ArmClient armClient, ResourceIdentifier id) : base(armClient, id)
        {
            _instancePoolClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ResourceType, out string instancePoolApiVersion);
            _instancePoolRestClient = new InstancePoolsRestOperations(_instancePoolClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, instancePoolApiVersion);
            _managedInstanceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ManagedInstance.ResourceType.Namespace, DiagnosticOptions);
            ArmClient.TryGetApiVersion(ManagedInstance.ResourceType, out string managedInstanceApiVersion);
            _managedInstanceRestClient = new ManagedInstancesRestOperations(_managedInstanceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceApiVersion);
            _usagesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
            _usagesRestClient = new UsagesRestOperations(_usagesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/instancePools";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual InstancePoolData Data
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: InstancePools_Get
        /// <summary> Gets an instance pool. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<InstancePool>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.Get");
            scope.Start();
            try
            {
                var response = await _instancePoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _instancePoolClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new InstancePool(ArmClient, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: InstancePools_Get
        /// <summary> Gets an instance pool. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<InstancePool> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.Get");
            scope.Start();
            try
            {
                var response = _instancePoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _instancePoolClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstancePool(ArmClient, response.Value), response.GetRawResponse());
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
            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.GetAvailableLocations");
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
            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.GetAvailableLocations");
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: InstancePools_Delete
        /// <summary> Deletes an instance pool. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<InstancePoolDeleteOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.Delete");
            scope.Start();
            try
            {
                var response = await _instancePoolRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new InstancePoolDeleteOperation(_instancePoolClientDiagnostics, Pipeline, _instancePoolRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: InstancePools_Delete
        /// <summary> Deletes an instance pool. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual InstancePoolDeleteOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.Delete");
            scope.Start();
            try
            {
                var response = _instancePoolRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new InstancePoolDeleteOperation(_instancePoolClientDiagnostics, Pipeline, _instancePoolRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response);
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

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public async virtual Task<Response<InstancePool>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _instancePoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new InstancePool(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add a tag to the current resource. </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag added. </returns>
        public virtual Response<InstancePool> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _instancePoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new InstancePool(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public async virtual Task<Response<InstancePool>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _instancePoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new InstancePool(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace the tags on the resource with the given set. </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tags replaced. </returns>
        public virtual Response<InstancePool> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags), $"{nameof(tags)} provided cannot be null.");
            }

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _instancePoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new InstancePool(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public async virtual Task<Response<InstancePool>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _instancePoolRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new InstancePool(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes a tag by key from the resource. </summary>
        /// <param name="key"> The key of the tag to remove. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The updated resource with the tag removed. </returns>
        public virtual Response<InstancePool> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _instancePoolRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new InstancePool(ArmClient, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: InstancePools_Update
        /// <summary> Updates an instance pool. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The requested instance pool resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<InstancePoolUpdateOperation> UpdateAsync(bool waitForCompletion, InstancePoolUpdate parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.Update");
            scope.Start();
            try
            {
                var response = await _instancePoolRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new InstancePoolUpdateOperation(ArmClient, _instancePoolClientDiagnostics, Pipeline, _instancePoolRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: InstancePools_Update
        /// <summary> Updates an instance pool. </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> The requested instance pool resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual InstancePoolUpdateOperation Update(bool waitForCompletion, InstancePoolUpdate parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _instancePoolClientDiagnostics.CreateScope("InstancePool.Update");
            scope.Start();
            try
            {
                var response = _instancePoolRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                var operation = new InstancePoolUpdateOperation(ArmClient, _instancePoolClientDiagnostics, Pipeline, _instancePoolRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters).Request, response);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}/managedInstances
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: ManagedInstances_ListByInstancePool
        /// <summary> Gets a list of all managed instances in an instance pool. </summary>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedInstanceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedInstanceData> GetManagedInstancesAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedInstanceData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceClientDiagnostics.CreateScope("InstancePool.GetManagedInstances");
                scope.Start();
                try
                {
                    var response = await _managedInstanceRestClient.ListByInstancePoolAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedInstanceData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceClientDiagnostics.CreateScope("InstancePool.GetManagedInstances");
                scope.Start();
                try
                {
                    var response = await _managedInstanceRestClient.ListByInstancePoolNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}/managedInstances
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: ManagedInstances_ListByInstancePool
        /// <summary> Gets a list of all managed instances in an instance pool. </summary>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedInstanceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedInstanceData> GetManagedInstances(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedInstanceData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceClientDiagnostics.CreateScope("InstancePool.GetManagedInstances");
                scope.Start();
                try
                {
                    var response = _managedInstanceRestClient.ListByInstancePool(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedInstanceData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceClientDiagnostics.CreateScope("InstancePool.GetManagedInstances");
                scope.Start();
                try
                {
                    var response = _managedInstanceRestClient.ListByInstancePoolNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}/usages
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: Usages_ListByInstancePool
        /// <summary> Gets all instance pool usage metrics. </summary>
        /// <param name="expandChildren"> Optional request parameter to include managed instance usages within the instance pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="InstancePoolUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<InstancePoolUsage> GetUsagesAsync(bool? expandChildren = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<InstancePoolUsage>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _usagesClientDiagnostics.CreateScope("InstancePool.GetUsages");
                scope.Start();
                try
                {
                    var response = await _usagesRestClient.ListByInstancePoolAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expandChildren, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<InstancePoolUsage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _usagesClientDiagnostics.CreateScope("InstancePool.GetUsages");
                scope.Start();
                try
                {
                    var response = await _usagesRestClient.ListByInstancePoolNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expandChildren, cancellationToken: cancellationToken).ConfigureAwait(false);
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

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}/usages
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}
        /// OperationId: Usages_ListByInstancePool
        /// <summary> Gets all instance pool usage metrics. </summary>
        /// <param name="expandChildren"> Optional request parameter to include managed instance usages within the instance pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="InstancePoolUsage" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<InstancePoolUsage> GetUsages(bool? expandChildren = null, CancellationToken cancellationToken = default)
        {
            Page<InstancePoolUsage> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _usagesClientDiagnostics.CreateScope("InstancePool.GetUsages");
                scope.Start();
                try
                {
                    var response = _usagesRestClient.ListByInstancePool(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expandChildren, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<InstancePoolUsage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _usagesClientDiagnostics.CreateScope("InstancePool.GetUsages");
                scope.Start();
                try
                {
                    var response = _usagesRestClient.ListByInstancePoolNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expandChildren, cancellationToken: cancellationToken);
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
    }
}
