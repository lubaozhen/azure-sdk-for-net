// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    public static partial class ArmClientExtensions
    {
        #region Deployment
        /// <summary> Gets an object representing a Deployment along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Deployment" /> object. </returns>
        public static Deployment GetDeployment(this ArmClient armClient, ResourceIdentifier id)
        {
            Deployment.ValidateResourceId(id);
            return new Deployment(armClient, id);
        }
        #endregion

        #region Application
        /// <summary> Gets an object representing a Application along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Application" /> object. </returns>
        public static Application GetApplication(this ArmClient armClient, ResourceIdentifier id)
        {
            Application.ValidateResourceId(id);
            return new Application(armClient, id);
        }
        #endregion

        #region ApplicationDefinition
        /// <summary> Gets an object representing a ApplicationDefinition along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ApplicationDefinition" /> object. </returns>
        public static ApplicationDefinition GetApplicationDefinition(this ArmClient armClient, ResourceIdentifier id)
        {
            ApplicationDefinition.ValidateResourceId(id);
            return new ApplicationDefinition(armClient, id);
        }
        #endregion

        #region JitRequestDefinition
        /// <summary> Gets an object representing a JitRequestDefinition along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="JitRequestDefinition" /> object. </returns>
        public static JitRequestDefinition GetJitRequestDefinition(this ArmClient armClient, ResourceIdentifier id)
        {
            JitRequestDefinition.ValidateResourceId(id);
            return new JitRequestDefinition(armClient, id);
        }
        #endregion

        #region DeploymentScript
        /// <summary> Gets an object representing a DeploymentScript along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeploymentScript" /> object. </returns>
        public static DeploymentScript GetDeploymentScript(this ArmClient armClient, ResourceIdentifier id)
        {
            DeploymentScript.ValidateResourceId(id);
            return new DeploymentScript(armClient, id);
        }
        #endregion

        #region ScriptLog
        /// <summary> Gets an object representing a ScriptLog along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ScriptLog" /> object. </returns>
        public static ScriptLog GetScriptLog(this ArmClient armClient, ResourceIdentifier id)
        {
            ScriptLog.ValidateResourceId(id);
            return new ScriptLog(armClient, id);
        }
        #endregion

        #region TemplateSpec
        /// <summary> Gets an object representing a TemplateSpec along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TemplateSpec" /> object. </returns>
        public static TemplateSpec GetTemplateSpec(this ArmClient armClient, ResourceIdentifier id)
        {
            TemplateSpec.ValidateResourceId(id);
            return new TemplateSpec(armClient, id);
        }
        #endregion

        #region TemplateSpecVersion
        /// <summary> Gets an object representing a TemplateSpecVersion along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="armClient"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TemplateSpecVersion" /> object. </returns>
        public static TemplateSpecVersion GetTemplateSpecVersion(this ArmClient armClient, ResourceIdentifier id)
        {
            TemplateSpecVersion.ValidateResourceId(id);
            return new TemplateSpecVersion(armClient, id);
        }
        #endregion
    }
}
